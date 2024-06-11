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
    public partial class UserLogInPage : Form
    {
        public static UserLogInPage userLogInPage;    
        public UserLogInPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_LogIn_Submit_Button_Click(object sender, EventArgs e)
        {
            AdminLandPage adminLandPage = new AdminLandPage();
            adminLandPage.Show();

        }
    }
}
