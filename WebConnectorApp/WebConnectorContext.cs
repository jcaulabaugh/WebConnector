using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectorLibrary.Utilities;
using WebConnectorApp.AppHelper;

namespace WebConnectorApp
{
    /// <summary>
    /// This class enables the app to run in the system tray on start
    /// </summary>
    public class WebConnectorContext : ApplicationContext
    {
        // Initializing all the forms
        MainControl filtersWindow = new MainControl();
        MCNiAuthentication MCNiAuthenticationWindow = new MCNiAuthentication();
        MSGPConfig MSGPConfigWindow = new MSGPConfig();
        Sage100Config sage100Window = new Sage100Config();
        Sage50Config sage50Window = new Sage50Config();


        // The systray icon 
        public static NotifyIcon appIcon;

        public WebConnectorContext()
        {
            MenuItem checkQueue = new MenuItem("Check Queue", new EventHandler(CheckQueue));
            MenuItem sage100ConfigMenuItem = new MenuItem("Sage 100 Config", new EventHandler(Sage100ConfigSettings));
            MenuItem sage50ConfigMenuItem = new MenuItem("Sage 50 Config", new EventHandler(Sage50ConfigSettings));
            MenuItem MCNiAuthenticationMenuItem = new MenuItem("MCNi Authentication", new EventHandler(ShowMCNiAuthentication));
            MenuItem MSGPConfigMenuItem = new MenuItem("MSGP Config", new EventHandler(ShowMSGPConfig));
            MenuItem sendLogErrorsMenuItem = new MenuItem("Send Error Report", new EventHandler(SendLogErrors));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            // Applying settings to the icon
            appIcon = new NotifyIcon();
            appIcon.Icon = Properties.Resources.AppIcon;
            appIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { checkQueue, MCNiAuthenticationMenuItem, MSGPConfigMenuItem, sage50ConfigMenuItem, sage100ConfigMenuItem, sendLogErrorsMenuItem, exitMenuItem });
            appIcon.Visible = true;
            appIcon.BalloonTipText = "MCNi Web Connector Running";
            appIcon.ShowBalloonTip(20000);
            appIcon.Text = IconText.IconTextCheck();
            appIcon.MouseClick += new MouseEventHandler(appIcon_MouseClicked);

            // Display the main control form when the application starts
            filtersWindow.ShowDialog();
        }

        // Open the Filter window
        private void appIcon_MouseClicked(object senser, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // If we are already showing the form, focus on it
                if (filtersWindow.Visible)
                {
                    filtersWindow.Activate();
                }
                else
                {
                    filtersWindow.ShowDialog();
                }
            }
        }

        // Open the Sage100Config form
        void Sage100ConfigSettings(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (sage100Window.Visible)
            {
                sage100Window.Activate();
            }
            else
            {
                sage100Window.ShowDialog();
            }
        }

        // Open the Sage50Config form
        void Sage50ConfigSettings(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (sage50Window.Visible)
            {
                sage50Window.Activate();
            }
            else
            {
                sage50Window.ShowDialog();
            }
        }

        // Open the MCNiAuthentication form
        void ShowMCNiAuthentication(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (MCNiAuthenticationWindow.Visible)
            {
                MCNiAuthenticationWindow.Activate();
            }
            else
            {
                MCNiAuthenticationWindow.ShowDialog();
            }
        }

        // Opens the MSGPConfig form
        void ShowMSGPConfig(object sender, EventArgs e)
        {
            // If we are already showing the form, focus on it
            if (MSGPConfigWindow.Visible)
            {
                MSGPConfigWindow.Activate();
            }
            else
            {
                MSGPConfigWindow.ShowDialog();
            }
        }

        // Method for checking if there any requests in the queue
        void CheckQueue(object sender, EventArgs e)
        {
            if (ConfigHelper.configCheck())
            {
                appIcon.BalloonTipText = "Checking for Updates";
                appIcon.ShowBalloonTip(20000);

                // Delay the queue check so that the previous ballontiptext is still readable
                Task.Delay(3000).ContinueWith(t => CheckQueueHelper.CheckQueueFlow());
            }
            else
            {
                appIcon.BalloonTipText = "Enter user info in Authenticaiton and Configuration forms";
                appIcon.ShowBalloonTip(30000);
            }
        }

        /// <summary>
        /// Method for sending error logs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SendLogErrors(object sender, EventArgs e)
        {
            string path = $@"{ GlobalConfig.filePath() }\errors\";
            string date = DateTime.Now.ToShortDateString().Replace("/", "-");
            string file = $@"{ path }ErrorLog_{ date }";

            if (File.Exists($"{ file }.txt"))
            {
                LogSender.SendErrorLog(path, date);
            }
            else
            {
                appIcon.BalloonTipText = "No errors recorded today";
                appIcon.ShowBalloonTip(20000);
            }
        }

        // Close the application
        void Exit(object sender, EventArgs e)
        {
            // Remove icon before we exit
            appIcon.Visible = false;
            appIcon.Dispose();

            Application.Exit();
        }
    }
}

