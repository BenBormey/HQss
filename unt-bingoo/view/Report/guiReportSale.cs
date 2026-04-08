using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using unt_bingoo.view.Report;

namespace unt_bingoo.view.Report
{
    public partial class guiReportSale : XtraForm
    {
    
        public Form lMDI { get; set; }

        public guiReportSale()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {

                if (dtpStart.Value.Date > dtpEnd.Value.Date)
                {
                    XtraMessageBox.Show(
                        "Start Date cannot be greater than End Date.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                btnPreview.Enabled = false;


                plloading loader = new plloading(
                    this.lMDI,
                    dtpStart.Value.Date,
                    dtpEnd.Value.Date
                );

          
                while (!loader.IsCompleted)
                    Application.DoEvents();

                if (loader.lReport == null)
                {
                    XtraMessageBox.Show(
                        "No data found for selected period.",
                        "No Report",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

         
                gui_preview_report gui_ = new gui_preview_report
                {
                    MdiParent = this.lMDI,
                    WindowState = FormWindowState.Maximized
                }; 

                gui_.Show();
                gui_.dcviewer.DocumentSource = loader.lReport;

                var ps = gui_.dcviewer.PrintingSystem;
                ps.SetCommandVisibility(
                    DevExpress.XtraPrinting.PrintingSystemCommand.Customize,
                    DevExpress.XtraPrinting.CommandVisibility.None);
                ps.SetCommandVisibility(
                    DevExpress.XtraPrinting.PrintingSystemCommand.Parameters,
                    DevExpress.XtraPrinting.CommandVisibility.None);
                ps.SetCommandVisibility(
                    DevExpress.XtraPrinting.PrintingSystemCommand.SubmitParameters,
                    DevExpress.XtraPrinting.CommandVisibility.None);

                loader.lReport.CreateDocument(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Report Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnPreview.Enabled = true;
            }
        }
    }
}
