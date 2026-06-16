using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Category
{
    public partial class guiCategory : XtraForm
    {
        private APIsController _api; 
        private BindingList<CategoryItem> _list =
            new BindingList<CategoryItem>();

        private int? _editingId = null;

        public guiCategory()
        {
            InitializeComponent();

            gridCategory.DataSource = _list;
        }

        private async void guiCategory_Load(object sender, EventArgs e)
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

                await LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task LoadData()
        {
            var data =
                await _api.GetAsync<System.Collections.Generic.List<CategoryItem>>(
                    "api/category");

            _list.Clear();

            foreach (var item in data)
                _list.Add(item);

            gvCategory.BestFitColumns();

            lblCount.Text = $"Count : {_list.Count}";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                bool ok;


                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/category", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    _list.Add(model);

                    XtraMessageBox.Show("Added!");
                }

                else
                {
                    ok = await _api.PutAsync($"api/category/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    var item = _list.First(x => x.Id == _editingId);

                    item.CategoryCode = model.CategoryCode;
                    item.CategoryName = model.CategoryName;
                    item.Remark = model.Remark;
                    item.Active = model.Active;

                    gvCategory.RefreshData();

                    XtraMessageBox.Show("Updated!");
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private async void btnMainDelete_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCategory.GetFocusedRow() as CategoryItem;

            if (row == null) return;

            if (XtraMessageBox.Show("Delete?",
                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteAsync($"api/category/{row.Id}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                _list.Remove(row);

                lblCount.Text = $"Count : {_list.Count}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private void btnMainupdate_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCategory.GetFocusedRow() as CategoryItem;

            if (row == null) return;

            //txtCode.Text = row.CategoryCode;
            txtName.Text = row.CategoryName;
            txtRemark.Text = row.Remark;

            //chkActive.Checked = row.Active;

            _editingId = row.Id;

            //btnAdd.Text = "Update";
        }


        private bool ValidateForm()
        {
            //if (string.IsNullOrWhiteSpace(txtCode.Text))
            //{
            //    XtraMessageBox.Show("Category Code required!");
            //    return false;
            //}

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Category Name required!");
                return false;
            }

            return true;
        }

        private CategoryItem GetFormData()
        {
            return new CategoryItem
            {
                Id = _editingId ?? 0,
                CategoryCode ="",
                CategoryName = txtName.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                khmerCategoryName = TxtKhmerName.Text.Trim()
                //Active = chkActive.Checked
            };
        }

        private void ClearForm()
        {
            //txtCode.Text = "";
            txtName.Text = "";
            txtRemark.Text = "";

            //chkActive.Checked = true;

            _editingId = null;

            //btnAdd.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Export Category";
                dialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                dialog.FileName = "Category_List.xlsx";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

      
                gridCategory.ExportToXlsx(dialog.FileName);

                XtraMessageBox.Show(
                    "Export successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Export failed: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
