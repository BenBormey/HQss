namespace unt_bingoo.view.Branch
{
    partial class test
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpPurchaseSetting;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpPurchaseSetting = new System.Windows.Forms.GroupBox();
            this.nudVat = new System.Windows.Forms.NumericUpDown();
            this.lblVat = new System.Windows.Forms.Label();
            this.nudOrderLevel = new System.Windows.Forms.NumericUpDown();
            this.lblOrderLevel = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.nudDayOrder = new System.Windows.Forms.NumericUpDown();
            this.lblDayOrder = new System.Windows.Forms.Label();
            this.nudTermDays = new System.Windows.Forms.NumericUpDown();
            this.lblTermDays = new System.Windows.Forms.Label();
            this.grpPurchaseSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTermDays)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPurchaseSetting
            // 
            this.grpPurchaseSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPurchaseSetting.Controls.Add(this.lblTermDays);
            this.grpPurchaseSetting.Controls.Add(this.nudTermDays);
            this.grpPurchaseSetting.Controls.Add(this.lblDayOrder);
            this.grpPurchaseSetting.Controls.Add(this.nudDayOrder);
            this.grpPurchaseSetting.Controls.Add(this.lblCountry);
            this.grpPurchaseSetting.Controls.Add(this.cboCountry);
            this.grpPurchaseSetting.Controls.Add(this.lblOrderLevel);
            this.grpPurchaseSetting.Controls.Add(this.nudOrderLevel);
            this.grpPurchaseSetting.Controls.Add(this.lblVat);
            this.grpPurchaseSetting.Controls.Add(this.nudVat);
            this.grpPurchaseSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPurchaseSetting.Location = new System.Drawing.Point(12, 12);
            this.grpPurchaseSetting.Name = "grpPurchaseSetting";
            this.grpPurchaseSetting.Size = new System.Drawing.Size(920, 120);
            this.grpPurchaseSetting.TabIndex = 0;
            this.grpPurchaseSetting.TabStop = false;
            this.grpPurchaseSetting.Text = "Purchase Setting";
            // 
            // nudVat
            // 
            this.nudVat.DecimalPlaces = 2;
            this.nudVat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudVat.Location = new System.Drawing.Point(400, 77);
            this.nudVat.Name = "nudVat";
            this.nudVat.Size = new System.Drawing.Size(110, 25);
            this.nudVat.TabIndex = 9;
            this.nudVat.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVat.Location = new System.Drawing.Point(280, 82);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(47, 15);
            this.lblVat.TabIndex = 8;
            this.lblVat.Text = "VAT (%)";
            // 
            // nudOrderLevel
            // 
            this.nudOrderLevel.DecimalPlaces = 2;
            this.nudOrderLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudOrderLevel.Location = new System.Drawing.Point(140, 77);
            this.nudOrderLevel.Name = "nudOrderLevel";
            this.nudOrderLevel.Size = new System.Drawing.Size(110, 25);
            this.nudOrderLevel.TabIndex = 7;
            this.nudOrderLevel.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblOrderLevel
            // 
            this.lblOrderLevel.AutoSize = true;
            this.lblOrderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderLevel.Location = new System.Drawing.Point(18, 82);
            this.lblOrderLevel.Name = "lblOrderLevel";
            this.lblOrderLevel.Size = new System.Drawing.Size(99, 15);
            this.lblOrderLevel.TabIndex = 6;
            this.lblOrderLevel.Text = "Set % Order Level";
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCountry.Items.AddRange(new object[] {
            "Cambodia",
            "Vietnam",
            "Thailand",
            "China"});
            this.cboCountry.Location = new System.Drawing.Point(690, 30);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(190, 25);
            this.cboCountry.TabIndex = 5;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCountry.Location = new System.Drawing.Point(540, 35);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(115, 15);
            this.lblCountry.TabIndex = 4;
            this.lblCountry.Text = "Country of Purchase";
            // 
            // nudDayOrder
            // 
            this.nudDayOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDayOrder.Location = new System.Drawing.Point(400, 30);
            this.nudDayOrder.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDayOrder.Name = "nudDayOrder";
            this.nudDayOrder.Size = new System.Drawing.Size(110, 25);
            this.nudDayOrder.TabIndex = 3;
            this.nudDayOrder.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblDayOrder
            // 
            this.lblDayOrder.AutoSize = true;
            this.lblDayOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDayOrder.Location = new System.Drawing.Point(280, 35);
            this.lblDayOrder.Name = "lblDayOrder";
            this.lblDayOrder.Size = new System.Drawing.Size(96, 15);
            this.lblDayOrder.TabIndex = 2;
            this.lblDayOrder.Text = "Day Order (Days)";
            // 
            // nudTermDays
            // 
            this.nudTermDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTermDays.Location = new System.Drawing.Point(140, 30);
            this.nudTermDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudTermDays.Name = "nudTermDays";
            this.nudTermDays.Size = new System.Drawing.Size(110, 25);
            this.nudTermDays.TabIndex = 1;
            this.nudTermDays.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblTermDays
            // 
            this.lblTermDays.AutoSize = true;
            this.lblTermDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTermDays.Location = new System.Drawing.Point(18, 35);
            this.lblTermDays.Name = "lblTermDays";
            this.lblTermDays.Size = new System.Drawing.Size(69, 15);
            this.lblTermDays.TabIndex = 0;
            this.lblTermDays.Text = "Term (Days)";
            // 
            // test
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 450);
            this.Controls.Add(this.grpPurchaseSetting);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Setting";
            this.grpPurchaseSetting.ResumeLayout(false);
            this.grpPurchaseSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTermDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTermDays;
        private System.Windows.Forms.NumericUpDown nudTermDays;
        private System.Windows.Forms.Label lblDayOrder;
        private System.Windows.Forms.NumericUpDown nudDayOrder;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label lblOrderLevel;
        private System.Windows.Forms.NumericUpDown nudOrderLevel;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.NumericUpDown nudVat;
    }
}