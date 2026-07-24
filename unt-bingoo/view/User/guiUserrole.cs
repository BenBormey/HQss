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
        private APIsController _api; 
        private BindingList<RoleItem> _roles =
            new BindingList<RoleItem>();

        private int? _editingId = null;
        private bool _editingIsSystemRole = false;

        public guiUserrole()
        {
            InitializeComponent();
        }


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

                // Role management is part of the User screen permission.
                if (!APIGlobals.HasPermission("USER"))
                {
                    XtraMessageBox.Show(APIGlobals.NoPermissionMessage, "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                await LoadData();
                await AutoRoleCode();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task AutoRoleCode()
        {
            try
            {
                txtRoleCode.Text = await _api.GetNextRoleCodeAsync() ?? string.Empty;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error generating Role Code: " + ex.Message);
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
            bool rolestatus = row.IsActive;
            if (rolestatus)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkDeactive.Checked = true;
            }
            txtDescription.Text = row.Description;

            _editingIsSystemRole = row.IsSystemRole;
 

            _editingId = row.Id;
            btnCancel.Visible = true;
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

                IsSystemRole = _editingIsSystemRole,
                IsActive = chkIsActive.Checked
            };
        }

        private async void ClearForm()
        {
            txtId.Text = "";
            txtRoleName.Text = "";
            txtDescription.Text = "";

            _editingIsSystemRole = false;
            chkIsActive.Checked = true;

            _editingId = null;

            btnAdd.Text = "Add";

            gridViewRole.ClearSelection();

            await AutoRoleCode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string tempPath = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    $"Roles_{DateTime.Now:yyyyMMddHHmmss}.xlsx");

                gridViewRole.ExportToXlsx(tempPath);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void Export()
        {

            SaveFileDialog save = new SaveFileDialog();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

            if (_suppressStatusEvents) return;
            _suppressStatusEvents = true;
            try
            {
                if (chkIsActive.Checked)
                {
                    chkDeactive.Checked = false;
                }
                else if (!chkDeactive.Checked)
                {
                    // Don't allow both to end up unchecked.
                    chkIsActive.Checked = true;
                }
            }
            finally { _suppressStatusEvents = false; }
        }
        private bool _suppressStatusEvents;
    

        private void chkDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (_suppressStatusEvents) return;
            _suppressStatusEvents = true;
            try
            {
                if (chkDeactive.Checked)
                {
                    chkIsActive.Checked = false;
                }
                else if (!chkIsActive.Checked)
                {

                    chkDeactive.Checked = true;
                }
            }
            finally { _suppressStatusEvents = false; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
