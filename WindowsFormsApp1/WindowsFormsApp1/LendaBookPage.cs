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
    public partial class LendaBookPage : Form
    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public LendaBookPage()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is System.Windows.Forms.TextBox)
                        (control as System.Windows.Forms.TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void LendaBookPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private bool IsUserValid(int userId)
        {
            string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};";
            string query = "SELECT COUNT(*) FROM users WHERE user_id = @userId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while checking user validity: " + ex.Message);
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userId, bookId, quantity;
            DateTime borrowedDate = DateTime.Now.Date;
            TimeSpan borrowedTime = DateTime.Now.TimeOfDay;
            string message = "";

            if (int.TryParse(textBox3.Text, out userId) &&
                int.TryParse(textBox2.Text, out bookId) &&
                int.TryParse(textBox4.Text, out quantity))
            {
                if (!IsUserValid(userId))
                {
                    MessageBox.Show("User ID is not valid.");
                    return;
                }

                string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("LendBook", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        cmd.Parameters.AddWithValue("@p_user_id", userId);
                        cmd.Parameters.AddWithValue("@p_book_id", bookId);
                        cmd.Parameters.AddWithValue("@p_quantity", quantity);
                        cmd.Parameters.AddWithValue("@p_borrowed_date", borrowedDate);
                        cmd.Parameters.AddWithValue("@p_borrowed_time", borrowedTime);

                        // Output parameter for message
                        cmd.Parameters.Add("@p_message", MySqlDbType.VarChar, 255);
                        cmd.Parameters["@p_message"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        message = cmd.Parameters["@p_message"].Value.ToString();
                        MessageBox.Show(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
        }
    }
}
