using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Vat
{
    // Single outlet-wide VAT rate the POS applies to every order. Reads and
    // writes api/VatSetting. Open it with: new guiVateSetting().ShowDialog();
    public partial class guiVateSetting : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api;

        // Mirrors api/VatSetting's JSON response.
        private class VatSettingDto
        {
            public int Id { get; set; }
            public decimal Percent { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }

        public guiVateSetting()
        {
            InitializeComponent();
            _api = APIGlobals.Api;
        }

        private async void guiVateSetting_Load(object sender, EventArgs e)
        {
            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }

            try
            {
                var setting = await _api.GetAsync<VatSettingDto>("api/VatSetting");

                if (setting != null)
                {
                    numPercent.Value = Math.Min(Math.Max(setting.Percent, 0m), 99.99m);

                    if (setting.UpdatedAt.HasValue)
                        lblStatus.Text = "Last changed " + setting.UpdatedAt.Value.ToString("dd MMM yyyy HH:mm")
                            + (string.IsNullOrWhiteSpace(setting.UpdatedBy) ? "" : " by " + setting.UpdatedBy);
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = "Could not load: " + ex.Message;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "Saving...";

            try
            {
                var percent = numPercent.Value;
                var updatedBy = !string.IsNullOrWhiteSpace(APIGlobals.FullName) ? APIGlobals.FullName
                    : !string.IsNullOrWhiteSpace(APIGlobals.UserName) ? APIGlobals.UserName
                    : "md";

                // The endpoint takes its args from the query string ([FromQuery]);
                // the JSON body is ignored, so an empty object is fine.
                var url = "api/VatSetting?percent="
                    + percent.ToString(CultureInfo.InvariantCulture)
                    + "&updatedBy=" + Uri.EscapeDataString(updatedBy);

                var ok = await _api.PutAsync(url, new { });

                if (ok)
                {
                    lblStatus.ForeColor = Color.SeaGreen;
                    lblStatus.Text = "Saved. New VAT rate: " + percent.ToString("0.##") + "%";
                }
                else
                {
                    lblStatus.ForeColor = Color.Firebrick;
                    lblStatus.Text = "Save failed.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Firebrick;
                lblStatus.Text = ex.Message;
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}
