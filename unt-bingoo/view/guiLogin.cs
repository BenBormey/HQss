using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;
using static unt_bingoo.Frameworks.DatabaseFramework;

namespace unt_bingoo.view
{
    public partial class guiLogin : Form
    {
        // ONE API INSTANCE ONLY
        private readonly APIsController _api;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();

        public guiLogin()
        {
            InitializeComponent();

            _api = new APIsController();

            TxtPassword.UseSystemPasswordChar = true;

            this.AcceptButton = BtnLogIn;  
            this.CancelButton = BtnExit;
        }

        private async Task Login()
        {
            try
            {
                BtnLogIn.Enabled = false;

                bool ok = await _api.MdLoginAsync(TxtPassword.Text.Trim());

                if (!ok)
                {
                    XtraMessageBox.Show("The Password is wrong!" + Environment.NewLine + "Please check the password again...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.SelectionStart = 0;
                    TxtPassword.SelectionLength = TxtPassword.TextLength;
                    TxtPassword.Focus();
                    return;
                }

                if (!await _api.HasSystemAccessAsync(APIGlobals.UserId))
                {
                    _api.Logout();
                    XtraMessageBox.Show("This account does not have permission to use this system.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.SelectionStart = 0;
                    TxtPassword.SelectionLength = TxtPassword.TextLength;
                    TxtPassword.Focus();
                    return;
                }

                // SAVE GLOBAL API
                APIGlobals.Api = _api;

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
                BtnLogIn.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogIn_Click_1(sender, e); // call login
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                BtnLogIn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
              //  btnLogin.PerformClick(); 
            }
        }

        private async void BtnLogIn_Click_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                XtraMessageBox.Show("Please enter the password login!", "Enter Password Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.TxtPassword.Focus();
                return;
            }

            await Login();
        }

        private void guiLogin_Load(object sender, EventArgs e)
        {
            Initialized initialized = new Initialized();
            Initialized.LoadingInitialized(Data, App);

            if (initialized.CheckCompaniesExistOrNot(Data, App) == true)
            {
                App.ClearController(this.TxtPassword);
            }
            else
            {
                XtraMessageBox.Show("Cannot find company name!\nPlease contact IT Assistant to create a company name!",
                                    "Invalid",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
