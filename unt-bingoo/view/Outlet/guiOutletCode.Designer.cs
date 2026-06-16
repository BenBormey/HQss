namespace unt_bingoo.view.Outlet
{
    partial class guiOutletCode
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblOutletCode;

        private System.Windows.Forms.TextBox txtOutletCode;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        private DevExpress.XtraGrid.GridControl grdOutlet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutlet;

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
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblOutletCode = new System.Windows.Forms.Label();
            this.txtOutletCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdOutlet = new DevExpress.XtraGrid.GridControl();
            this.gvOutlet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OutletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlInput.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutlet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txtid);
            this.pnlInput.Controls.Add(this.lblOutletCode);
            this.pnlInput.Controls.Add(this.txtOutletCode);
            this.pnlInput.Controls.Add(this.btnSave);
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(20);
            this.pnlInput.Size = new System.Drawing.Size(1000, 120);
            this.pnlInput.TabIndex = 1;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtid.Location = new System.Drawing.Point(534, 40);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(38, 27);
            this.txtid.TabIndex = 4;
            this.txtid.Visible = false;
            // 
            // lblOutletCode
            // 
            this.lblOutletCode.AutoSize = true;
            this.lblOutletCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOutletCode.Location = new System.Drawing.Point(20, 15);
            this.lblOutletCode.Name = "lblOutletCode";
            this.lblOutletCode.Size = new System.Drawing.Size(89, 19);
            this.lblOutletCode.TabIndex = 0;
            this.lblOutletCode.Text = "Outlet Code";
            // 
            // txtOutletCode
            // 
            this.txtOutletCode.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOutletCode.Location = new System.Drawing.Point(20, 40);
            this.txtOutletCode.Name = "txtOutletCode";
            this.txtOutletCode.Size = new System.Drawing.Size(350, 27);
            this.txtOutletCode.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(20, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(150, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Close";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdOutlet);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 120);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1000, 480);
            this.pnlGrid.TabIndex = 0;
            // 
            // grdOutlet
            // 
            this.grdOutlet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutlet.Location = new System.Drawing.Point(0, 0);
            this.grdOutlet.MainView = this.gvOutlet;
            this.grdOutlet.Name = "grdOutlet";
            this.grdOutlet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainDelete,
            this.btnmainUpdate});
            this.grdOutlet.Size = new System.Drawing.Size(1000, 480);
            this.grdOutlet.TabIndex = 0;
            this.grdOutlet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutlet});
            // 
            // gvOutlet
            // 
            this.gvOutlet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.OutletCode,
            this.Status,
            this.gridColumn1,
            this.gridColumn2});
            this.gvOutlet.GridControl = this.grdOutlet;
            this.gvOutlet.Name = "gvOutlet";
            this.gvOutlet.OptionsView.ColumnAutoWidth = false;
            this.gvOutlet.OptionsView.EnableAppearanceEvenRow = true;
            this.gvOutlet.OptionsView.ShowGroupPanel = false;
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
            this.OutletCode.Caption = "OutletCode";
            this.OutletCode.FieldName = "OutletCode";
            this.OutletCode.Name = "OutletCode";
            this.OutletCode.Visible = true;
            this.OutletCode.VisibleIndex = 0;
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = true;
            this.Status.VisibleIndex = 1;
            this.Status.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Delete";
            this.gridColumn1.ColumnEdit = this.btnmainDelete;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // btnmainDelete
            // 
            this.btnmainDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnmainDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainDelete.Name = "btnmainDelete";
            this.btnmainDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDelete_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Edit";
            this.gridColumn2.ColumnEdit = this.btnmainUpdate;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // btnmainUpdate
            // 
            this.btnmainUpdate.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnmainUpdate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainUpdate.Name = "btnmainUpdate";
            this.btnmainUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainUpdate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainUpdate_ButtonClick);
            // 
            // guiOutletCode
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlInput);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "guiOutletCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Management";
            this.Load += new System.EventHandler(this.guiOutletCode_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutlet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn OutletCode;
        private System.Windows.Forms.TextBox txtid;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
    }
}