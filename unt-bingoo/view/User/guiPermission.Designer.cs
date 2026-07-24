namespace unt_bingoo.view.User
{
    partial class guiPermission
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
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblRole = new DevExpress.XtraEditors.LabelControl();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblPermissions = new DevExpress.XtraEditors.LabelControl();
            this.chkPermissions = new System.Windows.Forms.CheckedListBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(534, 70);
            this.panelHeader.TabIndex = 0;
            //
            // picLogo
            //
            this.picLogo.Location = new System.Drawing.Point(12, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.AllowFocused = false;
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.ShowMenu = false;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(55, 55);
            this.picLogo.TabIndex = 0;
            //
            // lblSystemName
            //
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(80, 25);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(260, 24);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Permission Management";
            //
            // panelDetail
            //
            this.panelDetail.Controls.Add(this.lblRole);
            this.panelDetail.Controls.Add(this.cboRole);
            this.panelDetail.Controls.Add(this.lblPermissions);
            this.panelDetail.Controls.Add(this.chkPermissions);
            this.panelDetail.Controls.Add(this.chkSelectAll);
            this.panelDetail.Controls.Add(this.btnSave);
            this.panelDetail.Controls.Add(this.btnClose);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 70);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(534, 441);
            this.panelDetail.TabIndex = 1;
            //
            // lblRole
            //
            this.lblRole.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRole.Appearance.Options.UseFont = true;
            this.lblRole.Location = new System.Drawing.Point(20, 18);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 14);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Role:";
            //
            // cboRole
            //
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(90, 15);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(420, 22);
            this.cboRole.TabIndex = 1;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);
            //
            // lblPermissions
            //
            this.lblPermissions.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPermissions.Appearance.Options.UseFont = true;
            this.lblPermissions.Location = new System.Drawing.Point(20, 52);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(70, 14);
            this.lblPermissions.TabIndex = 2;
            this.lblPermissions.Text = "Permissions:";
            //
            // chkPermissions
            //
            this.chkPermissions.CheckOnClick = true;
            this.chkPermissions.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkPermissions.FormattingEnabled = true;
            this.chkPermissions.IntegralHeight = false;
            this.chkPermissions.Location = new System.Drawing.Point(20, 72);
            this.chkPermissions.Name = "chkPermissions";
            this.chkPermissions.Size = new System.Drawing.Size(490, 290);
            this.chkPermissions.TabIndex = 3;
            //
            // chkSelectAll
            //
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkSelectAll.Location = new System.Drawing.Point(20, 372);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(75, 18);
            this.chkSelectAll.TabIndex = 4;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            //
            // btnSave
            //
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(290, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnClose
            //
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(405, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // guiPermission
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permission Management";
            this.Load += new System.EventHandler(this.guiPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.PanelControl panelDetail;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private DevExpress.XtraEditors.LabelControl lblPermissions;
        private System.Windows.Forms.CheckedListBox chkPermissions;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
