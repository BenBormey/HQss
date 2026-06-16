using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using unt_bingoo.Declares;
using unt_bingoo.Frameworks;

namespace unt_bingoo.view.Supplier
{
    public partial class guiTerm : DevExpress.XtraEditors.XtraForm
    {
        private DatabaseFramework Data = new DatabaseFramework();
        private ApplicationFramework App = new ApplicationFramework();

        public guiTerm()
        {
            InitializeComponent();
            dgvTerm.AutoGenerateColumns = false;
            Initialized.LoadingInitialized(Data, App);


        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(
                    Data.ConnectionString(
                    Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();

                    string query = @"
            SELECT
                Id,
                CAST(CountDay AS VARCHAR(10)) + ' Day' AS TermDay,
              CountDay
            FROM [DBJuJuBi].[dbo].[tblTermDay]
            ORDER BY Id DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<TermDayClass> list = new List<TermDayClass>();

                            while (reader.Read())
                            {
                                list.Add(new TermDayClass
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TermDay = reader["TermDay"].ToString(),
                                    CountDay =Convert.ToInt32(reader["CountDay"])
                                });
                            }



                            dgvTerm.AutoGenerateColumns = false;

                            dgvTerm.Columns["Id"].DataPropertyName = "Id";
                            dgvTerm.Columns["TermDay"].DataPropertyName = "TermDay";
                            dgvTerm.Columns["CountDay"].DataPropertyName = "CountDay";

                            dgvTerm.DataSource = null;
                            dgvTerm.DataSource = list;
                            btnClose.Visible = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "SQL Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "System Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCountDay.Text))
                {
                    MessageBox.Show("Please enter Count Day");
                    return;
                }

                using (SqlConnection conn =
                    new SqlConnection(Data.ConnectionString(
                    Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();

                    string query = "";

                    if (_id == 0)
                    {
                        // Insert
                        query = @"
            INSERT INTO [DBJuJuBi].[dbo].[tblTermDay]
            (
                CountDay
            )
            VALUES
            (
                @CountDay
            )";
                    }
                    else
                    {
                        // Update
                        query = @"
            UPDATE [DBJuJuBi].[dbo].[tblTermDay]
            SET CountDay = @CountDay
            WHERE Id = @Id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@CountDay",
                            Convert.ToInt32(txtCountDay.Text));

                        if (_id != 0)
                        {
                            cmd.Parameters.AddWithValue("@Id", _id);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    _id == 0
                        ? "Saved Successfully"
                        : "Updated Successfully");

                _id = 0;
                txtCountDay.Clear();
                btnSave.Text = "Save";

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            _id = 0;
            this.LoadData();

            txtCountDay.Clear();

        }

        private void guiTerm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private int _id = 0;

        private void dgvTerm_CellClick(object sender, DataGridViewCellEventArgs e)
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
                            using (SqlConnection conn =
                    new SqlConnection(Data.ConnectionString(
                    Initialized.GetConnectionType(Data, App))))
                {
                    conn.Open();

                    string query = $@"
delete from  [DBJuJuBi].[dbo].[tblTermDay] where Id ={id} 

                   ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                        LoadData();   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class TermDayClass
    {
        public int Id { get; set; }
        public string TermDay { get; set; }
        public int CountDay { get; set; }
    }
}