namespace unt_bingoo.view.Sales
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraGrid.GridControl gridPaymentItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;

        private DevExpress.XtraEditors.LabelControl labelSubtotal;
        private DevExpress.XtraEditors.LabelControl labelDiscount;
        private DevExpress.XtraEditors.LabelControl labelTotal;
        private DevExpress.XtraEditors.LabelControl lblSubTotal;
        private DevExpress.XtraEditors.LabelControl lblDiscount;
        private DevExpress.XtraEditors.LabelControl lblTotal;

        // NEW: currency + cash fields
        private DevExpress.XtraEditors.LabelControl labelCurrency;
        private DevExpress.XtraEditors.ComboBoxEdit cboCurrency;
        private DevExpress.XtraEditors.LabelControl labelCashReceived;
        private DevExpress.XtraEditors.LabelControl labelChange;
        private DevExpress.XtraEditors.TextEdit txtCashReceived;
        private DevExpress.XtraEditors.TextEdit txtChange;

        private DevExpress.XtraEditors.SimpleButton btnPayCash;
        private DevExpress.XtraEditors.SimpleButton btnPayQR;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridPaymentItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelSubtotal = new DevExpress.XtraEditors.LabelControl();
            this.labelDiscount = new DevExpress.XtraEditors.LabelControl();
            this.labelTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscount = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelCurrency = new DevExpress.XtraEditors.LabelControl();
            this.cboCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelCashReceived = new DevExpress.XtraEditors.LabelControl();
            this.labelChange = new DevExpress.XtraEditors.LabelControl();
            this.txtCashReceived = new DevExpress.XtraEditors.TextEdit();
            this.txtChange = new DevExpress.XtraEditors.TextEdit();
            this.btnPayCash = new DevExpress.XtraEditors.SimpleButton();
            this.btnPayQR = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashReceived.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChange.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPaymentItems
            // 
            this.gridPaymentItems.Location = new System.Drawing.Point(10, 10);
            this.gridPaymentItems.MainView = this.gvItems;
            this.gridPaymentItems.Name = "gridPaymentItems";
            this.gridPaymentItems.Size = new System.Drawing.Size(520, 220);
            this.gridPaymentItems.TabIndex = 0;
            this.gridPaymentItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.GridControl = this.gridPaymentItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.Editable = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSubtotal.Appearance.Options.UseFont = true;
            this.labelSubtotal.Location = new System.Drawing.Point(10, 245);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(59, 17);
            this.labelSubtotal.TabIndex = 1;
            this.labelSubtotal.Text = "Sub total :";
            // 
            // labelDiscount
            // 
            this.labelDiscount.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDiscount.Appearance.Options.UseFont = true;
            this.labelDiscount.Location = new System.Drawing.Point(10, 270);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(57, 17);
            this.labelDiscount.TabIndex = 2;
            this.labelDiscount.Text = "Discount :";
            // 
            // labelTotal
            // 
            this.labelTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Appearance.Options.UseFont = true;
            this.labelTotal.Location = new System.Drawing.Point(10, 297);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(44, 20);
            this.labelTotal.TabIndex = 3;
            this.labelTotal.Text = "Total :";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotal.Appearance.Options.UseFont = true;
            this.lblSubTotal.Location = new System.Drawing.Point(130, 245);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(24, 17);
            this.lblSubTotal.TabIndex = 4;
            this.lblSubTotal.Text = "0.00";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscount.Appearance.Options.UseFont = true;
            this.lblDiscount.Location = new System.Drawing.Point(130, 270);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(24, 17);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Location = new System.Drawing.Point(130, 295);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 23);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0.00";
            // 
            // labelCurrency
            // 
            this.labelCurrency.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCurrency.Appearance.Options.UseFont = true;
            this.labelCurrency.Location = new System.Drawing.Point(280, 245);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(58, 17);
            this.labelCurrency.TabIndex = 7;
            this.labelCurrency.Text = "Currency :";
            // 
            // cboCurrency
            // 
            this.cboCurrency.Location = new System.Drawing.Point(360, 242);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCurrency.Properties.Appearance.Options.UseFont = true;
            this.cboCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCurrency.Properties.Items.AddRange(new object[] {
            "USD",
            "KHR"});
            this.cboCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCurrency.Size = new System.Drawing.Size(120, 24);
            this.cboCurrency.TabIndex = 1;
            // 
            // labelCashReceived
            // 
            this.labelCashReceived.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCashReceived.Appearance.Options.UseFont = true;
            this.labelCashReceived.Location = new System.Drawing.Point(10, 328);
            this.labelCashReceived.Name = "labelCashReceived";
            this.labelCashReceived.Size = new System.Drawing.Size(80, 17);
            this.labelCashReceived.TabIndex = 9;
            this.labelCashReceived.Text = "Cash receive :";
            // 
            // labelChange
            // 
            this.labelChange.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelChange.Appearance.Options.UseFont = true;
            this.labelChange.Location = new System.Drawing.Point(10, 356);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(66, 17);
            this.labelChange.TabIndex = 10;
            this.labelChange.Text = "Cash back :";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Location = new System.Drawing.Point(130, 325);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCashReceived.Properties.Appearance.Options.UseFont = true;
            this.txtCashReceived.Properties.Mask.EditMask = "n2";
            this.txtCashReceived.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCashReceived.Size = new System.Drawing.Size(120, 24);
            this.txtCashReceived.TabIndex = 2;
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(130, 353);
            this.txtChange.Name = "txtChange";
            this.txtChange.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChange.Properties.Appearance.Options.UseFont = true;
            this.txtChange.Properties.Mask.EditMask = "n2";
            this.txtChange.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChange.Properties.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(120, 24);
            this.txtChange.TabIndex = 3;
            // 
            // btnPayCash
            // 
            this.btnPayCash.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPayCash.Appearance.Options.UseFont = true;
            this.btnPayCash.ImageOptions.Image = global::unt_bingoo.Properties.Resources.dollar;
            this.btnPayCash.Location = new System.Drawing.Point(280, 320);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(120, 35);
            this.btnPayCash.TabIndex = 4;
            this.btnPayCash.Text = "Pay Cash";
            this.btnPayCash.Click += new System.EventHandler(this.btnPayCash_Click);
            // 
            // btnPayQR
            // 
            this.btnPayQR.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPayQR.Appearance.Options.UseFont = true;
            this.btnPayQR.ImageOptions.Image = global::unt_bingoo.Properties.Resources.qr_code;
            this.btnPayQR.Location = new System.Drawing.Point(280, 360);
            this.btnPayQR.Name = "btnPayQR";
            this.btnPayQR.Size = new System.Drawing.Size(120, 35);
            this.btnPayQR.TabIndex = 5;
            this.btnPayQR.Text = "Pay KHQR";
            this.btnPayQR.Click += new System.EventHandler(this.btnPayQR_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnCancel.Location = new System.Drawing.Point(410, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 75);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPayment
            // 
            this.ClientSize = new System.Drawing.Size(540, 410);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPayQR);
            this.Controls.Add(this.btnPayCash);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.labelCashReceived);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.labelSubtotal);
            this.Controls.Add(this.gridPaymentItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Summary";
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCashReceived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChange.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

