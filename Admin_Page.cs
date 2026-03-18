using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class Admin_Page : Form
    {
        public Admin_Page()
        {
            InitializeComponent();
        }
        private void Admin_Page_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Customers customersDashboard = new Manage_Customers();
            customersDashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Pets_Data petsDashboard = new View_Pets_Data();
            petsDashboard.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empmang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Employs employeesDashboard = new Manage_Employs();
            employeesDashboard.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
        }
    }
}

