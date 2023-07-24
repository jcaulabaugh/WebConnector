using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;



namespace ConnectorLibrary.Utilities
{
    public class QueueTimer
    {
        /// <summary>
        /// The timer that is used to check the queue
        /// </summary>
        public static void QueueCheckTimer()
        {

            Debug.WriteLine("Timer check 1");
            // Create a timer and set a 3 minute interval
            System.Timers.Timer myTimer = new System.Timers.Timer();

            if (File.Exists(ConfigHelper.filePath))
            {
                var doc = XDocument.Load(ConfigHelper.filePath);

                if (doc.Descendants("Run_Every_Minutes").Any())
                {
                    // User enters a minute value, that is then converted to milliseconds
                    myTimer.Interval = double.Parse(doc.Element("Company").Element("Run_Every_Minutes").Value) * 60000;
                }
            }
            else
            {
                // Default to five minutes
                myTimer.Interval = 1000 * 300;
            }
            
            // Hook up the Elapsed event for the timer
            myTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            myTimer.AutoReset = true;

            // Start the timer
            myTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine("Timer Check 2");
            if (File.Exists(ConfigHelper.filePath))
            {
                try
                {
                    CheckQueueHelper.CheckQueueFlow();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
