using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using Excel = Microsoft.Office.Interop.Excel;

namespace unt_bingoo.view.Customer
{
    public partial class guiCustomer : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;
        private int _editingId = 0;
        private List<CustomerItem> _allCustomers = new List<CustomerItem>();
        private bool _changingStatus = false;

        public guiCustomer()
        {
            InitializeComponent();

            _api = APIGlobals.Api;

            this.Load += guiCustomer_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private async void guiCustomer_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            await LoadData();
            ClearForm();
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                _allCustomers = await _api.GetAsync<List<CustomerItem>>("api/customer") ?? new List<CustomerItem>();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            var keyword = txtSearch.Text.Trim();

            var list = string.IsNullOrWhiteSpace(keyword)
                ? _allCustomers
                : _allCustomers.Where(c =>
                    (c.CustomerCode ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.CustomerName ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Phone ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Email ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            gridCustomer.DataSource = list;
            gvCustomer.BestFitColumns();
            lblCount.Text = $"Total Records: {list.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the customer name!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            int.TryParse(txtPoints.Text.Trim(), out int points);

            var customer = new CustomerItem
            {
                CustomerID = _editingId,
                CustomerCode = txtCode.Text.Trim(),
                CustomerName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Points = points,
                IsActive = chkActive.Checked
            };

            try
            {
                if (_editingId == 0)
                {
                    var ok = await _api.PostAsync("api/customer", customer);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Save failed.");
                        return;
                    }

                    XtraMessageBox.Show(
                        "Saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await _api.PutAsync($"api/customer/{_editingId}", customer);

                    XtraMessageBox.Show(
                        "Updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                await LoadData();
                ClearForm();
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

        private void btnMainEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCustomer.GetFocusedRow() as CustomerItem;

            if (row == null)
                return;

            _editingId = row.CustomerID;

            txtCode.Text = row.CustomerCode;
            txtName.Text = row.CustomerName;
            txtPhone.Text = row.Phone;
            txtEmail.Text = row.Email;
            txtAddress.Text = row.Address;
            txtPoints.Text = row.Points.ToString();

            chkActive.Checked = row.IsActive;
            chkDeactive.Checked = !row.IsActive;

            btnSave.Text = "Update";
        }

        private async void btnMainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCustomer.GetFocusedRow() as CustomerItem;

            if (row == null)
                return;

            if (MessageBox.Show(
                    $"Are you sure you want to delete customer '{row.CustomerName}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var ok = await _api.DeleteAsync($"api/customer/{row.CustomerID}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed.");
                    return;
                }

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (chkActive.Checked)
            {
                chkDeactive.Checked = false;
            }
            else if (!chkDeactive.Checked)
            {
                chkActive.Checked = true;
            }

            _changingStatus = false;
        }

        private void chkDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (_changingStatus) return;

            _changingStatus = true;

            if (chkDeactive.Checked)
            {
                chkActive.Checked = false;
            }
            else if (!chkActive.Checked)
            {
                chkDeactive.Checked = true;
            }

            _changingStatus = false;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void ClearForm()
        {
            _editingId = 0;

            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPoints.Text = "0";
            chkActive.Checked = true;
            chkDeactive.Checked = false;

            btnSave.Text = "Save";

            try
            {
                var result = await _api.GetAsync<Newtonsoft.Json.Linq.JObject>("api/customer/next-code");
                txtCode.Text = result?["customerCode"]?.ToString() ?? string.Empty;
            }
            catch
            {
                txtCode.Text = string.Empty;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCustomer.RowCount <= 0)
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

                for (int col = 0; col < gvCustomer.Columns.Count; col++)
                {
                    var column = gvCustomer.Columns[col];

                    if (column == colEdit || column == colDelete)
                        continue;

                    worksheet.Cells[1, excelCol] = column.Caption;
                    ((Excel.Range)worksheet.Cells[1, excelCol]).Font.Bold = true;

                    excelCol++;
                }

                for (int row = 0; row < gvCustomer.RowCount; row++)
                {
                    excelCol = 1;

                    for (int col = 0; col < gvCustomer.Columns.Count; col++)
                    {
                        var column = gvCustomer.Columns[col];

                        if (column == colEdit || column == colDelete)
                            continue;

                        object value = gvCustomer.GetRowCellValue(row, column);

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
