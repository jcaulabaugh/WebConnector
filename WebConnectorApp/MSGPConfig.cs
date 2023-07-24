using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using WebConnectorApp.AppHelper;

namespace WebConnectorApp
{
    public partial class MSGPConfig : Form
    {
        public MSGPConfig()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            passwordDBtxt.PasswordChar = '*';
        }

        /// <summary>
        /// Method for saving user's db info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configbtn_Click(object sender, EventArgs e)
        {

            if (ConnectionTestModel.MSGPConnectionStatus)
            {
                ConfigHelper.ConfigMSGPBuilder(dataSourcetxt.Text, databasetxt.Text, usernameDBtxt.Text, passwordDBtxt.Text, docidtxt.Text);

                // Set the proper icon text
                WebConnectorContext.appIcon.Text = IconText.IconTextCheck();

                dataSourcetxt.Text = "";
                databasetxt.Text = "";
                usernameDBtxt.Text = "";
                passwordDBtxt.Text = "";
                docidtxt.Text = "";

                ConnectionTestModel.MSGPConnectionStatus = false;

            }
            else if (!ConnectionTestModel.MSGPConnectionStatus)
            {
                connectionErrorlbl.Text = "Test Connection";
            }
        }

        /// <summary>
        /// Method for testing user's db info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configTestbtn_Click(object sender, EventArgs e)
        {
            var connection = connectionTest(dataSourcetxt.Text, databasetxt.Text, usernameDBtxt.Text, passwordDBtxt.Text);

            if (!connection)
            {
                connectionErrorlbl.Text = "Connection Error";
                connectionSuccesslbl.Text = "";
                ConnectionTestModel.MSGPConnectionStatus = false;
            }
            else if (connection)
            {
                connectionSuccesslbl.Text = "Connection Successful";
                connectionErrorlbl.Text = "";
                ConnectionTestModel.MSGPConnectionStatus = true;
            }
        }

        /// <summary>
        /// Method for testing the connection string information
        /// </summary>
        /// <param name="dataSource">server</param>
        /// <param name="database">database name</param>
        /// <param name="username">user ID</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        private bool connectionTest(string dataSource, string database, string username = "", string password = "")
        {
            string filePath = ConfigHelper.filePath;

            // Connectionstring
            string conn = $@"Server = { dataSource }; Initial Catalog = { database }; User ID = { username }; Password = { password };";

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                return false;
            }
        }

        /// <summary>
        /// Method for opening the db drivers window in windows
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("ODBCCP32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLManageDataSources(IntPtr hwnd);
        private void optionsbtn_Click(object sender, EventArgs e)
        {
            SQLManageDataSources(Handle);
        }

        private void docidtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
