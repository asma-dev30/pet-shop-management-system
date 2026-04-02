using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class View_Services_Request : Form
    {
       

        public View_Services_Request()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Appointment";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dgv.Rows.Clear(); // Clear the DataGridView before populating
                        while (sdr.Read())
                        {
                            dgv.Rows.Add(
                                   sdr["CustomerID"].ToString(),
                                   sdr["AppointmentDate"].ToString(),
                                   sdr["RequestStatus"].ToString()
                                    );
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading  data: {ex.Message}");
            }
        }
        private void View_Services_Request_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee_Dashboard employee_Dashboard = new Employee_Dashboard();
            this.Hide();
            employee_Dashboard.Show();  
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Database connection
                
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnString))
                {
                    string query = "UPDATE Appointment SET RequestStatus = @RequestStatus WHERE CustomerID = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        if (dgv.SelectedRows.Count > 0)
                        {
                            
                            string customerId = dgv.SelectedRows[0].Cells[0].Value.ToString();

                            command.Parameters.AddWithValue("@RequestStatus", "Confirmed");
                            command.Parameters.AddWithValue("@CustomerId", customerId);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment Confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData(); 
                            }
                            else
                            {
                                MessageBox.Show("No updated. Please check the selected row.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a row to confirm the appointment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ignore_Click(object sender, EventArgs e)
        {
            try
            {
                // Database connection
                
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnString))
                {
                    string query = "UPDATE Appointment SET RequestStatus = @RequestStatus WHERE CustomerID = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        if (dgv.SelectedRows.Count > 0)
                        {

                            string customerId = dgv.SelectedRows[0].Cells[0].Value.ToString();

                            command.Parameters.AddWithValue("@RequestStatus", "Rejected");
                            command.Parameters.AddWithValue("@CustomerId", customerId);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Appointment status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("No records were updated. Please check the selected row.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a row to confirm the appointment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
