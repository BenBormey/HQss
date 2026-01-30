using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.User
{
    public partial class guiUserrole : XtraForm
    {
        private APIsController _api; // Shared session
        private BindingList<RoleItem> _roles =
            new BindingList<RoleItem>();

        private int? _editingId = null;

        public guiUserrole()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private async void guiUserrole_Load(object sender, EventArgs e)
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
            var list =
                await _api.GetAsync<System.Collections.Generic.List<RoleItem>>(
                    "api/role");

            _roles = new BindingList<RoleItem>(list);

            gridControlRole.DataSource = _roles;

            UpdateRowCount();
        }

        private void UpdateRowCount()
        {
            lblCountRow.Text = $"Count : {_roles.Count}";
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
                    ok = await _api.PostAsync("api/role", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Add failed!");
                        return;
                    }

                    _roles.Add(model);

                    XtraMessageBox.Show("Added!");
                }
                // ============ UPDATE ============
                else
                {
                    ok = await _api.PutAsync($"api/role/{_editingId}", model);

                    if (!ok)
                    {
                        XtraMessageBox.Show("Update failed!");
                        return;
                    }

                    var item = _roles.FirstOrDefault(x => x.Id == _editingId);

                    if (item != null)
                    {
                        item.RoleCode = model.RoleCode;
                        item.RoleName = model.RoleName;
                        item.Description = model.Description;
                        item.IsSystemRole = model.IsSystemRole;
                        item.IsActive = model.IsActive;
                    }

                    gridViewRole.RefreshData();

                    XtraMessageBox.Show("Updated!");
                }

                UpdateRowCount();

                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= DELETE =================
        private async void btnmainDelete_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewRole.GetFocusedRow() as RoleItem;

            if (row == null) return;

            if (XtraMessageBox.Show("Delete?",
                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                bool ok =
                    await _api.DeleteAsync($"api/role/{row.Id}");

                if (!ok)
                {
                    XtraMessageBox.Show("Delete failed!");
                    return;
                }

                _roles.Remove(row);

                UpdateRowCount();

                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        // ================= EDIT =================
        private void btnmainEdit_ButtonClick(
            object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewRole.GetFocusedRow() as RoleItem;

            if (row == null) return;

            txtId.Text = row.Id.ToString();
            txtRoleCode.Text = row.RoleCode;
            txtRoleName.Text = row.RoleName;
            txtDescription.Text = row.Description;

            chkSystemRole.Checked = row.IsSystemRole;
            chkIsActive.Checked = row.IsActive;

            _editingId = row.Id;

            btnAdd.Text = "Update";
        }

        // ================= HELPER =================

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtRoleCode.Text))
            {
                XtraMessageBox.Show("Role Code required!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                XtraMessageBox.Show("Role Name required!");
                return false;
            }

            return true;
        }

        private RoleItem GetFormData()
        {
            return new RoleItem
            {
                Id = _editingId ?? 0,

                RoleCode = txtRoleCode.Text.Trim(),
                RoleName = txtRoleName.Text.Trim(),
                Description = txtDescription.Text.Trim(),

                IsSystemRole = chkSystemRole.Checked,
                IsActive = chkIsActive.Checked
            };
        }

        private void ClearForm()
        {
            txtId.Text = "";
            txtRoleCode.Text = "";
            txtRoleName.Text = "";
            txtDescription.Text = "";

            chkSystemRole.Checked = false;
            chkIsActive.Checked = true;

            _editingId = null;

            btnAdd.Text = "Add";

            gridViewRole.ClearSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
