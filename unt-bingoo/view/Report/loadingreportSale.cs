using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class.Report;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Report
{
    public class loadingreportSale : IDisposable
    {
        public bool IsCompleted { get; private set; }

        public XtraReport lReport { get; private set; }

        private readonly DateTime _from;
        private readonly DateTime _to;
        private readonly int? _outletId;

        private readonly mainForm MDI;

        private gui_loading _loading;


        public loadingreportSale(
            mainForm mdi,
            DateTime from,
            DateTime to,
            int? outletId)
        {
            MDI = mdi;
            _from = from;
            _to = to;
            _outletId = outletId;

            IsCompleted = false;

            _loading = new gui_loading();

            Task.Run(LoadAsync);

            _loading.ShowDialog();
        }

        private async Task LoadAsync()
        {
            try
            {
            
                string url =
                    $"/api/Report/sales?from={_from:yyyy-MM-dd}&to={_to:yyyy-MM-dd}";

                if (_outletId.HasValue)
                    url += $"&outletId={_outletId.Value}";

                // CALL API
                var data = await APIGlobals.Api
                    .GetAsync<List<SalesReportDto>>(url);

                if (data == null || data.Count == 0)
                {
                    lReport = null;
                    return;
                }

       
                rptSale rpt = new rptSale();

                rpt.DataSource = data;

            
                rpt.Parameters["pDateFrom"].Value = _from;
                rpt.Parameters["pDateTo"].Value = _to;

                rpt.Parameters["pOutletName"].Value =
                    _outletId.HasValue ? data[0].OutletName : "ALL OUTLETS";

                rpt.Parameters["pDateFrom"].Visible = false;
                rpt.Parameters["pDateTo"].Visible = false;
                rpt.Parameters["pOutletName"].Visible = false;

                lReport = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sale Report Error");
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
            if (_loading.InvokeRequired)
                _loading.Invoke(new Action(() => _loading.Close()));
            else
                _loading.Close();
        }

        public void Dispose()
        {
            _loading?.Dispose();
            lReport?.Dispose();
        }
    }
}
