using System.Windows.Forms;

namespace unt_bingoo.view.Supplier
{
    partial class guiTerm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblCountDay;
        private TextBox txtCountDay;
        private Button btnSave;
        private Button btnClose;
        private DataGridView dgvTerm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCountDay = new System.Windows.Forms.Label();
            this.txtCountDay = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTerm = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Term Management";
            // 
            // lblCountDay
            // 
            this.lblCountDay.AutoSize = true;
            this.lblCountDay.Location = new System.Drawing.Point(25, 70);
            this.lblCountDay.Name = "lblCountDay";
            this.lblCountDay.Size = new System.Drawing.Size(58, 13);
            this.lblCountDay.TabIndex = 4;
            this.lblCountDay.Text = "Count Day";
            // 
            // txtCountDay
            // 
            this.txtCountDay.Location = new System.Drawing.Point(110, 67);
            this.txtCountDay.Name = "txtCountDay";
            this.txtCountDay.Size = new System.Drawing.Size(150, 21);
            this.txtCountDay.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(280, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(380, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CanCel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTerm
            // 
            this.dgvTerm.AllowUserToAddRows = false;
            this.dgvTerm.AllowUserToDeleteRows = false;
            this.dgvTerm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TermDay,
            this.CountDay,
            this.Edit,
            this.Delete});
            this.dgvTerm.Location = new System.Drawing.Point(25, 110);
            this.dgvTerm.Name = "dgvTerm";
            this.dgvTerm.ReadOnly = true;
            this.dgvTerm.Size = new System.Drawing.Size(600, 250);
            this.dgvTerm.TabIndex = 0;
            this.dgvTerm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTerm_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // TermDay
            // 
            this.TermDay.HeaderText = "TermDay";
            this.TermDay.Name = "TermDay";
            this.TermDay.ReadOnly = true;
            // 
            // CountDay
            // 
            this.CountDay.HeaderText = "CountDay";
            this.CountDay.Name = "CountDay";
            this.CountDay.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // guiTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 404);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvTerm);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCountDay);
            this.Controls.Add(this.lblCountDay);
            this.Controls.Add(this.lblTitle);
            this.Name = "guiTerm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Term Day";
            this.Load += new System.EventHandler(this.guiTerm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Button button1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn TermDay;
        private DataGridViewTextBoxColumn CountDay;
        private DataGridViewImageColumn Edit;
        private DataGridViewImageColumn Delete;
    }
}