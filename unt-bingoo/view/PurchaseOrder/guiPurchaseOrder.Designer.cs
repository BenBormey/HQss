namespace unt_bingoo.view.PurchaseOrder
{
    partial class guiPurchaseOrder
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gvPODetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetailCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailUom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailRemaining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPO = new DevExpress.XtraGrid.GridControl();
            this.gvPO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOOutlet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOExpectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOGrandTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainReceive = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPODelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPOPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainPrint = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelHeaderBar = new System.Windows.Forms.Panel();
            this.groupEntry = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotalCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscountTotalCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscountTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblTaxTotalCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblTaxTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSavePO = new System.Windows.Forms.Button();
            this.gridLines = new DevExpress.XtraGrid.GridControl();
            this.gvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineUom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineRemove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemoveLine = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblTax = new DevExpress.XtraEditors.LabelControl();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new DevExpress.XtraEditors.LabelControl();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.lblUnitCost = new DevExpress.XtraEditors.LabelControl();
            this.cboUom = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new DevExpress.XtraEditors.LabelControl();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.lblInfoCode = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCodeValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoUnitValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCategoryValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoSupplier = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoSupplierValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoOnHand = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoOnHandValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoReorder = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoReorderValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoLastCost = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoLastCostValue = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoVat = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoVatValue = new DevExpress.XtraEditors.LabelControl();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedDate = new DevExpress.XtraEditors.LabelControl();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.lblOutlet = new DevExpress.XtraEditors.LabelControl();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvPODetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainPrint)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveLine)).BeginInit();
            this.pnlProductInfo.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvPODetail
            // 
            this.gvPODetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gvPODetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPODetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailCode,
            this.colDetailProduct,
            this.colDetailQty,
            this.colDetailUom,
            this.colDetailUnitCost,
            this.colDetailDiscount,
            this.colDetailTax,
            this.colDetailTotal,
            this.colDetailReceived,
            this.colDetailRemaining});
            this.gvPODetail.GridControl = this.gridPO;
            this.gvPODetail.Name = "gvPODetail";
            this.gvPODetail.OptionsBehavior.Editable = false;
            this.gvPODetail.OptionsView.ShowFooter = true;
            this.gvPODetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDetailCode
            // 
            this.colDetailCode.Caption = "Code";
            this.colDetailCode.FieldName = "ProNumY";
            this.colDetailCode.Name = "colDetailCode";
            this.colDetailCode.Visible = true;
            this.colDetailCode.VisibleIndex = 0;
            this.colDetailCode.Width = 130;
            // 
            // colDetailProduct
            // 
            this.colDetailProduct.Caption = "Product";
            this.colDetailProduct.FieldName = "ProductName";
            this.colDetailProduct.Name = "colDetailProduct";
            this.colDetailProduct.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductName", "{0} item(s)")});
            this.colDetailProduct.Visible = true;
            this.colDetailProduct.VisibleIndex = 1;
            this.colDetailProduct.Width = 210;
            // 
            // colDetailQty
            // 
            this.colDetailQty.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailQty.Caption = "Qty";
            this.colDetailQty.FieldName = "Quantity";
            this.colDetailQty.Name = "colDetailQty";
            this.colDetailQty.Visible = true;
            this.colDetailQty.VisibleIndex = 2;
            this.colDetailQty.Width = 65;
            // 
            // colDetailUom
            // 
            this.colDetailUom.Caption = "UOM";
            this.colDetailUom.FieldName = "UOMCode";
            this.colDetailUom.Name = "colDetailUom";
            this.colDetailUom.OptionsColumn.AllowEdit = false;
            this.colDetailUom.Visible = true;
            this.colDetailUom.VisibleIndex = 3;
            this.colDetailUom.Width = 60;
            // 
            // colDetailUnitCost
            // 
            this.colDetailUnitCost.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailUnitCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailUnitCost.Caption = "Unit Cost";
            this.colDetailUnitCost.DisplayFormat.FormatString = "N2";
            this.colDetailUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailUnitCost.FieldName = "UnitCost";
            this.colDetailUnitCost.Name = "colDetailUnitCost";
            this.colDetailUnitCost.Visible = true;
            this.colDetailUnitCost.VisibleIndex = 4;
            this.colDetailUnitCost.Width = 85;
            // 
            // colDetailDiscount
            // 
            this.colDetailDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailDiscount.Caption = "Discount %";
            this.colDetailDiscount.DisplayFormat.FormatString = "N2";
            this.colDetailDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailDiscount.FieldName = "DiscountPercent";
            this.colDetailDiscount.Name = "colDetailDiscount";
            this.colDetailDiscount.Visible = true;
            this.colDetailDiscount.VisibleIndex = 5;
            this.colDetailDiscount.Width = 80;
            // 
            // colDetailTax
            // 
            this.colDetailTax.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailTax.Caption = "Tax %";
            this.colDetailTax.DisplayFormat.FormatString = "N2";
            this.colDetailTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailTax.FieldName = "TaxPercent";
            this.colDetailTax.Name = "colDetailTax";
            this.colDetailTax.Visible = true;
            this.colDetailTax.VisibleIndex = 6;
            this.colDetailTax.Width = 65;
            // 
            // colDetailTotal
            // 
            this.colDetailTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailTotal.Caption = "Line Total";
            this.colDetailTotal.DisplayFormat.FormatString = "N2";
            this.colDetailTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailTotal.FieldName = "TotalCost";
            this.colDetailTotal.Name = "colDetailTotal";
            this.colDetailTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "{0:N2}")});
            this.colDetailTotal.Visible = true;
            this.colDetailTotal.VisibleIndex = 7;
            this.colDetailTotal.Width = 95;
            // 
            // colDetailReceived
            // 
            this.colDetailReceived.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailReceived.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailReceived.Caption = "Received";
            this.colDetailReceived.FieldName = "ReceivedQty";
            this.colDetailReceived.Name = "colDetailReceived";
            this.colDetailReceived.Visible = true;
            this.colDetailReceived.VisibleIndex = 8;
            // 
            // colDetailRemaining
            // 
            this.colDetailRemaining.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailRemaining.Caption = "Remaining";
            this.colDetailRemaining.FieldName = "RemainingQty";
            this.colDetailRemaining.Name = "colDetailRemaining";
            this.colDetailRemaining.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RemainingQty", "{0:N0}")});
            this.colDetailRemaining.Visible = true;
            this.colDetailRemaining.VisibleIndex = 9;
            this.colDetailRemaining.Width = 80;
            // 
            // gridPO
            // 
            this.gridPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.gvPODetail;
            gridLevelNode1.RelationName = "Items";
            this.gridPO.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridPO.Location = new System.Drawing.Point(13, 620);
            this.gridPO.MainView = this.gvPO;
            this.gridPO.Name = "gridPO";
            this.gridPO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnMainReceive,
            this.btnMainDelete,
            this.btnMainPrint});
            this.gridPO.Size = new System.Drawing.Size(1065, 244);
            this.gridPO.TabIndex = 3;
            this.gridPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPO,
            this.gvPODetail});
            // 
            // gvPO
            // 
            this.gvPO.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.gvPO.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPO.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gvPO.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPONo,
            this.colPOSupplier,
            this.colPOOutlet,
            this.colPOOrderDate,
            this.colPOExpectedDate,
            this.colPOGrandTotal,
            this.colPOStatus,
            this.colPOReceive,
            this.colPODelete,
            this.colPOPrint});
            this.gvPO.GridControl = this.gridPO;
            this.gvPO.Name = "gvPO";
            this.gvPO.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPO.OptionsView.ShowGroupPanel = false;
            // 
            // colPONo
            // 
            this.colPONo.Caption = "PO No.";
            this.colPONo.FieldName = "PurchaseOrderNo";
            this.colPONo.Name = "colPONo";
            this.colPONo.OptionsColumn.AllowEdit = false;
            this.colPONo.Visible = true;
            this.colPONo.VisibleIndex = 0;
            this.colPONo.Width = 100;
            // 
            // colPOSupplier
            // 
            this.colPOSupplier.Caption = "Supplier";
            this.colPOSupplier.FieldName = "SupplierName";
            this.colPOSupplier.Name = "colPOSupplier";
            this.colPOSupplier.OptionsColumn.AllowEdit = false;
            this.colPOSupplier.Visible = true;
            this.colPOSupplier.VisibleIndex = 1;
            this.colPOSupplier.Width = 180;
            // 
            // colPOOutlet
            // 
            this.colPOOutlet.Caption = "Warehouse";
            this.colPOOutlet.FieldName = "OutletName";
            this.colPOOutlet.Name = "colPOOutlet";
            this.colPOOutlet.OptionsColumn.AllowEdit = false;
            this.colPOOutlet.Visible = true;
            this.colPOOutlet.VisibleIndex = 2;
            this.colPOOutlet.Width = 130;
            // 
            // colPOOrderDate
            // 
            this.colPOOrderDate.Caption = "Order Date";
            this.colPOOrderDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colPOOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPOOrderDate.FieldName = "OrderDate";
            this.colPOOrderDate.Name = "colPOOrderDate";
            this.colPOOrderDate.OptionsColumn.AllowEdit = false;
            this.colPOOrderDate.Visible = true;
            this.colPOOrderDate.VisibleIndex = 3;
            this.colPOOrderDate.Width = 100;
            // 
            // colPOExpectedDate
            // 
            this.colPOExpectedDate.Caption = "Expected Date";
            this.colPOExpectedDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colPOExpectedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPOExpectedDate.FieldName = "ExpectedDate";
            this.colPOExpectedDate.Name = "colPOExpectedDate";
            this.colPOExpectedDate.OptionsColumn.AllowEdit = false;
            this.colPOExpectedDate.Visible = true;
            this.colPOExpectedDate.VisibleIndex = 4;
            this.colPOExpectedDate.Width = 100;
            // 
            // colPOGrandTotal
            // 
            this.colPOGrandTotal.Caption = "Grand Total";
            this.colPOGrandTotal.FieldName = "GrandTotal";
            this.colPOGrandTotal.Name = "colPOGrandTotal";
            this.colPOGrandTotal.OptionsColumn.AllowEdit = false;
            this.colPOGrandTotal.Visible = true;
            this.colPOGrandTotal.VisibleIndex = 5;
            this.colPOGrandTotal.Width = 100;
            // 
            // colPOStatus
            // 
            this.colPOStatus.Caption = "Status";
            this.colPOStatus.FieldName = "Status";
            this.colPOStatus.Name = "colPOStatus";
            this.colPOStatus.OptionsColumn.AllowEdit = false;
            this.colPOStatus.Visible = true;
            this.colPOStatus.VisibleIndex = 6;
            this.colPOStatus.Width = 110;
            // 
            // colPOReceive
            // 
            this.colPOReceive.Caption = "Receive";
            this.colPOReceive.ColumnEdit = this.btnMainReceive;
            this.colPOReceive.Name = "colPOReceive";
            this.colPOReceive.Visible = true;
            this.colPOReceive.VisibleIndex = 7;
            this.colPOReceive.Width = 60;
            // 
            // btnMainReceive
            // 
            this.btnMainReceive.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.received;
            this.btnMainReceive.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainReceive.Name = "btnMainReceive";
            this.btnMainReceive.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainReceive.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainReceive_ButtonClick);
            // 
            // colPODelete
            // 
            this.colPODelete.Caption = "Delete";
            this.colPODelete.ColumnEdit = this.btnMainDelete;
            this.colPODelete.Name = "colPODelete";
            this.colPODelete.Visible = true;
            this.colPODelete.VisibleIndex = 8;
            this.colPODelete.Width = 50;
            // 
            // btnMainDelete
            // 
            this.btnMainDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnMainDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainDelete.Name = "btnMainDelete";
            this.btnMainDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainDelete_ButtonClick);
            // 
            // colPOPrint
            // 
            this.colPOPrint.Caption = "Print";
            this.colPOPrint.ColumnEdit = this.btnMainPrint;
            this.colPOPrint.Name = "colPOPrint";
            this.colPOPrint.Visible = true;
            this.colPOPrint.VisibleIndex = 9;
            this.colPOPrint.Width = 50;
            // 
            // btnMainPrint
            // 
            this.btnMainPrint.AutoHeight = false;
            this.btnMainPrint.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.btnMainPrint.Name = "btnMainPrint";
            this.btnMainPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainPrint.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainPrint_ButtonClick);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.Control;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.panelHeaderBar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1090, 79);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSystemName.Location = new System.Drawing.Point(89, 34);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 165;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::unt_bingoo.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(89, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 164;
            this.picLogo.TabStop = false;
            // 
            // panelHeaderBar
            // 
            this.panelHeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeaderBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderBar.Location = new System.Drawing.Point(0, 60);
            this.panelHeaderBar.Name = "panelHeaderBar";
            this.panelHeaderBar.Size = new System.Drawing.Size(1090, 19);
            this.panelHeaderBar.TabIndex = 0;
            // 
            // groupEntry
            // 
            this.groupEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEntry.Controls.Add(this.lblGrandTotal);
            this.groupEntry.Controls.Add(this.lblSubTotalValue);
            this.groupEntry.Controls.Add(this.lblSubTotalCaption);
            this.groupEntry.Controls.Add(this.lblDiscountTotalCaption);
            this.groupEntry.Controls.Add(this.lblDiscountTotalValue);
            this.groupEntry.Controls.Add(this.lblTaxTotalCaption);
            this.groupEntry.Controls.Add(this.lblTaxTotalValue);
            this.groupEntry.Controls.Add(this.btnCancel);
            this.groupEntry.Controls.Add(this.btnSavePO);
            this.groupEntry.Controls.Add(this.gridLines);
            this.groupEntry.Controls.Add(this.btnAddItem);
            this.groupEntry.Controls.Add(this.txtTax);
            this.groupEntry.Controls.Add(this.lblTax);
            this.groupEntry.Controls.Add(this.txtDiscount);
            this.groupEntry.Controls.Add(this.lblDiscount);
            this.groupEntry.Controls.Add(this.txtUnitCost);
            this.groupEntry.Controls.Add(this.lblUnitCost);
            this.groupEntry.Controls.Add(this.cboUom);
            this.groupEntry.Controls.Add(this.txtQuantity);
            this.groupEntry.Controls.Add(this.lblQuantity);
            this.groupEntry.Controls.Add(this.pnlProductInfo);
            this.groupEntry.Controls.Add(this.cboProduct);
            this.groupEntry.Controls.Add(this.lblProduct);
            this.groupEntry.Controls.Add(this.txtNote);
            this.groupEntry.Controls.Add(this.lblNote);
            this.groupEntry.Controls.Add(this.dtpExpectedDate);
            this.groupEntry.Controls.Add(this.lblExpectedDate);
            this.groupEntry.Controls.Add(this.cboSupplier);
            this.groupEntry.Controls.Add(this.lblSupplier);
            this.groupEntry.Controls.Add(this.cboOutlet);
            this.groupEntry.Controls.Add(this.lblOutlet);
            this.groupEntry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupEntry.Location = new System.Drawing.Point(13, 88);
            this.groupEntry.Name = "groupEntry";
            this.groupEntry.Size = new System.Drawing.Size(1065, 486);
            this.groupEntry.TabIndex = 1;
            this.groupEntry.TabStop = false;
            this.groupEntry.Text = "Entry Purchase Order :";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblGrandTotal.Appearance.Options.UseFont = true;
            this.lblGrandTotal.Appearance.Options.UseForeColor = true;
            this.lblGrandTotal.Location = new System.Drawing.Point(520, 409);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(115, 16);
            this.lblGrandTotal.TabIndex = 20;
            this.lblGrandTotal.Text = "Grand Total : 0.00";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubTotalValue.Appearance.Options.UseFont = true;
            this.lblSubTotalValue.Location = new System.Drawing.Point(110, 411);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(25, 14);
            this.lblSubTotalValue.TabIndex = 19;
            this.lblSubTotalValue.Text = "0.00";
            // 
            // lblSubTotalCaption
            // 
            this.lblSubTotalCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalCaption.Appearance.Options.UseFont = true;
            this.lblSubTotalCaption.Location = new System.Drawing.Point(21, 411);
            this.lblSubTotalCaption.Name = "lblSubTotalCaption";
            this.lblSubTotalCaption.Size = new System.Drawing.Size(67, 14);
            this.lblSubTotalCaption.TabIndex = 18;
            this.lblSubTotalCaption.Text = "Sub Total :";
            // 
            // lblDiscountTotalCaption
            // 
            this.lblDiscountTotalCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountTotalCaption.Appearance.Options.UseFont = true;
            this.lblDiscountTotalCaption.Location = new System.Drawing.Point(190, 411);
            this.lblDiscountTotalCaption.Name = "lblDiscountTotalCaption";
            this.lblDiscountTotalCaption.Size = new System.Drawing.Size(62, 14);
            this.lblDiscountTotalCaption.TabIndex = 23;
            this.lblDiscountTotalCaption.Text = "Discount :";
            // 
            // lblDiscountTotalValue
            // 
            this.lblDiscountTotalValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDiscountTotalValue.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDiscountTotalValue.Appearance.Options.UseFont = true;
            this.lblDiscountTotalValue.Appearance.Options.UseForeColor = true;
            this.lblDiscountTotalValue.Location = new System.Drawing.Point(265, 411);
            this.lblDiscountTotalValue.Name = "lblDiscountTotalValue";
            this.lblDiscountTotalValue.Size = new System.Drawing.Size(25, 14);
            this.lblDiscountTotalValue.TabIndex = 24;
            this.lblDiscountTotalValue.Text = "0.00";
            // 
            // lblTaxTotalCaption
            // 
            this.lblTaxTotalCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTaxTotalCaption.Appearance.Options.UseFont = true;
            this.lblTaxTotalCaption.Location = new System.Drawing.Point(360, 411);
            this.lblTaxTotalCaption.Name = "lblTaxTotalCaption";
            this.lblTaxTotalCaption.Size = new System.Drawing.Size(29, 14);
            this.lblTaxTotalCaption.TabIndex = 25;
            this.lblTaxTotalCaption.Text = "Tax :";
            // 
            // lblTaxTotalValue
            // 
            this.lblTaxTotalValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTaxTotalValue.Appearance.Options.UseFont = true;
            this.lblTaxTotalValue.Location = new System.Drawing.Point(405, 411);
            this.lblTaxTotalValue.Name = "lblTaxTotalValue";
            this.lblTaxTotalValue.Size = new System.Drawing.Size(25, 14);
            this.lblTaxTotalValue.TabIndex = 26;
            this.lblTaxTotalValue.Text = "0.00";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(955, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSavePO
            // 
            this.btnSavePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePO.Location = new System.Drawing.Point(864, 444);
            this.btnSavePO.Name = "btnSavePO";
            this.btnSavePO.Size = new System.Drawing.Size(85, 28);
            this.btnSavePO.TabIndex = 21;
            this.btnSavePO.Text = "Save PO";
            this.btnSavePO.UseVisualStyleBackColor = true;
            // 
            // gridLines
            // 
            this.gridLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLines.Location = new System.Drawing.Point(21, 186);
            this.gridLines.MainView = this.gvLines;
            this.gridLines.Name = "gridLines";
            this.gridLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRemoveLine});
            this.gridLines.Size = new System.Drawing.Size(1019, 210);
            this.gridLines.TabIndex = 17;
            this.gridLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLines});
            // 
            // gvLines
            // 
            this.gvLines.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.gvLines.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvLines.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gvLines.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineCode,
            this.colLineProduct,
            this.colLineQty,
            this.colLineUom,
            this.colLineStock,
            this.colLineUnitCost,
            this.colLineDiscount,
            this.colLineTax,
            this.colLineTotal,
            this.colLineRemove});
            this.gvLines.GridControl = this.gridLines;
            this.gvLines.Name = "gvLines";
            this.gvLines.OptionsView.EnableAppearanceEvenRow = true;
            this.gvLines.OptionsView.ShowFooter = true;
            this.gvLines.OptionsView.ShowGroupPanel = false;
            // 
            // colLineCode
            // 
            this.colLineCode.Caption = "Code";
            this.colLineCode.FieldName = "ProNumY";
            this.colLineCode.Name = "colLineCode";
            this.colLineCode.OptionsColumn.AllowEdit = false;
            this.colLineCode.Visible = true;
            this.colLineCode.VisibleIndex = 0;
            this.colLineCode.Width = 130;
            // 
            // colLineProduct
            // 
            this.colLineProduct.Caption = "Product";
            this.colLineProduct.FieldName = "ProductName";
            this.colLineProduct.Name = "colLineProduct";
            this.colLineProduct.OptionsColumn.AllowEdit = false;
            this.colLineProduct.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductName", "{0} item(s)")});
            this.colLineProduct.Visible = true;
            this.colLineProduct.VisibleIndex = 1;
            this.colLineProduct.Width = 250;
            // 
            // colLineQty
            // 
            this.colLineQty.AppearanceCell.Options.UseTextOptions = true;
            this.colLineQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLineQty.Caption = "Qty";
            this.colLineQty.FieldName = "Quantity";
            this.colLineQty.Name = "colLineQty";
            this.colLineQty.OptionsColumn.AllowEdit = false;
            this.colLineQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:N0}")});
            this.colLineQty.Visible = true;
            this.colLineQty.VisibleIndex = 2;
            this.colLineQty.Width = 70;
            // 
            // colLineUom
            // 
            this.colLineUom.Caption = "UOM";
            this.colLineUom.FieldName = "UOMCode";
            this.colLineUom.Name = "colLineUom";
            this.colLineUom.OptionsColumn.AllowEdit = false;
            this.colLineUom.Visible = true;
            this.colLineUom.VisibleIndex = 3;
            this.colLineUom.Width = 60;
            // 
            // colLineStock
            // 
            this.colLineStock.AppearanceCell.ForeColor = System.Drawing.Color.SeaGreen;
            this.colLineStock.AppearanceCell.Options.UseForeColor = true;
            this.colLineStock.Caption = "Stock Effect";
            this.colLineStock.FieldName = "StockEffect";
            this.colLineStock.Name = "colLineStock";
            this.colLineStock.OptionsColumn.AllowEdit = false;
            this.colLineStock.Visible = true;
            this.colLineStock.VisibleIndex = 4;
            this.colLineStock.Width = 110;
            // 
            // colLineUnitCost
            // 
            this.colLineUnitCost.AppearanceCell.Options.UseTextOptions = true;
            this.colLineUnitCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLineUnitCost.Caption = "Unit Cost";
            this.colLineUnitCost.DisplayFormat.FormatString = "N2";
            this.colLineUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLineUnitCost.FieldName = "UnitCost";
            this.colLineUnitCost.Name = "colLineUnitCost";
            this.colLineUnitCost.OptionsColumn.AllowEdit = false;
            this.colLineUnitCost.Visible = true;
            this.colLineUnitCost.VisibleIndex = 5;
            this.colLineUnitCost.Width = 90;
            // 
            // colLineDiscount
            // 
            this.colLineDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.colLineDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLineDiscount.Caption = "Discount %";
            this.colLineDiscount.DisplayFormat.FormatString = "N2";
            this.colLineDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLineDiscount.FieldName = "DiscountPercent";
            this.colLineDiscount.Name = "colLineDiscount";
            this.colLineDiscount.OptionsColumn.AllowEdit = false;
            this.colLineDiscount.Visible = true;
            this.colLineDiscount.VisibleIndex = 6;
            this.colLineDiscount.Width = 80;
            // 
            // colLineTax
            // 
            this.colLineTax.AppearanceCell.Options.UseTextOptions = true;
            this.colLineTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLineTax.Caption = "Tax %";
            this.colLineTax.DisplayFormat.FormatString = "N2";
            this.colLineTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLineTax.FieldName = "TaxPercent";
            this.colLineTax.Name = "colLineTax";
            this.colLineTax.OptionsColumn.AllowEdit = false;
            this.colLineTax.Visible = true;
            this.colLineTax.VisibleIndex = 7;
            this.colLineTax.Width = 70;
            // 
            // colLineTotal
            // 
            this.colLineTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colLineTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLineTotal.Caption = "Line Total";
            this.colLineTotal.DisplayFormat.FormatString = "N2";
            this.colLineTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLineTotal.FieldName = "TotalCost";
            this.colLineTotal.Name = "colLineTotal";
            this.colLineTotal.OptionsColumn.AllowEdit = false;
            this.colLineTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "{0:N2}")});
            this.colLineTotal.Visible = true;
            this.colLineTotal.VisibleIndex = 8;
            this.colLineTotal.Width = 110;
            // 
            // colLineRemove
            // 
            this.colLineRemove.Caption = "Remove";
            this.colLineRemove.ColumnEdit = this.btnRemoveLine;
            this.colLineRemove.Name = "colLineRemove";
            this.colLineRemove.Visible = true;
            this.colLineRemove.VisibleIndex = 9;
            this.colLineRemove.Width = 70;
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.AutoHeight = false;
            editorButtonImageOptions3.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnRemoveLine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRemoveLine.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRemoveLine_ButtonClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(950, 91);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 25);
            this.btnAddItem.TabIndex = 16;
            this.btnAddItem.Text = "Add Line";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(830, 91);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(90, 22);
            this.txtTax.TabIndex = 15;
            this.txtTax.Text = "0";
            // 
            // lblTax
            // 
            this.lblTax.Location = new System.Drawing.Point(730, 94);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(39, 13);
            this.lblTax.TabIndex = 14;
            this.lblTax.Text = "Tax % :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(620, 91);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(90, 22);
            this.txtDiscount.TabIndex = 13;
            this.txtDiscount.Text = "0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Location = new System.Drawing.Point(520, 94);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(62, 13);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Discount % :";
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.Location = new System.Drawing.Point(950, 58);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(90, 22);
            this.txtUnitCost.TabIndex = 11;
            this.txtUnitCost.Text = "0";
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.Location = new System.Drawing.Point(830, 62);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(51, 13);
            this.lblUnitCost.TabIndex = 10;
            this.lblUnitCost.Text = "Unit Cost :";
            // 
            // cboUom
            // 
            this.cboUom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUom.FormattingEnabled = true;
            this.cboUom.Location = new System.Drawing.Point(682, 59);
            this.cboUom.Name = "cboUom";
            this.cboUom.Size = new System.Drawing.Size(138, 22);
            this.cboUom.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(620, 59);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(56, 22);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.Text = "1";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(520, 62);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity :";
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductInfo.Controls.Add(this.lblInfoCode);
            this.pnlProductInfo.Controls.Add(this.lblInfoCodeValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoUnit);
            this.pnlProductInfo.Controls.Add(this.lblInfoUnitValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoCategory);
            this.pnlProductInfo.Controls.Add(this.lblInfoCategoryValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoSupplier);
            this.pnlProductInfo.Controls.Add(this.lblInfoSupplierValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoOnHand);
            this.pnlProductInfo.Controls.Add(this.lblInfoOnHandValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoReorder);
            this.pnlProductInfo.Controls.Add(this.lblInfoReorderValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoLastCost);
            this.pnlProductInfo.Controls.Add(this.lblInfoLastCostValue);
            this.pnlProductInfo.Controls.Add(this.lblInfoVat);
            this.pnlProductInfo.Controls.Add(this.lblInfoVatValue);
            this.pnlProductInfo.Location = new System.Drawing.Point(21, 122);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(1019, 48);
            this.pnlProductInfo.TabIndex = 27;
            // 
            // lblInfoCode
            // 
            this.lblInfoCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoCode.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoCode.Appearance.Options.UseFont = true;
            this.lblInfoCode.Appearance.Options.UseForeColor = true;
            this.lblInfoCode.Location = new System.Drawing.Point(10, 8);
            this.lblInfoCode.Name = "lblInfoCode";
            this.lblInfoCode.Size = new System.Drawing.Size(34, 13);
            this.lblInfoCode.TabIndex = 0;
            this.lblInfoCode.Text = "Code :";
            // 
            // lblInfoCodeValue
            // 
            this.lblInfoCodeValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoCodeValue.Appearance.Options.UseFont = true;
            this.lblInfoCodeValue.Appearance.Options.UseForeColor = true;
            this.lblInfoCodeValue.Location = new System.Drawing.Point(90, 8);
            this.lblInfoCodeValue.Name = "lblInfoCodeValue";
            this.lblInfoCodeValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoCodeValue.TabIndex = 1;
            this.lblInfoCodeValue.Text = "-";
            // 
            // lblInfoUnit
            // 
            this.lblInfoUnit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoUnit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoUnit.Appearance.Options.UseFont = true;
            this.lblInfoUnit.Appearance.Options.UseForeColor = true;
            this.lblInfoUnit.Location = new System.Drawing.Point(265, 8);
            this.lblInfoUnit.Name = "lblInfoUnit";
            this.lblInfoUnit.Size = new System.Drawing.Size(29, 13);
            this.lblInfoUnit.TabIndex = 2;
            this.lblInfoUnit.Text = "Unit :";
            // 
            // lblInfoUnitValue
            // 
            this.lblInfoUnitValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoUnitValue.Appearance.Options.UseFont = true;
            this.lblInfoUnitValue.Appearance.Options.UseForeColor = true;
            this.lblInfoUnitValue.Location = new System.Drawing.Point(345, 8);
            this.lblInfoUnitValue.Name = "lblInfoUnitValue";
            this.lblInfoUnitValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoUnitValue.TabIndex = 3;
            this.lblInfoUnitValue.Text = "-";
            // 
            // lblInfoCategory
            // 
            this.lblInfoCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoCategory.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoCategory.Appearance.Options.UseFont = true;
            this.lblInfoCategory.Appearance.Options.UseForeColor = true;
            this.lblInfoCategory.Location = new System.Drawing.Point(520, 8);
            this.lblInfoCategory.Name = "lblInfoCategory";
            this.lblInfoCategory.Size = new System.Drawing.Size(58, 13);
            this.lblInfoCategory.TabIndex = 4;
            this.lblInfoCategory.Text = "Category :";
            // 
            // lblInfoCategoryValue
            // 
            this.lblInfoCategoryValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoCategoryValue.Appearance.Options.UseFont = true;
            this.lblInfoCategoryValue.Appearance.Options.UseForeColor = true;
            this.lblInfoCategoryValue.Location = new System.Drawing.Point(600, 8);
            this.lblInfoCategoryValue.Name = "lblInfoCategoryValue";
            this.lblInfoCategoryValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoCategoryValue.TabIndex = 5;
            this.lblInfoCategoryValue.Text = "-";
            // 
            // lblInfoSupplier
            // 
            this.lblInfoSupplier.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoSupplier.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoSupplier.Appearance.Options.UseFont = true;
            this.lblInfoSupplier.Appearance.Options.UseForeColor = true;
            this.lblInfoSupplier.Location = new System.Drawing.Point(770, 8);
            this.lblInfoSupplier.Name = "lblInfoSupplier";
            this.lblInfoSupplier.Size = new System.Drawing.Size(52, 13);
            this.lblInfoSupplier.TabIndex = 6;
            this.lblInfoSupplier.Text = "Supplier :";
            // 
            // lblInfoSupplierValue
            // 
            this.lblInfoSupplierValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoSupplierValue.Appearance.Options.UseFont = true;
            this.lblInfoSupplierValue.Appearance.Options.UseForeColor = true;
            this.lblInfoSupplierValue.Location = new System.Drawing.Point(850, 8);
            this.lblInfoSupplierValue.Name = "lblInfoSupplierValue";
            this.lblInfoSupplierValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoSupplierValue.TabIndex = 7;
            this.lblInfoSupplierValue.Text = "-";
            // 
            // lblInfoOnHand
            // 
            this.lblInfoOnHand.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoOnHand.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoOnHand.Appearance.Options.UseFont = true;
            this.lblInfoOnHand.Appearance.Options.UseForeColor = true;
            this.lblInfoOnHand.Location = new System.Drawing.Point(10, 27);
            this.lblInfoOnHand.Name = "lblInfoOnHand";
            this.lblInfoOnHand.Size = new System.Drawing.Size(53, 13);
            this.lblInfoOnHand.TabIndex = 8;
            this.lblInfoOnHand.Text = "On Hand :";
            // 
            // lblInfoOnHandValue
            // 
            this.lblInfoOnHandValue.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoOnHandValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoOnHandValue.Appearance.Options.UseFont = true;
            this.lblInfoOnHandValue.Appearance.Options.UseForeColor = true;
            this.lblInfoOnHandValue.Location = new System.Drawing.Point(90, 27);
            this.lblInfoOnHandValue.Name = "lblInfoOnHandValue";
            this.lblInfoOnHandValue.Size = new System.Drawing.Size(5, 13);
            this.lblInfoOnHandValue.TabIndex = 9;
            this.lblInfoOnHandValue.Text = "-";
            // 
            // lblInfoReorder
            // 
            this.lblInfoReorder.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoReorder.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoReorder.Appearance.Options.UseFont = true;
            this.lblInfoReorder.Appearance.Options.UseForeColor = true;
            this.lblInfoReorder.Location = new System.Drawing.Point(265, 27);
            this.lblInfoReorder.Name = "lblInfoReorder";
            this.lblInfoReorder.Size = new System.Drawing.Size(68, 13);
            this.lblInfoReorder.TabIndex = 10;
            this.lblInfoReorder.Text = "Reorder At :";
            // 
            // lblInfoReorderValue
            // 
            this.lblInfoReorderValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoReorderValue.Appearance.Options.UseFont = true;
            this.lblInfoReorderValue.Appearance.Options.UseForeColor = true;
            this.lblInfoReorderValue.Location = new System.Drawing.Point(345, 27);
            this.lblInfoReorderValue.Name = "lblInfoReorderValue";
            this.lblInfoReorderValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoReorderValue.TabIndex = 11;
            this.lblInfoReorderValue.Text = "-";
            // 
            // lblInfoLastCost
            // 
            this.lblInfoLastCost.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoLastCost.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoLastCost.Appearance.Options.UseFont = true;
            this.lblInfoLastCost.Appearance.Options.UseForeColor = true;
            this.lblInfoLastCost.Location = new System.Drawing.Point(520, 27);
            this.lblInfoLastCost.Name = "lblInfoLastCost";
            this.lblInfoLastCost.Size = new System.Drawing.Size(58, 13);
            this.lblInfoLastCost.TabIndex = 12;
            this.lblInfoLastCost.Text = "Buy Price :";
            // 
            // lblInfoLastCostValue
            // 
            this.lblInfoLastCostValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoLastCostValue.Appearance.Options.UseFont = true;
            this.lblInfoLastCostValue.Appearance.Options.UseForeColor = true;
            this.lblInfoLastCostValue.Location = new System.Drawing.Point(600, 27);
            this.lblInfoLastCostValue.Name = "lblInfoLastCostValue";
            this.lblInfoLastCostValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoLastCostValue.TabIndex = 13;
            this.lblInfoLastCostValue.Text = "-";
            // 
            // lblInfoVat
            // 
            this.lblInfoVat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfoVat.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(130)))));
            this.lblInfoVat.Appearance.Options.UseFont = true;
            this.lblInfoVat.Appearance.Options.UseForeColor = true;
            this.lblInfoVat.Location = new System.Drawing.Point(770, 27);
            this.lblInfoVat.Name = "lblInfoVat";
            this.lblInfoVat.Size = new System.Drawing.Size(28, 13);
            this.lblInfoVat.TabIndex = 14;
            this.lblInfoVat.Text = "VAT :";
            // 
            // lblInfoVatValue
            // 
            this.lblInfoVatValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblInfoVatValue.Appearance.Options.UseFont = true;
            this.lblInfoVatValue.Appearance.Options.UseForeColor = true;
            this.lblInfoVatValue.Location = new System.Drawing.Point(850, 27);
            this.lblInfoVatValue.Name = "lblInfoVatValue";
            this.lblInfoVatValue.Size = new System.Drawing.Size(4, 13);
            this.lblInfoVatValue.TabIndex = 15;
            this.lblInfoVatValue.Text = "-";
            // 
            // cboProduct
            // 
            this.cboProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(620, 27);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(420, 22);
            this.cboProduct.TabIndex = 7;
            // 
            // lblProduct
            // 
            this.lblProduct.Location = new System.Drawing.Point(520, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 6;
            this.lblProduct.Text = "Product :";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(167, 91);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(300, 22);
            this.txtNote.TabIndex = 5;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(21, 94);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(30, 13);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Note :";
            // 
            // dtpExpectedDate
            // 
            this.dtpExpectedDate.CustomFormat = "dd-MM-yyyy";
            this.dtpExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedDate.Location = new System.Drawing.Point(167, 59);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            this.dtpExpectedDate.Size = new System.Drawing.Size(150, 22);
            this.dtpExpectedDate.TabIndex = 3;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.Location = new System.Drawing.Point(21, 62);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(78, 13);
            this.lblExpectedDate.TabIndex = 2;
            this.lblExpectedDate.Text = "Expected Date :";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(167, 27);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(300, 22);
            this.cboSupplier.TabIndex = 1;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(21, 30);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(45, 13);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier :";
            // 
            // cboOutlet
            // 
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Enabled = false;
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(410, 59);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(100, 22);
            this.cboOutlet.TabIndex = 23;
            // 
            // lblOutlet
            // 
            this.lblOutlet.Location = new System.Drawing.Point(335, 62);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(62, 13);
            this.lblOutlet.TabIndex = 24;
            this.lblOutlet.Text = "Warehouse :";
            // 
            // panelToolbar
            // 
            this.panelToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbar.Controls.Add(this.lblSearch);
            this.panelToolbar.Controls.Add(this.txtSearch);
            this.panelToolbar.Controls.Add(this.btnRefresh);
            this.panelToolbar.Controls.Add(this.btnExport);
            this.panelToolbar.Location = new System.Drawing.Point(13, 580);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1065, 34);
            this.panelToolbar.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(4, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(52, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(879, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 25);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(970, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 25);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // guiPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 880);
            this.Controls.Add(this.gridPO);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.groupEntry);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE ORDER MANAGEMENT";
            ((System.ComponentModel.ISupportInitialize)(this.gvPODetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainPrint)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupEntry.ResumeLayout(false);
            this.groupEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveLine)).EndInit();
            this.pnlProductInfo.ResumeLayout(false);
            this.pnlProductInfo.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelHeaderBar;
        private System.Windows.Forms.GroupBox groupEntry;
        private DevExpress.XtraEditors.LabelControl lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplier;
        private DevExpress.XtraEditors.LabelControl lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private DevExpress.XtraEditors.LabelControl lblExpectedDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedDate;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Panel pnlProductInfo;
        private DevExpress.XtraEditors.LabelControl lblInfoCode;
        private DevExpress.XtraEditors.LabelControl lblInfoCodeValue;
        private DevExpress.XtraEditors.LabelControl lblInfoUnit;
        private DevExpress.XtraEditors.LabelControl lblInfoUnitValue;
        private DevExpress.XtraEditors.LabelControl lblInfoCategory;
        private DevExpress.XtraEditors.LabelControl lblInfoCategoryValue;
        private DevExpress.XtraEditors.LabelControl lblInfoSupplier;
        private DevExpress.XtraEditors.LabelControl lblInfoSupplierValue;
        private DevExpress.XtraEditors.LabelControl lblInfoOnHand;
        private DevExpress.XtraEditors.LabelControl lblInfoOnHandValue;
        private DevExpress.XtraEditors.LabelControl lblInfoReorder;
        private DevExpress.XtraEditors.LabelControl lblInfoReorderValue;
        private DevExpress.XtraEditors.LabelControl lblInfoLastCost;
        private DevExpress.XtraEditors.LabelControl lblInfoLastCostValue;
        private DevExpress.XtraEditors.LabelControl lblInfoVat;
        private DevExpress.XtraEditors.LabelControl lblInfoVatValue;
        private DevExpress.XtraEditors.LabelControl lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cboUom;
        private DevExpress.XtraEditors.LabelControl lblUnitCost;
        private System.Windows.Forms.TextBox txtUnitCost;
        private DevExpress.XtraEditors.LabelControl lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private DevExpress.XtraEditors.LabelControl lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Button btnAddItem;
        private DevExpress.XtraGrid.GridControl gridLines;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLines;
        private DevExpress.XtraGrid.Columns.GridColumn colLineCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLineProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colLineQty;
        private DevExpress.XtraGrid.Columns.GridColumn colLineUom;
        private DevExpress.XtraGrid.Columns.GridColumn colLineStock;
        private DevExpress.XtraGrid.Columns.GridColumn colLineUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colLineTax;
        private DevExpress.XtraGrid.Columns.GridColumn colLineTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colLineRemove;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRemoveLine;
        private DevExpress.XtraEditors.LabelControl lblSubTotalCaption;
        private DevExpress.XtraEditors.LabelControl lblSubTotalValue;
        private DevExpress.XtraEditors.LabelControl lblDiscountTotalCaption;
        private DevExpress.XtraEditors.LabelControl lblDiscountTotalValue;
        private DevExpress.XtraEditors.LabelControl lblTaxTotalCaption;
        private DevExpress.XtraEditors.LabelControl lblTaxTotalValue;
        private DevExpress.XtraEditors.LabelControl lblGrandTotal;
        private System.Windows.Forms.Button btnSavePO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelToolbar;
        private DevExpress.XtraEditors.LabelControl lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private DevExpress.XtraGrid.GridControl gridPO;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPO;
        private DevExpress.XtraGrid.Columns.GridColumn colPONo;
        private DevExpress.XtraGrid.Columns.GridColumn colPOSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colPOOutlet;
        private DevExpress.XtraGrid.Columns.GridColumn colPOOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPOExpectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPOGrandTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPOStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPOReceive;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainReceive;
        private DevExpress.XtraGrid.Columns.GridColumn colPODelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colPOPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainPrint;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPODetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailUom;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailTax;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailRemaining;
    }
}
