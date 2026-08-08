using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Purchase
{
    // Records money already paid to a supplier and lists the ledger.
    //
    // dbo.SupplierPayments existed before this screen but nothing wrote to
    // it, so Accounts Payable on the Balance Sheet always showed the full
    // amount ever received from every supplier, never reduced by what had
    // actually been paid — api/SupplierPayment/outstanding/{code} exposes
    // the same subtraction the Balance Sheet report already does, so this
    // screen and that report always agree.
    public partial class guiSupplierPayments : XtraForm
    {
        private APIsController _api;

        private List<SupplierItem> _suppliers = new List<SupplierItem>();
        private BindingList<SupplierPaymentItem> _payments = new BindingList<SupplierPaymentItem>();

        public guiSupplierPayments()
        {
            InitializeComponent();

            gridControlPayments.DataSource = _payments;
            gridViewPayments.OptionsView.ColumnAutoWidth = true;

            dtpPaymentDate.Value = DateTime.Now;
            cboPaymentMethod.SelectedIndex = 0;
        }

        private async void guiSupplierPayments_Load(object sender, EventArgs e)
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

                await LoadSuppliers();
                await LoadPayments();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task LoadSuppliers()
        {
            var all = await _api.GetAsync<List<SupplierItem>>("api/supplier") ?? new List<SupplierItem>();

            // A payment is keyed by SupplierCode (FK_SupplierPayment_Supplier),
            // so a supplier with no code cannot receive one here — that is an
            // existing gap in that supplier's own record, not something this
            // screen can work around.
            _suppliers = all.Where(s => !string.IsNullOrWhiteSpace(s.SupplierCode)).ToList();

            cboSupplier.DataSource = _suppliers;
            cboSupplier.DisplayMember = "SupplierName";
            cboSupplier.ValueMember = "SupplierCode";
            cboSupplier.SelectedIndex = -1;
        }

        private async Task LoadPayments()
        {
            var list = await _api.GetAsync<List<SupplierPaymentItem>>("api/SupplierPayment")
                       ?? new List<SupplierPaymentItem>();

            _payments = new BindingList<SupplierPaymentItem>(list);
            gridControlPayments.DataSource = _payments;
            gridViewPayments.BestFitColumns();
        }

        private async void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            await RefreshOutstanding();
        }

        private async Task RefreshOutstanding()
        {
            var supplier = cboSupplier.SelectedItem as SupplierItem;

            if (supplier == null)
            {
                lblOutstanding.Text = "—";
                return;
            }

            try
            {
                var result = await _api.GetAsync<SupplierOutstandingResponse>(
                    "api/SupplierPayment/outstanding/" + supplier.SupplierCode);

                lblOutstanding.Text = (result?.Outstanding ?? 0m).ToString("C2", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                lblOutstanding.Text = "—";
                XtraMessageBox.Show("Could not load outstanding balance: " + ex.Message);
            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            var supplier = cboSupplier.SelectedItem as SupplierItem;

            if (supplier == null)
            {
                XtraMessageBox.Show("Choose a supplier first.");
                return;
            }

            if (cboPaymentMethod.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Choose a payment method.");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), NumberStyles.Number,
                    CultureInfo.InvariantCulture, out var amount) || amount <= 0)
            {
                XtraMessageBox.Show("Enter an amount greater than zero.");
                return;
            }

            var body = new SupplierPaymentItem
            {
                SupplierCode = supplier.SupplierCode,
                PurchaseOrderId = nudPurchaseOrderId.Value > 0 ? (int?)nudPurchaseOrderId.Value : null,
                PaymentDate = dtpPaymentDate.Value,
                PaymentMethod = cboPaymentMethod.SelectedItem as string,
                Amount = amount,
                ReferenceNo = string.IsNullOrWhiteSpace(txtReferenceNo.Text) ? null : txtReferenceNo.Text.Trim(),
                Remark = string.IsNullOrWhiteSpace(txtRemark.Text) ? null : txtRemark.Text.Trim()
            };

            try
            {
                Cursor = Cursors.WaitCursor;

                var created = await _api.PostAsync<SupplierPaymentItem>("api/SupplierPayment", body);

                if (created == null)
                {
                    XtraMessageBox.Show("Could not record the payment.");
                    return;
                }

                XtraMessageBox.Show(created.PaymentNo + " recorded.");

                txtAmount.Text = "";
                txtReferenceNo.Text = "";
                txtRemark.Text = "";
                nudPurchaseOrderId.Value = 0;

                await LoadPayments();
                await RefreshOutstanding();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadPayments();
            await RefreshOutstanding();
        }
    }
}
