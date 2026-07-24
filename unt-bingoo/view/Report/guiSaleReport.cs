using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Class.Report;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Report
{
    public partial class guiSaleReport : XtraForm
    {
        private APIsController _api;
        private List<SalesReportDto> _rows = new List<SalesReportDto>();

        public guiSaleReport()
        {
            InitializeComponent();
        }

        private async void guiSaleReport_Load(object sender, EventArgs e)
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

                if (!APIGlobals.HasPermission("SALE_REPORT"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                // Default range: current month
                var today = DateTime.Today;
                dtFrom.DateTime = new DateTime(today.Year, today.Month, 1);
                dtTo.DateTime = today;

                await LoadOutletsAsync();
                await LoadReportAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadOutletsAsync()
        {
            try
            {
                var outlets = await _api.GetAsync<List<OutletItem>>("api/Outlet")
                              ?? new List<OutletItem>();

                cboOutlet.DataSource = outlets;
                cboOutlet.DisplayMember = "OutletName";
                cboOutlet.ValueMember = "Id";
                cboOutlet.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Load Outlet Error: " + ex.Message);
            }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                DateTime from = dtFrom.DateTime.Date;
                DateTime to = dtTo.DateTime.Date;

                if (from > to)
                {
                    XtraMessageBox.Show("From date must be before To date.",
                        "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string url = $"api/Report/sales?from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";

                if (!chkAllOutlets.Checked && cboOutlet.SelectedValue is int outletId)
                    url += $"&outletId={outletId}";

                var data = await _api.GetAsync<List<SalesReportDto>>(url);
                _rows = data ?? new List<SalesReportDto>();

                gridControl1.DataSource = _rows;
                lblCountRow.Text = _rows.Count.ToString("N0");
                lblTotalAmount.Text = _rows.Sum(r => r.NetAmount).ToString("N2");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private void chkAllOutlets_CheckedChanged(object sender, EventArgs e)
        {
            cboOutlet.Enabled = !chkAllOutlets.Checked;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_rows.Count == 0)
            {
                XtraMessageBox.Show("No data to export.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string tempFile = Path.Combine(
                    Path.GetTempPath(),
                    $"SaleReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                gridControl1.ExportToXlsx(tempFile);

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Cannot open file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }
    }
}
