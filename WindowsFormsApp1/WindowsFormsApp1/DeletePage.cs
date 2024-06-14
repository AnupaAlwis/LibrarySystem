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
    public partial class DeletePage : Form
    {
        string server = "localhost";
        string user = "root";
        string password = "";
        string database = "librarymanagementsystem";
        public DeletePage()
        {
            InitializeComponent();
        }

        //Function to clear all textboxes
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

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void DeletePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            //string deleteQuery = "DELETE FROM books WHERE book_id = @book_id AND book_name = @bookName)"; using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
            string deleteQuery = "DELETE FROM books WHERE book_id = @book_id AND book_name = @bookName";
            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, con))
            {
                cmd.Parameters.AddWithValue("@book_id", textBox4.Text);
                cmd.Parameters.AddWithValue("@bookName", textBox1.Text);
                //cmd.Parameters.AddWithValue("@bookISBN", textBox2.Text);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Book Deleted Successfully", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Book Found with the provided details","Not Found",MessageBoxButtons.RetryCancel,MessageBoxIcon.Question);
                }
            }

            con.Close();
        }
    }
    
}
