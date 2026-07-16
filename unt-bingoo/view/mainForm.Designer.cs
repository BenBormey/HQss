
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
            this.createUserProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuexit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnufile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuchangepassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupOutletMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupBankMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // createUserProfileToolStripMenuItem
            // 
            this.createUserProfileToolStripMenuItem.Name = "createUserProfileToolStripMenuItem";
            this.createUserProfileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createUserProfileToolStripMenuItem.Text = "Create User Profile";
            this.createUserProfileToolStripMenuItem.Click += new System.EventHandler(this.createUserProfileToolStripMenuItem_Click);
            // 
            // mnuexit
            // 
            this.mnuexit.Name = "mnuexit";
            this.mnuexit.Size = new System.Drawing.Size(202, 22);
            this.mnuexit.Text = "E&xit";
            this.mnuexit.Click += new System.EventHandler(this.mnuexit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // mnufile
            // 
            this.mnufile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripSeparator2,
            this.paymentToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItem5,
            this.toolStripSeparator7,
            this.supplierToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripSeparator3,
            this.toolStripMenuItem3,
            this.toolStripSeparator6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem1,
            this.mnuchangepassword,
            this.mnuexit,
            this.createUserProfileToolStripMenuItem});
            this.mnufile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.mnufile.Name = "mnufile";
            this.mnufile.Size = new System.Drawing.Size(63, 22);
            this.mnufile.Text = "&File     ";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::unt_bingoo.Properties.Resources.Currency;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem6.Text = "Exchange Rate";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.currencyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 22);
            this.toolStripSeparator2.Text = "Create Currency";
            this.toolStripSeparator2.Click += new System.EventHandler(this.toolStripSeparator2_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.paymentToolStripMenuItem.Text = "&Create Category";
            this.paymentToolStripMenuItem.Click += new System.EventHandler(this.paymentToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::unt_bingoo.Properties.Resources.retail;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem5.Text = "&Create OutLet";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.outLetToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(199, 6);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.supplierToolStripMenuItem.Text = "Create Supplier";
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.supplierToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::unt_bingoo.Properties.Resources.product_in_warehouse;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem2.Text = "&Create Product";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::unt_bingoo.Properties.Resources.category;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem3.Text = "&Create User";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            this.toolStripSeparator6.Visible = false;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::unt_bingoo.Properties.Resources.brand;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem7.Text = "&Brand";
            this.toolStripMenuItem7.Visible = false;
            this.toolStripMenuItem7.Click += new System.EventHandler(this.guiBranchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::unt_bingoo.Properties.Resources.Supplier1;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem8.Text = "Suppliers";
            this.toolStripMenuItem8.Visible = false;
            this.toolStripMenuItem8.Click += new System.EventHandler(this.suppliersToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::unt_bingoo.Properties.Resources.in_stock;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem9.Text = "StockProduct";
            this.toolStripMenuItem9.Visible = false;
            this.toolStripMenuItem9.Click += new System.EventHandler(this.stockProductToolStripMenuItem_Click);
            // 
            // mnuchangepassword
            // 
            this.mnuchangepassword.Image = ((System.Drawing.Image)(resources.GetObject("mnuchangepassword.Image")));
            this.mnuchangepassword.Name = "mnuchangepassword";
            this.mnuchangepassword.Size = new System.Drawing.Size(202, 22);
            this.mnuchangepassword.Text = "&Change Password";
            this.mnuchangepassword.Click += new System.EventHandler(this.mnuchangepassword_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnufile,
            this.reportToolStripMenuItem,
            this.menuItemToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "MenuStrip";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // supplierReportToolStripMenuItem
            // 
            this.supplierReportToolStripMenuItem.Name = "supplierReportToolStripMenuItem";
            this.supplierReportToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.supplierReportToolStripMenuItem.Text = "Supplier Report";
            this.supplierReportToolStripMenuItem.Click += new System.EventHandler(this.supplierReportToolStripMenuItem_Click);
            // 
            // menuItemToolStripMenuItem
            // 
            this.menuItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupOutletMenuToolStripMenuItem,
            this.setupBankMenuToolStripMenuItem});
            this.menuItemToolStripMenuItem.Name = "menuItemToolStripMenuItem";
            this.menuItemToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
            this.menuItemToolStripMenuItem.Text = "Menu";
            this.menuItemToolStripMenuItem.Click += new System.EventHandler(this.menuItemToolStripMenuItem_Click);
            // 
            // setupOutletMenuToolStripMenuItem
            // 
            this.setupOutletMenuToolStripMenuItem.Name = "setupOutletMenuToolStripMenuItem";
            this.setupOutletMenuToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setupOutletMenuToolStripMenuItem.Text = "Setup Outlet Menu";
            this.setupOutletMenuToolStripMenuItem.Click += new System.EventHandler(this.setupOutletMenuToolStripMenuItem_Click);
            // 
            // setupBankMenuToolStripMenuItem
            // 
            this.setupBankMenuToolStripMenuItem.Name = "setupBankMenuToolStripMenuItem";
            this.setupBankMenuToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setupBankMenuToolStripMenuItem.Text = "Setup Bank Menu";
            this.setupBankMenuToolStripMenuItem.Click += new System.EventHandler(this.setupBankMenuToolStripMenuItem_Click);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCustomerToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // createCustomerToolStripMenuItem
            // 
            this.createCustomerToolStripMenuItem.Name = "createCustomerToolStripMenuItem";
            this.createCustomerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.createCustomerToolStripMenuItem.Text = "CreateCustomer";
            this.createCustomerToolStripMenuItem.Click += new System.EventHandler(this.createCustomerToolStripMenuItem_Click);
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
            this.Text = "MD JuJuBi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
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
        private System.Windows.Forms.ToolStripMenuItem createUserProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuexit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuchangepassword;
        private System.Windows.Forms.ToolStripMenuItem mnufile;
        private System.Windows.Forms.MenuStrip menuStrip;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupOutletMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupBankMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCustomerToolStripMenuItem;
    }
}



