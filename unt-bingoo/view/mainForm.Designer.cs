
namespace unt_bingoo.view
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.loading = new System.Windows.Forms.Timer(this.components);
            this.lblversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblmsgconnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuabout = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuexit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnufile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Customer = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.customerFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuchangepassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.userRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.salerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.outLetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblversion
            // 
            this.lblversion.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.lblversion.BackColor = System.Drawing.Color.Transparent;
            this.lblversion.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.ForeColor = System.Drawing.Color.White;
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(85, 21);
            this.lblversion.Text = "Version 1.0.0";
            this.lblversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // status
            // 
            this.status.AutoSize = false;
            this.status.BackColor = System.Drawing.Color.Teal;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblversion,
            this.lblmsgconnection});
            this.status.Location = new System.Drawing.Point(0, 427);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.status.Size = new System.Drawing.Size(632, 26);
            this.status.TabIndex = 6;
            this.status.Text = "StatusStrip";
            // 
            // lblmsgconnection
            // 
            this.lblmsgconnection.AutoSize = false;
            this.lblmsgconnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsgconnection.ForeColor = System.Drawing.Color.White;
            this.lblmsgconnection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblmsgconnection.Name = "lblmsgconnection";
            this.lblmsgconnection.Size = new System.Drawing.Size(1080, 21);
            this.lblmsgconnection.Text = "This computer is not connected to the internet";
            this.lblmsgconnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblmsgconnection.Visible = false;
            // 
            // mnuabout
            // 
            this.mnuabout.Name = "mnuabout";
            this.mnuabout.Size = new System.Drawing.Size(114, 22);
            this.mnuabout.Text = "&About";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuabout});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(70, 22);
            this.aboutToolStripMenuItem.Text = "&Help     ";
            // 
            // createUserProfileToolStripMenuItem
            // 
            this.createUserProfileToolStripMenuItem.Name = "createUserProfileToolStripMenuItem";
            this.createUserProfileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createUserProfileToolStripMenuItem.Text = "Create User Profile";
            this.createUserProfileToolStripMenuItem.Visible = false;
            // 
            // mnuexit
            // 
            this.mnuexit.Name = "mnuexit";
            this.mnuexit.Size = new System.Drawing.Size(202, 22);
            this.mnuexit.Text = "E&xit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // mnufile
            // 
            this.mnufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuchangepassword,
            this.toolStripMenuItem1,
            this.mnuexit,
            this.createUserProfileToolStripMenuItem});
            this.mnufile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnufile.Name = "mnufile";
            this.mnufile.Size = new System.Drawing.Size(63, 22);
            this.mnufile.Text = "&File     ";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufile,
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.settingToolStripMenuItem,
            this.toolStripMenuItem3,
            this.Customer,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "MenuStrip";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.toolStripSeparator5,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.outLetToolStripMenuItem,
            this.toolStripSeparator2,
            this.currencyToolStripMenuItem,
            this.toolStripSeparator4,
            this.guiBranchToolStripMenuItem});
            this.settingToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.Logo;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.settingToolStripMenuItem.Text = "Bingooo";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // Customer
            // 
            this.Customer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerFormToolStripMenuItem});
            this.Customer.Image = global::unt_bingoo.Properties.Resources.Customer;
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(102, 22);
            this.Customer.Text = "&Customer";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // customerFormToolStripMenuItem
            // 
            this.customerFormToolStripMenuItem.Name = "customerFormToolStripMenuItem";
            this.customerFormToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customerFormToolStripMenuItem.Text = "&Customer";
            this.customerFormToolStripMenuItem.Click += new System.EventHandler(this.customerFormToolStripMenuItem_Click);
            // 
            // mnuchangepassword
            // 
            this.mnuchangepassword.Image = ((System.Drawing.Image)(resources.GetObject("mnuchangepassword.Image")));
            this.mnuchangepassword.Name = "mnuchangepassword";
            this.mnuchangepassword.Size = new System.Drawing.Size(202, 22);
            this.mnuchangepassword.Text = "&Change Password";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.toolStripSeparator3,
            this.userRoleToolStripMenuItem});
            this.toolStripMenuItem2.Image = global::unt_bingoo.Properties.Resources.UserName;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem2.Text = "User";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // userRoleToolStripMenuItem
            // 
            this.userRoleToolStripMenuItem.Name = "userRoleToolStripMenuItem";
            this.userRoleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.userRoleToolStripMenuItem.Text = "UserRole";
            this.userRoleToolStripMenuItem.Click += new System.EventHandler(this.userRoleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salerToolStripMenuItem});
            this.toolStripMenuItem5.Image = global::unt_bingoo.Properties.Resources.sale;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(65, 22);
            this.toolStripMenuItem5.Text = "Sale";
            // 
            // salerToolStripMenuItem
            // 
            this.salerToolStripMenuItem.Name = "salerToolStripMenuItem";
            this.salerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salerToolStripMenuItem.Text = "Saler";
            this.salerToolStripMenuItem.Click += new System.EventHandler(this.salerToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.product_in_warehouse;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productToolStripMenuItem.Text = "&product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::unt_bingoo.Properties.Resources.category;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "Category";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // outLetToolStripMenuItem
            // 
            this.outLetToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.retail;
            this.outLetToolStripMenuItem.Name = "outLetToolStripMenuItem";
            this.outLetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outLetToolStripMenuItem.Text = "OutLet";
            this.outLetToolStripMenuItem.Click += new System.EventHandler(this.outLetToolStripMenuItem_Click);
            // 
            // currencyToolStripMenuItem
            // 
            this.currencyToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.Currency;
            this.currencyToolStripMenuItem.Name = "currencyToolStripMenuItem";
            this.currencyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.currencyToolStripMenuItem.Text = "Currency";
            this.currencyToolStripMenuItem.Click += new System.EventHandler(this.currencyToolStripMenuItem_Click);
            // 
            // guiBranchToolStripMenuItem
            // 
            this.guiBranchToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.brand;
            this.guiBranchToolStripMenuItem.Name = "guiBranchToolStripMenuItem";
            this.guiBranchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guiBranchToolStripMenuItem.Text = "&Brand";
            this.guiBranchToolStripMenuItem.Click += new System.EventHandler(this.guiBranchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportSaleToolStripMenuItem});
            this.toolStripMenuItem3.Image = global::unt_bingoo.Properties.Resources.reports;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(81, 22);
            this.toolStripMenuItem3.Text = "Report";
            // 
            // reportSaleToolStripMenuItem
            // 
            this.reportSaleToolStripMenuItem.Image = global::unt_bingoo.Properties.Resources.reports;
            this.reportSaleToolStripMenuItem.Name = "reportSaleToolStripMenuItem";
            this.reportSaleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reportSaleToolStripMenuItem.Text = "Report Sale";
            this.reportSaleToolStripMenuItem.Click += new System.EventHandler(this.reportSaleToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Timer loading;
        internal System.Windows.Forms.ToolStripStatusLabel lblversion;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel lblmsgconnection;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuabout;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuexit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuchangepassword;
        private System.Windows.Forms.ToolStripMenuItem mnufile;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem outLetToolStripMenuItem;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem currencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem userRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem reportSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem guiBranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem salerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Customer;
        private System.Windows.Forms.ToolStripMenuItem customerFormToolStripMenuItem;
    }
}



