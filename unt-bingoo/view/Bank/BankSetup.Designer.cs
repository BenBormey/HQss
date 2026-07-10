namespace unt_bingoo.view.Bank
{
    partial class BankSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelEntry = new DevExpress.XtraEditors.PanelControl();
            this.chkIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.cmbCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lblCurrency = new DevExpress.XtraEditors.LabelControl();
            this.txtCallbackUrl = new DevExpress.XtraEditors.TextEdit();
            this.lblCallbackUrl = new DevExpress.XtraEditors.LabelControl();
            this.txtApiSecret = new DevExpress.XtraEditors.TextEdit();
            this.lblApiSecret = new DevExpress.XtraEditors.LabelControl();
            this.txtApiKey = new DevExpress.XtraEditors.TextEdit();
            this.lblApiKey = new DevExpress.XtraEditors.LabelControl();
            this.txtApiUrl = new DevExpress.XtraEditors.TextEdit();
            this.lblApiUrl = new DevExpress.XtraEditors.LabelControl();
            this.txtMerchantName = new DevExpress.XtraEditors.TextEdit();
            this.lblMerchantName = new DevExpress.XtraEditors.LabelControl();
            this.txtMerchantId = new DevExpress.XtraEditors.TextEdit();
            this.lblMerchantId = new DevExpress.XtraEditors.LabelControl();
            this.cmbBankType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBankType = new DevExpress.XtraEditors.LabelControl();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.lblBankName = new DevExpress.XtraEditors.LabelControl();
            this.txtBankCode = new DevExpress.XtraEditors.TextEdit();
            this.lblBankCode = new DevExpress.XtraEditors.LabelControl();
            this.chkDeactive = new DevExpress.XtraEditors.CheckEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblEntryHeader = new DevExpress.XtraEditors.LabelControl();
            this.gridControlBank = new DevExpress.XtraGrid.GridControl();
            this.gridViewBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBankId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEntry)).BeginInit();
            this.panelEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCallbackUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiSecret.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchantName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchantId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBankType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.White;
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1120, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(72, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 23);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "JuJuBi Management System";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM2;
            this.picLogo.Location = new System.Drawing.Point(12, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // panelEntry
            // 
            this.panelEntry.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelEntry.Appearance.Options.UseBackColor = true;
            this.panelEntry.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelEntry.Controls.Add(this.chkIsDefault);
            this.panelEntry.Controls.Add(this.cmbCurrency);
            this.panelEntry.Controls.Add(this.btnSave);
            this.panelEntry.Controls.Add(this.btnUpdate);
            this.panelEntry.Controls.Add(this.btnDelete);
            this.panelEntry.Controls.Add(this.lblCurrency);
            this.panelEntry.Controls.Add(this.txtCallbackUrl);
            this.panelEntry.Controls.Add(this.lblCallbackUrl);
            this.panelEntry.Controls.Add(this.txtApiSecret);
            this.panelEntry.Controls.Add(this.lblApiSecret);
            this.panelEntry.Controls.Add(this.txtApiKey);
            this.panelEntry.Controls.Add(this.lblApiKey);
            this.panelEntry.Controls.Add(this.txtApiUrl);
            this.panelEntry.Controls.Add(this.lblApiUrl);
            this.panelEntry.Controls.Add(this.txtMerchantName);
            this.panelEntry.Controls.Add(this.lblMerchantName);
            this.panelEntry.Controls.Add(this.txtMerchantId);
            this.panelEntry.Controls.Add(this.lblMerchantId);
            this.panelEntry.Controls.Add(this.cmbBankType);
            this.panelEntry.Controls.Add(this.lblBankType);
            this.panelEntry.Controls.Add(this.txtBankName);
            this.panelEntry.Controls.Add(this.lblBankName);
            this.panelEntry.Controls.Add(this.txtBankCode);
            this.panelEntry.Controls.Add(this.lblBankCode);
            this.panelEntry.Controls.Add(this.chkDeactive);
            this.panelEntry.Controls.Add(this.chkActive);
            this.panelEntry.Controls.Add(this.lblStatus);
            this.panelEntry.Controls.Add(this.lblEntryHeader);
            this.panelEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntry.Location = new System.Drawing.Point(0, 70);
            this.panelEntry.Name = "panelEntry";
            this.panelEntry.Size = new System.Drawing.Size(1120, 260);
            this.panelEntry.TabIndex = 1;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.Location = new System.Drawing.Point(120, 228);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Properties.Caption = "Set as Default Bank";
            this.chkIsDefault.Size = new System.Drawing.Size(160, 19);
            this.chkIsDefault.TabIndex = 40;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.Location = new System.Drawing.Point(490, 196);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCurrency.Size = new System.Drawing.Size(300, 20);
            this.cmbCurrency.TabIndex = 39;
            // 
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(714, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "&Add";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(820, 222);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(926, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // lblCurrency
            // 
            this.lblCurrency.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Appearance.Options.UseForeColor = true;
            this.lblCurrency.Location = new System.Drawing.Point(380, 198);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(51, 13);
            this.lblCurrency.TabIndex = 38;
            this.lblCurrency.Text = "Currency :";
            // 
            // txtCallbackUrl
            // 
            this.txtCallbackUrl.Location = new System.Drawing.Point(120, 196);
            this.txtCallbackUrl.Name = "txtCallbackUrl";
            this.txtCallbackUrl.Size = new System.Drawing.Size(220, 20);
            this.txtCallbackUrl.TabIndex = 37;
            // 
            // lblCallbackUrl
            // 
            this.lblCallbackUrl.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblCallbackUrl.Appearance.Options.UseForeColor = true;
            this.lblCallbackUrl.Location = new System.Drawing.Point(16, 198);
            this.lblCallbackUrl.Name = "lblCallbackUrl";
            this.lblCallbackUrl.Size = new System.Drawing.Size(62, 13);
            this.lblCallbackUrl.TabIndex = 36;
            this.lblCallbackUrl.Text = "Callback Url :";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(490, 166);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.Properties.UseSystemPasswordChar = true;
            this.txtApiSecret.Size = new System.Drawing.Size(300, 20);
            this.txtApiSecret.TabIndex = 35;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblApiSecret.Appearance.Options.UseForeColor = true;
            this.lblApiSecret.Location = new System.Drawing.Point(380, 168);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(56, 13);
            this.lblApiSecret.TabIndex = 34;
            this.lblApiSecret.Text = "Api Secret :";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(120, 166);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(220, 20);
            this.txtApiKey.TabIndex = 33;
            // 
            // lblApiKey
            // 
            this.lblApiKey.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblApiKey.Appearance.Options.UseForeColor = true;
            this.lblApiKey.Location = new System.Drawing.Point(16, 168);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(43, 13);
            this.lblApiKey.TabIndex = 32;
            this.lblApiKey.Text = "Api Key :";
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(490, 136);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(300, 20);
            this.txtApiUrl.TabIndex = 31;
            // 
            // lblApiUrl
            // 
            this.lblApiUrl.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblApiUrl.Appearance.Options.UseForeColor = true;
            this.lblApiUrl.Location = new System.Drawing.Point(380, 138);
            this.lblApiUrl.Name = "lblApiUrl";
            this.lblApiUrl.Size = new System.Drawing.Size(38, 13);
            this.lblApiUrl.TabIndex = 30;
            this.lblApiUrl.Text = "Api Url :";
            // 
            // txtMerchantName
            // 
            this.txtMerchantName.Location = new System.Drawing.Point(120, 136);
            this.txtMerchantName.Name = "txtMerchantName";
            this.txtMerchantName.Size = new System.Drawing.Size(220, 20);
            this.txtMerchantName.TabIndex = 29;
            // 
            // lblMerchantName
            // 
            this.lblMerchantName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMerchantName.Appearance.Options.UseForeColor = true;
            this.lblMerchantName.Location = new System.Drawing.Point(16, 138);
            this.lblMerchantName.Name = "lblMerchantName";
            this.lblMerchantName.Size = new System.Drawing.Size(82, 13);
            this.lblMerchantName.TabIndex = 28;
            this.lblMerchantName.Text = "Merchant Name :";
            // 
            // txtMerchantId
            // 
            this.txtMerchantId.Location = new System.Drawing.Point(490, 106);
            this.txtMerchantId.Name = "txtMerchantId";
            this.txtMerchantId.Size = new System.Drawing.Size(300, 20);
            this.txtMerchantId.TabIndex = 27;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMerchantId.Appearance.Options.UseForeColor = true;
            this.lblMerchantId.Location = new System.Drawing.Point(380, 108);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(65, 13);
            this.lblMerchantId.TabIndex = 26;
            this.lblMerchantId.Text = "Merchant Id :";
            // 
            // cmbBankType
            // 
            this.cmbBankType.Location = new System.Drawing.Point(120, 106);
            this.cmbBankType.Name = "cmbBankType";
            this.cmbBankType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBankType.Size = new System.Drawing.Size(220, 20);
            this.cmbBankType.TabIndex = 25;
            // 
            // lblBankType
            // 
            this.lblBankType.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBankType.Appearance.Options.UseForeColor = true;
            this.lblBankType.Location = new System.Drawing.Point(16, 108);
            this.lblBankType.Name = "lblBankType";
            this.lblBankType.Size = new System.Drawing.Size(57, 13);
            this.lblBankType.TabIndex = 24;
            this.lblBankType.Text = "Bank Type :";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(490, 76);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(300, 20);
            this.txtBankName.TabIndex = 23;
            // 
            // lblBankName
            // 
            this.lblBankName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBankName.Appearance.Options.UseForeColor = true;
            this.lblBankName.Location = new System.Drawing.Point(380, 78);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(60, 13);
            this.lblBankName.TabIndex = 22;
            this.lblBankName.Text = "Bank Name :";
            // 
            // txtBankCode
            // 
            this.txtBankCode.Location = new System.Drawing.Point(120, 76);
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.Size = new System.Drawing.Size(220, 20);
            this.txtBankCode.TabIndex = 21;
            // 
            // lblBankCode
            // 
            this.lblBankCode.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBankCode.Appearance.Options.UseForeColor = true;
            this.lblBankCode.Location = new System.Drawing.Point(16, 78);
            this.lblBankCode.Name = "lblBankCode";
            this.lblBankCode.Size = new System.Drawing.Size(58, 13);
            this.lblBankCode.TabIndex = 20;
            this.lblBankCode.Text = "Bank Code :";
            // 
            // chkDeactive
            // 
            this.chkDeactive.Location = new System.Drawing.Point(200, 46);
            this.chkDeactive.Name = "chkDeactive";
            this.chkDeactive.Properties.Caption = "Deactive";
            this.chkDeactive.Size = new System.Drawing.Size(85, 19);
            this.chkDeactive.TabIndex = 11;
            this.chkDeactive.CheckedChanged += new System.EventHandler(this.chkDeactive_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(120, 46);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(75, 19);
            this.chkActive.TabIndex = 10;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Location = new System.Drawing.Point(16, 48);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status :";
            // 
            // lblEntryHeader
            // 
            this.lblEntryHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblEntryHeader.Appearance.Options.UseFont = true;
            this.lblEntryHeader.Location = new System.Drawing.Point(16, 12);
            this.lblEntryHeader.Name = "lblEntryHeader";
            this.lblEntryHeader.Size = new System.Drawing.Size(121, 16);
            this.lblEntryHeader.TabIndex = 1;
            this.lblEntryHeader.Text = "Entry Bank Setup :";
            // 
            // gridControlBank
            // 
            this.gridControlBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBank.Location = new System.Drawing.Point(0, 330);
            this.gridControlBank.MainView = this.gridViewBank;
            this.gridControlBank.Name = "gridControlBank";
            this.gridControlBank.Size = new System.Drawing.Size(1120, 340);
            this.gridControlBank.TabIndex = 2;
            this.gridControlBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBank});
            this.gridControlBank.DoubleClick += new System.EventHandler(this.gridControlBank_DoubleClick);
            // 
            // gridViewBank
            // 
            this.gridViewBank.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBankId,
            this.colBankCode,
            this.colBankName,
            this.colBankType,
            this.colCurrency,
            this.colIsActive});
            this.gridViewBank.GridControl = this.gridControlBank;
            this.gridViewBank.Name = "gridViewBank";
            this.gridViewBank.OptionsBehavior.Editable = false;
            this.gridViewBank.OptionsView.ShowGroupPanel = false;
            // 
            // colBankId
            // 
            this.colBankId.Caption = "Bank Id";
            this.colBankId.FieldName = "BankId";
            this.colBankId.Name = "colBankId";
            this.colBankId.Visible = true;
            this.colBankId.VisibleIndex = 0;
            this.colBankId.Width = 80;
            // 
            // colBankCode
            // 
            this.colBankCode.Caption = "Bank Code";
            this.colBankCode.FieldName = "BankCode";
            this.colBankCode.Name = "colBankCode";
            this.colBankCode.Visible = true;
            this.colBankCode.VisibleIndex = 1;
            this.colBankCode.Width = 130;
            // 
            // colBankName
            // 
            this.colBankName.Caption = "Bank Name";
            this.colBankName.FieldName = "BankName";
            this.colBankName.Name = "colBankName";
            this.colBankName.Visible = true;
            this.colBankName.VisibleIndex = 2;
            this.colBankName.Width = 220;
            // 
            // colBankType
            // 
            this.colBankType.Caption = "Bank Type";
            this.colBankType.FieldName = "BankType";
            this.colBankType.Name = "colBankType";
            this.colBankType.Visible = true;
            this.colBankType.VisibleIndex = 3;
            this.colBankType.Width = 150;
            // 
            // colCurrency
            // 
            this.colCurrency.Caption = "Currency";
            this.colCurrency.FieldName = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Visible = true;
            this.colCurrency.VisibleIndex = 4;
            this.colCurrency.Width = 100;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Active";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 5;
            this.colIsActive.Width = 80;
            // 
            // panelButtons
            // 
            this.panelButtons.Appearance.BackColor = System.Drawing.Color.White;
            this.panelButtons.Appearance.Options.UseBackColor = true;
            this.panelButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 670);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1120, 50);
            this.panelButtons.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Location = new System.Drawing.Point(1020, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 50);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "Close";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // BankSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 720);
            this.Controls.Add(this.gridControlBank);
            this.Controls.Add(this.panelEntry);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelButtons);
            this.Name = "BankSetup";
            this.Text = "BANK SETUP";
            this.Load += new System.EventHandler(this.BankSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelEntry)).EndInit();
            this.panelEntry.ResumeLayout(false);
            this.panelEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCallbackUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiSecret.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApiUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchantName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMerchantId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBankType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private DevExpress.XtraEditors.LabelControl lblTitle;

        private DevExpress.XtraEditors.PanelControl panelEntry;
        private DevExpress.XtraEditors.LabelControl lblEntryHeader;

        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckEdit chkDeactive;

        private DevExpress.XtraEditors.LabelControl lblBankCode;
        private DevExpress.XtraEditors.TextEdit txtBankCode;

        private DevExpress.XtraEditors.LabelControl lblBankName;
        private DevExpress.XtraEditors.TextEdit txtBankName;

        private DevExpress.XtraEditors.LabelControl lblBankType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBankType;

        private DevExpress.XtraEditors.LabelControl lblMerchantId;
        private DevExpress.XtraEditors.TextEdit txtMerchantId;

        private DevExpress.XtraEditors.LabelControl lblMerchantName;
        private DevExpress.XtraEditors.TextEdit txtMerchantName;

        private DevExpress.XtraEditors.LabelControl lblApiUrl;
        private DevExpress.XtraEditors.TextEdit txtApiUrl;

        private DevExpress.XtraEditors.LabelControl lblApiKey;
        private DevExpress.XtraEditors.TextEdit txtApiKey;

        private DevExpress.XtraEditors.LabelControl lblApiSecret;
        private DevExpress.XtraEditors.TextEdit txtApiSecret;

        private DevExpress.XtraEditors.LabelControl lblCallbackUrl;
        private DevExpress.XtraEditors.TextEdit txtCallbackUrl;

        private DevExpress.XtraEditors.LabelControl lblCurrency;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCurrency;

        private DevExpress.XtraEditors.CheckEdit chkIsDefault;

        private DevExpress.XtraGrid.GridControl gridControlBank;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBank;
        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
        private DevExpress.XtraGrid.Columns.GridColumn colBankCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBankName;
        private DevExpress.XtraGrid.Columns.GridColumn colBankType;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;

        private DevExpress.XtraEditors.PanelControl panelButtons;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}