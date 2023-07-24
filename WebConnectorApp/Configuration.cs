using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WebConnectorApp.AppHelper;

namespace WebConnectorApp
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void driverListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            passwordDBtxt.PasswordChar = '*';
            
        }

        private void ShowDataSourceDialog()
        {

        }

        private void configbtn_Click(object sender, EventArgs e)
        {
            
            if (ConnectionTestModel.ConnectionStatus)
            {
                ConfigHelper.ConfigDBBuilder(dataSourcetxt.Text, databasetxt.Text, usernameDBtxt.Text, passwordDBtxt.Text);

                // Set the proper icon text
                WebConnectorContext.appIcon.Text = IconText.IconTextCheck();

                dataSourcetxt.Text = "";
                databasetxt.Text = "";
                usernameDBtxt.Text = "";
                passwordDBtxt.Text = "";

                ConnectionTestModel.ConnectionStatus = false;

            }
            else if (!ConnectionTestModel.ConnectionStatus)
            {
                connectionErrorlbl.Text = "Test Connection";
            }

        }

        private void configTestbtn_Click(object sender, EventArgs e)
        {
            var connection = connectionTest(dataSourcetxt.Text, databasetxt.Text, usernameDBtxt.Text, passwordDBtxt.Text);

            if (!connection)
            {
                connectionErrorlbl.Text = "Connection Error";
                connectionSuccesslbl.Text = "";
                ConnectionTestModel.ConnectionStatus = false;
            }
            else if (connection)
            {
                connectionSuccesslbl.Text = "Connection Successful";
                connectionErrorlbl.Text = "";
                ConnectionTestModel.ConnectionStatus = true;
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


        [DllImport("ODBCCP32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLManageDataSources(IntPtr hwnd);
        private void optionsbtn_Click(object sender, EventArgs e)
        {
            SQLManageDataSources(Handle);
        }

        private void dataSourcelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
