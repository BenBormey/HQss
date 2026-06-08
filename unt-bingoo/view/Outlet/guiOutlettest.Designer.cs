namespace unt_bingoo.view.Outlet
{
    partial class guiOutlettest
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpGeneralInfo;
        private System.Windows.Forms.GroupBox grpPhotoGallery;
        private System.Windows.Forms.DataGridView dgvOutlets;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtOutletName;
        private System.Windows.Forms.TextBox txtOutletCode;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.FlowLayoutPanel flowPhotoGallery;
        private System.Windows.Forms.PictureBox picMainThumbnail;
        private System.Windows.Forms.Label lblMainPhoto;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpGeneralInfo = new System.Windows.Forms.GroupBox();
            this.grpPhotoGallery = new System.Windows.Forms.GroupBox();
            this.flowPhotoGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvOutlets = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.picMainThumbnail = new System.Windows.Forms.PictureBox();

            // Form Settings
            this.ClientSize = new System.Drawing.Size(1250, 800);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 249);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 9F);
            this.Text = "BingGoo Outlet Management";

            // 1. Header Panel
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;

            this.lblTitle.Text = "Q'S OUTLET MANAGEMENT SYSTEM";
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Khmer OS Muol Light", 14F);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.AutoSize = true;
            this.pnlHeader.Controls.Add(this.lblTitle);

            // 2. General Info GroupBox (Left Side)
            this.grpGeneralInfo.Text = "ព័ត៌មានទូទៅ / General Info";
            this.grpGeneralInfo.Location = new System.Drawing.Point(20, 90);
            this.grpGeneralInfo.Size = new System.Drawing.Size(400, 420);
            this.grpGeneralInfo.BackColor = System.Drawing.Color.White;

            // 3. Photo Gallery GroupBox (Right Side)
            this.grpPhotoGallery.Text = "បណ្តុំរូបភាព / Photo Gallery";
            this.grpPhotoGallery.Location = new System.Drawing.Point(440, 90);
            this.grpPhotoGallery.Size = new System.Drawing.Size(780, 420);
            this.grpPhotoGallery.BackColor = System.Drawing.Color.White;

            this.picMainThumbnail.Size = new System.Drawing.Size(250, 180);
            this.picMainThumbnail.Location = new System.Drawing.Point(20, 40);
            this.picMainThumbnail.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.picMainThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMainThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.flowPhotoGallery.Location = new System.Drawing.Point(290, 40);
            this.flowPhotoGallery.Size = new System.Drawing.Size(470, 300);
            this.flowPhotoGallery.AutoScroll = true;
            this.flowPhotoGallery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPhotoGallery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.btnAddPhoto.Text = "បន្ថែមរូបភាព (+) Add Photos";
            this.btnAddPhoto.Location = new System.Drawing.Point(290, 350);
            this.btnAddPhoto.Size = new System.Drawing.Size(180, 45);
            this.btnAddPhoto.BackColor = System.Drawing.Color.FromArgb(0, 128, 128);
            this.btnAddPhoto.ForeColor = System.Drawing.Color.White;
            this.btnAddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnSave.Text = "រក្សាទុក / SAVE DATA";
            this.btnSave.Location = new System.Drawing.Point(20, 350);
            this.btnSave.Size = new System.Drawing.Size(250, 45);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS Battambang", 10F, System.Drawing.FontStyle.Bold);

            // 4. DataGrid (Bottom)
            this.dgvOutlets.Location = new System.Drawing.Point(20, 530);
            this.dgvOutlets.Size = new System.Drawing.Size(1200, 240);
            this.dgvOutlets.BackgroundColor = System.Drawing.Color.White;
            this.dgvOutlets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOutlets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutlets.ColumnHeadersHeight = 40;

            // Adding Controls
            this.grpPhotoGallery.Controls.Add(this.picMainThumbnail);
            this.grpPhotoGallery.Controls.Add(this.flowPhotoGallery);
            this.grpPhotoGallery.Controls.Add(this.btnAddPhoto);
            this.grpPhotoGallery.Controls.Add(this.btnSave);

            this.Controls.Add(this.dgvOutlets);
            this.Controls.Add(this.grpPhotoGallery);
            this.Controls.Add(this.grpGeneralInfo);
            this.Controls.Add(this.pnlHeader);
        }

        #endregion
    }
}