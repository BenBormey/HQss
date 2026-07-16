namespace unt_bingoo.view.currency
{
    partial class guiListExchange
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvExchange;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvExchange = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvExchange
            //
            this.dgvExchange.AllowUserToAddRows = false;
            this.dgvExchange.AllowUserToDeleteRows = false;
            this.dgvExchange.ReadOnly = true;
            this.dgvExchange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExchange.MultiSelect = false;
            this.dgvExchange.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExchange.Location = new System.Drawing.Point(0, 0);
            this.dgvExchange.Name = "dgvExchange";
            this.dgvExchange.RowHeadersVisible = false;
            this.dgvExchange.Size = new System.Drawing.Size(600, 360);
            this.dgvExchange.TabIndex = 0;
            this.dgvExchange.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExchange_CellDoubleClick);
            //
            // panelButtons
            //
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 360);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(600, 44);
            this.panelButtons.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(500, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(408, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Select";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // guiListExchange
            //
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 404);
            this.Controls.Add(this.dgvExchange);
            this.Controls.Add(this.panelButtons);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Name = "guiListExchange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Exchange Rate";
            this.Load += new System.EventHandler(this.guiListExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExchange)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
