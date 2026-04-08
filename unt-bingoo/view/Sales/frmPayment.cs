using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using unt_bingoo.Class;

namespace unt_bingoo.view.Sales
{
    public partial class frmPayment : XtraForm
    {
        private BindingList<OrderItemVM> _items;
        private decimal _subtotal;
        private decimal _discount;
        private decimal _total;
        private string _note; public decimal CashReceived { get; private set; }


        // ✅ Return to caller
        public string PaymentMethod { get; private set; } = "";

        public frmPayment(
            BindingList<OrderItemVM> items,
            decimal subtotal,
            decimal discount,
            decimal total,
            string note = "")
        {
            InitializeComponent();

            _items = items;
            _subtotal = subtotal;
            _discount = discount;
            _total = total;
            _note = note;

            // 🔗 Bind grid
            gridPaymentItems.DataSource = _items;
            gvItems.BestFitColumns();

            // 🔢 Summary
            lblSubTotal.Text = _subtotal.ToString("0.00");
            lblDiscount.Text = _discount.ToString("0.00");
            lblTotal.Text = _total.ToString("0.00");
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
        }

        // =====================================
        // ✅ CASH PAYMENT
        // =====================================
        private void btnPayCash_Click(object sender, EventArgs e)
        {
            if (_total <= 0)
            {
                XtraMessageBox.Show("Invalid total amount!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtCashReceived.Text, out decimal cash))
            {
                XtraMessageBox.Show("Please enter cash!");
                return;
            }

            if (cash < _total)
            {
                XtraMessageBox.Show("Not enough cash!");
                return;
            }

            var confirm = XtraMessageBox.Show(
                $"Confirm cash payment {_total:0.00} USD ?\nChange: {(cash - _total):0.00}",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            CashReceived = cash;

            PaymentMethod = "Cash";

            XtraMessageBox.Show(
                "Payment completed successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // =====================================
        // ✅ QR PAYMENT
        // =====================================
        private void btnPayQR_Click(object sender, EventArgs e)
        {
            if (_total <= 0)
            {
                XtraMessageBox.Show("Invalid total amount!", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Open QR Form
            var qrForm = new frmQRPayment(_total, _items);

            if (qrForm.ShowDialog() != DialogResult.OK)
                return;

            // ✅ QR success
            PaymentMethod = "QR";

            XtraMessageBox.Show(
                "QR payment completed!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // =====================================
        // ❌ CANCEL
        // =====================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirm = XtraMessageBox.Show(
                "Cancel payment?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCashReceived_EditValueChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCashReceived.Text, out decimal cash))
            {
                txtCashReceived.Text = "0.00";
                txtChange.ForeColor = Color.Red;
                return;
            }

            decimal total = _total; 

            decimal change = cash - total;

            if (change < 0)
            {
              
                txtCashReceived.Text = "0.00";
                txtChange.ForeColor = Color.Red;
            }
            else
            {
            
                txtChange.Text = change.ToString("0.00");
                txtChange.ForeColor = Color.Green;
            }
        }
    }
}
