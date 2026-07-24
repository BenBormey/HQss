
namespace unt_bingoo.view.Vat
{
    partial class guiVateSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblVatCaption = new System.Windows.Forms.Label();
            this.numPercent = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            this.SuspendLayout();
            //
            // lblInfo
            //
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(20, 18);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(320, 36);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "VAT rate applied to every order (added on top of the price).";
            //
            // lblVatCaption
            //
            this.lblVatCaption.AutoSize = true;
            this.lblVatCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVatCaption.Location = new System.Drawing.Point(20, 66);
            this.lblVatCaption.Name = "lblVatCaption";
            this.lblVatCaption.Size = new System.Drawing.Size(52, 19);
            this.lblVatCaption.TabIndex = 1;
            this.lblVatCaption.Text = "VAT %";
            //
            // numPercent
            //
            this.numPercent.DecimalPlaces = 2;
            this.numPercent.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numPercent.Location = new System.Drawing.Point(20, 90);
            this.numPercent.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(140, 32);
            this.numPercent.TabIndex = 2;
            this.numPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(109, 40, 217);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(180, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // lblStatus
            //
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(320, 44);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "";
            //
            // guiVateSetting
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 200);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPercent);
            this.Controls.Add(this.lblVatCaption);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiVateSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAT Setting";
            this.Load += new System.EventHandler(this.guiVateSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblVatCaption;
        private System.Windows.Forms.NumericUpDown numPercent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
    }
}
