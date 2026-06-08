namespace unt_bingoo.view.currency
{
    partial class guiListExchange
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
            this.lblOfficialHeader = new DevExpress.XtraEditors.LabelControl();
            this.lblRateValue = new DevExpress.XtraEditors.LabelControl();
            this.lblDatePrompt = new DevExpress.XtraEditors.LabelControl();
            this.dtpExchangeDate = new DevExpress.XtraEditors.DateEdit();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.gridExchange = new DevExpress.XtraGrid.GridControl();
            this.gvExchange = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCopyToInput = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExchangeDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExchangeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExchange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExchange)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOfficialHeader
            // 
            this.lblOfficialHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOfficialHeader.Location = new System.Drawing.Point(68, 86);
            this.lblOfficialHeader.Name = "lblOfficialHeader";
            this.lblOfficialHeader.Size = new System.Drawing.Size(139, 16);
            this.lblOfficialHeader.Text = "Official Exchange Rate :";
            // 
            // lblRateValue
            // 
            this.lblRateValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRateValue.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.lblRateValue.Location = new System.Drawing.Point(213, 86);
            this.lblRateValue.Name = "lblRateValue";
            this.lblRateValue.Size = new System.Drawing.Size(102, 16);
            this.lblRateValue.Text = "---- KHR / USD";
            // 
            // lblDatePrompt
            // 
            this.lblDatePrompt.Location = new System.Drawing.Point(68, 145);
            this.lblDatePrompt.Name = "lblDatePrompt";
            this.lblDatePrompt.Size = new System.Drawing.Size(92, 13);
            this.lblDatePrompt.Text = "Please select date :";
            // 
            // dtpExchangeDate
            // 
            this.dtpExchangeDate.EditValue = null;
            this.dtpExchangeDate.Location = new System.Drawing.Point(166, 142);
            this.dtpExchangeDate.Name = "dtpExchangeDate";
            this.dtpExchangeDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpExchangeDate.Size = new System.Drawing.Size(125, 20);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(300, 140);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // gridExchange
            // 
            this.gridExchange.Location = new System.Drawing.Point(68, 185);
            this.gridExchange.MainView = this.gvExchange;
            this.gridExchange.Name = "gridExchange";
            this.gridExchange.Size = new System.Drawing.Size(645, 410);
            this.gridExchange.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExchange});
            // 
            // gvExchange
            // 
            this.gvExchange.GridControl = this.gridExchange;
            this.gvExchange.Name = "gvExchange";
            this.gvExchange.OptionsView.ShowGroupPanel = false;
            // 
            // btnCopyToInput
            // 
            this.btnCopyToInput.Location = new System.Drawing.Point(610, 610);
            this.btnCopyToInput.Name = "btnCopyToInput";
            this.btnCopyToInput.Size = new System.Drawing.Size(103, 23);
            this.btnCopyToInput.Text = "Copy To Input";
            this.btnCopyToInput.Click += new System.EventHandler(this.btnCopyToInput_Click);
            // 
            // guiListExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 660);
            this.Controls.Add(this.btnCopyToInput);
            this.Controls.Add(this.gridExchange);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtpExchangeDate);
            this.Controls.Add(this.lblDatePrompt);
            this.Controls.Add(this.lblRateValue);
            this.Controls.Add(this.lblOfficialHeader);
            this.Name = "guiListExchange";
            this.Text = "MEF Official Exchange Rates";
            ((System.ComponentModel.ISupportInitialize)(this.dtpExchangeDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExchangeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExchange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExchange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOfficialHeader;
        private DevExpress.XtraEditors.LabelControl lblRateValue;
        private DevExpress.XtraEditors.LabelControl lblDatePrompt;
        private DevExpress.XtraEditors.DateEdit dtpExchangeDate;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraGrid.GridControl gridExchange;
        private DevExpress.XtraGrid.Views.Grid.GridView gvExchange;
        private DevExpress.XtraEditors.SimpleButton btnCopyToInput;
    }
}