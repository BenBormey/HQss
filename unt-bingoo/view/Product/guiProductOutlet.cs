using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Class.ProductScal;
using unt_bingoo.Controller;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Product
{
    public partial class guiProductOutlet : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private mainForm mdi;

        public List<ProductItem> RProductList;

        public string RWord_Searching;
       private bool lIsMainProducts;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        private string DatabaseName;
        private BindingSource DataBindingSource;
        public guiProductOutlet(mainForm mdi, bool lIsMainProducts)
        {
            InitializeComponent();
            LoadingInitialized();
            this.mdi = mdi;
            this.lIsMainProducts = lIsMainProducts;


            DataBindingSource = new BindingSource();
        }
        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
            TimerCurrencyLoading.Enabled = true;
            TimerUOMLoading.Enabled = true;
        }
        private void BtnAddDel_Click(object sender, EventArgs e)
        {

        }
        private void DataLoading()
        {
            //IsUpdated = false;

            // API Count
            // var totalItems = await _api.GetAsync<int>("api/Product/count");
            // var availableItems = await _api.GetAsync<int>("api/Product/count-available");

            // LblNumberOfItems.Text = $"Numbers of Items : {totalItems}";
            // LblAvailabelItems.Text = $"Available Items : {availableItems}";

            DataBindingSource.DataSource = RProductList;

            TxtId.DataBindings.Clear();
            TxtUnitNumber.DataBindings.Clear();
            TxtPackNumber.DataBindings.Clear();
            TxtCaseNumber.DataBindings.Clear();
            TxtSKU.DataBindings.Clear();
            TxtSupplierCode.DataBindings.Clear();
            CmbSupplier.DataBindings.Clear();
            CmbShelfliferequired.DataBindings.Clear();
            TxtKhmerName.DataBindings.Clear();
            TxtProductsName.DataBindings.Clear();
            TxtSize.DataBindings.Clear();
            TxtDescription.DataBindings.Clear();
            CmbCategory.DataBindings.Clear();
            TxtMadeIn.DataBindings.Clear();
            DTPBirthDate.DataBindings.Clear();
            TxtCurrentStock.DataBindings.Clear();
            TxtQtySold.DataBindings.Clear();
            TxtOrderLevel.DataBindings.Clear();
            TxtOrderAmount.DataBindings.Clear();
            TxtRemark.DataBindings.Clear();
            CmbFactoryCurrency.DataBindings.Clear();
            CmbFOBCIF.DataBindings.Clear();
            TxtFactoryCost.DataBindings.Clear();
            CmbCurrency.DataBindings.Clear();
            txtFormDLanded.DataBindings.Clear();
            TxtBuyin.DataBindings.Clear();
            TxtBuyinDiscount.DataBindings.Clear();
            TxtBuyinVAT.DataBindings.Clear();
            txtexcisetax.DataBindings.Clear();
            txtpubliclightingtax.DataBindings.Clear();
            TxtTotalBuyin.DataBindings.Clear();
            TxtAveragePrice.DataBindings.Clear();
            TxtUnitPrice.DataBindings.Clear();
            TxtSuggest.DataBindings.Clear();
            TxtQtyPerPack.DataBindings.Clear();
            TxtUnitProfit.DataBindings.Clear();
            TxtPackPrice.DataBindings.Clear();
            TxtPackProfit.DataBindings.Clear();
            TxtQtyPerCase.DataBindings.Clear();
            TxtCasePriceDiscount.DataBindings.Clear();
            TxtCasePrice.DataBindings.Clear();
            TxtCaseProfit.DataBindings.Clear();
            CmbShelfLifeOfProduct.DataBindings.Clear();
            txtvop.DataBindings.Clear();

            Navigator.BindingSource = DataBindingSource;


            if (DataBindingSource.DataSource != null)
            {
                TxtId.DataBindings.Add("Text", DataBindingSource, "ProID");
                TxtUnitNumber.DataBindings.Add("Text", DataBindingSource, "ProNumY");
                TxtPackNumber.DataBindings.Add("Text", DataBindingSource, "ProNumYP");
                TxtCaseNumber.DataBindings.Add("Text", DataBindingSource, "ProNumYC");
                TxtSKU.DataBindings.Add("Text", DataBindingSource, "ProSKU");
                TxtSupplierCode.DataBindings.Add("Text", DataBindingSource, "ProNumS");

                // SupNum => Sup1
                CmbSupplier.DataBindings.Add(
                    "SelectedValue",
                    DataBindingSource,
                    "Sup1");

                CmbShelfliferequired.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "Sup2");

                TxtProductsName.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProName");

                TxtKhmerName.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "KhmerName");

                TxtSize.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProPacksize");

                TxtDescription.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProDes");

                CmbCategory.DataBindings.Add(
                    "SelectedValue",
                    DataBindingSource,
                    "ProCat");

                TxtMadeIn.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProMadein");

                DTPBirthDate.DataBindings.Add(
                    "Value",
                    DataBindingSource,
                    "BirthDate");

                TxtCurrentStock.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProTotQty");

                TxtQtySold.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProSSec");

                TxtOrderLevel.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProRecLev");

                TxtOrderAmount.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProRecOrder");

                TxtRemark.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProRem");

                TxtFactoryCost.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "FOBCIFCost");

                TxtBuyin.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProImpPri");

                TxtBuyinDiscount.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProDis");

                TxtBuyinVAT.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProVAT");

                txtexcisetax.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ExciseTax");

                txtpubliclightingtax.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "PublicLightingTax");

                TxtTotalBuyin.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProFinBuyin");

                TxtAveragePrice.DataBindings.Add(
                    new Binding(
                        "Text",
                        DataBindingSource,
                        "Average",
                        true,
                        DataSourceUpdateMode.Never,
                        0,
                        "N4"));

                TxtUnitPrice.DataBindings.Add(
                    new Binding(
                        "Text",
                        DataBindingSource,
                        "ProUPrSE",
                        true,
                        DataSourceUpdateMode.Never,
                        0,
                        "N2"));

                TxtPackPrice.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProPckPri");

                TxtCasePrice.DataBindings.Add(
                    new Binding(
                        "Text",
                        DataBindingSource,
                        "ProUPriSeH",
                        true,
                        DataSourceUpdateMode.Never,
                        0,
                        "N2"));

                TxtQtyPerPack.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProQtyPPack");

                TxtQtyPerCase.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProQtyPCase");

                TxtUnitProfit.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProProPer");

                TxtPackProfit.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProPckDis");

                TxtCasePriceDiscount.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProHolesaleper");

                TxtCaseProfit.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProHoleSalePP");

                CmbFactoryCurrency.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "FactoryCurrency");

                CmbFOBCIF.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "FOB_CIF");

                CmbCurrency.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ProCurr");

                txtFormDLanded.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "FormDLanded");

                CmbShelfLifeOfProduct.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "ShelfLifeOfProduct");

                txtvop.DataBindings.Add(
                    "Text",
                    DataBindingSource,
                    "VOP");

                if (Navigator.BindingSource.Count > 0)
                {
                    RefreshItems();
                }
                else
                {
                    BtnAddNew_Click(BtnAddNew, EventArgs.Empty);
                }
            }
            else
            {
                BtnAddNew_Click(BtnAddNew, EventArgs.Empty);
            }
        }
        private void RefreshItems()
        {
            LoadingInitialized();

            DeliveryLogisticLoading.Enabled = true;
            disDimensionLoading.Enabled = true;

            PicProducts.Image = null;

            string status = "";

            if (DataBindingSource.Current is DataRowView row)
            {
                status = Convert.ToString(row["Status"])?.Trim() ?? "";
            }

            if (status == "Deactivated" || status == "Old_Deactivated")
            {
                BtnMoveToDeactivated.Text = "&Move To Products";
                LblStatus.Visible = true;
            }
            else
            {
                BtnMoveToDeactivated.Text = "&Move To Deactivated";
                LblStatus.Visible = false;
            }

            // បើបងមាន Image Column ក្នុង Product Table
            /*
            if (DataBindingSource.Current is DataRowView currentRow)
            {
                if (currentRow["ProImage"] != DBNull.Value)
                {
                    PicProducts.Image =
                        App.BytetoImage((byte[])currentRow["ProImage"]);
                }
            }
            */

            TxtStockOldCode.Text = "0";
            TxtStockGRNTemp.Text = "0";

            //if (!mdi.isAdmin)
            //{
            //    BtnMoveToDeactivated.Enabled = false;

            //    // បើមាន Role/Permission API
            //    // អាច call API មក verify នៅទីនេះ

            //    BtnMoveToDeactivated.Enabled = true;
            //}
        }
        private void TimerCurrencyLoading_Tick(object sender, EventArgs e)
        {

        }
        private async void LoadingSupplier()
        {
            try
            {
                var list = await _api.GetAsync<List<SupplierItem>>("api/Supplier");

                CmbSupplier.DataSource = list;
                CmbSupplier.DisplayMember = "SupplierName";
                CmbSupplier.ValueMember = "SupplierCode";
                CmbSupplier.SelectedIndex = -1;

                //if (DataBindingSource?.DataSource != null)
                //{
                //    string supNum = "";

                //    if (DataBindingSource.Current is DataRowView row)
                //    {
                //        supNum = Convert.ToString(row["SupNum"])?.Trim() ?? "";
                //    }

                //    if (!string.IsNullOrWhiteSpace(supNum))
                //    {
                //        CmbSupplier.SelectedValue = supNum;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void guiProductOutlet_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;

            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }
            this.CityLoading.Enabled = true;
      
         
            DataBindingSource = new BindingSource();
            this.LoadingSupplier();
            this.LoadingShelfLifeOfProductLoading();
            this.TimerCategoryLoading.Enabled = true;
            this.DataLoading();
            if (TxtId.Text == "")
            {
                TxtUnitNumber_Click(TxtUnitNumber, EventArgs.Empty);
            }
        }
        private void LoadingShelfLifeOfProductLoading()
        {
            try
            {
                string query = @"
            SELECT DISTINCT ShelfLifeOfProduct
            FROM [DBJuJuBi].[dbo].[TPRProducts]
            ORDER BY ShelfLifeOfProduct";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Data.strConnection))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        dt.Load(cmd.ExecuteReader());
                    }
                }

                CmbShelfLifeOfProduct.DataSource = dt;
                CmbShelfLifeOfProduct.DisplayMember = "ShelfLifeOfProduct";
                CmbShelfLifeOfProduct.ValueMember = "ShelfLifeOfProduct";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {

        }

        private List<ProductItem> _products;

        private async Task LoadProductAsync()
        {
            try
            {
                var products = await _api.GetAsync<List<ProductItem>>("api/Product");

                if (products == null || products.Count == 0)
                    return;

                BindProduct(products[0]); // យក row ដំបូង
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BindProduct(ProductItem product)
        {
            if (product == null)
                return;

            TxtId.Text = product.ProID.ToString();
            TxtUnitNumber.Text = product.ProNumY;
            TxtPackNumber.Text = product.ProNumYP;
            TxtCaseNumber.Text = product.ProNumYC;
            TxtSKU.Text = product.ProSKU;
            TxtSupplierCode.Text = product.ProNumS;

            TxtKhmerName.Text = product.KhmerName;
            TxtProductsName.Text = product.ProName;
            TxtSize.Text = product.ProPacksize;
            TxtDescription.Text = product.ProDes;
            TxtMadeIn.Text = product.ProMadein;

            TxtCurrentStock.Text = product.ProTotQty.ToString();
            TxtQtySold.Text = product.ProSSec.ToString();
            TxtOrderLevel.Text = product.ProRecLev.ToString();
            TxtOrderAmount.Text = product.ProRecOrder.ToString();

            TxtRemark.Text = product.ProRem;

            TxtFactoryCost.Text = product.FOBCIFCost.ToString();
            txtFormDLanded.Text = product.FormDLanded.ToString();

            TxtBuyin.Text = product.ProImpPri.ToString();
            TxtBuyinDiscount.Text = product.ProDis.ToString();
            TxtBuyinVAT.Text = product.ProVAT.ToString();

            txtexcisetax.Text = product.ExciseTax.ToString();
            txtpubliclightingtax.Text = product.PublicLightingTax.ToString();

            TxtTotalBuyin.Text = product.ProFinBuyin.ToString();
            TxtAveragePrice.Text = product.Average.ToString();

            TxtUnitPrice.Text = product.ProUPrSE.ToString();
            TxtSuggest.Text = product.ProRecPer.ToString();

            TxtQtyPerPack.Text = product.ProQtyPPack.ToString();
            TxtUnitProfit.Text = product.ProProPer.ToString();

            TxtPackPrice.Text = product.ProPckPri.ToString();
            TxtPackProfit.Text = product.ProPckDis.ToString();

            TxtQtyPerCase.Text = product.ProQtyPCase.ToString();
            TxtCasePriceDiscount.Text = product.ProHolesaleper.ToString();
            TxtCasePrice.Text = product.ProUPriSeH.ToString();

            txtvop.Text = product.VOP.ToString();

            CmbFOBCIF.Text = product.FOB_CIF;
            CmbShelfLifeOfProduct.Text = product.ShelfLifeOfProduct;
        }
        private async void CityLoading_Tick(object sender, EventArgs e)
        {
            try
            {
                CityLoading.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var list = await _api.GetAsync<List<ProvinceItem>>("api/Province");

                cmbProvince.Properties.Items.Clear();

                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        cmbProvince.Properties.Items.Add(
                            item.provinceId,       
                            item.provinceNameEN,   
                            CheckState.Unchecked,
                            true
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnAddDel_Click_1(object sender, EventArgs e)
        {

        }

 
        public static void DataSources(
    System.Windows.Forms.ComboBox combo,
    DataTable dt,
    string displayMember,
    string valueMember)
        {
            combo.DataSource = null;
            combo.DisplayMember = "";
            combo.ValueMember = "";

            combo.DataSource = dt;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
        }
        private void TxtUnitNumber_Click(object sender, EventArgs e)
        {
            bool isVisible = false;

            if (!string.IsNullOrWhiteSpace(TxtPackNumber.Text))
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Not allow to change this barcode. It contains pack code!" +
                        Environment.NewLine +
                        "Do you want to go ahead?(Yes/No)",
                        "Confirm Change Unit Number",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                isVisible = true;
            }
            else if (!string.IsNullOrWhiteSpace(TxtCaseNumber.Text))
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Not allow to change this barcode. It contains case code!" +
                        Environment.NewLine +
                        "Do you want to go ahead?(Yes/No)",
                        "Confirm Change Unit Number",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                isVisible = true;
            }

            while (true)
            {
                Initialized.R_Barcode = "";

                FrmProductsBarcode lGUI =
                    new FrmProductsBarcode(this.mdi, this.lIsMainProducts);

                lGUI.PanelAlert.Visible = isVisible;
                lGUI.RCurrentBarcode = TxtUnitNumber.Text.Trim();
                lGUI.RProId = (long)Convert.ToDecimal(
                    string.IsNullOrWhiteSpace(TxtId.Text)
                        ? "0"
                        : TxtId.Text.Trim());

                if (lGUI.ShowDialog() == DialogResult.Cancel)
                    return;

                bool barcodeExists =
                    !string.IsNullOrWhiteSpace(Initialized.R_Barcode) &&
                    (
                        Initialized.R_Barcode.Trim() == TxtSKU.Text.Trim() ||
                        Initialized.R_Barcode.Trim() == TxtPackNumber.Text.Trim() ||
                        Initialized.R_Barcode.Trim() == TxtCaseNumber.Text.Trim()
                    );

                if (barcodeExists)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"This barcode <{Initialized.R_Barcode.Trim()}> is existed already!" +
                        Environment.NewLine +
                        "Please check the barcode again...",
                        "Existed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    continue; // VB GoTo Err_again
                }

                break;
            }

            TxtUnitNumber.Text = Initialized.R_Barcode.Trim();
            TxtSKU.Text = Initialized.R_Barcode.Trim();
        }

        private void TxtPackNumber_Click(object sender, EventArgs e)
        {
   

            Initialized.R_Barcode = "";

            using (var lGUI = new FrmProductsPackNumber(this.mdi, this.lIsMainProducts))
            {
                lGUI.RUnitNumber = TxtUnitNumber.Text.Trim();
                lGUI.RCurrentBarcode = TxtPackNumber.Text.Trim();

                decimal proId = 0;
                decimal.TryParse(TxtId.Text.Trim(), out proId);
                lGUI.RProId = proId;

                if (lGUI.ShowDialog() == DialogResult.Cancel)
                    return;
            }

            if (!string.IsNullOrWhiteSpace(Initialized.R_Barcode) &&
                (Initialized.R_Barcode.Trim() == TxtUnitNumber.Text.Trim() ||
                 Initialized.R_Barcode.Trim() == TxtSKU.Text.Trim() ||
                 Initialized.R_Barcode.Trim() == TxtCaseNumber.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"This barcode <{Initialized.R_Barcode.Trim()}> is existed already!\r\nPlease check the barcode again...",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

        
            }

            TxtPackNumber.Text = Initialized.R_Barcode.Trim();
        }

        private void TxtCaseNumber_Click(object sender, EventArgs e)
        {
            Initialized.R_Barcode = "";

            FrmProductsCaseNumber lGUI = new FrmProductsCaseNumber(this.mdi, this.lIsMainProducts);

            lGUI.RUnitNumber = TxtUnitNumber.Text.Trim();
            lGUI.RCurrentBarcode = TxtCaseNumber.Text.Trim();
            lGUI.RProId = (long)(string.IsNullOrWhiteSpace(TxtId.Text)
                            ? 0
                            : Convert.ToDecimal(TxtId.Text.Trim()));

            if (lGUI.ShowDialog() == DialogResult.Cancel)
                return;

            if (!string.IsNullOrWhiteSpace(Initialized.R_Barcode) &&
                (
                    Initialized.R_Barcode.Trim() == TxtUnitNumber.Text.Trim() ||
                    Initialized.R_Barcode.Trim() == TxtPackNumber.Text.Trim() ||
                    Initialized.R_Barcode.Trim() == TxtSKU.Text.Trim()
                ))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"This barcode <{Initialized.R_Barcode.Trim()}> is existed already!\r\nPlease check the barcode again...",
                    "Existed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }

            TxtCaseNumber.Text = Initialized.R_Barcode.Trim();
        }

        private void TxtKhmerName_Leave(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "en-US")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void TxtKhmerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;



            if (e.KeyChar < 0x1780 || e.KeyChar > 0x17FF)
            {
                e.Handled = true;
            }
        }

        private void TxtKhmerName_Enter(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.Name == "km-KH")
                {
                    InputLanguage.CurrentInputLanguage = lang;
                    break;
                }
            }
        }

        private void txtexcisetax_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, "", 25);
        }

        private void TxtBuyinVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, "", 10);
        }
        public float CalculateUnitPercentage(
    double average,
    double qtyPerCase,
    double unitPrice)
        {
            if (qtyPerCase == 0 || unitPrice == 0)
                return 0;

            double buyIn = average / qtyPerCase;

            double percent =
                ((unitPrice - buyIn) / unitPrice) * 100;

            return (float)Math.Round(percent, 2);
        }
        private void TxtFactoryCost_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                    App.KeyPress(
                            sender,
                            e,
                            ApplicationFramework.TypeKeyPress.Format_Float,
                            null,
                            25);
        }

        private void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if(TxtAveragePrice.Text == "")
            {
                return;
            }
            double average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
     ? 0
     : Convert.ToDouble(TxtAveragePrice.Text.Trim());

            int qtyPerCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerCase.Text.Trim());

            double unitPrice = string.IsNullOrWhiteSpace(TxtUnitPrice.Text)
                ? 0
                : Convert.ToDouble(TxtUnitPrice.Text.Trim());

            float unitPercent = CalculateUnitPercentage(
                average,
                qtyPerCase,
                unitPrice);

            TxtUnitProfit.Text = unitPercent.ToString("N2");

            float dis = string.IsNullOrWhiteSpace(TxtCasePriceDiscount.Text)
                ? 0
                : Convert.ToSingle(TxtCasePriceDiscount.Text.Trim());

            dis = (100 - dis) / 100;

            double wholesalePrice = (unitPrice * dis) * qtyPerCase;

            TxtCasePrice.Text = wholesalePrice.ToString("N2");
        }

        private void TxtQtyPerPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number,"" , 10)
