using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class Add_Employee : Form
    {
   
        public Add_Employee()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fname.Text) ||
                    string.IsNullOrWhiteSpace(lname.Text) ||
                    string.IsNullOrWhiteSpace(sal.Text) ||
                    string.IsNullOrWhiteSpace(txtid.Text) ||
                    string.IsNullOrWhiteSpace(tbcon.Text) ||
                    string.IsNullOrWhiteSpace(tbpass.Text) ||
                    string.IsNullOrWhiteSpace(tbcpass.Text) ||
                    string.IsNullOrWhiteSpace(tbadd.Text) ||
                    pictureBox1.Image == null)
                {
                    MessageBox.Show("Please fill in all fields and upload an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(sal.Text, out _))
                {
                    MessageBox.Show("Salary must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tbpass.Text != tbcpass.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
                Regex regex = new Regex(passwordPattern);

                if (!regex.IsMatch(tbpass.Text))
                {
                    MessageBox.Show("Password must be at least 8 characters long, contain at least one letter, one number, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] imageBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);
                    imageBytes = memoryStream.ToArray();
                }
               

                
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnString))
                {
                    connection.Open();
                    // Check if the ID is already taken by another employee
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE EmployeeID = @NewID AND EmployeeID != @NewID", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@NewID", txtid.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("This Employee ID already exists. Please enter a unique Employee ID.");
                            return;
                        }
                    }

                    string query = @"INSERT INTO Employees
                                     (EmployeeID, FirstName, LastName, Salary, Contact, Password, HiringDate, Address,EmpImage) 
                                     VALUES 
                                     (@EmployeeID, @FirstName, @LastName, @Salary, @Contact, @Pasword, @HiringDate, @Addres, @EmpImage)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", fname.Text);
                        command.Parameters.AddWithValue("@LastName", lname.Text);
                        command.Parameters.AddWithValue("@Salary", sal.Text);
                        command.Parameters.AddWithValue("@EmployeeID", txtid.Text);
                        command.Parameters.AddWithValue("@Contact", tbcon.Text);
                        command.Parameters.AddWithValue("@Pasword", tbpass.Text);
                        command.Parameters.AddWithValue("@HiringDate", dthir.Value);
                        command.Parameters.AddWithValue("@Addres", tbadd.Text);
                        command.Parameters.AddWithValue("@EmpImage", imageBytes);

                        
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbadd.Text = null;
                        tbcon.Text = null;
                        tbcpass.Text = null;
                        tbpass.Text = null;
                        fname.Text = null;
                        lname.Text = null;
                        sal.Text = null;
                        txtid.Text = null;
                        pictureBox1 = null;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Employs manageEmployeeForm = new Manage_Employs();
            manageEmployeeForm.Show();
            this.Hide();
        }

       

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
