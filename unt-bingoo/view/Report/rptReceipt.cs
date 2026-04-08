using DevExpress.XtraReports.UI;
using System;
using System.Drawing;

namespace unt_bingoo.view.Report
{
    public partial class rptReceipt : XtraReport
    {
        public rptReceipt()
        {
            InitializeComponent();
        }

     
        public void SetData(
            string invoice,
            decimal subtotal,
            decimal discount,
            decimal total,
            decimal cash,
            decimal change,
            string payment)
        {
            lblInvoice.Text = $"Invoice: {invoice}";
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            lblSubtotal.Text = $"Subtotal: {subtotal:0.00}";
            lblDiscount.Text = $"Discount: {discount:0.00}";
            lblGrandTotal.Text = $"Total: {total:0.00}";
            lblCash.Text = $"Cash: {cash:0.00}";
            lblChange.Text = $"Change: {change:0.00}";
            lblPayment.Text = $"Payment: {payment}";
        }

      
        public void AddItem(
            string productName,
            int qty,
            decimal price,
            decimal total)
        {
            XRTableRow row = new XRTableRow();

            row.Cells.Add(CreateCell(productName));
            row.Cells.Add(CreateCell(qty.ToString()));
            row.Cells.Add(CreateCell(price.ToString("0.00")));
            row.Cells.Add(CreateCell(total.ToString("0.00")));

            tblItems.Rows.Add(row);
        }

        private XRTableCell CreateCell(string text)
        {
            return new XRTableCell()
            {
                Text = text,
                Font = new Font("Arial", 9)
            };
        }
    }
}