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
            string connectionString = "server="+server + ";user=" + user + ";password=" + password + ";database=" + database + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string addQuery = "INSERT INTO books(book_name, book_isbn, book_author,quantity,availability) VALUES (@bookName, @bookISBN, @bookAuthor, @quantity,TRUE)";
            using (MySqlCommand cmd = new MySqlCommand(addQuery, con))
            {
                cmd.Parameters.AddWithValue("@bookName", textBox1.Text);
                cmd.Parameters.AddWithValue("@bookISBN", textBox2.Text);
                cmd.Parameters.AddWithValue("@bookAuthor", textBox3.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox4.Text);

                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Book Added Successfully");
            }
            
        }

    }
}
