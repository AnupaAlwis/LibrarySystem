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
    public partial class ReturnPage : Form
    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public ReturnPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lendId, userId;
            if (!int.TryParse(textBox2.Text, out lendId) || !int.TryParse(textBox1.Text, out userId))
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for lend ID and user ID.");
                return;
            }

            string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("ProcessBookReturn", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.AddWithValue("@p_lend_id", lendId);
                    cmd.Parameters.AddWithValue("@p_user_id", userId);

                    // Output parameter for result (optional)
                    cmd.Parameters.Add("@p_result", MySqlDbType.VarChar, 50);
                    cmd.Parameters["@p_result"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["@p_result"].Value.ToString();
                    MessageBox.Show(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


        }
    }
}
