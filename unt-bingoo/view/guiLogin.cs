using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view
{
    public partial class guiLogin : XtraForm
    {
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
                btnLogin.Enabled = false;

                bool ok = await _api.LoginAsync(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (!ok)
                {
                    XtraMessageBox.Show("Login failed!");
                    return;
                }

                // SAVE SESSION ✅
                APIGlobals.Api = _api;

                Hide();

                var main = new mainForm();
                main.FormClosed += (s, e) => Close();
                main.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