;
        }

        private void TxtQtyPerPack_TextChanged(object sender, EventArgs e)
        {
            TxtPackPrice_TextChanged(sender, e);
        }
        public float CalculatePackPercentage(
    double aPack,
    double bPack,
    double cPack,
    double dPack)
        {
            double buyInPack = (aPack / bPack) * cPack;

            float percent = 0;

            if (dPack == 0)
            {
                percent = 0;
            }
            else
            {
                percent = (float)(((dPack - buyInPack) / dPack) * 100);
            }

            return (float)Math.Round(percent, 2);
        }
        private void TxtPackPrice_TextChanged(object sender, EventArgs e)
        {
            double average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
    ? 0
    : Convert.ToDouble(TxtAveragePrice.Text.Trim());

            int qtyPerCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerCase.Text.Trim());

            int qtyPerPack = string.IsNullOrWhiteSpace(TxtQtyPerPack.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerPack.Text.Trim());

            double packPrice = string.IsNullOrWhiteSpace(TxtPackPrice.Text)
                ? 0
                : Convert.ToDouble(TxtPackPrice.Text.Trim());

            float packPercent = CalculatePackPercentage(
                average,
                qtyPerCase,
                qtyPerPack,
                packPrice);

            TxtPackProfit.Text = packPercent.ToString("N2");
        }
        public float CalculateCasePercentage(
    double aCase,
    double eCase)
        {
            float percent = (float)(
                ((eCase - aCase) /
                (eCase == 0 ? 1 : eCase)) * 100);

            return (float)Math.Round(percent, 2);
        }

        private void TxtUnitProfit_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCasePriceDiscount_Validated(object sender, EventArgs e)
        {

        }

        private void TxtCasePriceDiscount_TextChanged(object sender, EventArgs e)
        {
            int qtyPerCase = int.TryParse(TxtQtyPerCase.Text, out int q) ? q : 1;

            double unitPrice = double.TryParse(TxtUnitPrice.Text, out double up)
                ? up
                : 0;

            float discount = float.TryParse(TxtCasePriceDiscount.Text, out float d)
                ? d
                : 0;

            double wholesalePrice =
                unitPrice *
                ((100 - discount) / 100.0) *
                qtyPerCase;

            TxtCasePrice.Text = wholesalePrice.ToString("N2");
        }

        private void TxtCasePrice_TextChanged(object sender, EventArgs e)
        {
            int qtyPerCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text)
    ? 1
    : Convert.ToInt32(TxtQtyPerCase.Text.Trim());

            double unitPrice = string.IsNullOrWhiteSpace(TxtUnitPrice.Text)
                ? 0
                : Convert.ToDouble(TxtUnitPrice.Text.Trim());

            float dis = string.IsNullOrWhiteSpace(TxtCasePriceDiscount.Text)
                ? 0
                : Convert.ToSingle(TxtCasePriceDiscount.Text.Trim());

            dis = (100 - dis) / 100;

            double wholesalePrice = (unitPrice * dis) * qtyPerCase;

            TxtCasePrice.Text = wholesalePrice.ToString("N2");

            double average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
                ? 0
                : Convert.ToDouble(TxtAveragePrice.Text.Trim());

            wholesalePrice = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                ? 0
                : Convert.ToDouble(TxtCasePrice.Text.Trim());

            float casePercent = CalculateCasePercentage(
                average,
                wholesalePrice);

            TxtCaseProfit.Text = casePercent.ToString("N2");

            CheckProfitBuyin();
        }
        private void CheckProfitBuyin()
        {
            double average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
                ? 0
                : Convert.ToDouble(TxtAveragePrice.Text.Trim());

            int qtyPerCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerCase.Text.Trim());

            double unitPrice = string.IsNullOrWhiteSpace(TxtUnitPrice.Text)
                ? 0
                : Convert.ToDouble(TxtUnitPrice.Text.Trim());

            float unitPercent = CalculateUnitPercentage(
                average,
                qtyPerCase,
                unitPrice);

            TxtUnitProfit.Text = unitPercent.ToString("N2");

            double totalBuyin = string.IsNullOrWhiteSpace(TxtTotalBuyin.Text)
                ? 0
                : Convert.ToDouble(TxtTotalBuyin.Text.Trim());

            double wholesalePrice = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                ? 0
                : Convert.ToDouble(TxtCasePrice.Text.Trim());

            float casePercent = CalculateCasePercentage(
                totalBuyin,
                wholesalePrice);

            TxtCaseProfitBuyin.Text = casePercent.ToString("N2");

            int qtyPerPack = string.IsNullOrWhiteSpace(TxtQtyPerPack.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerPack.Text.Trim());

            double packPrice = string.IsNullOrWhiteSpace(TxtPackPrice.Text)
                ? 0
                : Convert.ToDouble(TxtPackPrice.Text.Trim());

            float packPercent = CalculatePackPercentage(
                average,
                qtyPerCase,
                qtyPerPack,
                packPrice);

            TxtPackProfit.Text = packPercent.ToString("N2");

            wholesalePrice = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                ? 0
                : Convert.ToDouble(TxtCasePrice.Text.Trim());

            casePercent = CalculateCasePercentage(
                average,
                wholesalePrice);

            TxtCaseProfit.Text = casePercent.ToString("N2");
        }

        private void TxtCaseProfitBuyin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TimerLoading_Tick(object sender, EventArgs e)
        {

        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {

        }

        private async void TimerCategoryLoading_Tick(object sender, EventArgs e)
        {
            this.TimerCategoryLoading.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var data =
                    await _api.GetAsync<List<CategoryItem>>(
                        "api/category");

                CmbCategory.DataSource = data;

                // Display Text
                CmbCategory.DisplayMember = "CategoryName";

                // Value
                CmbCategory.ValueMember = "Id";

                if (DataBindingSource.DataSource != null &&
                    DataBindingSource.Current is ProductItem product)
                {
                    CmbCategory.SelectedValue = product.ProCat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }


        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPackPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            ProductItem product = GetData();

            APIsController api = new APIsController();

            bool success = await api.PostAsync(
                "api/Product",
                product);

            if (success)
            {
                XtraMessageBox.Show(
                    "Save Success",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(TxtUnitNumber.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the unit number.",
                    "Enter Unit Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtUnitNumber.Focus();
                return false;
            }

            if (CmbSupplier.SelectedValue == null ||
                CmbSupplier.SelectedValue is DataRowView ||
                string.IsNullOrWhiteSpace(CmbSupplier.Text))
            {
                XtraMessageBox.Show(
                    "Please select any supplier.",
                    "Select Supplier",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CmbSupplier.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtProductsName.Text))
            {
                XtraMessageBox.Show(
                    "Please enter product name.",
                    "Enter Product Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtProductsName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtKhmerName.Text))
            {
                XtraMessageBox.Show(
                    "Please enter khmer name.",
                    "Enter Khmer Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtKhmerName.Focus();
                return false;
            }

            if (CmbCategory.SelectedValue == null ||
                CmbCategory.SelectedValue is DataRowView)
            {
                XtraMessageBox.Show(
                    "Please select category.",
                    "Select Category",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtBuyin.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Buyin.",
                    "Enter Buyin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtBuyin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtUnitPrice.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Unit Price.",
                    "Enter Unit Price",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtUnitPrice.Focus();
                return false;
            }

            if (PicProducts.Image == null)
            {
                XtraMessageBox.Show(
                    "Please select product image.",
                    "Image",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                PicProducts.Focus();
                return false;
            }

            decimal packPrice = 0;
            decimal casePrice = 0;

            decimal.TryParse(TxtPackPrice.Text, out packPrice);
            decimal.TryParse(TxtCasePrice.Text, out casePrice);

            if (packPrice > casePrice && casePrice > 0)
            {
                XtraMessageBox.Show(
                    "Cannot allow Pack Price bigger than Case Price.",
                    "Check Price",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtPackPrice.Focus();
                return false;
            }

            return true;
        }
        private ProductItem GetData()
        {
            return new ProductItem
            {
                ProID = string.IsNullOrWhiteSpace(TxtId.Text) ? 0 : Convert.ToInt32(TxtId.Text),
                ProNumY = TxtUnitNumber.Text.Trim(),
                Sup1 = TxtSupplierCode.Text.Trim(),
                ProNumYP = TxtPackNumber.Text.Trim(),
                ProNumYC = TxtCaseNumber.Text.Trim(),

                Sup2 = CmbSupplier.SelectedValue?.ToString(),

                ProName = TxtProductsName.Text.Trim(),
                KhmerName = TxtKhmerName.Text.Trim(),
                ProDes = TxtDescription.Text.Trim(),

                ProCat = CmbCategory.SelectedValue?.ToString(),

                ProPacksize = TxtSize.Text.Trim(),
                ProCurr = CmbCurrency.Text.Trim(),

                ProImpPri = string.IsNullOrWhiteSpace(TxtBuyin.Text)
                    ? 0
                    : Convert.ToDecimal(TxtBuyin.Text),

                ProRecLev = string.IsNullOrWhiteSpace(TxtOrderLevel.Text)
                    ? 0
                    : Convert.ToDecimal(TxtOrderLevel.Text),

                ProRecOrder = string.IsNullOrWhiteSpace(TxtOrderAmount.Text)
                    ? 0
                    : Convert.ToDecimal(TxtOrderAmount.Text),

                ProMadein = TxtMadeIn.Text.Trim(),

                ProQtyPCase = string.IsNullOrWhiteSpace(TxtQtyPerCase.Text)
                    ? 1
                    : Convert.ToDecimal(TxtQtyPerCase.Text),

                ProQtyPPack = TxtQtyPerPack.Text.Trim(),
                ProPckPri = TxtPackPrice.Text.Trim(),

                ProFinBuyin = string.IsNullOrWhiteSpace(TxtTotalBuyin.Text)
                    ? 0
                    : Convert.ToDecimal(TxtTotalBuyin.Text),

                ProUPrSE = string.IsNullOrWhiteSpace(TxtUnitPrice.Text)
                    ? 0
                    : Convert.ToDecimal(TxtUnitPrice.Text),

                ProUPriSeH = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                    ? 0
                    : Convert.ToDecimal(TxtCasePrice.Text),

                ProSKU = TxtSKU.Text.Trim(),

                Average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
                    ? 0
                    : Convert.ToDecimal(TxtAveragePrice.Text),

                BirthDate = DTPBirthDate.Value,

                FactoryCurrency = CmbFactoryCurrency.Text.Trim(),
                FOB_CIF = CmbFOBCIF.Text.Trim(),

                FOBCIFCost = string.IsNullOrWhiteSpace(TxtFactoryCost.Text)
                    ? 0
                    : Convert.ToDecimal(TxtFactoryCost.Text),

                ShelfLifeOfProduct = CmbShelfLifeOfProduct.Text.Trim(),

                ExciseTax = string.IsNullOrWhiteSpace(txtexcisetax.Text)
                    ? 0
                    : Convert.ToDouble(txtexcisetax.Text),

                PublicLightingTax = string.IsNullOrWhiteSpace(txtpubliclightingtax.Text)
                    ? 0
                    : Convert.ToDouble(txtpubliclightingtax.Text),

                VOP = string.IsNullOrWhiteSpace(txtvop.Text)
                    ? 0
                    : Convert.ToDecimal(txtvop.Text),

                FormDLanded = string.IsNullOrWhiteSpace(txtFormDLanded.Text)
                    ? 0
                    : Convert.ToDecimal(txtFormDLanded.Text)
            };
        }
        private void LoadCurrency()
        {
            try
            {
                string supplierCode = "SUP00000";

                if (CmbSupplier.SelectedValue != null &&
                    !(CmbSupplier.SelectedValue is DataRowView) &&
                    !string.IsNullOrWhiteSpace(CmbSupplier.Text))
                {
                    supplierCode = CmbSupplier.SelectedValue.ToString();
                }

                string query = $@"
DECLARE @supnum_ NVARCHAR(8) = '{supplierCode}';

IF NOT EXISTS
(
    SELECT *
    FROM [DBJuJuBi].[dbo].[TblCurrencyjujubi]
    WHERE [SupNum] = @supnum_
)
    SET @supnum_ = 'SUP00000';

WITH v
AS
(
    SELECT
        CurNumber,
        Currency,
        COALESCE(CurNumber,'') + SPACE(3)
        + COALESCE(Currency,'') + SPACE(3)
        + COALESCE(CONVERT(NVARCHAR,Rate),'1') AS Display,
        SupNum
    FROM [DBJuJuBi].[dbo].[TblCurrencyjujubi]
    WHERE COALESCE(SupNum,'') = @supnum_
       OR @supnum_ = 'SUP00000'

    UNION ALL

    SELECT
        LEFT(ProCurr,8) AS CurNumber,
        RTRIM(LTRIM(SUBSTRING(ProCurr,9,7))) AS Currency,
        ProCurr AS Display,
        LEFT(Sup1,8) AS SupNum
    FROM [DBJuJuBi].[dbo].[TPRProducts]
)
SELECT DISTINCT
       CurNumber,
       Currency,
       Display
FROM v
ORDER BY Currency";

                DataTable dt = new DataTable();

                using (SqlConnection conn =
                       new SqlConnection(
                           Data.ConnectionString(
                               Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();

                    using (SqlCommand cmd =
                           new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da =
                            new SqlDataAdapter(cmd);

                        da.Fill(dt);
                    }
                }

                CmbCurrency.DataSource = dt;
                CmbCurrency.DisplayMember = "Display";
                CmbCurrency.ValueMember = "CurNumber";

                CmbFactoryCurrency.DataSource = dt.Copy();
                CmbFactoryCurrency.DisplayMember = "Display";
                CmbFactoryCurrency.ValueMember = "CurNumber";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Currency Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimerCurrencyLoading_Tick_1(object sender, EventArgs e)
        {
            this.LoadCurrency();

        }

        private void CmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
       


            //var row = DataBindingSource.Current as DataRowView;

            //double proImpPri = 0;

            //if (row != null)
            //{
            //    double.TryParse(
            //        Convert.ToString(row["ProImpPri"]),
            //        out proImpPri);
            //}

            //if (CmbCurrency.Text.Contains("KHR") ||
            //    CmbCurrency.Text.Contains("KHM") ||
            //    CmbCurrency.Text.Contains("RIL"))
            //{
            //    TxtBuyin.Text = string.Format("{0:N0}", proImpPri);
            //}
            //else
            //{
            //    TxtBuyin.Text = string.Format("{0:N4}", proImpPri);
            //}

            CalculatedTotalBuyin();
        }
        private void CalculatedTotalBuyin()
        {
            double buyin = string.IsNullOrWhiteSpace(TxtBuyin.Text)
                ? 0
                : Convert.ToDouble(TxtBuyin.Text);

            float dis = string.IsNullOrWhiteSpace(TxtBuyinDiscount.Text)
                ? 0
                : Convert.ToSingle(TxtBuyinDiscount.Text);

            float vat = string.IsNullOrWhiteSpace(TxtBuyinVAT.Text)
                ? 0
                : Convert.ToSingle(TxtBuyinVAT.Text);

            double exciseTax =
                (100 + (string.IsNullOrWhiteSpace(txtexcisetax.Text)
                ? 0
                : Convert.ToDouble(txtexcisetax.Text))) / 100;

            double publicLightTax =
                (100 + (string.IsNullOrWhiteSpace(txtpubliclightingtax.Text)
                ? 0
                : Convert.ToDouble(txtpubliclightingtax.Text))) / 100;

            string currency;

            if (string.IsNullOrWhiteSpace(CmbCurrency.Text))
            {
                currency = "CUR00001   USD   1";
            }
            else
            {
                if (CmbCurrency.SelectedValue == null ||
                    CmbCurrency.SelectedValue is DataRowView)
                {
                    currency = "CUR00001   USD   1";
                }
                else
                {
                    currency = CmbCurrency.Text.Trim();
                }
            }

            float rate = 1;

            try
            {
                rate = Convert.ToSingle(
                    currency.Substring(15).Trim());
            }
            catch
            {
                rate = 1;
            }

            dis = (100 - dis) / 100;

            vat = (vat / 100) + 1;

            double totalBuyin =
                ((buyin / rate) * dis)
                * exciseTax
                * publicLightTax
                * vat;

            TxtTotalBuyin.Text =
                string.Format("{0:N4}", totalBuyin);
        }

        private async void TimerUOMLoading_Tick(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            TimerUOMLoading.Enabled = false;

            try
            {
                var data =
                    await _api.GetAsync<List<ProductScal>>(
                        "api/ProductScale");

                CmbUOM.DataSource = data;


                CmbUOM.DisplayMember = "UOM";


                CmbUOM.ValueMember = "UOM";

                if (DataBindingSource.DataSource != null &&
                    DataBindingSource.Current is ProductItem product)
                {
                    CmbCategory.SelectedValue = product.ProCat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }


        }

        private async void disDimensionLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            disDimensionLoading.Enabled = false;

            try
            {
                var data =
                    await _api.GetAsync<List<ProductScal>>(
                        "api/ProductScale");

                gcMain.DataSource = data;
                gcMain.Refresh();
                gvMain.IndicatorWidth = 50;

                this.Cursor = Cursors.Default;

                if (DataBindingSource.DataSource != null &&
                    DataBindingSource.Current is ProductItem product)
                {
                    CmbCategory.SelectedValue = product.ProCat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private async void btnAddDimension_Click(object sender, EventArgs e)
        {

        if (string.IsNullOrWhiteSpace(TxtCTNPerPallet.Text))
            {
                XtraMessageBox.Show(
                    "Please enter CTN/Pallet.",
                    "Enter CTN/Pallet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtCTNPerPallet.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(CmbUOM.Text))
            {
                XtraMessageBox.Show(
                    "Please select/enter UOM.",
                    "Select/Enter UOM",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CmbUOM.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtWidth.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Width.",
                    "Enter Width",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtWidth.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtLength.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Length.",
                    "Enter Length",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtLength.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtHeight.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Height.",
                    "Enter Height",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtHeight.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtNetWeight.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Net Weight.",
                    "Enter Net Weight",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtNetWeight.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtGrossWeight.Text))
            {
                XtraMessageBox.Show(
                    "Please enter Gross Weight.",
                    "Enter Gross Weight",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TxtGrossWeight.Focus();
                return;
            }

            if(TxtId.Text == "")
            {
                return;
            }
            try
            {
                var dto = new CreateProductScaleDto
                {
                    ProId = string.IsNullOrWhiteSpace(TxtId.Text)
                        ? 0
                        : Convert.ToDecimal(TxtId.Text),

                    CTNPerPallet = string.IsNullOrWhiteSpace(TxtCTNPerPallet.Text)
                        ? 0
                        : Convert.ToDouble(TxtCTNPerPallet.Text),

                    UOM = CmbUOM.Text.Trim(),

                    Width = string.IsNullOrWhiteSpace(TxtWidth.Text)
                        ? 0
                        : Convert.ToDouble(TxtWidth.Text),

                    Length = string.IsNullOrWhiteSpace(TxtLength.Text)
                        ? 0
                        : Convert.ToDouble(TxtLength.Text),

                    Height = string.IsNullOrWhiteSpace(TxtHeight.Text)
                        ? 0
                        : Convert.ToDouble(TxtHeight.Text),

                    CBMPerCTN = string.IsNullOrWhiteSpace(TxtCBMPerCTN.Text)
                        ? 0
                        : Convert.ToDouble(TxtCBMPerCTN.Text),

                    NetWeight = string.IsNullOrWhiteSpace(TxtNetWeight.Text)
                        ? 0
                        : Convert.ToDouble(TxtNetWeight.Text),

                    GrossWeight = string.IsNullOrWhiteSpace(TxtGrossWeight.Text)
                        ? 0
                        : Convert.ToDouble(TxtGrossWeight.Text),

                    Status = true
                };

                await _api.PostAsync<object>(
                    "api/ProductScale",
                    dto);

                XtraMessageBox.Show(
                    "Saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                disDimensionLoading.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PicProducts_Click(object sender, EventArgs e)
        {

        }

        private void TxtWidth_TextChanged(object sender, EventArgs e)
        {
            
                float W = (string.IsNullOrWhiteSpace(TxtWidth.Text) ? 0 : Convert.ToSingle(TxtWidth.Text)) / 100;
                float L = (string.IsNullOrWhiteSpace(TxtLength.Text) ? 0 : Convert.ToSingle(TxtLength.Text)) / 100;
                float H = (string.IsNullOrWhiteSpace(TxtHeight.Text) ? 0 : Convert.ToSingle(TxtHeight.Text)) / 100;

                float M3 = W * L * H;

                TxtCBMPerCTN.Text = M3.ToString("N2");
            
        }
    }
}