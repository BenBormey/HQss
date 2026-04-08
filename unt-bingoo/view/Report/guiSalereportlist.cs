using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Class.Report;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Report
{
    public partial class guiSalereportlist : DevExpress.XtraEditors.XtraForm
    {
        public guiSalereportlist()
        {
            InitializeComponent();

            this.Load += guiSalereportlist_Load;
        }

        private async void guiSalereportlist_Load(object sender, EventArgs e)
        {
            try
            {

                var outlets = await APIGlobals.Api
                    .GetAsync<List<OutletItem>>("/api/outlet");


                outlets.Insert(0, new OutletItem
                {
                    Id = 0,
                    OutletName = "ALL OUTLETS"
                });
                 
                cboOutlet.DataSource = outlets;
                cboOutlet.DisplayMember = "OutletName";
                cboOutlet.ValueMember = "Id";

                cboOutlet.SelectedIndex = 0;

                // default dates
                dtStart.Value = DateTime.Today;
                dtEnd.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Load Outlet Failed");
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = dtStart.Value.Date;
                DateTime to = dtEnd.Value.Date;

                if (from > to)
                {
                    XtraMessageBox.Show("Start date must be before End date");
                    return;
                }

                int? outletId = null;

                if (cboOutlet.SelectedValue != null)
                {
                    int value = Convert.ToInt32(cboOutlet.SelectedValue);

                    if (value > 0)
                        outletId = value;
                }

                var loader = new loadingreportSale(
                    this.MdiParent as mainForm,
                    from,
                    to,
                    outletId);

                if (loader.lReport != null)
                {
                    loader.lReport.ShowPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Preview Error");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
