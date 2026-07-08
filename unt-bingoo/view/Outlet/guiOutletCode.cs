using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Outlet
{
    public partial class guiOutletCode : DevExpress.XtraEditors.XtraForm
    {
        private string DatabaseName;
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();
        public string editid = null;

        public guiOutletCode()
        {
            InitializeComponent();
            this.LoadingInitialized();

        
        }

        private void LoadingInitialized()
        {
            Initialized.LoadingInitialized(Data, App);
            DatabaseName = string.Format("{0}{1}", Data.PrefixDatabase, Data.DatabaseName);
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();
                    string query = @"select 

Id,OutletCode,IsActive

from [DBJuJuBi].dbo.OutletCode

order by OutletCode desc;";

 
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<OutletcodeClas> list = new List<OutletcodeClas>();
                            while (reader.Read())
                            {
                                list.Add(new OutletcodeClas
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    OutletCode = reader["OutletCode"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                });
                            }

                            grdOutlet.DataSource = list;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutletCode.Text))
            {
                XtraMessageBox.Show(
                    "Please enter the Outlet Code!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtOutletCode.Focus();
                return;
            }

            string finalOutletCode = txtOutletCode.Text.Trim();
            bool isActive = chkstatus.Checked;

            using (SqlConnection conn = new SqlConnection(
                Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
            {
                conn.Open();

                string checkQuery;

                if (string.IsNullOrEmpty(editid))
                {
                    // Add New
                    checkQuery = @"
                SELECT COUNT(*)
                FROM [DBJuJuBi].[dbo].[OutletCode]
                WHERE UPPER(OutletCode) = UPPER(@OutletCode)";
                }
                else
                {
                    // Edit
                    checkQuery = @"
                SELECT COUNT(*)
                FROM [DBJuJuBi].[dbo].[OutletCode]
                WHERE UPPER(OutletCode) = UPPER(@OutletCode)
                AND Id <> @Id";
                }

                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OutletCode", finalOutletCode);

                    if (!string.IsNullOrEmpty(editid))
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(editid));
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        XtraMessageBox.Show(
                            "Outlet Code already exists!",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtOutletCode.Focus();
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(editid))
            {
                string insertQuery = @"
            INSERT INTO [DBJuJuBi].[dbo].[OutletCode]
            (
                OutletCode,
                IsActive
            )
            VALUES
            (
                @OutletCode,
                @IsActive
            )";

                ExecuteNonQuery(insertQuery, new Dictionary<string, object>
        {
            { "@OutletCode", finalOutletCode },
            { "@IsActive", isActive }
        });

                XtraMessageBox.Show(
                    "Saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                string updateQuery = @"
            UPDATE [DBJuJuBi].[dbo].[OutletCode]
            SET OutletCode = @OutletCode,
                IsActive = @IsActive
            WHERE Id = @Id";

                ExecuteNonQuery(updateQuery, new Dictionary<string, object>
        {
            { "@OutletCode", finalOutletCode },
            { "@IsActive", isActive },
            { "@Id", Convert.ToInt32(editid) }
        });

                XtraMessageBox.Show(
                    "Record updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                editid = null;
                btnSave.Text = "SAVE";
            }

            txtOutletCode.Clear();
            chkstatus.Checked = true;

            LoadData();
            loadingidtextBox();
        }

        private void btnmainUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
         
            var view = grdOutlet.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

      
            if (view != null && view.GetFocusedRowCellValue("Id") != null)
            {
             
                editid = view.GetFocusedRowCellValue("Id").ToString();

                string rawCode = view.GetFocusedRowCellValue("OutletCode").ToString();
                bool v = Convert.ToBoolean(view.GetFocusedRowCellValue("IsActive"));
                chkstatus.Checked = v;
                txtOutletCode.Text = rawCode;

               
                btnSave.Text = "UPDATE";
                btnClear.Visible = true;
                txtOutletCode.Focus();   
            }
            else
            {
                MessageBox.Show("Please select a valid record to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnmainDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // 1. Get the GridView through the GridControl
            // Replace 'grdOutlet' with the actual name of your GridControl component
            var view = grdOutlet.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view == null) return;

            // 2. Safely get the ID from the focused row
            object idObj = view.GetFocusedRowCellValue("Id");

            if (idObj == null)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            editid = idObj.ToString();

            // 3. Confirm and Delete
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM [DBJuJuBi].[dbo].[OutletCode] WHERE Id = @Id";
                    ExecuteNonQuery(query, new Dictionary<string, object> { { "@Id", editid } });

                    // Refresh and cleanup
                    LoadData();
                    txtOutletCode.Clear();
                    editid = null;

                    MessageBox.Show("Record deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }
        }

        private void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guiOutletCode_Load(object sender, EventArgs e)
        {
            this.LoadData();
            //loadingidtextBox();
        }
        public void loadingidtextBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString(Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();
                   
                    string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [DBJuJuBi].[dbo].[OutletCode]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int nextId = Convert.ToInt32(cmd.ExecuteScalar());

                  
                        txtOutletCode.Text = string.Format("UNT-{0}", nextId);

                     
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating ID: " + ex.Message);
            }
        }

        // Ensure you hook this up to your GridView's RowCellClick or FocusedRowChanged event
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editid = null;

            txtOutletCode.Clear();

            
            btnSave.Text = "SAVE";


            txtOutletCode.Focus();
            //this.loadingidtextBox();
            //this.Close();
            btnClear.Visible = false;


        }
      

        private void gvOutlet_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.LightYellow;
                }
                else
                {
            
                    e.Appearance.BackColor = Color.LightCyan;   
                }
            }
        }
    }
}