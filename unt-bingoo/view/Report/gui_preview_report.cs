using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unt_bingoo.view.Report
{
    public partial class gui_preview_report : DevExpress.XtraEditors.XtraForm
    {
        public gui_preview_report()
        {
            InitializeComponent();
        }

        private void gui_preview_report_Load(object sender, EventArgs e)
        {

        }

        private void PrintPreviewRibbonPageGroup7_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
           
        }

        private void PrintPreviewBarItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
              
        }

        private void PrintPreviewBarItem25_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
        }
        private void SetupXlsxExport()
        {
            // Assuming 'printBarManager' or your PrintPreview exists
         //   this.PrintPreviewBarItem36.ItemClick += PrintPreviewBarItem36_ItemClick;
        }
        private void PrintPreviewBarItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XlsxExportOptionsEx options = new XlsxExportOptionsEx()
            {
                ExportType = DevExpress.Export.ExportType.WYSIWYG, // or DataAware
                TextExportMode = TextExportMode.Text,
                ExportMode = XlsxExportMode.SingleFile
            };

            // This will prevent merging in DataAware mode
            options.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;

            // Export
            dcviewer.PrintingSystem.ExportToXlsx("report.xlsx", options);

            MessageBox.Show("Export completed!");
        }

    }
}