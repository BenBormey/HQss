namespace unt_bingoo.view.Outlet
{
    partial class guiFranchisePriceList
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private System.Windows.Forms.Panel pnlHeaderText;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblScreenName;

        // Input card
        private DevExpress.XtraEditors.PanelControl pnlInput;
        private DevExpress.XtraEditors.LabelControl lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private DevExpress.XtraEditors.LabelControl lblUnit;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraEditors.LabelControl lblCostPrice;
        private DevExpress.XtraEditors.TextEdit txtCostPrice;
        private DevExpress.XtraEditors.LabelControl lblUnitPrice;
        private DevExpress.XtraEditors.TextEdit txtUnitPrice;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClear;

        // Grid
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl grdPrice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOutletName;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colProUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riDelete;

        // Footer
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.LabelControl lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.pnlHeaderText = new System.Windows.Forms.Panel();
            this.lblHeaderHint = new DevExpress.XtraEditors.LabelControl();
            this.lblScreenName = new DevExpress.XtraEditors.LabelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.pnlInput = new DevExpress.XtraEditors.PanelControl();
            this.lblOutlet = new DevExpress.XtraEditors.LabelControl();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblUnit = new DevExpress.XtraEditors.LabelControl();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.lblCostPrice = new DevExpress.XtraEditors.LabelControl();
            this.txtCostPrice = new DevExpress.XtraEditors.TextEdit();
            this.lblUnitPrice = new DevExpress.XtraEditors.LabelControl();
            this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.grdPrice = new DevExpress.XtraGrid.GridControl();
            this.gvPrice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOutletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.pnlHeaderText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).BeginInit();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.pnlHeaderText);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(820, 92);
            this.panelHeader.TabIndex = 3;
            // 
            // pnlHeaderText
            // 
            this.pnlHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderText.Controls.Add(this.lblHeaderHint);
            this.pnlHeaderText.Controls.Add(this.lblScreenName);
            this.pnlHeaderText.Controls.Add(this.lblSystemName);
            this.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderText.Location = new System.Drawing.Point(98, 0);
            this.pnlHeaderText.Name = "pnlHeaderText";
            this.pnlHeaderText.Size = new System.Drawing.Size(722, 92);
            this.pnlHeaderText.TabIndex = 185;
            // 
            // lblHeaderHint
            // 
            this.lblHeaderHint.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderHint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblHeaderHint.Appearance.Options.UseFont = true;
            this.lblHeaderHint.Appearance.Options.UseForeColor = true;
            this.lblHeaderHint.Location = new System.Drawing.Point(14, 69);
            this.lblHeaderHint.Name = "lblHeaderHint";
            this.lblHeaderHint.Size = new System.Drawing.Size(612, 15);
            this.lblHeaderHint.TabIndex = 2;
            this.lblHeaderHint.Text = "Every price is for ONE stocking unit — the \'Per Unit\' column says which (CAN, PCS" +
    ", G, ML). Never per case or carton.";
            this.lblHeaderHint.Visible = false;
            // 
            // lblScreenName
            // 
            this.lblScreenName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblScreenName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblScreenName.Appearance.Options.UseFont = true;
            this.lblScreenName.Appearance.Options.UseForeColor = true;
            this.lblScreenName.Location = new System.Drawing.Point(14, 47);
            this.lblScreenName.Name = "lblScreenName";
            this.lblScreenName.Size = new System.Drawing.Size(129, 20);
            this.lblScreenName.TabIndex = 1;
            this.lblScreenName.Text = "Franchise Price List";
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(12, 16);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.PicSectionIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(0, 0);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(98, 92);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 184;
            this.PicSectionIcon.TabStop = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlInput.Appearance.Options.UseBackColor = true;
            this.pnlInput.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlInput.Controls.Add(this.lblOutlet);
            this.pnlInput.Controls.Add(this.cboOutlet);
            this.pnlInput.Controls.Add(this.lblProduct);
            this.pnlInput.Controls.Add(this.cboProduct);
            this.pnlInput.Controls.Add(this.lblUnit);
            this.pnlInput.Controls.Add(this.txtUnit);
            this.pnlInput.Controls.Add(this.lblCostPrice);
            this.pnlInput.Controls.Add(this.txtCostPrice);
            this.pnlInput.Controls.Add(this.lblUnitPrice);
            this.pnlInput.Controls.Add(this.txtUnitPrice);
            this.pnlInput.Controls.Add(this.btnSave);
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 92);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(820, 190);
            this.pnlInput.TabIndex = 2;
            // 
            // lblOutlet
            // 
            this.lblOutlet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOutlet.Appearance.Options.UseFont = true;
            this.lblOutlet.Location = new System.Drawing.Point(24, 16);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(99, 17);
            this.lblOutlet.TabIndex = 0;
            this.lblOutlet.Text = "Franchise Outlet";
            // 
            // cboOutlet
            // 
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(24, 38);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(280, 21);
            this.cboOutlet.TabIndex = 1;
            // 
            // lblProduct
            // 
            this.lblProduct.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Appearance.Options.UseFont = true;
            this.lblProduct.Location = new System.Drawing.Point(348, 15);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(48, 17);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Product";
            // 
            // cboProduct
            // 
            this.cboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(348, 38);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(340, 21);
            this.cboProduct.TabIndex = 3;
            // 
            // lblUnit
            // 
            this.lblUnit.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Appearance.Options.UseFont = true;
            this.lblUnit.Location = new System.Drawing.Point(24, 76);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(25, 17);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(24, 98);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.txtUnit.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtUnit.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnit.Properties.Appearance.Options.UseFont = true;
            this.txtUnit.Properties.NullValuePrompt = "—";
            this.txtUnit.Properties.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(120, 24);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.TabStop = false;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCostPrice.Appearance.Options.UseFont = true;
            this.lblCostPrice.Location = new System.Drawing.Point(164, 76);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(72, 17);
            this.lblCostPrice.TabIndex = 6;
            this.lblCostPrice.Text = "Buy-in Price";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(164, 98);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.txtCostPrice.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCostPrice.Properties.Appearance.Options.UseBackColor = true;
            this.txtCostPrice.Properties.Appearance.Options.UseFont = true;
            this.txtCostPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCostPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCostPrice.Properties.NullValuePrompt = "—";
            this.txtCostPrice.Properties.ReadOnly = true;
            this.txtCostPrice.Size = new System.Drawing.Size(130, 24);
            this.txtCostPrice.TabIndex = 7;
            this.txtCostPrice.TabStop = false;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnitPrice.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.lblUnitPrice.Appearance.Options.UseFont = true;
            this.lblUnitPrice.Appearance.Options.UseForeColor = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(348, 76);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(58, 17);
            this.lblUnitPrice.TabIndex = 8;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(348, 98);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtUnitPrice.Properties.Appearance.Options.UseFont = true;
            this.txtUnitPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUnitPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtUnitPrice.Properties.NullValuePrompt = "0.00";
            this.txtUnitPrice.Size = new System.Drawing.Size(140, 24);
            this.txtUnitPrice.TabIndex = 9;
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitPrice_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(24, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ADD";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClear.Appearance.Options.UseBackColor = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.Location = new System.Drawing.Point(140, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Appearance.Options.UseBackColor = true;
            this.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlGrid.Controls.Add(this.grdPrice);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 282);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrid.Size = new System.Drawing.Size(820, 280);
            this.pnlGrid.TabIndex = 0;
            // 
            // grdPrice
            // 
            this.grdPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrice.Location = new System.Drawing.Point(16, 12);
            this.grdPrice.MainView = this.gvPrice;
            this.grdPrice.Name = "grdPrice";
            this.grdPrice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riUpdate,
            this.riDelete});
            this.grdPrice.Size = new System.Drawing.Size(788, 256);
            this.grdPrice.TabIndex = 0;
            this.grdPrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrice});
            // 
            // gvPrice
            // 
            this.gvPrice.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvPrice.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPrice.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvPrice.Appearance.Row.Options.UseFont = true;
            this.gvPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOutletName,
            this.colProductName,
            this.colUnitPrice,
            this.colProUnit,
            this.colIsActive,
            this.colUpdatedAt,
            this.colUpdatedBy,
            this.colUpdate,
            this.colDelete});
            this.gvPrice.GridControl = this.grdPrice;
            this.gvPrice.Name = "gvPrice";
            this.gvPrice.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPrice.OptionsView.ShowGroupPanel = false;
            this.gvPrice.RowHeight = 30;
            // 
            // colOutletName
            // 
            this.colOutletName.Caption = "Outlet";
            this.colOutletName.FieldName = "OutletName";
            this.colOutletName.Name = "colOutletName";
            this.colOutletName.Visible = true;
            this.colOutletName.VisibleIndex = 0;
            this.colOutletName.Width = 180;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Product";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 1;
            this.colProductName.Width = 240;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "Unit Price (per 1 unit)";
            // 0.0000: an ingredient price is per gram/ml, so 2 decimals shows 0.00
            // for prices that are really set - indistinguishable from unset.
            this.colUnitPrice.DisplayFormat.FormatString = "0.0000";
            this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ToolTip = "Price for ONE unit of the product, in the unit shown in \'Per Unit\'. Not a case pr" +
    "ice.";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 2;
            this.colUnitPrice.Width = 140;
            // 
            // colProUnit
            // 
            this.colProUnit.Caption = "Per Unit";
            this.colProUnit.FieldName = "ProUnit";
            this.colProUnit.Name = "colProUnit";
            this.colProUnit.OptionsColumn.AllowEdit = false;
            this.colProUnit.ToolTip = "The unit this price is per (Product.ProUnit) — a transfer of 100 is 100 of these." +
    "";
            this.colProUnit.Visible = true;
            this.colProUnit.VisibleIndex = 3;
            this.colProUnit.Width = 80;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Active";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.OptionsColumn.AllowEdit = false;
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 4;
            this.colIsActive.Width = 60;
            // 
            // colUpdatedAt
            // 
            this.colUpdatedAt.Caption = "Updated";
            this.colUpdatedAt.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.colUpdatedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUpdatedAt.FieldName = "UpdatedAt";
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.Visible = true;
            this.colUpdatedAt.VisibleIndex = 5;
            this.colUpdatedAt.Width = 140;
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.Caption = "By";
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Name = "colUpdatedBy";
            this.colUpdatedBy.Visible = true;
            this.colUpdatedBy.VisibleIndex = 6;
            this.colUpdatedBy.Width = 110;
            // 
            // colUpdate
            // 
            this.colUpdate.Caption = "Edit";
            this.colUpdate.ColumnEdit = this.riUpdate;
            this.colUpdate.FieldName = "Update";
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUpdate.Visible = true;
            this.colUpdate.VisibleIndex = 7;
            this.colUpdate.Width = 60;
            // 
            // riUpdate
            // 
            this.riUpdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.riUpdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.riUpdate.Name = "riUpdate";
            this.riUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.riUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowUpdate_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Toggle";
            this.colDelete.ColumnEdit = this.riDelete;
            this.colDelete.FieldName = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 8;
            this.colDelete.Width = 70;
            // 
            // riDelete
            // 
            this.riDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.refresh_16;
            this.riDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.riDelete.Name = "riDelete";
            this.riDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.riDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowToggleActive_ButtonClick);
            // 
            // panelFooter
            // 
            this.panelFooter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.panelFooter.Appearance.Options.UseBackColor = true;
            this.panelFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFooter.Controls.Add(this.lblCount);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 562);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(820, 38);
            this.panelFooter.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblCount.Appearance.Options.UseFont = true;
            this.lblCount.Appearance.Options.UseForeColor = true;
            this.lblCount.Location = new System.Drawing.Point(24, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(85, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Total Records: 0";
            // 
            // guiFranchisePriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiFranchisePriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Franchise Price List";
            this.Load += new System.EventHandler(this.guiFranchisePriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.pnlHeaderText.ResumeLayout(false);
            this.pnlHeaderText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).EndInit();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.LabelControl lblHeaderHint;
    }
}
