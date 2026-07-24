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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelHeaderBar = new System.Windows.Forms.Panel();
            this.groupEntry = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotalCaption = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSavePO = new System.Windows.Forms.Button();
            this.gridLines = new DevExpress.XtraGrid.GridControl();
            this.gvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineQty = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new DevExpress.XtraEditors.LabelControl();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedDate = new DevExpress.XtraEditors.LabelControl();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gridPO = new DevExpress.XtraGrid.GridControl();
            this.gvPO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOExpectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOGrandTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPOReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainReceive = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPODelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveLine)).BeginInit();
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).BeginInit();
            this.SuspendLayout();
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
            this.groupEntry.Controls.Add(this.lblGrandTotal);
            this.groupEntry.Controls.Add(this.lblSubTotalValue);
            this.groupEntry.Controls.Add(this.lblSubTotalCaption);
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
            this.groupEntry.Controls.Add(this.txtQuantity);
            this.groupEntry.Controls.Add(this.lblQuantity);
            this.groupEntry.Controls.Add(this.cboProduct);
            this.groupEntry.Controls.Add(this.lblProduct);
            this.groupEntry.Controls.Add(this.txtNote);
            this.groupEntry.Controls.Add(this.lblNote);
            this.groupEntry.Controls.Add(this.dtpExpectedDate);
            this.groupEntry.Controls.Add(this.lblExpectedDate);
            this.groupEntry.Controls.Add(this.cboSupplier);
            this.groupEntry.Controls.Add(this.lblSupplier);
            this.groupEntry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupEntry.Location = new System.Drawing.Point(13, 88);
            this.groupEntry.Name = "groupEntry";
            this.groupEntry.Size = new System.Drawing.Size(1065, 430);
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
            this.lblGrandTotal.Location = new System.Drawing.Point(260, 353);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(115, 16);
            this.lblGrandTotal.TabIndex = 20;
            this.lblGrandTotal.Text = "Grand Total : 0.00";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubTotalValue.Appearance.Options.UseFont = true;
            this.lblSubTotalValue.Location = new System.Drawing.Point(120, 355);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(25, 14);
            this.lblSubTotalValue.TabIndex = 19;
            this.lblSubTotalValue.Text = "0.00";
            // 
            // lblSubTotalCaption
            // 
            this.lblSubTotalCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalCaption.Appearance.Options.UseFont = true;
            this.lblSubTotalCaption.Location = new System.Drawing.Point(21, 355);
            this.lblSubTotalCaption.Name = "lblSubTotalCaption";
            this.lblSubTotalCaption.Size = new System.Drawing.Size(67, 14);
            this.lblSubTotalCaption.TabIndex = 18;
            this.lblSubTotalCaption.Text = "Sub Total :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(955, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSavePO
            // 
            this.btnSavePO.Location = new System.Drawing.Point(864, 388);
            this.btnSavePO.Name = "btnSavePO";
            this.btnSavePO.Size = new System.Drawing.Size(85, 28);
            this.btnSavePO.TabIndex = 21;
            this.btnSavePO.Text = "Save PO";
            this.btnSavePO.UseVisualStyleBackColor = true;
            // 
            // gridLines
            // 
            this.gridLines.Location = new System.Drawing.Point(21, 130);
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
            this.gvLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineProduct,
            this.colLineQty,
            this.colLineUnitCost,
            this.colLineDiscount,
            this.colLineTax,
            this.colLineTotal,
            this.colLineRemove});
            this.gvLines.GridControl = this.gridLines;
            this.gvLines.Name = "gvLines";
            this.gvLines.OptionsView.ShowGroupPanel = false;
            // 
            // colLineProduct
            // 
            this.colLineProduct.Caption = "Product";
            this.colLineProduct.FieldName = "ProductName";
            this.colLineProduct.Name = "colLineProduct";
            this.colLineProduct.OptionsColumn.AllowEdit = false;
            this.colLineProduct.Visible = true;
            this.colLineProduct.VisibleIndex = 0;
            this.colLineProduct.Width = 300;
            // 
            // colLineQty
            // 
            this.colLineQty.Caption = "Qty";
            this.colLineQty.FieldName = "Quantity";
            this.colLineQty.Name = "colLineQty";
            this.colLineQty.OptionsColumn.AllowEdit = false;
            this.colLineQty.Visible = true;
            this.colLineQty.VisibleIndex = 1;
            this.colLineQty.Width = 80;
            // 
            // colLineUnitCost
            // 
            this.colLineUnitCost.Caption = "Unit Cost";
            this.colLineUnitCost.FieldName = "UnitCost";
            this.colLineUnitCost.Name = "colLineUnitCost";
            this.colLineUnitCost.OptionsColumn.AllowEdit = false;
            this.colLineUnitCost.Visible = true;
            this.colLineUnitCost.VisibleIndex = 2;
            this.colLineUnitCost.Width = 100;
            // 
            // colLineDiscount
            // 
            this.colLineDiscount.Caption = "Discount %";
            this.colLineDiscount.FieldName = "DiscountPercent";
            this.colLineDiscount.Name = "colLineDiscount";
            this.colLineDiscount.OptionsColumn.AllowEdit = false;
            this.colLineDiscount.Visible = true;
            this.colLineDiscount.VisibleIndex = 3;
            this.colLineDiscount.Width = 90;
            // 
            // colLineTax
            // 
            this.colLineTax.Caption = "Tax %";
            this.colLineTax.FieldName = "TaxPercent";
            this.colLineTax.Name = "colLineTax";
            this.colLineTax.OptionsColumn.AllowEdit = false;
            this.colLineTax.Visible = true;
            this.colLineTax.VisibleIndex = 4;
            this.colLineTax.Width = 80;
            // 
            // colLineTotal
            // 
            this.colLineTotal.Caption = "Line Total";
            this.colLineTotal.FieldName = "TotalCost";
            this.colLineTotal.Name = "colLineTotal";
            this.colLineTotal.OptionsColumn.AllowEdit = false;
            this.colLineTotal.Visible = true;
            this.colLineTotal.VisibleIndex = 5;
            this.colLineTotal.Width = 110;
            // 
            // colLineRemove
            // 
            this.colLineRemove.Caption = "Remove";
            this.colLineRemove.ColumnEdit = this.btnRemoveLine;
            this.colLineRemove.Name = "colLineRemove";
            this.colLineRemove.Visible = true;
            this.colLineRemove.VisibleIndex = 6;
            this.colLineRemove.Width = 70;
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnRemoveLine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRemoveLine.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRemoveLine_ButtonClick);
            // 
            // btnAddItem
            // 
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
            this.txtUnitCost.Location = new System.Drawing.Point(830, 59);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(90, 22);
            this.txtUnitCost.TabIndex = 11;
            this.txtUnitCost.Text = "0";
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.Location = new System.Drawing.Point(730, 62);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(51, 13);
            this.lblUnitCost.TabIndex = 10;
            this.lblUnitCost.Text = "Unit Cost :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(620, 59);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(90, 22);
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
            // cboProduct
            // 
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
            // panelToolbar
            // 
            this.panelToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbar.Controls.Add(this.lblSearch);
            this.panelToolbar.Controls.Add(this.txtSearch);
            this.panelToolbar.Controls.Add(this.btnRefresh);
            this.panelToolbar.Controls.Add(this.btnExport);
            this.panelToolbar.Location = new System.Drawing.Point(13, 524);
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
            // gridPO
            // 
            this.gridPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPO.Location = new System.Drawing.Point(13, 564);
            this.gridPO.MainView = this.gvPO;
            this.gridPO.Name = "gridPO";
            this.gridPO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnMainView,
            this.btnMainReceive,
            this.btnMainDelete});
            this.gridPO.Size = new System.Drawing.Size(1065, 300);
            this.gridPO.TabIndex = 3;
            this.gridPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPO});
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
            this.colPOOrderDate,
            this.colPOExpectedDate,
            this.colPOGrandTotal,
            this.colPOStatus,
            this.colPOView,
            this.colPOReceive,
            this.colPODelete});
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
            // colPOOrderDate
            // 
            this.colPOOrderDate.Caption = "Order Date";
            this.colPOOrderDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colPOOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPOOrderDate.FieldName = "OrderDate";
            this.colPOOrderDate.Name = "colPOOrderDate";
            this.colPOOrderDate.OptionsColumn.AllowEdit = false;
            this.colPOOrderDate.Visible = true;
            this.colPOOrderDate.VisibleIndex = 2;
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
            this.colPOExpectedDate.VisibleIndex = 3;
            this.colPOExpectedDate.Width = 100;
            // 
            // colPOGrandTotal
            // 
            this.colPOGrandTotal.Caption = "Grand Total";
            this.colPOGrandTotal.FieldName = "GrandTotal";
            this.colPOGrandTotal.Name = "colPOGrandTotal";
            this.colPOGrandTotal.OptionsColumn.AllowEdit = false;
            this.colPOGrandTotal.Visible = true;
            this.colPOGrandTotal.VisibleIndex = 4;
            this.colPOGrandTotal.Width = 100;
            // 
            // colPOStatus
            // 
            this.colPOStatus.Caption = "Status";
            this.colPOStatus.FieldName = "Status";
            this.colPOStatus.Name = "colPOStatus";
            this.colPOStatus.OptionsColumn.AllowEdit = false;
            this.colPOStatus.Visible = true;
            this.colPOStatus.VisibleIndex = 5;
            this.colPOStatus.Width = 110;
            // 
            // colPOView
            // 
            this.colPOView.Caption = "View";
            this.colPOView.ColumnEdit = this.btnMainView;
            this.colPOView.Name = "colPOView";
            this.colPOView.Visible = true;
            this.colPOView.VisibleIndex = 6;
            this.colPOView.Width = 50;
            // 
            // btnMainView
            // 
            this.btnMainView.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnMainView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainView.Name = "btnMainView";
            this.btnMainView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainView.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainView_ButtonClick);
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
            editorButtonImageOptions3.Image = global::unt_bingoo.Properties.Resources.received;
            this.btnMainReceive.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
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
            editorButtonImageOptions4.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnMainDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainDelete.Name = "btnMainDelete";
            this.btnMainDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainDelete_ButtonClick);
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
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupEntry.ResumeLayout(false);
            this.groupEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveLine)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblExpectedDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedDate;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private DevExpress.XtraEditors.LabelControl lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private DevExpress.XtraEditors.LabelControl lblUnitCost;
        private System.Windows.Forms.TextBox txtUnitCost;
        private DevExpress.XtraEditors.LabelControl lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private DevExpress.XtraEditors.LabelControl lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Button btnAddItem;
        private DevExpress.XtraGrid.GridControl gridLines;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLines;
        private DevExpress.XtraGrid.Columns.GridColumn colLineProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colLineQty;
        private DevExpress.XtraGrid.Columns.GridColumn colLineUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colLineTax;
        private DevExpress.XtraGrid.Columns.GridColumn colLineTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colLineRemove;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRemoveLine;
        private DevExpress.XtraEditors.LabelControl lblSubTotalCaption;
        private DevExpress.XtraEditors.LabelControl lblSubTotalValue;
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
        private DevExpress.XtraGrid.Columns.GridColumn colPOOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPOExpectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPOGrandTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colPOStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPOView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainView;
        private DevExpress.XtraGrid.Columns.GridColumn colPOReceive;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainReceive;
        private DevExpress.XtraGrid.Columns.GridColumn colPODelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainDelete;
    }
}
