
namespace unt_bingoo.view.Product
{
    partial class FrmProductsBarcode
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
            this.PanelAlert = new System.Windows.Forms.Panel();
            this.Label18 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel30 = new System.Windows.Forms.Panel();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.Panel53 = new System.Windows.Forms.Panel();
            this.CmbSpecial = new System.Windows.Forms.ComboBox();
            this.Label57 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnSetAsOldCode = new System.Windows.Forms.Button();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PanelAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel30.SuspendLayout();
            this.Panel53.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelAlert
            // 
            this.PanelAlert.Controls.Add(this.Label18);
            this.PanelAlert.Controls.Add(this.PictureBox1);
            this.PanelAlert.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelAlert.Location = new System.Drawing.Point(0, 0);
            this.PanelAlert.Name = "PanelAlert";
            this.PanelAlert.Size = new System.Drawing.Size(412, 20);
            this.PanelAlert.TabIndex = 17;
            // 
            // Label18
            // 
            this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label18.Location = new System.Drawing.Point(20, 0);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Label18.Size = new System.Drawing.Size(392, 20);
            this.Label18.TabIndex = 2;
            this.Label18.Text = "When change item code must check Pack Number, Case Number.";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Help;
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(20, 20);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 3;
            this.PictureBox1.TabStop = false;
            // 
            // Panel30
            // 
            this.Panel30.Controls.Add(this.TxtBarcode);
            this.Panel30.Controls.Add(this.Panel53);
            this.Panel30.Controls.Add(this.Label31);
            this.Panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel30.Location = new System.Drawing.Point(0, 26);
            this.Panel30.Name = "Panel30";
            this.Panel30.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.Panel30.Size = new System.Drawing.Size(412, 48);
            this.Panel30.TabIndex = 18;
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtBarcode.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TxtBarcode.Location = new System.Drawing.Point(214, 23);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(196, 20);
            this.TxtBarcode.TabIndex = 10;
            this.TxtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBarcode_KeyPress);
            this.TxtBarcode.Leave += new System.EventHandler(this.TxtBarcode_Leave);
            this.TxtBarcode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TxtBarcode_PreviewKeyDown);
            // 
            // Panel53
            // 
            this.Panel53.Controls.Add(this.CmbSpecial);
            this.Panel53.Controls.Add(this.Label57);
            this.Panel53.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel53.Location = new System.Drawing.Point(153, 5);
            this.Panel53.Name = "Panel53";
            this.Panel53.Padding = new System.Windows.Forms.Padding(2);
            this.Panel53.Size = new System.Drawing.Size(61, 38);
            this.Panel53.TabIndex = 11;
            // 
            // CmbSpecial
            // 
            this.CmbSpecial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmbSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSpecial.FormattingEnabled = true;
            this.CmbSpecial.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.CmbSpecial.Location = new System.Drawing.Point(2, 17);
            this.CmbSpecial.Name = "CmbSpecial";
            this.CmbSpecial.Size = new System.Drawing.Size(57, 21);
            this.CmbSpecial.TabIndex = 2;
            // 
            // Label57
            // 
            this.Label57.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label57.ForeColor = System.Drawing.Color.Black;
            this.Label57.Location = new System.Drawing.Point(2, 2);
            this.Label57.Name = "Label57";
            this.Label57.Size = new System.Drawing.Size(57, 15);
            this.Label57.TabIndex = 0;
            this.Label57.Text = "Special";
            // 
            // Label31
            // 
            this.Label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label31.ForeColor = System.Drawing.Color.Black;
            this.Label31.Location = new System.Drawing.Point(2, 5);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(151, 38);
            this.Label31.TabIndex = 0;
            this.Label31.Text = "If any, enter the new barcode";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.BtnSetAsOldCode);
            this.Panel2.Controls.Add(this.BtnChange);
            this.Panel2.Controls.Add(this.BtnCancel);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 74);
            this.Panel2.Name = "Panel2";
            this.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.Panel2.Size = new System.Drawing.Size(412, 42);
            this.Panel2.TabIndex = 19;
            // 
            // BtnSetAsOldCode
            // 
            this.BtnSetAsOldCode.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSetAsOldCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetAsOldCode.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSetAsOldCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSetAsOldCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSetAsOldCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnSetAsOldCode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetAsOldCode.Location = new System.Drawing.Point(2, 2);
            this.BtnSetAsOldCode.Name = "BtnSetAsOldCode";
            this.BtnSetAsOldCode.Size = new System.Drawing.Size(125, 38);
            this.BtnSetAsOldCode.TabIndex = 130;
            this.BtnSetAsOldCode.Text = "&Set As Old Code";
            this.BtnSetAsOldCode.UseVisualStyleBackColor = false;
            this.BtnSetAsOldCode.Click += new System.EventHandler(this.BtnSetAsOldCode_Click);
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
            this.BtnChange.Location = new System.Drawing.Point(218, 2);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(108, 38);
            this.BtnChange.TabIndex = 129;
            this.BtnChange.Text = "&Change";
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
            this.BtnCancel.Location = new System.Drawing.Point(326, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(84, 38);
            this.BtnCancel.TabIndex = 128;
            this.BtnCancel.Text = "C&ancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmProductsBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 116);
            this.Controls.Add(this.PanelAlert);
            this.Controls.Add(this.Panel30);
            this.Controls.Add(this.Panel2);
            this.Name = "FrmProductsBarcode";
            this.Text = "FrmProductsBarcode";
            this.Load += new System.EventHandler(this.FrmProductsBarcode_Load);
            this.PanelAlert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel30.ResumeLayout(false);
            this.Panel30.PerformLayout();
            this.Panel53.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanelAlert;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel Panel30;
        internal System.Windows.Forms.TextBox TxtBarcode;
        internal System.Windows.Forms.Panel Panel53;
        internal System.Windows.Forms.ComboBox CmbSpecial;
        internal System.Windows.Forms.Label Label57;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnSetAsOldCode;
        internal System.Windows.Forms.Button BtnChange;
        internal System.Windows.Forms.Button BtnCancel;
    }
}