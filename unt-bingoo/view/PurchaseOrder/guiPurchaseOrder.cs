using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.PurchaseOrder
{
    public partial class guiPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;
        private List<SupplierItem> _suppliers = new List<SupplierItem>();
        private List<OutletItem> _outlets = new List<OutletItem>();
        private List<ProductItem> _products = new List<ProductItem>();
        private List<PurchaseOrderModel> _allPOs = new List<PurchaseOrderModel>();
        private BindingList<PurchaseOrderItemModel> _currentLines = new BindingList<PurchaseOrderItemModel>();

        // Refreshed per product: the units this one may be purchased in, with
        // the factor each converts by. Server-derived — see LoadPurchaseUoms.
        private List<PurchaseUomModel> _purchaseUoms = new List<PurchaseUomModel>();

        public guiPurchaseOrder()
        {
            InitializeComponent();

            _api = APIGlobals.Api;

            gridLines.DataSource = _currentLines;

            this.Load += guiPurchaseOrder_Load;
            btnAddItem.Click += btnAddItem_Click;
            btnSavePO.Click += btnSavePO_Click;
            btnCancel.Click += btnCancel_Click;
            cboProduct.SelectedIndexChanged += cboProduct_SelectedIndexChanged;
            cboUom.SelectedIndexChanged += cboUom_SelectedIndexChanged;

            // The info panel flags when the picked product's usual supplier
            // isn't the one this PO is going to, so it has to re-evaluate when
            // either side of that comparison changes.
            cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;

            // Master-detail: expanding a PO row shows its line items in
            // gvPODetail (LevelTree/RelationName "Items" — see Designer),
            // same manual-wiring approach guiOutlet already uses for its
            // Photos/Citizenship relations, rather than DevExpress's
            // automatic list-property detection (guiRecipes found that path
            // renders an unformatted, raw-column-name grid).
            gvPO.MasterRowGetRelationCount += (s, e) => e.RelationCount = 1;
            gvPO.MasterRowGetRelationName += (s, e) => e.RelationName = "Items";
            gvPO.MasterRowGetChildList += (s, e) =>
            {
                var po = gvPO.GetRow(e.RowHandle) as PurchaseOrderModel;
                e.ChildList = po?.PurchaseOrderItems;
            };

            gvPO.RowCellStyle += gvPO_RowCellStyle;
        }

        // Colours the Status cell so a long list can be scanned at a glance —
        // the statuses are the ones the backend actually sets (Draft on insert,
        // Ordered once lines are saved, then Received/PartiallyReceived from
        // the receive flow); anything else is left with the default styling.
        private void gvPO_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column != colPOStatus)
                return;

            var status = gvPO.GetRowCellValue(e.RowHandle, colPOStatus) as string;

            System.Drawing.Color color;

            switch (status)
            {
                case "Draft":
                    color = System.Drawing.Color.Gray;
                    break;
                case "Ordered":
                    color = System.Drawing.Color.RoyalBlue;
                    break;
                case "PartiallyReceived":
                    color = System.Drawing.Color.DarkOrange;
                    break;
                case "Received":
                    color = System.Drawing.Color.SeaGreen;
                    break;
                default:
                    return;
            }

            e.Appearance.ForeColor = color;
            e.Appearance.Font = new System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold);
        }

        private async void guiPurchaseOrder_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            dtpExpectedDate.Value = DateTime.Today.AddDays(7);

            await LoadSuppliers();
            await LoadOutlets();
            await LoadProducts();
            await LoadPOList();
        }

        private async System.Threading.Tasks.Task LoadSuppliers()
        {
            try
            {
                _suppliers = await _api.GetAsync<List<SupplierItem>>("api/supplier") ?? new List<SupplierItem>();

                cboSupplier.DataSource = _suppliers;
                cboSupplier.DisplayMember = "SupplierName";
                cboSupplier.ValueMember = "SupplierID";
                cboSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        private async System.Threading.Tasks.Task LoadOutlets()
        {
            try
            {
                _outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet") ?? new List<OutletItem>();

                cboOutlet.DataSource = _outlets;
                cboOutlet.DisplayMember = "OutletName";
                cboOutlet.ValueMember = "Id";

                // Default to the HeadOffice warehouse (the old hardcoded
                // behavior) so nothing changes for buyers who never touch
                // this field, while still letting them pick another outlet.
                var headOffice = _outlets.FirstOrDefault(o => o.HeadOffice);
                cboOutlet.SelectedItem = headOffice ?? _outlets.FirstOrDefault();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading outlets: " + ex.Message);
            }
        }

        // Fetched once and kept; the supplier filter runs against this cache so
        // changing supplier does not re-hit the API on every click.
        private async System.Threading.Tasks.Task LoadProducts()
        {
            try
            {
                _products = (await _api.GetAsync<List<ProductItem>>("api/product") ?? new List<ProductItem>())
                            .OrderBy(p => p.ProName)
                            .ToList();

                // ProductPickerName leads with the name (not the barcode) so the
                // combo's built-in type-to-find still works the way a buyer
                // expects, while the code stays visible for identification.
                cboProduct.DisplayMember = "ProductPickerName";
                cboProduct.ValueMember = "ProNumY";

                ApplyProductFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        // A purchase order goes to ONE supplier, so the product list should be
        // what that supplier actually sells. Showing the whole catalogue meant
        // scrolling past hundreds of products that this order could never
        // legitimately contain.
        //
        // Products with no supplier recorded are kept in the list: they are
        // unassigned rather than known to belong to someone else, and dropping
        // them would make them unorderable from every supplier at once.
        private void ApplyProductFilter()
        {
            var supplier = cboSupplier.SelectedItem as SupplierItem;

            List<ProductItem> visible;

            if (supplier == null)
            {
                visible = new List<ProductItem>();
            }
            else
            {
                visible = _products
                    .Where(p => !p.SupplierID.HasValue || p.SupplierID.Value == supplier.SupplierID)
                    .ToList();
            }

            cboProduct.DataSource = visible;
            cboProduct.SelectedIndex = -1;
        }

        private async System.Threading.Tasks.Task LoadPOList()
        {
            try
            {
                var list = await _api.GetAsync<List<PurchaseOrderModel>>("api/purchaseorder") ?? new List<PurchaseOrderModel>();

                foreach (var po in list)
                {
                    po.SupplierName = _suppliers.FirstOrDefault(s => s.SupplierID == po.SupplierID)?.SupplierName
                                       ?? $"#{po.SupplierID}";

                    po.OutletName = _outlets.FirstOrDefault(o => o.Id == po.OutletID)?.OutletName
                                     ?? $"#{po.OutletID}";

                    // The master-detail grid binds ProductName directly (no
                    // per-cell lookup like the old popup did), so it has to be
                    // filled in here once instead.
                    foreach (var item in po.PurchaseOrderItems)
                    {
                        item.ProductName = _products.FirstOrDefault(p => p.ProNumY == item.ProNumY)?.ProName
                                            ?? item.ProNumY;
                    }
                }

                _allPOs = list;

                ApplyFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading purchase orders: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            var keyword = txtSearch.Text.Trim();

            var list = string.IsNullOrWhiteSpace(keyword)
                ? _allPOs
                : _allPOs.Where(p =>
                    (p.PurchaseOrderNo ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.SupplierName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.Status ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            gridPO.DataSource = list;
            gvPO.BestFitColumns();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPOList();
        }

        // Pre-fills Unit Cost from the product's own stored purchase price
        // (ProImpPri — "Import Price", what the supplier is paid) instead of
        // leaving it at 0 for every line; still just a starting value, the
        // buyer can still change it for a one-off deal. The label shows which
        // currency that stored price is actually in, since the PO itself has
        // no currency picker (it's saved server-side against the shop's
        // default/base currency — see PurchaseOrderRepository.CreateAsync) —
        // if a supplier's product is priced in something else, this makes
        // that visible instead of silently mixing currencies.
        private async void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = cboProduct.SelectedItem as ProductItem;

            if (product == null)
            {
                lblUnitCost.Text = "Unit Cost :";
                cboUom.DataSource = null;
                _purchaseUoms.Clear();
                ClearProductInfo();
                return;
            }

            await LoadPurchaseUoms(product.ProNumY);

            txtUnitCost.Text = (product.ProImpPri ?? 0m).ToString("0.####");

            // Same reasoning as the unit cost above: the product already
            // carries its own VAT rate, so pre-fill it rather than making the
            // buyer look it up and retype it on every line.
            txtTax.Text = (product.ProVAT ?? 0f).ToString("0.####");

            lblUnitCost.Text = string.IsNullOrWhiteSpace(product.ProCurr)
                ? "Unit Cost :"
                : $"Unit Cost ({product.ProCurr}) :";

            ShowProductInfo(product);
        }

        // Everything below comes off the product record the buyer just picked —
        // it's the context needed to decide whether (and how much) to order,
        // which otherwise means leaving this screen to go look at the product.
        private void ShowProductInfo(ProductItem product)
        {
            lblInfoCodeValue.Text = OrDash(product.ProNumY);
            lblInfoUnitValue.Text = OrDash(product.ProUnit);
            lblInfoCategoryValue.Text = OrDash(product.categoryName);

            decimal onHand = product.ProTotQty ?? 0;
            decimal reorderAt = product.ProRecLev ?? 0m;

            lblInfoOnHandValue.Text = onHand.ToString("N0");
            lblInfoReorderValue.Text = reorderAt > 0 ? reorderAt.ToString("N0") : "-";

            // At or below the reorder level is the whole reason to be raising a
            // PO, so flag it instead of leaving the buyer to compare two numbers.
            lblInfoOnHandValue.Appearance.ForeColor = (reorderAt > 0 && onHand <= reorderAt)
                ? System.Drawing.Color.Firebrick
                : System.Drawing.Color.FromArgb(40, 40, 40);

            lblInfoLastCostValue.Text = (product.ProImpPri ?? 0m).ToString("N2")
                + (string.IsNullOrWhiteSpace(product.ProCurr) ? "" : " " + product.ProCurr);

            lblInfoVatValue.Text = (product.ProVAT ?? 0f).ToString("0.##") + " %";

            // Prefer the supplier master's own name over the product's cached
            // Sup1 text, which is free-form and drifts out of date.
            string productSupplier = null;

            if (product.SupplierID.HasValue)
            {
                productSupplier = _suppliers
                    .FirstOrDefault(s => s.SupplierID == product.SupplierID.Value)?.SupplierName;
            }

            if (string.IsNullOrWhiteSpace(productSupplier))
                productSupplier = product.Sup1;

            lblInfoSupplierValue.Text = OrDash(productSupplier);

            // Ordering a product from a supplier that isn't its usual one is
            // legitimate, but it's worth making visible rather than silent.
            var poSupplier = cboSupplier.SelectedItem as SupplierItem;

            bool differentSupplier = poSupplier != null
                                     && product.SupplierID.HasValue
                                     && product.SupplierID.Value != poSupplier.SupplierID;

            lblInfoSupplierValue.Appearance.ForeColor = differentSupplier
                ? System.Drawing.Color.DarkOrange
                : System.Drawing.Color.FromArgb(40, 40, 40);
        }

        // The units this product may be bought in. Asked of the server rather
        // than assembled here: it knows which units reduce to the product's
        // stocking unit, and it is the same rule that decides whether the
        // receipt will be accepted. Building the list locally would let this
        // form offer something receiving then rejects.
        private async System.Threading.Tasks.Task LoadPurchaseUoms(string proNumY)
        {
            try
            {
                _purchaseUoms = await _api.GetAsync<List<PurchaseUomModel>>(
                    "api/PurchaseOrder/purchase-units/" + Uri.EscapeDataString(proNumY ?? string.Empty))
                    ?? new List<PurchaseUomModel>();
            }
            catch
            {
                // An older server without the endpoint, or a product with no
                // stocking unit. Left empty on purpose: Add Line then refuses
                // rather than quietly sending a quantity with no unit, which is
                // the state that made a kilogram arrive as a gram.
                _purchaseUoms = new List<PurchaseUomModel>();
            }

            cboUom.DataSource = null;

            if (_purchaseUoms.Count == 0)
            {
                lblQuantity.Text = "Quantity :";
                return;
            }

            cboUom.DataSource = _purchaseUoms;
            cboUom.DisplayMember = "Display";
            cboUom.ValueMember = "UOMCode";

            // The stocking unit is the safe default — it is what the old form
            // always effectively sent, so a buyer who ignores this dropdown
            // gets exactly the previous behaviour rather than a surprise.
            var baseUnit = _purchaseUoms.FirstOrDefault(u => u.IsBaseUnit) ?? _purchaseUoms[0];
            cboUom.SelectedItem = baseUnit;

            ShowQuantityHint();
        }

        // "Quantity (stocked in G) :" — names the unit stock is actually kept
        // in, right where the number is typed.
        private void ShowQuantityHint()
        {
            var uom = cboUom.SelectedItem as PurchaseUomModel;

            lblQuantity.Text = uom == null || string.IsNullOrWhiteSpace(uom.BaseUOMCode)
                ? "Quantity :"
                : "Quantity (stocked in " + uom.BaseUOMCode + ") :";
        }

        private void cboUom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowQuantityHint();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Rebuilds the product list for the newly chosen supplier. Any
            // product already picked is cleared by ApplyProductFilter, which is
            // deliberate: it may not be on the new supplier's list at all, and
            // silently keeping it is how a line ends up on the wrong order.
            ApplyProductFilter();

            var product = cboProduct.SelectedItem as ProductItem;

            if (product != null)
                ShowProductInfo(product);
        }

        private void ClearProductInfo()
        {
            lblInfoCodeValue.Text = "-";
            lblInfoUnitValue.Text = "-";
            lblInfoCategoryValue.Text = "-";
            lblInfoSupplierValue.Text = "-";
            lblInfoOnHandValue.Text = "-";
            lblInfoReorderValue.Text = "-";
            lblInfoLastCostValue.Text = "-";
            lblInfoVatValue.Text = "-";

            lblInfoOnHandValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            lblInfoSupplierValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
        }

        private static string OrDash(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value.Trim();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var product = cboProduct.SelectedItem as ProductItem;

            if (product == null)
            {
                XtraMessageBox.Show("Please select a product.");
                return;
            }

            // Decimal, not int: a supplier sells 2.5 KG of coffee and the old
            // int.TryParse rejected the line outright.
            if (!decimal.TryParse(txtQuantity.Text.Trim(), out decimal qty) || qty <= 0)
            {
                XtraMessageBox.Show("Please enter a valid quantity.");
                return;
            }

            var uom = cboUom.SelectedItem as PurchaseUomModel;

            // No unit means no way to know whether "1" bought a kilogram or a
            // gram, and guessing is exactly the defect this screen now exists
            // to close. Refuse rather than send an unlabelled number.
            if (uom == null)
            {
                XtraMessageBox.Show(
                    "This product has no purchase unit available, so a line cannot be added.\n\n" +
                    "Set the product's stocking unit (Unit) in Product Management first.",
                    "Missing unit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtUnitCost.Text.Trim(), out decimal unitCost) || unitCost < 0)
            {
                XtraMessageBox.Show("Please enter a valid unit cost.");
                return;
            }

            decimal.TryParse(txtDiscount.Text.Trim(), out decimal discountPercent);
            decimal.TryParse(txtTax.Text.Trim(), out decimal taxPercent);

            var subTotal = qty * unitCost;
            var discountAmount = subTotal * discountPercent / 100;
            var afterDiscount = subTotal - discountAmount;
            var taxAmount = afterDiscount * taxPercent / 100;
            var totalCost = afterDiscount + taxAmount;

            _currentLines.Add(new PurchaseOrderItemModel
            {
                ProNumY = product.ProNumY,
                ProductName = product.ProName,
                Quantity = qty,

                // Quantity and UnitCost are both in this unit — exactly what
                // the supplier invoiced. The server converts on receipt; the
                // order keeps saying "5 KG @ $12".
                UOMCode = uom.UOMCode,
                LocalFactor = uom.ConversionFactor,
                LocalBaseUOMCode = uom.BaseUOMCode,

                UnitCost = unitCost,
                DiscountPercent = discountPercent,
                DiscountAmount = discountAmount,
                TaxPercent = taxPercent,
                TaxAmount = taxAmount,
                SubTotal = subTotal,
                TotalCost = totalCost
            });

            RecalculateTotals();

            cboProduct.SelectedIndex = -1;
            txtQuantity.Text = "1";
            txtUnitCost.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";
        }

        private void btnRemoveLine_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var line = gvLines.GetFocusedRow() as PurchaseOrderItemModel;

            if (line == null)
                return;

            _currentLines.Remove(line);
            RecalculateTotals();
        }

        private void RecalculateTotals()
        {
            var subTotal = _currentLines.Sum(l => l.SubTotal);
            var discountAmount = _currentLines.Sum(l => l.DiscountAmount);
            var taxAmount = _currentLines.Sum(l => l.TaxAmount);
            var grandTotal = _currentLines.Sum(l => l.TotalCost);

            lblSubTotalValue.Text = subTotal.ToString("N2");

            // Discount and tax were already being summed here but never shown,
            // so the jump from Sub Total to Grand Total looked unexplained.
            lblDiscountTotalValue.Text = "-" + discountAmount.ToString("N2");
            lblTaxTotalValue.Text = taxAmount.ToString("N2");

            lblGrandTotal.Text = "Grand Total : " + grandTotal.ToString("N2");
        }

        private async void btnSavePO_Click(object sender, EventArgs e)
        {
            var supplier = cboSupplier.SelectedItem as SupplierItem;

            if (supplier == null)
            {
                XtraMessageBox.Show("Please select a supplier.");
                return;
            }

            var outlet = cboOutlet.SelectedItem as OutletItem;

            if (outlet == null)
            {
                XtraMessageBox.Show("Please select a warehouse.");
                return;
            }

            if (_currentLines.Count == 0)
            {
                XtraMessageBox.Show("Please add at least one line item.");
                return;
            }

            var dto = new
            {
                SupplierID = supplier.SupplierID,
                OutletID = outlet.Id,
                ExpectedDate = dtpExpectedDate.Value,
                Note = txtNote.Text.Trim(),
                Items = _currentLines.Select(l => new
                {
                    l.ProNumY,
                    l.Quantity,
                    l.UOMCode,          // without this the server falls back to
                                        // the stocking unit, and 5 KG posts as 5 G
                    l.UnitCost,
                    l.DiscountPercent,
                    l.TaxPercent
                }).ToList()
            };

            try
            {
                var ok = await _api.PostAsync("api/purchaseorder", dto);

                if (!ok)
                {
                    XtraMessageBox.Show("Save failed.");
                    return;
                }

                XtraMessageBox.Show(
                    "Purchase order saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
                await LoadPOList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cboSupplier.SelectedIndex = -1;

            var headOffice = _outlets.FirstOrDefault(o => o.HeadOffice);
            cboOutlet.SelectedItem = headOffice ?? _outlets.FirstOrDefault();

            dtpExpectedDate.Value = DateTime.Today.AddDays(7);
            txtNote.Text = string.Empty;

            cboProduct.SelectedIndex = -1;
            txtQuantity.Text = "1";
            txtUnitCost.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";

            _currentLines.Clear();
            RecalculateTotals();
        }

        // The supplier's copy of the order. Everything it needs is already in
        // memory — the PO with its lines, plus the supplier, warehouse and
        // product caches this form loaded at startup — so printing does not
        // depend on the API being reachable at that moment.
        private void btnMainPrint_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            if (po.PurchaseOrderItems == null || po.PurchaseOrderItems.Count == 0)
            {
                XtraMessageBox.Show("This purchase order has no lines to print.");
                return;
            }

            try
            {
                var supplier = _suppliers.FirstOrDefault(s => s.SupplierID == po.SupplierID);
                var warehouse = _outlets.FirstOrDefault(o => o.Id == po.OutletID);

                // Barcode and product name come off the product master; the
                // order line only stores the code.
                var byCode = _products
                    .Where(p => !string.IsNullOrWhiteSpace(p.ProNumY))
                    .GroupBy(p => p.ProNumY)
                    .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

                var report = new rptPurchaseOrder(po, supplier, warehouse, byCode);

                // Preview rather than straight to the printer: the buyer still
                // has to choose a printer, and can export to PDF to email the
                // supplier instead of putting it on paper. ReportPrintTool is
                // the version-stable way in; XtraReport's own preview helpers
                // moved between DevExpress releases.
                using (var tool = new DevExpress.XtraReports.UI.ReportPrintTool(report))
                {
                    tool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Could not print this purchase order: " + ex.Message);
            }
        }

        private async void btnMainReceive_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            if (po.Status == "Received")
            {
                XtraMessageBox.Show("This purchase order has already been fully received.");
                return;
            }

            if (!po.PurchaseOrderItems.Any(i => i.Quantity - i.ReceivedQty > 0))
            {
                XtraMessageBox.Show("There is no remaining quantity to receive.");
                return;
            }

            // Per-line receive screen, not a single "receive everything"
            // confirm: lets the buyer receive less than the full remaining
            // quantity, and record a lot number / expiry date per line. The
            // dialog itself posts to the server and reports success/failure.
            using (var dlg = new FrmReceivePurchaseOrder(po, _api))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    await LoadPOList();
            }
        }

        private async void btnMainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var po = gvPO.GetFocusedRow() as PurchaseOrderModel;

            if (po == null)
                return;

            if (MessageBox.Show(
                    $"Are you sure you want to delete purchase order '{po.PurchaseOrderNo}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var ok = await _api.DeleteAsync($"api/purchaseorder/{po.PurchaseOrderID}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed.");
                    return;
                }

                await LoadPOList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPO.RowCount <= 0)
                {
                    MessageBox.Show(
                        "No data to export.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                Cursor = Cursors.WaitCursor;

                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                int excelCol = 1;

                for (int col = 0; col < gvPO.Columns.Count; col++)
                {
                    var column = gvPO.Columns[col];

                    if (column == colPOReceive || column == colPODelete)
                        continue;

                    worksheet.Cells[1, excelCol] = column.Caption;
                    ((Excel.Range)worksheet.Cells[1, excelCol]).Font.Bold = true;

                    excelCol++;
                }

                for (int row = 0; row < gvPO.RowCount; row++)
                {
                    excelCol = 1;

                    for (int col = 0; col < gvPO.Columns.Count; col++)
                    {
                        var column = gvPO.Columns[col];

                        if (column == colPOReceive || column == colPODelete)
                            continue;

                        object value = gvPO.GetRowCellValue(row, column);

                        worksheet.Cells[row + 2, excelCol] = value?.ToString() ?? "";

                        excelCol++;
                    }
                }

                worksheet.Columns.AutoFit();

                Cursor = Cursors.Default;

                MessageBox.Show(
                    "Export completed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
