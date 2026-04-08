namespace unt_bingoo.view.Report
{
    partial class rptSalereport
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;

        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.XRLabel lblDateRange;

        private DevExpress.XtraReports.UI.XRLabel hDate;
        private DevExpress.XtraReports.UI.XRLabel hOrders;
        private DevExpress.XtraReports.UI.XRLabel hQty;
        private DevExpress.XtraReports.UI.XRLabel hTotal;

        private DevExpress.XtraReports.UI.XRLabel dDate;
        private DevExpress.XtraReports.UI.XRLabel dOrders;
        private DevExpress.XtraReports.UI.XRLabel dQty;
        private DevExpress.XtraReports.UI.XRLabel dTotal;

        private DevExpress.XtraReports.UI.XRLabel lblGrandTotal;
        private DevExpress.XtraReports.UI.XRLabel sumTotalSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        

            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();

            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDateRange = new DevExpress.XtraReports.UI.XRLabel();

            this.hDate = new DevExpress.XtraReports.UI.XRLabel();
            this.hOrders = new DevExpress.XtraReports.UI.XRLabel();
            this.hQty = new DevExpress.XtraReports.UI.XRLabel();
            this.hTotal = new DevExpress.XtraReports.UI.XRLabel();

            this.dDate = new DevExpress.XtraReports.UI.XRLabel();
            this.dOrders = new DevExpress.XtraReports.UI.XRLabel();
            this.dQty = new DevExpress.XtraReports.UI.XRLabel();
            this.dTotal = new DevExpress.Xtra​Reports.UI.XRLabel();

            this.lblGrandTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.sumTotalSales = new DevExpress.XtraReports.UI.XRLabel();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            // Top Margin
            this.TopMargin.HeightF = 20F;

            // Bottom Margin
            this.BottomMargin.HeightF = 20F;

            // Report Header
            this.ReportHeader.HeightF = 70F;
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.lblTitle,
                this.lblDateRange
            });

            this.lblTitle.Text = "SALES REPORT";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblTitle.BoundsF = new System.Drawing.RectangleF(0, 0, 650, 35);

            this.lblDateRange.Text = "From: - To: -";
            this.lblDateRange.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblDateRange.BoundsF = new System.Drawing.RectangleF(0, 40, 650, 20);

            // Page Header
            this.PageHeader.HeightF = 30F;
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.hDate, this.hOrders, this.hQty, this.hTotal
            });

            CreateHeader(this.hDate, "Date", 0);
            CreateHeader(this.hOrders, "Orders", 120);
            CreateHeader(this.hQty, "Qty", 240);
            CreateHeader(this.hTotal, "Total Sales", 360);

            // Detail
            this.Detail.HeightF = 25F;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.dDate, this.dOrders, this.dQty, this.dTotal
            });

            CreateDetail(this.dDate, 0);
            CreateDetail(this.dOrders, 120);
            CreateDetail(this.dQty, 240);
            CreateDetail(this.dTotal, 360);

            // Footer
            this.ReportFooter.HeightF = 30F;
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.lblGrandTotal, this.sumTotalSales
            });

            this.lblGrandTotal.Text = "TOTAL";
            this.lblGrandTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.BoundsF = new System.Drawing.RectangleF(240, 0, 120, 25);

            this.sumTotalSales.BoundsF = new System.Drawing.RectangleF(360, 0, 260, 25);
            this.sumTotalSales.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);

            DevExpress.XtraReports.UI.XRSummary summary = new DevExpress.XtraReports.UI.XRSummary();
            summary.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            summary.Func = DevExpress.XtraReports.UI.SummaryFunc.Sum;

            this.sumTotalSales.Summary = summary;

            // Add Bands
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin,
                this.BottomMargin,
                this.ReportHeader,
                this.PageHeader,
                this.Detail,
                this.ReportFooter
            });

            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 20, 20);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        private void CreateHeader(DevExpress.XtraReports.UI.XRLabel lbl, string text, float x)
        {
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            lbl.BoundsF = new System.Drawing.RectangleF(x, 0, 120, 25);
            lbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        }

        private void CreateDetail(DevExpress.XtraReports.UI.XRLabel lbl, float x)
        {
            lbl.BoundsF = new System.Drawing.RectangleF(x, 0, 120, 25);
        }
    }
}
