using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;

namespace WebConnectorApp
{
    public partial class Sage50Config : Form
    {
        public Sage50Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for submitting the users information to the config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitbtn_Click(object sender, EventArgs e)
        {
            if (ConnectionTestModel.Sage50SDKConnectionStatus && ConnectionTestModel.Sage50DatasourceConnectionStatus)
            {
                ConfigHelper.ConfigSage50Builder(companytxt.Text, datasourceNametxt.Text, datasourcePasswordtxt.Text);
                successlbl.ForeColor = ColorTranslator.FromHtml("#3399FF");
                successlbl.Text = "Configuration info saved";
                successlbl.Visible = true;
            }
            else
            {
                successlbl.ForeColor = ColorTranslator.FromHtml("#ff0000");
                successlbl.Text = "Test Connection";
                successlbl.Visible = true;
            }
        }

        /// <summary>
        /// Method for testing the provided user info for the SDK Sage 50 input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sdkTestbtn_Click(object sender, EventArgs e)
        {
            if (companytxt.Text != "")
            {
                Sage50Connector.Sage50SDKConnectionTest(companytxt.Text);

                if (ConnectionTestModel.Sage50SDKConnectionStatus)
                {
                    sdklbl.ForeColor = ColorTranslator.FromHtml("#3399FF");
                    sdklbl.Visible = true;
                    sdklbl.Text = "Connection Successful";
                }
                else
                {
                    sdklbl.ForeColor = ColorTranslator.FromHtml("#ff0000");
                    sdklbl.Visible = true;
                    sdklbl.Text = "Connection Error";
                }
            }
            else
            {
                sdklbl.ForeColor = ColorTranslator.FromHtml("#ff0000");
                sdklbl.Visible = true;
                sdklbl.Text = "Fill Out All Fields";
            }
        }


        /// <summary>
        /// Method for testing the Sage 50 ODBC connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataSourceTestbtn_Click(object sender, EventArgs e)
        {
            if (datasourcePasswordtxt.Text != "" && datasourcePasswordtxt.Text != "")
            {
                Sage50Connector.Sage50DatasourceConnectionTest(datasourceNametxt.Text, datasourcePasswordtxt.Text);

                if (ConnectionTestModel.Sage50DatasourceConnectionStatus)
                {
                    datasourcelbl.ForeColor = ColorTranslator.FromHtml("#3399FF");
                    datasourcelbl.Visible = true;
                    datasourcelbl.Text = "Connection Successful";
                }
                else
                {
                    datasourcelbl.ForeColor = ColorTranslator.FromHtml("#ff0000");
                    datasourcelbl.Visible = true;
                    datasourcelbl.Text = "Connection Error";
                }
            }
            else
            {
                datasourcelbl.ForeColor = ColorTranslator.FromHtml("#ff0000");
                datasourcelbl.Visible = true;
                datasourcelbl.Text = "Fill Out All Fields";
            }
        }

        /// <summary>
        /// Setting all the label information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sage50_Load(object sender, EventArgs e)
        {
            datasourcePasswordtxt.PasswordChar = '*';
            sdklbl.Visible = false;
            datasourcelbl.Visible = false;
            successlbl.Visible = false;
        }

        /// <summary>
        /// Method for opening the db drivers window in windows
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("ODBCCP32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLManageDataSources(IntPtr hwnd);

        private void dataSourcebtn_Click(object sender, EventArgs e)
        {
            SQLManageDataSources(Handle);
        }
    }
}
