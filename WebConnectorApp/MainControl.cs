using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;

namespace WebConnectorApp
{
    public partial class MainControl : Form
    {
        public MainControl()
        {
            InitializeComponent();
        }

        private void Filters_Load(object sender, EventArgs e)
        {
            errorlbl.Text = "";

            // Setting the time
            timelbl.Text = DateTime.Now.ToString("t");

            // Timer for updating the timelbl
            Timer MyTimer = new Timer();
            MyTimer.Interval = (1000); // 45 mins
            MyTimer.Tick += new EventHandler(lblTimer_Tick);
            MyTimer.Start();

            // Updating the listbox with all application activity
            activitylistbox.DataSource = ActivityLog.activityList;

            // Checking the count of the list to see if the ListBox needs to be cleared 
            if (ActivityLog.activityList.Count > 5000)
            {
                ActivityLog.ClearActivityList();
            }

            updateListbox();
        }

        /// <summary>
        /// Tick event for updating the timlbl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                timelbl.Text = DateTime.Now.ToString("t");
                updateListbox();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
            }
            
        }

        /// <summary>
        /// On click the queue is checked for any requests from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void processbtn_Click(object sender, EventArgs e)
        {
            // Checking the queue
            if (ConfigHelper.configCheck())
            {
                // Disable button
                processbtn.Enabled = false;

                await CheckQueueHelper.CheckQueueFlow();
                errorlbl.Text = "";
                updateListbox();

                // Enable button after the process has been completed
                processbtn.Enabled = true;
            }
            else
            {
                errorlbl.Text = "Enter user info in Authentication and Configuration forms";
            }
        }

        /// <summary>
        /// Method for changing the checkbox style once checked or unchecked
        /// </summary>
        /// <param name="checkBoxNum">One of the four checkboxes</param>
        private void checkBoxUIChanger(CheckBox checkBoxNum)
        {
            if (checkBoxNum.Text == "OFF")
            {
                checkBoxNum.Text = "ON";
                checkBoxNum.BackColor = ColorTranslator.FromHtml("#3399FF");
                checkBoxNum.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            }
            else
            {
                checkBoxNum.Text = "OFF";
                checkBoxNum.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                checkBoxNum.ForeColor = ColorTranslator.FromHtml("#3399FF");
            }
        }

        /// <summary>
        /// Method for changing the listbox based on the status of each checkbox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="term"></param>
        private void checkBoxChanger(CheckBox box, string term)
        {
            if (!box.Checked)
            {
                for (int i = ActivityLog.activityList.Count() - 1; i >= 0; i--)
                {
                    if (ActivityLog.activityList[i].Contains(term))
                    {
                        ActivityLog.filteredList.Add(ActivityLog.activityList[i]);
                        ActivityLog.activityList.Remove(ActivityLog.activityList[i]);
                    }
                }
                ActivityLog.activityList.ApplySort(ListSortDirection.Ascending);
                updateListbox();
            }
            else
            {
                foreach (string item in ActivityLog.filteredList.ToList())
                {
                    if (item.Contains(term))
                    {
                        ActivityLog.activityList.Add(item);
                        ActivityLog.filteredList.Remove(item);

                    }
                }
                ActivityLog.activityList.ApplySort(ListSortDirection.Ascending);
                updateListbox();
            }
        }

        // Control for checkbox
        private void salesTransactioncheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUIChanger(salesTransactioncheckBox);
            checkBoxChanger(salesTransactioncheckBox, "Sales Transaction");
        }

        // Control for checkbox
        private void inventoryTransactionscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUIChanger(inventoryTransactionscheckBox);
            checkBoxChanger(inventoryTransactionscheckBox, "Inventory Transaction");
        }

        // Control for checkbox
        private void communicationscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUIChanger(communicationscheckBox);
            checkBoxChanger(communicationscheckBox, "Authenticated!");
            checkBoxChanger(communicationscheckBox, "Connecting");
            checkBoxChanger(communicationscheckBox, "Accounting");
            checkBoxChanger(communicationscheckBox, "Sending");
            checkBoxChanger(communicationscheckBox, "Replying");
            checkBoxChanger(communicationscheckBox, "Nothing");
            checkBoxChanger(communicationscheckBox, "Running");
            checkBoxChanger(communicationscheckBox, "Timer");
        }

        // Control for checkbox
        private void errorscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUIChanger(errorscheckBox);
            checkBoxChanger(errorscheckBox, "Error");
        }

        /// <summary>
        /// Method for filtering out the search reults in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findbtn_Click(object sender, EventArgs e)
        {
            if (findtxt.Text != "")
            {
                for (int i = ActivityLog.activityList.Count() - 1; i >= 0; i--)
                {
                    if (!ActivityLog.activityList[i].ToUpper().Contains(findtxt.Text.ToUpper()))
                    {
                        ActivityLog.searchList.Add(ActivityLog.activityList[i]);
                        ActivityLog.activityList.Remove(ActivityLog.activityList[i]);
                    }
                }
                ActivityLog.activityList.ApplySort(ListSortDirection.Ascending);
                updateListbox();
            }
            else if (ActivityLog.searchList.Any())
            {
                foreach (string item in ActivityLog.searchList.ToList())
                {
                    ActivityLog.activityList.Add(item);
                    ActivityLog.searchList.Remove(item);
                    ActivityLog.activityList.ApplySort(ListSortDirection.Ascending);
                }
                updateListbox();
            }
        }

        // Method for searching the listbox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findbtn_Click(this, new EventArgs());
            }
        }

        // Close the form
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open the MCNiAuthentication form
        private void authenticationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var authorizationWindow = new MCNiAuthentication();
            authorizationWindow.Show();
        }

        // Open the MSGPConfig form
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var configurationWindow = new MSGPConfig();
            configurationWindow.Show();
        }

        // Open the about form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.Show();
        }

        // Open the Sage100Config form
        private void sage100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sage100Window = new Sage100Config();
            sage100Window.Show();
        }

        // Open the Sage50Config form
        private void sage50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sage50Window = new Sage50Config();
            sage50Window.Show();
        }

        /// <summary>
        /// Method for making sure the listbox always displays the most current activity after the queue is checked
        /// </summary>
        private void updateListbox()
        {
            // Setting the list to scroll to bottom so that the most recent item is visible
            activitylistbox.SelectedIndex = activitylistbox.Items.Count - 1;
        }

        /// <summary>
        /// Method for opening the default mail client with error log file attached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendErrorLogToolStripMenuItem_Click(object sender, EventArgs e)
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
                WebConnectorContext.appIcon.BalloonTipText = "No errors recorded today";
                WebConnectorContext.appIcon.ShowBalloonTip(20000);
            }
        }

        /// <summary>
        /// Method for opening the most current error log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openErrorLogMenuItem_Click(object sender, EventArgs e)
        {
            string path = $@"{ GlobalConfig.filePath() }\errors\";
            string date = DateTime.Now.ToShortDateString().Replace("/", "-");
            string file = $@"{ path }ErrorLog_{ date }";

            if (File.Exists($"{ file }.txt"))
            {
                Process.Start("notepad.exe", file);
            }
            else
            {
                WebConnectorContext.appIcon.BalloonTipText = "No errors recorded today";
                WebConnectorContext.appIcon.ShowBalloonTip(20000);
            }
        }

        private void mSGPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var configurationWindow = new MSGPConfig();
            configurationWindow.Show();
        }

        private void sage50ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sage50Window = new Sage50Config();
            sage50Window.Show();
        }

        private void sage100ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sage100Window = new Sage100Config();
            sage100Window.Show();
        }
    }
}
