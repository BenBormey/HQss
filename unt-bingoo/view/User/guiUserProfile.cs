using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view.User
{
    public partial class guiUserProfile : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;

        public guiUserProfile()
        {
            InitializeComponent();
        }

        private async void guiUserProfile_Load(object sender, EventArgs e)
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

                var user = await _api.GetMeAsync();

                if (user == null)
                {
                    XtraMessageBox.Show("Could not load user profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }

                txtUsername.Text = user.Username;
                txtUserId.Text = user.Id.ToString();
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtRole.Text = user.RoleName;
                txtOutlet.Text = user.OutletName;
                txtStatus.Text = user.IsActive ? "Active" : "Inactive";
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.address;
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
