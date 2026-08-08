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
            this._api = APIGlobals.Api ?? new APIsController();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string newPass = txtNewPassword.Text.Trim();
                string confirm = txtConfirmPassword.Text.Trim();


                if (
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

                //if (newPass.Length < 8)
                //{
                //    XtraMessageBox.Show("Password must be at least 8 characters.");
                //    return;
                //}

              
                var data = new
                {
                    newPassword = newPass
                };


                var res = await _api.PutAsync(
                    $"api/users/{APIGlobals.UserId}/reset-password",
                    data);

                if (!res)
                {
                    XtraMessageBox.Show("Change password failed.");
                    return;
                }

         
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
                txtNewPassword.PasswordChar = '•';
                txtConfirmPassword.PasswordChar = '•';

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = chkShow.Checked ? '\0' : '•';
            txtConfirmPassword.PasswordChar = chkShow.Checked ? '\0' : '•';
        }
    }
}