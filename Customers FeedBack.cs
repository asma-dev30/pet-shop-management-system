using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class Customers_FeedBack : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";

        public Customers_FeedBack()
        {
            InitializeComponent();
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cons))
                {
                    conn.Open();
                    string query = "SELECT * FROM Feedback";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dgv.Rows.Clear(); // Clear the DataGridView before populating
                        while (sdr.Read())
                        {
                            dgv.Rows.Add(
                                sdr["CustomerID"].ToString(),
                              
                                sdr["Message"].ToString()

                            );
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}");
            }
        }
        private void Readed_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cons))
            {
                conn.Open();
                string query = "DELETE FROM Feedback WHERE CustomerID = @CustomerId";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", ID.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Message deleted successfully.");
                        LoadEmployeeData(); // Refresh the grid
                    }
                    else
                    {
                        MessageBox.Show("No Message found to delete.");
                    }
                }
                conn.Close();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ID.Text = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    Messagetb.Text = dgv.Rows[e.RowIndex].Cells[1].Value?.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting record: {ex.Message}");
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void DB_Click(object sender, EventArgs e)
        {
            Manage_Customers manage_Customers  = new Manage_Customers();
            this.Hide();
            manage_Customers.Show();
        }

        private void Customers_FeedBack_Load(object sender, EventArgs e)
        {

        }
    }
}
