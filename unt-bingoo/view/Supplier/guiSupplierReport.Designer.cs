namespace unt_bingoo.view.Supplier
{
    partial class guiSupplierReport
    {
        /// <summary> Required designer variable. </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> Clean up any resources being used. </summary>
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
            this.pnlOptions = new DevExpress.XtraEditors.PanelControl();
            this.chkBuyinPrice = new DevExpress.XtraEditors.CheckEdit();
            this.chkSellingPrice = new DevExpress.XtraEditors.CheckEdit();
            this.chkPicture = new DevExpress.XtraEditors.CheckEdit();
            this.chkRemoveDC = new DevExpress.XtraEditors.CheckEdit();
            this.chkRemoveOutOfStock = new DevExpress.XtraEditors.CheckEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.pnlOptions)).BeginInit();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBuyinPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSellingPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveDC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveOutOfStock.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkBuyinPrice);
            this.pnlOptions.Controls.Add(this.chkSellingPrice);
            this.pnlOptions.Controls.Add(this.chkPicture);
            this.pnlOptions.Controls.Add(this.chkRemoveDC);
            this.pnlOptions.Controls.Add(this.chkRemoveOutOfStock);
            this.pnlOptions.Location = new System.Drawing.Point(12, 12);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(348, 185);
            this.pnlOptions.TabIndex = 0;
            // 
            // chkBuyinPrice
            // 
            this.chkBuyinPrice.Location = new System.Drawing.Point(18, 15);
            this.chkBuyinPrice.Name = "chkBuyinPrice";
            this.chkBuyinPrice.Properties.Caption = "With Buyin Price";
            this.chkBuyinPrice.Size = new System.Drawing.Size(300, 20);
            this.chkBuyinPrice.TabIndex = 0;
            // 
            // chkSellingPrice
            // 
            this.chkSellingPrice.Location = new System.Drawing.Point(18, 50);
            this.chkSellingPrice.Name = "chkSellingPrice";
            this.chkSellingPrice.Properties.Caption = "With Selling Price";
            this.chkSellingPrice.Size = new System.Drawing.Size(300, 20);
            this.chkSellingPrice.TabIndex = 1;
            // 
            // chkPicture
            // 
            this.chkPicture.Location = new System.Drawing.Point(18, 85);
            this.chkPicture.Name = "chkPicture";
            this.chkPicture.Properties.Caption = "With Picture";
            this.chkPicture.Size = new System.Drawing.Size(300, 20);
            this.chkPicture.TabIndex = 2;
            // 
            // chkRemoveDC
            // 
            this.chkRemoveDC.Location = new System.Drawing.Point(18, 120);
            this.chkRemoveDC.Name = "chkRemoveDC";
            this.chkRemoveDC.Properties.Caption = "Remove DC Items";
            this.chkRemoveDC.Size = new System.Drawing.Size(300, 20);
            this.chkRemoveDC.TabIndex = 3;
            // 
            // chkRemoveOutOfStock
            // 
            this.chkRemoveOutOfStock.Location = new System.Drawing.Point(18, 155);
            this.chkRemoveOutOfStock.Name = "chkRemoveOutOfStock";
            this.chkRemoveOutOfStock.Properties.Caption = "Remove Items Out of Stock";
            this.chkRemoveOutOfStock.Size = new System.Drawing.Size(300, 20);
            this.chkRemoveOutOfStock.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExport.Location = new System.Drawing.Point(95, 208);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 32);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(255, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // guiSupplierReport
            // 
            this.AcceptButton = this.btnExport;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 252);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlOptions);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiSupplierReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Excel";

            ((System.ComponentModel.ISupportInitialize)(this.chkBuyinPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSellingPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveDC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemoveOutOfStock.Properties)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOptions)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlOptions;
        private DevExpress.XtraEditors.CheckEdit chkBuyinPrice;
        private DevExpress.XtraEditors.CheckEdit chkSellingPrice;
        private DevExpress.XtraEditors.CheckEdit chkPicture;
        private DevExpress.XtraEditors.CheckEdit chkRemoveDC;
        private DevExpress.XtraEditors.CheckEdit chkRemoveOutOfStock;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}