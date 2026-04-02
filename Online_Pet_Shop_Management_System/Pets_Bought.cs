using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Pet_Shop_Management_System
{
    public partial class Pets_Bought : Form
    {
     
        public Pets_Bought()
        {
            InitializeComponent();
            dgv.DataSource = PetsBought.petb;
            loadPets();
        }

        public void loadPets()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    PetsBought.petb.Clear(); // Clear old entries instead of Pet.pet
                    conn.Open();

                    string query = "SELECT * FROM PetsBought WHERE CustomerID = @cid";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Declare and assign the parameter
                        cmd.Parameters.AddWithValue("@cid", LoginPage.CID);

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                Image img = null;
                                if (!(sdr["PetImage"] is DBNull))
                                {
                                    byte[] imgBytes = (byte[])sdr["PetImage"];
                                    if (imgBytes.Length > 0)
                                    {
                                        using (MemoryStream ms = new MemoryStream(imgBytes))
                                        {
                                            Image temp = Image.FromStream(ms);
                                            img = new Bitmap(temp);
                                        }
                                    }
                                }

                                string cid = sdr["CustomerID"].ToString(); // Use from DB instead of LoginPage.CID
                                string id = sdr["PetID"].ToString();
                                string n = sdr["PetName"].ToString();
                                string a = sdr["Age"].ToString();
                                string d = sdr["Descriptions"].ToString();

                                PetsBought.petb.Add(new PetsBought
                                {
                                    CustomerID = cid,
                                    PetID = id,
                                    PetName = n,
                                    Age = a,
                                    Descriptions = d,
                                    PetImage = img,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bought pets data: {ex.Message}");
            }
        }
        private void Dashboard_Click(object sender, EventArgs e)
        {
            Customer_Dashboard cd = new Customer_Dashboard();
            this.Hide();
            cd.Show();
        }
    }
}
