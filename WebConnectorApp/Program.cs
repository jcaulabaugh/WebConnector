using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;
using WeConnectorApp;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;

namespace WebConnectorApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            // The timer that triggers the queue check
            try
            {
                QueueTimer.QueueCheckTimer();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
            }


            if (ConfigHelper.configCheck())
            {
                // Setting the interval for the timer
                string interval;

                if (File.Exists(ConfigHelper.filePath))
                {
                    var doc = XDocument.Load(ConfigHelper.filePath);
                    if (doc.Descendants("Run_Every_Minutes").Any())
                    {
                        interval = doc.Element("Company").Element("Run_Every_Minutes").Value;

                        ActivityLog.activityListText($"Timer running, checking queue in <{ interval }> minutes");
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WebConnectorContext());

            
        }
    }
}
