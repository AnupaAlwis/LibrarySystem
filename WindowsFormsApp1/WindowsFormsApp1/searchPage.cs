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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class searchPage : Form
    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public searchPage()
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

        private void searchPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string searchQuery = @"
                SELECT * FROM books
                WHERE (@book_id IS NULL OR book_id = @book_id)
                AND (@book_name IS NULL OR book_name = @book_name)
                AND (@book_author IS NULL OR book_author = @book_author)
                AND (@book_isbn IS NULL OR book_isbn = @book_isbn)";

            using (MySqlCommand cmd = new MySqlCommand(searchQuery, con))
            {
                cmd.Parameters.AddWithValue("@book_id", string.IsNullOrEmpty(textBox4.Text) ? (object)DBNull.Value : textBox4.Text);
                cmd.Parameters.AddWithValue("@book_name", string.IsNullOrEmpty(textBox1.Text) ? (object)DBNull.Value : textBox1.Text);
                cmd.Parameters.AddWithValue("@book_isbn", string.IsNullOrEmpty(textBox3.Text) ? (object)DBNull.Value : textBox3.Text);
                cmd.Parameters.AddWithValue("@book_author", string.IsNullOrEmpty(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No book found with the provided details.");
                    dataGridView1.DataSource = null;
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
