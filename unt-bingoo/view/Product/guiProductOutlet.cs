using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private const string UPLOAD_URL = "http://192.168.1.99:8099/api/Product/upload";
        public List<ProductItem> RProductList;

        public string RWord_Searching;
        private bool lIsMainProducts;
        private ApplicationFramework App = new ApplicationFramework();
        private BindingSource DataBindingSource;

        private bool _suspendCalc;

        public guiProductOutlet(mainForm mdi, bool lIsMainProducts)
        {
            InitializeComponent();
            this.mdi = mdi;
            this.lIsMainProducts = lIsMainProducts;

            DataBindingSource = new BindingSource();

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        private static double ParseDouble(string s)
            => double.TryParse((s ?? "").Trim(), out double v) ? v : 0;

        private static int ParseIntDefault(string s, int fallback)
            => int.TryParse((s ?? "").Trim(), out int v) ? v : fallback;

        private static decimal ParseDecimal(string s)
            => decimal.TryParse((s ?? "").Trim(), out decimal v) ? v : 0;

        /// <summary>
        /// Parses text like "0", "0.0000" or "12.00" into a whole int.
        /// Needed because the API declares some fields (e.g. proTotQty) as
        /// Nullable&lt;Int32&gt; — sending 0.0 as a decimal makes ASP.NET model
        /// binding fail with "The JSON value could not be converted to
        /// System.Nullable`1[System.Int32]" and then "The dto field is required."
        /// </summary>
        private static int ParseWholeNumber(string s)
            => (int)Math.Round(ParseDecimal(s), MidpointRounding.AwayFromZero);

        // ------------------------------------------------------------------------

        private void BtnAddDel_Click(object sender, EventArgs e)
        {
        }
        // Numeric two-way binding: commit immediately, show 2 decimals,
        // but keep raw text while typing so the caret doesn't jump.
        private void BindEditableNumeric(Control control, string dataMember, string formatString = "0.00")
        {
            // Never push back to the data source: every read of these fields (calc + save)
            // already goes straight to the control's Text, so a live two-way push only
            // causes a reformat-while-typing fight that can revert what was just typed.
            var binding = new Binding("Text", DataBindingSource, dataMember, true,
                                      DataSourceUpdateMode.Never);

            binding.Format += (s, e) =>
            {
                // កំពុងវាយ -> ទុក text ដដែល (កុំ reformat)
                if (control.Focused)
                {
                    e.Value = control.Text;
                    return;
                }

                if (e.Value == null) { e.Value = ""; return; }

                if (decimal.TryParse(e.Value.ToString(), out var d))
                    e.Value = d.ToString(formatString);
            };

            control.DataBindings.Add(binding);
        }

        private static void BindEditable(Control control, string controlProperty,
                                         BindingSource source, string dataMember,
                                         string formatString = null)
        {
            var binding = new Binding(controlProperty, source, dataMember, true,
                                      DataSourceUpdateMode.OnPropertyChanged);
            if (!string.IsNullOrEmpty(formatString))
                binding.FormatString = formatString;
            control.DataBindings.Add(binding);
        }

        private void DataLoading()
        {
            DataBindingSource.DataSource = RProductList;

            ClearAllBindings();

            Navigator.BindingSource = DataBindingSource;

            if (DataBindingSource.DataSource != null)
            {
             
                BindEditable(TxtId, "Text", DataBindingSource, "ProID");
                BindEditable(TxtUnitNumber, "Text", DataBindingSource, "ProNumY");
                BindEditable(TxtPackNumber, "Text", DataBindingSource, "ProNumYP");
                BindEditable(TxtCaseNumber, "Text", DataBindingSource, "ProNumYC");
                BindEditable(TxtSKU, "Text", DataBindingSource, "ProSKU");
                BindEditable(TxtSupplierCode, "Text", DataBindingSource, "ProNumS");

                BindEditable(CmbSupplier, "SelectedValue", DataBindingSource, "Sup1");

                BindEditable(TxtProductsName, "Text", DataBindingSource, "ProName");
                BindEditable(TxtKhmerName, "Text", DataBindingSource, "KhmerName");
                BindEditable(TxtSize, "Text", DataBindingSource, "ProPacksize");
                BindEditable(TxtDescription, "Text", DataBindingSource, "ProDes");
                //BindEditable(CmbCategory, "SelectedValue", DataBindingSource, "ProCat");
                BindEditable(TxtMadeIn, "Text", DataBindingSource, "ProMadein");
                BindEditable(DTPBirthDate, "Value", DataBindingSource, "BirthDate");
                BindEditable(TxtCurrentStock, "Text", DataBindingSource, "ProTotQty");
                BindEditable(TxtQtySold, "Text", DataBindingSource, "ProSSec");
                BindEditable(TxtOrderLevel, "Text", DataBindingSource, "ProRecLev");
                BindEditable(TxtOrderAmount, "Text", DataBindingSource, "ProRecOrder");
                BindEditable(TxtRemark, "Text", DataBindingSource, "ProRem");


                // NOTE: these are intentionally NOT two-way DataBindings. Any bound control
                // on this form that pushes a value (e.g. TxtQtyPerCase via OpenBuyinDialog)
                // can make the shared BindingManagerBase re-pull every bound control for the
                // current item, which would blow away whatever the user just typed here.
                // Calc + Save already read straight from .Text, so a persistent Binding buys
                // nothing except that fight. PopulateCalculatedFieldsFromCurrent() below does
                // the one-time initial display instead.

           
                BindEditable(TxtQtyPerPack, "Text", DataBindingSource, "ProQtyPPack");
                BindEditable(TxtQtyPerCase, "Text", DataBindingSource, "ProQtyPCase");

         
                BindEditable(CmbFactoryCurrency, "Text", DataBindingSource, "FactoryCurrency");
                BindEditable(CmbFOBCIF, "Text", DataBindingSource, "FOB_CIF");
                BindEditable(CmbCurrency, "Text", DataBindingSource, "ProCurr");
                BindEditable(CmbShelfLifeOfProduct, "Text", DataBindingSource, "ShelfLifeOfProduct");

          
                TxtAveragePrice.DataBindings.Add(
                    new Binding("Text", DataBindingSource, "Average", true,
                                DataSourceUpdateMode.Never, 0, "N4"));
                TxtUnitPrice.DataBindings.Add(
                    new Binding("Text", DataBindingSource, "ProUPrSE", true,
                                DataSourceUpdateMode.Never, 0, "N2"));
                TxtCasePrice.DataBindings.Add(
                    new Binding("Text", DataBindingSource, "ProUPriSeH", true,
                                DataSourceUpdateMode.Never, 0, "N2"));

                
                LoadScaleGridFromCurrentProduct();

                DataBindingSource.CurrentChanged -= DataBindingSource_CurrentChanged;
                DataBindingSource.CurrentChanged += DataBindingSource_CurrentChanged;

                if (Navigator.BindingSource.Count > 0)
                    RefreshItems();
                else
                    BtnAddNew_Click(BtnAddNew, EventArgs.Empty);
            }
            else
            {
                BtnAddNew_Click(BtnAddNew, EventArgs.Empty);
            }

            LoadProductImage();
        }


        private void LoadScaleGridFromCurrentProduct()
        {
            _scaleList.Clear();

            var currentProduct = DataBindingSource.Current as ProductItem;

            if (currentProduct?.ProductScale != null)
            {
                var s = currentProduct.ProductScale;

                _scaleList.Add(new ProductScal
                {
                    Id = s.Id,
                    ProId = currentProduct.ProID,
                    UOMCode = s.UOMCode,
                    Width = (double?)s.Width,
                    Length = (double?)s.Length,
                    Height = (double?)s.Height,
                    CBMPerCTN = (double?)s.CBMPerCTN,
                    NetWeight = (double?)s.NetWeight,
                    GrossWeight = (double?)s.GrossWeight,
                    Status = true,
                    //ProNumY = currentProduct.ProNumY
                });
            }

            gcScale.DataSource = _scaleList;
            gvScale.RefreshData();
        }

        private void ClearAllBindings()
        {
            Control[] bound =
            {
                TxtId, TxtUnitNumber, TxtPackNumber, TxtCaseNumber, TxtSKU, TxtSupplierCode,
                CmbSupplier, TxtKhmerName, TxtProductsName, TxtSize, TxtDescription, CmbCategory,
                TxtMadeIn, DTPBirthDate, TxtCurrentStock, TxtQtySold, TxtOrderLevel, TxtOrderAmount,
                TxtRemark, CmbFactoryCurrency, CmbFOBCIF, TxtFactoryCost, CmbCurrency, txtFormDLanded,
                TxtBuyin, TxtBuyinDiscount, TxtBuyinVAT, txtexcisetax, txtpubliclightingtax,
                TxtTotalBuyin, TxtAveragePrice, TxtUnitPrice, TxtSuggest, TxtQtyPerPack, TxtUnitProfit,
                TxtPackPrice, TxtPackProfit, TxtQtyPerCase, TxtCasePriceDiscount, TxtCasePrice,
                TxtCaseProfit, CmbShelfLifeOfProduct, txtvop
            };

            foreach (Control c in bound)
                c.DataBindings.Clear();
        }

        private void RefreshItems()
        {
            DeliveryLogisticLoading.Enabled = true;
            disDimensionLoading.Enabled = true;

            PicProducts.Image = null;

            string status = "";
            object current = DataBindingSource.Current;

            if (current is DataRowView row)
            {
                status = Convert.ToString(row["Status"])?.Trim() ?? "";
            }
            else if (current != null)
            {
                var prop = current.GetType().GetProperty("Status");
                if (prop != null)
                    status = Convert.ToString(prop.GetValue(current))?.Trim() ?? "";
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

            TxtStockOldCode.Text = "0";
            TxtStockGRNTemp.Text = "0";

            PopulateCalculatedFieldsFromCurrent();
        }

        // One-time display of the buy-in/pricing fields from the current record.
        // These fields are read directly from .Text everywhere else (calc + save),
        // so this replaces what a persistent two-way Binding used to do, without
        // the risk of an unrelated bound control's edit reverting them mid-typing.
        private void PopulateCalculatedFieldsFromCurrent()
        {
            if (!(DataBindingSource.Current is ProductItem product))
                return;

            TxtFactoryCost.Text = (product.FOBCIFCost ?? 0).ToString("0.00");
            TxtBuyin.Text = (product.ProImpPri ?? 0).ToString("N2");
            TxtBuyinDiscount.Text = (product.ProDis ?? 0).ToString("0.00");
            TxtBuyinVAT.Text = (product.ProVAT ?? 0).ToString("0");
            txtexcisetax.Text = (product.ExciseTax ?? 0).ToString("0");
            txtpubliclightingtax.Text = (product.PublicLightingTax ?? 0).ToString("0.00");
            TxtTotalBuyin.Text = (product.ProFinBuyin ?? 0).ToString("N2");
            TxtPackPrice.Text = decimal.TryParse(product.ProPckPri, out var packPrice)
                ? packPrice.ToString("0.00") : "0.00";
            TxtUnitProfit.Text = (product.ProProPer ?? 0).ToString("0.00");
            TxtPackProfit.Text = (product.ProPckDis ?? 0).ToString("0.00");
            TxtCasePriceDiscount.Text = (product.ProHolesaleper ?? 0).ToString("0.00");
            TxtCaseProfit.Text = (product.ProHoleSalePP ?? 0).ToString("0.00");
            txtFormDLanded.Text = (product.FormDLanded ?? 0).ToString("N2");
            txtvop.Text = (product.VOP ?? 0).ToString("0.00");
        }

        private void DataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            PopulateCalculatedFieldsFromCurrent();
            LoadProductImage();
            LoadScaleGridFromCurrentProduct();
            SyncCategoryCombo();
        }
        public void SyncCategoryCombo()
        {
            if (DataBindingSource.Current is ProductItem product &&
      int.TryParse(product.ProCat?.ToString(), out int catId))
            {
                CmbCategory.SelectedValue = catId;
            }
            else
            {
                CmbCategory.SelectedIndex = -1;
            }
        }
        private int _imageLoadToken;

        private async void LoadProductImage()
        {
            int myToken = ++_imageLoadToken;

            try
            {
                if (!(DataBindingSource.Current is ProductItem product))
                {
                    PicProducts.Image = null;
                    return;
                }

                string imageUrl = product.ProImage;

                if (string.IsNullOrWhiteSpace(imageUrl))
                {
                    PicProducts.Image = null;
                    return;
                }

                byte[] bytes = await _httpClient.GetByteArrayAsync(imageUrl);

                if (myToken != _imageLoadToken || PicProducts.IsDisposed)
                    return;

                using (MemoryStream ms = new MemoryStream(bytes))
                using (Image downloaded = Image.FromStream(ms))
                {
                    PicProducts.Image?.Dispose();
                    PicProducts.Image = new Bitmap(downloaded);
                }
            }
            catch (Exception ex)
            {
                if (myToken == _imageLoadToken && !PicProducts.IsDisposed)
                    PicProducts.Image = null;

                System.Diagnostics.Debug.WriteLine("LoadProductImage error: " + ex.Message);
            }
        }

        private void TimerCurrencyLoading_Tick(object sender, EventArgs e)
        {
            TimerCurrencyLoading_Tick_1(sender, e);
        }

        private async Task LoadingSupplier()
        {
            try
            {
                //npte
                var list = await _api.GetAsync<List<SupplierItem>>("api/Supplier");

                CmbSupplier.DataSource = list;
                CmbSupplier.DisplayMember = "SupplierName";
                CmbSupplier.ValueMember = "SupplierCode";
                CmbSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // One shared client for the form's lifetime (don't new-up HttpClient per call).
        private static readonly HttpClient _httpClient = new HttpClient();

        private string _productImageFileName;   // set in PicProducts_DoubleClick

        private async Task<T> SafeCall<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Connection error: " + ex.Message,
                    "Network", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out. Please try again.",
                    "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        private static string GuessContentType(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName).ToLowerInvariant();
            switch (ext)
            {
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                case ".bmp": return "image/bmp";
                default: return "image/jpeg";
            }
        }

        private async void guiProductOutlet_Load(object sender, EventArgs e)
        {
            _api = APIGlobals.Api;

            if (_api == null || !_api.HasToken())
            {
                XtraMessageBox.Show("Please login again!");
                Close();
                return;
            }
           

            DataBindingSource = new BindingSource();

            await LoadingSupplier();
            await LoadingCategory();

            await ShelifeAsync();

            this.DataLoading();
            await LodingUOMAsync();
            if (DataBindingSource.Current is ProductItem product)
            {
                CmbCategory.SelectedValue = Convert.ToInt32(product.ProCat);
            }
            else
            {
                CmbCategory.SelectedValue = -1;

            }
            SyncCategoryCombo();

            this.CityLoading.Enabled = true;
            this.TimerCurrencyLoading.Enabled = true;
            this.TimerUOMLoading.Enabled = true;

            if (TxtId.Text == "")
                TxtUnitNumber_Click(TxtUnitNumber, EventArgs.Empty);
   
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

                BindProduct(products[0]);
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

            TxtBuyin.Text = product.ProImpPri.HasValue
     ? product.ProImpPri.Value.ToString("0.##")
     : "";
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
                            true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string.IsNullOrWhiteSpace(TxtId.Text) ? "0" : TxtId.Text.Trim());

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

                    continue;
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

                return;
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

                return;
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
                e.Handled = true;
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

        public float CalculateUnitPercentage(double average, double qtyPerCase, double unitPrice)
            => ProductPricingCalculator.UnitPercentage(average, qtyPerCase, unitPrice);

        public float CalculatePackPercentage(double aPack, double bPack, double cPack, double dPack)
            => ProductPricingCalculator.PackPercentage(aPack, bPack, cPack, dPack);

        public float CalculateCasePercentage(double aCase, double eCase)
            => ProductPricingCalculator.CasePercentage(aCase, eCase);

        private void TxtFactoryCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

        
            if (char.IsControl(e.KeyChar))
                return;

   
            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void TxtDeliveryCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

        
            if (char.IsControl(e.KeyChar))
                return;

   
            if (char.IsDigit(e.KeyChar))
                return;

     
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

          
            e.Handled = true;
        }

        private void txtFormDLanded_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

          
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

          
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txtpubliclightingtax_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

          
            if (char.IsControl(e.KeyChar))
                return;


            if (char.IsDigit(e.KeyChar))
                return;

     
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            e.Handled = true;
        }

        /// <summary>
        /// Case price = (unit price x qty per case) reduced by the case discount %.
        /// Example: Unit 23.00, Qty/Case 23, Discount 0% -> 529.00
        ///          Unit 23.00, Qty/Case 23, Discount 5% -> 502.55
        /// </summary>
        private static double ComputeCasePrice(double unitPrice, double discountPercent, int qtyPerCase)
        {
            if (qtyPerCase <= 0)
                qtyPerCase = 1;

            double gross = unitPrice * qtyPerCase;

            if (discountPercent > 0)
                gross -= gross * (discountPercent / 100.0);

            return gross;
        }

        private void RecalculateSellingPrices()
        {
            if (_suspendCalc)
                return;

            _suspendCalc = true;
            try
            {
                double average = ParseDouble(TxtAveragePrice.Text);
                double totalBuyin = ParseDouble(TxtTotalBuyin.Text);
                int qtyPerCase = ParseIntDefault(TxtQtyPerCase.Text, 1);
                int qtyPerPack = ParseIntDefault(TxtQtyPerPack.Text, 1);
                double unitPrice = ParseDouble(TxtUnitPrice.Text);
                double packPrice = ParseDouble(TxtPackPrice.Text);
                double caseDiscount = ParseDouble(TxtCasePriceDiscount.Text);

                double casePrice = ComputeCasePrice(unitPrice, caseDiscount, qtyPerCase);
                TxtCasePrice.Text = casePrice.ToString("N2");

                TxtUnitProfit.Text =
                    ProductPricingCalculator.UnitPercentage(average, qtyPerCase, unitPrice).ToString("N2");

                TxtPackProfit.Text =
                    ProductPricingCalculator.PackPercentage(average, qtyPerCase, qtyPerPack, packPrice).ToString("N2");

                TxtCaseProfit.Text =
                    ProductPricingCalculator.CasePercentage(average, casePrice).ToString("N2");

                TxtCaseProfitBuyin.Text =
                    ProductPricingCalculator.CasePercentage(totalBuyin, casePrice).ToString("N2");
            }
            finally
            {
                _suspendCalc = false;
            }
        }

        private void RecalculateProfitsFromCasePrice()
        {
            if (_suspendCalc)
                return;

            _suspendCalc = true;
            try
            {
                double average = ParseDouble(TxtAveragePrice.Text);
                double totalBuyin = ParseDouble(TxtTotalBuyin.Text);
                double casePrice = ParseDouble(TxtCasePrice.Text);

                TxtCaseProfit.Text =
                    ProductPricingCalculator.CasePercentage(average, casePrice).ToString("N2");

                TxtCaseProfitBuyin.Text =
                    ProductPricingCalculator.CasePercentage(totalBuyin, casePrice).ToString("N2");
            }
            finally
            {
                _suspendCalc = false;
            }
        }

        private void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            RecalculateSellingPrices();
        }

        private void TxtQtyPerPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number, "", 10);
        }

        private void TxtQtyPerPack_TextChanged(object sender, EventArgs e)
        {
            RecalculateSellingPrices();
        }

        private void TxtPackPrice_TextChanged(object sender, EventArgs e)
        {
            RecalculateSellingPrices();
        }

        private void TxtUnitProfit_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtCasePriceDiscount_Validated(object sender, EventArgs e)
        {
        }

        private void TxtCasePriceDiscount_TextChanged(object sender, EventArgs e)
        {
            RecalculateSellingPrices();
        }

        private void TxtCasePrice_TextChanged(object sender, EventArgs e)
        {
            RecalculateProfitsFromCasePrice();
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

            float unitPercent = CalculateUnitPercentage(average, qtyPerCase, unitPrice);
            TxtUnitProfit.Text = unitPercent.ToString("N2");

            double totalBuyin = string.IsNullOrWhiteSpace(TxtTotalBuyin.Text)
                ? 0
                : Convert.ToDouble(TxtTotalBuyin.Text.Trim());

            double wholesalePrice = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                ? 0
                : Convert.ToDouble(TxtCasePrice.Text.Trim());

            float casePercent = CalculateCasePercentage(totalBuyin, wholesalePrice);
            TxtCaseProfitBuyin.Text = casePercent.ToString("N2");

            int qtyPerPack = string.IsNullOrWhiteSpace(TxtQtyPerPack.Text)
                ? 1
                : Convert.ToInt32(TxtQtyPerPack.Text.Trim());

            double packPrice = string.IsNullOrWhiteSpace(TxtPackPrice.Text)
                ? 0
                : Convert.ToDouble(TxtPackPrice.Text.Trim());

            float packPercent = CalculatePackPercentage(average, qtyPerCase, qtyPerPack, packPrice);
            TxtPackProfit.Text = packPercent.ToString("N2");

            wholesalePrice = string.IsNullOrWhiteSpace(TxtCasePrice.Text)
                ? 0
                : Convert.ToDouble(TxtCasePrice.Text.Trim());

            casePercent = CalculateCasePercentage(average, wholesalePrice);
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
            this.DataLoading();
        }
        private async Task LoadingCategory()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                var data = await _api.GetAsync<List<CategoryItem>>("api/category");

                CmbCategory.DataSource = data;
                CmbCategory.DisplayMember = "CategoryName";
                CmbCategory.ValueMember = "Id";
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private async Task TimerCategoryLoading_Tick(object sender, EventArgs e)
        {
            this.TimerCategoryLoading.Enabled = false;

        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void TxtPackPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private byte[] _productImageBytes;

        private async Task<string> UploadProductImageAsync()
        {
            if (_productImageBytes == null || _productImageBytes.Length == 0)
                return null;

            string fileName = string.IsNullOrWhiteSpace(_productImageFileName)
                ? "product.jpg" : _productImageFileName;

            return await _api.UploadFileAsync("api/Product/upload", _productImageBytes, fileName, "file");
        }
        private async Task UpdateProductAsync()
        {
            if (!ValidateData())
                return;


            int proId = ParseIntDefault(TxtId.Text, 0);
            bool isUpdate = proId > 0;
            string action = isUpdate ? "UPDATE this product" : "SAVE as a new product";

            if (searching == true)
            {

            }
            else{
                if (XtraMessageBox.Show(
                    $"Do you want to {action}?",
                    isUpdate ? "Confirm Update" : "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            // Confirm with the user which action is about to happen.
        

            this.Cursor = Cursors.WaitCursor;
            BtnUpdate.Enabled = false;

            try
            {
                // 1. Upload the image first (if the user picked a new one).
                string imagePath = await UploadProductImageAsync();
                if (!string.IsNullOrWhiteSpace(imagePath))
                    imagePath = imagePath.Trim('"');
                else if (DataBindingSource.Current is ProductItem current)
                    imagePath = current.ProImage;

                bool success;

                if (isUpdate)
                {

                    object payload = GetPutPayload(proId, imagePath);
                    success = await _api.PutAsync($"api/Product/{proId}", payload);
                }
                else
                {


                    object payload = GetPutPayload(proId, imagePath);

                    success = await _api.PostAsync("api/Product", payload);
                }

                if (success)
                {
                    XtraMessageBox.Show(
                        isUpdate ? "Update Success" : "Save Success",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await ReloadCurrentProduct();

                }
                else
                {
                    XtraMessageBox.Show(
                        (isUpdate ? "Update" : "Save") + " failed. Please check the data and try again.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnUpdate.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
           await this.UpdateProductAsync();


        }

        /// <summary>
        /// Product scale taken from the dimension grid (last added row) or,
        /// if the grid is empty, from the dimension text boxes.
        /// </summary>
        private object BuildProductScalePayload()
        {
            var s = _scaleList.LastOrDefault();

            return new
            {
                ctnPerPallet = 0,
                uomCode = s?.UOMCode ?? (CmbUOM.SelectedValue?.ToString() ?? ""),
                width = s?.Width ?? ParseDouble(TxtWidth.Text),
                length = s?.Length ?? ParseDouble(TxtLength.Text),
                height = s?.Height ?? ParseDouble(TxtHeight.Text),
                cbmPerCTN = s?.CBMPerCTN ?? ParseDouble(TxtCBMPerCTN.Text),
                netWeight = s?.NetWeight ?? ParseDouble(TxtNetWeight.Text),
                grossWeight = s?.GrossWeight ?? ParseDouble(TxtGrossWeight.Text),
                createdDate = DateTime.Now,
                status = true
            };
        }

        /// <summary>
        /// Payload for POST api/Product (new product).
        /// Field names/types match the POST Swagger schema exactly:
        /// "id", booleans, numeric proQtyPPack/proPckPri, numeric shelfLifeOfProduct.
        /// </summary>
        private object GetPostPayload(string imagePath)
        {
            int shelfLifeId = 0;
            if (CmbShelfLifeOfProduct.SelectedValue != null &&
                !(CmbShelfLifeOfProduct.SelectedValue is DataRowView))
            {
                int.TryParse(CmbShelfLifeOfProduct.SelectedValue.ToString(), out shelfLifeId);
            }

            return new
            {
                id = 0,
                proNumY = TxtUnitNumber.Text.Trim(),
                proNumS = TxtSupplierCode.Text.Trim(),
                proNumYP = TxtPackNumber.Text.Trim(),
                proNumYC = TxtCaseNumber.Text.Trim(),
                sup1 = CmbSupplier.SelectedValue?.ToString() ?? "",
                sup2 = CmbSupplier.SelectedValue?.ToString() ?? "",
                proName = TxtProductsName.Text.Trim(),
                khmerNameUnicode = TxtKhmerName.Text.Trim(),
                proConsign = false,
                proDes = TxtDescription.Text.Trim(),
                proCat = CmbCategory.SelectedValue?.ToString() ?? "",
                proPacksize = TxtSize.Text.Trim(),
                proCurr = CmbCurrency.Text.Trim(),
                proImpPri = ParseDecimal(TxtBuyin.Text),
                proRecLev = ParseDecimal(TxtOrderLevel.Text),
                proRecOrder = ParseDecimal(TxtOrderAmount.Text),
                khmerName = TxtKhmerName.Text.Trim(),
                proSSec = TxtQtySold.Text.Trim(),          // string in POST schema
                proRem = TxtRemark.Text.Trim(),
                auto = true,
                profitAuto = true,
                proTotQty = ParseWholeNumber(TxtCurrentStock.Text),   // API expects int
                proMadein = TxtMadeIn.Text.Trim(),
                proQtyPCase = ParseDecimal(TxtQtyPerCase.Text) == 0 ? 1 : ParseDecimal(TxtQtyPerCase.Text),
                proQtyPPack = ParseDecimal(TxtQtyPerPack.Text),    // number in POST schema
                proPckPri = ParseDecimal(TxtPackPrice.Text),       // number in POST schema
                proPckDis = ParseDecimal(TxtPackProfit.Text),
                proPckAllDis = 0,
                proRecomLev = 0,
                promotion = false,
                formDLanded = ParseDecimal(txtFormDLanded.Text),
                proUPriBY = 0,
                proAllowDisW = false,
                proAllowDisU = false,
                proDis = ParseDecimal(TxtBuyinDiscount.Text),
                exciseTax = ParseDouble(txtexcisetax.Text),
                publicLightingTax = ParseDouble(txtpubliclightingtax.Text),
                proVAT = ParseDecimal(TxtBuyinVAT.Text),
                proFinBuyin = ParseDecimal(TxtTotalBuyin.Text),
                proUPrSE = ParseDecimal(TxtUnitPrice.Text),
                proProPer = ParseDecimal(TxtUnitProfit.Text),
                proUPriSeH = ParseDecimal(TxtCasePrice.Text),
                proHolesaleper = ParseDecimal(TxtCasePriceDiscount.Text),
                proHoleSalePP = ParseDecimal(TxtCaseProfit.Text),
                proRecPer = ParseDecimal(TxtSuggest.Text),
                proSKU = TxtSKU.Text.Trim(),
                average = ParseDecimal(TxtAveragePrice.Text),
                birthDate = DTPBirthDate.Value,
                averSalePmonth = 0,
                wHcode = "",                               // string in POST schema
                sampling = false,
                factoryCurrency = CmbFactoryCurrency.Text.Trim(),
                foB_CIF = CmbFOBCIF.Text.Trim(),
                fobcifCost = ParseDecimal(TxtFactoryCost.Text),
                shelfLifeOfProduct = shelfLifeId,          // number in POST schema
                vop = ParseDecimal(txtvop.Text),
                proImage = imagePath ?? "",
                productScale = BuildProductScalePayload()
            };
        }

        /// <summary>
        /// Payload for PUT api/Product/{id} (update existing product).
        /// Field names/types match the PUT Swagger schema exactly:
        /// "proID", string proQtyPPack/proPckPri, string shelfLifeOfProduct,
        /// numeric proSSec, string auto/profitAuto/proConsign.
        /// </summary>
        private object GetPutPayload(int proId, string imagePath)
        {
            return new
            {
                proID = proId,
                proNumY = TxtUnitNumber.Text.Trim(),
                proNumS = TxtSupplierCode.Text.Trim(),
                proNumYP = TxtPackNumber.Text.Trim(),
                proNumYC = TxtCaseNumber.Text.Trim(),

                proImage = imagePath ?? "",

                sup1 = CmbSupplier.SelectedValue?.ToString() ?? "",
                sup2 = CmbSupplier.SelectedValue?.ToString() ?? "",
                
  

                proName = TxtProductsName.Text.Trim(),
                khmerNameUnicode = TxtKhmerName.Text.Trim(),
                khmerName = TxtKhmerName.Text.Trim(),

                proDes = TxtDescription.Text.Trim(),
                proCat = CmbCategory.SelectedValue?.ToString() ?? "",
                proPacksize = TxtSize.Text.Trim(),
                proCurr = CmbCurrency.Text.Trim(),

                proImpPri = ParseDecimal(TxtBuyin.Text),
                proRecLev = ParseDecimal(TxtOrderLevel.Text),
                proRecOrder = ParseDecimal(TxtOrderAmount.Text),
                //proSSec = ParseDecimal(TxtQtySold.Text),

                proRem = TxtRemark.Text.Trim(),

                auto = "",
                profitAuto = "",

                proTotQty = ParseWholeNumber(TxtCurrentStock.Text),
                proMadein = TxtMadeIn.Text.Trim(),

                proQtyPCase = ParseDecimal(TxtQtyPerCase.Text) == 0 ? 1 : ParseDecimal(TxtQtyPerCase.Text),

                // PUT expects string
                proQtyPPack = TxtQtyPerPack.Text.Trim(),
                proPckPri = TxtPackPrice.Text.Trim(),

                proPckDis = ParseDecimal(TxtPackProfit.Text),
                proPckAllDis = 0,
                proRecomLev = 0,

                promotion = 0,

                formDLanded = ParseDecimal(txtFormDLanded.Text),
                proUPriBY = 0,

                proAllowDisW = 0,
                proAllowDisU = 1,

                proDis = ParseDecimal(TxtBuyinDiscount.Text),

                exciseTax = ParseDouble(txtexcisetax.Text),
                publicLightingTax = ParseDouble(txtpubliclightingtax.Text),
                proVAT = ParseDecimal(TxtBuyinVAT.Text),

                proFinBuyin = ParseDecimal(TxtTotalBuyin.Text),
                proUPrSE = ParseDecimal(TxtUnitPrice.Text),
                proProPer = ParseDecimal(TxtUnitProfit.Text),

                proUPriSeH = ParseDecimal(TxtCasePrice.Text),
                proHolesaleper = ParseDecimal(TxtCasePriceDiscount.Text),
                proHoleSalePP = ParseDecimal(TxtCaseProfit.Text),
                proRecPer = ParseDecimal(TxtSuggest.Text),

                proSKU = TxtSKU.Text.Trim(),
                average = ParseDecimal(TxtAveragePrice.Text),

                birthDate = DTPBirthDate.Value,

                averSalePmonth = 0,
                wHcode = 0,
                sampling = 0,

                factoryCurrency = CmbFactoryCurrency.Text.Trim(),
                foB_CIF = CmbFOBCIF.Text.Trim(),
                fobcifCost = ParseDecimal(TxtFactoryCost.Text),

                shelfLifeOfProduct = CmbShelfLifeOfProduct.Text.Trim(),

                vop = ParseDecimal(txtvop.Text),

                productScale = BuildProductScalePayload()
            };
        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(TxtUnitNumber.Text))
            {
                XtraMessageBox.Show("Please enter the unit number.", "Enter Unit Number",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUnitNumber.Focus();
                return false;
            }

            if (CmbSupplier.SelectedValue == null ||
                CmbSupplier.SelectedValue is DataRowView ||
                string.IsNullOrWhiteSpace(CmbSupplier.Text))
            {
                XtraMessageBox.Show("Please select any supplier.", "Select Supplier",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbSupplier.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtProductsName.Text))
            {
                XtraMessageBox.Show("Please enter product name.", "Enter Product Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductsName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtKhmerName.Text))
            {
                XtraMessageBox.Show("Please enter khmer name.", "Enter Khmer Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtKhmerName.Focus();
                return false;
            }

            if (CmbCategory.SelectedValue == null || CmbCategory.SelectedValue is DataRowView)
            {
                XtraMessageBox.Show("Please select category.", "Select Category",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtUnitPrice.Text))
            {
                XtraMessageBox.Show("Please enter Unit Price.", "Enter Unit Price",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUnitPrice.Focus();
                return false;
            }

            if (PicProducts.Image == null)
            {
                XtraMessageBox.Show("Please select product image.", "Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                PicProducts.Focus();
                return false;
            }

            if (!decimal.TryParse(TxtQtyPerCase.Text, out decimal qtyPerCase) || qtyPerCase <= 0)
            {
                XtraMessageBox.Show("Qty Per Case cannot be 0. Please enter a valid quantity.", "Enter Qty Per Case",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQtyPerCase.Focus();
                return false;
            }

            if (!decimal.TryParse(TxtQtyPerPack.Text, out decimal qtyPerPack) || qtyPerPack <= 0)
            {
                XtraMessageBox.Show("Qty Per Pack cannot be 0. Please enter a valid quantity.", "Enter Qty Per Pack",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQtyPerPack.Focus();
                return false;
            }

            decimal packPrice = 0;
            decimal casePrice = 0;
            decimal.TryParse(TxtPackPrice.Text, out packPrice);
            decimal.TryParse(TxtCasePrice.Text, out casePrice);

            if (packPrice > casePrice && casePrice > 0)
            {
                XtraMessageBox.Show("Cannot allow Pack Price bigger than Case Price.", "Check Price",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPackPrice.Focus();
                return false;
            }

            return true;
        }

        private async Task LoadCurrency()
        {

            try
            {
                int? supplierId = null;

                if (CmbSupplier.SelectedValue != null &&
                    CmbSupplier.SelectedValue != DBNull.Value &&
                    !(CmbSupplier.SelectedValue is DataRowView))
                {
                    if (int.TryParse(CmbSupplier.SelectedValue.ToString(), out int supId))
                    {
                        supplierId = supId;
                    }
                }

                // Load Currency
                var all = await _api.GetAsync<List<CurrencyItem>>("api/currency") ?? new List<CurrencyItem>();

                var list = all
                    .Where(c => c.Active && (supplierId == null || c.SupplierId == supplierId))
                    .OrderBy(c => c.CurrencyCode)
                    .ToList();

                CmbCurrency.DataSource = list;
                CmbCurrency.DisplayMember = "Display";
                CmbCurrency.ValueMember = "CurNumber";

                // Load Factory Currency
                CmbFactoryCurrency.DataSource = list.ToList();
                CmbFactoryCurrency.DisplayMember = "Display";
                CmbFactoryCurrency.ValueMember = "CurNumber";


                var usdRow = list.FirstOrDefault(c =>
                    c.CurrencyCode.Equals("USD", StringComparison.OrdinalIgnoreCase));

                if (usdRow != null)
                {
                    CmbCurrency.SelectedValue = usdRow.CurNumber;
                    CmbFactoryCurrency.SelectedValue = usdRow.CurNumber;
                }
                else
                {

                    if (list.Count > 0)
                    {
                        CmbCurrency.SelectedIndex = 0;
                        CmbFactoryCurrency.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Currency Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private async void TimerCurrencyLoading_Tick_1(object sender, EventArgs e)
        {
            this.TimerCurrencyLoading.Enabled = false;
            await this.LoadCurrency();
        }

        private void CmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private static double ParseCurrencyRate(string currencyText)
        {
            if (string.IsNullOrWhiteSpace(currencyText) || currencyText.Length < 16)
                return 1;

            return double.TryParse(currencyText.Substring(15).Trim(), out double r) && r != 0 ? r : 1;
        }

        private void CalculatedTotalBuyin()
        {
            double buyin = ParseDouble(TxtBuyin.Text);
            double discount = ParseDouble(TxtBuyinDiscount.Text);
            double vat = ParseDouble(TxtBuyinVAT.Text);
            double excise = ParseDouble(txtexcisetax.Text);
            double publicLight = ParseDouble(txtpubliclightingtax.Text);
            double rate = ParseCurrencyRate(CmbCurrency.Text);

            double totalBuyin = ProductPricingCalculator.TotalBuyin(
                buyin, discount, vat, excise, publicLight, rate);

            TxtTotalBuyin.Text = string.Format("{0:N2}", totalBuyin);

            // Total Buyin/Average Price feed Case Price, Unit/Pack/Case Profit -
            // refresh those immediately instead of waiting for another field to change.
            RecalculateSellingPrices();
        }

        private async void TimerUOMLoading_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TimerUOMLoading.Enabled = false;

            try
            {
                var data = await _api.GetAsync<List<ProductScal>>("api/ProductScale");

                if (DataBindingSource.DataSource != null &&
                    DataBindingSource.Current is ProductItem product)
                {
                    //CmbCategory.SelectedValue = product.categoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void disDimensionLoading_Tick(object sender, EventArgs e)
        {
            disDimensionLoading.Enabled = false;
        }

        private void btnAddDimension_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbUOM.Text))
            {
                XtraMessageBox.Show("Please select/enter UOM.", "Select/Enter UOM",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbUOM.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtWidth.Text))
            {
                XtraMessageBox.Show("Please enter Width.", "Enter Width",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtWidth.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtLength.Text))
            {
                XtraMessageBox.Show("Please enter Length.", "Enter Length",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLength.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtHeight.Text))
            {
                XtraMessageBox.Show("Please enter Height.", "Enter Height",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtHeight.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtNetWeight.Text))
            {
                XtraMessageBox.Show("Please enter Net Weight.", "Enter Net Weight",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNetWeight.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtGrossWeight.Text))
            {
                XtraMessageBox.Show("Please enter Gross Weight.", "Enter Gross Weight",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtGrossWeight.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtUnitNumber.Text))
            {
                XtraMessageBox.Show("Please enter UnitNumber.", "Enter UnitNumber",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUnitNumber.Focus();
                return;
            }

            try
            {
                if (CmbUOM.SelectedValue == null)
                {
                    XtraMessageBox.Show("Please select UOM.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dto = new ProductScal
                {
                    ProId = string.IsNullOrWhiteSpace(TxtId.Text) ? 0 : Convert.ToDecimal(TxtId.Text),
                    UOMCode = CmbUOM.SelectedValue.ToString(),
                    Width = ParseDouble(TxtWidth.Text),
                    Length = ParseDouble(TxtLength.Text),
                    Height = ParseDouble(TxtHeight.Text),
                    CBMPerCTN = ParseDouble(TxtCBMPerCTN.Text),
                    NetWeight = ParseDouble(TxtNetWeight.Text),
                    GrossWeight = ParseDouble(TxtGrossWeight.Text),
                    Status = true,
                    ProNumY = TxtUnitNumber.Text.Trim(),
                    //UOMName = CmbUOM.Text.Trim()
                };

                _scaleList.Add(dto);

                if (!ReferenceEquals(gcScale.DataSource, _scaleList))
                    gcScale.DataSource = _scaleList;

                gvScale.RefreshData();

                XtraMessageBox.Show("Added to the list. Click Update to save the product.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BindingList<ProductScal> _scaleList = new BindingList<ProductScal>();

        private void PicProducts_Click(object sender, EventArgs e)
        {
        }

        private void TxtWidth_TextChanged(object sender, EventArgs e)
        {
            CalculateCBM();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            ShelfLife gui = new ShelfLife();
            gui.ShowDialog();
            await ShelifeAsync();
        }

        public async Task ShelifeAsync()
        {
            try
            {
                var list = await _api.GetAsync<List<ShelfLifeClass>>("api/shelflife") ?? new List<ShelfLifeClass>();

                CmbShelfLifeOfProduct.DataSource = list;
                CmbShelfLifeOfProduct.DisplayMember = "ShelfLifeText";
                CmbShelfLifeOfProduct.ValueMember = "Id";
                CmbShelfLifeOfProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private static void OnlyDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
                e.Handled = true;
        }

        private void TxtLength_KeyPress(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);
        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);
        private void TxtCBMPerCTN_KeyPress(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);
        private void TxtNetWeight_KeyPress(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);
        private void TxtGrossWeight_KeyPress(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);
        private void TxtWidth_KeyPress_1(object sender, KeyPressEventArgs e) => OnlyDecimalKeyPress(sender, e);

        private void ShelfLifeOfProductLoading_Tick(object sender, EventArgs e)
        {
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            guiUOM gui = new guiUOM();
            gui.ShowDialog();
            await LodingUOMAsync();
        }

        public async Task LodingUOMAsync()
        {
            try
            {
                var all = await _api.GetAsync<List<UOMClass>>("api/uom") ?? new List<UOMClass>();

                var list = all.Where(u => u.IsActive).ToList();

                CmbUOM.DataSource = list;
                CmbUOM.DisplayMember = "UOMName";
                CmbUOM.ValueMember = "UOMCode";
                CmbUOM.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading UOM: " + ex.Message);
            }
        }

        private void CalculateCBM()
        {
            float.TryParse(TxtWidth.Text.Trim(), out float w);
            float.TryParse(TxtLength.Text.Trim(), out float l);
            float.TryParse(TxtHeight.Text.Trim(), out float h);

            double m3 = ProductPricingCalculator.CbmPerCtn(w, l, h);
            TxtCBMPerCTN.Text = m3.ToString("N2");
        }

        private void TxtHeight_TextChanged(object sender, EventArgs e)
        {
            CalculateCBM();
        }

        private void btnDeleteItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void PicProducts_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select Product Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] bytes = File.ReadAllBytes(dlg.FileName);

                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image temp = Image.FromStream(ms))
                    {
                        PicProducts.Image?.Dispose();
                        PicProducts.Image = new Bitmap(temp);
                    }

                    _productImageBytes = bytes;
                    _productImageFileName = Path.GetFileName(dlg.FileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Could not load image: " + ex.Message,
                        "Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtBuyin_TextChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private void TxtBuyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Float, "", 25);
        }



        private void TxtUnitNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task ReloadCurrentProduct()
        {
            if (!(DataBindingSource.Current is ProductItem current))
                return;

            var product = await _api.GetAsync<ProductItem>($"api/Product/{current.ProID}");

            if (product == null)
                return;

            int index = DataBindingSource.Position;

            RProductList[index] = product;

            DataBindingSource.ResetBindings(false);
            DataBindingSource.Position = index;
        }

        private void TxtTotalBuyin_TextChanged(object sender, EventArgs e)
        {
            double average = string.IsNullOrWhiteSpace(TxtAveragePrice.Text)
                ? 0
                : Convert.ToDouble(TxtAveragePrice.Text.Trim());

            double totalBuyin = string.IsNullOrWhiteSpace(TxtTotalBuyin.Text)
                ? 0
                : Convert.ToDouble(TxtTotalBuyin.Text.Trim());

            if (!BtnAddNew.Enabled)
            {
                TxtAveragePrice.Text = totalBuyin.ToString("N2");
            }

            int qtySold = string.IsNullOrWhiteSpace(TxtQtySold.Text)
                ? 0
                : Convert.ToInt32(TxtQtySold.Text.Trim());

            if (qtySold == 0)
            {
                TxtAveragePrice.Text = totalBuyin.ToString("N2");
            }

            CheckProfitBuyin();
        }
        static int x = 200;
        static int y = 200;
        private void TxtBuyin_Click(object sender, EventArgs e)
        {
            OpenBuyinDialog(sender);
        }
        private void OpenBuyinDialog(object sender)
        {
            double vAvg = string.IsNullOrEmpty(TxtAveragePrice.Text.Trim()) ? 0 : Convert.ToDouble(TxtAveragePrice.Text.Trim());
            double vBuyin = string.IsNullOrEmpty(TxtBuyin.Text.Trim()) ? 0 : Convert.ToDouble(TxtBuyin.Text.Trim());
            decimal vQtyPCase = string.IsNullOrEmpty(TxtQtyPerCase.Text.Trim()) ? 1 : Convert.ToDecimal(TxtQtyPerCase.Text.Trim());
            bool vDefaultBuyinFocus = sender == TxtBuyin;

            FrmProductsBuyinNQtyPCase vFrm = new FrmProductsBuyinNQtyPCase
            {
                vBuyin = vBuyin,
                vQtyPerCase = vQtyPCase,
                vDefaultBuyinFocus = vDefaultBuyinFocus,
                StartPosition = FormStartPosition.Manual
            };


        
            var wa = Screen.FromControl(this).WorkingArea;
            int x = this.Location.X + (this.Width - vFrm.Width) / 2 + 550;
            int y = this.Location.Y  + (this.Height - vFrm.Height) /2  -200;

            x = Math.Max(wa.Left, Math.Min(x, wa.Right - vFrm.Width));
            y = Math.Max(wa.Top, Math.Min(y, wa.Bottom - vFrm.Height));

            vFrm.Location = new Point(x, y);
            if (vFrm.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (vQtyPCase != vFrm.vQtyPerCase)
            {
                if (vBuyin == vFrm.vBuyin)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Please check buyin again." + Environment.NewLine +
                        "The Qty/Case have been changed from '" + vQtyPCase + "' to '" + vFrm.vQtyPerCase + "'.",
                        "Invalid Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                double vTotalAvg = (double)((decimal)vAvg / vQtyPCase * vFrm.vQtyPerCase);
                TxtAveragePrice.Text = vTotalAvg.ToString("N2");
            }

            TxtBuyin.Text = vFrm.vBuyin.ToString();
            TxtQtyPerCase.Text = vFrm.vQtyPerCase.ToString();
        }

        private void TxtBuyin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void TxtBuyin_KeyDown(object sender, KeyEventArgs e)
        {
       



            OpenBuyinDialog(sender);
        }
        public bool searching = false;
        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            int proId = ParseIntDefault(TxtId.Text, 0);
            searching = true;
            if (proId > 0)
            {
                DialogResult answer = XtraMessageBox.Show(
                    "Do you want to update this product before searching?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    await UpdateProductAsync();
                }
            }


            FrmProductsSearch frm = new FrmProductsSearch(this.MdiParent as mainForm);


            this.Close();


            frm.Show();
        }
        private void OpenSearchAndClose()
        {
            var frm = new FrmProductsSearch(this.MdiParent as mainForm);
            frm.MdiParent = this.MdiParent;   
            frm.Show();

            this.Close();   
        }

        private void TxtFactoryCost_Leave(object sender, EventArgs e)
        {
            FormatNumber(TxtFactoryCost);
        }
        private void FormatNumber(TextBox txt)
        {
            if (decimal.TryParse(txt.Text, out decimal value))
            {
                txt.Text = value == 0 ? "" : value.ToString("0.##");
            }
            else
            {
                txt.Text = "";
            }
        }

        private void TxtBuyin_Leave(object sender, EventArgs e)
        {

        }

        private void Panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtBuyinDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

    
            if (char.IsControl(e.KeyChar))
                return;

     
            if (char.IsDigit(e.KeyChar))
                return;

     
            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;


            e.Handled = true;
        }

        private void txtvop_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;


            if (char.IsControl(e.KeyChar))
                return;


            if (char.IsDigit(e.KeyChar))
                return;


            if (e.KeyChar == '.' && !txt.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void TxtBuyinDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private void TxtBuyinVAT_TextChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private void txtexcisetax_TextChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private void txtpubliclightingtax_TextChanged(object sender, EventArgs e)
        {
            CalculatedTotalBuyin();
        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}