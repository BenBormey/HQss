using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view.OutletOrder
{
    // Warehouse-side approval screen for outlet restock requests: pick a
    // request, see each line against current warehouse stock, edit the
    // fulfill quantity per line, then Fulfill (moves stock warehouse ->
    // outlet) or Reject. Server enforces the OUTLET_ORDER permission on
    // both actions. Controls are built in code — no .Designer.cs.
    //
    // Open it from a menu with: new guiOutletOrderApproval().ShowDialog();
    public class guiOutletOrderApproval : XtraForm
    {
        private const string AllStatuses = "All";

        private readonly APIsController _api;

        // ---- DTOs mirroring the JuJuBiAPI endpoints (kept local so the
        // form is self-contained) ----
        private class OutletOrderItemDto
        {
            public int OutletOrderItemID { get; set; }
            public int OutletOrderID { get; set; }
            public string ProNumY { get; set; }
            public int RequestedQty { get; set; }
            public int FulfilledQty { get; set; }
        }

        private class OutletOrderDto
        {
            public int OutletOrderID { get; set; }
            public string OutletOrderNo { get; set; }
            public int OutletID { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime? ExpectedDate { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
            public DateTime CreatedAt { get; set; }
            public List<OutletOrderItemDto> OutletOrderItems { get; set; }
        }

        private class OutletDto
        {
            public int Id { get; set; }
            public string OutletName { get; set; }
        }

        private class WarehouseStockDto
        {
            public string ProNumY { get; set; }
            public decimal StockQty { get; set; }
        }

        private class MenuItemDto
        {
            public string ProNumY { get; set; }
            public string ProductName { get; set; }
        }

        private class FulfillItemDto
        {
            public int OutletOrderItemID { get; set; }
            public int FulfilledQty { get; set; }
        }

        private class FulfillDto
        {
            public List<FulfillItemDto> Items { get; set; }
        }

        // ---- state ----
        private List<OutletOrderDto> _orders = new List<OutletOrderDto>();
        private Dictionary<int, string> _outletNames = new Dictionary<int, string>();
        private Dictionary<string, decimal> _warehouseStock =
            new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, string> _productNames =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private OutletOrderDto _selected;

        // ---- controls ----
        private Label lblStatRequested, lblStatPartial, lblStatFulfilled, lblStatRejected;
        private System.Windows.Forms.ComboBox cboStatus;
        private Button btnRefresh, btnFulfill, btnReject, btnClose;
        private DataGridView gridOrders, gridDetails;
        private Label lblInfoNo, lblInfoOutlet, lblInfoDate, lblInfoStatus, lblInfoNote;
        private Label lblSumItems, lblSumRequested, lblSumFulfilled, lblSumRemaining;
        private Label lblActionStatus;

        private static readonly Color ColNavy = Color.FromArgb(30, 33, 48);
        private static readonly Color ColGray = Color.FromArgb(120, 124, 138);
        private static readonly Color ColPurple = Color.FromArgb(109, 40, 217);
        private static readonly Color ColPurpleTint = Color.FromArgb(237, 231, 255);
        private static readonly Color ColGreen = Color.FromArgb(22, 163, 74);
        private static readonly Color ColRed = Color.FromArgb(220, 38, 38);
        private static readonly Color ColAmber = Color.FromArgb(217, 119, 6);
        private static readonly Color ColBlue = Color.FromArgb(37, 99, 235);
        private static readonly Color ColPageBg = Color.FromArgb(249, 250, 252);

        public guiOutletOrderApproval()
        {
            _api = APIGlobals.Api;

            Text = "Outlet Order Approval";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1100, 720);
            MinimumSize = new Size(980, 640);
            BackColor = ColPageBg;
            Font = new Font("Segoe UI", 9F);

            BuildUi();
            Load += guiOutletOrderApproval_Load;
        }

        private async void guiOutletOrderApproval_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            await LoadAllAsync();
        }

        // ---------------------------------------------------------------
        // UI construction
        // ---------------------------------------------------------------
        private void BuildUi()
        {
            var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Color.White };
            Controls.Add(pnlHeader);

            pnlHeader.Controls.Add(new Label
            {
                Text = "Outlet Order Approval",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = ColNavy,
                Location = new Point(20, 10),
                AutoSize = true
            });
            pnlHeader.Controls.Add(new Label
            {
                Text = "Review and approve outlet order requests",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = ColGray,
                Location = new Point(21, 38),
                AutoSize = true
            });

            lblStatRequested = AddStatChip(pnlHeader, 0, "Requested", ColBlue);
            lblStatPartial = AddStatChip(pnlHeader, 1, "Partial", ColAmber);
            lblStatFulfilled = AddStatChip(pnlHeader, 2, "Fulfilled", ColGreen);
            lblStatRejected = AddStatChip(pnlHeader, 3, "Rejected", ColRed);

            var pnlActions = new Panel { Dock = DockStyle.Bottom, Height = 56, BackColor = Color.White };
            Controls.Add(pnlActions);

            lblActionStatus = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9F),
                ForeColor = ColGray,
                Location = new Point(20, 18),
                Size = new Size(430, 20)
            };
            pnlActions.Controls.Add(lblActionStatus);

            btnClose = MakeButton("Close", ColPageBg, ColNavy, 100);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(pnlActions.Width - 120, 10);
            btnClose.Click += (s, e) => Close();
            pnlActions.Controls.Add(btnClose);

            btnReject = MakeButton("Reject", Color.FromArgb(254, 226, 226), ColRed, 110);
            btnReject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReject.Location = new Point(pnlActions.Width - 240, 10);
            btnReject.Enabled = false;
            btnReject.Click += async (s, e) => await RejectAsync();
            pnlActions.Controls.Add(btnReject);

            btnFulfill = MakeButton("Fulfill", ColPurple, Color.White, 140);
            btnFulfill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFulfill.Location = new Point(pnlActions.Width - 390, 10);
            btnFulfill.Enabled = false;
            btnFulfill.Click += async (s, e) => await FulfillAsync();
            pnlActions.Controls.Add(btnFulfill);

            var split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 290,
                BackColor = ColPageBg
            };
            Controls.Add(split);
            split.BringToFront();

            var topSplit = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 700,
                BackColor = ColPageBg
            };
            split.Panel1.Controls.Add(topSplit);

            var pnlFilter = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.White };
            topSplit.Panel1.Controls.Add(pnlFilter);

            pnlFilter.Controls.Add(new Label
            {
                Text = "Status",
                Font = new Font("Segoe UI", 9F),
                ForeColor = ColGray,
                Location = new Point(12, 11),
                AutoSize = true
            });

            cboStatus = new System.Windows.Forms.ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(60, 7),
                Size = new Size(160, 26)
            };
            cboStatus.Items.AddRange(new object[] { AllStatuses, "Requested", "PartiallyFulfilled", "Fulfilled", "Rejected" });
            cboStatus.SelectedIndex = 0;
            cboStatus.SelectedIndexChanged += (s, e) => RenderOrderList();
            pnlFilter.Controls.Add(cboStatus);

            btnRefresh = MakeButton("Refresh", ColPurple, Color.White, 80);
            btnRefresh.Location = new Point(232, 6);
            btnRefresh.Height = 28;
            btnRefresh.Click += async (s, e) => await LoadAllAsync();
            pnlFilter.Controls.Add(btnRefresh);

            gridOrders = MakeGrid();
            gridOrders.Columns.Add(MakeCol("colNo", "Order No", 90));
            gridOrders.Columns.Add(MakeCol("colOutlet", "Outlet", 150));
            gridOrders.Columns.Add(MakeCol("colDate", "Order Date", 100));
            gridOrders.Columns.Add(MakeCol("colStatus", "Status", 110));
            gridOrders.Columns.Add(MakeCol("colNote", "Note", 160));
            gridOrders.SelectionChanged += async (s, e) => await OnOrderSelectedAsync();
            topSplit.Panel1.Controls.Add(gridOrders);
            gridOrders.BringToFront();

            var pnlInfo = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(14) };
            topSplit.Panel2.Controls.Add(pnlInfo);

            int y = 12;

            pnlInfo.Controls.Add(new Label
            {
                Text = "Order Information",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColNavy,
                Location = new Point(14, y),
                AutoSize = true
            });
            y += 26;

            lblInfoNo = AddInfoRow(pnlInfo, "Order No:", ref y);
            lblInfoOutlet = AddInfoRow(pnlInfo, "Outlet:", ref y);
            lblInfoDate = AddInfoRow(pnlInfo, "Order Date:", ref y);
            lblInfoStatus = AddInfoRow(pnlInfo, "Status:", ref y);
            lblInfoNote = AddInfoRow(pnlInfo, "Note:", ref y);

            y += 10;
            pnlInfo.Controls.Add(new Label
            {
                Text = "Summary",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColNavy,
                Location = new Point(14, y),
                AutoSize = true
            });
            y += 26;

            lblSumItems = AddInfoRow(pnlInfo, "Total Items:", ref y);
            lblSumRequested = AddInfoRow(pnlInfo, "Requested:", ref y);
            lblSumFulfilled = AddInfoRow(pnlInfo, "Fulfilled:", ref y);
            lblSumRemaining = AddInfoRow(pnlInfo, "Remaining:", ref y);

            gridDetails = MakeGrid();
            gridDetails.ReadOnly = false;
            gridDetails.Columns.Add(MakeCol("colItemId", "ItemId", 0, false));
            gridDetails.Columns.Add(MakeCol("colCode", "Product Code", 120));
            gridDetails.Columns.Add(MakeCol("colProduct", "Product Name", 200));
            gridDetails.Columns.Add(MakeCol("colWhStock", "Warehouse Stock", 120));
            gridDetails.Columns.Add(MakeCol("colRequested", "Requested", 90));
            gridDetails.Columns.Add(MakeCol("colFulfilled", "Fulfilled", 80));
            gridDetails.Columns.Add(MakeCol("colRemaining", "Remaining", 90));

            var colNow = MakeCol("colFulfillNow", "Fulfill Now", 100);
            colNow.ReadOnly = false;
            colNow.DefaultCellStyle.BackColor = ColPurpleTint;
            gridDetails.Columns.Add(colNow);

            foreach (DataGridViewColumn c in gridDetails.Columns)
                if (c.Name != "colFulfillNow")
                    c.ReadOnly = true;

            split.Panel2.Controls.Add(gridDetails);
        }

        private Label AddStatChip(Panel host, int index, string caption, Color color)
        {
            var chip = new Panel
            {
                Size = new Size(120, 44),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            chip.Location = new Point(host.Width - (4 - index) * 130 - 16, 10);
            host.Controls.Add(chip);

            chip.Controls.Add(new Label
            {
                Text = caption,
                Font = new Font("Segoe UI", 8F),
                ForeColor = ColGray,
                Location = new Point(8, 3),
                AutoSize = true
            });

            var lblCount = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(8, 18),
                AutoSize = true
            };
            chip.Controls.Add(lblCount);
            return lblCount;
        }

        private Label AddInfoRow(Panel host, string caption, ref int y)
        {
            host.Controls.Add(new Label
            {
                Text = caption,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = ColGray,
                Location = new Point(14, y),
                AutoSize = true
            });
            var val = new Label
            {
                Text = "—",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = ColNavy,
                Location = new Point(110, y),
                Size = new Size(240, 18),
                AutoEllipsis = true
            };
            host.Controls.Add(val);
            y += 24;
            return val;
        }

        private static Button MakeButton(string text, Color back, Color fore, int width)
        {
            var b = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Size = new Size(width, 36)
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        private static DataGridView MakeGrid()
        {
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 34,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };
            grid.ColumnHeadersDefaultCellStyle.BackColor = ColPurpleTint;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ColNavy;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.SelectionBackColor = ColPurpleTint;
            grid.DefaultCellStyle.SelectionForeColor = ColNavy;
            grid.AlternatingRowsDefaultCellStyle.BackColor = ColPageBg;
            return grid;
        }

        private static DataGridViewTextBoxColumn MakeCol(string name, string header, int width, bool visible = true)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = Math.Max(width, 1),
                Visible = visible,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        // ---------------------------------------------------------------
        // Data
        // ---------------------------------------------------------------
        private async Task LoadAllAsync()
        {
            lblActionStatus.Text = "Loading...";
            btnRefresh.Enabled = false;

            try
            {
                var orders = await _api.GetAsync<List<OutletOrderDto>>("api/OutletOrder");
                var outlets = await _api.GetAsync<List<OutletDto>>("api/Outlet");
                var stock = await _api.GetAsync<List<WarehouseStockDto>>("api/OutletOrder/warehouse-stock");
                var menu = await _api.GetAsync<List<MenuItemDto>>("api/MenuItem");

                if (IsDisposed)
                    return;

                _orders = orders ?? new List<OutletOrderDto>();

                _outletNames = (outlets ?? new List<OutletDto>())
                    .GroupBy(o => o.Id)
                    .ToDictionary(g => g.Key, g => g.First().OutletName ?? ("Outlet " + g.Key));

                _warehouseStock = (stock ?? new List<WarehouseStockDto>())
                    .GroupBy(r => r.ProNumY, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.First().StockQty, StringComparer.OrdinalIgnoreCase);

                _productNames = (menu ?? new List<MenuItemDto>())
                    .Where(m => !string.IsNullOrWhiteSpace(m.ProNumY))
                    .GroupBy(m => m.ProNumY, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.First().ProductName ?? g.Key, StringComparer.OrdinalIgnoreCase);

                RenderStats();
                RenderOrderList();
                lblActionStatus.Text = _orders.Count + " order(s) loaded.";
            }
            catch (Exception ex)
            {
                lblActionStatus.Text = "Load failed: " + ex.Message;
            }
            finally
            {
                if (!IsDisposed)
                    btnRefresh.Enabled = true;
            }
        }

        private void RenderStats()
        {
            lblStatRequested.Text = _orders.Count(o => o.Status == "Requested").ToString();
            lblStatPartial.Text = _orders.Count(o => o.Status == "PartiallyFulfilled").ToString();
            lblStatFulfilled.Text = _orders.Count(o => o.Status == "Fulfilled").ToString();
            lblStatRejected.Text = _orders.Count(o => o.Status == "Rejected").ToString();
        }

        private void RenderOrderList()
        {
            var filter = cboStatus.SelectedItem as string ?? AllStatuses;

            var rows = _orders
                .Where(o => filter == AllStatuses || o.Status == filter)
                .OrderByDescending(o => o.CreatedAt)
                .ToList();

            gridOrders.Rows.Clear();

            foreach (var o in rows)
            {
                string outletName;
                if (!_outletNames.TryGetValue(o.OutletID, out outletName))
                    outletName = "Outlet " + o.OutletID;

                int i = gridOrders.Rows.Add(
                    o.OutletOrderNo ?? ("#" + o.OutletOrderID),
                    outletName,
                    o.OrderDate.ToString("dd/MM/yyyy"),
                    o.Status,
                    o.Note ?? "");

                gridOrders.Rows[i].Tag = o.OutletOrderID;

                var cell = gridOrders.Rows[i].Cells["colStatus"];
                cell.Style.ForeColor = StatusColor(o.Status);
                cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            if (gridOrders.Rows.Count == 0)
                ClearDetail();
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Fulfilled": return ColGreen;
                case "PartiallyFulfilled": return ColAmber;
                case "Rejected": return ColRed;
                default: return ColBlue; // Requested
            }
        }

        private void ClearDetail()
        {
            _selected = null;
            gridDetails.Rows.Clear();
            lblInfoNo.Text = lblInfoOutlet.Text = lblInfoDate.Text = lblInfoStatus.Text = lblInfoNote.Text = "—";
            lblSumItems.Text = lblSumRequested.Text = lblSumFulfilled.Text = lblSumRemaining.Text = "—";
            btnFulfill.Enabled = false;
            btnReject.Enabled = false;
        }

        private async Task OnOrderSelectedAsync()
        {
            if (gridOrders.SelectedRows.Count == 0 || !(gridOrders.SelectedRows[0].Tag is int))
            {
                ClearDetail();
                return;
            }

            int id = (int)gridOrders.SelectedRows[0].Tag;

            try
            {
                // The list endpoint returns headers only; the by-id endpoint
                // carries the item lines.
                var full = await _api.GetAsync<OutletOrderDto>("api/OutletOrder/" + id);

                if (IsDisposed || full == null)
                    return;

                if (full.OutletOrderItems == null)
                    full.OutletOrderItems = new List<OutletOrderItemDto>();

                _selected = full;
                RenderDetail();
            }
            catch (Exception ex)
            {
                lblActionStatus.Text = "Could not load order: " + ex.Message;
            }
        }

        private void RenderDetail()
        {
            var o = _selected;

            string outletName;
            if (!_outletNames.TryGetValue(o.OutletID, out outletName))
                outletName = "Outlet " + o.OutletID;

            lblInfoNo.Text = o.OutletOrderNo ?? ("#" + o.OutletOrderID);
            lblInfoOutlet.Text = outletName;
            lblInfoDate.Text = o.OrderDate.ToString("dd/MM/yyyy");
            lblInfoStatus.Text = o.Status;
            lblInfoStatus.ForeColor = StatusColor(o.Status);
            lblInfoNote.Text = string.IsNullOrWhiteSpace(o.Note) ? "—" : o.Note;

            int totalRequested = o.OutletOrderItems.Sum(i => i.RequestedQty);
            int totalFulfilled = o.OutletOrderItems.Sum(i => i.FulfilledQty);
            lblSumItems.Text = o.OutletOrderItems.Count.ToString();
            lblSumRequested.Text = totalRequested.ToString();
            lblSumFulfilled.Text = totalFulfilled.ToString();
            lblSumRemaining.Text = (totalRequested - totalFulfilled).ToString();

            gridDetails.Rows.Clear();

            foreach (var it in o.OutletOrderItems)
            {
                int remaining = it.RequestedQty - it.FulfilledQty;

                decimal whStock;
                if (!_warehouseStock.TryGetValue(it.ProNumY, out whStock))
                    whStock = 0m;

                string pname;
                if (!_productNames.TryGetValue(it.ProNumY, out pname))
                    pname = it.ProNumY;

                // Default fulfill-now: whatever's still owed, capped by what
                // the warehouse actually has.
                int suggested = (int)Math.Max(0, Math.Min(remaining, whStock));

                gridDetails.Rows.Add(
                    it.OutletOrderItemID,
                    it.ProNumY,
                    pname,
                    whStock.ToString("0.##"),
                    it.RequestedQty,
                    it.FulfilledQty,
                    remaining,
                    suggested);
            }

            // Only open orders can be acted on.
            bool open = o.Status == "Requested" || o.Status == "PartiallyFulfilled";
            btnFulfill.Enabled = open;
            btnReject.Enabled = o.Status == "Requested";
        }

        // ---------------------------------------------------------------
        // Actions
        // ---------------------------------------------------------------
        private async Task FulfillAsync()
        {
            if (_selected == null)
                return;

            var dto = new FulfillDto { Items = new List<FulfillItemDto>() };

            foreach (DataGridViewRow row in gridDetails.Rows)
            {
                int qty;
                if (!int.TryParse(Convert.ToString(row.Cells["colFulfillNow"].Value), out qty) || qty <= 0)
                    continue;

                int remaining;
                if (!int.TryParse(Convert.ToString(row.Cells["colRemaining"].Value), out remaining))
                    remaining = 0;

                if (qty > remaining)
                {
                    XtraMessageBox.Show(
                        "Fulfill Now for " + row.Cells["colProduct"].Value + " exceeds the remaining "
                        + remaining + ".", "Fulfill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dto.Items.Add(new FulfillItemDto
                {
                    OutletOrderItemID = Convert.ToInt32(row.Cells["colItemId"].Value),
                    FulfilledQty = qty
                });
            }

            if (dto.Items.Count == 0)
            {
                XtraMessageBox.Show("Enter a Fulfill Now quantity for at least one line.",
                    "Fulfill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnFulfill.Enabled = false;
            lblActionStatus.Text = "Fulfilling...";

            try
            {
                var ok = await _api.PostAsync("api/OutletOrder/fulfill/" + _selected.OutletOrderID, dto);

                if (ok)
                {
                    lblActionStatus.Text = "Order fulfilled — stock moved to the outlet.";
                    await LoadAllAsync();
                    await OnOrderSelectedAsync();
                }
                else
                {
                    lblActionStatus.Text = "";
                    btnFulfill.Enabled = true;
                    XtraMessageBox.Show("Fulfill failed.", "Fulfill",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblActionStatus.Text = "";
                btnFulfill.Enabled = true;
                XtraMessageBox.Show(ex.Message, "Fulfill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RejectAsync()
        {
            if (_selected == null)
                return;

            var confirm = XtraMessageBox.Show(
                "Reject " + (_selected.OutletOrderNo ?? ("#" + _selected.OutletOrderID)) + "?"
                + "\n\nNo stock will move; the outlet will see the request as Rejected.",
                "Reject Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            btnReject.Enabled = false;
            lblActionStatus.Text = "Rejecting...";

            try
            {
                var ok = await _api.PutAsync(
                    "api/OutletOrder/status/" + _selected.OutletOrderID + "?status=Rejected", new { });

                if (ok)
                {
                    lblActionStatus.Text = "Order rejected.";
                    await LoadAllAsync();
                }
                else
                {
                    lblActionStatus.Text = "";
                    btnReject.Enabled = true;
                    XtraMessageBox.Show("Reject failed.", "Reject",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblActionStatus.Text = "";
                btnReject.Enabled = true;
                XtraMessageBox.Show(ex.Message, "Reject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
