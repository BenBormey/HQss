
namespace unt_bingoo.view.Product
{
    partial class FrmProductsCaseNumber
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
            this.Panel30 = new System.Windows.Forms.Panel();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.PanelAlert = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnClearPackNumber = new System.Windows.Forms.Button();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Panel30.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel30
            // 
            this.Panel30.Controls.Add(this.TxtBarcode);
            this.Panel30.Controls.Add(this.Label31);
            this.Panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel30.Location = new System.Drawing.Point(0, 19);
            this.Panel30.Name = "Panel30";
            this.Panel30.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Panel30.Size = new System.Drawing.Size(373, 29);
            this.Panel30.TabIndex = 18;
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBarcode.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TxtBarcode.Location = new System.Drawing.Point(172, 5);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(199, 20);
            this.TxtBarcode.TabIndex = 10;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            this.TxtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBarcode_KeyPress);
            // 
            // Label31
            // 
            this.Label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label31.ForeColor = System.Drawing.Color.Black;
            this.Label31.Location = new System.Drawing.Point(2, 5);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(170, 19);
            this.Label31.TabIndex = 0;
            this.Label31.Text = "If any, enter the new barcode";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PanelAlert
            // 
            this.PanelAlert.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelAlert.Location = new System.Drawing.Point(0, 0);
            this.PanelAlert.Name = "PanelAlert";
            this.PanelAlert.Size = new System.Drawing.Size(373, 20);
            this.PanelAlert.TabIndex = 17;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnClearPackNumber);
            this.Panel2.Controls.Add(this.BtnChange);
            this.Panel2.Controls.Add(this.BtnCancel);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 48);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(373, 42);
            this.Panel2.TabIndex = 19;
            // 
            // BtnClearPackNumber
            // 
            this.BtnClearPackNumber.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClearPackNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearPackNumber.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnClearPackNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnClearPackNumber.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearPackNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnClearPackNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClearPackNumber.Location = new System.Drawing.Point(2, 2);
            this.BtnClearPackNumber.Name = "BtnClearPackNumber";
            this.BtnClearPackNumber.Size = new System.Drawing.Size(125, 38);
            this.BtnClearPackNumber.TabIndex = 130;
            this.BtnClearPackNumber.Text = "Clear Case &Number";
            this.BtnClearPackNumber.UseVisualStyleBackColor = false;
            this.BtnClearPackNumber.Click += new System.EventHandler(this.BtnClearPackNumber_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.BackColor = System.Drawing.SystemColors.Control;
            this.BtnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnChange.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnChange.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnChange.Location = new System.Drawing.Point(198, 2);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(89, 38);
            this.BtnChange.TabIndex = 129;
            this.BtnChange.Text = "&Ok";
            this.BtnChange.UseVisualStyleBackColor = false;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.Location = new System.Drawing.Point(287, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(84, 38);
            this.BtnCancel.TabIndex = 128;
            this.BtnCancel.Text = "C&ancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmProductsCaseNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 90);
            this.Controls.Add(this.Panel30);
            this.Controls.Add(this.PanelAlert);
            this.Controls.Add(this.Panel2);
            this.Name = "FrmProductsCaseNumber";
            this.Text = "FrmProductsCaseNumber";
            this.Load += new System.EventHandler(this.FrmProductsCaseNumber_Load);
            this.Panel30.ResumeLayout(false);
            this.Panel30.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel30;
        internal System.Windows.Forms.TextBox TxtBarcode;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Panel PanelAlert;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnClearPackNumber;
        internal System.Windows.Forms.Button BtnChange;
        internal System.Windows.Forms.Button BtnCancel;
    }
}