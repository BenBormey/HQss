using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Branch
{
    public partial class guiBranch : XtraForm
    {
        private APIsController _api;

        private BindingList<BranchItem> _branchList =
            new BindingList<BranchItem>();

        private int? _editingId = null;

        public guiBranch()
        {
            InitializeComponent();

            // Grid setting (IMPORTANT)
            if (gridViewRole is GridView view)
            {
                view.OptionsBehavior.Editable = true;
                view.OptionsBehavior.ReadOnly = false;
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsBehavior.EditorShowMode =
                    DevExpress.Utils.EditorShowMode.Click;
            }
        }

        // ================= LOAD =================
        private async void guiBranch_Load(object sender, EventArgs e)
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
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= LOAD DATA =================
        private async Task LoadData()
        {
            var list = await _api.GetAsync<
                System.Collections.Generic.List<BranchItem>>("api/Brand");

            _branchList = new BindingList<BranchItem>(list);

            gridBranch.DataSource = _branchList;

            gridViewRole.BestFitColumns();

            UpdateRowCount();
        }

        private void UpdateRowCount()
        {
            lblCountRow.Text = $"Count Row : {_branchList.Count}";
        }

        // ================= HELPER =================
        private void ClearForm()
        {
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
            chkActive.Checked = true;

            _editingId = null;

            btnAdd.Text = "Add";
        }

        // ================= GET FORM DATA =================
        private BranchItem GetFormData()
        {
            return new BranchItem
            {
                Id = _editingId ?? 0,

                BranchCode = txtBranchCode.Text.Trim(),
                BranchName = txtBranchName.Text.Trim(),

                Active = chkActive.Checked
            };
        }

        // ================= VALIDATION =================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBranchCode.Text))
            {
                XtraMessageBox.Show("Branch Code required!");
                txtBranchCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBranchName.Text))
            {
                XtraMessageBox.Show("Branch Name required!");
                txtBranchName.Focus();
                return false;
            }

            return true;
        }

        // ================= ADD / UPDATE =================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok;

                // ============ ADD ============
                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/Brand", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    XtraMessageBox.Show("Added successfully!");
                }
                // ============ UPDATE ============
                else
                {
                    ok = await _api.PutAsync($"api/Brand/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    XtraMessageBox.Show("Updated successfully!");
                }

                await LoadData();

                ClearForm();
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

        // ================= UPDATE (GRID BUTTON) =================
        private void repositoryItemButtonEdit1_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewRole.GetFocusedRow() as BranchItem;

            if (row == null) return;

            txtBranchCode.Text = row.BranchCode;
            txtBranchName.Text = row.BranchName;
            chkActive.Checked = row.Active;

            _editingId = row.Id;

            btnAdd.Text = "Update";
        }

        // ================= DELETE (GRID BUTTON) =================
        private async void btnmainDelete_ButtonClick_1(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewRole.GetFocusedRow() as BranchItem;

            if (row == null) return;

            if (XtraMessageBox.Show(
                "Delete this branch?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                bool ok = await _api.DeleteAsync($"api/Brand/{row.Id}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                await LoadData();

                ClearForm();

                XtraMessageBox.Show("Deleted successfully!");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
                // Get selected row
                var row = gridViewRole.GetFocusedRow() as BranchItem;

                if (row == null)
                {
                    XtraMessageBox.Show("Please select a row first!");
                    return;
                }

                // Confirm delete
                if (XtraMessageBox.Show(
                    "Do you want to delete this branch?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Call API delete
                    bool ok = await _api.DeleteAsync($"api/Brand/{row.Id}");

                    if (!ok)
                    {
                        XtraMessageBox.Show("Delete failed!");
                        return;
                    }

                    // Reload data
                    await LoadData();

                    ClearForm();

                    XtraMessageBox.Show("Deleted successfully!");
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

        private void btnupdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewRole.GetFocusedRow() as BranchItem;

            if (row == null)
            {
                XtraMessageBox.Show("Please select a row first!");
                return;
            }

      
            txtBranchCode.Text = row.BranchCode;
            txtBranchName.Text = row.BranchName;
            chkActive.Checked = row.Active;

            // Set edit mode
            _editingId = row.Id;

            btnAdd.Text = "Update";

            // Focus first textbox
            txtBranchCode.Focus();

        }
    }
}
