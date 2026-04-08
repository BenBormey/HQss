using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace unt_bingoo.view.Report
{
    partial class rptPL
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.TopMargin = new TopMarginBand();
            this.BottomMargin = new BottomMarginBand();
            this.ReportHeader = new ReportHeaderBand();
            this.Detail = new DetailBand();
            this.ReportFooter = new ReportFooterBand();

            this.lblCompany = new XRLabel();
            this.lblTitle = new XRLabel();
            this.lblDate = new XRLabel();

            this.lblRevenueTitle = new XRLabel();
            this.pnlRevenue = new XRPanel();
            this.lblRevenueText = new XRLabel();
            this.lblRevenueValue = new XRLabel();

            this.lblExpenseTitle = new XRLabel();
            this.pnlExpense = new XRPanel();
            this.lblExpenseText = new XRLabel();
            this.lblExpenseValue = new XRLabel();

            this.lineTop = new XRLine();
            this.lineBottom = new XRLine();
            this.lblNetProfit = new XRLabel();

            this.fromdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.amount = new DevExpress.XtraReports.Parameters.Parameter();
            this.totalExp = new DevExpress.XtraReports.Parameters.Parameter();
            this.parameter1 = new DevExpress.XtraReports.Parameters.Parameter();

            ((ISupportInitialize)(this)).BeginInit();

            // ===== Margins =====
            this.TopMargin.HeightF = 25;
            this.BottomMargin.HeightF = 25;

            // ===== Report Header =====
            this.ReportHeader.HeightF = 120;
            this.ReportHeader.Controls.AddRange(new XRControl[]
            {
                this.lblCompany,
                this.lblTitle,
                this.lblDate
            });

            this.lblCompany.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblCompany.SizeF = new SizeF(650, 35);
            this.lblCompany.Text = "BINGOO COMPANY";
            this.lblCompany.TextAlignment = TextAlignment.MiddleCenter;

            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.LocationFloat = new DevExpress.Utils.PointFloat(0, 40);
            this.lblTitle.SizeF = new SizeF(650, 30);
            this.lblTitle.Text = "PROFIT & LOSS STATEMENT";
            this.lblTitle.TextAlignment = TextAlignment.MiddleCenter;

            this.lblDate.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "Text", "?fromdate"));
            this.lblDate.Font = new Font("Segoe UI", 10F);
            this.lblDate.LocationFloat = new DevExpress.Utils.PointFloat(0, 80);
            this.lblDate.SizeF = new SizeF(650, 25);
            this.lblDate.TextAlignment = TextAlignment.MiddleCenter;

            // ===== Detail =====
            this.Detail.HeightF = 200;
            this.Detail.Controls.AddRange(new XRControl[]
            {
                this.lblRevenueTitle,
                this.pnlRevenue,
                this.lblExpenseTitle,
                this.pnlExpense
            });

            // Revenue title
            this.lblRevenueTitle.Text = "REVENUE";
            this.lblRevenueTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblRevenueTitle.LocationFloat = new DevExpress.Utils.PointFloat(20, 0);
            this.lblRevenueTitle.SizeF = new SizeF(610, 25);

            // Revenue panel
            this.pnlRevenue.LocationFloat = new DevExpress.Utils.PointFloat(20, 30);
            this.pnlRevenue.SizeF = new SizeF(610, 40);
            this.pnlRevenue.Borders = BorderSide.Bottom;

            this.lblRevenueText.Text = "Total Sales";
            this.lblRevenueText.Font = new Font("Segoe UI", 11F);
            this.lblRevenueText.SizeF = new SizeF(300, 40);

            this.lblRevenueValue.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "Text", "?amount"));
            this.lblRevenueValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblRevenueValue.TextAlignment = TextAlignment.MiddleRight;
            this.lblRevenueValue.TextFormatString = "{0:#,##0.00}";
            this.lblRevenueValue.LocationFloat = new DevExpress.Utils.PointFloat(300, 0);
            this.lblRevenueValue.SizeF = new SizeF(310, 40);

            this.pnlRevenue.Controls.AddRange(new XRControl[]
            {
                this.lblRevenueText,
                this.lblRevenueValue
            });

            // Expense title
            this.lblExpenseTitle.Text = "EXPENSES";
            this.lblExpenseTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblExpenseTitle.LocationFloat = new DevExpress.Utils.PointFloat(20, 90);
            this.lblExpenseTitle.SizeF = new SizeF(610, 25);

            // Expense panel
            this.pnlExpense.LocationFloat = new DevExpress.Utils.PointFloat(20, 120);
            this.pnlExpense.SizeF = new SizeF(610, 40);
            this.pnlExpense.Borders = BorderSide.Bottom;

            this.lblExpenseText.Text = "Total Expense";
            this.lblExpenseText.Font = new Font("Segoe UI", 11F);
            this.lblExpenseText.SizeF = new SizeF(300, 40);

            this.lblExpenseValue.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "Text", "?totalExp"));
            this.lblExpenseValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblExpenseValue.TextAlignment = TextAlignment.MiddleRight;
            this.lblExpenseValue.TextFormatString = "{0:#,##0.00}";
            this.lblExpenseValue.LocationFloat = new DevExpress.Utils.PointFloat(300, 0);
            this.lblExpenseValue.SizeF = new SizeF(310, 40);

            this.pnlExpense.Controls.AddRange(new XRControl[]
            {
                this.lblExpenseText,
                this.lblExpenseValue
            });

            // ===== Footer =====
            this.ReportFooter.HeightF = 120;
            this.ReportFooter.Controls.AddRange(new XRControl[]
            {
                this.lineTop,
                this.lblNetProfit,
                this.lineBottom
            });

            this.lineTop.LocationFloat = new DevExpress.Utils.PointFloat(20, 0);
            this.lineTop.SizeF = new SizeF(610, 2);

            this.lblNetProfit.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "Text", "?parameter1"));
            this.lblNetProfit.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblNetProfit.LocationFloat = new DevExpress.Utils.PointFloat(20, 20);
            this.lblNetProfit.SizeF = new SizeF(610, 40);
            this.lblNetProfit.TextAlignment = TextAlignment.MiddleRight;
            this.lblNetProfit.TextFormatString = "NET PROFIT : {0:#,##0.00}";
            this.lblNetProfit.ExpressionBindings.Add(
                new ExpressionBinding("BeforePrint", "ForeColor",
                "Iif(?parameter1 >= 0, 'Green', 'Red')"));

            this.lineBottom.LocationFloat = new DevExpress.Utils.PointFloat(20, 70);
            this.lineBottom.SizeF = new SizeF(610, 2);

            // ===== Parameters =====
            this.fromdate.Name = "fromdate";
            this.fromdate.Type = typeof(string);

            this.amount.Name = "amount";
            this.amount.Type = typeof(decimal);

            this.totalExp.Name = "totalExp";
            this.totalExp.Type = typeof(decimal);

            this.parameter1.Name = "parameter1";
            this.parameter1.Type = typeof(decimal);

            // ===== Report =====
            this.Bands.AddRange(new Band[]
            {
                this.TopMargin,
                this.BottomMargin,
                this.ReportHeader,
                this.Detail,
                this.ReportFooter
            });

            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[]
            {
                this.fromdate,
                this.amount,
                this.totalExp,
                this.parameter1
            });

            this.Font = new Font("Segoe UI", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.Version = "23.2";

            ((ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private ReportHeaderBand ReportHeader;
        private DetailBand Detail;
        private ReportFooterBand ReportFooter;

        private XRLabel lblCompany;
        private XRLabel lblTitle;
        private XRLabel lblDate;

        private XRLabel lblRevenueTitle;
        private XRPanel pnlRevenue;
        private XRLabel lblRevenueText;
        private XRLabel lblRevenueValue;

        private XRLabel lblExpenseTitle;
        private XRPanel pnlExpense;
        private XRLabel lblExpenseText;
        private XRLabel lblExpenseValue;

        private XRLine lineTop;
        private XRLine lineBottom;
        private XRLabel lblNetProfit;

        private DevExpress.XtraReports.Parameters.Parameter fromdate;
        private DevExpress.XtraReports.Parameters.Parameter amount;
        private DevExpress.XtraReports.Parameters.Parameter totalExp;
        private DevExpress.XtraReports.Parameters.Parameter parameter1;
    }
}
