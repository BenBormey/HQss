using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using unt_bingoo.Class;

namespace unt_bingoo.view.Sales
{
    public partial class frmQRPayment : XtraForm
    {
        private decimal _amount;
        private BindingList<OrderItemVM> _items;
        public frmQRPayment(decimal amount, BindingList<OrderItemVM> items)
        {
            InitializeComponent();
            _amount = amount;

            lblAmount.Text = $"{_amount:0.00} USD";

            _items = items;
     

            // 🔗 BIND LIST TO GRID
            gridPaymentItems.DataSource = _items;
            gvItems.BestFitColumns();


        
            GenerateQR();
        }

        private void GenerateQR()
        {
            
            string qrData = $"PAYMENT:{_amount:0.00} USD";


    
            ZXing.BarcodeWriter qr = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 1
                }
            };

            var img = qr.Write(qrData);
            picQR.Image = img;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQRPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
