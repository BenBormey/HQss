using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;

namespace unt_bingoo.view.currency
{
    public partial class guiCurency : DevExpress.XtraEditors.XtraForm
    {
        public guiCurency()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private BindingList<CurrencyItem> _currencyList = new BindingList<CurrencyItem>();

        private void guiCurency_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _currencyList;

            // Sample Data for UI Testing
            _currencyList.Add(new CurrencyItem
            {
                CurrencyCode = "USD",
                CurrencyName = "US Dollar",
                BuyRate = 4100,
                SellRate = 4150
            });

            _currencyList.Add(new CurrencyItem
            {
                CurrencyCode = "THB",
                CurrencyName = "Thai Baht",
                BuyRate = 110,
                SellRate = 115
            });

            gridView1.BestFitColumns();
            lblCountRow.Text = $"Count Row: {_currencyList.Count}";
        }
    }
}