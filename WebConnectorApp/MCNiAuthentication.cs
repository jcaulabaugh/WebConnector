using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;
using WebConnectorApp.AppHelper;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;

namespace WebConnectorApp
{
    public partial class MCNiAuthentication : Form
    {
        private static HttpClient _httpClient;

        public MCNiAuthentication()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            // Clearing the form fields
            userNameErrorlbl.Text = "";
            passwordErrorlbl.Text = "";
            authenticationErrorlbl.Text = "";
            authenticationErrorlbl.Text = "";
            authenticationSuccesslbl.Text = "";
            passwordtxt.PasswordChar = '*';

            // Populate the textbox fields with the correct info if it is available
            if (File.Exists(ConfigHelper.filePath))
            {
                var doc = XDocument.Load(ConfigHelper.filePath);

                if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any())
                {
                    userNametxt.Text = doc.Element("Company").Element("MCNI_Username").Value;
                    passwordtxt.Text = doc.Element("Company").Element("MCNI_Password").Value;

                    userNametxt.ReadOnly = true;
                    passwordtxt.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// Method for checkin user's credentials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void loginbtn_Click(object sender, EventArgs e)
        {
            if (userNametxt.Text == "")
            {
                userNameErrorlbl.Text = "Please enter a Username";
            }
            if (passwordtxt.Text == "")
            {
                passwordErrorlbl.Text = "Please enter a Password";
            }

            if (userNametxt.Text != "" && passwordtxt.Text != "")
            {
                try
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(@"https://www.mcni360wctest.com");
                    var authentication = await AuthenticationHandler.UserAuthenticationAsync(_httpClient, userNametxt.Text, passwordtxt.Text);
                    if (!authentication.Status)
                    {
                        authenticationErrorlbl.Text = "Authentication failed, please re-enter username and password";
                        authenticationSuccesslbl.Text = "";
                        userNameErrorlbl.Text = "";
                        passwordErrorlbl.Text = "";

                        // Clear username and password fields
                        userNametxt.Text = "";
                        passwordtxt.Text = "";
                    }
                    else if (authentication.Status)
                    {
                        authenticationSuccesslbl.Text = "Authentication successful";
                        authenticationErrorlbl.Text = "";
                        userNameErrorlbl.Text = "";
                        passwordErrorlbl.Text = "";

                        ConfigHelper.ConfigBuilder(userNametxt.Text, passwordtxt.Text);

                        // Set the proper icon text
                        WebConnectorContext.appIcon.Text = IconText.IconTextCheck();

                        userNametxt.ReadOnly = true;
                        passwordtxt.ReadOnly = true;

                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogException(ex);
                }

            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            // Populate the textbox fields with the correct info if it is available
            if (File.Exists(ConfigHelper.filePath))
            {
                var doc = XDocument.Load(ConfigHelper.filePath);

                if (doc.Descendants("MCNI_Username").Any() && doc.Descendants("MCNI_Password").Any())
                {
                    userNametxt.Text = doc.Element("Company").Element("MCNI_Username").Value;
                    passwordtxt.Text = doc.Element("Company").Element("MCNI_Password").Value;

                    File.Delete(ConfigHelper.filePath);

                    // Clear all labels
                    authenticationErrorlbl.Text = "";
                    authenticationSuccesslbl.Text = "";
                    userNameErrorlbl.Text = "";
                    passwordErrorlbl.Text = "";

                    // Clear username and password fields
                    userNametxt.Text = "";
                    passwordtxt.Text = "";

                    // Set readonly to false so that user can enter new information
                    userNametxt.ReadOnly = false;
                    passwordtxt.ReadOnly = false;
                }
            }
        }
    }
}
