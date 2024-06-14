using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
            string lendId = textBox1.Text;
            string lastMessage = "";

            if (string.IsNullOrWhiteSpace(lendId))
            {
                MessageBox.Show("Please enter a lend_id.");
                return;
            }

            string connectionString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={password};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Check if lend_id exists
                string checkLendIdQuery = "SELECT * FROM lends WHERE lend_id = @lendId";
                MySqlCommand checkLendIdCmd = new MySqlCommand(checkLendIdQuery, conn);
                checkLendIdCmd.Parameters.AddWithValue("@lendId", lendId);
                MySqlDataReader reader = checkLendIdCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("lend_id is not available.");
                    reader.Close();
                    return;
                }

                // Fetch lend details
                reader.Read();
                int userId = reader.GetInt32("user_id");
                int bookId = reader.GetInt32("book_id");
                DateTime borrowedDate = reader.GetDateTime("borrowed_date");
                int quantity = reader.GetInt32("quantity");
                reader.Close();

                // Calculate fine if applicable
                DateTime currentDate = DateTime.Now;
                TimeSpan timeSpan = currentDate - borrowedDate;
                int daysExceeded = (int)timeSpan.TotalDays - 14;
                int fine = 0;

                if (daysExceeded > -100)
                {
                    fine = daysExceeded * 100 * quantity;
                }

                // Update user's fine
                if (fine > 0)
                {
                    string updateFineQuery = "UPDATE users SET fine = fine + @fine WHERE user_id = @userId";
                    MySqlCommand updateFineCmd = new MySqlCommand(updateFineQuery, conn);
                    updateFineCmd.Parameters.AddWithValue("@fine", fine);
                    updateFineCmd.Parameters.AddWithValue("@userId", userId);
                    updateFineCmd.ExecuteNonQuery();
                    lastMessage = "Book returned No fine needed";
                }
                else
                {
                    string updateFineQuery = "UPDATE users SET fine = " + fine + " WHERE user_id = @userId";
                    MySqlCommand updateFineCmd = new MySqlCommand(updateFineQuery, conn);
                    updateFineCmd.Parameters.AddWithValue("@userId", userId);
                    updateFineCmd.ExecuteNonQuery();
                    lastMessage = "Book Returned fine is " + fine;
                }

                // Update book's quantity
                string updateBookQuery = "UPDATE books SET quantity = quantity + @quantity WHERE book_id = @bookId";
                MySqlCommand updateBookCmd = new MySqlCommand(updateBookQuery, conn);
                updateBookCmd.Parameters.AddWithValue("@quantity", quantity);
                updateBookCmd.Parameters.AddWithValue("@bookId", bookId);
                updateBookCmd.ExecuteNonQuery();

                // Delete the lend record
                string deleteLendQuery = "DELETE FROM lends WHERE lend_id = @lendId";
                MySqlCommand deleteLendCmd = new MySqlCommand(deleteLendQuery, conn);
                deleteLendCmd.Parameters.AddWithValue("@lendId", lendId);
                deleteLendCmd.ExecuteNonQuery();

                MessageBox.Show(lastMessage);
            }

        }
    }
}
