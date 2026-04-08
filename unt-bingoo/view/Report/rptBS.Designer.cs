namespace unt_bingoo.view.Report
{
    partial class rptBS
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();

            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();

            this.lblSection = new DevExpress.XtraReports.UI.XRLabel();
            this.lblName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAmount = new DevExpress.XtraReports.UI.XRLabel();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            // ======================
            // TopMargin
            // ======================
            this.TopMargin.HeightF = 20F;

            // ======================
            // BottomMargin
            // ======================
            this.BottomMargin.HeightF = 20F;

            // ======================
            // ReportHeader
            // ======================
            this.ReportHeader.HeightF = 80F;
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.lblTitle,
                this.lblDate
            });

            // Title
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "BALANCE SHEET";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblTitle.BoundsF = new System.Drawing.RectangleF(0, 0, 650, 35);

            // Date
            this.lblDate.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDate.Text = "As of Date:"; 
            this.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            this.lblDate.BoundsF = new System.Drawing.RectangleF(0, 40, 650, 20);

            // ======================
            // Detail
            // ======================
            this.Detail.HeightF = 25F;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.lblSection,
                this.lblName,
                this.lblAmount
            });

            // Section (ASSETS / LIABILITIES / EQUITY)
            this.lblSection.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblSection.Text = "ASSETS";
            this.lblSection.BoundsF = new System.Drawing.RectangleF(0, 0, 200, 25);

            // Item Name
            this.lblName.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblName.Text = "Cash & Bank";
            this.lblName.BoundsF = new System.Drawing.RectangleF(20, 0, 400, 25);

            // Amount
            this.lblAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
         
            this.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

        
            this.lblAmount.Text = "0.00";
            this.lblAmount.BoundsF = new System.Drawing.RectangleF(420, 0, 200, 25);

            // ======================
            // rptBS
            // ======================
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin,
                this.BottomMargin,
                this.ReportHeader,
                this.Detail
            });

            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 20, 20);
            this.Version = "19.1";

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;

        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.XRLabel lblDate;
        private DevExpress.XtraReports.UI.XRLabel lblSection;
        private DevExpress.XtraReports.UI.XRLabel lblName;
        private DevExpress.XtraReports.UI.XRLabel lblAmount;
    }
}
