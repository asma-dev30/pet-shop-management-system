using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Online_Pet_Shop_Management_System
{
    public partial class Delete_Or_Update_Employee : Form
    {

       
        


        public Delete_Or_Update_Employee()
        {
            InitializeComponent();
            dataGridView1.DataSource = Employee.emp;
            LoadEmployeeData();
            pb.BackColor = Color.White;
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    Employee.emp.Clear();
                    conn.Open();
                    string query = "SELECT * FROM Employees";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            // Safely handle NULL CoverImage
                            Image img = null;
                            if (!(sdr["EmpImage"] is DBNull))
                            {
                                byte[] imgBytes = (byte[])sdr["EmpImage"];
                                if (imgBytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imgBytes))
                                    {
                                        Image temp = Image.FromStream(ms);
                                        img = new Bitmap(temp);  // Create a copy to avoid stream locking issues
                                    }
                                }
                            }


                            string id = sdr["EmployeeID"].ToString();
                            string fn = sdr["FirstName"].ToString();
                            string ln = sdr["LastName"].ToString();
                            string s = sdr["Salary"].ToString();
                            string c = sdr["Contact"].ToString();
                            string p = sdr["Password"].ToString();
                            string hd = sdr["HiringDate"].ToString();
                            string ad = sdr["Address"].ToString();

                            Employee.emp.Add(new Employee
                            {
                                EmployeeID = id,
                                FirstName = fn,
                                LastName = ln,
                                Salary = s,
                                Contact = c,
                                Password = p,  
                                HiringDate = hd,
                                Address = ad,
                                EmpImage = img,
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}");
            }
        }

        private void Delete_Or_Update_Employee_Load(object sender, EventArgs e)
        {
            tbi.Enabled = false;
            tbn.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Employee.emp.Clear(); // Clear the binding list to refresh
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    conn.Open();
                    string query = cbn.Checked
                        ? "SELECT * FROM Employees WHERE FirstName LIKE @FirstName"
                        : "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (cbn.Checked)
                            cmd.Parameters.AddWithValue("@FirstName", $"%{tbn.Text}%");
                        else
                            cmd.Parameters.AddWithValue("@EmployeeID", tbi.Text);

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                Image img = null;
                                if (!(sdr["EmpImage"] is DBNull))
                                {
                                    byte[] imgBytes = (byte[])sdr["EmpImage"];
                                    if (imgBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imgBytes))
                                        {
                                            img = new Bitmap(Image.FromStream(ms));
                                        }
                                    }
                                }

                                Employee.emp.Add(new Employee
                                {
                                    EmployeeID = sdr["EmployeeID"].ToString(),
                                    FirstName = sdr["FirstName"].ToString(),
                                    LastName = sdr["LastName"].ToString(),
                                    Salary = sdr["Salary"].ToString(),
                                    Contact = sdr["Contact"].ToString(),
                                    Password = sdr["Password"].ToString(),
                                    HiringDate = sdr["HiringDate"].ToString(),
                                    Address = sdr["Address"].ToString(),
                                    EmpImage = img
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching records: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.Text))
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    conn.Open();

                    // Check if the ID is already taken by another employee
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE EmployeeID = @NewID AND EmployeeID != @NewID", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@NewID", id.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("This Employee ID already exists. Please enter a unique Employee ID.");
                            return;
                        }
                    }


                    string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary, Contact = @Contact, HiringDate = @HiringDate, Password = @Password, Address = @Address, EmpImage = @EmpImage WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", fname.Text);
                        cmd.Parameters.AddWithValue("@LastName", lname.Text);
                        cmd.Parameters.AddWithValue("@Salary", salery.Text);
                        cmd.Parameters.AddWithValue("@Contact", con.Text);
                        cmd.Parameters.AddWithValue("@HiringDate", dtp.Value);
                        cmd.Parameters.AddWithValue("@Password", pas.Text);
                        cmd.Parameters.AddWithValue("@Address", ad.Text);
                        cmd.Parameters.AddWithValue("@EmployeeID", id.Text);

                        byte[] imageBytes;

                        if (pb.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Clone the image into a bitmap to avoid stream or resource locks
                                using (Bitmap bmp = new Bitmap(pb.Image))
                                {
                                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Use a fixed format
                                }
                                imageBytes = ms.ToArray();
                            }
                        }
                        else
                        {
                            // Optional: set to DBNull or empty array if image is missing
                            imageBytes = new byte[0];
                        }

                        cmd.Parameters.AddWithValue("@EmpImage", imageBytes);


                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                            LoadEmployeeData(); // Refresh the grid
                        }
                        else
                        {
                            MessageBox.Show("No record found to update.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.Text))
                {
                    MessageBox.Show("Please select a Employee to delete.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", id.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                                LoadEmployeeData(); // Refresh the grid
                            }
                            else
                            {
                                MessageBox.Show("No Employee found to delete.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Employee: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Page adminDashboard = new Admin_Page();
            adminDashboard.Show();
            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbi.Checked)
            {
                cbn.Checked = false; // Uncheck the other box
                tbi.Enabled = true;
                tbn.Enabled = false;
            }
            else
            {
                tbi.Enabled = false;
                tbn.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbn.Checked)
            {
                cbi.Checked = false; // Uncheck the other box
                tbn.Enabled = true;
                tbi.Enabled = false;
            }
            else
            {
                tbn.Enabled = false;
                tbi.Enabled = false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    fname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                    lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    salery.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();
                    con.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString();
                    pas.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString();

                    if (DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells[6].Value?.ToString(), out DateTime date))
                    {
                        dtp.Value = date;
                    }
                    else
                    {
                        dtp.Value = DateTime.Now;
                    }

                    ad.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value?.ToString();

                    using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                    {
                        conn.Open();
                        string query = "SELECT EmpImage FROM Employees WHERE EmployeeID = @EmployeeID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", id.Text);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (!(reader["EmpImage"] is DBNull))
                                    {
                                        byte[] imageBytes = (byte[])reader["EmpImage"];
                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                            pb.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pb.Image = null; // No image found
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting record: {ex.Message}");
                }
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
    }
}



