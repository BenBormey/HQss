using System;
using DevExpress.XtraEditors;

namespace unt_bingoo.view.Supplier
{
    public partial class guiSupplierReport : XtraForm
    {
        public guiSupplierReport()
        {
            InitializeComponent();
        }

        // The caller reads these after ShowDialog() returns DialogResult.OK
        public bool WithBuyinPrice => chkBuyinPrice.Checked;
        public bool WithSellingPrice => chkSellingPrice.Checked;
        public bool WithPicture => chkPicture.Checked;
        public bool RemoveDCItems => chkRemoveDC.Checked;
        public bool RemoveItemsOutOfStock => chkRemoveOutOfStock.Checked;

        private void btnExport_Click(object sender, EventArgs e)
        {
            // DialogResult.OK is already set on the button in the designer,
            // so the form closes automatically. Add validation here if needed.
        }
    }
}