using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace unt_bingoo.view.Sales
{
    public partial class guiPaysuceess : XtraForm
    {
        public guiPaysuceess()
        {
            InitializeComponent();
        }

        public guiPaysuceess(decimal totalAmount) : this()
        {
            lblMessage.Text = $"Payment of {totalAmount:0.00} USD was successful.";
        }

        private void guiPaysuceess_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
