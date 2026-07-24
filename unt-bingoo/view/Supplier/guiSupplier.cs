using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Supplier
{
    public partial class guiSupplier : XtraForm
    {
        private APIsController _api;
        private List<SupplierLookup> _suppliers = new List<SupplierLookup>();
        private List<SupplierReportItem> _rows = new List<SupplierReportItem>();
        private bool _loading;   // stop events firing while we set values in code

        public guiSupplier()
        {
            InitializeComponent();
        }

        private async void guiSupplier_Load(object sender, EventArgs e)
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

                await LoadSuppliersAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadSuppliersAsync()
        {
            _loading = true;

            try
            {
                var suppliers = await _api.GetAsync<List<SupplierLookup>>("api/Supplier");
                var products = await _api.GetAsync<List<ProductItem>>("api/Product");

                _suppliers = (suppliers ?? new List<SupplierLookup>())
                    .Where(s => products != null &&
                                products.Any(p => p.Sup1 == s.SupplierCode))
                    .ToList();

                searchSupplier.Properties.DataSource = _suppliers;
                searchSupplier.Properties.DisplayMember = "SupplierName";
                searchSupplier.Properties.ValueMember = "SupplierID";

                searchSupplier.Properties.PopupView.Columns.Clear();
                searchSupplier.Properties.PopupView.Columns.AddVisible("SupplierCode", "Code");
                searchSupplier.Properties.PopupView.Columns.AddVisible("SupplierName", "Supplier Name");

                // Same as ComboBox SelectedIndex = -1
                searchSupplier.EditValue = null;
            }
            finally
            {
                _loading = false;
            }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                bool showAll = chkShowAll.Checked;

                string url;
                if (showAll)
                {
                    url = "api/reports/SupplierReport";
                }
                else
                {
                    if (searchSupplier.EditValue == null)
                    {
                        ClearReport();
                        return;
                    }

                    int supplierId = Convert.ToInt32(searchSupplier.EditValue);

                    var supplier = _suppliers.FirstOrDefault(x => x.SupplierID == supplierId);

                    if (supplier == null)
                    {
                        ClearReport();
                        return;
                    }

                    string supplierCode = supplier.SupplierCode;

                    url = $"api/reports/SupplierReport?Search={Uri.EscapeDataString(supplierCode)}";
                }

                var data = await _api.GetAsync<List<SupplierReportItem>>(url);
                _rows = data ?? new List<SupplierReportItem>();

                gridControl1.DataSource = _rows;
                lblCountRow.Text = _rows.Count.ToString("N0");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearReport()
        {
            _rows = new List<SupplierReportItem>();
            gridControl1.DataSource = _rows;
            lblCountRow.Text = "0";
        }

        // ---------------------------------------------------------
        //  Events
        // ---------------------------------------------------------
        private async void searchSupplier_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading || chkShowAll.Checked) return;
            await LoadReportAsync();
        }

        private async void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            searchSupplier.Enabled = !chkShowAll.Checked;
            await LoadReportAsync();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_rows.Count == 0)
            {
                XtraMessageBox.Show("No data to export.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dlg = new guiSupplierReport())
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                colBuyin.Visible = dlg.WithBuyinPrice;
                colFactoryCost.Visible = dlg.WithBuyinPrice;
                colTotalBuyin.Visible = dlg.WithBuyinPrice;

                
                string tempFile = Path.Combine(
                    Path.GetTempPath(),
                    $"SupplierReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                try
                {
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