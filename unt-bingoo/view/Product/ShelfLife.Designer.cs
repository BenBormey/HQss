namespace unt_bingoo.view.Product
{
    partial class ShelfLife
    {
        private System.ComponentModel.IContainer components = null;

        // Input card
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblShelfLife;
        private System.Windows.Forms.TextBox txtShelfLife;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtShelfLifeValue;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbShelfLifeUnit;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        // Grid
        private System.Windows.Forms.Panel pnlGrid;
        private DevExpress.XtraGrid.GridControl grdShelfLife;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShelfLife;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn ShelfLifeName;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLifeValue;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLifeUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;

        // Footer
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions5 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions6 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject24 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblShelfLife = new System.Windows.Forms.Label();
            this.txtShelfLife = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtShelfLifeValue = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbShelfLifeUnit = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdShelfLife = new DevExpress.XtraGrid.GridControl();
            this.gvShelfLife = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShelfLifeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLifeValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLifeUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShelfLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShelfLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.txtid);
            this.pnlInput.Controls.Add(this.lblShelfLife);
            this.pnlInput.Controls.Add(this.txtShelfLife);
            this.pnlInput.Controls.Add(this.lblValue);
            this.pnlInput.Controls.Add(this.txtShelfLifeValue);
            this.pnlInput.Controls.Add(this.lblUnit);
            this.pnlInput.Controls.Add(this.cmbShelfLifeUnit);
            this.pnlInput.Controls.Add(this.chkIsActive);
            this.pnlInput.Controls.Add(this.btnSave);
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(820, 168);
            this.pnlInput.TabIndex = 2;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(0, 0);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(60, 21);
            this.txtid.TabIndex = 0;
            this.txtid.Visible = false;
            // 
            // lblShelfLife
            // 
            this.lblShelfLife.AutoSize = true;
            this.lblShelfLife.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblShelfLife.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblShelfLife.Location = new System.Drawing.Point(532, 94);
            this.lblShelfLife.Name = "lblShelfLife";
            this.lblShelfLife.Size = new System.Drawing.Size(101, 17);
            this.lblShelfLife.TabIndex = 1;
            this.lblShelfLife.Text = "Shelf Life Name";
            this.lblShelfLife.Visible = false;
            // 
            // txtShelfLife
            // 
            this.txtShelfLife.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShelfLife.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtShelfLife.Location = new System.Drawing.Point(532, 118);
            this.txtShelfLife.Name = "txtShelfLife";
            this.txtShelfLife.Size = new System.Drawing.Size(300, 25);
            this.txtShelfLife.TabIndex = 2;
            this.txtShelfLife.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblValue.Location = new System.Drawing.Point(20, 24);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(40, 17);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Value";
            // 
            // txtShelfLifeValue
            // 
            this.txtShelfLifeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShelfLifeValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtShelfLifeValue.Location = new System.Drawing.Point(20, 48);
            this.txtShelfLifeValue.Name = "txtShelfLifeValue";
            this.txtShelfLifeValue.Size = new System.Drawing.Size(110, 25);
            this.txtShelfLifeValue.TabIndex = 4;
            this.txtShelfLifeValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShelfLifeValue_KeyPress);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblUnit.Location = new System.Drawing.Point(150, 24);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(44, 17);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "Terms";
            // 
            // cmbShelfLifeUnit
            // 
            this.cmbShelfLifeUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbShelfLifeUnit.FormattingEnabled = true;
            this.cmbShelfLifeUnit.Items.AddRange(new object[] {
            "Day(s)",
            "Week(s)",
            "Month(s)",
            "Year(s)"});
            this.cmbShelfLifeUnit.Location = new System.Drawing.Point(150, 48);
            this.cmbShelfLifeUnit.Name = "cmbShelfLifeUnit";
            this.cmbShelfLifeUnit.Size = new System.Drawing.Size(160, 25);
            this.cmbShelfLifeUnit.TabIndex = 6;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.chkIsActive.Location = new System.Drawing.Point(24, 84);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 21);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Active";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(24, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ADD";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClear.Location = new System.Drawing.Point(154, 118);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Close";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.grdShelfLife);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 168);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrid.Size = new System.Drawing.Size(820, 394);
            this.pnlGrid.TabIndex = 0;
            // 
            // grdShelfLife
            // 
            this.grdShelfLife.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShelfLife.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.grdShelfLife.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdShelfLife.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.grdShelfLife.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.grdShelfLife.Location = new System.Drawing.Point(16, 12);
            this.grdShelfLife.MainView = this.gvShelfLife;
            this.grdShelfLife.Name = "grdShelfLife";
            this.grdShelfLife.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.grdShelfLife.Size = new System.Drawing.Size(788, 370);
            this.grdShelfLife.TabIndex = 0;
            this.grdShelfLife.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShelfLife});
            // 
            // gvShelfLife
            // 
            this.gvShelfLife.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.gvShelfLife.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvShelfLife.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gvShelfLife.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvShelfLife.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvShelfLife.Appearance.Row.Options.UseFont = true;
            this.gvShelfLife.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.ShelfLifeName,
            this.colShelfLifeValue,
            this.colShelfLifeUnit,
            this.colIsActive,
            this.gridColumn1,
            this.gridColumn2});
            this.gvShelfLife.GridControl = this.grdShelfLife;
            this.gvShelfLife.Name = "gvShelfLife";
            this.gvShelfLife.OptionsView.EnableAppearanceEvenRow = true;
            this.gvShelfLife.OptionsView.ShowGroupPanel = false;
            this.gvShelfLife.RowHeight = 30;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "ShelfLifeId";
            this.Id.Name = "Id";
            // 
            // ShelfLifeName
            // 
            this.ShelfLifeName.Caption = "Shelf Life Name";
            this.ShelfLifeName.FieldName = "ShelfLifeName";
            this.ShelfLifeName.Name = "ShelfLifeName";
            this.ShelfLifeName.OptionsColumn.ReadOnly = true;
            this.ShelfLifeName.Width = 230;
            // 
            // colShelfLifeValue
            // 
            this.colShelfLifeValue.Caption = "Value";
            this.colShelfLifeValue.FieldName = "ShelfLifeValue";
            this.colShelfLifeValue.Name = "colShelfLifeValue";
            this.colShelfLifeValue.OptionsColumn.ReadOnly = true;
            this.colShelfLifeValue.Visible = true;
            this.colShelfLifeValue.VisibleIndex = 0;
            this.colShelfLifeValue.Width = 110;
            // 
            // colShelfLifeUnit
            // 
            this.colShelfLifeUnit.Caption = "Terms";
            this.colShelfLifeUnit.FieldName = "ShelfLifeUnit";
            this.colShelfLifeUnit.Name = "colShelfLifeUnit";
            this.colShelfLifeUnit.OptionsColumn.ReadOnly = true;
            this.colShelfLifeUnit.Visible = true;
            this.colShelfLifeUnit.VisibleIndex = 1;
            this.colShelfLifeUnit.Width = 130;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Active";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.OptionsColumn.ReadOnly = true;
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 2;
            this.colIsActive.Width = 90;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Edit";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions5.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions5, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17, serializableAppearanceObject18, serializableAppearanceObject19, serializableAppearanceObject20, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Delete";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions6.Image = global::unt_bingoo.Properties.Resources.Deleted16;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions6, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, serializableAppearanceObject22, serializableAppearanceObject23, serializableAppearanceObject24, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.panelFooter.Controls.Add(this.lblCount);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 562);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(820, 38);
            this.panelFooter.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblCount.Location = new System.Drawing.Point(24, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(91, 15);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Total Records: 0";
            // 
            // ShelfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.pnlInput);
            this.Name = "ShelfLife";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shelf Life Management";
            this.Load += new System.EventHandler(this.ShelfLife_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShelfLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShelfLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}