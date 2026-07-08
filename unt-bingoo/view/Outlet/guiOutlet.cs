using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;
using System.Linq;
using unt_bingoo.Frameworks;
using ClosedXML.Excel;
using unt_bingoo.view.Product;
using System.Net.Mail;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutlet : XtraForm
    {
        private const int MAX_PHOTOS = 8;
        private const string UPLOAD_URL = "http://192.168.1.99:8099/api/Product/upload";

        private APIsController _api;
        private BindingList<OutletItem> _outletList = new BindingList<OutletItem>();
 
        private ConcurrentDictionary<string, Image> imageCache = new ConcurrentDictionary<string, Image>();
        
        private static readonly HttpClient _httpClient = new HttpClient();
        private int? _editingId = null;
        private string _uploadedImageUrl = "";
        private string _uploadedImagecizen = "";

        private ApplicationFramework App = new ApplicationFramework();

        public guiOutlet()
        {
            InitializeComponent();

            if (gridViewOutlet is GridView view)
            {
                view.OptionsBehavior.Editable = true;
                view.OptionsBehavior.ReadOnly = false;
                view.OptionsView.ShowGroupPanel = false;
                view.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            }
            gridViewOutlet.Appearance.HeaderPanel.BackColor = Color.DimGray;
            gridViewOutlet.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewOutlet.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            gridViewOutlet.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewOutlet.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewOutlet.Appearance.HeaderPanel.Options.UseFont = true;

          
            gridViewOutlet.MasterRowGetRelationCount -= GridViewOutlet_MasterRowGetRelationCount;
            gridViewOutlet.MasterRowGetRelationName -= GridViewOutlet_MasterRowGetRelationName;
            gridViewOutlet.MasterRowGetChildList -= gridViewOutlet_MasterRowGetChildList;
            gridViewOutlet.MasterRowGetLevelDefaultView -= gridViewOutlet_MasterRowGetLevelDefaultView;

            gridViewOutlet.MasterRowGetRelationCount += GridViewOutlet_MasterRowGetRelationCount;
            gridViewOutlet.MasterRowGetRelationName += GridViewOutlet_MasterRowGetRelationName;
            gridViewOutlet.MasterRowGetChildList += gridViewOutlet_MasterRowGetChildList;
            gridViewOutlet.MasterRowGetLevelDefaultView += gridViewOutlet_MasterRowGetLevelDefaultView;

          
        }
        private void GridViewOutlet_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 2;
        }

        // ★ ឈ្មោះ tab សម្រាប់ relation នីមួយៗ
        private void GridViewOutlet_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = (e.RelationIndex == 0) ? "Photos" : "Citizenship";
        }

        public async void FilterFranchise(int franchid)
        {
            try
            {
                var data = await _api.GetAsync<List<Franchise>>("api/Franchise");
                cmbFranchise.DataSource = data;

                var selected = data.FirstOrDefault(x => x.franchiseId == franchid);
                if (selected != null)
                {
                    txtOutletCode.Text = selected.outlet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error:\n" + ex.Message);
            }
        }

        public async Task LoadAllFranchise()
        {
            try
            {
                var franchises = await _api.GetAsync<List<Franchise>>("api/Franchise");

                cmbFranchise.DataSource = franchises;
                cmbFranchise.DisplayMember = "outletName";
                cmbFranchise.ValueMember = "franchiseId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task LoadFranchiseToComboBox()
        {
            try
            {
                var allFranchises = await _api.GetAsync<List<Franchise>>("api/Franchise");
                var existingOutlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

                if (allFranchises == null) return;

                var usedFranchiseIds = (existingOutlets ?? new List<OutletItem>())
                    .Select(o => o.FranchiseId)
                    .ToList();

                var filteredList = allFranchises
                    .Where(f => !usedFranchiseIds.Contains(f.franchiseId))
                    .ToList();

                cmbFranchise.DataSource = filteredList;
                cmbFranchise.DisplayMember = "outletName";
                cmbFranchise.ValueMember = "franchiseId";
                cmbFranchise.SelectedIndex = (filteredList.Count > 0) ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error:\n" + ex.Message);
            }
        }
        private async Task LoadingHourseOparation()
        {
            try
            {
                var data = await _api.GetAsync<List<HourOperation>>("api/HourOperation");

                cboHourOperation.DataSource = null;

                cboHourOperation.DataSource = data;
                cboHourOperation.DisplayMember = "Display";
                cboHourOperation.ValueMember = "Id";
                cboHourOperation.SelectedIndex = -1;
             
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private async void guiOutlet_Load(object sender, EventArgs e)
        {
       //     EnableResponsiveScaling();
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                //// Setup Grid Image Column
                //gridViewOutlet.RowHeight = 70;

                //RepositoryItemPictureEdit pic = new RepositoryItemPictureEdit();
                //pic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                //pic.NullText = "No Image";
                //gridControlOutlet.RepositoryItems.Add(pic);

                //// ★ បង្កើត column ProductImage បើវាមិនទាន់មាន (បង្ហាញរូបមេក្នុង grid)
                //var imgCol = gridViewOutlet.Columns["ProductImage"];
                //if (imgCol == null)
                //{
                //    imgCol = gridViewOutlet.Columns.AddVisible("ProductImage");
                //}
                //imgCol.Caption = "Image";
                //imgCol.ColumnEdit = pic;
                //imgCol.Visible = true;
                //imgCol.VisibleIndex = -1;
                //imgCol.Width = 70;
                //imgCol.OptionsColumn.FixedWidth = false;
                //imgCol.OptionsColumn.AllowEdit = false;

                await LoadData();
                await LoadingProvince();
                await GenerateAutoOutletCodeAsync();
                await this.LoadFranchiseToComboBox();
                await this.LoadingHourseOparation();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            //gridViewOutlet.BestFitColumns();

            OutletCode.OptionsColumn.FixedWidth = true;
            OutletCode.Width = 30;
            OutletCode.MinWidth = 30;
            OutletCode.MaxWidth = 30;
        }

        private async Task GenerateAutoOutletCodeAsync()
        {
            try
            {
                var list = await _api.GetAsync<List<OutletItem>>("api/Outlet");
                int newId = (list != null && list.Any()) ? list.Max(x => x.Id) + 1 : 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error generating code: {ex.Message}");
            }
        }

        private async Task LoadingProvince()
        {
            var list = await _api.GetAsync<List<ProvinceItem>>("api/Province");
            cboProvince.DataSource = list;
            cboProvince.DisplayMember = "ProvinceNameEN";
            cboProvince.ValueMember = "provinceId";
            cboProvince.SelectedIndex = -1;
        }

        private async Task LoadData()
        {
            try
            {
                var list = await _api.GetAsync<List<OutletItem>>("api/Outlet");
                if (list == null) return;

                var imageTasks = new List<Task>();

                foreach (var item in list)
                {
                    // រូបមេ
                    if (!string.IsNullOrEmpty(item.PhotoPath))
                    {
                        var captured = item;
                        imageTasks.Add(Task.Run(async () =>
                        {
                            try { captured.ProductImage = await LoadImageFromUrl(captured.PhotoPath); }
                            catch { captured.ProductImage = null; }
                        }));
                    }

                    if (item.ShopPhoto != null && item.ShopPhoto.Any())
                    {
                        foreach (var photo in item.ShopPhoto)
                        {
                            if (!string.IsNullOrEmpty(photo.Url))
                            {
                                var capturedPhoto = photo;
                                imageTasks.Add(Task.Run(async () =>
                                {
                                    try { capturedPhoto.DetailImage = await LoadImageFromUrl(capturedPhoto.Url); }
                                    catch { capturedPhoto.DetailImage = null; }
                                }));
                            }
                        }
                    }

                    // ★ Citizenship photos (tab Citizenship)
                    if (item.citizenshipPhotos != null && item.citizenshipPhotos.Any())
                    {
                        foreach (var cp in item.citizenshipPhotos)
                        {
                            if (!string.IsNullOrEmpty(cp.ImageUrl))
                            {
                                var capturedCp = cp;
                                imageTasks.Add(Task.Run(async () =>
                                {
                                    try { capturedCp.CitizenshipImage = await LoadImageFromUrl(capturedCp.ImageUrl); }
                                    catch { capturedCp.CitizenshipImage = null; }
                                }));
                            }
                        }
                    }
                }

                await Task.WhenAll(imageTasks);
          
                _outletList = new BindingList<OutletItem>(list);
                gridControlOutlet.DataSource = _outletList;
                //gridViewOutlet.BestFitColumns();
                //gridViewOutlet.RefreshData();
                lblCountRow.Text = $"Count Row: {_outletList.Count}";
                await this.LoadFranchiseToComboBox();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private async Task<Image> LoadImageFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;
            if (imageCache.TryGetValue(url, out Image cached)) return cached;

            try
            {
                byte[] data = await _httpClient.GetByteArrayAsync(url);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    // ★ បង្កើត Bitmap ថ្មី ដើម្បីកុំឱ្យ Image ពឹងលើ stream ដែលត្រូវ dispose
                    using (Image temp = Image.FromStream(ms))
                    {
                        Image img = new Bitmap(temp);
                        imageCache[url] = img;
                        return img;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var model = GetFormData();

            try
            {
                Cursor = Cursors.WaitCursor;
                bool ok;

                if (_editingId == null)
                {
                    ok = await _api.PostAsync("api/Outlet", model);
                    if (ok) XtraMessageBox.Show("Added successfully!");
                }
                else
                {
                    ok = await _api.PutAsync($"api/Outlet/{_editingId}", model);
                    if (ok) XtraMessageBox.Show("Updated successfully!");
                }

                if (ok)
                {
                    await LoadData();
                    await GenerateAutoOutletCodeAsync();
                    ClearForm();
                }
                else
                {
                    XtraMessageBox.Show("Operation failed!");
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
            finally { Cursor = Cursors.Default; }
        }

        private async void btnUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private async void picCustomer_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var old = picCustomer.Image;
                    using (var tmp = Image.FromFile(dlg.FileName))
                    {
                        picCustomer.Image = new Bitmap(tmp);
                    }
                    old?.Dispose();

                    string url = await UploadImage(dlg.FileName);
                    if (!string.IsNullOrEmpty(url))
                    {
                        _uploadedImageUrl = url;
                
                        XtraMessageBox.Show("Upload success!");
                    }
                }
            }
        }

        private async Task<string> UploadImage(string filePath)
        {
            try
            {
                using (var form = new MultipartFormDataContent())
                {
                    byte[] data = File.ReadAllBytes(filePath);
                    var content = new ByteArrayContent(data);

                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    string mime = (ext == ".png") ? "image/png" : "image/jpeg";
                    content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue(mime);

                    form.Add(content, "file", Path.GetFileName(filePath));

                    var res = await _httpClient.PostAsync(UPLOAD_URL, form);
                    var json = await res.Content.ReadAsStringAsync();

                    if (!res.IsSuccessStatusCode)
                    {
                        XtraMessageBox.Show(
                            $"Server error: {(int)res.StatusCode} {res.StatusCode}\n\n{json}",
                            "Upload Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<UploadResult>(json);

                    if (obj == null || string.IsNullOrEmpty(obj.imageUrl))
                    {
                        XtraMessageBox.Show(
                            $"No imageUrl in response.\nRaw JSON:\n{json}",
                            "Parse Problem",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return null;
                    }

                    return obj.imageUrl;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Connection Error");
                return null;
            }
        }

        private async void btnAddPhoto_Click(object sender, EventArgs e)
        {
            await PickAndUploadPhotos(flpPhotos, AddImageToGallery);
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            await PickAndUploadPhotos(flowLayoutPanel1, AddImageToGallerycititenship);
        }

        private async Task PickAndUploadPhotos(
            FlowLayoutPanel targetPanel,
            Action<string, string> addToGallery)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Images|*.jpg;*.jpeg;*.png"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                if (targetPanel.Controls.Count + ofd.FileNames.Length > MAX_PHOTOS)
                {
                    XtraMessageBox.Show(
                        $"You can upload a maximum of {MAX_PHOTOS} photos.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                try
                {
                    int successCount = 0;

                    foreach (string file in ofd.FileNames)
                    {
                        string url = await UploadImage(file);

                        if (!string.IsNullOrEmpty(url))
                        {
                            addToGallery(file, url);

                            var oldImage = picCustomer.Image;
                            using (var tempImg = Image.FromFile(file))
                            {
                                picCustomer.Image = new Bitmap(tempImg);
                            }
                            oldImage?.Dispose();

                            _uploadedImageUrl = url;
                           
                            successCount++;
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                $"Upload failed for {Path.GetFileName(file)}.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }

                    if (successCount > 0)
                    {
                        XtraMessageBox.Show(
                            $"{successCount} photo(s) added!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        "Error " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void AddImageToGallerycititenship(string localFilePath, string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel
                {
                    Size = new Size(100, 100),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = remoteUrl
                };
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };
                using (var img = Image.FromFile(localFilePath))
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton
                {
                    Text = "X",
                    Size = new Size(20, 20),
                    Location = new Point(78, 2),
                    ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat,
                    Appearance = { ForeColor = Color.Red }
                };
                btnDel.Click += (s, e) =>
                {
                    flowLayoutPanel1.Controls.Remove(pnl);
                    pb.Image?.Dispose();
                    pnl.Dispose();
                };

                pnl.Controls.Add(pb);
                pnl.Controls.Add(btnDel);
                btnDel.BringToFront();
                flowLayoutPanel1.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Photo Notfound Gallery: " + ex.Message); }
        }

        private void AddImageToGallery(string localFilePath, string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel
                {
                    Size = new Size(100, 100),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = remoteUrl
                };

                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };
                using (var img = Image.FromFile(localFilePath))
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton
                {
                    Text = "X",
                    Size = new Size(20, 20),
                    Location = new Point(78, 2),
                    ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat,
                    Appearance = { ForeColor = Color.Red }
                };
                btnDel.Click += (s, e) =>
                {
                    flpPhotos.Controls.Remove(pnl);
                    pb.Image?.Dispose();
                    pnl.Dispose();
                };

                pnl.Controls.Add(pb);
                pnl.Controls.Add(btnDel);
                btnDel.BringToFront();
                flpPhotos.Controls.Add(pnl);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Photo Notfound Gallery: " + ex.Message);
            }
        }

        private async Task AddImageToGalleryFromUrl(string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel
                {
                    Size = new Size(100, 100),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = remoteUrl
                };
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };

                Image img = await LoadImageFromUrl(remoteUrl);
                if (img != null)
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton
                {
                    Text = "X",
                    Size = new Size(20, 20),
                    Location = new Point(78, 2),
                    ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat,
                    Appearance = { ForeColor = Color.Red }
                };
                btnDel.Click += (s, e) =>
                {
                    flpPhotos.Controls.Remove(pnl);
                    pb.Image?.Dispose();
                    pnl.Dispose();
                };

                pnl.Controls.Add(pb);
                pnl.Controls.Add(btnDel);
                btnDel.BringToFront();
                flpPhotos.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Error loading gallery item: " + ex.Message); }
        }

        // ★ load រូប citizenship មកវិញពី URL ចូល flowLayoutPanel1 (ប្រើពេលកែ)
        private async Task AddCitizenshipGalleryFromUrl(string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel
                {
                    Size = new Size(100, 100),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = remoteUrl
                };
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };

                Image img = await LoadImageFromUrl(remoteUrl);
                if (img != null)
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton
                {
                    Text = "X",
                    Size = new Size(20, 20),
                    Location = new Point(78, 2),
                    ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat,
                    Appearance = { ForeColor = Color.Red }
                };
                btnDel.Click += (s, e) =>
                {
                    flowLayoutPanel1.Controls.Remove(pnl);
                    pb.Image?.Dispose();
                    pnl.Dispose();
                };

                pnl.Controls.Add(pb);
                pnl.Controls.Add(btnDel);
                btnDel.BringToFront();
                flowLayoutPanel1.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Error loading citizenship item: " + ex.Message); }
        }

        private OutletItemCreate GetFormData()
        {
            List<string> galleryPhotos = new List<string>();

            foreach (Control ctrl in flpPhotos.Controls)
            {
                if (ctrl is Panel pnl && pnl.Tag != null)
                {
                    string url = pnl.Tag.ToString();
                    if (!string.IsNullOrEmpty(url))
                    {
                        galleryPhotos.Add(url);
                    }
                }
            }

            List<string> galleryPhotoss = new List<string>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel pnl && pnl.Tag != null)
                {
                    string url = pnl.Tag.ToString();
                    if (!string.IsNullOrEmpty(url))
                    {
                        galleryPhotoss.Add(url);
                    }
                }
            }
            return new OutletItemCreate
            {
                Id = _editingId ?? 0,
                FranchiseId = cmbFranchise.SelectedValue != null ? Convert.ToInt32(cmbFranchise.SelectedValue) : 0,
                OutletCode = txtOutletCode.Text.Trim(),
                Province = cboProvince.Text.Trim(),
                FrancisePhone = txtPhone.Text.Trim(),
                Manager = txtManager.Text.Trim(),
                HeadOffice = chkHeadOffice.Checked,
                IsActive = chkActive.Checked,
                VATNumber = txtvatNumber.Text.Trim(),
                ProvinceId = cboProvince.SelectedValue != null ? Convert.ToInt32(cboProvince.SelectedValue) : 0,
                PhotoPath = _uploadedImageUrl,
                OutletName = cmbFranchise.Text.Trim(),
                Position = txtposition.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                PhotoPaths = galleryPhotos,
                CitizenshipPhotos = galleryPhotoss,
                HourOperationId = cboHourOperation.SelectedValue != null ? Convert.ToInt32(cboHourOperation.SelectedValue) : 0,
                OutletPhone = txtoutletphon.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                GrandOpeningDate = dtpOpening.Value
            };
        }

        private bool ValidateForm()
        {
            if (cmbFranchise.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Please select Franchise.");
                cmbFranchise.Focus();
                return false;
            }
           
            if (string.IsNullOrWhiteSpace(txtOutletCode.Text))
            {
                XtraMessageBox.Show("Outlet Code is required.");
                txtOutletCode.Focus();
                return false;
            }

            if (cboProvince.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Please select Province.");
                cboProvince.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                XtraMessageBox.Show("Phone is required.");
                txtPhone.Focus();
                return false;
            }

            if (txtPhone.Text.Length < 8)
            {
                XtraMessageBox.Show("Phone number is invalid.");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtManager.Text))
            {
                XtraMessageBox.Show("Manager is required.");
                txtManager.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(_uploadedImageUrl))
            {
                XtraMessageBox.Show("Please add shop photo, require.");
                return false;
            }
            if (!chkActive.Checked && !chkDeactive.Checked)
            {
                XtraMessageBox.Show("Please select Active or Deactive.");
                return false;
            }
            List<string> galleryPhotoss = new List<string>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Panel pnl && pnl.Tag is string url && !string.IsNullOrWhiteSpace(url))
                {
                    galleryPhotoss.Add(url);
                }
            }

            if (galleryPhotoss.Count == 0)
            {
                MessageBox.Show(
      "Please add at least one citizen ID photo.",
      "Validation",
      MessageBoxButtons.OK,
      MessageBoxIcon.Warning);

                return false;
            }



            List<string> galleryPhotos = new List<string>();

            foreach (Control ctrl in flpPhotos.Controls)
            {
                if (ctrl is Panel pnl && pnl.Tag is string url && !string.IsNullOrWhiteSpace(url))
                {
                    galleryPhotos.Add(url);
                }
            }

            if (galleryPhotos.Count == 0)
            {
                MessageBox.Show(
      "Please add at least one Shop Photo.",
      "Validation",
      MessageBoxButtons.OK,
      MessageBoxIcon.Warning);

                return false;
            }




            return true;
        }

        private void ClearForm()
        {
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtManager.Text = "";
            txtEmail.Text = "";
            txtvatNumber.Text = "";
            chkHeadOffice.Checked = false;
            chkActive.Checked = true;
            txtOutletCode.Text = "";
            cmbFranchise.SelectedIndex = -1;
            txtoutletphon.Text = "";

            picCustomer.Image?.Dispose();
            picCustomer.Image = null;
            cmbFranchise.Enabled = true;

            DisposeGallery(flpPhotos);
            DisposeGallery(flowLayoutPanel1);

            _editingId = null;
            _uploadedImageUrl = "";
            btnAdd.Text = "Add";
            txtposition.Text = "";
            cboProvince.SelectedIndex = -1;
            cmbFranchise.SelectedIndex = -1;
            cboHourOperation.SelectedIndex = -1;
        }

        private void DisposeGallery(FlowLayoutPanel panel)
        {
            if (panel == null) return;
            foreach (Control ctrl in panel.Controls)
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (child is PictureBox pb)
                    {
                        pb.Image?.Dispose();
                    }
                }
            }
            panel.Controls.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e) => ClearForm();

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewOutlet.DataRowCount <= 0)
                {
                    XtraMessageBox.Show("No data to export.", "Export Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cols = gridViewOutlet.VisibleColumns
                    .Cast<DevExpress.XtraGrid.Columns.GridColumn>()
                    .Where(c => !string.IsNullOrEmpty(c.FieldName)
                                && c.FieldName != "ProductImage"
                                && c.FieldName != "DetailImage"
                                && c.FieldName != "CitizenshipImage"
                                && c.FieldName != "Update"
                                && c.FieldName != "Delete"
                                && !(c.ColumnEdit is RepositoryItemPictureEdit)
                                && !(c.ColumnEdit is RepositoryItemButtonEdit))
                    .ToList();

                string path = Path.Combine(
                    Path.GetTempPath(),
                    "Outlet_List_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");

                BuildOutletWorkbook(cols, path);

                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo() { FileName = path, UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Export failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildOutletWorkbook(List<DevExpress.XtraGrid.Columns.GridColumn> cols, string path)
        {
            var navy = XLColor.FromArgb(31, 58, 95);
            var bandB = XLColor.FromArgb(238, 243, 250);
            var white = XLColor.White;
            var dark = XLColor.FromArgb(27, 39, 51);
            var grid = XLColor.FromArgb(201, 211, 223);
            var line = XLColor.FromArgb(143, 168, 196);
            const string FONT = "Calibri";

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Outlet List");
                ws.ShowGridLines = false;

                int nCols = cols.Count + 1;
                var headers = new List<string> { "No." };
                headers.AddRange(cols.Select(c => string.IsNullOrEmpty(c.Caption) ? c.FieldName : c.Caption));

                ws.Column(1).Width = 6;
                for (int c = 0; c < cols.Count; c++)
                {
                    string cap = headers[c + 1].ToLower();
                    double w = 18;
                    if (cap.Contains("address") || cap.Contains("province")) w = 36;
                    else if (cap.Contains("name") || cap.Contains("outlet")) w = 26;
                    else if (cap.Contains("manager") || cap.Contains("position")) w = 20;
                    else if (cap.Contains("phone") || cap.Contains("vat") || cap.Contains("code")) w = 16;
                    else if (cap.Contains("date")) w = 18;
                    else if (cap.Contains("active") || cap.Contains("head")) w = 11;
                    ws.Column(c + 2).Width = w;
                }

                ws.Range(1, 1, 1, nCols).Merge();
                var t = ws.Cell(1, 1);
                t.Value = "OUTLET  LIST";
                t.Style.Font.SetBold(true); t.Style.Font.FontColor = white;
                t.Style.Font.FontSize = 16; t.Style.Font.FontName = FONT;
                t.Style.Fill.BackgroundColor = navy;
                t.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                t.Style.Alignment.Indent = 1;
                ws.Row(1).Height = 32;

                ws.Range(2, 1, 2, nCols).Merge();
                var s = ws.Cell(2, 1);
                s.Value = "Exported: " + DateTime.Now.ToString("dd MMM yyyy  HH:mm") +
                          "     |     " + gridViewOutlet.DataRowCount + " records";
                s.Style.Font.Italic = true; s.Style.Font.FontSize = 9.5;
                s.Style.Font.FontColor = XLColor.FromArgb(91, 107, 123);
                s.Style.Fill.BackgroundColor = XLColor.FromArgb(244, 247, 251);
                s.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                s.Style.Alignment.Indent = 1;
                ws.Row(2).Height = 18;

                int headerRow = 4;
                for (int c = 0; c < nCols; c++)
                {
                    var h = ws.Cell(headerRow, c + 1);
                    h.Value = headers[c];
                    h.Style.Font.SetBold(true); h.Style.Font.FontColor = white;
                    h.Style.Font.FontName = FONT; h.Style.Font.FontSize = 10.5;
                    h.Style.Fill.BackgroundColor = navy;
                    h.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    h.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    h.Style.Alignment.WrapText = true;
                }
                ws.Row(headerRow).Height = 26;

                int row = headerRow + 1;
                int dataCount = gridViewOutlet.DataRowCount;
                for (int r = 0; r < dataCount; r++)
                {
                    var band = (r % 2 == 1) ? bandB : white;

                    var no = ws.Cell(row, 1);
                    no.Value = r + 1;
                    no.Style.Font.FontName = FONT; no.Style.Font.FontSize = 10;
                    no.Style.Font.FontColor = dark;
                    no.Style.Fill.BackgroundColor = band;
                    no.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    no.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                    for (int c = 0; c < cols.Count; c++)
                    {
                        string text = gridViewOutlet.GetRowCellDisplayText(r, cols[c]) ?? "";
                        var cell = ws.Cell(row, c + 2);
                        cell.Value = text;
                        cell.Style.Font.FontName = FONT; cell.Style.Font.FontSize = 10;
                        cell.Style.Font.FontColor = dark;
                        cell.Style.Fill.BackgroundColor = band;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        string cap = headers[c + 1].ToLower();
                        if (cap.Contains("address") || cap.Contains("province") ||
                            cap.Contains("name") || cap.Contains("outlet") || cap.Contains("manager"))
                        {
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            cell.Style.Alignment.WrapText = true;
                            cell.Style.Alignment.Indent = 1;
                        }
                        else cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    ws.Row(row).Height = 20;
                    row++;
                }
                int dataEnd = row - 1;

                var dr = ws.Range(headerRow, 1, dataEnd, nCols);
                dr.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                dr.Style.Border.InsideBorderColor = grid;
                dr.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                dr.Style.Border.OutsideBorderColor = line;
                ws.Range(headerRow, 1, headerRow, nCols).Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                ws.Range(headerRow, 1, headerRow, nCols).Style.Border.BottomBorderColor = line;

                ws.SheetView.FreezeRows(headerRow);
                ws.Range(headerRow, 1, dataEnd, nCols).SetAutoFilter();

                wb.SaveAs(path);
            }
        }

        private void flpPhotos_Paint(object sender, PaintEventArgs e) { }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridViewOutlet.GetFocusedRow() as OutletItem;
                if (row != null)
                {
                    using (var frmDetail = new guiListoutLet(row.Id))
                    {
                        frmDetail.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error opening details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guiProvince gui = new guiProvince();
            gui.ShowDialog();
            _ = this.LoadingProvince();
        }

        private void btnClose_Click_1(object sender, EventArgs e) => this.Close();

        private void cmbFranchise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFranchise.SelectedIndex != -1 && cmbFranchise.SelectedItem != null)
            {
                var selectedFranchise = (Franchise)cmbFranchise.SelectedItem;
                txtOutletCode.Text = selectedFranchise.outlet;
                txtfrandtype.Text = selectedFranchise.typeName;
            }
            else
            {
                txtOutletCode.Text = string.Empty;
                txtfrandtype.Text = string.Empty;
            }
        }

        int currentselect = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            currentselect = (int)this.cmbFranchise.SelectedIndex;
            guiFranchise gui = new guiFranchise();
            gui.ShowDialog();
            _ = this.LoadFranchiseToComboBox();
        }

        private void gridViewOutlet_MasterRowExpanded(object sender, CustomMasterRowEventArgs e) { }

        // ★ ផ្ដល់ tile view សម្រាប់ tab នីមួយៗ (index 0 = Photos, index 1 = Citizenship)
        private void gridViewOutlet_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e)
        {
            string imageField = (e.RelationIndex == 0) ? "DetailImage" : "CitizenshipImage";

            DevExpress.XtraGrid.Views.Tile.TileView tileView =
                new DevExpress.XtraGrid.Views.Tile.TileView(gridControlOutlet);

            tileView.OptionsTiles.Orientation = Orientation.Horizontal;
            tileView.OptionsTiles.ItemSize = new Size(120, 100);
            tileView.OptionsTiles.RowCount = 1;
            tileView.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            tileView.OptionsTiles.Padding = new Padding(10, 5, 10, 5);

            RepositoryItemPictureEdit detailPic = new RepositoryItemPictureEdit();
            detailPic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            detailPic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridControlOutlet.RepositoryItems.Add(detailPic);

            DevExpress.XtraGrid.Columns.GridColumn colImage = tileView.Columns.AddField(imageField);
            colImage.Visible = true;
            colImage.ColumnEdit = detailPic;

            tileView.TileTemplate.Clear();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement element =
                new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            element.Column = colImage;
            element.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside;
            element.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            element.StretchHorizontal = true;
            element.StretchVertical = true;

            tileView.TileTemplate.Add(element);

            e.DefaultView = tileView;
        }

        private void gridViewOutlet_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.White;
            }
            else
            {
                e.Appearance.BackColor = Color.AliceBlue;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        // ★ child list ខុសគ្នាតាម tab
        private void gridViewOutlet_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var row = gridViewOutlet.GetRow(e.RowHandle) as OutletItem;
            if (row == null) return;

            if (e.RelationIndex == 0)
                e.ChildList = row.Photos;
            else
                e.ChildList = row.citizenshipPhotos;
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void btnUpdate_ButtonClick(object sender, EventArgs e)
        {
        }

        private async void btnmainDelete_ButtonClick(object sender, EventArgs e)
        {
        }

        private async void gridViewOutlet_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var row = gridViewOutlet.GetRow(e.RowHandle) as OutletItem;

            if (row == null)
                return;

            if (e.Column.FieldName == "Update")
            {
                await LoadAllFranchise();
                _editingId = row.Id;
                cmbFranchise.SelectedValue = row.FranchiseId;
                txtOutletCode.Text = row.OutletCode;
                txtAddress.Text = row.Address;
                txtPhone.Text = row.FrancisePhone;
                txtManager.Text = row.Manager;
                txtvatNumber.Text = row.VATNumber;
                txtposition.Text = row.position;
                txtoutletphon.Text = row.OutletPhone ?? "";

                chkHeadOffice.Checked = row.HeadOffice;
                chkActive.Checked = row.IsActive;
                cboHourOperation.SelectedValue = row.HourOperationId;
                cboProvince.SelectedValue = row.provinceId;
                txtEmail.Text = row.Email;
                cboHourOperation.SelectedValue = row.hourOperationId;
                cmbFranchise.Enabled = false;
     
                //txtAddress.Text

   
                _uploadedImageUrl = row.PhotoPath ?? "";
                picCustomer.Image?.Dispose();
                picCustomer.Image = null;
                if (!string.IsNullOrEmpty(row.PhotoPath))
                {
                    var mainImg = await LoadImageFromUrl(row.PhotoPath);
                    if (mainImg != null) picCustomer.Image = new Bitmap(mainImg);
                }

                // ★ reload shop photos
                DisposeGallery(flpPhotos);
                if (row.ShopPhoto != null)
                {
                    foreach (var p in row.ShopPhoto)
                    {
                        if (!string.IsNullOrEmpty(p.Url))
                            await AddImageToGalleryFromUrl(p.Url);
                    }
                }

                // ★ reload citizenship photos
                DisposeGallery(flowLayoutPanel1);
                if (row.citizenshipPhotos != null)
                {
                    foreach (var cp in row.citizenshipPhotos)
                    {
                        if (!string.IsNullOrEmpty(cp.ImageUrl))
                            await AddCitizenshipGalleryFromUrl(cp.ImageUrl);
                    }
                }

                btnAdd.Text = "Update";
                if (!chkActive.Checked)
                {
                    chkDeactive.Checked = true;
                }
            }

            if (e.Column.FieldName == "Delete")
            {
                DialogResult result = XtraMessageBox.Show(
                    $"Are you sure you want to delete '{row.OutletName}' ?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = await _api.DeleteAsync($"api/Outlet/{row.Id}");
                        if (success)
                        {
                            XtraMessageBox.Show("Deleted successfully!");
                            await LoadData();
                            ClearForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            ex.Message,
                            "Delete Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkDeactive.Checked = false;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeactive.Checked)
            {
                chkActive.Checked = false;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboBrand_Enter(object sender, EventArgs e)
        {
        }

        private void cboBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private readonly Size _designSize = new Size(1613, 635);
        private const bool ScaleFonts = true;
        private bool _responsiveReady = false;

        public void EnableResponsiveScaling()
        {
            this.panelDetail.AutoScroll = false;

            StoreOriginalBounds(this);
            _responsiveReady = true;

            this.Resize += (s, e) => { if (_responsiveReady) ScaleAll(); };
            ScaleAll();
        }

        private void StoreOriginalBounds(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Tag = new CtrlInfo
                {
                    Bounds = c.Bounds,
                    FontSize = c.Font != null ? c.Font.Size : 9f
                };
                if (c.HasChildren)
                    StoreOriginalBounds(c);
            }
        }

        private void ScaleAll()
        {
            if (_designSize.Width <= 0 || _designSize.Height <= 0) return;
            if (this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0) return;

            float sx = (float)this.ClientSize.Width / _designSize.Width;
            float sy = (float)this.ClientSize.Height / _designSize.Height;

            this.SuspendLayout();
            ScaleControls(this, sx, sy);
            this.ResumeLayout(true);
        }

        private void ScaleControls(Control parent, float sx, float sy)
        {
            foreach (Control c in parent.Controls)
            {
                CtrlInfo info = c.Tag as CtrlInfo;
                if (info != null)
                {
                    Rectangle b = info.Bounds;

                    switch (c.Dock)
                    {
                        case DockStyle.None:
                            c.Bounds = new Rectangle(
                                (int)(b.X * sx),
                                (int)(b.Y * sy),
                                (int)(b.Width * sx),
                                (int)(b.Height * sy));
                            break;

                        case DockStyle.Left:
                        case DockStyle.Right:
                            c.Width = Math.Max(1, (int)(b.Width * sx));
                            break;

                        case DockStyle.Top:
                        case DockStyle.Bottom:
                            c.Height = Math.Max(1, (int)(b.Height * sy));
                            break;
                    }

                    if (ScaleFonts)
                    {
                        float f = info.FontSize * Math.Min(sx, sy);
                        if (f >= 6f && f <= 30f && Math.Abs(c.Font.Size - f) > 0.3f)
                        {
                            try { c.Font = new Font(c.Font.FontFamily, f, c.Font.Style); }
                            catch { /* ignore */ }
                        }
                    }
                }

                if (c.HasChildren)
                    ScaleControls(c, sx, sy);
            }
        }

        private class CtrlInfo
        {
            public Rectangle Bounds;
            public float FontSize;
        }

        private void lblManager_Click(object sender, EventArgs e)
        {

        }

        private void txtManager_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            guiHourOpration gui = new guiHourOpration();
            gui.ShowDialog();
            _ = LoadingHourseOparation();
        }

        private void cboHourOperation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void gridControlOutlet_Click(object sender, EventArgs e)
        {

        }

        private void txtoutletphon_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        
            if (!char.IsControl(e.KeyChar) &&
                txtoutletphon.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void gridViewOutlet_MasterRowGetRelationCount_1(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 2;
        }

        private void simpleButton5_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}