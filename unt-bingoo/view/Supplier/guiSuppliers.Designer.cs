namespace unt_bingoo.view.Supplier
{
    partial class guiSuppliers
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTaxNumber;

        private System.Windows.Forms.CheckBox chkStatus;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTaxNumber = new System.Windows.Forms.TextBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblTermDays = new System.Windows.Forms.Label();
            this.nudTermDays = new System.Windows.Forms.NumericUpDown();
            this.lblDayOrder = new System.Windows.Forms.Label();
            this.nudDayOrder = new System.Windows.Forms.NumericUpDown();
            this.lblOrderLevel = new System.Windows.Forms.Label();
            this.nudOrderLevel = new System.Windows.Forms.NumericUpDown();
            this.lblVat = new System.Windows.Forms.Label();
            this.nudVat = new System.Windows.Forms.NumericUpDown();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnmainUpdateButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnmainDeletebutton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridViewSuppliers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TaxNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlSuppliers = new DevExpress.XtraGrid.GridControl();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTermDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVat)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDeletebutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(146, 176);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(651, 23);
            this.txtAddress.TabIndex = 6;
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxNumber.Location = new System.Drawing.Point(146, 206);
            this.txtTaxNumber.Name = "txtTaxNumber";
            this.txtTaxNumber.Size = new System.Drawing.Size(651, 23);
            this.txtTaxNumber.TabIndex = 7;
            // 
            // chkStatus
            // 
            this.chkStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(265, 283);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(104, 24);
            this.chkStatus.TabIndex = 8;
            this.chkStatus.Text = "Active";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(940, 328);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1040, 328);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 35);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1092, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1192, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(26, 176);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Address";
            // 
            // lblTaxNumber
            // 
            this.lblTaxNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxNumber.Location = new System.Drawing.Point(26, 206);
            this.lblTaxNumber.Name = "lblTaxNumber";
            this.lblTaxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblTaxNumber.TabIndex = 19;
            this.lblTaxNumber.Text = "Tax Number";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(145, 283);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.lblTermDays);
            this.panel12.Controls.Add(this.nudTermDays);
            this.panel12.Controls.Add(this.lblDayOrder);
            this.panel12.Controls.Add(this.nudDayOrder);
            this.panel12.Controls.Add(this.lblOrderLevel);
            this.panel12.Controls.Add(this.nudOrderLevel);
            this.panel12.Controls.Add(this.lblVat);
            this.panel12.Controls.Add(this.nudVat);
            this.panel12.Location = new System.Drawing.Point(838, 20);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(417, 241);
            this.panel12.TabIndex = 21;
            // 
            // lblTermDays
            // 
            this.lblTermDays.AutoSize = true;
            this.lblTermDays.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTermDays.Location = new System.Drawing.Point(24, 13);
            this.lblTermDays.Name = "lblTermDays";
            this.lblTermDays.Size = new System.Drawing.Size(69, 15);
            this.lblTermDays.TabIndex = 10;
            this.lblTermDays.Text = "Term (Days)";
            // 
            // nudTermDays
            // 
            this.nudTermDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTermDays.Location = new System.Drawing.Point(146, 8);
            this.nudTermDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudTermDays.Name = "nudTermDays";
            this.nudTermDays.Size = new System.Drawing.Size(110, 25);
            this.nudTermDays.TabIndex = 11;
            this.nudTermDays.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblDayOrder
            // 
            this.lblDayOrder.AutoSize = true;
            this.lblDayOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDayOrder.Location = new System.Drawing.Point(24, 98);
            this.lblDayOrder.Name = "lblDayOrder";
            this.lblDayOrder.Size = new System.Drawing.Size(96, 15);
            this.lblDayOrder.TabIndex = 12;
            this.lblDayOrder.Text = "Day Order (Days)";
            // 
            // nudDayOrder
            // 
            this.nudDayOrder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDayOrder.Location = new System.Drawing.Point(144, 93);
            this.nudDayOrder.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDayOrder.Name = "nudDayOrder";
            this.nudDayOrder.Size = new System.Drawing.Size(110, 25);
            this.nudDayOrder.TabIndex = 13;
            this.nudDayOrder.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblOrderLevel
            // 
            this.lblOrderLevel.AutoSize = true;
            this.lblOrderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderLevel.Location = new System.Drawing.Point(24, 60);
            this.lblOrderLevel.Name = "lblOrderLevel";
            this.lblOrderLevel.Size = new System.Drawing.Size(99, 15);
            this.lblOrderLevel.TabIndex = 16;
            this.lblOrderLevel.Text = "Set % Order Level";
            // 
            // nudOrderLevel
            // 
            this.nudOrderLevel.DecimalPlaces = 2;
            this.nudOrderLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudOrderLevel.Location = new System.Drawing.Point(146, 50);
            this.nudOrderLevel.Name = "nudOrderLevel";
            this.nudOrderLevel.Size = new System.Drawing.Size(110, 25);
            this.nudOrderLevel.TabIndex = 17;
            this.nudOrderLevel.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVat.Location = new System.Drawing.Point(24, 145);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(47, 15);
            this.lblVat.TabIndex = 18;
            this.lblVat.Text = "VAT (%)";
            // 
            // nudVat
            // 
            this.nudVat.DecimalPlaces = 2;
            this.nudVat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudVat.Location = new System.Drawing.Point(144, 140);
            this.nudVat.Name = "nudVat";
            this.nudVat.Size = new System.Drawing.Size(110, 25);
            this.nudVat.TabIndex = 19;
            this.nudVat.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCountry.Location = new System.Drawing.Point(25, 241);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(115, 15);
            this.lblCountry.TabIndex = 14;
            this.lblCountry.Text = "Country of Purchase";
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCountry.Items.AddRange(new object[] {
            "Cambodia",
            "Vietnam",
            "Thailand",
            "China"});
            this.cboCountry.Location = new System.Drawing.Point(146, 236);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(650, 25);
            this.cboCountry.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSupplierCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(28, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 24);
            this.panel1.TabIndex = 23;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Location = new System.Drawing.Point(120, 0);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(648, 23);
            this.txtSupplierCode.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Supplier Code          ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSupplierName);
            this.panel2.Controls.Add(this.lblSupplierName);
            this.panel2.Location = new System.Drawing.Point(28, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 27);
            this.panel2.TabIndex = 24;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(117, 0);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(652, 23);
            this.txtSupplierName.TabIndex = 15;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSupplierName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(0, 0);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(117, 27);
            this.lblSupplierName.TabIndex = 16;
            this.lblSupplierName.Text = "Supplier Name";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtContactName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(28, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 27);
            this.panel3.TabIndex = 25;
            // 
            // txtContactName
            // 
            this.txtContactName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactName.Location = new System.Drawing.Point(117, 0);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(652, 23);
            this.txtContactName.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 16;
            this.label2.Text = "Contact Name";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtPhone);
            this.panel4.Controls.Add(this.lblPhone);
            this.panel4.Location = new System.Drawing.Point(28, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(769, 24);
            this.panel4.TabIndex = 27;
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(114, 0);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(655, 23);
            this.txtPhone.TabIndex = 17;
            // 
            // lblPhone
            // 
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(0, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(114, 24);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Phone";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Controls.Add(this.lblEmail);
            this.panel5.Location = new System.Drawing.Point(28, 140);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(769, 30);
            this.panel5.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(121, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(648, 27);
            this.txtEmail.TabIndex = 18;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(0, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(121, 30);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email";
            // 
            // btnmainUpdateButton
            // 
            this.btnmainUpdateButton.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.edit__1_;
            this.btnmainUpdateButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainUpdateButton.Name = "btnmainUpdateButton";
            this.btnmainUpdateButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainUpdateButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainUpdateButton_ButtonClick);
            // 
            // btnmainDeletebutton
            // 
            this.btnmainDeletebutton.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Delete_User;
            this.btnmainDeletebutton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainDeletebutton.Name = "btnmainDeletebutton";
            this.btnmainDeletebutton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainDeletebutton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDeletebutton_ButtonClick);
            // 
            // gridViewSuppliers
            // 
            this.gridViewSuppliers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SupplierID,
            this.gridColumn7,
            this.SupplierName,
            this.ContactName,
            this.Phone,
            this.Email,
            this.Address,
            this.TaxNumber,
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewSuppliers.GridControl = this.gridControlSuppliers;
            this.gridViewSuppliers.Name = "gridViewSuppliers";
            this.gridViewSuppliers.OptionsView.ColumnAutoWidth = false;
            this.gridViewSuppliers.OptionsView.ShowGroupPanel = false;
            this.gridViewSuppliers.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewSuppliers_RowClick);
            // 
            // SupplierID
            // 
            this.SupplierID.Caption = "SupplierID";
            this.SupplierID.FieldName = "SupplierID";
            this.SupplierID.Name = "SupplierID";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "SupplierCode";
            this.gridColumn7.FieldName = "SupplierCode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // SupplierName
            // 
            this.SupplierName.Caption = "SupplierName";
            this.SupplierName.FieldName = "SupplierName";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.Visible = true;
            this.SupplierName.VisibleIndex = 1;
            this.SupplierName.Width = 150;
            // 
            // ContactName
            // 
            this.ContactName.Caption = "ContactName";
            this.ContactName.FieldName = "ContactName";
            this.ContactName.Name = "ContactName";
            this.ContactName.Visible = true;
            this.ContactName.VisibleIndex = 2;
            this.ContactName.Width = 100;
            // 
            // Phone
            // 
            this.Phone.Caption = "Phone";
            this.Phone.FieldName = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 3;
            // 
            // Email
            // 
            this.Email.Caption = "Email";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 4;
            this.Email.Width = 120;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 5;
            this.Address.Width = 200;
            // 
            // TaxNumber
            // 
            this.TaxNumber.Caption = "TaxNumber";
            this.TaxNumber.FieldName = "TaxNumber";
            this.TaxNumber.Name = "TaxNumber";
            this.TaxNumber.Visible = true;
            this.TaxNumber.VisibleIndex = 6;
            this.TaxNumber.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.ColumnEdit = this.btnmainUpdateButton;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.ColumnEdit = this.btnmainDeletebutton;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            // 
            // gridControlSuppliers
            // 
            this.gridControlSuppliers.Location = new System.Drawing.Point(12, 369);
            this.gridControlSuppliers.MainView = this.gridViewSuppliers;
            this.gridControlSuppliers.Name = "gridControlSuppliers";
            this.gridControlSuppliers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainUpdateButton,
            this.btnmainDeletebutton});
            this.gridControlSuppliers.Size = new System.Drawing.Size(1350, 437);
            this.gridControlSuppliers.TabIndex = 0;
            this.gridControlSuppliers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSuppliers});
            // 
            // guiSuppliers
            // 
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.gridControlSuppliers);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtTaxNumber);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblTaxNumber);
            this.Controls.Add(this.lblStatus);
            this.Name = "guiSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Management";
            this.Load += new System.EventHandler(this.guiSuppliers_Load);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTermDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainUpdateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDeletebutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblTermDays;
        private System.Windows.Forms.NumericUpDown nudTermDays;
        private System.Windows.Forms.Label lblDayOrder;
        private System.Windows.Forms.NumericUpDown nudDayOrder;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label lblOrderLevel;
        private System.Windows.Forms.NumericUpDown nudOrderLevel;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.NumericUpDown nudVat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainUpdateButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDeletebutton;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSuppliers;
        private DevExpress.XtraGrid.Columns.GridColumn SupplierID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn SupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn ContactName;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn TaxNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gridControlSuppliers;
    }
}
