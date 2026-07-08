namespace unt_bingoo.view
{
    partial class gui_loading
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblLoading;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblLoading = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoading
            // 
            this.lblLoading.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLoading.Appearance.Options.UseFont = true;
            this.lblLoading.Appearance.Options.UseTextOptions = true;
            this.lblLoading.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Padding = new System.Windows.Forms.Padding(10);
            this.lblLoading.Size = new System.Drawing.Size(222, 40);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Loading report, please wait...";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.EditValue = 0;
            this.progressBar.Location = new System.Drawing.Point(0, 40);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.MarqueeAnimationSpeed = 30;
            this.progressBar.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.progressBar.Size = new System.Drawing.Size(252, 0);
            this.progressBar.TabIndex = 0;
            // 
            // gui_loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 22);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gui_loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
