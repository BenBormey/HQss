using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using unt_bingoo.Class;   // <-- for OrderItemVM

namespace unt_bingoo.view.Sales
{
    public partial class frmPayment : XtraForm
    {
        private BindingList<OrderItemVM> _items;
        private decimal _subtotal;
        private decimal _discount;
        private decimal _total;
        private string _note;

        public frmPayment(BindingList<OrderItemVM> items,
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

            // 🔗 BIND LIST TO GRID
            gridPaymentItems.DataSource = _items;
            gvItems.BestFitColumns();

            // 🔢 SET SUMMARY LABELS
            lblSubTotal.Text = _subtotal.ToString("0.00");
            lblDiscount.Text = _discount.ToString("0.00");
            lblTotal.Text = _total.ToString("0.00");

            //if (lblNote != null)
            //    lblNote.Text = string.IsNullOrWhiteSpace(_note) ? "-" : _note;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
        }

        private void btnPayCash_Click(object sender, EventArgs e)
        {
            if (_total <= 0)
            {
                XtraMessageBox.Show("Invalid total amount!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XtraMessageBox.Show(
                $"Payment Completed (Cash): {_total:0.00} USD",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;

            var form = new guiPaysuceess(_total);   // បើ constructor មិនមាន parameter គ្រាន់ new guiPaysuceess();
            form.ShowDialog();
            this.Close();
        }

        private void btnPayQR_Click(object sender, EventArgs e)
        {
            if (_total <= 0)
            {
                XtraMessageBox.Show("Invalid total amount!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // now _items exists ✅
            var qr = new frmQRPayment(_total, this._items);
            qr.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
