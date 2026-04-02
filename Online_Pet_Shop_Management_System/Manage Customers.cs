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
    public partial class Manage_Customers : Form
    {
        public Manage_Customers()
        {
            InitializeComponent();
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

       

        private void Feedback_Click(object sender, EventArgs e)
        {
            Customers_FeedBack customers_FeedBack = new Customers_FeedBack();
            this.Hide();
            customers_FeedBack.Show();  
        }

        private void V_D_Cutomer_Click(object sender, EventArgs e)
        {
            View_All_Customers viewAllCustomersForm = new View_All_Customers();
            this.Hide();
            viewAllCustomersForm.Show();
        }
        
            
    }
}
