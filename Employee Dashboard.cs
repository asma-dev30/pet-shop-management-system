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
    public partial class Employee_Dashboard : Form
    {
        public Employee_Dashboard()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Update_Pet_Details updatePet = new Update_Pet_Details();
            this.Hide();
            updatePet.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Services_Request viewServicesRequestForm = new View_Services_Request();
            this.Hide();
            viewServicesRequestForm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void add_pet_Click(object sender, EventArgs e)
        {
            Add_New_Pet addPetForm = new Add_New_Pet();
            this.Hide ();
            addPetForm.Show();

        }

        private void Employee_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Hide();
            loginPage.Show();
        }
    }
}
