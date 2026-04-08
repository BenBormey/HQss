using System;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace unt_bingoo.view.Report
{
    partial class rptSale
    {
        private System.ComponentModel.IContainer components = null;

        public Parameter pDateFrom;
        public Parameter pDateTo;
        public Parameter pOutletName;

        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private DetailBand Detail;
        private PageHeaderBand PageHeader1;
        private ReportFooterBand ReportFooter;

        private XRLabel lblTitle;
        private XRLabel lblDateRange;
        private XRLabel lblOutlet;
        private XRLabel lblPrintedOn;

        private XRTable tblDetail;
        private XRTableRow tblDetailRow;

        private XRTableCell cellNo;
        private XRTableCell cellInvoice;
        private XRTableCell cellOutlet;
        private XRTableCell cellQty;
        private XRTableCell cellAmount;
        private XRTableCell cellSaleDate;

        private XRLabel lblTotalText;
        private XRLabel lblTotalQty;
        private XRLabel lblTotalAmt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pDateFrom = new DevExpress.XtraReports.Parameters.Parameter();
            this.pDateTo = new DevExpress.XtraReports.Parameters.Parameter();
            this.pOutletName = new DevExpress.XtraReports.Parameters.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDateRange = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOutlet = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tblDetail = new DevExpress.XtraReports.UI.XRTable();
            this.tblDetailRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellInvoice = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellOutlet = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellQty = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellSaleDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lblTotalText = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalQty = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalAmt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pDateFrom
            // 
            this.pDateFrom.Name = "pDateFrom";
            this.pDateFrom.Type = typeof(System.DateTime);
            // 
            // pDateTo
            // 
            this.pDateTo.Name = "pDateTo";
            this.pDateTo.Type = typeof(System.DateTime);
            // 
            // pOutletName
            // 
            this.pOutletName.Name = "pOutletName";
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.lblTitle,
            this.lblDateRange,
            this.lblOutlet,
            this.lblPrintedOn});
            this.TopMargin.HeightF = 187.1667F;
            this.TopMargin.Name = "TopMargin";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 61.45833F);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.SizeF = new System.Drawing.SizeF(760F, 23F);
            this.lblTitle.Text = "BINGOOO - SALES REPORT";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblDateRange
            // 
            this.lblDateRange.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Date : \' + FormatString(\'{0:dd/MM/yyyy}\', ?pDateFrom) + \' - \' + FormatString(\'{0" +
                    ":dd/MM/yyyy}\', ?pDateTo)")});
            this.lblDateRange.LocationFloat = new DevExpress.Utils.PointFloat(0F, 129.5833F);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.SizeF = new System.Drawing.SizeF(400F, 23F);
            // 
            // lblOutlet
            // 
            this.lblOutlet.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Outlet : \' + ?pOutletName")});
            this.lblOutlet.LocationFloat = new DevExpress.Utils.PointFloat(0F, 149.5833F);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.SizeF = new System.Drawing.SizeF(400F, 23F);
            // 
            // lblPrintedOn
            // 
            this.lblPrintedOn.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Printed : \' + LocalDateTimeNow()")});
            this.lblPrintedOn.LocationFloat = new DevExpress.Utils.PointFloat(400F, 129.5833F);
            this.lblPrintedOn.Name = "lblPrintedOn";
            this.lblPrintedOn.SizeF = new System.Drawing.SizeF(360F, 23F);
            this.lblPrintedOn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // BottomMargin
            // 
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
            this.tblDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblDetail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tblDetailRow});
            this.tblDetail.SizeF = new System.Drawing.SizeF(760F, 25F);
            // 
            // tblDetailRow
            // 
            this.tblDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellNo,
            this.cellInvoice,
            this.cellOutlet,
            this.cellQty,
            this.cellAmount,
            this.cellSaleDate});
            this.tblDetailRow.Name = "tblDetailRow";
            this.tblDetailRow.Weight = 11.5D;
            // 
            // cellNo
            // 
            this.cellNo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellNo.Name = "cellNo";
            this.cellNo.StylePriority.UseBorders = false;
            this.cellNo.Weight = 0.625D;
            // 
            // cellInvoice
            // 
            this.cellInvoice.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvoiceNo]")});
            this.cellInvoice.Name = "cellInvoice";
            this.cellInvoice.Weight = 0.625D;
            // 
            // cellOutlet
            // 
            this.cellOutlet.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OutletName]")});
            this.cellOutlet.Name = "cellOutlet";
            this.cellOutlet.Weight = 0.625D;
            // 
            // cellQty
            // 
            this.cellQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalQty]")});
            this.cellQty.Name = "cellQty";
            this.cellQty.Weight = 0.625D;
            // 
            // cellAmount
            // 
            this.cellAmount.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NetAmount]")});
            this.cellAmount.Name = "cellAmount";
            this.cellAmount.Weight = 0.625D;
            // 
            // cellSaleDate
            // 
            this.cellSaleDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "FormatString(\'{0:dd/MM/yyyy}\', [SaleDate])")});
            this.cellSaleDate.Name = "cellSaleDate";
            this.cellSaleDate.Weight = 0.625D;
            // 
            // PageHeader1
            // 
            this.PageHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageHeader1.HeightF = 25F;
            this.PageHeader1.Name = "PageHeader1";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(760F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell2});
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "No.";
            this.xrTableCell1.Weight = 1.4209400528029479D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "InvoiceNo";
            this.xrTableCell3.Weight = 1.4209400528029479D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "OutletName";
            this.xrTableCell4.Weight = 1.4209415933539509D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "TotalQty";
            this.xrTableCell6.Weight = 1.4209398816306142D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "NetAmount";
            this.xrTableCell7.Weight = 1.4209398896751002D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "SaleDate";
            this.xrTableCell2.Weight = 1.420940574364435D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblTotalText,
            this.lblTotalQty,
            this.lblTotalAmt});
            this.ReportFooter.HeightF = 101.375F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lblTotalText
            // 
            this.lblTotalText.LocationFloat = new DevExpress.Utils.PointFloat(300F, 0F);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.lblTotalText.Text = "TOTAL:";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Sum([TotalQty])")});
            this.lblTotalQty.LocationFloat = new DevExpress.Utils.PointFloat(400F, 0F);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Sum([NetAmount])")});
            this.lblTotalAmt.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.SizeF = new System.Drawing.SizeF(100F, 23F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(198.5417F, 84.45834F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.SizeF = new System.Drawing.SizeF(360F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "UNT WHOLESALE Co., Ltd, No.891 St.53cc, Phnom Penh";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rptSale
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader1,
            this.Detail,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(40, 40, 187, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pDateFrom,
            this.pDateTo,
            this.pOutletName});
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private XRTable xrTable1;
        private XRTableRow xrTableRow1;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell3;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell2;
        private XRLabel xrLabel1;
    }
}