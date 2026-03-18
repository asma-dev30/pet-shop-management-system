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
    public partial class View_Pets_Data : Form
    {
       
        public View_Pets_Data()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Sold_Pets soldPetsForm = new View_Sold_Pets();
            soldPetsForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Available_Pets availablePetsForm = new View_Available_Pets();
            availablePetsForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Page adminForm = new Admin_Page();
            adminForm.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void View_Pets_Data_Load(object sender, EventArgs e)
        {

        }
    }
}
