using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queens_sso_auth
{
    public partial class LoginPortal : Form
    {
        public LoginPortal()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Initialize login pop-up
            SSO_Auth authScreen = new SSO_Auth(sender);
            authScreen.Show();
        }
    }
}
