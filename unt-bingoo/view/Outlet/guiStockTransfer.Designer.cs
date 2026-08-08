namespace unt_bingoo.view.Outlet
{
    partial class guiStockTransfer
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
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlEntry = new DevExpress.XtraEditors.PanelControl();
            this.lblEntryTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblOutlet = new DevExpress.XtraEditors.LabelControl();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.lblIngredient = new DevExpress.XtraEditors.LabelControl();
            this.cboIngredient = new System.Windows.Forms.ComboBox();
            this.lblWarehouseStock = new DevExpress.XtraEditors.LabelControl();
            this.txtWarehouseStock = new System.Windows.Forms.TextBox();
            this.lblOutletStock = new DevExpress.XtraEditors.LabelControl();
            this.txtOutletStock = new System.Windows.Forms.TextBox();
            this.lblAfterTransfer = new DevExpress.XtraEditors.LabelControl();
            this.txtAfterTransfer = new System.Windows.Forms.TextBox();
            this.lblQty = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblReason = new DevExpress.XtraEditors.LabelControl();
            this.cboReason = new System.Windows.Forms.ComboBox();
            this.lblUnitPrice = new DevExpress.XtraEditors.LabelControl();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEntry)).BeginInit();
            this.pnlEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1390, 76);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSystemName.Location = new System.Drawing.Point(98, 50);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(291, 26);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "JuJuBi Management System";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Image = global::unt_bingoo.Properties.Resources.ChatGPT_Image_Jun_3__2026__04_25_20_PM2;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(98, 76);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlEntry
            // 
            this.pnlEntry.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlEntry.Appearance.Options.UseBackColor = true;
            this.pnlEntry.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlEntry.Controls.Add(this.lblEntryTitle);
            this.pnlEntry.Controls.Add(this.lblOutlet);
            this.pnlEntry.Controls.Add(this.cboOutlet);
            this.pnlEntry.Controls.Add(this.lblIngredient);
            this.pnlEntry.Controls.Add(this.cboIngredient);
            this.pnlEntry.Controls.Add(this.lblWarehouseStock);
            this.pnlEntry.Controls.Add(this.txtWarehouseStock);
            this.pnlEntry.Controls.Add(this.lblOutletStock);
            this.pnlEntry.Controls.Add(this.txtOutletStock);
            this.pnlEntry.Controls.Add(this.lblAfterTransfer);
            this.pnlEntry.Controls.Add(this.txtAfterTransfer);
            this.pnlEntry.Controls.Add(this.lblQty);
            this.pnlEntry.Controls.Add(this.txtQty);
            this.pnlEntry.Controls.Add(this.lblReason);
            this.pnlEntry.Controls.Add(this.cboReason);
            this.pnlEntry.Controls.Add(this.lblUnitPrice);
            this.pnlEntry.Controls.Add(this.txtUnitPrice);
            this.pnlEntry.Controls.Add(this.lblTotalAmount);
            this.pnlEntry.Controls.Add(this.txtTotalAmount);
            this.pnlEntry.Controls.Add(this.lblNote);
            this.pnlEntry.Controls.Add(this.txtNote);
            this.pnlEntry.Controls.Add(this.btnTransfer);
            this.pnlEntry.Controls.Add(this.btnClear);
            this.pnlEntry.Controls.Add(this.lblStatus);
            this.pnlEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEntry.Location = new System.Drawing.Point(0, 76);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(1390, 270);
            this.pnlEntry.TabIndex = 1;
            // 
            // lblEntryTitle
            // 
            this.lblEntryTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEntryTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblEntryTitle.Appearance.Options.UseFont = true;
            this.lblEntryTitle.Appearance.Options.UseForeColor = true;
            this.lblEntryTitle.Location = new System.Drawing.Point(24, 12);
            this.lblEntryTitle.Name = "lblEntryTitle";
            this.lblEntryTitle.Size = new System.Drawing.Size(360, 21);
            this.lblEntryTitle.TabIndex = 0;
            this.lblEntryTitle.Text = "Transfer Ingredient Stock — Warehouse → Outlet";
            // 
            // lblOutlet
            // 
            this.lblOutlet.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOutlet.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblOutlet.Appearance.Options.UseFont = true;
            this.lblOutlet.Appearance.Options.UseForeColor = true;
            this.lblOutlet.Location = new System.Drawing.Point(24, 44);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(72, 17);
            this.lblOutlet.TabIndex = 1;
            this.lblOutlet.Text = "Outlet (To) :";
            // 
            // cboOutlet
            // 
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(143, 40);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(300, 23);
            this.cboOutlet.TabIndex = 2;
            // 
            // lblIngredient
            // 
            this.lblIngredient.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIngredient.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblIngredient.Appearance.Options.UseFont = true;
            this.lblIngredient.Appearance.Options.UseForeColor = true;
            this.lblIngredient.Location = new System.Drawing.Point(24, 82);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(70, 17);
            this.lblIngredient.TabIndex = 3;
            this.lblIngredient.Text = "Ingredient :";
            // 
            // cboIngredient
            // 
            this.cboIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIngredient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboIngredient.FormattingEnabled = true;
            this.cboIngredient.Location = new System.Drawing.Point(143, 78);
            this.cboIngredient.Name = "cboIngredient";
            this.cboIngredient.Size = new System.Drawing.Size(300, 23);
            this.cboIngredient.TabIndex = 4;
            // 
            // lblWarehouseStock
            // 
            this.lblWarehouseStock.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblWarehouseStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblWarehouseStock.Appearance.Options.UseFont = true;
            this.lblWarehouseStock.Appearance.Options.UseForeColor = true;
            this.lblWarehouseStock.Location = new System.Drawing.Point(473, 44);
            this.lblWarehouseStock.Name = "lblWarehouseStock";
            this.lblWarehouseStock.Size = new System.Drawing.Size(113, 17);
            this.lblWarehouseStock.TabIndex = 5;
            this.lblWarehouseStock.Text = "Warehouse Stock :";
            // 
            // txtWarehouseStock
            // 
            this.txtWarehouseStock.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtWarehouseStock.Location = new System.Drawing.Point(613, 40);
            this.txtWarehouseStock.Name = "txtWarehouseStock";
            this.txtWarehouseStock.ReadOnly = true;
            this.txtWarehouseStock.Size = new System.Drawing.Size(120, 22);
            this.txtWarehouseStock.TabIndex = 6;
            // 
            // lblOutletStock
            // 
            this.lblOutletStock.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOutletStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblOutletStock.Appearance.Options.UseFont = true;
            this.lblOutletStock.Appearance.Options.UseForeColor = true;
            this.lblOutletStock.Location = new System.Drawing.Point(473, 82);
            this.lblOutletStock.Name = "lblOutletStock";
            this.lblOutletStock.Size = new System.Drawing.Size(122, 17);
            this.lblOutletStock.TabIndex = 7;
            this.lblOutletStock.Text = "Outlet Stock (Now) :";
            // 
            // txtOutletStock
            // 
            this.txtOutletStock.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtOutletStock.Location = new System.Drawing.Point(613, 78);
            this.txtOutletStock.Name = "txtOutletStock";
            this.txtOutletStock.ReadOnly = true;
            this.txtOutletStock.Size = new System.Drawing.Size(120, 22);
            this.txtOutletStock.TabIndex = 8;
            // 
            // lblAfterTransfer
            // 
            this.lblAfterTransfer.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAfterTransfer.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblAfterTransfer.Appearance.Options.UseFont = true;
            this.lblAfterTransfer.Appearance.Options.UseForeColor = true;
            this.lblAfterTransfer.Location = new System.Drawing.Point(763, 44);
            this.lblAfterTransfer.Name = "lblAfterTransfer";
            this.lblAfterTransfer.Size = new System.Drawing.Size(90, 17);
            this.lblAfterTransfer.TabIndex = 9;
            this.lblAfterTransfer.Text = "After Transfer :";
            // 
            // txtAfterTransfer
            // 
            this.txtAfterTransfer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.txtAfterTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(122)))), ((int)(((byte)(56)))));
            this.txtAfterTransfer.Location = new System.Drawing.Point(863, 40);
            this.txtAfterTransfer.Name = "txtAfterTransfer";
            this.txtAfterTransfer.ReadOnly = true;
            this.txtAfterTransfer.Size = new System.Drawing.Size(90, 22);
            this.txtAfterTransfer.TabIndex = 10;
            // 
            // lblQty
            // 
            this.lblQty.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblQty.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblQty.Appearance.Options.UseFont = true;
            this.lblQty.Appearance.Options.UseForeColor = true;
            this.lblQty.Location = new System.Drawing.Point(24, 120);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(82, 17);
            this.lblQty.TabIndex = 11;
            this.lblQty.Text = "Transfer Qty :";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQty.Location = new System.Drawing.Point(143, 116);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(120, 23);
            this.txtQty.TabIndex = 12;
            // 
            // lblReason
            // 
            this.lblReason.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReason.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblReason.Appearance.Options.UseFont = true;
            this.lblReason.Appearance.Options.UseForeColor = true;
            this.lblReason.Location = new System.Drawing.Point(293, 120);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(51, 17);
            this.lblReason.TabIndex = 13;
            this.lblReason.Text = "Reason :";
            // 
            // cboReason
            // 
            this.cboReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboReason.FormattingEnabled = true;
            this.cboReason.Items.AddRange(new object[] {
            "Initial stock for outlet",
            "Restock",
            "Correction",
            "Other"});
            this.cboReason.Location = new System.Drawing.Point(363, 116);
            this.cboReason.Name = "cboReason";
            this.cboReason.Size = new System.Drawing.Size(220, 23);
            this.cboReason.TabIndex = 14;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnitPrice.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(95)))), ((int)(((byte)(6)))));
            this.lblUnitPrice.Appearance.Options.UseFont = true;
            this.lblUnitPrice.Appearance.Options.UseForeColor = true;
            this.lblUnitPrice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUnitPrice.Location = new System.Drawing.Point(603, 120);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(70, 17);
            this.lblUnitPrice.TabIndex = 15;
            this.lblUnitPrice.Text = "Unit Price :";
            this.lblUnitPrice.Visible = false;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUnitPrice.Location = new System.Drawing.Point(678, 116);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(70, 23);
            this.txtUnitPrice.TabIndex = 16;
            this.txtUnitPrice.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblTotalAmount.Appearance.Options.UseFont = true;
            this.lblTotalAmount.Appearance.Options.UseForeColor = true;
            this.lblTotalAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalAmount.Location = new System.Drawing.Point(758, 120);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(45, 17);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Total :";
            this.lblTotalAmount.Visible = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.Location = new System.Drawing.Point(809, 116);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.txtTotalAmount.TabIndex = 18;
            this.txtTotalAmount.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNote.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblNote.Appearance.Options.UseFont = true;
            this.lblNote.Appearance.Options.UseForeColor = true;
            this.lblNote.Location = new System.Drawing.Point(24, 158);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(37, 17);
            this.lblNote.TabIndex = 19;
            this.lblNote.Text = "Note :";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.Location = new System.Drawing.Point(143, 154);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(720, 23);
            this.txtNote.TabIndex = 20;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.btnTransfer.FlatAppearance.BorderSize = 0;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(763, 190);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(110, 32);
            this.btnTransfer.TabIndex = 21;
            this.btnTransfer.Text = "Transfer Stock";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClear.Location = new System.Drawing.Point(883, 190);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(158)))));
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(24, 232);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(730, 18);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Pick an outlet, add each ingredient to the list, then Save && Export All.";
            // 
            // guiStockTransfer
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 737);
            this.Controls.Add(this.pnlEntry);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "guiStockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INGREDIENT STOCK TRANSFER";
            this.Load += new System.EventHandler(this.guiStockTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEntry)).EndInit();
            this.pnlEntry.ResumeLayout(false);
            this.pnlEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private System.Windows.Forms.PictureBox picLogo;

        private DevExpress.XtraEditors.PanelControl pnlEntry;
        private DevExpress.XtraEditors.LabelControl lblEntryTitle;
        private DevExpress.XtraEditors.LabelControl lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private DevExpress.XtraEditors.LabelControl lblIngredient;
        private System.Windows.Forms.ComboBox cboIngredient;
        private DevExpress.XtraEditors.LabelControl lblWarehouseStock;
        private System.Windows.Forms.TextBox txtWarehouseStock;
        private DevExpress.XtraEditors.LabelControl lblOutletStock;
        private System.Windows.Forms.TextBox txtOutletStock;
        private DevExpress.XtraEditors.LabelControl lblAfterTransfer;
        private System.Windows.Forms.TextBox txtAfterTransfer;
        private DevExpress.XtraEditors.LabelControl lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private DevExpress.XtraEditors.LabelControl lblReason;
        private System.Windows.Forms.ComboBox cboReason;
        private DevExpress.XtraEditors.LabelControl lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private DevExpress.XtraEditors.LabelControl lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnClear;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}
