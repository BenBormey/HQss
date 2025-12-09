using System;
using DevExpress.XtraReports.UI;

namespace unt_bingoo.view.Report
{
    partial class rptSale
    {
        private System.ComponentModel.IContainer components = null;

        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private DetailBand Detail;
        private ReportHeaderBand ReportHeader;
        private PageHeaderBand PageHeader;
        private ReportFooterBand ReportFooter;

        private XRLabel lblTitle;
        private XRLabel lblDateRange;
        private XRLabel lblOutlet;
        private XRLabel lblPrintedOn;

        private XRTable tblHeader;
        private XRTableRow tblHeaderRow;
        private XRTableCell cellHNo;
        private XRTableCell cellHDate;
        private XRTableCell cellHInvoice;
        private XRTableCell cellHOutlet;
        private XRTableCell cellHCashier;
        private XRTableCell cellHQty;
        private XRTableCell cellHAmount;

        private XRTable tblDetail;
        private XRTableRow tblDetailRow;
        private XRTableCell cellNo;
        private XRTableCell cellDate;
        private XRTableCell cellInvoice;
        private XRTableCell cellOutlet;
        private XRTableCell cellCashier;
        private XRTableCell cellQty;
        private XRTableCell cellAmount;

        private XRLabel lblTotalText;
        private XRLabel lblTotalQty;
        private XRLabel lblTotalAmt;
        private XRLine footerLine;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.cellNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellInvoice = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellOutlet = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellCashier = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellQty = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDateRange = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOutlet = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tblHeader = new DevExpress.XtraReports.UI.XRTable();
            this.tblHeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellHNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHInvoice = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHOutlet = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHCashier = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHQty = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellHAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.footerLine = new DevExpress.XtraReports.UI.XRLine();
            this.lblTotalText = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalQty = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalAmt = new DevExpress.XtraReports.UI.XRLabel();
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
            this.Detail.HeightF = 22F;
            this.Detail.Name = "Detail";
            // 
            // tblDetail
            // 
            this.tblDetail.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tblDetail.Font = new System.Drawing.Font("Arial", 9F);
            this.tblDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblDetailRow});
            this.tblDetail.SizeF = new System.Drawing.SizeF(780F, 22F);
            this.tblDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tblDetailRow
            // 
            this.tblDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellNo,
            this.cellDate,
            this.cellInvoice,
            this.cellOutlet,
            this.cellCashier,
            this.cellQty,
            this.cellAmount});
            this.tblDetailRow.Name = "tblDetailRow";
            this.tblDetailRow.Weight = 1.0454545454545454D;
            // 
            // cellNo
            // 
            this.cellNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.cellNo.Name = "cellNo";
            this.cellNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellNo.Weight = 0.05128205128205128D;
            // 
            // cellDate
            // 
            this.cellDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SaleDate]")});
            this.cellDate.Name = "cellDate";
            this.cellDate.TextFormatString = "{0:dd/MM/yyyy}";
            this.cellDate.Weight = 0.11538461538461539D;
            // 
            // cellInvoice
            // 
            this.cellInvoice.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvoiceNo]")});
            this.cellInvoice.Name = "cellInvoice";
            this.cellInvoice.Weight = 0.15384615384615386D;
            // 
            // cellOutlet
            // 
            this.cellOutlet.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutletName]")});
            this.cellOutlet.Name = "cellOutlet";
            this.cellOutlet.Weight = 0.20512820512820512D;
            // 
            // cellCashier
            // 
            this.cellCashier.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CashierName]")});
            this.cellCashier.Name = "cellCashier";
            this.cellCashier.Weight = 0.16666666666666666D;
            // 
            // cellQty
            // 
            this.cellQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.cellQty.Name = "cellQty";
            this.cellQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellQty.TextFormatString = "{0:n0}";
            this.cellQty.Weight = 0.089743589743589744D;
            // 
            // cellAmount
            // 
            this.cellAmount.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.cellAmount.Name = "cellAmount";
            this.cellAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellAmount.TextFormatString = "{0:n2}";
            this.cellAmount.Weight = 0.21794871794871795D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblTitle,
            this.lblDateRange,
            this.lblOutlet,
            this.lblPrintedOn});
            this.ReportHeader.HeightF = 80F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5F);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.SizeF = new System.Drawing.SizeF(780F, 25F);
            this.lblTitle.Text = "BINGOOO - SALES REPORT";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblDateRange
            // 
            this.lblDateRange.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDateRange.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35F);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.SizeF = new System.Drawing.SizeF(380F, 18F);
            this.lblDateRange.Text = "Date : [Parameters.pDateFrom] - [Parameters.pDateTo]";
            // 
            // lblOutlet
            // 
            this.lblOutlet.Font = new System.Drawing.Font("Arial", 9F);
            this.lblOutlet.LocationFloat = new DevExpress.Utils.PointFloat(0F, 53F);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.SizeF = new System.Drawing.SizeF(380F, 18F);
            this.lblOutlet.Text = "Outlet : [Parameters.pOutletName]";
            // 
            // lblPrintedOn
            // 
            this.lblPrintedOn.Font = new System.Drawing.Font("Arial", 9F);
            this.lblPrintedOn.LocationFloat = new DevExpress.Utils.PointFloat(400F, 35F);
            this.lblPrintedOn.Name = "lblPrintedOn";
            this.lblPrintedOn.SizeF = new System.Drawing.SizeF(380F, 18F);
            this.lblPrintedOn.Text = "Printed : [LocalDateTimeNow()]";
            this.lblPrintedOn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tblHeader});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            // 
            // tblHeader
            // 
            this.tblHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.tblHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblHeaderRow});
            this.tblHeader.SizeF = new System.Drawing.SizeF(780F, 25F);
            this.tblHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tblHeaderRow
            // 
            this.tblHeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellHNo,
            this.cellHDate,
            this.cellHInvoice,
            this.cellHOutlet,
            this.cellHCashier,
            this.cellHQty,
            this.cellHAmount});
            this.tblHeaderRow.Name = "tblHeaderRow";
            this.tblHeaderRow.Weight = 11.5D;
            // 
            // cellHNo
            // 
            this.cellHNo.Name = "cellHNo";
            this.cellHNo.Text = "No";
            this.cellHNo.Weight = 0.05128205128205128D;
            // 
            // cellHDate
            // 
            this.cellHDate.Name = "cellHDate";
            this.cellHDate.Text = "Date";
            this.cellHDate.Weight = 0.11538461538461539D;
            // 
            // cellHInvoice
            // 
            this.cellHInvoice.Name = "cellHInvoice";
            this.cellHInvoice.Text = "Invoice";
            this.cellHInvoice.Weight = 0.15384615384615386D;
            // 
            // cellHOutlet
            // 
            this.cellHOutlet.Name = "cellHOutlet";
            this.cellHOutlet.Text = "Outlet";
            this.cellHOutlet.Weight = 0.20512820512820512D;
            // 
            // cellHCashier
            // 
            this.cellHCashier.Name = "cellHCashier";
            this.cellHCashier.Text = "Cashier";
            this.cellHCashier.Weight = 0.16666666666666666D;
            // 
            // cellHQty
            // 
            this.cellHQty.Name = "cellHQty";
            this.cellHQty.Text = "Qty";
            this.cellHQty.Weight = 0.089743589743589744D;
            // 
            // cellHAmount
            // 
            this.cellHAmount.Name = "cellHAmount";
            this.cellHAmount.Text = "Amount";
            this.cellHAmount.Weight = 0.21794871794871795D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.footerLine,
            this.lblTotalText,
            this.lblTotalQty,
            this.lblTotalAmt});
            this.ReportFooter.HeightF = 40F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // footerLine
            // 
            this.footerLine.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.footerLine.Name = "footerLine";
            this.footerLine.SizeF = new System.Drawing.SizeF(780F, 2F);
            // 
            // lblTotalText
            // 
            this.lblTotalText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalText.LocationFloat = new DevExpress.Utils.PointFloat(340F, 10F);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.SizeF = new System.Drawing.SizeF(80F, 18F);
            this.lblTotalText.Text = "TOTAL :";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Qty])")});
            this.lblTotalQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalQty.LocationFloat = new DevExpress.Utils.PointFloat(420F, 10F);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.SizeF = new System.Drawing.SizeF(90F, 18F);
            this.lblTotalQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblTotalQty.TextFormatString = "{0:n0}";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Amount])")});
            this.lblTotalAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmt.LocationFloat = new DevExpress.Utils.PointFloat(510F, 10F);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.SizeF = new System.Drawing.SizeF(270F, 18F);
            this.lblTotalAmt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lblTotalAmt.TextFormatString = "{0:n2}";
            // 
            // rptSale
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
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
    }
}
