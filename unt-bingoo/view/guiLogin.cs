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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            try
            {
                // Basic validation
                //if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                //    string.IsNullOrWhiteSpace(txtPassword.Text))
                //{
                //    XtraMessageBox.Show("Please enter username and password!");
                //    return;
                //}

                //btnLogin.Enabled = false;

                //// USE EXISTING API INSTANCE ✅
                //bool ok = await _api.LoginAsync(
                //    txtUsername.Text.Trim(),
                //    txtPassword.Text.Trim());

                //if (!ok)
                //{
                //    XtraMessageBox.Show("Login failed!");
                //    return;
                //}

                //// SAVE GLOBAL API
                //APIGlobals.Api = _api;

                //// Debug (optional - remove later)
                //// XtraMessageBox.Show("UserId = " + APIGlobals.UserId);

                //// Open main form
                //Hide();

                //var main = new mainForm();

                //main.FormClosed += (s, e) => Close();

                //main.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Login error:\n" + ex.Message);
            }
            finally
            {
                //btnLogin.Enabled = true;
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

        private void BtnLogIn_Click_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                XtraMessageBox.Show("Please enter the password login!", "Enter Password Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.TxtPassword.Focus();
                return;
            }
            else
            {
                // Check Password MD
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "Managing Director");

                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>();
                    Dic.Add("ProgramName", "Managing Director");
                    Dic.Add("UserName", "Managing Director");
                    Dic.Add("Password", App.ConvertTextToPassword("Admin", Initialized.R_KeyPassword));
                    Dic.Add("CreatedDate", "GETDATE()");

                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }

                // Check Password GM
                Dic = new Dictionary<string, object>();
                Dic.Add("ProgramName", "UNT-ADMIN");

                if (((DataTable)Data.Selects("PasswordLogin", null, Dic, false, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count <= 0)
                {
                    Dic = new Dictionary<string, object>();
                    Dic.Add("ProgramName", "UNT-ADMIN");
                    Dic.Add("UserName", "UNT-ADMIN");
                    Dic.Add("Password", App.ConvertTextToPassword("1122", Initialized.R_KeyPassword));
                    Dic.Add("CreatedDate", "GETDATE()");

                    bool R_Result = Data.Inserts("PasswordLogin", Dic, Initialized.GetConnectionType(Data, App));
                }


                Dictionary<string, object> Dics = new Dictionary<string, object>();

                Dics.Add("ProgramName", "N'Managing Director',N'GM',N'IT Manager',N'UNT-ADMIN',N'National Sale Manager 1',N'National Sale Manager 2',N'National Sale Manager 3',N'National Sale Manager 5',N'national-sale-manager-nestle',N'Programming Support'");

                Dics.Add("Password", string.Format("'{0}'", App.ConvertTextToPassword(TxtPassword.Text, Initialized.R_KeyPassword)));

                if (((DataTable)Data.Selects("PasswordLogin", null, Dics, true, SeparatorList.Is_And, null, null, Initialized.GetConnectionType(Data, App))).Rows.Count > 0)
                {
                    this.Hide();
                    mainForm mdi = new mainForm();
                    mdi.Show();
                }
                else
                {
                    XtraMessageBox.Show("The Password is wrong!" + Environment.NewLine + "Please check the password again...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtPassword.SelectionStart = 0;
                    TxtPassword.SelectionLength = TxtPassword.TextLength;
                    TxtPassword.Focus();
                    return;
                }
            }
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
