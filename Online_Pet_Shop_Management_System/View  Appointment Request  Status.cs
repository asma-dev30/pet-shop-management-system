using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class View__Appointment_Request__Status : Form
    {
        
        
        public View__Appointment_Request__Status()
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
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DB_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard();
            this.Hide();
            customer_Dashboard.Show();
        }

        private void View__Appointment_Request__Status_Load(object sender, EventArgs e)
        {

        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Appointment WHERE RequestStatus = 'Confirmed'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dgv.Rows.Clear(); 
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
                MessageBox.Show($"Error loading confirmed appointments: {ex.Message}");
            }
        }
    }
}
