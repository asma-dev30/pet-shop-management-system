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
    public partial class Add_New_Pet : Form
    {
        private string cons = "Data Source=SUNSHINE;Initial Catalog=DQPP;Integrated Security=True;Encrypt=False;";
        public Add_New_Pet()
        {
            InitializeComponent();
            pbimg.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(tbname.Text) ||
                    string.IsNullOrWhiteSpace(tbage.Text) ||
                    string.IsNullOrWhiteSpace(tbdesc.Text) ||
                    string.IsNullOrWhiteSpace(tbid.Text) ||
                    string.IsNullOrWhiteSpace(tbstatus.Text) ||
                    pbimg.Image == null)
                {
                    MessageBox.Show("Please fill in all fields and upload an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convert image to byte array
                MemoryStream memoryStream = new MemoryStream();
                pbimg.Image.Save(memoryStream, pbimg.Image.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();

                // Database connection and insertion
                using (SqlConnection connection = new SqlConnection(cons))
                {
                    string query = "INSERT INTO Pets (PetID, PetName, Age, Descriptions, Stat, PetImage) " +
                                   "VALUES (@PetID, @PetName, @Age, @Descriptions, @Stat, @PetImage)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adding parameters for text fields
                        command.Parameters.AddWithValue("@PetName", tbname.Text);
                        command.Parameters.AddWithValue("@Age", tbage.Text);
                        command.Parameters.AddWithValue("@Descriptions", tbdesc.Text);
                        command.Parameters.AddWithValue("@PetID", tbid.Text);
                        command.Parameters.AddWithValue("@Stat", tbstatus.Text);

                        // Adding parameter for image
                        command.Parameters.AddWithValue("@PetImage", imageBytes);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Pet added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbname.Text = null;
                        tbage.Text = null;
                        tbdesc.Text = null;
                        tbid.Text = null;
                        tbstatus.Text = null;
                        pbimg.Image = null;
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

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
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
