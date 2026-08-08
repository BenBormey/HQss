namespace unt_bingoo.view.Outlet
{
    partial class guiStockTransferHistory
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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterOutlet = new DevExpress.XtraEditors.LabelControl();
            this.cboFilterOutlet = new System.Windows.Forms.ComboBox();
            this.lblFilterCategory = new DevExpress.XtraEditors.LabelControl();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridHistory = new DevExpress.XtraGrid.GridControl();
            this.gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransferNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIngredientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeforeOutletStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAfterOutletStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferredBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1390, 76);
            this.panelHeader.TabIndex = 0;
            //
            // lblSystemName
            //
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSystemName.Location = new System.Drawing.Point(98, 50);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(1292, 26);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "JuJuBi Management System";
            //
            // picLogo
            //
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM2;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(98, 76);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // pnlFilter
            //
            this.pnlFilter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Appearance.Options.UseBackColor = true;
            this.pnlFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.cboFilterOutlet);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.lblFilterOutlet);
            this.pnlFilter.Controls.Add(this.cboFilterCategory);
            this.pnlFilter.Controls.Add(this.lblFilterCategory);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 76);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1390, 80);
            this.pnlFilter.TabIndex = 1;
            //
            // lblSearch
            //
            this.lblSearch.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblSearch.Appearance.Options.UseFont = true;
            this.lblSearch.Appearance.Options.UseForeColor = true;
            this.lblSearch.Location = new System.Drawing.Point(24, 26);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            //
            // txtSearch
            //
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(24, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 23);
            this.txtSearch.TabIndex = 1;
            //
            // lblFilterOutlet
            //
            this.lblFilterOutlet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterOutlet.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblFilterOutlet.Appearance.Options.UseFont = true;
            this.lblFilterOutlet.Appearance.Options.UseForeColor = true;
            this.lblFilterOutlet.Location = new System.Drawing.Point(186, 26);
            this.lblFilterOutlet.Name = "lblFilterOutlet";
            this.lblFilterOutlet.Size = new System.Drawing.Size(41, 17);
            this.lblFilterOutlet.TabIndex = 2;
            this.lblFilterOutlet.Text = "Outlet :";
            //
            // cboFilterOutlet
            //
            this.cboFilterOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterOutlet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterOutlet.FormattingEnabled = true;
            this.cboFilterOutlet.Location = new System.Drawing.Point(186, 45);
            this.cboFilterOutlet.Name = "cboFilterOutlet";
            this.cboFilterOutlet.Size = new System.Drawing.Size(150, 23);
            this.cboFilterOutlet.TabIndex = 3;
            //
            // lblFilterCategory
            //
            this.lblFilterCategory.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterCategory.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblFilterCategory.Appearance.Options.UseFont = true;
            this.lblFilterCategory.Appearance.Options.UseForeColor = true;
            this.lblFilterCategory.Location = new System.Drawing.Point(351, 26);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(58, 17);
            this.lblFilterCategory.TabIndex = 4;
            this.lblFilterCategory.Text = "Category :";
            //
            // cboFilterCategory
            //
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(351, 45);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(150, 23);
            this.cboFilterCategory.TabIndex = 5;
            //
            // lblFrom
            //
            this.lblFrom.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblFrom.Appearance.Options.UseFont = true;
            this.lblFrom.Appearance.Options.UseForeColor = true;
            this.lblFrom.Location = new System.Drawing.Point(511, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(35, 17);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From :";
            //
            // dtpFrom
            //
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(511, 45);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(110, 23);
            this.dtpFrom.TabIndex = 7;
            //
            // lblTo
            //
            this.lblTo.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblTo.Appearance.Options.UseFont = true;
            this.lblTo.Appearance.Options.UseForeColor = true;
            this.lblTo.Location = new System.Drawing.Point(631, 26);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 17);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To :";
            //
            // dtpTo
            //
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(631, 45);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(110, 23);
            this.dtpTo.TabIndex = 9;
            //
            // btnRefresh
            //
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnRefresh.Location = new System.Drawing.Point(871, 43);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            //
            // panelFooter
            //
            this.panelFooter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.panelFooter.Appearance.Options.UseBackColor = true;
            this.panelFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFooter.Controls.Add(this.lblCount);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 660);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1390, 40);
            this.panelFooter.TabIndex = 3;
            //
            // lblCount
            //
            this.lblCount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblCount.Appearance.Options.UseFont = true;
            this.lblCount.Appearance.Options.UseForeColor = true;
            this.lblCount.Location = new System.Drawing.Point(24, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(93, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Total Records: 0";
            //
            // pnlGrid
            //
            this.pnlGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Appearance.Options.UseBackColor = true;
            this.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlGrid.Controls.Add(this.gridHistory);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 156);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrid.Size = new System.Drawing.Size(1390, 504);
            this.pnlGrid.TabIndex = 2;
            //
            // gridHistory
            //
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.Location = new System.Drawing.Point(16, 12);
            this.gridHistory.MainView = this.gvHistory;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.Size = new System.Drawing.Size(1358, 480);
            this.gridHistory.TabIndex = 0;
            this.gridHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHistory});
            //
            // gvHistory
            //
            this.gvHistory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvHistory.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvHistory.Appearance.Row.Options.UseFont = true;
            this.gvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransferNo,
            this.colCreatedAt,
            this.colIngredientName,
            this.colOutletName,
            this.colQty,
            this.colBeforeOutletStock,
            this.colAfterOutletStock,
            this.colReason,
            this.colTransferredBy,
            this.colUnitPrice,
            this.colTotalAmount});
            this.gvHistory.GridControl = this.gridHistory;
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.OptionsBehavior.Editable = false;
            this.gvHistory.OptionsView.EnableAppearanceEvenRow = true;
            this.gvHistory.OptionsView.ShowGroupPanel = false;
            this.gvHistory.RowHeight = 30;
            //
            // colTransferNo
            //
            this.colTransferNo.Caption = "Transfer No";
            this.colTransferNo.FieldName = "TransferNo";
            this.colTransferNo.Name = "colTransferNo";
            this.colTransferNo.OptionsColumn.AllowEdit = false;
            this.colTransferNo.Visible = true;
            this.colTransferNo.VisibleIndex = 0;
            this.colTransferNo.Width = 100;
            //
            // colCreatedAt
            //
            this.colCreatedAt.Caption = "Date";
            this.colCreatedAt.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.colCreatedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.OptionsColumn.AllowEdit = false;
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 1;
            this.colCreatedAt.Width = 130;
            //
            // colIngredientName
            //
            this.colIngredientName.Caption = "Ingredient";
            this.colIngredientName.FieldName = "IngredientName";
            this.colIngredientName.Name = "colIngredientName";
            this.colIngredientName.OptionsColumn.AllowEdit = false;
            this.colIngredientName.Visible = true;
            this.colIngredientName.VisibleIndex = 2;
            this.colIngredientName.Width = 150;
            //
            // colOutletName
            //
            this.colOutletName.Caption = "Outlet";
            this.colOutletName.FieldName = "OutletName";
            this.colOutletName.Name = "colOutletName";
            this.colOutletName.OptionsColumn.AllowEdit = false;
            this.colOutletName.Visible = true;
            this.colOutletName.VisibleIndex = 3;
            this.colOutletName.Width = 130;
            //
            // colQty
            //
            this.colQty.Caption = "Transfer Qty";
            this.colQty.DisplayFormat.FormatString = "0.####";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            this.colQty.Width = 90;
            //
            // colBeforeOutletStock
            //
            this.colBeforeOutletStock.Caption = "Before Stock";
            this.colBeforeOutletStock.DisplayFormat.FormatString = "0.####";
            this.colBeforeOutletStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeforeOutletStock.FieldName = "BeforeOutletStock";
            this.colBeforeOutletStock.Name = "colBeforeOutletStock";
            this.colBeforeOutletStock.OptionsColumn.AllowEdit = false;
            this.colBeforeOutletStock.Visible = true;
            this.colBeforeOutletStock.VisibleIndex = 5;
            this.colBeforeOutletStock.Width = 90;
            //
            // colAfterOutletStock
            //
            this.colAfterOutletStock.Caption = "After Stock";
            this.colAfterOutletStock.DisplayFormat.FormatString = "0.####";
            this.colAfterOutletStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAfterOutletStock.FieldName = "AfterOutletStock";
            this.colAfterOutletStock.Name = "colAfterOutletStock";
            this.colAfterOutletStock.OptionsColumn.AllowEdit = false;
            this.colAfterOutletStock.Visible = true;
            this.colAfterOutletStock.VisibleIndex = 6;
            this.colAfterOutletStock.Width = 90;
            //
            // colReason
            //
            this.colReason.Caption = "Reason";
            this.colReason.FieldName = "Reason";
            this.colReason.Name = "colReason";
            this.colReason.OptionsColumn.AllowEdit = false;
            this.colReason.Visible = true;
            this.colReason.VisibleIndex = 7;
            this.colReason.Width = 130;
            //
            // colTransferredBy
            //
            this.colTransferredBy.Caption = "Transferred By";
            this.colTransferredBy.FieldName = "TransferredBy";
            this.colTransferredBy.Name = "colTransferredBy";
            this.colTransferredBy.OptionsColumn.AllowEdit = false;
            this.colTransferredBy.Visible = true;
            this.colTransferredBy.VisibleIndex = 8;
            this.colTransferredBy.Width = 110;
            //
            // colUnitPrice
            //
            this.colUnitPrice.Caption = "Unit Price";
            this.colUnitPrice.DisplayFormat.FormatString = "$0.0000";
            this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowEdit = false;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 9;
            this.colUnitPrice.Width = 90;
            //
            // colTotalAmount
            //
            this.colTotalAmount.Caption = "Amount (Franchise)";
            this.colTotalAmount.DisplayFormat.FormatString = "$0.00";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.OptionsColumn.AllowEdit = false;
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 10;
            this.colTotalAmount.Width = 110;
            //
            // guiStockTransferHistory
            //
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "guiStockTransferHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK TRANSFER HISTORY";
            this.Load += new System.EventHandler(this.guiStockTransferHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.PictureBox picLogo;

        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.LabelControl lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private DevExpress.XtraEditors.LabelControl lblFilterOutlet;
        private System.Windows.Forms.ComboBox cboFilterOutlet;
        private DevExpress.XtraEditors.LabelControl lblFilterCategory;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnRefresh;

        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.LabelControl lblCount;

        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl gridHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colIngredientName;
        private DevExpress.XtraGrid.Columns.GridColumn colOutletName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colBeforeOutletStock;
        private DevExpress.XtraGrid.Columns.GridColumn colAfterOutletStock;
        private DevExpress.XtraGrid.Columns.GridColumn colReason;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferredBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
    }
}
