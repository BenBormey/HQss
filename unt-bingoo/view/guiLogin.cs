using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view
{
    public partial class guiLogin : XtraForm
    {
        // ONE API INSTANCE ONLY
        private readonly APIsController _api;

        public guiLogin()
        {
            InitializeComponent();

            _api = new APIsController();

            txtPassword.UseSystemPasswordChar = true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    XtraMessageBox.Show("Please enter username and password!");
                    return;
                }

                btnLogin.Enabled = false;

                // USE EXISTING API INSTANCE ✅
                bool ok = await _api.LoginAsync(
                    txtUsername.Text.Trim(),
                    txtPassword.Text.Trim());

                if (!ok)
                {
                    XtraMessageBox.Show("Login failed!");
                    return;
                }

                // SAVE GLOBAL API
                APIGlobals.Api = _api;

                // Debug (optional - remove later)
                // XtraMessageBox.Show("UserId = " + APIGlobals.UserId);

                // Open main form
                Hide();

                var main = new mainForm();

                main.FormClosed += (s, e) => Close();

                main.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Login error:\n" + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick(); 
            }
        }
    }
}
