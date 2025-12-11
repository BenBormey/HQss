using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;   // ⭐ IMPORTANT: add this

namespace unt_bingoo.view.Category
{
    public partial class guiCategory : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingList<CategoryItem> _categoryList = new BindingList<CategoryItem>();

        // ⭐ API controller for calling Web API
        private readonly APIsController _apiController = new APIsController();

        public guiCategory()
        {
            InitializeComponent();

            // ចង datasource ម្តង
            gridCategory.DataSource = _categoryList;

            // (Optional) grid view setting – avoid edit direct in grid
            // gvCategory.OptionsBehavior.Editable = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // បើបងចង់បិទ Form
            this.Close();
        }

        // ⭐ Make load event async to call API
        private async void guiCategory_Load(object sender, EventArgs e)
        {
            await LoadCategoryFromApiAsync();
        }

        // ⭐ Separate function to load category from API
        private async System.Threading.Tasks.Task LoadCategoryFromApiAsync()
        {
            try
            {
                // 1. Call API
                List<CategoryItem> data = await _apiController.GetCategoryAsync();

                // 2. Fill BindingList
                _categoryList.Clear();
                foreach (var item in data)
                {
                    _categoryList.Add(item);
                }

                // 3. Adjust column width
                gvCategory.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Error while loading category from API:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var model = new CategoryItem
            {
                CategoryCode = txtCode.Text.Trim(),
                CategoryName = txtName.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                Active = chkActive.Checked
            };

            // 2. Simple validation
            if (string.IsNullOrWhiteSpace(model.CategoryCode) || string.IsNullOrWhiteSpace(model.CategoryName))
            {
                XtraMessageBox.Show(
                    "Category Code និង Category Name ត្រូវតែបំពេញ!",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // 3. Call API
                var ok = await _apiController.AddCategoryAsync(model);

                if (ok)
                {
                    XtraMessageBox.Show(
                        "Add Category Successfully ✔",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // 4. Reload list from API (or you can _categoryList.Add(model);)
                    await LoadCategoryFromApiAsync();

                    ClearCategoryForm();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Fail to add category!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Error while adding category:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Helper to clear textboxes after Add
        private void ClearCategoryForm()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtRemark.Text = string.Empty;
            chkActive.Checked = true;
        }

        private async void btnMainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gvCategory as GridView;
            if (view == null) return;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;

            var item = view.GetRow(rowHandle) as CategoryItem;
            if (item == null) return;

            // Confirm dialog
            var confirm = XtraMessageBox.Show(
                $"តើបងចង់លុប Category '{item.CategoryName}' មែនទេ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                var ok = await _apiController.DeleteCategoryAsync(item.Id);

                if (ok)
                {
                    // Remove from BindingList
                    _categoryList.Remove(item);

                    XtraMessageBox.Show(
                        "Delete Successfully ✔",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    XtraMessageBox.Show(
                        "Fail to delete category!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Error while deleting category:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnMainupdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gvCategory as GridView;
            if (view == null) return;

            int rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;


            var item = view.GetRow(rowHandle) as CategoryItem;
            if (item == null) return;

            if (item.Id <= 0)
            {
                XtraMessageBox.Show(
                    "Id of category is invalid!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                var ok = await _apiController.UpdateCategoryAsync(item.Id, item);

                if (ok)
                {
                    XtraMessageBox.Show(
                        "Update Successfully ✔",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadCategoryFromApiAsync();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Fail to update category!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Error while updating category:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
     
        

    }
}
