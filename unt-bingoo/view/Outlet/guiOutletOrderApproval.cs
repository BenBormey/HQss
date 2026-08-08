using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutletOrderApproval : XtraForm
    {
        private APIsController _api;
        private List<OutletOrderModel> _allOrders = new List<OutletOrderModel>();
        private Dictionary<int, string> _outletNames = new Dictionary<int, string>();
        private Dictionary<string, string> _productNames = new Dictionary<string, string>();

        // Whether the currently focused order's outlet is a Franchise — a
        // Company-Own outlet stays a free internal move and never needs
        // colUnitPrice at all.
        private bool _isFranchiseOutlet;

        public guiOutletOrderApproval()
        {
            InitializeComponent();

            // Added in code so the Designer stays untouched.
            btnRefresh.Image = MenuIcons.Refresh(System.Drawing.Color.FromArgb(60, 64, 72));
            btnApprove.Image = MenuIcons.CheckMark(System.Drawing.Color.White);
            btnReject.Image = MenuIcons.ExitDoor(System.Drawing.Color.White);


            gridViewOrders.MasterRowGetRelationCount += (s, e) => e.RelationCount = 1;
            gridViewOrders.MasterRowGetRelationName += (s, e) => e.RelationName = "Items";
            gridViewOrders.MasterRowGetChildList += (s, e) =>
            {
                var order = gridViewOrders.GetRow(e.RowHandle) as OutletOrderModel;
                e.ChildList = order?.OutletOrderItems ?? new List<OutletOrderItemModel>();
            };

        
            gridViewOrders.SelectionChanged += (s, e) =>
                btnBulkUpdate.Text = $"Update Checked ({gridViewOrders.GetSelectedRows().Length})";
        }

        private async void guiOutletOrderApproval_Load(object sender, EventArgs e)
        {
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                if (!APIGlobals.HasPermission("OUTLET_ORDER"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                cboStatus.SelectedIndex = 1; // default filter: Requested (waiting for approval)

                await LoadLookupsAsync();
                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadLookupsAsync()
        {
            var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet")
                          ?? new List<OutletItem>();
            _outletNames = outlets.ToDictionary(o => o.Id, o => o.OutletName);

            var filterOutlets = new List<OutletItem> { new OutletItem { Id = 0, OutletName = "All Outlets" } };
            filterOutlets.AddRange(outlets.OrderBy(o => o.OutletName));
            cboOutletFilter.DataSource = filterOutlets;
            cboOutletFilter.DisplayMember = "OutletName";
            cboOutletFilter.ValueMember = "Id";
            cboOutletFilter.SelectedIndex = 0;

            var products = await _api.GetAsync<List<ProductItem>>("api/Product")
                           ?? new List<ProductItem>();
            _productNames = products
                .Where(p => !string.IsNullOrEmpty(p.ProNumY))
                .GroupBy(p => p.ProNumY)
                .ToDictionary(g => g.Key, g => g.First().ProName);
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await _api.GetAsync<List<OutletOrderModel>>("api/OutletOrder")
                             ?? new List<OutletOrderModel>();

                foreach (var o in orders)
                {
                    o.OutletName = _outletNames.TryGetValue(o.OutletID, out var name)
                        ? name
                        : $"Outlet #{o.OutletID}";
                }

                _allOrders = orders;

                ApplyStatusFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyStatusFilter()
        {
            string status = cboStatus.SelectedItem?.ToString() ?? "All";
            int outletId = (cboOutletFilter.SelectedItem as OutletItem)?.Id ?? 0;

            IEnumerable<OutletOrderModel> filtered = _allOrders;

            if (status != "All")
                filtered = filtered.Where(o => o.Status == status);

            if (outletId != 0)
                filtered = filtered.Where(o => o.OutletID == outletId);

            var list = filtered.ToList();

            gridControlOrders.DataSource = list;
            gridViewOrders.BestFitColumns();
            lblCountRow.Text = list.Count.ToString("N0");

            // Rebinding DataSource collapses any expanded row and doesn't
            // reliably re-fire FocusedRowChanged, so refresh explicitly
            // rather than depend on it.
            RefreshActionButtons();
        }

        private OutletOrderModel FocusedOrder()
        {
            return gridViewOrders.GetFocusedRow() as OutletOrderModel;
        }

        private async void gridViewOrders_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            RefreshActionButtons();

            // Only one row's items are ever shown expanded at a time —
            // colUnitPrice/colFulfillQty visibility below is set per the
            // newly-focused order and shared by the one detail view
            // template, so two different orders' rules could never both
            // apply correctly if more than one stayed expanded together.
            for (int i = 0; i < gridViewOrders.RowCount; i++)
            {
                int handle = gridViewOrders.GetRowHandle(i);
                if (handle != e.FocusedRowHandle && gridViewOrders.GetMasterRowExpanded(handle))
                    gridViewOrders.SetMasterRowExpanded(handle, false);
            }

            // Load before expanding, so MasterRowGetChildList reads an
            // already-populated OutletOrderItems the moment it's asked.
            await LoadItemsForFocusedOrderAsync();

            if (e.FocusedRowHandle >= 0)
                gridViewOrders.SetMasterRowExpanded(e.FocusedRowHandle, true);
        }

        // btnApprove is a single button that relabels itself and does whatever
        // action is next for the focused order's current status — same pattern
        // as it already had for Requested (Approve) before this pipeline grew.
        //
        // Matches OutletOrderRepository's actual state machine exactly —
        // there is no Picking/Packing/ReadyToShip stage on the backend at
        // all (UpdateStatusAsync's allowed-transitions table only lists
        // Requested/Approved/PartiallyFulfilled as valid FROM-states, and
        // Received/PartiallyReceived have no further transition anywhere).
        // The real pipeline is: Requested -> Approved -> (Fulfill, i.e. Ship
        // Now) -> Delivering/PartiallyFulfilled -> (outlet's own Receive,
        // not something HQ does here) -> Received/PartiallyReceived, done.
        private void RefreshActionButtons()
        {
            var order = FocusedOrder();

            if (order == null)
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                return;
            }

            btnReject.Visible = order.Status == "Requested"
                || order.Status == "Approved"
                || order.Status == "PartiallyFulfilled";

            switch (order.Status)
            {
                case "Requested":
                    btnApprove.Text = "&Approve";
                    btnApprove.Visible = true;
                    break;
                case "Approved":
                case "PartiallyFulfilled":
                    btnApprove.Text = "&Ship Now";
                    btnApprove.Visible = true;
                    break;
                default:
                    // Delivering/PartiallyReceived — stock is in transit or
                    // partially confirmed; only the requesting outlet can act
                    // from here (ReceiveAsync is gated to the outlet's own
                    // token, not HQ's OUTLET_ORDER permission). Received/
                    // Rejected are terminal. Nothing for HQ to do in either case.
                    btnApprove.Visible = false;
                    break;
            }
        }

        private async Task LoadItemsForFocusedOrderAsync()
        {
            var order = FocusedOrder();

            if (order == null)
                return;

            try
            {
                // GetById returns the order with its items populated.
                var full = await _api.GetAsync<OutletOrderModel>($"api/OutletOrder/{order.OutletOrderID}");

                var items = full?.OutletOrderItems ?? new List<OutletOrderItemModel>();

                foreach (var it in items)
                {
                    it.ProductName = _productNames.TryGetValue(it.ProNumY, out var name)
                        ? name
                        : "";
                    it.FulfillQty = it.RemainingQty; // default: send everything remaining
                }

                // Same rule IngredientStockTransfer already enforces: a
                // Franchise outlet is a separate business paying for goods,
                // so fulfilling its order needs a price per item.
                var franchiseCheck = await _api.GetAsync<IsFranchiseResponse>(
                    $"api/IngredientStockTransfer/is-franchise?outletId={order.OutletID}");

                _isFranchiseOutlet = franchiseCheck?.IsFranchise ?? false;

                // Pre-fill from the Franchise Price List where a standing
                // price exists — still just a starting value, the approver
                // can change it per item before Ship Now. Done before binding
                // DataSource below so the grid shows the filled-in values
                // straight away instead of needing a refresh.
                if (_isFranchiseOutlet)
                {
                    var prices = await _api.GetAsync<List<FranchisePriceLookupItem>>(
                        $"api/FranchisePriceList/outlet/{order.OutletID}") ?? new List<FranchisePriceLookupItem>();

                    var priceByProduct = prices.ToDictionary(p => p.ProNumY, p => p.UnitPrice);

                    foreach (var it in items)
                    {
                        if (!(it.UnitPrice > 0) && priceByProduct.TryGetValue(it.ProNumY, out var known))
                            it.UnitPrice = known;
                    }
                }

                // Sets the same List<T> reference MasterRowGetChildList reads —
                // updating it here is enough, there's no separate grid/
                // DataSource to reassign now that items are a detail view.
                order.OutletOrderItems = items;

                colUnitPrice.Visible = _isFranchiseOutlet;
                colUnitPrice.OptionsColumn.AllowEdit = _isFranchiseOutlet;

                // Only editable when Ship Now is actually the next possible
                // action (FulfillAsync itself accepts Approved or
                // PartiallyFulfilled — there's no separate ReadyToShip stage).
                // That's the one moment "how much am I actually sending" is a
                // real decision (e.g. a pick came up short); elsewhere it
                // would just be a number nobody reads yet.
                bool canShipNow = order.Status == "Approved" || order.Status == "PartiallyFulfilled";
                colFulfillQty.Visible = canShipNow;
                colFulfillQty.OptionsColumn.AllowEdit = canShipNow;

                gridViewItems.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private async void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_allOrders.Count > 0 || cboStatus.Focused)
                ApplyStatusFilter();
            await Task.CompletedTask;
        }

        private async void cboOutletFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_allOrders.Count > 0 || cboOutletFilter.Focused)
                ApplyStatusFilter();
            await Task.CompletedTask;
        }

        // Dispatches on the focused order's current status — RefreshActionButtons
        // keeps btnApprove's label in sync with exactly one of these cases, so
        // whichever branch runs here matches what the button just said.
        private async void btnApprove_Click(object sender, EventArgs e)
        {
            var order = FocusedOrder();

            if (order == null)
            {
                XtraMessageBox.Show("Please select an order first.");
                return;
            }

            switch (order.Status)
            {
                case "Requested":
                    await ApproveAsync(order);
                    break;
                case "Approved":
                case "PartiallyFulfilled":
                    await ShipNowAsync(order);
                    break;
            }
        }

        // Approving is now just the "yes, fulfill this" decision — no stock
        // moves and no quantities are entered here. That happens later, at
        // Ship Now, once the order has actually been picked and packed.
        private async Task ApproveAsync(OutletOrderModel order)
        {
            if (XtraMessageBox.Show(
                    $"Approve order '{order.OutletOrderNo}' for outlet '{order.OutletName}'?",
                    "Confirm Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await UpdateStatusAsync(order.OutletOrderID, "Approved");
        }

        // The actual shipment: enters what's leaving the warehouse right now
        // (colFulfillQty, editable only at this stage — defaults to the full
        // remaining quantity but can be reduced for a short pick), credits
        // OutletStock, and moves the order to Delivering/PartiallyFulfilled.
        private async Task ShipNowAsync(OutletOrderModel order)
        {
            gridViewItems.PostEditor();
            gridViewItems.UpdateCurrentRow();

            var items = order.OutletOrderItems ?? new List<OutletOrderItemModel>();

            // colFulfillQty has no built-in range validation, so clamp in case
            // someone typed a number outside 0..RemainingQty.
            foreach (var i in items)
                i.FulfillQty = Math.Max(0, Math.Min(i.FulfillQty, i.RemainingQty));

            var toSend = items.Where(i => i.FulfillQty > 0).ToList();

            if (toSend.Count == 0)
            {
                XtraMessageBox.Show("Enter a quantity to ship for at least one item (see 'Fulfill Now').");
                return;
            }

            if (_isFranchiseOutlet)
            {
                var missingPrice = toSend.FirstOrDefault(i => !(i.UnitPrice > 0));
                if (missingPrice != null)
                {
                    XtraMessageBox.Show(
                        $"'{missingPrice.ProNumY}' — '{order.OutletName}' is a Franchise outlet, so a Unit Price is required for every item being shipped.",
                        "Unit Price Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (XtraMessageBox.Show(
                    $"Ship order '{order.OutletOrderNo}' for outlet '{order.OutletName}'?\n\n" +
                    $"{toSend.Count} item(s) will leave the Warehouse now.",
                    "Confirm Ship", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var dto = new FulfillOutletOrderRequest
                {
                    Items = toSend.Select(i => new FulfillOutletOrderItemRequest
                    {
                        OutletOrderItemID = i.OutletOrderItemID,
                        FulfilledQty = i.FulfillQty,
                        UnitPrice = _isFranchiseOutlet ? i.UnitPrice : null
                    }).ToList()
                };

                bool ok = await _api.PostAsync($"api/OutletOrder/fulfill/{order.OutletOrderID}", dto);

                if (!ok)
                    return; // error message already shown by PostAsync

                // Stock has already left the warehouse at this point — a PDF
                // failure (Excel missing, temp file locked) must not look like
                // the shipment itself failed, and must not crash this handler.
                try
                {
                    ExportShipmentToPdf(order, toSend);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        $"Shipped successfully, but the delivery note PDF could not be generated:\n\n{ex.Message}",
                        "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                XtraMessageBox.Show(
                    "Shipped. Stock has left the Warehouse — the outlet will confirm receipt on arrival.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delivery note for what's leaving the warehouse right now — same
        // letterhead/table/signature-line layout as guiStockTransfer's
        // "Save && Export All" PDF, via Excel Interop (no new dependency).
        private void ExportShipmentToPdf(OutletOrderModel order, List<OutletOrderItemModel> shipped)
        {
            Excel.Application excelApp = new Excel.Application { Visible = false, DisplayAlerts = false };
            Excel.Workbook workbook = null;

            try
            {
                workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = (Excel.Worksheet)workbook.ActiveSheet;

                int lastCol = _isFranchiseOutlet ? 6 : 4; // No, Product Code, Product Name, Qty [, Unit Price, Total]

                void Merge(int row, int colFrom, int colTo)
                {
                    ws.Range[ws.Cells[row, colFrom], ws.Cells[row, colTo]].Merge();
                }

                ws.Cells[1, 1] = "UNT WHOLESALE CO., LTD.";
                Merge(1, 1, lastCol);
                ((Excel.Range)ws.Cells[1, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[1, 1]).Font.Size = 14;

                ws.Cells[2, 1] = "No. 891, Phum Toulpongror, Sangkat Chorm Chao, Khan Por Sen Chey, Phnom Penh.";
                Merge(2, 1, lastCol);
                ((Excel.Range)ws.Cells[2, 1]).Font.Size = 9;

                ws.Cells[3, 1] = "Tel: 023 995 900, 012 702 000";
                Merge(3, 1, lastCol);
                ((Excel.Range)ws.Cells[3, 1]).Font.Size = 9;

                ws.Cells[5, 1] = "Outlet Order — Delivery Note";
                Merge(5, 1, lastCol);
                ((Excel.Range)ws.Cells[5, 1]).Font.Bold = true;
                ((Excel.Range)ws.Cells[5, 1]).Font.Size = 13;
                ((Excel.Range)ws.Cells[5, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Cells[7, 1] = "Order No:";
                ((Excel.Range)ws.Cells[7, 1]).Font.Bold = true;
                ws.Cells[7, 2] = order.OutletOrderNo;
                ws.Cells[7, lastCol - 1] = "Outlet:";
                ((Excel.Range)ws.Cells[7, lastCol - 1]).Font.Bold = true;
                ws.Cells[7, lastCol] = order.OutletName;

                ws.Cells[8, 1] = "Shipped By:";
                ((Excel.Range)ws.Cells[8, 1]).Font.Bold = true;
                ws.Cells[8, 2] = APIGlobals.UserName ?? "";
                ws.Cells[8, lastCol - 1] = "Date:";
                ((Excel.Range)ws.Cells[8, lastCol - 1]).Font.Bold = true;
                ws.Cells[8, lastCol] = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                var headers = _isFranchiseOutlet
                    ? new[] { "No", "Product Code", "Product Name", "Qty Shipped", "Unit Price", "Total" }
                    : new[] { "No", "Product Code", "Product Name", "Qty Shipped" };

                int headerRow = 10;
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = (Excel.Range)ws.Cells[headerRow, i + 1];
                    cell.Value = headers[i];
                    cell.Font.Bold = true;
                    cell.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(241, 242, 245));
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                int r = headerRow + 1;
                int no = 1;
                decimal grandTotal = 0m;

                foreach (var item in shipped)
                {
                    ws.Cells[r, 1] = no++;
                    ws.Cells[r, 2] = item.ProNumY;
                    ws.Cells[r, 3] = item.ProductName;
                    ws.Cells[r, 4] = item.FulfillQty;

                    if (_isFranchiseOutlet)
                    {
                        decimal total = (item.UnitPrice ?? 0m) * item.FulfillQty;
                        ws.Cells[r, 5] = item.UnitPrice.HasValue ? (object)item.UnitPrice.Value : "";
                        ws.Cells[r, 6] = total;
                        grandTotal += total;
                    }

                    r++;
                }

                int lastDataRow = r - 1;

                var tableRange = ws.Range[ws.Cells[headerRow, 1], ws.Cells[lastDataRow, lastCol]];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                tableRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                int nextRow = lastDataRow + 2;

                if (_isFranchiseOutlet)
                {
                    Merge(nextRow, lastCol - 2, lastCol - 1);
                    ws.Cells[nextRow, lastCol - 2] = "Grand Total:";
                    ((Excel.Range)ws.Cells[nextRow, lastCol - 2]).Font.Bold = true;
                    ((Excel.Range)ws.Cells[nextRow, lastCol - 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    ws.Cells[nextRow, lastCol] = grandTotal;
                    ((Excel.Range)ws.Cells[nextRow, lastCol]).Font.Bold = true;
                    nextRow += 2;
                }

                // Sign-off line — same layout as guiStockTransfer's PDF.
                int signRow = nextRow + 2;
                int colWidth = Math.Max(2, lastCol / 3);

                Merge(signRow, 1, colWidth);
                ws.Cells[signRow, 1] = "Shipped By";
                ((Excel.Range)ws.Cells[signRow, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, colWidth + 1, colWidth * 2);
                ws.Cells[signRow, colWidth + 1] = "Received By";
                ((Excel.Range)ws.Cells[signRow, colWidth + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Merge(signRow, colWidth * 2 + 1, lastCol);
                ws.Cells[signRow, colWidth * 2 + 1] = "Approved By";
                ((Excel.Range)ws.Cells[signRow, colWidth * 2 + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[1].ColumnWidth = 5;
                ws.Columns[2].ColumnWidth = 16;
                ws.Columns[3].ColumnWidth = 30;
                ws.Columns[4].ColumnWidth = 12;
                if (_isFranchiseOutlet)
                {
                    ws.Columns[5].ColumnWidth = 12;
                    ws.Columns[6].ColumnWidth = 12;
                }

                ws.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                ws.PageSetup.Zoom = false;
                ws.PageSetup.FitToPagesWide = 1;
                ws.PageSetup.FitToPagesTall = false;

                string pdfFile = Path.Combine(
                    Path.GetTempPath(),
                    $"OutletOrder_{order.OutletOrderNo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFile);

                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfFile,
                    UseShellExecute = true
                });
            }
            finally
            {
                workbook?.Close(false);
                excelApp.Quit();
            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            var order = FocusedOrder();

            if (order == null)
            {
                XtraMessageBox.Show("Please select an order first.");
                return;
            }

            if (order.Status != "Requested" && order.Status != "Approved" && order.Status != "PartiallyFulfilled")
            {
                XtraMessageBox.Show(
                    $"Only Requested, Approved, or PartiallyFulfilled orders can be rejected.\nThis order is '{order.Status}'.",
                    "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(
                    $"Reject order '{order.OutletOrderNo}' for outlet '{order.OutletName}'?",
                    "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await UpdateStatusAsync(order.OutletOrderID, "Rejected");
        }

        private async Task UpdateStatusAsync(int orderId, string status)
        {
            try
            {
                bool ok = await _api.PutAsync(
                    $"api/OutletOrder/status/{orderId}?status={status}",
                    new { });

                if (!ok)
                {
                    XtraMessageBox.Show("Update failed.");
                    return;
                }

                XtraMessageBox.Show($"Order moved to '{status}'.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private static string NextBulkStatus(string current)
        {
            switch (current)
            {
                case "Requested": return "Approved";
                default: return null;
            }
        }


        private async void btnBulkUpdate_Click(object sender, EventArgs e)
        {
            var orders = gridViewOrders.GetSelectedRows()
                .Select(h => gridViewOrders.GetRow(h) as OutletOrderModel)
                .Where(o => o != null)
                .ToList();

            if (orders.Count == 0)
            {
                XtraMessageBox.Show("Check at least one order first (the checkbox column on the left).");
                return;
            }

            var actionable = orders.Where(o => NextBulkStatus(o.Status) != null).ToList();
            var skipped = orders.Count - actionable.Count;

            if (actionable.Count == 0)
            {
                XtraMessageBox.Show(
                    "None of the checked orders can be bulk-updated. Only 'Requested' orders can be bulk-approved — " +
                    "Approved/PartiallyFulfilled need Ship Now individually (line items must be reviewed first), " +
                    "and Delivering/Received/Completed/Rejected orders have nothing left to do here.",
                    "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var summary = string.Join("\n", actionable
                .GroupBy(o => $"{o.Status} -> {NextBulkStatus(o.Status)}")
                .Select(g => $"{g.Key}: {g.Count()} order(s)"));

            var confirmMsg = $"Update {actionable.Count} order(s)?\n\n{summary}";

            if (skipped > 0)
                confirmMsg += $"\n\n{skipped} checked order(s) will be skipped (only 'Requested' orders can be bulk-approved — others need Ship Now individually, or have nothing left to do here).";

            if (XtraMessageBox.Show(confirmMsg, "Confirm Bulk Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int succeeded = 0;
            var failed = new List<string>();

            foreach (var order in actionable)
            {
                try
                {
                    bool ok = await _api.PutAsync(
                        $"api/OutletOrder/status/{order.OutletOrderID}?status={NextBulkStatus(order.Status)}",
                        new { });

                    if (ok)
                        succeeded++;
                    else
                        failed.Add(order.OutletOrderNo ?? order.OutletOrderID.ToString());
                }
                catch (Exception ex)
                {
                    failed.Add($"{order.OutletOrderNo} ({ex.Message})");
                }
            }

            if (failed.Count == 0)
                XtraMessageBox.Show($"Updated {succeeded} order(s) successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show(
                    $"{succeeded} succeeded, {failed.Count} failed:\n\n{string.Join("\n", failed)}",
                    "Some Updates Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            await LoadOrdersAsync();
        }
    }
}
