using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Online_Pet_Shop_Management_System
{
    public partial class Customer_Account_Mangement : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";
        
       
        public Customer_Account_Mangement()
        {
            InitializeComponent();
        }
        public Customer_Account_Mangement(String id)
        {
            InitializeComponent();
             
            LoadCustomerData(id);
        }
        private void LoadCustomerData(String cid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cons))
                {
                    conn.Open();
                    string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", LoginPage.ide);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                fname.Text = reader["First_name"].ToString();
                                lname.Text = reader["Last_name"].ToString();
                                id.Text = reader["CustomerID"].ToString();
                                contact.Text = reader["Contact"].ToString();
                                Add.Text = reader["Address"].ToString();
                                pass.Text = reader["Password"].ToString();
                               

                                if (reader["Picture"] != DBNull.Value)
                                {
                                    byte[] imageBytes = (byte[])reader["Picture"];
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pb.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Guest data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guest data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Customer_Account_Mangement_Load(object sender, EventArgs e)
        {
            // Add any initialization logic if required
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_Dashboard  c=new Customer_Dashboard();
            this.Close();
            c.ShowDialog();
        }
    }
}










//cmd.Parameters.AddWithValue("@CustomerId", id.Text);
//cmd.Parameters.AddWithValue("@first_name", fname.Text);
//cmd.Parameters.AddWithValue("@last_name", lname.Text);
//cmd.Parameters.AddWithValue("@contact", contact.Text);
//cmd.Parameters.AddWithValue("@Addres", Add.Text);
//cmd.Parameters.AddWithValue("@Pasword", pass.Text); string query = "UPDATE Customer SET first_name = @first_name, last_name = @last_name, contact = @contact, Pasword = @Pasword, Addres = @Addres, picture = @picture WHERE CustomerId = @CustomerId";
