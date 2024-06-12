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
        ReaderLandingPage readerLandingPage;
        public ReaderLandingPage()
        {
            InitializeComponent();
        }

        private void Admin_LogIn_Submit_Button_Click(object sender, EventArgs e)
        {

        }

        private void UserLogIn_Submit_Button_Click(object sender, EventArgs e)
        {
            searchPage searchPa = new searchPage();
            searchPa.Show();
        }
    }
}
