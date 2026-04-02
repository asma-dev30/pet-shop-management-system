using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Pet_Shop_Management_System
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public string HiringDate { get; set; }
        public string Address { get; set; }
        public Image EmpImage { get; set; }



        public static BindingList<Employee> emp = new BindingList<Employee>();
    }
}
