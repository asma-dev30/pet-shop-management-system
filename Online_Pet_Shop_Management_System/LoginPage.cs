using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    
    public partial class LoginPage : Form
    {
        public static string CID = "-1";
       
        private delegate void CreateAdmins();
        public static BindingList<ADMIN> admin;


        public static string ide;
        public LoginPage()
        {
            InitializeComponent();
            createadmin();
        }
        CreateAdmins createadmin = delegate
        {
            admin = new BindingList<ADMIN>
          {
        new ADMIN {  Id = "A1", Password = "AA@123" },
        new ADMIN {  Id = "A2", Password = "aa@123" },
        new ADMIN {  Id = "A3", Password = "Aa@123" }
        };
        };
        private void Login_Click(object sender, EventArgs e)
        {
            if (category.Text.Equals("Admin"))
            {
                string id = userid.Text;
                string password = userpassword.Text;

                // LINQ query to find admin user
                var adminMatch = admin.FirstOrDefault(a => a.Id == id && a.Password == password);

                if (adminMatch != null)
                {
                    // Navigate to admin dashboard
                    Admin_Page administrationDashboard = new Admin_Page();
                    this.Hide();
                    administrationDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Admin ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (category.Text.Equals("Employee"))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(DbConfig.ConnString);

                    conn.Open();

                    string query = "SELECT * FROM Employees";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    int f = 0;
                    while (sdr.Read())
                    {
                        String id = sdr["EmployeeID"].ToString();
                        string pa = sdr["Password"].ToString();
                        if (userid.Text == id && userpassword.Text == pa)
                        {
                            f = 1;
                            break;
                        }
                    }
                    if (f == 1)
                    {
                        Employee_Dashboard adb = new Employee_Dashboard();
                        this.Hide();
                        adb.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Employee ID or Password.\nPlease enter the correct Employee ID or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            if (category.Text.Equals("Customer"))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(DbConfig.ConnString);

                    conn.Open();

                    string query = "SELECT * FROM Customer";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    int f = 0;
                   
                    while (sdr.Read())
                    {
                        String id = sdr["CustomerID"].ToString();
                        CID = sdr["CustomerID"].ToString();
                        string pa = sdr["Password"].ToString();
                        if (userid.Text == id && userpassword.Text == pa)
                        {
                            f = 1;
                            ide = id;
                            break;
                        }
                    }
                    if (f == 1)
                    {
                        Customer_Dashboard adb = new Customer_Dashboard(ide);
                        this.Hide();
                        adb.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Customer ID or Password.\nPlease enter the correct Customer ID or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            Customer_Signup signup = new Customer_Signup(); 
            this.Hide();
            signup.Show();
        }
    }
}
