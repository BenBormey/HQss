using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.User
{
    public partial class guiPermission : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private List<PermissionItem> _permissions = new List<PermissionItem>();
        private bool _loadingRole = false;

        public guiPermission()
        {
            InitializeComponent();
        }

        private async void guiPermission_Load(object sender, EventArgs e)
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

                // Only MD (ADMIN) can manage permissions.
                var roles = await _api.GetAsync<List<RoleItem>>("api/role") ?? new List<RoleItem>();

                cboRole.DataSource = roles;
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "Id";
                cboRole.SelectedIndex = -1;

                _permissions = await _api.GetPermissionsAsync() ?? new List<PermissionItem>();

                if (_permissions.Count == 0)
                {
                    XtraMessageBox.Show(
                        APIGlobals.NoPermissionMessage,
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                chkPermissions.Items.Clear();
                foreach (var p in _permissions)
                    chkPermissions.Items.Add(p, false);

                chkPermissions.Enabled = false;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedValue == null || !(cboRole.SelectedValue is int roleId))
                return;

            try
            {
                _loadingRole = true;

                var grantedIds = await _api.GetRolePermissionIdsAsync(roleId) ?? new List<int>();

                for (int i = 0; i < chkPermissions.Items.Count; i++)
                {
                    var item = (PermissionItem)chkPermissions.Items[i];
                    chkPermissions.SetItemChecked(i, grantedIds.Contains(item.Id));
                }

                chkPermissions.Enabled = true;
                btnSave.Enabled = true;
                chkSelectAll.Checked = grantedIds.Count == _permissions.Count;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                _loadingRole = false;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_loadingRole) return;

            for (int i = 0; i < chkPermissions.Items.Count; i++)
                chkPermissions.SetItemChecked(i, chkSelectAll.Checked);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cboRole.SelectedValue == null || !(cboRole.SelectedValue is int roleId))
            {
                XtraMessageBox.Show("Please select a role first.");
                return;
            }

            try
            {
                var selectedIds = chkPermissions.CheckedItems
                    .Cast<PermissionItem>()
                    .Select(p => p.Id)
                    .ToList();

                bool ok = await _api.SaveRolePermissionsAsync(roleId, selectedIds);

                if (!ok)
                {
                    XtraMessageBox.Show("Save failed.");
                    return;
                }

                XtraMessageBox.Show("Permissions saved successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
