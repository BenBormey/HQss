namespace unt_bingoo.view.Outlet
{
    partial class guiOutletCode
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Layout containers =====
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlButtons;

        // ===== Input fields =====
        private System.Windows.Forms.Label lblOutletCode;
        private System.Windows.Forms.TextBox txtOutletCode;
        private System.Windows.Forms.CheckBox chkstatus;
        private System.Windows.Forms.TextBox txtid;

        // ===== Buttons =====
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        // ===== Grid =====
        private DevExpress.XtraGrid.GridControl grdOutlet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutlet;

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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdOutlet = new DevExpress.XtraGrid.GridControl();
            this.gvOutlet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblOutletCode = new System.Windows.Forms.Label();
            this.txtOutletCode = new System.Windows.Forms.TextBox();
            this.chkstatus = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).BeginInit();
            this.pnlInput.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlInput);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlMain.Size = new System.Drawing.Size(1000, 640);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdOutlet);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 104);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 520);
            this.pnlGrid.TabIndex = 2;
            // 
            // grdOutlet
            // 
            this.grdOutlet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutlet.Location = new System.Drawing.Point(24, 0);
            this.grdOutlet.MainView = this.gvOutlet;
            this.grdOutlet.Name = "grdOutlet";
            this.grdOutlet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainUpdate,
            this.btnmainDelete});
            this.grdOutlet.Size = new System.Drawing.Size(952, 520);
            this.grdOutlet.TabIndex = 0;
            this.grdOutlet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutlet});
            // 
            // gvOutlet
            // 
            this.gvOutlet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.gvOutlet.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvOutlet.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gvOutlet.Appearance.Row.Options.UseFont = true;
            this.gvOutlet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.OutletCode,
            this.IsActive,
            this.gridColumn2,
            this.gridColumn1});
            this.gvOutlet.GridControl = this.grdOutlet;
            this.gvOutlet.Name = "gvOutlet";
            this.gvOutlet.OptionsView.ColumnAutoWidth = false;
            this.gvOutlet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvOutlet.OptionsView.ShowGroupPanel = false;
            this.gvOutlet.RowHeight = 32;
            this.gvOutlet.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvOutlet_RowCellStyle);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // OutletCode
            // 
            this.OutletCode.Caption = "Outlet Code";
            this.OutletCode.FieldName = "OutletCode";
            this.OutletCode.Name = "OutletCode";
            this.OutletCode.Visible = true;
            this.OutletCode.VisibleIndex = 0;
            this.OutletCode.Width = 50;
            // 
            // IsActive
            // 
            this.IsActive.Caption = "Status";
            this.IsActive.FieldName = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.Visible = true;
            this.IsActive.VisibleIndex = 1;
            this.IsActive.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Edit";
            this.gridColumn2.ColumnEdit = this.btnmainUpdate;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 80;
            // 
            // btnmainUpdate
            // 
            this.btnmainUpdate.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnmainUpdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainUpdate.Name = "btnmainUpdate";
            this.btnmainUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainUpdate_ButtonClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Delete";
            this.gridColumn1.ColumnEdit = this.btnmainDelete;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 80;
            // 
            // btnmainDelete
            // 
            this.btnmainDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnmainDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainDelete.Name = "btnmainDelete";
            this.btnmainDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDelete_ButtonClick);
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlInput.Controls.Add(this.txtid);
            this.pnlInput.Controls.Add(this.lblOutletCode);
            this.pnlInput.Controls.Add(this.txtOutletCode);
            this.pnlInput.Controls.Add(this.chkstatus);
            this.pnlInput.Controls.Add(this.pnlButtons);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlInput.Size = new System.Drawing.Size(1000, 104);
            this.pnlInput.TabIndex = 1;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtid.Location = new System.Drawing.Point(900, 20);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(38, 25);
            this.txtid.TabIndex = 99;
            this.txtid.Visible = false;
            // 
            // lblOutletCode
            // 
            this.lblOutletCode.AutoSize = true;
            this.lblOutletCode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblOutletCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.lblOutletCode.Location = new System.Drawing.Point(24, 22);
            this.lblOutletCode.Name = "lblOutletCode";
            this.lblOutletCode.Size = new System.Drawing.Size(81, 17);
            this.lblOutletCode.TabIndex = 0;
            this.lblOutletCode.Text = "Outlet Code";
            // 
            // txtOutletCode
            // 
            this.txtOutletCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutletCode.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtOutletCode.Location = new System.Drawing.Point(24, 43);
            this.txtOutletCode.Name = "txtOutletCode";
            this.txtOutletCode.Size = new System.Drawing.Size(380, 26);
            this.txtOutletCode.TabIndex = 1;
            // 
            // chkstatus
            // 
            this.chkstatus.AutoSize = true;
            this.chkstatus.Checked = true;
            this.chkstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkstatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.chkstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.chkstatus.Location = new System.Drawing.Point(424, 47);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Size = new System.Drawing.Size(64, 21);
            this.chkstatus.TabIndex = 2;
            this.chkstatus.Text = "Active";
            this.chkstatus.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Location = new System.Drawing.Point(704, 30);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(272, 44);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(72)))));
            this.btnClear.Location = new System.Drawing.Point(142, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "CanCel";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // guiOutletCode
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "guiOutletCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Management";
            this.Load += new System.EventHandler(this.guiOutletCode_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).EndInit();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn OutletCode;
        private DevExpress.XtraGrid.Columns.GridColumn IsActive;
    }
}