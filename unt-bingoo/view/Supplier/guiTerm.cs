using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Supplier
{
    public partial class guiTerm : DevExpress.XtraEditors.XtraForm
    {
        private readonly APIsController _api = new APIsController();
        private ApplicationFramework App = new ApplicationFramework();

        private int _id = 0;

        public guiTerm()
        {
            InitializeComponent();
            dgvTerm.AutoGenerateColumns = false;
        }

    
        private async Task LoadData()
        {
            var list = await _api.GetAsync<List<TermDayClass>>("api/termday");
            if (list == null) list = new List<TermDayClass>();

            foreach (var item in list)
                if (string.IsNullOrEmpty(item.TermDay))
                    item.TermDay = item.CountDay + " Day";

            dgvTerm.AutoGenerateColumns = false;
            dgvTerm.Columns["Id"].DataPropertyName = "Id";
            dgvTerm.Columns["TermDay"].DataPropertyName = "TermDay";
            dgvTerm.Columns["CountDay"].DataPropertyName = "CountDay";

            dgvTerm.DataSource = null;
            dgvTerm.DataSource = list;
            btnClose.Visible = false;
        }

        // ================= SAVE (Add / Update) =================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCountDay.Text))
                {
                    MessageBox.Show("Please enter Count Day");
                    return;
                }

                var payload = new TermDayClass
                {
                    CountDay = Convert.ToInt32(txtCountDay.Text)
                };

                bool ok;

                if (_id == 0)
                {
                    // Insert -> POST
                    ok = await _api.PostAsync("api/termday", payload);
                }
                else
                {
                    // Update -> PUT
                    payload.Id = _id;

                    try
                    {
                        ok = await _api.PutAsync($"api/termday/{_id}", payload);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }

                if (!ok) return;   // error បង្ហាញ​ក្នុង controller រួច

                MessageBox.Show(_id == 0 ? "Saved Successfully" : "Updated Successfully");

                _id = 0;
                txtCountDay.Clear();
                btnSave.Text = "Save";

                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= EDIT / DELETE (grid click) =================
        private async void dgvTerm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvTerm.Columns[e.ColumnIndex].Name == "Edit")
                {
                    DataGridViewRow row = dgvTerm.Rows[e.RowIndex];

                    _id = Convert.ToInt32(row.Cells["Id"].Value);
                    txtCountDay.Text = row.Cells["CountDay"].Value?.ToString();

                    btnClose.Visible = true;
                    btnSave.Text = "Update";
                }

                if (dgvTerm.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DataGridViewRow row = dgvTerm.Rows[e.RowIndex];
                    int id = Convert.ToInt32(row.Cells["Id"].Value);

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this record?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bool ok = await _api.DeleteAsync($"api/termday/{id}");
                            if (!ok) return;

                            await LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private async void guiTerm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            _id = 0;
            txtCountDay.Clear();
            await LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCountDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            App.KeyPress(sender, e, ApplicationFramework.TypeKeyPress.Format_Number);
        }
    }

    public class TermDayClass
    {
        public int Id { get; set; }
        public string TermDay { get; set; }
        public int CountDay { get; set; }
    }
}