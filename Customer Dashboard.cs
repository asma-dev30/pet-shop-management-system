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
    public partial class Customer_Dashboard : Form
    {
        string ide;
        public Customer_Dashboard()
        {
            InitializeComponent();
        }
        public Customer_Dashboard(String id)
        {
            InitializeComponent();
            ide= id;

        }

        private void btn_viewpets_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Pets_By_Customers viewPets = new View_Pets_By_Customers();
            viewPets.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Care_service petCareService = new Care_service();
            this.Hide();
            petCareService.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Customer_Account_Mangement accountManagement = new Customer_Account_Mangement(ide);
            this.Hide();
            accountManagement.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customer_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void rqueststats_Click(object sender, EventArgs e)
        {
            View__Appointment_Request__Status view__Appointment_Request__Status = new View__Appointment_Request__Status();
            this.Hide();
            view__Appointment_Request__Status.Show();
            
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
        }

        private void btnPetsBought_Click(object sender, EventArgs e)
        {
            Pets_Bought pb = new Pets_Bought();
            this.Hide();
            pb.Show();
        }
    }
}
