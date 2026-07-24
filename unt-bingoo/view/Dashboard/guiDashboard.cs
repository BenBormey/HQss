using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Dashboard
{
    // MD dashboard: headline figures, sales charts, recent outlet orders and
    // low stock — all served by one call to GET api/Report/dashboard. Charts
    // use the framework's built-in System.Windows.Forms.DataVisualization.
    //
    // Open it from the Dashboard menu (wired in mainForm).
    public class guiDashboard : XtraForm
    {
        private readonly APIsController _api;

        // ---- DTOs mirroring api/Report/dashboard ----
        private class DatePoint
        {
            public DateTime Date { get; set; }
            public decimal Total { get; set; }
        }

        private class NameValue
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
        }

        private class LowStockRow
        {
            public string Product { get; set; }
            public string Outlet { get; set; }
            public decimal StockQty { get; set; }
        }

        private class OutletOrderRow
        {
            public string OutletOrderNo { get; set; }
            public string Outlet { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime? ExpectedDate { get; set; }
            public string Status { get; set; }
            public string Note { get; set; }
            public int Items { get; set; }
        }

        private class DashboardDto
        {
            public decimal SalesToday { get; set; }
            public decimal SalesYesterday { get; set; }
            public decimal SalesWeek { get; set; }
            public decimal SalesMonth { get; set; }
            public int OrdersToday { get; set; }
            public decimal VatMonth { get; set; }
            public decimal StockValue { get; set; }
            public int PendingOutletOrders { get; set; }
            public List<DatePoint> SalesByDay { get; set; }
            public List<NameValue> SalesByOutlet { get; set; }
            public List<NameValue> TopProducts { get; set; }
            public List<NameValue> SalesByPayment { get; set; }
            public List<LowStockRow> LowStock { get; set; }
            public List<OutletOrderRow> RecentOutletOrders { get; set; }
        }

        // ---- controls ----
        private Label lblSalesToday, lblSalesTodaySub;
        private Label lblSalesWeek, lblSalesMonth, lblOrdersToday, lblStockValue, lblPending, lblPendingSub;
        private Chart chartByDay, chartByOutlet, chartTopProducts, chartByPayment;
        private DataGridView gridLowStock, gridRecentOrders;
        private Button btnRefresh;
        private Label lblStatus;

        private static readonly Color ColNavy = Color.FromArgb(30, 33, 48);
        private static readonly Color ColGray = Color.FromArgb(120, 124, 138);
        private static readonly Color ColPurple = Color.FromArgb(109, 40, 217);
        private static readonly Color ColGreen = Color.FromArgb(22, 163, 74);
        private static readonly Color ColRed = Color.FromArgb(220, 38, 38);
        private static readonly Color ColBlue = Color.FromArgb(37, 99, 235);
        private static readonly Color ColAmber = Color.FromArgb(217, 119, 6);
        private static readonly Color ColPageBg = Color.FromArgb(249, 250, 252);

        public guiDashboard()
        {
            _api = APIGlobals.Api;

            Text = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1220, 820);
            MinimumSize = new Size(1050, 700);
            BackColor = ColPageBg;
            Font = new Font("Segoe UI", 9F);

            BuildUi();
            Load += guiDashboard_Load;
        }

        private async void guiDashboard_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            await LoadDataAsync();
        }

        // ---------------------------------------------------------------
        // UI construction
        // ---------------------------------------------------------------
        private void BuildUi()
        {
            // ---- Header ----
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.White };
            Controls.Add(pnlTop);

            pnlTop.Controls.Add(new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = ColNavy,
                Location = new Point(20, 6),
                AutoSize = true
            });
            pnlTop.Controls.Add(new Label
            {
                Text = "Overview of warehouse and outlet order activities",
                Font = new Font("Segoe UI", 8F),
                ForeColor = ColGray,
                Location = new Point(21, 30),
                AutoSize = true
            });

            lblStatus = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = ColGray,
                Location = new Point(340, 16),
                Size = new Size(380, 18)
            };
            pnlTop.Controls.Add(lblStatus);

            btnRefresh = new Button
            {
                Text = "Refresh",
                BackColor = ColBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(90, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Location = new Point(pnlTop.Width - 110, 9);
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            pnlTop.Controls.Add(btnRefresh);

            // ---- Stat cards row ----
            var pnlStats = new Panel { Dock = DockStyle.Top, Height = 92, BackColor = ColPageBg, Padding = new Padding(12, 8, 12, 8) };
            Controls.Add(pnlStats);
            pnlStats.BringToFront();

            var statFlow = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
            pnlStats.Controls.Add(statFlow);

            Label subToday, subDummy, subPending;
            lblSalesToday = AddStatCard(statFlow, "Sales Today", ColGreen, out subToday);
            lblSalesTodaySub = subToday;
            lblSalesWeek = AddStatCard(statFlow, "Sales (7 Days)", ColBlue, out subDummy);
            lblSalesMonth = AddStatCard(statFlow, "Sales (This Month)", ColPurple, out subDummy);
            lblOrdersToday = AddStatCard(statFlow, "Orders Today", ColAmber, out subDummy);
            lblStockValue = AddStatCard(statFlow, "Stock Value", ColBlue, out subDummy);
            lblPending = AddStatCard(statFlow, "Pending Approvals", ColRed, out subPending);
            lblPendingSub = subPending;

            // ---- Bottom row: Recent Outlet Orders + Low Stock ----
            var pnlBottom = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 220,
                ColumnCount = 2,
                BackColor = ColPageBg,
                Padding = new Padding(8, 0, 8, 8)
            };
            pnlBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            pnlBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            Controls.Add(pnlBottom);
            pnlBottom.BringToFront();

            var pnlOrders = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(8), Margin = new Padding(4) };
            pnlBottom.Controls.Add(pnlOrders, 0, 0);

            pnlOrders.Controls.Add(new Label
            {
                Text = "Recent Outlet Orders",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColNavy,
                Dock = DockStyle.Top,
                Height = 24
            });

            gridRecentOrders = MakeGrid();
            gridRecentOrders.Columns.Add(MakeCol("colNo", "Order No", 80));
            gridRecentOrders.Columns.Add(MakeCol("colOutlet", "Outlet", 110));
            gridRecentOrders.Columns.Add(MakeCol("colDate", "Order Date", 80));
            gridRecentOrders.Columns.Add(MakeCol("colExpected", "Expected", 80));
            gridRecentOrders.Columns.Add(MakeCol("colStatus", "Status", 100));
            gridRecentOrders.Columns.Add(MakeCol("colItems", "Items", 45));
            gridRecentOrders.Columns.Add(MakeCol("colNote", "Note", 110));
            pnlOrders.Controls.Add(gridRecentOrders);
            gridRecentOrders.BringToFront();

            var pnlLow = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(8), Margin = new Padding(4) };
            pnlBottom.Controls.Add(pnlLow, 1, 0);

            pnlLow.Controls.Add(new Label
            {
                Text = "Low Stock (Under 10)",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColRed,
                Dock = DockStyle.Top,
                Height = 24
            });

            gridLowStock = MakeGrid();
            gridLowStock.Columns.Add(MakeCol("colProduct", "Product", 130));
            gridLowStock.Columns.Add(MakeCol("colOutlet", "Outlet", 110));
            gridLowStock.Columns.Add(MakeCol("colQty", "Available Qty", 60));
            pnlLow.Controls.Add(gridLowStock);
            gridLowStock.BringToFront();

            // ---- Charts 2 × 2 ----
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = ColPageBg,
                Padding = new Padding(8)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            Controls.Add(table);
            table.BringToFront();

            chartByDay = MakeChart("Sales by Day (Last 14 Days)");
            chartByOutlet = MakeChart("Sales by Outlet (This Month)");
            chartTopProducts = MakeChart("Top Products (This Month)");
            chartByPayment = MakeChart("Sales by Payment (This Month)");

            table.Controls.Add(chartByDay, 0, 0);
            table.Controls.Add(chartByOutlet, 1, 0);
            table.Controls.Add(chartTopProducts, 0, 1);
            table.Controls.Add(chartByPayment, 1, 1);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // guiDashboard
            // 
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Name = "guiDashboard";
            this.Load += new System.EventHandler(this.guiDashboard_Load_1);
            this.ResumeLayout(false);

        }

        private void guiDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private Label AddStatCard(FlowLayoutPanel host, string caption, Color color, out Label subLabel)
        {
            var card = new Panel
            {
                Size = new Size(188, 72),
                BackColor = Color.White,
                Margin = new Padding(6, 0, 6, 0)
            };
            host.Controls.Add(card);

            card.Controls.Add(new Label
            {
                Text = caption,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = ColGray,
                Location = new Point(12, 7),
                AutoSize = true
            });

            var lblValue = new Label
            {
                Text = "—",
                Font = new Font("Segoe UI", 13.5F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(12, 25),
                AutoSize = true
            };
            card.Controls.Add(lblValue);

            subLabel = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = ColGray,
                Location = new Point(12, 52),
                AutoSize = true
            };
            card.Controls.Add(subLabel);

            return lblValue;
        }

        private static Chart MakeChart(string title)
        {
            var chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(6)
            };

            var area = new ChartArea("main") { BackColor = Color.White };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 240);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            chart.ChartAreas.Add(area);

            var t = new Title(title)
            {
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 33, 48),
                Alignment = ContentAlignment.TopLeft
            };
            chart.Titles.Add(t);

            return chart;
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
                ColumnHeadersHeight = 28,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 248);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ColNavy;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 231, 255);
            grid.DefaultCellStyle.SelectionForeColor = ColNavy;
            return grid;
        }

        private static DataGridViewTextBoxColumn MakeCol(string name, string header, int weight)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = Math.Max(weight, 1),
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        // ---------------------------------------------------------------
        // Data
        // ---------------------------------------------------------------
        private async Task LoadDataAsync()
        {
            btnRefresh.Enabled = false;
            lblStatus.Text = "Loading...";

            try
            {
                var d = await _api.GetAsync<DashboardDto>("api/Report/dashboard");

                if (IsDisposed)
                    return;

                if (d == null)
                {
                    lblStatus.Text = "Could not load the dashboard — check the server.";
                    return;
                }

                lblSalesToday.Text = "$" + d.SalesToday.ToString("0.00");
                lblSalesTodaySub.Text = TrendText(d.SalesToday, d.SalesYesterday) + " vs yesterday";
                lblSalesTodaySub.ForeColor = d.SalesToday >= d.SalesYesterday ? ColGreen : ColRed;

                lblSalesWeek.Text = "$" + d.SalesWeek.ToString("0.00");
                lblSalesMonth.Text = "$" + d.SalesMonth.ToString("0.00");
                lblOrdersToday.Text = d.OrdersToday.ToString();
                lblStockValue.Text = "$" + d.StockValue.ToString("#,0.00");
                lblPending.Text = d.PendingOutletOrders.ToString();
                lblPendingSub.Text = d.PendingOutletOrders == 0 ? "No pending" : "Needs review";
                lblPendingSub.ForeColor = d.PendingOutletOrders == 0 ? ColGray : ColRed;

                RenderColumnChart(chartByDay, d.SalesByDay ?? new List<DatePoint>());
                RenderDoughnut(chartByOutlet, d.SalesByOutlet ?? new List<NameValue>());
                RenderBarChart(chartTopProducts, d.TopProducts ?? new List<NameValue>());
                RenderDoughnut(chartByPayment, d.SalesByPayment ?? new List<NameValue>());

                gridRecentOrders.Rows.Clear();
                foreach (var o in d.RecentOutletOrders ?? new List<OutletOrderRow>())
                {
                    int i = gridRecentOrders.Rows.Add(
                        o.OutletOrderNo,
                        o.Outlet,
                        o.OrderDate.ToString("dd/MM/yyyy"),
                        o.ExpectedDate.HasValue ? o.ExpectedDate.Value.ToString("dd/MM/yyyy") : "-",
                        o.Status,
                        o.Items,
                        string.IsNullOrWhiteSpace(o.Note) ? "-" : o.Note);

                    var cell = gridRecentOrders.Rows[i].Cells["colStatus"];
                    cell.Style.ForeColor = StatusColor(o.Status);
                    cell.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }

                gridLowStock.Rows.Clear();
                foreach (var row in d.LowStock ?? new List<LowStockRow>())
                {
                    int i = gridLowStock.Rows.Add(row.Product, row.Outlet, row.StockQty.ToString("0.##"));
                    var cell = gridLowStock.Rows[i].Cells["colQty"];
                    cell.Style.ForeColor = ColRed;
                    cell.Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }

                lblStatus.Text = "Updated " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Load failed: " + ex.Message;
            }
            finally
            {
                if (!IsDisposed)
                    btnRefresh.Enabled = true;
            }
        }

        private static string TrendText(decimal today, decimal yesterday)
        {
            if (yesterday <= 0)
                return today > 0 ? "▲ new" : "—";

            decimal pct = Math.Round((today - yesterday) / yesterday * 100m);
            return (pct >= 0 ? "▲ " : "▼ ") + Math.Abs(pct).ToString("0") + "%";
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Fulfilled": return Color.FromArgb(22, 163, 74);
                case "PartiallyFulfilled": return Color.FromArgb(217, 119, 6);
                case "Rejected": return Color.FromArgb(220, 38, 38);
                default: return Color.FromArgb(37, 99, 235); // Requested etc.
            }
        }

        private static void RenderColumnChart(Chart chart, List<DatePoint> points)
        {
            chart.Series.Clear();
            chart.Annotations.Clear();

            var s = new Series
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Date,
                Color = Color.FromArgb(109, 40, 217),
                IsValueShownAsLabel = true,
                LabelFormat = "0",
                Font = new Font("Segoe UI", 7F)
            };

            foreach (var p in points)
                s.Points.AddXY(p.Date, p.Total);

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chart.Series.Add(s);
        }

        private static void RenderBarChart(Chart chart, List<NameValue> points)
        {
            chart.Series.Clear();
            chart.Annotations.Clear();

            var s = new Series
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.FromArgb(109, 40, 217),
                IsValueShownAsLabel = true,
                LabelFormat = "0",
                Font = new Font("Segoe UI", 7.5F)
            };

            // Reverse so the biggest ends up at the top of the bar chart.
            for (int i = points.Count - 1; i >= 0; i--)
                s.Points.AddXY(points[i].Name, points[i].Value);

            chart.Series.Add(s);
        }

        // Doughnut with the total in the hole and a right-hand legend showing
        // each slice's amount and share — like the mockup.
        private static void RenderDoughnut(Chart chart, List<NameValue> points)
        {
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Annotations.Clear();

            var legend = new Legend("legend")
            {
                Docking = Docking.Right,
                Font = new Font("Segoe UI", 8F),
                IsTextAutoFit = false
            };
            chart.Legends.Add(legend);

            decimal total = points.Sum(p => p.Value);

            var s = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new Font("Segoe UI", 7.5F)
            };
            s["DoughnutRadius"] = "55";

            foreach (var p in points)
            {
                decimal pct = total > 0 ? Math.Round(p.Value / total * 100m) : 0m;
                int i = s.Points.AddXY(p.Name, p.Value);
                s.Points[i].LegendText = p.Name + "   $" + p.Value.ToString("0.00") + "  (" + pct.ToString("0") + "%)";
                s.Points[i].Label = ""; // amounts live in the legend, not on slices
            }

            chart.Series.Add(s);

            var ta = new TextAnnotation
            {
                Text = "$" + total.ToString("0.00") + "\nTotal",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 33, 48),
                Alignment = ContentAlignment.MiddleCenter,
                AnchorX = 38,
                AnchorY = 55
            };
            chart.Annotations.Add(ta);
        }
    }
}
