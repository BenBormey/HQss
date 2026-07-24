using System;
using System.Windows.Forms;

namespace unt_bingoo.view.User
{
    public partial class guiResetPassword : Form
    {
        public string NewPassword { get; private set; }

        public guiResetPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter the new password.");
                DialogResult = DialogResult.None;
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                DialogResult = DialogResult.None;
                return;
            }

            NewPassword = txtNewPassword.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
