namespace unt_bingoo.view
{
    partial class guiLogin
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiLogin));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.PicSectionIcon = new System.Windows.Forms.PictureBox();
            this.panelBody = new System.Windows.Forms.Panel();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).BeginInit();
            this.panelBody.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.Control;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.PicSectionIcon);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(8);
            this.panelHeader.Size = new System.Drawing.Size(452, 74);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(78, 28);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 164;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // PicSectionIcon
            // 
            this.PicSectionIcon.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM;
            this.PicSectionIcon.Location = new System.Drawing.Point(11, 11);
            this.PicSectionIcon.Name = "PicSectionIcon";
            this.PicSectionIcon.Size = new System.Drawing.Size(61, 47);
            this.PicSectionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSectionIcon.TabIndex = 163;
            this.PicSectionIcon.TabStop = false;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.Control;
            this.panelBody.Controls.Add(this.BtnLogIn);
            this.panelBody.Controls.Add(this.BtnExit);
            this.panelBody.Controls.Add(this.Panel2);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 74);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(452, 234);
            this.panelBody.TabIndex = 1;
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLogIn.Image = global::unt_bingoo.Properties.Resources.login;
            this.BtnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLogIn.Location = new System.Drawing.Point(97, 115);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(144, 34);
            this.BtnLogIn.TabIndex = 110;
            this.BtnLogIn.Text = "&Login";
            this.BtnLogIn.UseVisualStyleBackColor = false;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click_1);
            this.BtnLogIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnLogin_KeyPress);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.Location = new System.Drawing.Point(247, 115);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(122, 34);
            this.BtnExit.TabIndex = 111;
            this.BtnExit.Text = "&Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.TxtPassword);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel2.Location = new System.Drawing.Point(81, 69);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(290, 40);
            this.Panel2.TabIndex = 109;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(16, 15);
            this.TxtPassword.MaxLength = 25;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '◦';
            this.TxtPassword.Size = new System.Drawing.Size(272, 21);
            this.TxtPassword.TabIndex = 2;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(16, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(167, 13);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Please enter the password :";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox2.Location = new System.Drawing.Point(2, 2);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(14, 36);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox2.TabIndex = 0;
            this.PictureBox2.TabStop = false;
            // 
            // guiLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 308);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MD JuJuBi";
            this.Load += new System.EventHandler(this.guiLogin_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSectionIcon)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.PictureBox PicSectionIcon;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.Panel panelBody;
        internal System.Windows.Forms.Button BtnLogIn;
        internal System.Windows.Forms.Button BtnExit;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.TextBox TxtPassword;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PictureBox2;
    }
}
