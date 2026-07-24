namespace unt_bingoo.view.Outlet
{
    partial class guiOutletOrderApproval
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
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlOrders = new DevExpress.XtraGrid.GridControl();
            this.gridViewOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProNumY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFulfilledQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFulfillQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblCountCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnFulfill = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.lblSystemName);
            this.pnlHeader.Controls.Add(this.PicSectionIcon);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.cboStatus);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1150, 78);
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
            this.lblSystemName.Size = new System.Drawing.Size(230, 24);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Outlet Order Approval";
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(120, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            //
            // cboStatus
            //
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "All",
            "Requested",
            "Approved",
            "PartiallyFulfilled",
            "Fulfilled",
            "Rejected"});
            this.cboStatus.Location = new System.Drawing.Point(165, 12);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(160, 21);
            this.cboStatus.TabIndex = 3;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(345, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 26);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // splitContainer
            //
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Horizontal = false;
            this.splitContainer.Location = new System.Drawing.Point(0, 78);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.gridControlOrders);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.gridControlItems);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(1150, 476);
            this.splitContainer.SplitterPosition = 250;
            this.splitContainer.TabIndex = 1;
            //
            // gridControlOrders
            //
            this.gridControlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOrders.Location = new System.Drawing.Point(0, 0);
            this.gridControlOrders.MainView = this.gridViewOrders;
            this.gridControlOrders.Name = "gridControlOrders";
            this.gridControlOrders.Size = new System.Drawing.Size(1150, 250);
            this.gridControlOrders.TabIndex = 0;
            this.gridControlOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrders});
            //
            // gridViewOrders
            //
            this.gridViewOrders.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
            this.gridViewOrders.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewOrders.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridViewOrders.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewOrders.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewOrders.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewOrders.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNo,
            this.colOutletName,
            this.colOrderDate,
            this.colExpectedDate,
            this.colStatus,
            this.colNote});
            this.gridViewOrders.GridControl = this.gridControlOrders;
            this.gridViewOrders.IndicatorWidth = 40;
            this.gridViewOrders.Name = "gridViewOrders";
            this.gridViewOrders.OptionsBehavior.Editable = false;
            this.gridViewOrders.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewOrders.OptionsView.ShowGroupPanel = false;
            this.gridViewOrders.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewOrders_FocusedRowChanged);
            //
            // colOrderNo
            //
            this.colOrderNo.Caption = "Order No";
            this.colOrderNo.FieldName = "OutletOrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 0;
            this.colOrderNo.Width = 130;
            //
            // colOutletName
            //
            this.colOutletName.Caption = "Outlet";
            this.colOutletName.FieldName = "OutletName";
            this.colOutletName.Name = "colOutletName";
            this.colOutletName.Visible = true;
            this.colOutletName.VisibleIndex = 1;
            this.colOutletName.Width = 180;
            //
            // colOrderDate
            //
            this.colOrderDate.Caption = "Order Date";
            this.colOrderDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 2;
            this.colOrderDate.Width = 100;
            //
            // colExpectedDate
            //
            this.colExpectedDate.Caption = "Expected Date";
            this.colExpectedDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colExpectedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colExpectedDate.FieldName = "ExpectedDate";
            this.colExpectedDate.Name = "colExpectedDate";
            this.colExpectedDate.Visible = true;
            this.colExpectedDate.VisibleIndex = 3;
            this.colExpectedDate.Width = 110;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 120;
            //
            // colNote
            //
            this.colNote.Caption = "Note";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 5;
            this.colNote.Width = 220;
            //
            // gridControlItems
            //
            this.gridControlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlItems.Location = new System.Drawing.Point(0, 0);
            this.gridControlItems.MainView = this.gridViewItems;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.Size = new System.Drawing.Size(1150, 216);
            this.gridControlItems.TabIndex = 0;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            //
            // gridViewItems
            //
            this.gridViewItems.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
            this.gridViewItems.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewItems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridViewItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewItems.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewItems.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProNumY,
            this.colProductName,
            this.colRequestedQty,
            this.colFulfilledQty,
            this.colRemainingQty,
            this.colFulfillQty});
            this.gridViewItems.GridControl = this.gridControlItems;
            this.gridViewItems.IndicatorWidth = 40;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            //
            // colProNumY
            //
            this.colProNumY.Caption = "Product Code";
            this.colProNumY.FieldName = "ProNumY";
            this.colProNumY.Name = "colProNumY";
            this.colProNumY.OptionsColumn.AllowEdit = false;
            this.colProNumY.Visible = true;
            this.colProNumY.VisibleIndex = 0;
            this.colProNumY.Width = 130;
            //
            // colProductName
            //
            this.colProductName.Caption = "Product Name";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsColumn.AllowEdit = false;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            this.colProductName.Width = 250;
            //
            // colRequestedQty
            //
            this.colRequestedQty.Caption = "Requested";
            this.colRequestedQty.DisplayFormat.FormatString = "n0";
            this.colRequestedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRequestedQty.FieldName = "RequestedQty";
            this.colRequestedQty.Name = "colRequestedQty";
            this.colRequestedQty.OptionsColumn.AllowEdit = false;
            this.colRequestedQty.Visible = true;
            this.colRequestedQty.VisibleIndex = 2;
            this.colRequestedQty.Width = 90;
            //
            // colFulfilledQty
            //
            this.colFulfilledQty.Caption = "Fulfilled";
            this.colFulfilledQty.DisplayFormat.FormatString = "n0";
            this.colFulfilledQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFulfilledQty.FieldName = "FulfilledQty";
            this.colFulfilledQty.Name = "colFulfilledQty";
            this.colFulfilledQty.OptionsColumn.AllowEdit = false;
            this.colFulfilledQty.Visible = true;
            this.colFulfilledQty.VisibleIndex = 3;
            this.colFulfilledQty.Width = 90;
            //
            // colRemainingQty
            //
            this.colRemainingQty.Caption = "Remaining";
            this.colRemainingQty.DisplayFormat.FormatString = "n0";
            this.colRemainingQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemainingQty.FieldName = "RemainingQty";
            this.colRemainingQty.Name = "colRemainingQty";
            this.colRemainingQty.OptionsColumn.AllowEdit = false;
            this.colRemainingQty.Visible = true;
            this.colRemainingQty.VisibleIndex = 4;
            this.colRemainingQty.Width = 90;
            //
            // colFulfillQty
            //
            this.colFulfillQty.AppearanceCell.BackColor = System.Drawing.Color.LightYellow;
            this.colFulfillQty.AppearanceCell.Options.UseBackColor = true;
            this.colFulfillQty.Caption = "Fulfill Now";
            this.colFulfillQty.DisplayFormat.FormatString = "n0";
            this.colFulfillQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFulfillQty.FieldName = "FulfillQty";
            this.colFulfillQty.Name = "colFulfillQty";
            this.colFulfillQty.Visible = true;
            this.colFulfillQty.VisibleIndex = 5;
            this.colFulfillQty.Width = 90;
            //
            // pnlFooter
            //
            this.pnlFooter.Controls.Add(this.lblCountCaption);
            this.pnlFooter.Controls.Add(this.lblCountRow);
            this.pnlFooter.Controls.Add(this.btnApprove);
            this.pnlFooter.Controls.Add(this.btnReject);
            this.pnlFooter.Controls.Add(this.btnFulfill);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 554);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1150, 46);
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
            // btnApprove
            //
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnApprove.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseForeColor = true;
            this.btnApprove.Location = new System.Drawing.Point(590, 7);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 32);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "&Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            //
            // btnReject
            //
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnReject.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnReject.Appearance.Options.UseBackColor = true;
            this.btnReject.Appearance.Options.UseForeColor = true;
            this.btnReject.Location = new System.Drawing.Point(710, 7);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(110, 32);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "&Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            //
            // btnFulfill
            //
            this.btnFulfill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFulfill.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnFulfill.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFulfill.Appearance.Options.UseBackColor = true;
            this.btnFulfill.Appearance.Options.UseForeColor = true;
            this.btnFulfill.Location = new System.Drawing.Point(830, 7);
            this.btnFulfill.Name = "btnFulfill";
            this.btnFulfill.Size = new System.Drawing.Size(140, 32);
            this.btnFulfill.TabIndex = 4;
            this.btnFulfill.Text = "&Process / Fulfill";
            this.btnFulfill.Click += new System.EventHandler(this.btnFulfill_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1000, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // guiOutletOrderApproval
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 600);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "guiOutletOrderApproval";
            this.Text = "Outlet Order Approval";
            this.Load += new System.EventHandler(this.guiOutletOrderApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraGrid.GridControl gridControlOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOutletName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraGrid.Columns.GridColumn colProNumY;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colFulfilledQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingQty;
        private DevExpress.XtraGrid.Columns.GridColumn colFulfillQty;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl lblCountCaption;
        private DevExpress.XtraEditors.LabelControl lblCountRow;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnReject;
        private DevExpress.XtraEditors.SimpleButton btnFulfill;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
