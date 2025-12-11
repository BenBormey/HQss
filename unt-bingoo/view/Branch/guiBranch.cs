using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Branch
{
    public partial class guiBranch : XtraForm
    {
        private BindingList<BranchItem> _branchList = new BindingList<BranchItem>();
        private readonly APIsController _api;
        private int? _editingId = null;

        public guiBranch()
        {
            InitializeComponent();
            _api = new APIsController();

            // Optional: some grid settings
            var view = gvBranch as GridView;
            if (view != null)
            {
                view.OptionsBehavior.Editable = false;
                view.OptionsView.ShowGroupPanel = false;
            }
        }

        #region Form / Load

        private async void guiBranch_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadBranchesAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadBranchesAsync()
        {
            List<BranchItem> list = await _api.GetBranchAsync();

            if (list == null)
                _branchList = new BindingList<BranchItem>();
            else
                _branchList = new BindingList<BranchItem>(list);

            gridBranch.DataSource = _branchList;
            gvBranch.BestFitColumns();

            lblCountRow.Text = $"Count Row : {_branchList.Count}";
        }

        #endregion

        #region Helper

        private void ClearForm()
        {
            txtBranchCode.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtRemark.Text = string.Empty;
            chkActive.Checked = true;

            _editingId = null;
            btnAdd.Text = "Add";           // back to Add mode
        }

        private BranchItem GetFormData()
        {
            return new BranchItem
            {
                Id = _editingId ?? 0,
                BranchCode = txtBranchCode.Text.Trim(),
                BranchName = txtBranchName.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                Active = chkActive.Checked
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBranchCode.Text))
            {
                XtraMessageBox.Show("Please input Branch Code.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBranchCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBranchName.Text))
            {
                XtraMessageBox.Show("Please input Branch Name.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBranchName.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Buttons

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Add or Update
        /// </summary>
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var model = GetFormData();
            bool ok;

            try
            {
                if (_editingId == null)
                {
                    // ADD
                    ok = await _api.AddBranchAsync(model);
                    if (ok)
                    {
                        XtraMessageBox.Show("Branch added successfully.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // UPDATE
                    ok = await _api.UpdateBranchAsync(_editingId.Value, model);
                    if (ok)
                    {
                        XtraMessageBox.Show("Branch updated successfully.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (ok)
                {
                    await LoadBranchesAsync();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Request failed.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Grid Button Columns

   
        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvBranch.GetFocusedRow() as BranchItem;
            if (row == null) return;

            var confirm = XtraMessageBox.Show(
                $"Delete branch: {row.BranchName} ?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                bool ok = await _api.DeleteBranchAsync(row.Id);
                if (ok)
                {
                    _branchList.Remove(row);
                    lblCountRow.Text = $"Count Row : {_branchList.Count}";
                }
                else
                {
                    XtraMessageBox.Show("Delete failed.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click Update button inside grid
        /// </summary>
        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gvBranch.GetFocusedRow() as BranchItem;
            if (row == null) return;

            txtBranchCode.Text = row.BranchCode;
            txtBranchName.Text = row.BranchName;
            txtRemark.Text = row.Remark;
            chkActive.Checked = row.Active;

            _editingId = row.Id;
            btnAdd.Text = "Update";
        }

        #endregion
    }
}
