namespace unt_bingoo.view.Purchase
{
    partial class guiSupplierPayments
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOutstanding = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudPurchaseOrderId = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gridViewPayments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedByName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlPayments = new DevExpress.XtraGrid.GridControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchaseOrderId)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayments)).BeginInit();
            this.SuspendLayout();
            //
            // panel1 (Supplier)
            //
            this.panel1.Controls.Add(this.cboSupplier);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(28, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 27);
            this.panel1.TabIndex = 0;
            //
            // cboSupplier
            //
            this.cboSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboSupplier.Location = new System.Drawing.Point(150, 0);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(618, 25);
            this.cboSupplier.TabIndex = 1;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            //
            // label1
            //
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel2 (Outstanding)
            //
            this.panel2.Controls.Add(this.lblOutstanding);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(28, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 27);
            this.panel2.TabIndex = 2;
            //
            // lblOutstanding
            //
            this.lblOutstanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutstanding.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblOutstanding.ForeColor = System.Drawing.Color.DarkRed;
            this.lblOutstanding.Location = new System.Drawing.Point(150, 0);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(618, 27);
            this.lblOutstanding.TabIndex = 3;
            this.lblOutstanding.Text = "—";
            this.lblOutstanding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // label2
            //
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Outstanding (AP)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel3 (Purchase Order Id)
            //
            this.panel3.Controls.Add(this.nudPurchaseOrderId);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(28, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(768, 27);
            this.panel3.TabIndex = 4;
            //
            // nudPurchaseOrderId
            //
            this.nudPurchaseOrderId.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.nudPurchaseOrderId.Location = new System.Drawing.Point(150, 2);
            this.nudPurchaseOrderId.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            this.nudPurchaseOrderId.Name = "nudPurchaseOrderId";
            this.nudPurchaseOrderId.Size = new System.Drawing.Size(200, 23);
            this.nudPurchaseOrderId.TabIndex = 5;
            //
            // label3
            //
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "PO ID (optional, 0 = none)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel4 (Payment Date)
            //
            this.panel4.Controls.Add(this.dtpPaymentDate);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(28, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(768, 27);
            this.panel4.TabIndex = 6;
            //
            // dtpPaymentDate
            //
            this.dtpPaymentDate.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(150, 2);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(200, 23);
            this.dtpPaymentDate.TabIndex = 7;
            //
            // label4
            //
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Payment Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel5 (Payment Method)
            //
            this.panel5.Controls.Add(this.cboPaymentMethod);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(28, 140);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(768, 27);
            this.panel5.TabIndex = 8;
            //
            // cboPaymentMethod
            //
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Bank Transfer",
            "Cheque",
            "Other"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(150, 2);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(200, 25);
            this.cboPaymentMethod.TabIndex = 9;
            //
            // label5
            //
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "Payment Method *";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel6 (Amount)
            //
            this.panel6.Controls.Add(this.txtAmount);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(28, 170);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(768, 27);
            this.panel6.TabIndex = 10;
            //
            // txtAmount
            //
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(150, 2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 23);
            this.txtAmount.TabIndex = 11;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // label6
            //
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "Amount *";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel7 (Reference No)
            //
            this.panel7.Controls.Add(this.txtReferenceNo);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(28, 200);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(768, 27);
            this.panel7.TabIndex = 12;
            //
            // txtReferenceNo
            //
            this.txtReferenceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReferenceNo.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtReferenceNo.Location = new System.Drawing.Point(150, 0);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(618, 23);
            this.txtReferenceNo.TabIndex = 13;
            //
            // label7
            //
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 27);
            this.label7.TabIndex = 12;
            this.label7.Text = "Reference No.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // panel8 (Remark)
            //
            this.panel8.Controls.Add(this.txtRemark);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(28, 230);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(768, 50);
            this.panel8.TabIndex = 14;
            //
            // txtRemark
            //
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtRemark.Location = new System.Drawing.Point(150, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(618, 50);
            this.txtRemark.TabIndex = 15;
            //
            // label8
            //
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 50);
            this.label8.TabIndex = 14;
            this.label8.Text = "Remark";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnRecord
            //
            this.btnRecord.Location = new System.Drawing.Point(940, 300);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(150, 35);
            this.btnRecord.TabIndex = 16;
            this.btnRecord.Text = "Record Payment";
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(1192, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // gridViewPayments
            //
            this.gridViewPayments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentNo,
            this.colSupplierName,
            this.colPurchaseOrderNo,
            this.colPaymentDate,
            this.colPaymentMethod,
            this.colAmount,
            this.colReferenceNo,
            this.colStatus,
            this.colCreatedByName,
            this.colCreatedAt});
            this.gridViewPayments.GridControl = this.gridControlPayments;
            this.gridViewPayments.Name = "gridViewPayments";
            this.gridViewPayments.OptionsBehavior.Editable = false;
            this.gridViewPayments.OptionsView.ColumnAutoWidth = false;
            this.gridViewPayments.OptionsView.ShowGroupPanel = false;
            //
            // colPaymentNo
            //
            this.colPaymentNo.Caption = "Payment No.";
            this.colPaymentNo.FieldName = "PaymentNo";
            this.colPaymentNo.Name = "colPaymentNo";
            this.colPaymentNo.Visible = true;
            this.colPaymentNo.VisibleIndex = 0;
            this.colPaymentNo.Width = 100;
            //
            // colSupplierName
            //
            this.colSupplierName.Caption = "Supplier";
            this.colSupplierName.FieldName = "SupplierName";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.Visible = true;
            this.colSupplierName.VisibleIndex = 1;
            this.colSupplierName.Width = 180;
            //
            // colPurchaseOrderNo
            //
            this.colPurchaseOrderNo.Caption = "PO No.";
            this.colPurchaseOrderNo.FieldName = "PurchaseOrderNo";
            this.colPurchaseOrderNo.Name = "colPurchaseOrderNo";
            this.colPurchaseOrderNo.Visible = true;
            this.colPurchaseOrderNo.VisibleIndex = 2;
            this.colPurchaseOrderNo.Width = 100;
            //
            // colPaymentDate
            //
            this.colPaymentDate.Caption = "Payment Date";
            this.colPaymentDate.FieldName = "PaymentDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.VisibleIndex = 3;
            this.colPaymentDate.Width = 100;
            //
            // colPaymentMethod
            //
            this.colPaymentMethod.Caption = "Method";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 4;
            this.colPaymentMethod.Width = 100;
            //
            // colAmount
            //
            this.colAmount.Caption = "Amount";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;
            this.colAmount.Width = 100;
            //
            // colReferenceNo
            //
            this.colReferenceNo.Caption = "Reference";
            this.colReferenceNo.FieldName = "ReferenceNo";
            this.colReferenceNo.Name = "colReferenceNo";
            this.colReferenceNo.Visible = true;
            this.colReferenceNo.VisibleIndex = 6;
            this.colReferenceNo.Width = 120;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            this.colStatus.Width = 90;
            //
            // colCreatedByName
            //
            this.colCreatedByName.Caption = "Recorded By";
            this.colCreatedByName.FieldName = "CreatedByName";
            this.colCreatedByName.Name = "colCreatedByName";
            this.colCreatedByName.Visible = true;
            this.colCreatedByName.VisibleIndex = 8;
            this.colCreatedByName.Width = 120;
            //
            // colCreatedAt
            //
            this.colCreatedAt.Caption = "Recorded At";
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 9;
            this.colCreatedAt.Width = 130;
            //
            // gridControlPayments
            //
            this.gridControlPayments.Location = new System.Drawing.Point(12, 369);
            this.gridControlPayments.MainView = this.gridViewPayments;
            this.gridControlPayments.Name = "gridControlPayments";
            this.gridControlPayments.Size = new System.Drawing.Size(1350, 437);
            this.gridControlPayments.TabIndex = 18;
            this.gridControlPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPayments});
            //
            // guiSupplierPayments
            //
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.gridControlPayments);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "guiSupplierPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Payments";
            this.Load += new System.EventHandler(this.guiSupplierPayments_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchaseOrderId)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayments)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOutstanding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudPurchaseOrderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPayments;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedByName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.GridControl gridControlPayments;
    }
}
