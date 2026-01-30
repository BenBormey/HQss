using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace unt_bingoo.view.User
{
    partial class guiUserrole
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private PanelControl panelHeader;
        private PictureEdit picLogo;
        private LabelControl lblSystemName;

        // Detail panel
        private PanelControl panelDetail;
        private LabelControl lblRoleCode;
        private LabelControl lblRoleName;
        private LabelControl lblDescription;

        private TextEdit txtRoleCode;
        private TextEdit txtRoleName;
        private MemoEdit txtDescription;

        private CheckEdit chkSystemRole;
        private CheckEdit chkIsActive;

        private SimpleButton btnAdd;
        private SimpleButton btnCancel;

        // Grid panel
        private PanelControl panelGrid;

        // Bottom panel
        private PanelControl panelBottom;
        private LabelControl lblCountRow;
        private SimpleButton btnExport;
        private SimpleButton btnClose;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
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
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.panelDetail = new DevExpress.XtraEditors.PanelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblRoleCode = new DevExpress.XtraEditors.LabelControl();
            this.lblRoleName = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.txtRoleCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.chkSystemRole = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblCountRow = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.LoadingRole = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnmainEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnmainDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridViewRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlRole = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystemRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRole)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 80);
            this.panelHeader.TabIndex = 3;
            // 
            // picLogo
            // 
            this.picLogo.EditValue = global::unt_bingoo.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(10, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.TabIndex = 0;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(90, 25);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(363, 26);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Q\'s USER ROLE MANAGEMENT";
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.txtId);
            this.panelDetail.Controls.Add(this.lblRoleCode);
            this.panelDetail.Controls.Add(this.lblRoleName);
            this.panelDetail.Controls.Add(this.lblDescription);
            this.panelDetail.Controls.Add(this.txtRoleCode);
            this.panelDetail.Controls.Add(this.txtRoleName);
            this.panelDetail.Controls.Add(this.txtDescription);
            this.panelDetail.Controls.Add(this.chkSystemRole);
            this.panelDetail.Controls.Add(this.chkIsActive);
            this.panelDetail.Controls.Add(this.btnAdd);
            this.panelDetail.Controls.Add(this.btnCancel);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetail.Location = new System.Drawing.Point(0, 80);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(900, 180);
            this.panelDetail.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(562, 73);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Size = new System.Drawing.Size(35, 20);
            this.txtId.TabIndex = 10;
            this.txtId.Visible = false;
            // 
            // lblRoleCode
            // 
            this.lblRoleCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleCode.Appearance.Options.UseFont = true;
            this.lblRoleCode.Location = new System.Drawing.Point(20, 25);
            this.lblRoleCode.Name = "lblRoleCode";
            this.lblRoleCode.Size = new System.Drawing.Size(59, 14);
            this.lblRoleCode.TabIndex = 0;
            this.lblRoleCode.Text = "Role Code:";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleName.Appearance.Options.UseFont = true;
            this.lblRoleName.Location = new System.Drawing.Point(20, 60);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(62, 14);
            this.lblRoleName.TabIndex = 1;
            this.lblRoleName.Text = "Role Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Appearance.Options.UseFont = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 95);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 14);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(100, 22);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleCode.Properties.Appearance.Options.UseFont = true;
            this.txtRoleCode.Size = new System.Drawing.Size(431, 20);
            this.txtRoleCode.TabIndex = 3;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(100, 57);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleName.Properties.Appearance.Options.UseFont = true;
            this.txtRoleName.Size = new System.Drawing.Size(431, 20);
            this.txtRoleName.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 92);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Size = new System.Drawing.Size(431, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // chkSystemRole
            // 
            this.chkSystemRole.Location = new System.Drawing.Point(562, 23);
            this.chkSystemRole.Name = "chkSystemRole";
            this.chkSystemRole.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSystemRole.Properties.Appearance.Options.UseFont = true;
            this.chkSystemRole.Properties.Caption = "System Role (built-in)";
            this.chkSystemRole.Size = new System.Drawing.Size(146, 19);
            this.chkSystemRole.TabIndex = 6;
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(562, 48);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Properties.Appearance.Options.UseFont = true;
            this.chkIsActive.Properties.Caption = "Active";
            this.chkIsActive.Size = new System.Drawing.Size(75, 19);
            this.chkIsActive.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(700, 135);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(790, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridControlRole);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 260);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(900, 250);
            this.panelGrid.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCountRow);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 510);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCountRow
            // 
            this.lblCountRow.Location = new System.Drawing.Point(10, 12);
            this.lblCountRow.Name = "lblCountRow";
            this.lblCountRow.Size = new System.Drawing.Size(53, 13);
            this.lblCountRow.TabIndex = 0;
            this.lblCountRow.Text = "Count Row";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(700, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 25);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(790, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            // 
            // btnmainEdit
            // 
            this.btnmainEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.update_16;
            this.btnmainEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainEdit.Name = "btnmainEdit";
            this.btnmainEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainEdit_ButtonClick);
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
            // gridViewRole
            // 
            this.gridViewRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.RoleCode,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.Edit,
            this.Delete});
            this.gridViewRole.GridControl = this.gridControlRole;
            this.gridViewRole.Name = "gridViewRole";
            this.gridViewRole.OptionsView.ShowGroupPanel = false;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.Name = "Id";
            // 
            // RoleCode
            // 
            this.RoleCode.Caption = "Role Code";
            this.RoleCode.FieldName = "RoleCode";
            this.RoleCode.Name = "RoleCode";
            this.RoleCode.Visible = true;
            this.RoleCode.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Role Name";
            this.gridColumn2.FieldName = "RoleName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "System Role";
            this.gridColumn4.FieldName = "IsSystemRole";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Active";
            this.gridColumn5.FieldName = "IsActive";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // Edit
            // 
            this.Edit.Caption = "gridColumn1";
            this.Edit.ColumnEdit = this.btnmainEdit;
            this.Edit.Name = "Edit";
            this.Edit.Visible = true;
            this.Edit.VisibleIndex = 5;
            // 
            // Delete
            // 
            this.Delete.Caption = "Delete";
            this.Delete.ColumnEdit = this.btnmainDelete;
            this.Delete.Name = "Delete";
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 6;
            // 
            // gridControlRole
            // 
            this.gridControlRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRole.Location = new System.Drawing.Point(2, 2);
            this.gridControlRole.MainView = this.gridViewRole;
            this.gridControlRole.Name = "gridControlRole";
            this.gridControlRole.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainEdit,
            this.btnmainDelete});
            this.gridControlRole.Size = new System.Drawing.Size(896, 246);
            this.gridControlRole.TabIndex = 0;
            this.gridControlRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRole});
            // 
            // guiUserrole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelHeader);
            this.Name = "guiUserrole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Role Management";
            this.Load += new System.EventHandler(this.guiUserrole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetail)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystemRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Timer LoadingRole;
        private Timer timer2;
        private Timer timer3;
        private TextEdit txtId;
        private GridControl gridControlRole;
        private GridView gridViewRole;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn RoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDelete;
    }
}
