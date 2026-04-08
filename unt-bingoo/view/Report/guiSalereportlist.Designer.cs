namespace unt_bingoo.view.Report
{
    partial class guiSalereportlist
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSection;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblOutlet;

        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;

        private System.Windows.Forms.ComboBox cboOutlet;

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::unt_bingoo.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(10, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(80, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(299, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Q\'s MANAGEMENT SYSTEM";
            // 
            // panelBody
            // 
            this.panelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBody.Controls.Add(this.lblSection);
            this.panelBody.Controls.Add(this.lblStartDate);
            this.panelBody.Controls.Add(this.dtStart);
            this.panelBody.Controls.Add(this.lblEndDate);
            this.panelBody.Controls.Add(this.dtEnd);
            this.panelBody.Controls.Add(this.lblOutlet);
            this.panelBody.Controls.Add(this.cboOutlet);
            this.panelBody.Controls.Add(this.btnPreview);
            this.panelBody.Controls.Add(this.btnCancel);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(600, 270);
            this.panelBody.TabIndex = 0;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSection.Location = new System.Drawing.Point(20, 20);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(113, 20);
            this.lblSection.TabIndex = 0;
            this.lblSection.Text = "SALE REPORTS";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(40, 60);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(150, 55);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 21);
            this.dtStart.TabIndex = 2;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(40, 100);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(150, 95);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 21);
            this.dtEnd.TabIndex = 4;
            // 
            // lblOutlet
            // 
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Location = new System.Drawing.Point(40, 140);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(41, 13);
            this.lblOutlet.TabIndex = 5;
            this.lblOutlet.Text = "Outlet:";
            // 
            // cboOutlet
            // 
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Location = new System.Drawing.Point(150, 135);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(200, 21);
            this.cboOutlet.TabIndex = 6;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(150, 180);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(90, 30);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // guiSalereportlist
            // 
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiSalereportlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Reports";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
