namespace unt_bingoo.view.Sales
{
    partial class frmQRPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraGrid.GridControl gridPaymentItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.LabelControl labelTitle;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.PictureEdit picQR;
        private DevExpress.XtraEditors.SimpleButton btnBack;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.gridPaymentItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.picQR = new DevExpress.XtraEditors.PictureEdit();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPaymentItems
            // 
            this.gridPaymentItems.Location = new System.Drawing.Point(5, 5);
            this.gridPaymentItems.MainView = this.gvItems;
            this.gridPaymentItems.Name = "gridPaymentItems";
            this.gridPaymentItems.Size = new System.Drawing.Size(420, 380);
            this.gridPaymentItems.TabIndex = 0;
            this.gridPaymentItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.GridControl = this.gridPaymentItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsView.ShowGroupPanel = false;
            // 
            // labelTitle
            // 
            this.labelTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelTitle.Appearance.Options.UseFont = true;
            this.labelTitle.Location = new System.Drawing.Point(445, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(96, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Total Payment:";
            // 
            // lblAmount
            // 
            this.lblAmount.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Appearance.Options.UseFont = true;
            this.lblAmount.Location = new System.Drawing.Point(560, 15);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(29, 20);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "0.00";
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(445, 50);
            this.picQR.Name = "picQR";
            this.picQR.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picQR.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picQR.Size = new System.Drawing.Size(260, 240);
            this.picQR.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Location = new System.Drawing.Point(445, 310);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(260, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmQRPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 390);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.gridPaymentItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmQRPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KHQR Payment";
            this.Load += new System.EventHandler(this.frmQRPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
