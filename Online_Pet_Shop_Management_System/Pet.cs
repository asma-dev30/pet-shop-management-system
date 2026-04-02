using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Pet_Shop_Management_System
{
    public class Pet
    {
        public string PetID { get; set; }
        public string PetName { get; set; }
        public string Age { get; set; }
        public string Descriptions { get; set; }
        public string Stat { get; set; }
        public Image PetImage { get; set; }

        public static BindingList<Pet> pet = new BindingList<Pet>();
    }
}
