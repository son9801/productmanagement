using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
 

// ...



       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
                // Hide the current form
                this.Hide();

                // Show the other form
                frmRegister frmRegister = new frmRegister();
                frmRegister.Show();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Create a connection to the database
            SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True");

            try
            {
                // Open the connection
                conn.Open();

                // Create a SQL command to select the user with the given username and password
                SqlCommand cmd = new SqlCommand("SELECT Id FROM Users WHERE Username = @username AND Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // Execute the command and check if the user exists
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // If the user is authenticated, show a message and close the login form
                    MessageBox.Show("Logged in successfully!");
                    this.Hide();
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                }
                else
                {
                    // If the user is not authenticated, show an error message
                    MessageBox.Show("Invalid username or password!");
                }
            }
            catch (Exception ex)
            {
                // If there's an error, show an error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }
    }
}
