using System;
using System.Drawing;
using DevExpress.XtraReports.UI;

namespace unt_bingoo.view.Report
{
    public partial class rtpProfitandlose : XtraReport
    {
        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private DetailBand Detail;

        private ReportHeaderBand ReportHeader;
        private PageHeaderBand PageHeader;
        private ReportFooterBand ReportFooter;

        private XRLabel lblTitle;
        private XRLabel lblPeriod;

        private XRTable tblHeader;
        private XRTableRow tblHeaderRow;
        private XRTableCell cellHeaderType;
        private XRTableCell cellHeaderName;
        private XRTableCell cellHeaderAmount;

        private XRTable tblDetail;
        private XRTableRow tblDetailRow;
        private XRTableCell cellType;
        private XRTableCell cellName;
        private XRTableCell cellAmount;

        private XRLabel lblTotalRevenue;
        private XRLabel lblTotalCOGS;
        private XRLabel lblGrossProfit;
        private XRLabel lblTotalExpense;
        private XRLabel lblNetProfit;

        private System.ComponentModel.IContainer components = null;

        public rtpProfitandlose()
        {
            InitializeComponent();
        }

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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tblDetail = new DevExpress.XtraReports.UI.XRTable();
            this.tblDetailRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellType = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellName = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPeriod = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tblHeader = new DevExpress.XtraReports.UI.XRTable();
            this.tblHeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellHeaderType = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHeaderName = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHeaderAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lblTotalRevenue = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalCOGS = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGrossProfit = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalExpense = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNetProfit = new DevExpress.XtraReports.UI.XRLabel();
            this.valTotalRevenue = new DevExpress.XtraReports.UI.XRLabel();
            this.valTotalCOGS = new DevExpress.XtraReports.UI.XRLabel();
            this.valGrossProfit = new DevExpress.XtraReports.UI.XRLabel();
            this.valTotalExpense = new DevExpress.XtraReports.UI.XRLabel();
            this.valNetProfit = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 10F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tblDetail});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            // 
            // tblDetail
            // 
            this.tblDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblDetailRow});
            this.tblDetail.SizeF = new System.Drawing.SizeF(650F, 25F);
            // 
            // tblDetailRow
            // 
            this.tblDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellType,
            this.cellName,
            this.cellAmount});
            this.tblDetailRow.Name = "tblDetailRow";
            this.tblDetailRow.Weight = 11.5D;
            // 
            // cellType
            // 
            this.cellType.Name = "cellType";
            this.cellType.Text = "[Type]";
            this.cellType.Weight = 0.18461538461538463D;
            // 
            // cellName
            // 
            this.cellName.Name = "cellName";
            this.cellName.Text = "[Name]";
            this.cellName.Weight = 0.50769230769230766D;
            // 
            // cellAmount
            // 
            this.cellAmount.Name = "cellAmount";
            this.cellAmount.StylePriority.UseTextAlignment = false;
            this.cellAmount.Text = "[Amount]";
            this.cellAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellAmount.Weight = 0.30769230769230771D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblTitle,
            this.lblPeriod});
            this.ReportHeader.HeightF = 70F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitle.SizeF = new System.Drawing.SizeF(650F, 30F);
            this.lblTitle.StylePriority.UseFont = false;
            this.lblTitle.StylePriority.UseTextAlignment = false;
            this.lblTitle.Text = "Profit && Loss Statement";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPeriod.LocationFloat = new DevExpress.Utils.PointFloat(0F, 40F);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPeriod.SizeF = new System.Drawing.SizeF(650F, 20F);
            this.lblPeriod.StylePriority.UseFont = false;
            this.lblPeriod.StylePriority.UseTextAlignment = false;
            this.lblPeriod.Text = "For the period: [SetAtRuntime]";
            this.lblPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tblHeader});
            this.PageHeader.HeightF = 30F;
            this.PageHeader.Name = "PageHeader";
            // 
            // tblHeader
            // 
            this.tblHeader.BackColor = System.Drawing.Color.LightGray;
            this.tblHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5F);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblHeaderRow});
            this.tblHeader.SizeF = new System.Drawing.SizeF(650F, 25F);
            this.tblHeader.StylePriority.UseBackColor = false;
            // 
            // tblHeaderRow
            // 
            this.tblHeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellHeaderType,
            this.cellHeaderName,
            this.cellHeaderAmount});
            this.tblHeaderRow.Name = "tblHeaderRow";
            this.tblHeaderRow.Weight = 11.5D;
            // 
            // cellHeaderType
            // 
            this.cellHeaderType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cellHeaderType.Name = "cellHeaderType";
            this.cellHeaderType.StylePriority.UseFont = false;
            this.cellHeaderType.Text = "Type";
            this.cellHeaderType.Weight = 0.18461538461538463D;
            // 
            // cellHeaderName
            // 
            this.cellHeaderName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cellHeaderName.Name = "cellHeaderName";
            this.cellHeaderName.StylePriority.UseFont = false;
            this.cellHeaderName.Text = "Name";
            this.cellHeaderName.Weight = 0.50769230769230766D;
            // 
            // cellHeaderAmount
            // 
            this.cellHeaderAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cellHeaderAmount.Name = "cellHeaderAmount";
            this.cellHeaderAmount.StylePriority.UseFont = false;
            this.cellHeaderAmount.StylePriority.UseTextAlignment = false;
            this.cellHeaderAmount.Text = "Amount";
            this.cellHeaderAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellHeaderAmount.Weight = 0.30769230769230771D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblTotalRevenue,
            this.lblTotalCOGS,
            this.lblGrossProfit,
            this.lblTotalExpense,
            this.lblNetProfit,
            this.valTotalRevenue,
            this.valTotalCOGS,
            this.valGrossProfit,
            this.valTotalExpense,
            this.valNetProfit});
            this.ReportFooter.HeightF = 120F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotalRevenue.SizeF = new System.Drawing.SizeF(325F, 20F);
            this.lblTotalRevenue.Text = "Total Revenue:";
            // 
            // lblTotalCOGS
            // 
            this.lblTotalCOGS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalCOGS.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
            this.lblTotalCOGS.Name = "lblTotalCOGS";
            this.lblTotalCOGS.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotalCOGS.SizeF = new System.Drawing.SizeF(325F, 20F);
            this.lblTotalCOGS.Text = "Total COGS:";
            // 
            // lblGrossProfit
            // 
            this.lblGrossProfit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGrossProfit.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
            this.lblGrossProfit.Name = "lblGrossProfit";
            this.lblGrossProfit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGrossProfit.SizeF = new System.Drawing.SizeF(325F, 20F);
            this.lblGrossProfit.Text = "Gross Profit (Revenue - COGS):";
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpense.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotalExpense.SizeF = new System.Drawing.SizeF(325F, 20F);
            this.lblTotalExpense.Text = "Total Operating Expense:";
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblNetProfit.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNetProfit.SizeF = new System.Drawing.SizeF(325F, 20F);
            this.lblNetProfit.Text = "Net Profit (Gross - Expense):";
            // 
            // valTotalRevenue
            // 
            this.valTotalRevenue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.valTotalRevenue.LocationFloat = new DevExpress.Utils.PointFloat(330F, 0F);
            this.valTotalRevenue.Name = "valTotalRevenue";
            this.valTotalRevenue.SizeF = new System.Drawing.SizeF(320F, 20F);
            this.valTotalRevenue.Text = "[TotalRevenue]";
            this.valTotalRevenue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // valTotalCOGS
            // 
            this.valTotalCOGS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.valTotalCOGS.LocationFloat = new DevExpress.Utils.PointFloat(330F, 25F);
            this.valTotalCOGS.Name = "valTotalCOGS";
            this.valTotalCOGS.SizeF = new System.Drawing.SizeF(320F, 20F);
            this.valTotalCOGS.Text = "[TotalCOGS]";
            this.valTotalCOGS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // valGrossProfit
            // 
            this.valGrossProfit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.valGrossProfit.LocationFloat = new DevExpress.Utils.PointFloat(330F, 50F);
            this.valGrossProfit.Name = "valGrossProfit";
            this.valGrossProfit.SizeF = new System.Drawing.SizeF(320F, 20F);
            this.valGrossProfit.Text = "[GrossProfit]";
            this.valGrossProfit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // valTotalExpense
            // 
            this.valTotalExpense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.valTotalExpense.LocationFloat = new DevExpress.Utils.PointFloat(330F, 75F);
            this.valTotalExpense.Name = "valTotalExpense";
            this.valTotalExpense.SizeF = new System.Drawing.SizeF(320F, 20F);
            this.valTotalExpense.Text = "[TotalExpense]";
            this.valTotalExpense.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // valNetProfit
            // 
            this.valNetProfit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.valNetProfit.LocationFloat = new DevExpress.Utils.PointFloat(330F, 100F);
            this.valNetProfit.Name = "valNetProfit";
            this.valNetProfit.SizeF = new System.Drawing.SizeF(320F, 20F);
            this.valNetProfit.Text = "[NetProfit]";
            this.valNetProfit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // rtpProfitandlose
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.Detail,
            this.ReportFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private XRLabel valTotalRevenue;
        private XRLabel valTotalCOGS;
        private XRLabel valGrossProfit;
        private XRLabel valTotalExpense;
        private XRLabel valNetProfit;
    }
}
