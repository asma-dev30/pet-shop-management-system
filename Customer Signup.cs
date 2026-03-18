using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Online_Pet_Shop_Management_System
{
    public partial class Customer_Signup : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";
        public Customer_Signup()
        {
            InitializeComponent();
            pb.BackColor = Color.White;
        }

        private void LP_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
        }

        private void create_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fname.Text) ||
                    string.IsNullOrWhiteSpace(lname.Text) ||
                    string.IsNullOrWhiteSpace(id.Text) ||
                    string.IsNullOrWhiteSpace(contact.Text) ||
                    string.IsNullOrWhiteSpace(Add.Text) ||
                    string.IsNullOrWhiteSpace(pass.Text) ||
                    string.IsNullOrWhiteSpace(cpass.Text) ||
                 
                    pb.Image == null)
                {
                    MessageBox.Show("Please fill in all fields and upload an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (pass.Text != cpass.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
                Regex regex = new Regex(passwordPattern);

                if (!regex.IsMatch(pass.Text))
                {
                    MessageBox.Show("Password must be at least 8 characters long, contain at least one letter, one number, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] imageBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    pb.Image.Save(memoryStream, pb.Image.RawFormat);
                    imageBytes = memoryStream.ToArray();
                }


                
                using (SqlConnection connection = new SqlConnection(cons))
                {
                    string query = @"INSERT INTO Customer
                                     (CustomerID,First_name, Last_name,Contact,Address,Password,Picture) 
                                     VALUES 
                                     (@CustomerId, @first_name, @last_name, @contact, @Addres, @Pasword, @picture)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", id.Text);
                        command.Parameters.AddWithValue("@first_name", fname.Text);
                        command.Parameters.AddWithValue("@last_name", lname.Text);
                        command.Parameters.AddWithValue("@contact", contact.Text);
                        command.Parameters.AddWithValue("@Addres", Add.Text);
                        command.Parameters.AddWithValue("@Pasword", pass.Text);
                        command.Parameters.AddWithValue("@picture", imageBytes);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();     
        }
    }
}
