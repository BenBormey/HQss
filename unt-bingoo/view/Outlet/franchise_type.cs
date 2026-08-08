using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using unt_bingoo.Controller;
using unt_bingoo.Class;

namespace unt_bingoo.view.Outlet
{
    public partial class franchise_type : DevExpress.XtraEditors.XtraForm
    {
        private  APIsController _api;
        private int _editingId = 0; // 0 = Add New, > 0 = Update

        public franchise_type()
        {
            InitializeComponent();
            _api = APIGlobals.Api ?? new APIsController();
        }

        private async void franchise_type_Load(object sender, EventArgs e)
        {

            _api  = APIGlobals.Api; ;
            ClearForm();
            await LoadFranchiseTypes();
        }


        private async Task LoadFranchiseTypes()
        {
            try
            {
                btnAdd.Enabled = false;

               
                var data = await _api.GetAsync<List<FranchiseTypeItem>>("api/FranchiseType");

                if (data != null)
                {
                    gridControl1.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

       
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await SaveFranchiseType();
        }

        private async Task SaveFranchiseType()
        {
            try
            {
                btnAdd.Enabled = false;

                // Validation ឆែកមើលប្រអប់បញ្ចូលទិន្នន័យ
                if (string.IsNullOrWhiteSpace(txtTypeName.Text))
                {
                    MessageBox.Show("Please enter franchise type name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTypeName.Focus();
                    return;
                }

                // បង្កើត Model Object ឱ្យត្រូវនឹង API structure 
                var model = new
                {
                    id = _editingId,
                    typeName = txtTypeName.Text.Trim(),
                    description = txtDescription.Text?.Trim(),
                    isActive = chkActive.Checked
                };

                bool result = false;

                if (_editingId == 0) // ករណីបង្កើតថ្មី (POST)
                {
                    result = await _api.PostAsync("api/FranchiseType", model);
                }
                else // ករណីកែប្រែទិន្នន័យ (PUT)
                {
                    result = await _api.PutAsync($"api/FranchiseType/{_editingId}", model);
                }

                if (result)
                {
                    MessageBox.Show("Franchise Type saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    await LoadFranchiseTypes();
                }
                else
                {
                    MessageBox.Show("Failed to save franchise type!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        // ៣. ព្រឹត្តិការណ៍ចុចប៊ូតុង Actions (Edit/Delete) នៅក្នុង GridView
        private async void btnActionRepository_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as FranchiseTypeItem;
            if (selectedRow == null) return;

            if (e.Button.Caption == "Edit")
            {
                _editingId = selectedRow.Id;
                txtTypeName.Text = selectedRow.TypeName;
                txtDescription.Text = selectedRow.Description;
                chkActive.Checked = selectedRow.IsActive;
                btnAdd.Text = "Update";
            }
            else if (e.Button.Caption == "Delete")
            {
                if (MessageBox.Show($"Do you want to delete '{selectedRow.TypeName}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool isDeleted = await _api.DeleteAsync($"api/FranchiseType/{selectedRow.Id}");
                        if (isDeleted)
                        {
                            MessageBox.Show("Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (_editingId == selectedRow.Id) ClearForm();
                            await LoadFranchiseTypes();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete franchise type!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void ClearForm()
        {
            _editingId = 0;
            txtTypeName.Text = "";
            txtDescription.Text = "";
            chkActive.Checked = true;
            btnAdd.Text = "Save";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel changes?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private async void btnActionRepository_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
                // 1. Get the row data
                var selectedRow = gridView1.GetFocusedRow() as FranchiseTypeItem;
                if (selectedRow == null) return;
             
                    if (MessageBox.Show($"Do you want to delete '{selectedRow.TypeName}'?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            // 3. Call your DELETE API
                            // Using the URL structure provided: api/FranchiseType/{id}
                            bool isDeleted = await _api.DeleteAsync($"api/FranchiseType/{selectedRow.Id}");

                            if (isDeleted)
                            {
                                MessageBox.Show("Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Reset form if the deleted item was currently being edited
                                if (_editingId == selectedRow.Id) ClearForm();

                            // Refresh the grid
                            await LoadFranchiseTypes();

                        }
                            else
                            {
                                MessageBox.Show("Failed to delete franchise type!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                
            
        }

        private void repositoryItemButtonEdit1_ButtonClick(
     object sender,
     DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var selectedRow = gridView1.GetFocusedRow() as FranchiseTypeItem;

            if (selectedRow == null)
                return;

            _editingId = selectedRow.Id;

            txtTypeName.Text = selectedRow.TypeName;
            txtDescription.Text = selectedRow.Description;
            chkActive.Checked = selectedRow.IsActive;

            btnAdd.Text = "Update";

            txtTypeName.Focus();
        }

        public int _editid = 0;

        private void flowLayoutButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel changes?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }
    }
}