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
                components.Dispose();

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

            // GRID
            this.gridPaymentItems.Location = new System.Drawing.Point(10, 10);
            this.gridPaymentItems.MainView = this.gvItems;
            this.gridPaymentItems.Name = "gridPaymentItems";
            this.gridPaymentItems.Size = new System.Drawing.Size(660, 260);
            this.gridPaymentItems.TabIndex = 0;
            this.gridPaymentItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvItems });

            // GRID VIEW
            this.gvItems.GridControl = this.gridPaymentItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.Editable = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;

            // LABELS
            this.labelSubtotal.Location = new System.Drawing.Point(20, 285);
            this.labelSubtotal.Text = "Sub total :";

            this.labelDiscount.Location = new System.Drawing.Point(20, 310);
            this.labelDiscount.Text = "Discount :";

            this.labelTotal.Location = new System.Drawing.Point(20, 335);
            this.labelTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Text = "Total :";

            this.lblSubTotal.Location = new System.Drawing.Point(130, 285);
            this.lblSubTotal.Text = "0.00";

            this.lblDiscount.Location = new System.Drawing.Point(130, 310);
            this.lblDiscount.Text = "0.00";

            this.lblTotal.Location = new System.Drawing.Point(130, 330);
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Text = "0.00";

            // CURRENCY
            this.labelCurrency.Location = new System.Drawing.Point(360, 285);
            this.labelCurrency.Text = "Currency :";

            this.cboCurrency.Location = new System.Drawing.Point(440, 282);
            this.cboCurrency.Properties.Items.AddRange(new object[] { "USD", "KHR" });
            this.cboCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // CASH RECEIVE
            this.labelCashReceived.Location = new System.Drawing.Point(360, 310);
            this.labelCashReceived.Text = "Cash receive :";

            this.txtCashReceived.Location = new System.Drawing.Point(440, 307);
            this.txtCashReceived.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCashReceived.Properties.Mask.EditMask = "n2";
            this.txtCashReceived.EditValueChanged += new System.EventHandler(this.txtCashReceived_EditValueChanged);

            // CHANGE
            this.labelChange.Location = new System.Drawing.Point(360, 335);
            this.labelChange.Text = "Cash back :";

            this.txtChange.Location = new System.Drawing.Point(440, 332);
            this.txtChange.Properties.ReadOnly = true;

            // BUTTON CASH
            this.btnPayCash.Location = new System.Drawing.Point(200, 380);
            this.btnPayCash.Size = new System.Drawing.Size(140, 40);
            this.btnPayCash.Text = "Pay Cash";
            this.btnPayCash.Click += new System.EventHandler(this.btnPayCash_Click);

            // BUTTON QR
            this.btnPayQR.Location = new System.Drawing.Point(350, 380);
            this.btnPayQR.Size = new System.Drawing.Size(140, 40);
            this.btnPayQR.Text = "Pay KHQR";
            this.btnPayQR.Click += new System.EventHandler(this.btnPayQR_Click);

            // BUTTON CANCEL
            this.btnCancel.Location = new System.Drawing.Point(500, 380);
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FORM
            this.ClientSize = new System.Drawing.Size(680, 440);
            this.Controls.Add(this.gridPaymentItems);
            this.Controls.Add(this.labelSubtotal);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.labelCashReceived);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.btnPayCash);
            this.Controls.Add(this.btnPayQR);
            this.Controls.Add(this.btnCancel);

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