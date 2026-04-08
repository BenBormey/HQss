using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view.User
{
    public partial class guiChangePassword : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        public guiChangePassword()
        {
            InitializeComponent();
            this._api = new APIsController();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPass = txtOldPassword.Text.Trim();
                string newPass = txtNewPassword.Text.Trim();
                string confirm = txtConfirmPassword.Text.Trim();

            
                if (string.IsNullOrEmpty(oldPass) ||
                    string.IsNullOrEmpty(newPass) ||
                    string.IsNullOrEmpty(confirm))
                {
                    XtraMessageBox.Show("Please fill all fields.");
                    return;
                }

                if (newPass != confirm)
                {
                    XtraMessageBox.Show("New password and confirm do not match.");
                    return;
                }

                if (newPass.Length < 8)
                {
                    XtraMessageBox.Show("Password must be at least 8 characters.");
                    return;
                }

              
                var data = new
                {
                    oldPassword = oldPass,
                    newPassword = newPass
                };

               
                var res = await _api.PutAsync(
                    "api/users/change-password",
                    data);

                if (!res)
                {
                    XtraMessageBox.Show("Change password failed.");
                    return;
                }

                // 4️⃣ Success
                XtraMessageBox.Show("Password changed successfully.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guiChangePassword_Load(object sender, EventArgs e)
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

           
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}