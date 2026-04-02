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
    public partial class View_Sold_Pets : Form
    {
       

        public View_Sold_Pets()
        {
            InitializeComponent();
            LoadpetsData();
            dgv.DataSource = Pet.pet;
        }
        private void LoadpetsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnString))
                {
                    Pet.pet.Clear();
                    conn.Open();
                    string query = "SELECT * FROM Pets where Stat='Sold'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            // Safely handle NULL CoverImage
                            Image img = null;
                            if (!(sdr["PetImage"] is DBNull))
                            {
                                byte[] imgBytes = (byte[])sdr["PetImage"];
                                if (imgBytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imgBytes))
                                    {
                                        Image temp = Image.FromStream(ms);
                                        img = new Bitmap(temp);  // Create a copy to avoid stream locking issues
                                    }
                                }
                            }


                            string id = sdr["PetID"].ToString();
                            string n = sdr["PetName"].ToString();
                            string a = sdr["Age"].ToString();
                            string d = sdr["Descriptions"].ToString();
                            string stat = sdr["Stat"].ToString();

                            Pet.pet.Add(new Pet
                            {
                                PetID = id,
                                PetName = n,
                                Age = a,
                                Descriptions = d,
                                Stat = stat,
                                PetImage = img,
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee data: {ex.Message}");
            }
        }
        private void View_Sold_Pets_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            View_Pets_Data view = new View_Pets_Data();
            this.Hide();
            view.Show();
            
        }
    }
}
