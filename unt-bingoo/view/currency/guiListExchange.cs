using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.currency
{
    public partial class guiListExchange : DevExpress.XtraEditors.XtraForm
    {
        // Property to pass the selected rate back to your main form
        public decimal SelectedRate { get; private set; }

        public guiListExchange()
        {
            InitializeComponent();
            // Set default date to today for the MEF API
            dtpExchangeDate.DateTime = DateTime.Now;
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = false;
                APIsController api = new APIsController();

                // Call the MEF API using the date from the picker
                var result = await api.GetListByDate(dtpExchangeDate.DateTime);

                if (result?.data != null)
                {
                    // Update header label
                    lblRateValue.Text = $"{result.data.bid:N0} KHR / {result.data.currency_id}";

                    // Bind data to the DevExpress Grid
                    gridExchange.DataSource = new List<MefData> { result.data };
                    gvExchange.BestFitColumns();
                }
                else
                {
                    XtraMessageBox.Show("No data found for the selected date.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("API Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnView.Enabled = true;
            }
        }

       
        public DateTime SelectedDate { get; private set; }

        private void btnCopyToInput_Click(object sender, EventArgs e)
        {
      
            var data = gvExchange.GetFocusedRow() as MefData;

            if (data != null)
            {
              
                SelectedRate = data.bid;

            
                if (DateTime.TryParse(data.valid_date, out DateTime validDate))
                {
                    SelectedDate = validDate;
                }
                else
                {
                    SelectedDate = DateTime.Now;
                }

               
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Please select a row in the grid first.", "Selection Required");
            }
        }
    }
}