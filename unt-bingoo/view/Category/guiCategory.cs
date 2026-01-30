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
        private APIsController _api; // Shared session
        private BindingList<CategoryItem> _list =
            new BindingList<CategoryItem>();

        private int? _editingId = null;

        public guiCategory()
        {
            InitializeComponent();

            gridCategory.DataSource = _list;
        }

        // ================= LOAD =================
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

        // ================= LOAD DATA =================
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

        // ================= ADD / UPDATE =================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                bool ok;

                // ============ ADD ============
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
                // ============ UPDATE ============
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

        // ================= DELETE =================
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

        // ================= EDIT =================
        private void btnMainupdate_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvCategory.GetFocusedRow() as CategoryItem;

            if (row == null) return;

            txtCode.Text = row.CategoryCode;
            txtName.Text = row.CategoryName;
            txtRemark.Text = row.Remark;

            chkActive.Checked = row.Active;

            _editingId = row.Id;

            btnAdd.Text = "Update";
        }

        // ================= HELPER =================

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                XtraMessageBox.Show("Category Code required!");
                return false;
            }

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
                CategoryCode = txtCode.Text.Trim(),
                CategoryName = txtName.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                Active = chkActive.Checked
            };
        }

        private void ClearForm()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtRemark.Text = "";

            chkActive.Checked = true;

            _editingId = null;

            btnAdd.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
