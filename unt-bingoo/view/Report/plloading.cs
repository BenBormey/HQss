using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Report
{
    public class plloading : IDisposable
    {
        public bool IsCompleted { get; private set; }
        public XtraReport lReport { get; private set; }

        private readonly DateTime _from;
        private readonly DateTime _to;
        private readonly Form _mdi;

        private gui_loading _loading;

        public plloading(Form mdi, DateTime from, DateTime to)
        {
            _mdi = mdi;
            _from = from;
            _to = to;

            IsCompleted = false;
            _loading = new gui_loading();
            Task.Run(LoadAsync);
            _loading.ShowDialog();
        }

        private async Task LoadAsync()
        {
            try
            {
                var data = await APIGlobals.Api.GetAsync<List<PnLDto>>(
                    $"api/Report/pnl?from={_from:yyyy-MM-dd}&to={_to:yyyy-MM-dd}"
                );

                if (data == null || data.Count == 0)
                {
                    lReport = null;
                    return;
                }
                rptPL rpt = new rptPL();
                rpt.Parameters["fromdate"].Value =
                    $"From {_from:dd-MM-yyyy} To {_to:dd-MM-yyyy}";
                rpt.Parameters["amount"].Value =string.Format("Total Sale :{0}", data[0].TotalSales);
                rpt.Parameters["totalExp"].Value = data[0].TotalCost;
                decimal netProfit = data[0].Profit;
                if (rpt.Parameters["parameter1"] != null)
                rpt.Parameters["parameter1"].Value = netProfit;
                rpt.RequestParameters = false;
                lReport = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "P&L Report Error");
                lReport = null;
            }
            finally
            {
                IsCompleted = true;
                CloseLoading();
            }
        }

        private void CloseLoading()
        {
            if (_loading == null) return;

            if (_loading.InvokeRequired)
            {
                _loading.Invoke(new Action(() =>
                {
                    _loading.Close();
                    _loading.Dispose();
                }));
            }
            else
            {
                _loading.Close();
                _loading.Dispose();
            }
        }

        public void Dispose()
        {
            _loading = null;
            lReport = null;
        }
    }
}
