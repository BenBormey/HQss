using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.currency
{
    public partial class guiListExchange : Form
    {
        private readonly APIsController _api;
        private List<ExchangeRateModel> _list = new List<ExchangeRateModel>();

        public decimal SelectedRate { get; private set; }
        public DateTime SelectedDate { get; private set; }

        public guiListExchange()
        {
            InitializeComponent();
            _api = APIGlobals.Api ?? new APIsController();
        }

        private async void guiListExchange_Load(object sender, EventArgs e)
        {
            try
            {
                var data = await _api.GetAsync<List<ExchangeRateModel>>("api/ExchangeRate")
                           ?? new List<ExchangeRateModel>();

                _list = data.OrderByDescending(x => x.rateDate).ToList();

                dgvExchange.DataSource = _list
                    .Select(x => new
                    {
                        x.currencyCode,
                        x.rate,
                        x.ask,
                        x.bid,
                        x.average,
                        x.rateDate,
                        x.note
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void dgvExchange_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SelectRow();
        }

        private void SelectRow()
        {
            if (dgvExchange.CurrentRow == null || dgvExchange.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a row.");
                return;
            }

            var row = _list[dgvExchange.CurrentRow.Index];

            SelectedRate = row.rate;
            SelectedDate = row.rateDate;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
