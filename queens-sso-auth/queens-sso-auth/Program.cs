using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace queens_sso_auth
{
    static class Program
    {
        // Global, public instance of the current LoginPortal
        // Used by SSO-Auth to hide the initial view
        public static LoginPortal initialPortal;
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize the public LoginPortal instance
            initialPortal = new LoginPortal();
            // Run the initial LoginPortal
            Application.Run(initialPortal);
        }

        // Initialize the main application's Windows Form
        // Called after successful login
        // Passes a string of the user's Queen's Net ID to the new form
        public static void RunApp(string netid)
        {
            // Run a new instance of the MainApp form within the Application
            Application.Run(new MainApp(netid));
        }

    }
}
