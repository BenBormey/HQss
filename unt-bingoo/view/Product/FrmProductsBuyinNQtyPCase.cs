using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class FrmProductsBuyinNQtyPCase : DevExpress.XtraEditors.XtraForm
    {
        private ApplicationFramework App = new ApplicationFramework();

        public double vBuyin { get; set; }
        public decimal vQtyPerCase { get; set; }
        public bool vDefaultBuyinFocus { get; set; }

        public FrmProductsBuyinNQtyPCase()
        {
            InitializeComponent();
        }

        private void FrmProductsBuyinNQtyPCase_Load(object sender, EventArgs e)
        {
            TxtBuyin.Text = vBuyin.ToString("N2");
            TxtQtyPerCase.Text = vQtyPerCase.ToString("N0");
        }

        private void FrmProductsBuyinNQtyPCase_Activated(object sender, EventArgs e)
        {
            TxtNewBuyin.Focus();
        }

        private void TxtNewBuyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                TxtNewBuyin.Text = Clipboard.GetText();
                TxtNewBuyin.SelectionStart = TxtNewBuyin.Text.Length;
                TxtNewBuyin.Focus();
            }
        }

        private void TxtBuyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, null, 25);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

            vBuyin = string.IsNullOrEmpty(TxtNewBuyin.Text.Trim()) ? 0 : Convert.ToDouble(TxtNewBuyin.Text.Trim());
            vQtyPerCase = string.IsNullOrEmpty(TxtNewQtyPerCase.Text.Trim()) ? 0 : Convert.ToDecimal(TxtNewQtyPerCase.Text.Trim());

            if (vBuyin == 0)
                vBuyin = string.IsNullOrEmpty(TxtBuyin.Text.Trim()) ? 0 : Convert.ToDouble(TxtBuyin.Text.Trim());

            if (vQtyPerCase == 0)
                vQtyPerCase = string.IsNullOrEmpty(TxtQtyPerCase.Text.Trim()) ? 1 : Convert.ToDecimal(TxtQtyPerCase.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}