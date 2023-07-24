using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;


namespace WebConnectorApp
{
    public class WebConnectorContext : ApplicationContext
    {
        
        Authentication authorizationWindow = new Authentication();
        Configuration configWindow = new Configuration();
        public static NotifyIcon appIcon;

        public static NotifyIcon Notifier { get { return appIcon; } }
       
        public WebConnectorContext()
        {
            MenuItem checkQueue = new MenuItem("Check Queue", new EventHandler(CheckQueue));
            MenuItem authenticationMenuItem = new MenuItem("Authentication", new EventHandler(ShowAuthentication));
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem sendLogErrorsMenuItem = new MenuItem("Send Error Report", new EventHandler(SendLogErrors));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            appIcon = new NotifyIcon();

            appIcon.Icon = Properties.Resources.AppIcon;
            appIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { checkQueue, configMenuItem, authenticationMenuItem, sendLogErrorsMenuItem, exitMenuItem });
            appIcon.Visible = true;

            appIcon.Text = "TEST";
            appIcon.BalloonTipText = "runningggg";
            appIcon.ShowBalloonTip(30000);
        }


        // Opens the authentication form
        void ShowAuthentication(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (authorizationWindow.Visible)
            {
                authorizationWindow.Activate();
            }
            else
            {
                authorizationWindow.ShowDialog();
            }
        }

        // Opens the config form
        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (configWindow.Visible)
            {
                configWindow.Activate();
            }
            else
            {
                configWindow.ShowDialog();
            }
        }

        private static HttpClient _httpClient = new HttpClient();

        // A method for checking if there any requests in the queue
        void CheckQueue(object sender, EventArgs e)
        {
            CheckQueueHelper.CheckQueueFlow();
        }

        void SendLogErrors(object sender, EventArgs e)
        {
            Debug.WriteLine("Log Error");
        }

        void Exit(object sender, EventArgs e)
        {
            // Remove icon before we exit
            appIcon.Visible = false;
            appIcon.Dispose();

            Application.Exit();
        }
    }
}

