namespace unt_bingoo.view.Report
{
    partial class guiSaleReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.chkAllOutlets = new DevExpress.XtraEditors.CheckEdit();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSaleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalOrders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrossAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblCountCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalAmount = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllOutlets.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblSystemName);
            this.pnlHeader.Controls.Add(this.PicSectionIcon);
            this.pnlHeader.Controls.Add(this.lblFrom);
            this.pnlHeader.Controls.Add(this.dtFrom);
            this.pnlHeader.Controls.Add(this.lblTo);
            this.pnlHeader.Controls.Add(this.dtTo);
            this.pnlHeader.Controls.Add(this.chkAllOutlets);
            this.pnlHeader.Controls.Add(this.cboOutlet);
            this.pnlHeader.Controls.Add(this.btnView);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 78);
            this.pnlHeader.TabIndex = 0;
            //
            // PicSectionIcon
            //
            this.PicSectionIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.PicSectionIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(2, 2);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(98, 74);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 0;
            this.PicSectionIcon.TabStop = false;
            //
            // lblSystemName
            //
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(110, 48);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(120, 24);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Sale Report";
            //
            // lblFrom
            //
            this.lblFrom.Location = new System.Drawing.Point(120, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(29, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From:";
            //
            // dtFrom
            //
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(160, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(120, 20);
            this.dtFrom.TabIndex = 3;
            //
            // lblTo
            //
            this.lblTo.Location = new System.Drawing.Point(295, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(16, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To:";
            //
            // dtTo
            //
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(320, 12);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Size = new System.Drawing.Size(120, 20);
            this.dtTo.TabIndex = 5;
            //
            // chkAllOutlets
            //
            this.chkAllOutlets.EditValue = true;
            this.chkAllOutlets.Location = new System.Drawing.Point(460, 12);
            this.chkAllOutlets.Name = "chkAllOutlets";
            this.chkAllOutlets.Properties.Caption = "All Outlets";
            this.chkAllOutlets.Size = new System.Drawing.Size(90, 19);
            this.chkAllOutlets.TabIndex = 6;
            this.chkAllOutlets.CheckedChanged += new System.EventHandler(this.chkAllOutlets_CheckedChanged);
            //
            // cboOutlet
            //
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Enabled = false;
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(560, 11);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(220, 21);
            this.cboOutlet.TabIndex = 7;
            //
            // btnView
            //
            this.btnView.Location = new System.Drawing.Point(800, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 26);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "&View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            //
            // gridControl1
            //
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 78);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1100, 426);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // gridView1
            //
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSaleDate,
            this.colInvoiceNo,
            this.colOutletName,
            this.colTotalOrders,
            this.colTotalQty,
            this.colGrossAmount,
            this.colTotalDiscount,
            this.colNetAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            //
            // colSaleDate
            //
            this.colSaleDate.Caption = "Sale Date";
            this.colSaleDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colSaleDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSaleDate.FieldName = "SaleDate";
            this.colSaleDate.Name = "colSaleDate";
            this.colSaleDate.Visible = true;
            this.colSaleDate.VisibleIndex = 0;
            this.colSaleDate.Width = 100;
            //
            // colInvoiceNo
            //
            this.colInvoiceNo.Caption = "Invoice No";
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 1;
            this.colInvoiceNo.Width = 130;
            //
            // colOutletName
            //
            this.colOutletName.Caption = "Outlet";
            this.colOutletName.FieldName = "OutletName";
            this.colOutletName.Name = "colOutletName";
            this.colOutletName.Visible = true;
            this.colOutletName.VisibleIndex = 2;
            this.colOutletName.Width = 160;
            //
            // colTotalOrders
            //
            this.colTotalOrders.Caption = "Orders";
            this.colTotalOrders.DisplayFormat.FormatString = "n0";
            this.colTotalOrders.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalOrders.FieldName = "TotalOrders";
            this.colTotalOrders.Name = "colTotalOrders";
            this.colTotalOrders.Visible = true;
            this.colTotalOrders.VisibleIndex = 3;
            this.colTotalOrders.Width = 70;
            //
            // colTotalQty
            //
            this.colTotalQty.Caption = "Qty";
            this.colTotalQty.DisplayFormat.FormatString = "n0";
            this.colTotalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.Visible = true;
            this.colTotalQty.VisibleIndex = 4;
            this.colTotalQty.Width = 70;
            //
            // colGrossAmount
            //
            this.colGrossAmount.Caption = "Gross Amount";
            this.colGrossAmount.DisplayFormat.FormatString = "n2";
            this.colGrossAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGrossAmount.FieldName = "GrossAmount";
            this.colGrossAmount.Name = "colGrossAmount";
            this.colGrossAmount.Visible = true;
            this.colGrossAmount.VisibleIndex = 5;
            this.colGrossAmount.Width = 110;
            //
            // colTotalDiscount
            //
            this.colTotalDiscount.Caption = "Discount";
            this.colTotalDiscount.DisplayFormat.FormatString = "n2";
            this.colTotalDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalDiscount.FieldName = "TotalDiscount";
            this.colTotalDiscount.Name = "colTotalDiscount";
            this.colTotalDiscount.Visible = true;
            this.colTotalDiscount.VisibleIndex = 6;
            this.colTotalDiscount.Width = 100;
            //
            // colNetAmount
            //
            this.colNetAmount.Caption = "Net Amount";
            this.colNetAmount.DisplayFormat.FormatString = "n2";
            this.colNetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmount.FieldName = "NetAmount";
            this.colNetAmount.Name = "colNetAmount";
            this.colNetAmount.Visible = true;
            this.colNetAmount.VisibleIndex = 7;
            this.colNetAmount.Width = 110;
            //
            // pnlFooter
            //
            this.pnlFooter.Controls.Add(this.lblCountCaption);
            this.pnlFooter.Controls.Add(this.lblCountRow);
            this.pnlFooter.Controls.Add(this.lblTotalCaption);
            this.pnlFooter.Controls.Add(this.lblTotalAmount);
            this.pnlFooter.Controls.Add(this.btnExport);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 504);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 46);
            this.pnlFooter.TabIndex = 2;
            //
            // lblCountCaption
            //
            this.lblCountCaption.Location = new System.Drawing.Point(14, 16);
            this.lblCountCaption.Name = "lblCountCaption";
            this.lblCountCaption.Size = new System.Drawing.Size(60, 13);
            this.lblCountCaption.TabIndex = 0;
            this.lblCountCaption.Text = "Count Row :";
            //
            // lblCountRow
            //
            this.lblCountRow.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblCountRow.Appearance.Options.UseFont = true;
            this.lblCountRow.Location = new System.Drawing.Point(90, 16);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(8, 14);
            this.lblCountRow.TabIndex = 1;
            this.lblCountRow.Text = "0";
            //
            // lblTotalCaption
            //
            this.lblTotalCaption.Location = new System.Drawing.Point(180, 16);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(80, 13);
            this.lblTotalCaption.TabIndex = 2;
            this.lblTotalCaption.Text = "Total Net Amount :";
            //
            // lblTotalAmount
            //
            this.lblTotalAmount.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalAmount.Appearance.Options.UseFont = true;
            this.lblTotalAmount.Appearance.Options.UseForeColor = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(280, 16);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(28, 14);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "0.00";
            //
            // btnExport
            //
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(820, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 32);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(982, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // guiSaleReport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "guiSaleReport";
            this.Text = "Sale Report";
            this.Load += new System.EventHandler(this.guiSaleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllOutlets.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.CheckEdit chkAllOutlets;
        private System.Windows.Forms.ComboBox cboOutlet;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOutletName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn colGrossAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmount;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl lblCountCaption;
        private DevExpress.XtraEditors.LabelControl lblCountRow;
        private DevExpress.XtraEditors.LabelControl lblTotalCaption;
        private DevExpress.XtraEditors.LabelControl lblTotalAmount;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
