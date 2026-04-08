using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace unt_bingoo.view.Report
{
    public partial class rptSale : DevExpress.XtraReports.UI.XtraReport
    {
        private int rowNo = 0;
        public rptSale()
        {
            InitializeComponent();
        }

        private void rptSale_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowNo = 0;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowNo++;
            cellNo.Text = rowNo.ToString();
        }
    }
}
