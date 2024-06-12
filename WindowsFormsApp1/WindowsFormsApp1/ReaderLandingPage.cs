using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReaderLandingPage : Form

    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public ReaderLandingPage()
        {
            InitializeComponent();
        }

        private void Admin_LogIn_Submit_Button_Click(object sender, EventArgs e)
        {

        }

        private void UserLogIn_Submit_Button_Click(object sender, EventArgs e)
        {
            string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string loginQuery = @"
                SELECT COUNT(*) FROM admin
                WHERE user_name = @userName AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(loginQuery, con))
            {
                cmd.Parameters.AddWithValue("@userName", UserName_TextBox.Text);
                cmd.Parameters.AddWithValue("@password", UserPassword_TextBox.Text);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0)
                {
                    
                    searchPage searchPa = new searchPage();
                    searchPa.Show();
                    MessageBox.Show("Login Successful");
                    // Redirect to the next page or perform other actions upon successful login
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            
        }

        private void ReaderLandingPage_Load(object sender, EventArgs e)
        {

        }
    }
}
