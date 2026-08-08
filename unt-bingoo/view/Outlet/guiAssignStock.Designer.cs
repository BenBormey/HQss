namespace unt_bingoo.view.Outlet
{
    partial class guiAssignStock
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
            this.btnBack = new System.Windows.Forms.Button();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.pnlHeaderText = new System.Windows.Forms.Panel();
            this.lblScreenName = new DevExpress.XtraEditors.LabelControl();

            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridStock = new DevExpress.XtraGrid.GridControl();
            this.gvStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockSellPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockUpdatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelListHeader = new System.Windows.Forms.Panel();
            this.lblGridHeader = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.spacerMid = new System.Windows.Forms.Panel();
            this.panelEntry = new DevExpress.XtraEditors.PanelControl();
            this.pnlEntryInner = new System.Windows.Forms.Panel();
            this.lblFormTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblOutlet = new DevExpress.XtraEditors.LabelControl();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.rdoIngredients = new System.Windows.Forms.RadioButton();
            this.rdoSellable = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblCurrentStock = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.lblQuantity = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.pnlProductInfo = new DevExpress.XtraEditors.PanelControl();
            this.lblInfoCodeCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCodeVal = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoUnitCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoUnitVal = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCostCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoCostVal = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoPriceCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoPriceVal = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoValueCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoValueVal = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoAfterCap = new DevExpress.XtraEditors.LabelControl();
            this.lblInfoAfterVal = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.pnlRecipeWarning = new System.Windows.Forms.Panel();
            this.pnlWarnAccent = new System.Windows.Forms.Panel();
            this.lblRecipeWarning = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.pnlHeaderText.SuspendLayout();
            this.panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).BeginInit();
            this.panelListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelEntry)).BeginInit();
            this.panelEntry.SuspendLayout();
            this.pnlEntryInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProductInfo)).BeginInit();
            this.pnlProductInfo.SuspendLayout();
            this.pnlRecipeWarning.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // pnlHeaderText added before PicSectionIcon: WinForms docks in
            // reverse of the Controls order, so the last-added Left control
            // takes the leftmost slot and the Fill panel gets what remains.
            this.panelHeader.Controls.Add(this.pnlHeaderText);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 92);
            this.panelHeader.TabIndex = 0;
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
            this.PicSectionIcon.TabIndex = 0;
            this.PicSectionIcon.TabStop = false;
            //
            // pnlHeaderText
            //
            this.pnlHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderText.Controls.Add(this.btnBack);
            this.pnlHeaderText.Controls.Add(this.lblScreenName);
            this.pnlHeaderText.Controls.Add(this.lblSystemName);
            this.pnlHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderText.Location = new System.Drawing.Point(98, 0);
            this.pnlHeaderText.Name = "pnlHeaderText";
            this.pnlHeaderText.Size = new System.Drawing.Size(1102, 92);
            this.pnlHeaderText.TabIndex = 1;
            //
            // lblSystemName
            //
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(12, 22);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "JuJuBi Management System";
            //
            // lblScreenName
            //
            this.lblScreenName.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblScreenName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblScreenName.Appearance.Options.UseFont = true;
            this.lblScreenName.Appearance.Options.UseForeColor = true;
            this.lblScreenName.Location = new System.Drawing.Point(14, 53);
            this.lblScreenName.Name = "lblScreenName";
            this.lblScreenName.Size = new System.Drawing.Size(180, 20);
            this.lblScreenName.TabIndex = 1;
            this.lblScreenName.Text = "Assign Stock to Outlet";
            //
            // btnBack
            //
            // Moved to the right: the logo now owns the left edge.
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnBack.FlatAppearance.BorderSize = 1;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnBack.Location = new System.Drawing.Point(986, 29);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 34);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "←  Back";
            this.btnBack.UseVisualStyleBackColor = false;
            //
            // panelBody
            //
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelBody.Controls.Add(this.panelGrid);
            this.panelBody.Controls.Add(this.spacerMid);
            this.panelBody.Controls.Add(this.panelEntry);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(24, 16, 24, 12);
            this.panelBody.Size = new System.Drawing.Size(1200, 640);
            this.panelBody.TabIndex = 1;
            //
            // panelEntry
            //
            this.panelEntry.Appearance.BackColor = System.Drawing.Color.White;
            this.panelEntry.Appearance.Options.UseBackColor = true;
            this.panelEntry.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelEntry.Controls.Add(this.pnlEntryInner);
            this.panelEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntry.Location = new System.Drawing.Point(24, 16);
            this.panelEntry.Name = "panelEntry";
            this.panelEntry.Padding = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.panelEntry.Size = new System.Drawing.Size(1152, 340);
            this.panelEntry.TabIndex = 0;
            //
            // pnlEntryInner
            //
            this.pnlEntryInner.BackColor = System.Drawing.Color.Transparent;
            this.pnlEntryInner.Controls.Add(this.pnlRecipeWarning);
            this.pnlEntryInner.Controls.Add(this.lblStatus);
            this.pnlEntryInner.Controls.Add(this.pnlProductInfo);
            this.pnlEntryInner.Controls.Add(this.btnAssign);
            this.pnlEntryInner.Controls.Add(this.txtQuantity);
            this.pnlEntryInner.Controls.Add(this.lblQuantity);
            this.pnlEntryInner.Controls.Add(this.txtCurrentStock);
            this.pnlEntryInner.Controls.Add(this.lblCurrentStock);
            this.pnlEntryInner.Controls.Add(this.cboProduct);
            this.pnlEntryInner.Controls.Add(this.rdoAll);
            this.pnlEntryInner.Controls.Add(this.rdoSellable);
            this.pnlEntryInner.Controls.Add(this.rdoIngredients);
            this.pnlEntryInner.Controls.Add(this.lblProduct);
            this.pnlEntryInner.Controls.Add(this.cboOutlet);
            this.pnlEntryInner.Controls.Add(this.lblOutlet);
            this.pnlEntryInner.Controls.Add(this.lblFormTitle);
            this.pnlEntryInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEntryInner.Location = new System.Drawing.Point(24, 18);
            this.pnlEntryInner.Name = "pnlEntryInner";
            this.pnlEntryInner.Size = new System.Drawing.Size(1104, 300);
            this.pnlEntryInner.TabIndex = 0;
            //
            // lblFormTitle
            //
            this.lblFormTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblFormTitle.Appearance.Options.UseFont = true;
            this.lblFormTitle.Appearance.Options.UseForeColor = true;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(150, 21);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Assign Stock";
            //
            // lblOutlet
            //
            this.lblOutlet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblOutlet.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblOutlet.Appearance.Options.UseFont = true;
            this.lblOutlet.Appearance.Options.UseForeColor = true;
            this.lblOutlet.Location = new System.Drawing.Point(0, 38);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(40, 15);
            this.lblOutlet.TabIndex = 1;
            this.lblOutlet.Text = "Outlet";
            //
            // cboOutlet
            //
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOutlet.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(0, 58);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(300, 25);
            this.cboOutlet.TabIndex = 2;
            //
            // lblProduct
            //
            this.lblProduct.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblProduct.Appearance.Options.UseFont = true;
            this.lblProduct.Appearance.Options.UseForeColor = true;
            this.lblProduct.Location = new System.Drawing.Point(320, 38);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(50, 15);
            this.lblProduct.TabIndex = 3;
            this.lblProduct.Text = "Product";
            //
            // rdoIngredients
            //
            this.rdoIngredients.AutoSize = true;
            this.rdoIngredients.Checked = true;
            this.rdoIngredients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoIngredients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoIngredients.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoIngredients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.rdoIngredients.Location = new System.Drawing.Point(392, 36);
            this.rdoIngredients.Name = "rdoIngredients";
            this.rdoIngredients.Size = new System.Drawing.Size(83, 18);
            this.rdoIngredients.TabIndex = 20;
            this.rdoIngredients.TabStop = true;
            this.rdoIngredients.Text = "Ingredients";
            this.rdoIngredients.UseVisualStyleBackColor = true;
            //
            // rdoSellable
            //
            this.rdoSellable.AutoSize = true;
            this.rdoSellable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoSellable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoSellable.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoSellable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.rdoSellable.Location = new System.Drawing.Point(483, 36);
            this.rdoSellable.Name = "rdoSellable";
            this.rdoSellable.Size = new System.Drawing.Size(68, 18);
            this.rdoSellable.TabIndex = 21;
            this.rdoSellable.Text = "Sellable";
            this.rdoSellable.UseVisualStyleBackColor = true;
            //
            // rdoAll
            //
            this.rdoAll.AutoSize = true;
            this.rdoAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.rdoAll.Location = new System.Drawing.Point(559, 36);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(41, 18);
            this.rdoAll.TabIndex = 22;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            //
            // cboProduct
            //
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(320, 58);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(340, 25);
            this.cboProduct.TabIndex = 4;
            //
            // lblCurrentStock
            //
            this.lblCurrentStock.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCurrentStock.Appearance.Options.UseFont = true;
            this.lblCurrentStock.Appearance.Options.UseForeColor = true;
            this.lblCurrentStock.Location = new System.Drawing.Point(680, 38);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(80, 15);
            this.lblCurrentStock.TabIndex = 5;
            this.lblCurrentStock.Text = "Current Stock";
            //
            // txtCurrentStock
            //
            this.txtCurrentStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtCurrentStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentStock.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtCurrentStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.txtCurrentStock.Location = new System.Drawing.Point(680, 58);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(160, 25);
            this.txtCurrentStock.TabIndex = 6;
            this.txtCurrentStock.Text = "—";
            //
            // lblQuantity
            //
            this.lblQuantity.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblQuantity.Appearance.Options.UseFont = true;
            this.lblQuantity.Appearance.Options.UseForeColor = true;
            this.lblQuantity.Location = new System.Drawing.Point(860, 38);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(80, 15);
            this.lblQuantity.TabIndex = 7;
            this.lblQuantity.Text = "New Quantity";
            //
            // txtQuantity
            //
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(860, 58);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(160, 25);
            this.txtQuantity.TabIndex = 8;
            //
            // btnAssign
            //
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAssign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssign.FlatAppearance.BorderSize = 0;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(1040, 57);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(120, 27);
            this.btnAssign.TabIndex = 9;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            //
            // pnlProductInfo
            //
            this.pnlProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductInfo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlProductInfo.Appearance.Options.UseBackColor = true;
            this.pnlProductInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlProductInfo.Controls.Add(this.lblInfoAfterVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoAfterCap);
            this.pnlProductInfo.Controls.Add(this.lblInfoValueVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoValueCap);
            this.pnlProductInfo.Controls.Add(this.lblInfoPriceVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoPriceCap);
            this.pnlProductInfo.Controls.Add(this.lblInfoCostVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoCostCap);
            this.pnlProductInfo.Controls.Add(this.lblInfoUnitVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoUnitCap);
            this.pnlProductInfo.Controls.Add(this.lblInfoCodeVal);
            this.pnlProductInfo.Controls.Add(this.lblInfoCodeCap);
            this.pnlProductInfo.Location = new System.Drawing.Point(0, 98);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(1104, 64);
            this.pnlProductInfo.TabIndex = 10;
            //
            // lblInfoCodeCap
            //
            this.lblInfoCodeCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoCodeCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoCodeCap.Appearance.Options.UseFont = true;
            this.lblInfoCodeCap.Appearance.Options.UseForeColor = true;
            this.lblInfoCodeCap.Location = new System.Drawing.Point(16, 11);
            this.lblInfoCodeCap.Name = "lblInfoCodeCap";
            this.lblInfoCodeCap.Size = new System.Drawing.Size(30, 14);
            this.lblInfoCodeCap.TabIndex = 0;
            this.lblInfoCodeCap.Text = "Code";
            //
            // lblInfoCodeVal
            //
            this.lblInfoCodeVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoCodeVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblInfoCodeVal.Appearance.Options.UseFont = true;
            this.lblInfoCodeVal.Appearance.Options.UseForeColor = true;
            this.lblInfoCodeVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoCodeVal.Location = new System.Drawing.Point(16, 31);
            this.lblInfoCodeVal.Name = "lblInfoCodeVal";
            this.lblInfoCodeVal.Size = new System.Drawing.Size(160, 19);
            this.lblInfoCodeVal.TabIndex = 1;
            this.lblInfoCodeVal.Text = "—";
            //
            // lblInfoUnitCap
            //
            this.lblInfoUnitCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoUnitCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoUnitCap.Appearance.Options.UseFont = true;
            this.lblInfoUnitCap.Appearance.Options.UseForeColor = true;
            this.lblInfoUnitCap.Location = new System.Drawing.Point(191, 11);
            this.lblInfoUnitCap.Name = "lblInfoUnitCap";
            this.lblInfoUnitCap.Size = new System.Drawing.Size(24, 14);
            this.lblInfoUnitCap.TabIndex = 2;
            this.lblInfoUnitCap.Text = "Unit";
            //
            // lblInfoUnitVal
            //
            this.lblInfoUnitVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoUnitVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblInfoUnitVal.Appearance.Options.UseFont = true;
            this.lblInfoUnitVal.Appearance.Options.UseForeColor = true;
            this.lblInfoUnitVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoUnitVal.Location = new System.Drawing.Point(191, 31);
            this.lblInfoUnitVal.Name = "lblInfoUnitVal";
            this.lblInfoUnitVal.Size = new System.Drawing.Size(160, 19);
            this.lblInfoUnitVal.TabIndex = 3;
            this.lblInfoUnitVal.Text = "—";
            //
            // lblInfoCostCap
            //
            this.lblInfoCostCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoCostCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoCostCap.Appearance.Options.UseFont = true;
            this.lblInfoCostCap.Appearance.Options.UseForeColor = true;
            this.lblInfoCostCap.Location = new System.Drawing.Point(366, 11);
            this.lblInfoCostCap.Name = "lblInfoCostCap";
            this.lblInfoCostCap.Size = new System.Drawing.Size(80, 14);
            this.lblInfoCostCap.TabIndex = 4;
            this.lblInfoCostCap.Text = "Buy-in Price";
            //
            // lblInfoCostVal
            //
            this.lblInfoCostVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoCostVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblInfoCostVal.Appearance.Options.UseFont = true;
            this.lblInfoCostVal.Appearance.Options.UseForeColor = true;
            this.lblInfoCostVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoCostVal.Location = new System.Drawing.Point(366, 31);
            this.lblInfoCostVal.Name = "lblInfoCostVal";
            this.lblInfoCostVal.Size = new System.Drawing.Size(160, 19);
            this.lblInfoCostVal.TabIndex = 5;
            this.lblInfoCostVal.Text = "—";
            //
            // lblInfoPriceCap
            //
            this.lblInfoPriceCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoPriceCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoPriceCap.Appearance.Options.UseFont = true;
            this.lblInfoPriceCap.Appearance.Options.UseForeColor = true;
            this.lblInfoPriceCap.Location = new System.Drawing.Point(541, 11);
            this.lblInfoPriceCap.Name = "lblInfoPriceCap";
            this.lblInfoPriceCap.Size = new System.Drawing.Size(52, 14);
            this.lblInfoPriceCap.TabIndex = 6;
            this.lblInfoPriceCap.Text = "Sell Price";
            //
            // lblInfoPriceVal
            //
            this.lblInfoPriceVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoPriceVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblInfoPriceVal.Appearance.Options.UseFont = true;
            this.lblInfoPriceVal.Appearance.Options.UseForeColor = true;
            this.lblInfoPriceVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoPriceVal.Location = new System.Drawing.Point(541, 31);
            this.lblInfoPriceVal.Name = "lblInfoPriceVal";
            this.lblInfoPriceVal.Size = new System.Drawing.Size(160, 19);
            this.lblInfoPriceVal.TabIndex = 7;
            this.lblInfoPriceVal.Text = "—";
            //
            // lblInfoValueCap
            //
            this.lblInfoValueCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoValueCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoValueCap.Appearance.Options.UseFont = true;
            this.lblInfoValueCap.Appearance.Options.UseForeColor = true;
            this.lblInfoValueCap.Location = new System.Drawing.Point(716, 11);
            this.lblInfoValueCap.Name = "lblInfoValueCap";
            this.lblInfoValueCap.Size = new System.Drawing.Size(90, 14);
            this.lblInfoValueCap.TabIndex = 8;
            this.lblInfoValueCap.Text = "Value on Hand";
            //
            // lblInfoValueVal
            //
            this.lblInfoValueVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoValueVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblInfoValueVal.Appearance.Options.UseFont = true;
            this.lblInfoValueVal.Appearance.Options.UseForeColor = true;
            this.lblInfoValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoValueVal.Location = new System.Drawing.Point(716, 31);
            this.lblInfoValueVal.Name = "lblInfoValueVal";
            this.lblInfoValueVal.Size = new System.Drawing.Size(160, 19);
            this.lblInfoValueVal.TabIndex = 9;
            this.lblInfoValueVal.Text = "—";
            //
            // lblInfoAfterCap
            //
            this.lblInfoAfterCap.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInfoAfterCap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblInfoAfterCap.Appearance.Options.UseFont = true;
            this.lblInfoAfterCap.Appearance.Options.UseForeColor = true;
            this.lblInfoAfterCap.Location = new System.Drawing.Point(891, 11);
            this.lblInfoAfterCap.Name = "lblInfoAfterCap";
            this.lblInfoAfterCap.Size = new System.Drawing.Size(110, 14);
            this.lblInfoAfterCap.TabIndex = 10;
            this.lblInfoAfterCap.Text = "Value After Assign";
            //
            // lblInfoAfterVal
            //
            this.lblInfoAfterVal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoAfterVal.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblInfoAfterVal.Appearance.Options.UseFont = true;
            this.lblInfoAfterVal.Appearance.Options.UseForeColor = true;
            this.lblInfoAfterVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfoAfterVal.Location = new System.Drawing.Point(891, 31);
            this.lblInfoAfterVal.Name = "lblInfoAfterVal";
            this.lblInfoAfterVal.Size = new System.Drawing.Size(190, 19);
            this.lblInfoAfterVal.TabIndex = 11;
            this.lblInfoAfterVal.Text = "—";
            //
            // lblStatus
            //
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(0, 172);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1100, 18);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Pick an outlet and product to see its price and current stock, then enter a new quantity.";
            //
            // pnlRecipeWarning
            //
            this.pnlRecipeWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecipeWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlRecipeWarning.Controls.Add(this.lblRecipeWarning);
            this.pnlRecipeWarning.Controls.Add(this.pnlWarnAccent);
            this.pnlRecipeWarning.Location = new System.Drawing.Point(0, 194);
            this.pnlRecipeWarning.Name = "pnlRecipeWarning";
            this.pnlRecipeWarning.Padding = new System.Windows.Forms.Padding(0, 6, 8, 6);
            this.pnlRecipeWarning.Size = new System.Drawing.Size(1104, 106);
            this.pnlRecipeWarning.TabIndex = 12;
            this.pnlRecipeWarning.Visible = false;
            //
            // pnlWarnAccent
            //
            this.pnlWarnAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.pnlWarnAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlWarnAccent.Location = new System.Drawing.Point(0, 6);
            this.pnlWarnAccent.Name = "pnlWarnAccent";
            this.pnlWarnAccent.Size = new System.Drawing.Size(4, 94);
            this.pnlWarnAccent.TabIndex = 0;
            //
            // lblRecipeWarning
            //
            this.lblRecipeWarning.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecipeWarning.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.lblRecipeWarning.Appearance.Options.UseFont = true;
            this.lblRecipeWarning.Appearance.Options.UseForeColor = true;
            this.lblRecipeWarning.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRecipeWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecipeWarning.Location = new System.Drawing.Point(4, 6);
            this.lblRecipeWarning.Name = "lblRecipeWarning";
            this.lblRecipeWarning.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblRecipeWarning.Size = new System.Drawing.Size(1092, 94);
            this.lblRecipeWarning.TabIndex = 1;
            this.lblRecipeWarning.Text = "";
            //
            // spacerMid
            //
            this.spacerMid.BackColor = System.Drawing.Color.Transparent;
            this.spacerMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacerMid.Location = new System.Drawing.Point(24, 292);
            this.spacerMid.Name = "spacerMid";
            this.spacerMid.Size = new System.Drawing.Size(1152, 12);
            this.spacerMid.TabIndex = 1;
            //
            // panelGrid
            //
            this.panelGrid.Appearance.BackColor = System.Drawing.Color.White;
            this.panelGrid.Appearance.Options.UseBackColor = true;
            this.panelGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelGrid.Controls.Add(this.gridStock);
            this.panelGrid.Controls.Add(this.panelListHeader);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(24, 304);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.panelGrid.Size = new System.Drawing.Size(1152, 324);
            this.panelGrid.TabIndex = 2;
            //
            // panelListHeader
            //
            this.panelListHeader.BackColor = System.Drawing.Color.Transparent;
            this.panelListHeader.Controls.Add(this.btnRefresh);
            this.panelListHeader.Controls.Add(this.lblGridHeader);
            this.panelListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListHeader.Location = new System.Drawing.Point(20, 18);
            this.panelListHeader.Name = "panelListHeader";
            this.panelListHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelListHeader.Size = new System.Drawing.Size(1112, 42);
            this.panelListHeader.TabIndex = 0;
            //
            // lblGridHeader
            //
            this.lblGridHeader.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridHeader.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblGridHeader.Appearance.Options.UseFont = true;
            this.lblGridHeader.Appearance.Options.UseForeColor = true;
            this.lblGridHeader.Location = new System.Drawing.Point(0, 6);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(220, 19);
            this.lblGridHeader.TabIndex = 0;
            this.lblGridHeader.Text = "Current stock for this outlet";
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnRefresh.Location = new System.Drawing.Point(1012, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            //
            // gridStock
            //
            this.gridStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStock.Location = new System.Drawing.Point(20, 60);
            this.gridStock.MainView = this.gvStock;
            this.gridStock.Name = "gridStock";
            this.gridStock.Size = new System.Drawing.Size(1112, 246);
            this.gridStock.TabIndex = 1;
            this.gridStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStock});
            //
            // gvStock
            //
            this.gvStock.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.gvStock.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvStock.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.gvStock.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gvStock.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvStock.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvStock.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.gvStock.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gvStock.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.gvStock.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvStock.Appearance.FooterPanel.Options.UseFont = true;
            this.gvStock.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvStock.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.gvStock.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvStock.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.gvStock.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvStock.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvStock.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvStock.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gvStock.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.gvStock.Appearance.Row.Options.UseFont = true;
            this.gvStock.Appearance.Row.Options.UseForeColor = true;
            this.gvStock.ColumnPanelRowHeight = 36;
            this.gvStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStockCode,
            this.colStockName,
            this.colStockType,
            this.colStockQty,
            this.colStockUnitCost,
            this.colStockSellPrice,
            this.colStockValue,
            this.colStockUpdatedAt,
            this.colStockUpdatedBy});
            this.gvStock.GridControl = this.gridStock;
            this.gvStock.Name = "gvStock";
            this.gvStock.OptionsBehavior.Editable = false;
            this.gvStock.OptionsView.EnableAppearanceEvenRow = true;
            this.gvStock.OptionsView.ShowFooter = true;
            this.gvStock.OptionsView.ShowGroupPanel = false;
            this.gvStock.OptionsView.ShowIndicator = false;
            this.gvStock.RowHeight = 34;
            //
            // colStockCode
            //
            this.colStockCode.Caption = "Code";
            this.colStockCode.FieldName = "ProNumY";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.OptionsColumn.AllowEdit = false;
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 0;
            this.colStockCode.Width = 120;
            //
            // colStockName
            //
            this.colStockName.Caption = "Name";
            this.colStockName.FieldName = "ProName";
            this.colStockName.Name = "colStockName";
            this.colStockName.OptionsColumn.AllowEdit = false;
            this.colStockName.Visible = true;
            this.colStockName.VisibleIndex = 1;
            this.colStockName.Width = 200;
            //
            // colStockType
            //
            this.colStockType.Caption = "Type";
            this.colStockType.FieldName = "ProductType";
            this.colStockType.Name = "colStockType";
            this.colStockType.OptionsColumn.AllowEdit = false;
            this.colStockType.UnboundExpression = "iif(IsIngredient, \'Ingredient\', \'Sellable\')";
            this.colStockType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStockType.Visible = true;
            this.colStockType.VisibleIndex = 2;
            this.colStockType.Width = 90;
            //
            // colStockQty
            //
            this.colStockQty.AppearanceCell.Options.UseTextOptions = true;
            this.colStockQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockQty.Caption = "Stock Qty";
            this.colStockQty.DisplayFormat.FormatString = "0.####";
            this.colStockQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockQty.FieldName = "StockQty";
            this.colStockQty.Name = "colStockQty";
            this.colStockQty.OptionsColumn.AllowEdit = false;
            this.colStockQty.Visible = true;
            this.colStockQty.VisibleIndex = 3;
            this.colStockQty.Width = 100;
            //
            // colStockUnitCost
            //
            this.colStockUnitCost.AppearanceCell.Options.UseTextOptions = true;
            this.colStockUnitCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockUnitCost.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockUnitCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockUnitCost.Caption = "Buy-in Price";
            // N4: an ingredient buy-in is per gram/ml and vanishes at 2 decimals.
            this.colStockUnitCost.DisplayFormat.FormatString = "N4";
            this.colStockUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockUnitCost.FieldName = "UnitCost";
            this.colStockUnitCost.Name = "colStockUnitCost";
            this.colStockUnitCost.OptionsColumn.AllowEdit = false;
            this.colStockUnitCost.Visible = true;
            this.colStockUnitCost.VisibleIndex = 4;
            this.colStockUnitCost.Width = 90;
            //
            // colStockSellPrice
            //
            this.colStockSellPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colStockSellPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockSellPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockSellPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockSellPrice.Caption = "Sell Price";
            this.colStockSellPrice.DisplayFormat.FormatString = "N2";
            this.colStockSellPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockSellPrice.FieldName = "SellPrice";
            this.colStockSellPrice.Name = "colStockSellPrice";
            this.colStockSellPrice.OptionsColumn.AllowEdit = false;
            this.colStockSellPrice.Visible = true;
            this.colStockSellPrice.VisibleIndex = 5;
            this.colStockSellPrice.Width = 90;
            //
            // colStockValue
            //
            this.colStockValue.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.colStockValue.AppearanceCell.Options.UseFont = true;
            this.colStockValue.AppearanceCell.Options.UseTextOptions = true;
            this.colStockValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colStockValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStockValue.Caption = "Stock Value";
            this.colStockValue.DisplayFormat.FormatString = "N2";
            this.colStockValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStockValue.FieldName = "StockValue";
            this.colStockValue.Name = "colStockValue";
            this.colStockValue.OptionsColumn.AllowEdit = false;
            this.colStockValue.SummaryItem.DisplayFormat = "Total: {0:N2}";
            this.colStockValue.SummaryItem.FieldName = "StockValue";
            this.colStockValue.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colStockValue.Visible = true;
            this.colStockValue.VisibleIndex = 6;
            this.colStockValue.Width = 110;
            //
            // colStockUpdatedAt
            //
            this.colStockUpdatedAt.Caption = "Last Updated";
            this.colStockUpdatedAt.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.colStockUpdatedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStockUpdatedAt.FieldName = "UpdatedAt";
            this.colStockUpdatedAt.Name = "colStockUpdatedAt";
            this.colStockUpdatedAt.OptionsColumn.AllowEdit = false;
            this.colStockUpdatedAt.Visible = true;
            this.colStockUpdatedAt.VisibleIndex = 7;
            this.colStockUpdatedAt.Width = 130;
            //
            // colStockUpdatedBy
            //
            this.colStockUpdatedBy.Caption = "Updated By";
            this.colStockUpdatedBy.FieldName = "UpdatedBy";
            this.colStockUpdatedBy.Name = "colStockUpdatedBy";
            this.colStockUpdatedBy.OptionsColumn.AllowEdit = false;
            this.colStockUpdatedBy.Visible = true;
            this.colStockUpdatedBy.VisibleIndex = 8;
            this.colStockUpdatedBy.Width = 110;
            //
            // guiAssignStock
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "guiAssignStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASSIGN STOCK TO OUTLET";
            this.Load += new System.EventHandler(this.guiAssignStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            this.pnlHeaderText.ResumeLayout(false);
            this.pnlHeaderText.PerformLayout();
            this.panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStock)).EndInit();
            this.panelListHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelEntry)).EndInit();
            this.panelEntry.ResumeLayout(false);
            this.pnlEntryInner.ResumeLayout(false);
            this.pnlEntryInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProductInfo)).EndInit();
            this.pnlProductInfo.ResumeLayout(false);
            this.pnlProductInfo.PerformLayout();
            this.pnlRecipeWarning.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private System.Windows.Forms.Panel pnlHeaderText;
        private DevExpress.XtraEditors.LabelControl lblScreenName;

        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.Panel panelBody;
        private DevExpress.XtraEditors.PanelControl panelEntry;
        private System.Windows.Forms.Panel pnlEntryInner;
        private DevExpress.XtraEditors.LabelControl lblFormTitle;
        private DevExpress.XtraEditors.LabelControl lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private System.Windows.Forms.RadioButton rdoIngredients;
        private System.Windows.Forms.RadioButton rdoSellable;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.ComboBox cboProduct;
        private DevExpress.XtraEditors.LabelControl lblCurrentStock;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private DevExpress.XtraEditors.LabelControl lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAssign;
        private DevExpress.XtraEditors.PanelControl pnlProductInfo;
        private DevExpress.XtraEditors.LabelControl lblInfoCodeCap;
        private DevExpress.XtraEditors.LabelControl lblInfoCodeVal;
        private DevExpress.XtraEditors.LabelControl lblInfoUnitCap;
        private DevExpress.XtraEditors.LabelControl lblInfoUnitVal;
        private DevExpress.XtraEditors.LabelControl lblInfoCostCap;
        private DevExpress.XtraEditors.LabelControl lblInfoCostVal;
        private DevExpress.XtraEditors.LabelControl lblInfoPriceCap;
        private DevExpress.XtraEditors.LabelControl lblInfoPriceVal;
        private DevExpress.XtraEditors.LabelControl lblInfoValueCap;
        private DevExpress.XtraEditors.LabelControl lblInfoValueVal;
        private DevExpress.XtraEditors.LabelControl lblInfoAfterCap;
        private DevExpress.XtraEditors.LabelControl lblInfoAfterVal;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private System.Windows.Forms.Panel pnlRecipeWarning;
        private System.Windows.Forms.Panel pnlWarnAccent;
        private DevExpress.XtraEditors.LabelControl lblRecipeWarning;
        private System.Windows.Forms.Panel spacerMid;
        private DevExpress.XtraEditors.PanelControl panelGrid;
        private System.Windows.Forms.Panel panelListHeader;
        private DevExpress.XtraEditors.LabelControl lblGridHeader;
        private System.Windows.Forms.Button btnRefresh;
        private DevExpress.XtraGrid.GridControl gridStock;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStock;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStockName;
        private DevExpress.XtraGrid.Columns.GridColumn colStockType;
        private DevExpress.XtraGrid.Columns.GridColumn colStockQty;
        private DevExpress.XtraGrid.Columns.GridColumn colStockUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colStockSellPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStockValue;
        private DevExpress.XtraGrid.Columns.GridColumn colStockUpdatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colStockUpdatedBy;
    }
}
