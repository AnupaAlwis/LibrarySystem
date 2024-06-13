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
    public partial class AdminLandPage : Form
    {
        public AdminLandPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchPage searchP = new searchPage();
            searchP.Show();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeletePage deletePage = new DeletePage();
            deletePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPage addPage = new AddPage();
            addPage.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LendaBookPage lendaBookPage = new LendaBookPage();
            lendaBookPage.Show();
        }
    }
}
