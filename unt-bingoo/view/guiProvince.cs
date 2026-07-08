using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view
{
    public partial class guiProvince : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private BindingList<ProvinceItem> _provinceList = new BindingList<ProvinceItem>();
        private int? _editingId = null;

        public guiProvince()
        {
            InitializeComponent();

            gridViewProvince.OptionsBehavior.Editable = true;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewProvince.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
            }

            gridColumn1.OptionsColumn.AllowEdit = true; // Edit Button
            gridColumn2.OptionsColumn.AllowEdit = true; // Delete Button
        }

        private async void guiProvince_Load(object sender, EventArgs e)
        {
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    this.Close();
                    return;
                }

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void loadingProvice()
        {

        }

        private async Task LoadData()
        {
            try
            {
                // Fetch data from your API
                var list = await _api.GetAsync<List<ProvinceItem>>("api/Province");
                if (list != null)
                {
                    _provinceList = new BindingList<ProvinceItem>(list);
                    gridControlProvince.DataSource = _provinceList;
                    gridViewProvince.BestFitColumns();
                }

                lblCountRow.Text = $"Count Row: {_provinceList.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;
                bool success;

                if (_editingId == null)
                {
                    // Add New
                    success = await _api.PostAsync("api/Province", model);
                    if (success) XtraMessageBox.Show("Province added successfully!");
                }
                else
                {
                    // Update Existing
                    success = await _api.PutAsync($"api/Province/{_editingId}", model);
                    if (success) XtraMessageBox.Show("Province updated successfully!");
                }

                if (success)
                {
                    await LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewProvince.GetFocusedRow() as ProvinceItem;
            if (row == null) return;

            // Map data to textboxes
            txtCode.Text = row.code;
            txtProvinceKH.Text = row.provinceNameKH;
            txtProvinceEN.Text = row.provinceNameEN;

            _editingId = row.provinceId;
            btnAdd.Text = "Update";
        }

        private async void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewProvince.GetFocusedRow() as ProvinceItem;
            if (row == null) return;

            if (XtraMessageBox.Show($"Delete {row.provinceNameEN}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/Province/{row.provinceId}");
                if (ok)
                {
                    await LoadData();
                    ClearForm();
                    XtraMessageBox.Show("Deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private ProvinceItem GetFormData()
        {
            return new ProvinceItem
            {
                provinceId = _editingId ?? 0,
                code = txtCode.Text.Trim(),
                provinceNameKH = txtProvinceKH.Text.Trim(),
                provinceNameEN = txtProvinceEN.Text.Trim()
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProvinceKH.Text))
            {
                XtraMessageBox.Show("Khmer Name is required!");
                txtProvinceKH.Focus();
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtCode.Text = "";
            txtProvinceKH.Text = "";
            txtProvinceEN.Text = "";
            _editingId = null;
            btnAdd.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                    sfd.Title = "Export to Excel";
                    sfd.FileName = "Province.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = sfd.FileName;

                        // Export Grid to Excel
                        gridControlProvince.ExportToXlsx(filePath);

                        XtraMessageBox.Show("Export successful!");
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == null ? "" : txtSearch.Text.Trim();
            gridViewProvince.ApplyFindFilter(keyword);

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridViewProvince.FocusedRowHandle;
            if (rowHandle < 0) return;  

       
            txtProvinceId.Text = gridViewProvince.GetRowCellValue(rowHandle, "provinceId")?.ToString();
            txtProvinceKH.Text = gridViewProvince.GetRowCellValue(rowHandle, "provinceNameKH")?.ToString();
            txtProvinceEN.Text = gridViewProvince.GetRowCellValue(rowHandle, "provinceNameEN")?.ToString();
            txtCode.Text = gridViewProvince.GetRowCellValue(rowHandle, "code")?.ToString();

       
            btnAdd.Text = "Update";
        }

        private async void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridViewProvince.FocusedRowHandle;
            if (rowHandle < 0) return;

            string id = gridViewProvince
                .GetRowCellValue(rowHandle, "provinceId")
                ?.ToString();

            if (string.IsNullOrEmpty(id))
                return;

            var confirm = XtraMessageBox.Show(
                "Are you sure you want to delete this province?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            bool success = await _api.DeleteAsync($"api/Province/{id}");

            if (success)
            {
                XtraMessageBox.Show(
                    "Province deleted successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadData();
                ClearForm();
            }
        }
    }

}