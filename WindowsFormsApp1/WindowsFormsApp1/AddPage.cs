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
    public partial class AddPage : Form
    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public AddPage()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void AddPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            string bookId = textBox5.Text;
            string bookName = textBox1.Text;
            string bookISBN = textBox2.Text;
            string bookAuthor = textBox3.Text;
            string quantityText = textBox4.Text;

            if (!string.IsNullOrEmpty(bookId))
            {
                // Book_ID is entered, check quantity
                if (string.IsNullOrEmpty(quantityText))
                {
                    MessageBox.Show("Please enter the quantity.");
                    return;
                }

                int quantity = int.Parse(quantityText);

                // Check if the book ID exists
                string checkQuery = "SELECT quantity FROM books WHERE book_id = @bookId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@bookId", bookId);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Book ID exists, update quantity
                        int existingQuantity = Convert.ToInt32(result);
                        int newQuantity = existingQuantity + quantity;

                        string updateQuery = "UPDATE books SET quantity = @newQuantity WHERE book_id = @bookId";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                            updateCmd.Parameters.AddWithValue("@bookId", bookId);
                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Book quantity updated successfully");
                        }
                        con.Close();
                        return;
                    }
                }

                // If book ID does not exist, show error message
                MessageBox.Show("Book ID does not exist.");
            }
            else
            {
                // Book_ID is not entered, check other fields
                if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(bookISBN) || string.IsNullOrEmpty(bookAuthor) || string.IsNullOrEmpty(quantityText))
                {
                    MessageBox.Show("Please fill in all the details correctly.");
                    return;
                }

                int quantity = int.Parse(quantityText);

                // Insert new record
                string addQuery = "INSERT INTO books(book_name, book_isbn, book_author, quantity) VALUES (@bookName, @bookISBN, @bookAuthor, @quantity)";
                using (MySqlCommand cmd = new MySqlCommand(addQuery, con))
                {
                    cmd.Parameters.AddWithValue("@bookName", bookName);
                    cmd.Parameters.AddWithValue("@bookISBN", bookISBN);
                    cmd.Parameters.AddWithValue("@bookAuthor", bookAuthor);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully");
                }
            }

            con.Close();
        }

    }
}
