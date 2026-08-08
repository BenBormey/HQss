using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using unt_bingoo.Diagnostics;
namespace unt_bingoo.view.currency
{
    public partial class guiExchange : Form
    {
        private APIsController _api;


        private BindingList<ExchangeRateModel> _list =
            new BindingList<ExchangeRateModel>();

        public guiExchange()
        {
            InitializeComponent();

            _api = APIGlobals.Api ?? new APIsController();


            gridControl1.DataSource = _list;

            this.Load += guiExchange_Load;
        }



        private async Task LoadGrid()
        {
            try
            {
                var data = await _api.GetAsync<List<ExchangeRateModel>>("api/ExchangeRate");

                _list.Clear();

                foreach (var item in data.OrderByDescending(x => x.createdDate))
                    _list.Add(item);

                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Load Error: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (nExchangRate.Value <= 0)
                {
                    XtraMessageBox.Show("Exchange Rate must be greater than 0.");
                    return;
                }
                // 1. Validate currency
                if (string.IsNullOrWhiteSpace(cboCurrency.Text))
                {
                    MessageBox.Show("Please select currency");
                    return;
                }

   
                if (!decimal.TryParse(txtAsk.Text, out decimal ask) ||
                    !decimal.TryParse(txtBid.Text, out decimal bid) ||
                    !decimal.TryParse(txtAvg.Text, out decimal avg))
                {
                    MessageBox.Show("Invalid number format");
                    return;
                }
      
             
                var selectedDate = dtDate.Value.Date;
                DateTime filter_ = DateTime.Now.Date;

        
                if (selectedDate > filter_)
                {
                    MessageBox.Show("Insertion of future dates is not allowed. Please select today’s date or a past date.",
                                    "Invalid Date",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; 
                }
                

            
                if (_list.Count > 0)
                {
                    var lastDate = _list.Max(x => x.rateDate.Date);
                    var expectedDate = lastDate.AddDays(1);
                    //var lastDate = _list.Max(x => x.rateDate.Date);
                    if (lastDate == DateTime.Today)
                    {
                    
                        MessageBox.Show("The exchange rate for today has already been entered.",
                                        "Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                       
                    }
                  

                    if (selectedDate != expectedDate)
                    {
                        var result = MessageBox.Show(
                            $"Missing exchange rate date: {expectedDate:dd-MM-yyyy}\n\nDo you want to use this date?",
                            "Missing Date",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                dtpDate.Value = expectedDate;

                                selectedDate = expectedDate;
                                return;

                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                // Professional English message
                                MessageBox.Show("The selected date is outside the valid range. Future dates are not allowed.",
                                                "Validation Error",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                // Reset to current date to keep the UI stable
                                dtDate.Value = DateTime.Today;
                                return;
                            }

                          
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                // 4. Build model
                var model = new ExchangeRateModel
                {
                    currencyCode = cboCurrency.Text,
                    rate = nExchangRate.Value,
                    ask = ask,
                    bid = bid,
                    average = avg,
                    rateDate = selectedDate,
                    note = txtRemark.Text,
                    createdDate = DateTime.Now,
                    createdBy = Environment.MachineName
                };

                // 5. Call API
                var ok = await _api.PostAsync("api/ExchangeRate", model);

                if (!ok)
                {
                    MessageBox.Show("Add failed!");
                    return;
                }

                _list.Add(model);
                await LoadGrid();
                MessageBox.Show("Added successfully ✅");

                ClearForm();
             

                try
                {
                    dtpDate.Value = selectedDate.AddDays(1);
                }
                catch (Exception ex)
                {
                    // Only realistic cause is DateTime overflow past year 9999 - the date
                    // picker just stays on the current value, nothing else to do here.
                    CrashLogger.Log(ex, CrashSource.UiThread, CrashSeverity.Recoverable, "Recoverable - date field left unchanged");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                await LoadGrid();
            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAvg.Text, out decimal avg))
            {
                nExchangRate.Value = avg;
                cboCurrency.Text = "USD";
                dtDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Invalid Avg value!");
            }
        }

        private void ClearForm()
        {
            txtRemark.Clear();
            nExchangRate.Value = 0;
        }
        private async void LoadExchangerate()
        {
            txtAsk.Text = "";
            txtAvg.Text = "";
            txtBid.Text = "";
            txtAsk.ForeColor = Color.Green;
            try
            {
                var result = await _api.GetNBCExchange();

                // GetNBCExchange goes out to nbc.gov.kh, so it returns null on
                // any network failure (no internet, site down) — and SafeCall
                // has already shown the user what went wrong. Returning quietly
                // here avoids a second, more confusing NullReferenceException
                // popup on top of it. The rate can still be entered by hand.
                if (result?.Items == null)
                    return;

                var usdKhr = result.Items
                .FirstOrDefault(x => x.Key == "USD/KHR");

                if (usdKhr == null)
                {
                    MessageBox.Show(
                        "The NBC feed did not include a USD/KHR rate today. Please enter the rate manually.",
                        "Rate Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                txtBid.Text = usdKhr.Bid.ToString();
                txtAsk.Text = usdKhr.Ask.ToString();
                txtAvg.Text = usdKhr.Average.ToString();

                // The rates above are the point of this call, so don't let an
                // unexpected date format throw them away — just leave the date
                // picker on whatever it already showed.
                DateTime dt;

                if (DateTime.TryParseExact(usdKhr.Date, "MM/dd/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out dt))
                {
                    dtpDate.Text = dt.ToString("dd-MM-yyyy");
                    dtpDate.Value = dt;
                }
           //     txtDate.Text = usdKhr.Key;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void guiExchange_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;

            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }
            DateTime now_ = DateTime.Now;
            await LoadGrid();
            this.LoadRateByDate(now_);
            cboCurrency.SelectedItem = "KHR";
            dtDate.MaxDate = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today;
        }

        private void guiExchange_Load_1(object sender, EventArgs e)
        {
        }
   






        private void btnClear_Click(object sender, EventArgs e)
        {
            nExchangRate.Value = 0;

            //cboCurrency.SelectedIndex = -1;
        //    dtDate.Value = DateTime.Now;

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            try
            {

                dtDate.Value =   dtpDate.Value;
       
                  
        

                var rate = Convert.ToDecimal(txtAsk.Text);

                if (rate > 3000 && rate < 5000)
                {
                    nExchangRate.Value = rate;
                    cboCurrency.SelectedItem = "KHR";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date format. Use dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exchange Error: " + ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repositoryItemButtonEdit1_ButtonClick(
    object sender,
    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridView1.GetFocusedRow() as ExchangeRateModel;

                if (row == null)
                {
                    MessageBox.Show("No row selected!");
                    return;
                }

                //cboCurrency.Text = row.currencyCode;
                //nExchangRate.Value = row.rate;
                //txtAsk.Text = row.ask.ToString();
                //txtBid.Text = row.bid.ToString();
                //txtAvg.Text = row.average.ToString();
                //dtDate.Value = row.rateDate;
                txtRemark.Text = row.note;

                dtpDate.Value = row.rateDate;
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = "dd-MM-yyyy";


    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit Load Error: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private async void btnRemoveTemp_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
             
                var row = gridView1.GetFocusedRow() as ExchangeRateModel;

                if (row == null)
                {
                    MessageBox.Show("No row selected!");
                    return;
                }

        
                var confirm = MessageBox.Show(
                    $"Are you sure to delete rate: {row.currencyCode} ({row.rateDate:dd/MM/yyyy}) ?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

         
                var result = await _api.DeleteAsync($"api/ExchangeRate/{row.id}");

                if (!result)
                {
                    MessageBox.Show("Delete failed!");
                    return;
                }

      
                _list.Remove(row);

                MessageBox.Show("Deleted successfully ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void repositoryItemButtonEdit2_ButtonClick(
         object sender,
         DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridView1.GetFocusedRow() as ExchangeRateModel;

                if (row == null)
                {
                    MessageBox.Show("No row selected!");
                    return;
                }

                // Find latest date in list
                var lastDate = _list.Max(x => x.rateDate.Date);

                // Allow delete only latest date
                if (row.rateDate.Date != lastDate)
                {
                    MessageBox.Show(
                        $"You can only delete the latest exchange rate entry.\n\n" +
                        $"Latest Date: {lastDate:dd-MM-yyyy}",
                        "Delete Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Are you sure to delete rate: {row.currencyCode} ({row.rateDate:dd/MM/yyyy}) ?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                var result = await _api.DeleteAsync($"api/ExchangeRate/{row.id}");

                if (!result)
                {
                    MessageBox.Show("Delete failed!");
                    return;
                }

                _list.Remove(row);

                MessageBox.Show("Deleted successfully ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async Task LoadRateByDate(DateTime selectedDate)
        {
            try
            {
        

                APIsController api = APIGlobals.Api ?? new APIsController();

                var result = await api.GetListByDate(selectedDate);

                // Same split as LoadExchangerate: a null result means the call
                // to data.mef.gov.kh itself failed and SafeCall already said so,
                // whereas a null .data means the feed answered but has nothing
                // for that date. Reporting the first as "no data" blamed the
                // date when the real cause was the connection.
                if (result == null)
                    return;

                if (result.data != null)
                {
               
               

                    // fill textbox
                  
                    txtBid.Text = result.data.bid.ToString("N0");
                    txtAvg.Text = result.data.average.ToString("N0");
                    txtAsk.Text = result.data.Ask.ToString("N0");
                    dtDate.Value = dtpDate.Value;
            
                       var rate = Convert.ToDecimal(txtAsk.Text);
                    nExchangRate.Value = rate;

                }
                else
                {
                    MessageBox.Show("No data found for selected date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message);
            }
            finally
            {
               // btnView.Enabled = true;
            }
        }
        private async void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime datefilter =Convert.ToDateTime(txtDate.Text);
          
                await LoadRateByDate(datefilter);
            
        }

        private async void txtDate_Validated(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtDate.Text, out DateTime selectedDate))
            {
                await LoadRateByDate(selectedDate);
            }
        }

        private async void dtpDate_ValueChanged(object sender, EventArgs e)
        {
     

            await LoadRateByDate(dtpDate.Value);
        }

        private void dtpDate_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "RowNum")
            {
                // Display the row handle + 1 (so it starts at 1 instead of 0)
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }




private void BtnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show(
                    "No data to export.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Cursor = Cursors.WaitCursor;

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet =
                (Excel.Worksheet)workbook.ActiveSheet;

            int excelCol = 1;

      
            for (int col = 0; col < gridView1.Columns.Count; col++)
            {
                string fieldName =
                    (gridView1.Columns[col].FieldName ?? "")
                    .Trim()
                    .ToLower();

                if (fieldName == "rownum" ||
                    fieldName == "createddate" ||
                    fieldName == "note" ||
                    string.IsNullOrWhiteSpace(fieldName))
                {
                    continue;
                }

                worksheet.Cells[1, excelCol] =
                    gridView1.Columns[col].Caption;

                Excel.Range headerCell =
                    (Excel.Range)worksheet.Cells[1, excelCol];

                headerCell.Font.Bold = true;

                excelCol++;
            }


            for (int row = 0; row < gridView1.RowCount; row++)
            {
                excelCol = 1;

                for (int col = 0; col < gridView1.Columns.Count; col++)
                {
                    string fieldName =
                        (gridView1.Columns[col].FieldName ?? "")
                        .Trim()
                        .ToLower();

                    if (fieldName == "rownum" ||
                        fieldName == "createddate" ||
                        fieldName == "note" ||
                        string.IsNullOrWhiteSpace(fieldName))
                    {
                        continue;
                    }

                    object value =
                        gridView1.GetRowCellValue(
                            row,
                            gridView1.Columns[col]);

                    if (fieldName == "rate")
                    {
                        if (decimal.TryParse(
                            value?.ToString(),
                            out decimal rate))
                        {
                            worksheet.Cells[row + 2, excelCol] = rate;

                            ((Excel.Range)worksheet.Cells[row + 2, excelCol])
                                .NumberFormat = "#,##0.00";
                        }
                        else
                        {
                            worksheet.Cells[row + 2, excelCol] = 0;
                        }
                    }
                    else if (value is DateTime dt)
                    {
                        worksheet.Cells[row + 2, excelCol] =
                            dt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        worksheet.Cells[row + 2, excelCol] =
                            value?.ToString() ?? "";
                    }

                    excelCol++;
                }
            }

            worksheet.Columns.AutoFit();


            excelApp.ActiveWindow.SplitRow = 1;
            excelApp.ActiveWindow.FreezePanes = true;

            Cursor = Cursors.Default;

            MessageBox.Show(
                "Export completed successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            Cursor = Cursors.Default;

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

}
}