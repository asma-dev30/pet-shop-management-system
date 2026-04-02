using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class Manage_Employs : Form
    {
        public Manage_Employs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Employee addEmployeeForm = new Add_Employee();
            this.Hide();
            addEmployeeForm.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete_Or_Update_Employee deleteOrUpdateEmployeeForm = new Delete_Or_Update_Employee();
            deleteOrUpdateEmployeeForm.Show();
            this.Hide();
        }

        private void emp_mang_Click(object sender, EventArgs e)
        {
            View_Employs v=new View_Employs();
            this.Hide();
            v.Show(); 
        }

       
       

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Page adminForm = new Admin_Page();
            
            this.Hide();
            adminForm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
            
        }

        private void Manage_Employs_Load(object sender, EventArgs e)
        {
        }
    }
}
