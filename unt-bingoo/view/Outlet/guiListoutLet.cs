using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Class;
using unt_bingoo.Controller;

namespace unt_bingoo.view.Outlet
{
    public partial class guiListoutLet : DevExpress.XtraEditors.XtraForm
    {
        private APIsController _api;
        private int _id;
        public guiListoutLet(int id)
        {
            InitializeComponent();
            this._id = id;
        }

        private async void guiListoutLet_Load(object sender, EventArgs e)
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

             
                await loadingOutlet(this._id);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task loadingOutlet(int id)
        {
            try
            {
                
                var data = await _api.GetAsync<OutletResponse>($"api/outlet/{id}");

                if (data != null)
                {
                   
                    txtOutletCode.Text = data.outletCode;
                    txtOutletName.Text = data.outletName;
                    txtProvince.Text = data.province;
                    txtPhone.Text = data.phone;
                    txtManager.Text = data.manager;
                    txtVat.Text = data.vatNumber;
                    chkIsActive.Checked = data.isActive;

          
                    if (!string.IsNullOrEmpty(data.photoPath))
                    {
                        await LoadImageAsync(data.photoPath, pbMainPhoto);
                    }

              
                    flpGallery.Controls.Clear(); 
                    if (data.photos != null)
                    {
                        foreach (var imgUrl in data.photos)
                        {
                            PictureBox thumb = new PictureBox
                            {
                                Size = new Size(100, 80),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                BorderStyle = BorderStyle.FixedSingle,
                                Cursor = Cursors.Hand,
                                Margin = new Padding(5)
                            };

                           
                            thumb.Click += async (s, e) => await LoadImageAsync(imgUrl, pbMainPhoto);

                            await LoadImageAsync(imgUrl, thumb);
                            flpGallery.Controls.Add(thumb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading details: " + ex.Message);
            }
        }

 
        private async Task LoadImageAsync(string url, PictureBox pb)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] imageBytes = await client.DownloadDataTaskAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
           
                pb.Image = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}