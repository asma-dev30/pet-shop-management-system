using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    
    public partial class View_Employs : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";
      
        public View_Employs()
        {
            InitializeComponent();
            LoadEmployeeData();
            dataGridView1.DataSource = Employee.emp;
        }


        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cons))
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

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Employs manageEmploysForm = new Manage_Employs();
            this.Hide();
            manageEmploysForm.Show();
        }
        
           
        

        private void Exit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        
    }
}
