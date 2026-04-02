using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Pet_Shop_Management_System
{
    
     
        public static class DbConfig
        {
           
            public static string ConnString = ConfigurationManager.ConnectionStrings["MyPetShopConn"].ConnectionString;
        }
    }


