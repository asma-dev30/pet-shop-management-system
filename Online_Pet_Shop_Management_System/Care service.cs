using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Online_Pet_Shop_Management_System
{
    public partial class Care_service : Form
    {
       

        public Care_service()
        {
            InitializeComponent();
        }

        private void Care_service_Load(object sender, EventArgs e)
        {

        }

        private void Request_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnString))
                {
                    connection.Open();

                    // Ensure the date is valid before checking for duplicates
                    if (!DateTime.TryParse(adtp.Text, out DateTime appointmentDate))
                    {
                        MessageBox.Show("Invalid date format. Please enter a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // First check if an appointment already exists for this CustomerID and AppointmentDate
                    string checkQuery = "SELECT COUNT(*) FROM Appointment WHERE CustomerID = @CustomerId AND AppointmentDate = @AppointmentDate";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@CustomerId", id.Text);
                        checkCmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

                        int existingCount = (int)checkCmd.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("You have already requested an appointment for this date.", "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // If no duplicate found, proceed with the insert
                    string insertQuery = "INSERT INTO Appointment (CustomerID, AppointmentDate, RequestStatus) VALUES (@CustomerId, @AppointmentDate, @RequestStatus)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@CustomerId", id.Text);
                        insertCmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                        insertCmd.Parameters.AddWithValue("@RequestStatus", "InProgress");

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment requested successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to request appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DB_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard();
            this.Hide();
            customer_Dashboard.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
