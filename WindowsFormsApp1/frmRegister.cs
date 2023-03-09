using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check if the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // Create a connection to the database
            SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-ECGEBFA\SQLEXPRESS;Initial Catalog=QLHangHoa;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password",password);

            // Open the connection


            // Check if the username is already taken



            conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Registration failed!");
                }
            
            
                // Close the connection
                conn.Close();
            }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Show the other form
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
    }

