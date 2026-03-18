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
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

namespace Online_Pet_Shop_Management_System
{
    public partial class Update_Pet_Details : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";


        public Update_Pet_Details()
        {
            InitializeComponent();
            dgv.DataSource = Pet.pet;
            LoadpetsData();
            pbimg.BackColor = Color.White;
        }
        private void LoadpetsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cons))
                {
                    Pet.pet.Clear();
                    conn.Open();
                    string query = "SELECT * FROM Pets";
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
        private void chb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbi.Checked)
            {
                cbn.Checked = false; // Uncheck the other box
                tbi.Enabled = true;
                tbn.Enabled = false;
            }
            else
            {
                tbi.Enabled = false;
                tbn.Enabled = false;
            }
        }

        private void chb2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbn.Checked)
            {
                cbi.Checked = false; // Uncheck the other box
                tbn.Enabled = true;
                tbi.Enabled = false;
            }
            else
            {
                tbn.Enabled = false;
                tbi.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pet.pet.Clear(); // Clear the binding list to refresh
                using (SqlConnection conn = new SqlConnection(cons))
                {
                    conn.Open();
                    string query = cbn.Checked
                        ? "SELECT * FROM Pets WHERE PetName LIKE @PetName"
                        : "SELECT * FROM Pets WHERE PetID = @PetID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (cbn.Checked)
                            cmd.Parameters.AddWithValue("@PetName", $"%{tbn.Text}%");
                        else
                            cmd.Parameters.AddWithValue("@PetID", tbi.Text);

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
                                            img = new Bitmap(Image.FromStream(ms));
                                        }
                                    }
                                }

                                Pet.pet.Add(new Pet
                                {
                                    PetID = sdr["PetID"].ToString(),
                                    PetName = sdr["PetName"].ToString(),
                                    Age = sdr["Age"].ToString(),
                                    Descriptions = sdr["Descriptions"].ToString(),
                                    Stat = sdr["Stat"].ToString(),
                                    PetImage = img
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching records: {ex.Message}");
            }

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(tbpetid.Text) ||
                    string.IsNullOrWhiteSpace(tbpet.Text) ||
                    string.IsNullOrWhiteSpace(tbage.Text) ||
                    string.IsNullOrWhiteSpace(tbdesc.Text) ||
                    string.IsNullOrWhiteSpace(tbstatus.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Database connection
                
                using (SqlConnection connection = new SqlConnection(cons))
                {
                    connection.Open();
                    string query = "UPDATE Pets SET PetName = @PetName, Age = @Age, Descriptions = @Descriptions, Stat = @Stat,PetImage=@PetImage WHERE PetID = @PetID";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PetID", tbpetid.Text);
                        command.Parameters.AddWithValue("@PetName", tbpet.Text);
                        command.Parameters.AddWithValue("@Age", tbage.Text);
                        command.Parameters.AddWithValue("@Descriptions", tbdesc.Text);
                        command.Parameters.AddWithValue("@Stat", tbstatus.Text);

                        byte[] imageBytes;

                        if (pbimg.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                // Clone the image into a bitmap to avoid stream or resource locks
                                using (Bitmap bmp = new Bitmap(pbimg.Image))
                                {
                                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Use a fixed format
                                }
                                imageBytes = ms.ToArray();
                            }
                        }
                        else
                        {
                            // Optional: set to DBNull or empty array if image is missing
                            imageBytes = new byte[0];
                        }
                        command.Parameters.AddWithValue("@PetImage", imageBytes);


                        
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Pet details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadpetsData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Employee_Dashboard dashboard = new Employee_Dashboard();
            this.Hide();
            dashboard.Show();
            
        }

        

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                try
                {



                    tbpetid.Text = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    String id= dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();
                    tbpet.Text = dgv.Rows[e.RowIndex].Cells[1].Value?.ToString();
                    tbage.Text = dgv.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    tbdesc.Text = dgv.Rows[e.RowIndex].Cells[3].Value?.ToString();
                    tbstatus.Text = dgv.Rows[e.RowIndex].Cells[4].Value?.ToString();
                    // Handle image cell


                   
                    using (SqlConnection conn = new SqlConnection(cons))
                    {
                        conn.Open();
                        string query = "SELECT PetImage FROM Pets WHERE PetID = @PetID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PetID", id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (!(reader["PetImage"] is DBNull))
                                    {
                                        byte[] imageBytes = (byte[])reader["PetImage"];
                                        using (MemoryStream ms = new MemoryStream(imageBytes))
                                        {
                                           pbimg.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pbimg.Image = null; // No image found
                                    }
                                }
                            }
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting record: {ex.Message}");
                }
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Display the selected image in the PictureBox
                pbimg.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
