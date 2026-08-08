namespace unt_bingoo.view.Outlet
{
    partial class guiOutletReadiness
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.gridItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCanSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCanMake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProblem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Outlet Readiness Check";
            //
            // lblIntro
            //
            this.lblIntro.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblIntro.Location = new System.Drawing.Point(20, 48);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(900, 18);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "For each product on this outlet\'s menu: can the cashier actually sell it right now, and if not, what needs doing.";
            //
            // lblOutlet
            //
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Location = new System.Drawing.Point(20, 82);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(40, 13);
            this.lblOutlet.TabIndex = 2;
            this.lblOutlet.Text = "Outlet :";
            //
            // cboOutlet
            //
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboOutlet.Location = new System.Drawing.Point(75, 78);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(300, 23);
            this.cboOutlet.TabIndex = 3;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(390, 77);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 25);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // lblSummary
            //
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(20, 115);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(900, 22);
            this.lblSummary.TabIndex = 5;
            this.lblSummary.Text = "Pick an outlet.";
            //
            // gridItems
            //
            this.gridItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItems.Location = new System.Drawing.Point(20, 145);
            this.gridItems.MainView = this.gvItems;
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(1080, 460);
            this.gridItems.TabIndex = 6;
            this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            //
            // gvItems
            //
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProduct,
            this.colPrice,
            this.colKind,
            this.colCanSell,
            this.colCanMake,
            this.colProblem,
            this.colAction});
            this.gvItems.GridControl = this.gridItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.Editable = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;
            this.gvItems.OptionsView.RowAutoHeight = true;
            this.gvItems.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvItems_RowCellStyle);
            //
            // colProduct
            //
            this.colProduct.Caption = "Product";
            this.colProduct.FieldName = "ProductName";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 0;
            this.colProduct.Width = 170;
            //
            // colPrice
            //
            this.colPrice.Caption = "Price";
            this.colPrice.DisplayFormat.FormatString = "c2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 1;
            this.colPrice.Width = 80;
            //
            // colKind
            //
            this.colKind.Caption = "Made how";
            this.colKind.FieldName = "Kind";
            this.colKind.Name = "colKind";
            this.colKind.Visible = true;
            this.colKind.VisibleIndex = 2;
            this.colKind.Width = 110;
            //
            // colCanSell
            //
            this.colCanSell.Caption = "Can sell?";
            this.colCanSell.FieldName = "CanSellText";
            this.colCanSell.Name = "colCanSell";
            this.colCanSell.Visible = true;
            this.colCanSell.VisibleIndex = 3;
            this.colCanSell.Width = 90;
            //
            // colCanMake
            //
            this.colCanMake.Caption = "Units available";
            this.colCanMake.FieldName = "Available";
            this.colCanMake.Name = "colCanMake";
            this.colCanMake.Visible = true;
            this.colCanMake.VisibleIndex = 4;
            this.colCanMake.Width = 100;
            //
            // colProblem
            //
            this.colProblem.Caption = "What is wrong";
            this.colProblem.FieldName = "Problem";
            this.colProblem.Name = "colProblem";
            this.colProblem.Visible = true;
            this.colProblem.VisibleIndex = 5;
            this.colProblem.Width = 320;
            //
            // colAction
            //
            this.colAction.Caption = "What to do";
            this.colAction.FieldName = "Action";
            this.colAction.Name = "colAction";
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 6;
            this.colAction.Width = 280;
            //
            // guiOutletReadiness
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 625);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboOutlet);
            this.Controls.Add(this.lblOutlet);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblTitle);
            this.Name = "guiOutletReadiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Readiness Check";
            this.Load += new System.EventHandler(this.guiOutletReadiness_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSummary;
        private DevExpress.XtraGrid.GridControl gridItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colKind;
        private DevExpress.XtraGrid.Columns.GridColumn colCanSell;
        private DevExpress.XtraGrid.Columns.GridColumn colCanMake;
        private DevExpress.XtraGrid.Columns.GridColumn colProblem;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
    }
}
