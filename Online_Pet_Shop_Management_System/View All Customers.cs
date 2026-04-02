using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class View_All_Customers : Form
    {
        

        public View_All_Customers()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Customer";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dgv.Rows.Clear(); // Clear the DataGridView before populating

                        while (sdr.Read())
                        {
                            byte[] imageBytes = sdr["Picture"] as byte[];

                            dgv.Rows.Add(
                                sdr["CustomerID"].ToString(),
                                sdr["First_name"].ToString(),
                                sdr["Last_name"].ToString(),
                                sdr["Contact"].ToString(),
                                sdr["Address"].ToString(),
                                sdr["Password"].ToString(),
                                imageBytes != null ? "Image" : "No Image" // Mark if there's an image or not
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Customer data: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Customers manageCustomerForm = new Manage_Customers();
            manageCustomerForm.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                var customerId = dgv.SelectedRows[0].Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Invalid Customer ID selected.");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                    {
                        conn.Open();

                        // Delete associated feedback first (if any)
                        string feedbackQuery = "DELETE FROM Feedback WHERE CustomerID = @CustomerId";
                        using (SqlCommand feedbackCmd = new SqlCommand(feedbackQuery, conn))
                        {
                            feedbackCmd.Parameters.AddWithValue("@CustomerId", customerId);
                            feedbackCmd.ExecuteNonQuery();
                        }
                        string ApoointmentQuery = "DELETE FROM Appointment WHERE CustomerID = @CustomerId";
                        using (SqlCommand AppiontmentCmd = new SqlCommand(ApoointmentQuery, conn))
                        {
                            AppiontmentCmd.Parameters.AddWithValue("@CustomerId", customerId);
                            AppiontmentCmd.ExecuteNonQuery();
                        }

                        // Delete the customer
                        string customerQuery = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
                        using (SqlCommand customerCmd = new SqlCommand(customerQuery, conn))
                        {
                            customerCmd.Parameters.AddWithValue("@CustomerId", customerId);

                            int rowsAffected = customerCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer deleted successfully.");
                                LoadCustomerData();
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the provided ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
