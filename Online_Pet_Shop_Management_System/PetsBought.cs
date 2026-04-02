using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Pet_Shop_Management_System
{
    public class PetsBought
    {
        public string CustomerID {  get; set; }
        public string PetID { get; set; }
        public string PetName { get; set; }
        public string Age { get; set; }
        public string Descriptions { get; set; }
        public Image PetImage { get; set; }

        public static BindingList<PetsBought> petb = new BindingList<PetsBought>();
    }
}
