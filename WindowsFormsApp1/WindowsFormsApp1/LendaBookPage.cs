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

        private void button2_Click(object sender, EventArgs e)
        {
            string bookId = textBox2.Text;
            string bookName = textBox1.Text;
            string userId = textBox3.Text;
            string quantityStr = textBox4.Text;

            if (int.TryParse(bookId, out int bookID) && int.TryParse(userId, out int userID) && int.TryParse(quantityStr, out int quantity))
            {
                string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("LendBook", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_user_id", userID);
                        cmd.Parameters.AddWithValue("p_book_id", bookID);
                        cmd.Parameters.AddWithValue("p_quantity", quantity);
                        cmd.Parameters.Add("p_message", MySqlDbType.VarChar);
                        cmd.Parameters["p_message"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        string message = cmd.Parameters["p_message"].Value.ToString();
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
                MessageBox.Show("Please enter valid integers for Book ID, User ID, and Quantity.");
            }


        }
    }
}
