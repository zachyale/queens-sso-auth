using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Add Microsoft.mshtml to your References, and include it in the authentication browser class.
using mshtml;

namespace queens_sso_auth
{
    public partial class SSO_Auth : Form
    {
        // Private String to store the temporary, and final user Net ID
        private String username;

        public SSO_Auth(Object sender)
        {
            InitializeComponent();
            // Initialize username to null value
            username = null;
            // Direct authentication browser to Queen's SSO
            authBrowser.Navigate("http://my.queensu.ca");
        }

        // Method called upon successful navigation of the authentication browser to a new web page
        private void authBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Initialize current browser URL to the string 'url' 
            String url = authBrowser.Url.ToString();
            // If authentication browser has reached the MyQueen'sU page, login was successful
            if (authBrowser.Url.ToString() == "https://my.queensu.ca/")
            {
                // Close authentication browser
                Close();

                // Hide initial login portal
                //Program.initialPortal.Close();
                Program.initialPortal.Visible = false;

                // Display the application's next Windows Form
                MainApp mainApplication = new MainApp(username);
                mainApplication.Show();
                //Program.RunApp(username);

                // Debugging message box, to verify user Net ID
                MessageBox.Show("Successful login!\nUsername: " + username);
            }
            // Else, login was unsuccessful
            else
            {
                // MessageBox.Show("Unsuccessful login! Please try again.");
                // Redirect authentication browser to new page
                //loginBrowser.Navigate("http://my.queensu.ca");
            }
        }

        // Method called while the authentication browser is navigating to a new web page, 
        // i.e., upon the user attempting to login on the Queen's SSO website.
        // Temporarily stores the last Net ID used to attempt a login.
        private void authBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // If the document stored within the authentication browser is valid,
            if (authBrowser.Document != null)
            {
                // Fetch the HTML input element associated with the Queen's SSO Net ID textbox (Element "j_username")
                HtmlElement inputHtmlElement = authBrowser.Document.GetElementById("j_username");

                // Initialize HTML input element variable to null.
                IHTMLInputElement inputElement = null;

                // Store input HTML element's DOM element as an IHTMLInputElement
                inputElement = (IHTMLInputElement)inputHtmlElement.DomElement;

                // Store input element value (Net ID string) within username variable
                username = (String)inputElement.value;
            }
        }
    }
}
