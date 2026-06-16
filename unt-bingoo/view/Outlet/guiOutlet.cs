using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
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

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutlet : XtraForm
    {
        private APIsController _api;
        private BindingList<OutletItem> _outletList = new BindingList<OutletItem>();
        private Dictionary<string, Image> imageCache = new Dictionary<string, Image>();
        private int? _editingId = null;
        private string _uploadedImageUrl = "";

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

        public async Task LoadFranchiseToComboBox()
        {
            try
            {
            
                var allFranchises = await _api.GetAsync<List<Franchise>>("api/Franchise");
                var existingOutlets = await _api.GetAsync<List<OutletItem>>("api/Outlet");

             
                var usedFranchiseIds = existingOutlets.Select(o => o.FranchiseId).ToList();

     
                var filteredList = allFranchises
                    .Where(f => !usedFranchiseIds.Contains(f.franchiseId))
                    .ToList();

     
                if (filteredList != null)
                {
                    cmbFranchise.DataSource = filteredList;
                    cmbFranchise.DisplayMember = "outletName";
                    cmbFranchise.ValueMember = "franchiseId";

             
                    cmbFranchise.SelectedIndex = (filteredList.Count > 0) ? 0 : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error:\n" + ex.Message);
            }
        }

        private async void guiOutlet_Load(object sender, EventArgs e)
        {
            try
            {
                _api = APIGlobals.Api;

                if (_api == null || !_api.HasToken())
                {
                    XtraMessageBox.Show("Please login again!");
                    Close();
                    return;
                }

                // Setup Grid Image Column
                gridViewOutlet.RowHeight = 70;

                RepositoryItemPictureEdit pic = new RepositoryItemPictureEdit();
                pic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                pic.NullText = "No Image";
                gridControlOutlet.RepositoryItems.Add(pic);

                if (gridViewOutlet.Columns["ProductImage"] != null)
                {
                    gridViewOutlet.Columns["ProductImage"].ColumnEdit = pic;
                }

                await LoadData();
                await LoadingProvince();
                await GenerateAutoOutletCodeAsync();
                await this.LoadFranchiseToComboBox();
                ClearForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
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
            cboBrand.DataSource = list;
            cboBrand.DisplayMember = "ProvinceNameEN";
            cboBrand.ValueMember = "provinceId";
            cboBrand.SelectedIndex = -1;
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
                   
                    if (!string.IsNullOrEmpty(item.PhotoPath))
                    {
                        imageTasks.Add(Task.Run(async () =>
                        {
                            item.ProductImage = await LoadImageFromUrl(item.PhotoPath);
                        }));
                    }

             
                    if (item.Photos != null && item.Photos.Any())
                    {
                        foreach (var photo in item.Photos)
                        {
                            if (!string.IsNullOrEmpty(photo.Url))
                            {
                                imageTasks.Add(Task.Run(async () =>
                                {
                                    photo.DetailImage = await LoadImageFromUrl(photo.Url);
                                }));
                            }
                        }
                    }
                }

                await Task.WhenAll(imageTasks);

                _outletList = new BindingList<OutletItem>(list);
                gridControlOutlet.DataSource = _outletList;
                gridViewOutlet.BestFitColumns();

                gridViewOutlet.RefreshData();
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
            if (imageCache.ContainsKey(url)) return imageCache[url];

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] data = await client.GetByteArrayAsync(url);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        Image img = Image.FromStream(ms);
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
            var row = gridViewOutlet.GetFocusedRow() as OutletItem;
            if (row == null) return;

            _editingId = row.Id;
            cmbFranchise.SelectedValue = row.FranchiseId;
            txtOutletCode.Text = row.OutletCode;
            txtAddress.Text = row.Province;
            txtPhone.Text = row.Phone;
            txtManager.Text = row.Manager;
            txtvatNumber.Text = row.VATNumber;

            chkHeadOffice.Checked = row.HeadOffice;
            chkActive.Checked = row.IsActive;

            if (cboBrand.DataSource is List<ProvinceItem> provinces)
            {
                var prov = provinces.FirstOrDefault(p => p.provinceNameKH == row.Province || p.provinceNameEN == row.Province);
                if (prov != null) cboBrand.SelectedValue = prov.provinceId;
            }

            _uploadedImageUrl = row.PhotoPath;
            if (row.ProductImage != null)
                picCustomer.Image = row.ProductImage;
            else if (!string.IsNullOrEmpty(row.PhotoPath))
                picCustomer.Image = await LoadImageFromUrl(row.PhotoPath);
            else
                picCustomer.Image = null;

            flpPhotos.Controls.Clear();
            if (row.Photos != null && row.Photos.Any())
            {
                foreach (var photo in row.Photos)
                {
                    if (!string.IsNullOrEmpty(photo.Url))
                    {
                        await AddImageToGalleryFromUrl(photo.Url);
                    }
                }
            }

            btnAdd.Text = "Update";
        }

        private async void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewOutlet.GetFocusedRow() as OutletItem;
            if (row == null) return;

            if (XtraMessageBox.Show("Delete this outlet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool ok = await _api.DeleteAsync($"api/Outlet/{row.Id}");
                if (ok)
                {
                    await LoadData();
                    ClearForm();
                    XtraMessageBox.Show("Deleted successfully!");
                }
            }
        }

        private async void picCustomer_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picCustomer.Image = Image.FromFile(dlg.FileName);
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
                using (var client = new HttpClient())
                using (var form = new MultipartFormDataContent())
                {

                    ///http://localhost:8099/bingoo/api/Product/upload
                    byte[] data = File.ReadAllBytes(filePath);
                    var content = new ByteArrayContent(data);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                    form.Add(content, "file", Path.GetFileName(filePath));

                     var res = await client.PostAsync("http://192.168.1.99:8099/api/Product/upload", form);
                    //  var res = await client.PostAsync("http://localhost:5189/api/Product/upload", form);


                    if (!res.IsSuccessStatusCode) return null;

                    var json = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<UploadResult>(json);
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

            const int MAX_PHOTOS = 8;

            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Images|*.jpg;*.png"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Check total photos after selection
                    if (flpPhotos.Controls.Count + ofd.FileNames.Length > MAX_PHOTOS)
                    {
                        XtraMessageBox.Show(
                            $"You can upload a maximum of {MAX_PHOTOS} photos.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    try
                    {
                        foreach (string file in ofd.FileNames)
                        {
                            string url = await UploadImage(file);

                            if (!string.IsNullOrEmpty(url))
                            {
                                AddImageToGallery(file, url);

                                using (var tempImg = Image.FromFile(file))
                                {
                                    picCustomer.Image = new Bitmap(tempImg);
                                }

                                _uploadedImageUrl = url;
                            }
                            else
                            {
                                XtraMessageBox.Show(
                                    $"Upload Photo {Path.GetFileName(file)} Sucess!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }

                        XtraMessageBox.Show(
                            "Add Photo!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            "Error " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
            private void AddImageToGallerycititenship(string localFilePath, string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel { Size = new Size(100, 100), Margin = new Padding(5), BorderStyle = BorderStyle.FixedSingle, Tag = remoteUrl };
                PictureBox pb = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Dock = DockStyle.Fill };

                using (var img = Image.FromFile(localFilePath))
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton { Text = "X", Size = new Size(20, 20), Location = new Point(75, 0), ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat, Appearance = { ForeColor = Color.Red } };
                btnDel.Click += (s, e) => { flpPhotos.Controls.Remove(pnl); pnl.Dispose(); };

                pnl.Controls.Add(btnDel);
                pnl.Controls.Add(pb);
                btnDel.BringToFront();
                flowLayoutPanel1.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Photo Notfound Gallery: " + ex.Message); }
        }
        private void AddImageToGallery(string localFilePath, string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel { Size = new Size(100, 100), Margin = new Padding(5), BorderStyle = BorderStyle.FixedSingle, Tag = remoteUrl };
                PictureBox pb = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Dock = DockStyle.Fill };

                using (var img = Image.FromFile(localFilePath))
                {
                    pb.Image = new Bitmap(img);
                }

                SimpleButton btnDel = new SimpleButton { Text = "X", Size = new Size(20, 20), Location = new Point(75, 0), ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat, Appearance = { ForeColor = Color.Red } };
                btnDel.Click += (s, e) => { flpPhotos.Controls.Remove(pnl); pnl.Dispose(); };

                pnl.Controls.Add(btnDel);
                pnl.Controls.Add(pb);
                btnDel.BringToFront();
                flpPhotos.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Photo Notfound Gallery: " + ex.Message); }
        }

        private async Task AddImageToGalleryFromUrl(string remoteUrl)
        {
            try
            {
                Panel pnl = new Panel { Size = new Size(100, 100), Margin = new Padding(5), BorderStyle = BorderStyle.FixedSingle, Tag = remoteUrl };
                PictureBox pb = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Dock = DockStyle.Fill };

                Image img = await LoadImageFromUrl(remoteUrl);
                if (img != null)
                {
                    pb.Image = img;
                }

                SimpleButton btnDel = new SimpleButton { Text = "X", Size = new Size(20, 20), Location = new Point(75, 0), ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat, Appearance = { ForeColor = Color.Red } };
                btnDel.Click += (s, e) => { flpPhotos.Controls.Remove(pnl); pnl.Dispose(); };

                pnl.Controls.Add(btnDel);
                pnl.Controls.Add(pb);
                btnDel.BringToFront();
                flpPhotos.Controls.Add(pnl);
            }
            catch (Exception ex) { XtraMessageBox.Show("Error loading gallery item: " + ex.Message); }
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


            return new OutletItemCreate
            {
                Id = _editingId ?? 0,
                FranchiseId = cmbFranchise.SelectedValue != null ? Convert.ToInt32(cmbFranchise.SelectedValue) : 0,
                OutletCode = txtOutletCode.Text.Trim(),
                Province = cboBrand.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Manager = txtManager.Text.Trim(),
                HeadOffice = chkHeadOffice.Checked,
                IsActive = chkActive.Checked,
                VATNumber = txtvatNumber.Text.Trim(),
                ProvinceId = cboBrand.SelectedValue != null ? Convert.ToInt32(cboBrand.SelectedValue) : 0,
                PhotoPath = _uploadedImageUrl,
                OutletName = cmbFranchise.Text.Trim(),
                Position = txtposition.Text.Trim(),
                PhotoPaths = galleryPhotos,
                GrandOpeningDate = dtpOpening.Value
            };
        }

        private bool ValidateForm()
        {
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
            picCustomer.Image = null;
            flpPhotos.Controls.Clear();
            _editingId = null;
            _uploadedImageUrl = "";
            btnAdd.Text = "Add";
        }

        private void btnCancel_Click(object sender, EventArgs e) => ClearForm();

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel File (*.xlsx)|*.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridControlOutlet.ExportToXlsx(sfd.FileName);
                XtraMessageBox.Show("Export success!");
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
        private void gridViewOutlet_MasterRowGetLevelDefaultView(object sender, MasterRowGetLevelDefaultViewEventArgs e)
        {

            if (e.RelationIndex == 0) // បញ្ជាក់ Relation របស់ Photos
            {
                DevExpress.XtraGrid.Views.Tile.TileView tileView = new DevExpress.XtraGrid.Views.Tile.TileView(gridControlOutlet);

                // ១. កំណត់ឱ្យតម្រៀបពីឆ្វេងទៅស្តាំ
                tileView.OptionsTiles.Orientation = Orientation.Horizontal;

                tileView.OptionsTiles.ItemSize = new Size(120, 100);
                tileView.OptionsTiles.RowCount = 1;

                // កំណត់ការតម្រឹម (Alignment)
                tileView.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
                //tileView.OptionsTiles.Padding = new Padding(10, 5, 10, 5); // គម្លាតពីឆ្វេងស្តាំ
                tileView.OptionsTiles.Padding = new Padding(10, 5, 10, 5); // គម្លាតពីឆ្វេងស្តាំ

                RepositoryItemPictureEdit detailPic = new RepositoryItemPictureEdit();
                detailPic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                detailPic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                gridControlOutlet.RepositoryItems.Add(detailPic);
      
                // បង្កើត Column
                DevExpress.XtraGrid.Columns.GridColumn colImage = tileView.Columns.AddField("DetailImage");
                
                colImage.Visible = true;
                colImage.ColumnEdit = detailPic;

               

                // រៀបចំ Template
                tileView.TileTemplate.Clear();
                DevExpress.XtraGrid.Views.Tile.TileViewItemElement element = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
                element.Column = colImage;

                // កំណត់ការបង្ហាញរូបភាពឱ្យពេញកន្លែង
                element.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside;
                element.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            
                element.StretchHorizontal = true;
                element.StretchVertical = true;

                tileView.TileTemplate.Add(element);

                e.DefaultView = tileView;
            }







            //if (e.RelationIndex == 0) // Tab ទី១ (Photos)
            //{
            //    DevExpress.XtraGrid.Views.Tile.TileView tileView = new DevExpress.XtraGrid.Views.Tile.TileView(gridControlOutlet);

            //    tileView.OptionsTiles.Orientation = Orientation.Horizontal;

            //    // កំណត់ទំហំប្រអប់ Item មកសល់ត្រឹម 70x70
            //    tileView.OptionsTiles.ItemSize = new Size(70, 70);
            //    tileView.OptionsTiles.RowCount = 1;

            //    tileView.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            //    tileView.OptionsTiles.Padding = new Padding(4);

            //    // 💡 គន្លឹះបន្ថែម៖ បិទ Border ព័ទ្ធជុំវិញប្រអប់ Tile ដើម្បីកុំឱ្យឃើញប្រអប់ការ៉េលេចចេញមក
            //    tileView.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Default;
            //    tileView.Appearance.ItemNormal.BackColor = Color.Transparent;
            //    tileView.Appearance.ItemNormal.BorderColor = Color.Transparent;
            //    tileView.Appearance.ItemNormal.Options.UseBackColor = true;
            //    tileView.Appearance.ItemNormal.Options.UseBorderColor = true;

            //    // បង្កើត PictureEdit សម្រាប់បង្ហាញរូបភាព
            //    RepositoryItemPictureEdit detailPic = new RepositoryItemPictureEdit();
            //    detailPic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            //    detailPic.NullText = ""; // 💡 ទុកឱ្យទទេ (មិនបាច់ដាក់ពាក្យ No Img នាំឱ្យទើសភ្នែកទេ)
            //    detailPic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder; // បិទ Border របស់ PictureEdit
            //    gridControlOutlet.RepositoryItems.Add(detailPic);

            //    // បង្កើត Column ទៅចាប់យក Property 'DetailImage'
            //    DevExpress.XtraGrid.Columns.GridColumn colImage = tileView.Columns.AddField("DetailImage");
            //    colImage.Visible = true;
            //    colImage.ColumnEdit = detailPic;

            //    // រៀបចំ Template ឱ្យរូបភាពបង្ហាញចំកណ្តាលសមល្មម
            //    tileView.TileTemplate.Clear();
            //    DevExpress.XtraGrid.Views.Tile.TileViewItemElement element = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            //    element.Column = colImage;

            //    // បិទការ Stretch (ពង្រីក) ទាំងសងខាង និងកំណត់ឱ្យ ZoomInside រួញចូលចំកណ្តាល
            //    element.ImageOptions.ImageScaleMode = TileItemImageScaleMode.ZoomInside;
            //    element.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            //    element.StretchHorizontal = false;
            //    element.StretchVertical = false;

            //    tileView.TileTemplate.Add(element);

            //    e.DefaultView = tileView;
            //}
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

        private void gridViewOutlet_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var row = gridViewOutlet.GetRow(e.RowHandle) as OutletItem;
            if (row != null)
            {
                e.ChildList = row.Photos;
            }
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            const int MAX_PHOTOS = 8;

            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Images|*.jpg;*.png"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Check total photos after selection
                    if (flowLayoutPanel1.Controls.Count + ofd.FileNames.Length > MAX_PHOTOS)
                    {
                        XtraMessageBox.Show(
                            $"You can upload a maximum of {MAX_PHOTOS} photos.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    try
                    {
                        foreach (string file in ofd.FileNames)
                        {
                            string url = await UploadImage(file);

                            if (!string.IsNullOrEmpty(url))
                            {
                                AddImageToGallerycititenship(file, url);

                                using (var tempImg = Image.FromFile(file))
                                {
                                    picCustomer.Image = new Bitmap(tempImg);
                                }

                                _uploadedImageUrl = url;
                            }
                            else
                            {
                                XtraMessageBox.Show(
                                    $"Upload Photo {Path.GetFileName(file)} Sucess!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }

                        XtraMessageBox.Show(
                            "Add Photo!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            "Error " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}