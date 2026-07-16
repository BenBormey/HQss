namespace unt_bingoo.view.Customer
{
    partial class guiCustomer
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelHeaderBar = new System.Windows.Forms.Panel();
            this.groupEntry = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.lblPoints = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.chkDeactive = new DevExpress.XtraEditors.CheckEdit();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.gridCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoints = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnMainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.Control;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.panelHeaderBar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1082, 79);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(631, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 25);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelHeaderBar
            // 
            this.panelHeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeaderBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderBar.Location = new System.Drawing.Point(0, 60);
            this.panelHeaderBar.Name = "panelHeaderBar";
            this.panelHeaderBar.Size = new System.Drawing.Size(1082, 19);
            this.panelHeaderBar.TabIndex = 0;
            // 
            // groupEntry
            // 
            this.groupEntry.Controls.Add(this.txtAddress);
            this.groupEntry.Controls.Add(this.lblAddress);
            this.groupEntry.Controls.Add(this.txtPoints);
            this.groupEntry.Controls.Add(this.lblPoints);
            this.groupEntry.Controls.Add(this.txtEmail);
            this.groupEntry.Controls.Add(this.lblEmail);
            this.groupEntry.Controls.Add(this.txtPhone);
            this.groupEntry.Controls.Add(this.lblPhone);
            this.groupEntry.Controls.Add(this.txtName);
            this.groupEntry.Controls.Add(this.lblName);
            this.groupEntry.Controls.Add(this.txtCode);
            this.groupEntry.Controls.Add(this.lblCode);
            this.groupEntry.Controls.Add(this.chkActive);
            this.groupEntry.Controls.Add(this.chkDeactive);
            this.groupEntry.Controls.Add(this.lblStatus);
            this.groupEntry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupEntry.Location = new System.Drawing.Point(13, 88);
            this.groupEntry.Name = "groupEntry";
            this.groupEntry.Size = new System.Drawing.Size(1055, 200);
            this.groupEntry.TabIndex = 1;
            this.groupEntry.TabStop = false;
            this.groupEntry.Text = "Entry Customer :";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(600, 85);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(300, 82);
            this.txtAddress.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(500, 88);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(46, 13);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Address :";
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(600, 55);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(103, 22);
            this.txtPoints.TabIndex = 12;
            this.txtPoints.Text = "0";
            this.txtPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoints_KeyPress);
            // 
            // lblPoints
            // 
            this.lblPoints.Location = new System.Drawing.Point(500, 58);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(36, 13);
            this.lblPoints.TabIndex = 11;
            this.lblPoints.Text = "Points :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(167, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(21, 148);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(31, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email :";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(167, 115);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 22);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(21, 118);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(37, 13);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Phone :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(167, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 22);
            this.txtName.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(21, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(34, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name :";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(167, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(180, 22);
            this.txtCode.TabIndex = 4;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(21, 58);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Code :";
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(167, 24);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Active";
            this.chkActive.Size = new System.Drawing.Size(61, 19);
            this.chkActive.TabIndex = 1;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // chkDeactive
            // 
            this.chkDeactive.Location = new System.Drawing.Point(233, 24);
            this.chkDeactive.Name = "chkDeactive";
            this.chkDeactive.Properties.Caption = "Deactive";
            this.chkDeactive.Size = new System.Drawing.Size(85, 19);
            this.chkDeactive.TabIndex = 2;
            this.chkDeactive.CheckedChanged += new System.EventHandler(this.chkDeactive_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(21, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status :";
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(888, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 34);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelToolbar.Controls.Add(this.panel1);
            this.panelToolbar.Controls.Add(this.btnCancel);
            this.panelToolbar.Controls.Add(this.lblSearch);
            this.panelToolbar.Controls.Add(this.txtSearch);
            this.panelToolbar.Controls.Add(this.btnExport);
            this.panelToolbar.Location = new System.Drawing.Point(13, 294);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1057, 34);
            this.panelToolbar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(808, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 34);
            this.panel1.TabIndex = 17;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(4, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            this.lblSearch.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(52, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(963, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 34);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridCustomer
            // 
            this.gridCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCustomer.Location = new System.Drawing.Point(13, 334);
            this.gridCustomer.MainView = this.gvCustomer;
            this.gridCustomer.Name = "gridCustomer";
            this.gridCustomer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnMainEdit,
            this.btnMainDelete});
            this.gridCustomer.Size = new System.Drawing.Size(1057, 400);
            this.gridCustomer.TabIndex = 3;
            this.gridCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.gvCustomer.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvCustomer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gvCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colPhone,
            this.colEmail,
            this.colPoints,
            this.colActive,
            this.colEdit,
            this.colDelete});
            this.gvCustomer.GridControl = this.gridCustomer;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "CustomerCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 90;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "CustomerName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 170;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "Phone";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 2;
            this.colPhone.Width = 110;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 3;
            this.colEmail.Width = 160;
            // 
            // colPoints
            // 
            this.colPoints.Caption = "Points";
            this.colPoints.FieldName = "Points";
            this.colPoints.Name = "colPoints";
            this.colPoints.OptionsColumn.AllowEdit = false;
            this.colPoints.Visible = true;
            this.colPoints.VisibleIndex = 4;
            this.colPoints.Width = 80;
            // 
            // colActive
            // 
            this.colActive.Caption = "Active";
            this.colActive.FieldName = "IsActive";
            this.colActive.Name = "colActive";
            this.colActive.OptionsColumn.AllowEdit = false;
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            this.colActive.Width = 70;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Edit";
            this.colEdit.ColumnEdit = this.btnMainEdit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 6;
            this.colEdit.Width = 50;
            // 
            // btnMainEdit
            // 
            this.btnMainEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnMainEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnMainEdit.Name = "btnMainEdit";
            this.btnMainEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnMainEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnMainEdit_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.Caption = "Delete";
            this.colDelete.ColumnEdit = this.btnMainDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 7;
            this.colDelete.Width = 50;
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
            // guiCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 750);
            this.Controls.Add(this.gridCustomer);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.groupEntry);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER MANAGEMENT";
            this.Load += new System.EventHandler(this.guiCustomer_Load_1);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupEntry.ResumeLayout(false);
            this.groupEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeactive.Properties)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMainDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelHeaderBar;
        private System.Windows.Forms.GroupBox groupEntry;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckEdit chkDeactive;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private DevExpress.XtraEditors.LabelControl lblName;
        private System.Windows.Forms.TextBox txtName;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private DevExpress.XtraEditors.LabelControl lblPoints;
        private System.Windows.Forms.TextBox txtPoints;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelToolbar;
        private DevExpress.XtraEditors.LabelControl lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private DevExpress.XtraGrid.GridControl gridCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPoints;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMainDelete;
        private System.Windows.Forms.Panel panel1;
    }
}
