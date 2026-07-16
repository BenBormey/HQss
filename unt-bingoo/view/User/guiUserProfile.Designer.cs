namespace unt_bingoo.view.User
{
    partial class guiUserProfile
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblProfileSection = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.txtOutlet = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblContactSection = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(520, 80);
            this.panelHeader.TabIndex = 0;
            //
            // PicSectionIcon
            //
            this.PicSectionIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(0, 0);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(79, 80);
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
            this.lblSystemName.Location = new System.Drawing.Point(90, 30);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(150, 21);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "User Profile";
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.lblProfileSection);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.txtUsername);
            this.panelMain.Controls.Add(this.lblUserId);
            this.panelMain.Controls.Add(this.txtUserId);
            this.panelMain.Controls.Add(this.lblFullName);
            this.panelMain.Controls.Add(this.txtFullName);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblRole);
            this.panelMain.Controls.Add(this.txtRole);
            this.panelMain.Controls.Add(this.lblOutlet);
            this.panelMain.Controls.Add(this.txtOutlet);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.txtStatus);
            this.panelMain.Controls.Add(this.lblContactSection);
            this.panelMain.Controls.Add(this.lblPhone);
            this.panelMain.Controls.Add(this.txtPhone);
            this.panelMain.Controls.Add(this.lblAddress);
            this.panelMain.Controls.Add(this.txtAddress);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelMain.Size = new System.Drawing.Size(520, 330);
            this.panelMain.TabIndex = 1;
            //
            // lblProfileSection
            //
            this.lblProfileSection.AutoSize = true;
            this.lblProfileSection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lblProfileSection.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblProfileSection.Location = new System.Drawing.Point(20, 15);
            this.lblProfileSection.Name = "lblProfileSection";
            this.lblProfileSection.Size = new System.Drawing.Size(130, 15);
            this.lblProfileSection.TabIndex = 0;
            this.lblProfileSection.Text = "Profile Information";
            //
            // lblUsername
            //
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblUsername.Location = new System.Drawing.Point(20, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(64, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            //
            // txtUsername
            //
            this.txtUsername.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtUsername.Location = new System.Drawing.Point(20, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(210, 21);
            this.txtUsername.TabIndex = 2;
            //
            // lblUserId
            //
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblUserId.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblUserId.Location = new System.Drawing.Point(250, 48);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(47, 13);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "User ID";
            //
            // txtUserId
            //
            this.txtUserId.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtUserId.Location = new System.Drawing.Point(250, 65);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(210, 21);
            this.txtUserId.TabIndex = 4;
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblFullName.Location = new System.Drawing.Point(20, 92);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(62, 13);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "Full Name";
            //
            // txtFullName
            //
            this.txtFullName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtFullName.Location = new System.Drawing.Point(20, 109);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(210, 21);
            this.txtFullName.TabIndex = 6;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblEmail.Location = new System.Drawing.Point(250, 92);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            //
            // txtEmail
            //
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtEmail.Location = new System.Drawing.Point(250, 109);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(210, 21);
            this.txtEmail.TabIndex = 8;
            //
            // lblRole
            //
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblRole.Location = new System.Drawing.Point(20, 136);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(31, 13);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "Role";
            //
            // txtRole
            //
            this.txtRole.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtRole.Location = new System.Drawing.Point(20, 153);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(210, 21);
            this.txtRole.TabIndex = 10;
            //
            // lblOutlet
            //
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblOutlet.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblOutlet.Location = new System.Drawing.Point(250, 136);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(38, 13);
            this.lblOutlet.TabIndex = 11;
            this.lblOutlet.Text = "Outlet";
            //
            // txtOutlet
            //
            this.txtOutlet.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtOutlet.Location = new System.Drawing.Point(250, 153);
            this.txtOutlet.Name = "txtOutlet";
            this.txtOutlet.ReadOnly = true;
            this.txtOutlet.Size = new System.Drawing.Size(210, 21);
            this.txtOutlet.TabIndex = 12;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblStatus.Location = new System.Drawing.Point(20, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            //
            // txtStatus
            //
            this.txtStatus.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtStatus.Location = new System.Drawing.Point(20, 197);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(210, 21);
            this.txtStatus.TabIndex = 14;
            //
            // lblContactSection
            //
            this.lblContactSection.AutoSize = true;
            this.lblContactSection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lblContactSection.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblContactSection.Location = new System.Drawing.Point(20, 230);
            this.lblContactSection.Name = "lblContactSection";
            this.lblContactSection.Size = new System.Drawing.Size(107, 15);
            this.lblContactSection.TabIndex = 15;
            this.lblContactSection.Text = "Contact Details";
            //
            // lblPhone
            //
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblPhone.Location = new System.Drawing.Point(20, 263);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 13);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Phone Number";
            //
            // txtPhone
            //
            this.txtPhone.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPhone.Location = new System.Drawing.Point(20, 280);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(210, 21);
            this.txtPhone.TabIndex = 17;
            //
            // lblAddress
            //
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(70, 78, 95);
            this.lblAddress.Location = new System.Drawing.Point(250, 263);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Address";
            //
            // txtAddress
            //
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAddress.Location = new System.Drawing.Point(250, 280);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(210, 21);
            this.txtAddress.TabIndex = 19;
            //
            // panelButtons
            //
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 410);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(520, 50);
            this.panelButtons.TabIndex = 2;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnClose.Location = new System.Drawing.Point(398, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // guiUserProfile
            //
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 460);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiUserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Profile";
            this.Load += new System.EventHandler(this.guiUserProfile_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblProfileSection;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.TextBox txtOutlet;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblContactSection;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}
