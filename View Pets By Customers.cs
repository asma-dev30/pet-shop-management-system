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
    public partial class View_Pets_By_Customers : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";

        public View_Pets_By_Customers()
        {
            InitializeComponent();
            LoadpetsData();
            dgv.DataSource = Pet.pet;
            
        }
        private void LoadpetsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cons))
                {
                    Pet.pet.Clear();
                    conn.Open();
                    string query = "SELECT * FROM Pets where Stat='Available'";
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
        private void View_Pets_By_Customers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          Customer_Dashboard customer_Dashboard = new Customer_Dashboard();
            this.Hide();
            customer_Dashboard.Show();
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string petID = dgv.SelectedRows[0].Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(petID))
                {
                    MessageBox.Show("Invalid Pet ID selected.");
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(cons))
                    {
                        conn.Open();

                        // Step 1: Fetch full pet details before updating
                        string fetchQuery = "SELECT * FROM Pets WHERE PetID = @PetID";
                        SqlCommand fetchCmd = new SqlCommand(fetchQuery, conn);
                        fetchCmd.Parameters.AddWithValue("@PetID", petID);

                        string name = "", age = "", description = "", stat = "";
                        byte[] imageBytes = null;

                        using (SqlDataReader reader = fetchCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = reader["PetName"].ToString();
                                age = reader["Age"].ToString();
                                description = reader["Descriptions"].ToString();
                                stat = "Sold"; // Force this to match the status we’re updating to
                                if (!(reader["PetImage"] is DBNull))
                                {
                                    imageBytes = (byte[])reader["PetImage"];
                                }
                            }
                            else
                            {
                                MessageBox.Show("Pet not found.");
                                return;
                            }
                        }

                        // Step 2: Update the pet status to Sold
                        string updateQuery = "UPDATE Pets SET Stat = 'Sold' WHERE PetID = @PetID";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@PetID", petID);
                        updateCmd.ExecuteNonQuery();

                        // Step 3: Insert into PetsBought table (ignoring CustomerID)
                        string insertQuery = "INSERT INTO PetsBought (CustomerID,PetID, PetName, Age, Descriptions, PetImage) " +
                                             "VALUES (@CID, @PetID, @PetName, @Age, @Descriptions, @PetImage)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@CID", LoginPage.CID);
                        insertCmd.Parameters.AddWithValue("@PetID", petID);
                        insertCmd.Parameters.AddWithValue("@PetName", name);
                        insertCmd.Parameters.AddWithValue("@Age", age);
                        insertCmd.Parameters.AddWithValue("@Descriptions", description);
                        insertCmd.Parameters.AddWithValue("@PetImage", (object)imageBytes ?? DBNull.Value);

                        int insertResult = insertCmd.ExecuteNonQuery();

                        if (insertResult > 0)
                        {
                            MessageBox.Show("Pet bought successfully and saved to purchase history.");
                            LoadpetsData(); // Refresh the available pets
                        }
                        else
                        {
                            MessageBox.Show("Pet purchase saved failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a pet to buy.");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
