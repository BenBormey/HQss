namespace unt_bingoo.view.Report
{
    partial class rptReceipt
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;

        private DevExpress.XtraReports.UI.XRLabel lblStore;
        private DevExpress.XtraReports.UI.XRLabel lblDate;
        private DevExpress.XtraReports.UI.XRLabel lblInvoice;

        private DevExpress.XtraReports.UI.XRLine lineTop;
        private DevExpress.XtraReports.UI.XRLine lineBottom;

        private DevExpress.XtraReports.UI.XRTable tblItems;
        private DevExpress.XtraReports.UI.XRTableRow tblHeaderRow;
        private DevExpress.XtraReports.UI.XRTableCell cellItem;
        private DevExpress.XtraReports.UI.XRTableCell cellQty;
        private DevExpress.XtraReports.UI.XRTableCell cellPrice;
        private DevExpress.XtraReports.UI.XRTableCell cellTotal;

        private DevExpress.XtraReports.UI.XRLabel lblSubtotal;
        private DevExpress.XtraReports.UI.XRLabel lblDiscount;
        private DevExpress.XtraReports.UI.XRLabel lblGrandTotal;

        private DevExpress.XtraReports.UI.XRLabel lblCash;
        private DevExpress.XtraReports.UI.XRLabel lblChange;
        private DevExpress.XtraReports.UI.XRLabel lblPayment;

        private DevExpress.XtraReports.UI.XRLabel lblFooter;

        protected override void Dispose(bool disposing)
        {
            if ((disposing && (components != null)))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();

            this.lblStore = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblInvoice = new DevExpress.XtraReports.UI.XRLabel();

            this.lineTop = new DevExpress.XtraReports.UI.XRLine();
            this.lineBottom = new DevExpress.XtraReports.UI.XRLine();

            this.tblItems = new DevExpress.XtraReports.UI.XRTable();
            this.tblHeaderRow = new DevExpress.XtraReports.UI.XRTableRow();

            this.cellItem = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellQty = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellTotal = new DevExpress.XtraReports.UI.XRTableCell();

            this.lblSubtotal = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDiscount = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGrandTotal = new DevExpress.XtraReports.UI.XRLabel();

            this.lblCash = new DevExpress.XtraReports.UI.XRLabel();
            this.lblChange = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPayment = new DevExpress.XtraReports.UI.XRLabel();

            this.lblFooter = new DevExpress.XtraReports.UI.XRLabel();

            ((System.ComponentModel.ISupportInitialize)(this.tblItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            // Detail
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblStore,
            this.lblDate,
            this.lblInvoice,
            this.lineTop,
            this.tblItems,
            this.lineBottom,
            this.lblSubtotal,
            this.lblDiscount,
            this.lblGrandTotal,
            this.lblCash,
            this.lblChange,
            this.lblPayment,
            this.lblFooter});

            this.Detail.HeightF = 500F;

            // STORE
            this.lblStore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblStore.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblStore.SizeF = new System.Drawing.SizeF(290F, 25F);
            this.lblStore.Text = "MY STORE";
            this.lblStore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            // DATE
            this.lblDate.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
            this.lblDate.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblDate.Text = "Date";
            this.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            // INVOICE
            this.lblInvoice.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.LocationFloat = new DevExpress.Utils.PointFloat(0F, 55F);
            this.lblInvoice.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblInvoice.Text = "Invoice: 0001";

            // LINE TOP
            this.lineTop.LineWidth = 2;
            this.lineTop.LocationFloat = new DevExpress.Utils.PointFloat(0F, 80F);
            this.lineTop.SizeF = new System.Drawing.SizeF(290F, 5F);

            // TABLE
            this.tblItems.LocationFloat = new DevExpress.Utils.PointFloat(0F, 90F);
            this.tblItems.SizeF = new System.Drawing.SizeF(290F, 25F);
            this.tblItems.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblHeaderRow});

            // HEADER ROW
            this.tblHeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellItem,
            this.cellQty,
            this.cellPrice,
            this.cellTotal});

            // ITEM
            this.cellItem.Text = "Item";
            this.cellItem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;

            // QTY
            this.cellQty.Text = "Qty";
            this.cellQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            // PRICE
            this.cellPrice.Text = "Price";
            this.cellPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            // TOTAL
            this.cellTotal.Text = "Total";
            this.cellTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            // LINE BOTTOM
            this.lineBottom.LineWidth = 2;
            this.lineBottom.LocationFloat = new DevExpress.Utils.PointFloat(0F, 200F);
            this.lineBottom.SizeF = new System.Drawing.SizeF(290F, 5F);

            // SUBTOTAL
            this.lblSubtotal.LocationFloat = new DevExpress.Utils.PointFloat(0F, 210F);
            this.lblSubtotal.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblSubtotal.Text = "Subtotal: 0.00";
            this.lblSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            // DISCOUNT
            this.lblDiscount.LocationFloat = new DevExpress.Utils.PointFloat(0F, 235F);
            this.lblDiscount.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblDiscount.Text = "Discount: 0.00";
            this.lblDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            // TOTAL
            this.lblGrandTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.LocationFloat = new DevExpress.Utils.PointFloat(0F, 260F);
            this.lblGrandTotal.SizeF = new System.Drawing.SizeF(290F, 22F);
            this.lblGrandTotal.Text = "TOTAL: 0.00";
            this.lblGrandTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            // CASH
            this.lblCash.LocationFloat = new DevExpress.Utils.PointFloat(0F, 290F);
            this.lblCash.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblCash.Text = "Cash: 0.00";

            // CHANGE
            this.lblChange.LocationFloat = new DevExpress.Utils.PointFloat(0F, 315F);
            this.lblChange.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblChange.Text = "Change: 0.00";

            // PAYMENT
            this.lblPayment.LocationFloat = new DevExpress.Utils.PointFloat(0F, 340F);
            this.lblPayment.SizeF = new System.Drawing.SizeF(290F, 20F);
            this.lblPayment.Text = "Payment: Cash";

            // FOOTER
            this.lblFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
            this.lblFooter.LocationFloat = new DevExpress.Utils.PointFloat(0F, 380F);
            this.lblFooter.SizeF = new System.Drawing.SizeF(290F, 25F);
            this.lblFooter.Text = "Thank you for shopping!";
            this.lblFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            // REPORT
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});

            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            this.PageWidth = 315;
            this.PageHeight = 850;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;

            ((System.ComponentModel.ISupportInitialize)(this.tblItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}