using ConnectorLibrary.Utilities;
using MCNiWebServiceApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WebConnectorApp.AppHelper;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.Models;

namespace WebConnectorApp
{
    public partial class Authentication : Form
    {
        private static HttpClient _httpClient = new HttpClient();

        public Authentication()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
        }

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
                    var authentication = await AuthenticationHandler.UserAuthenticationAsync(_httpClient, userNametxt.Text, passwordtxt.Text);
                    if (!authentication.Status)
                    {
                        authenticationErrorlbl.Text = "Authentication failed, please re-enter username and password";
                        authenticationSuccesslbl.Text = "";
                        userNameErrorlbl.Text = "";
                        passwordErrorlbl.Text = "";

                    }
                    else if (authentication.Status)
                    {
                        authenticationSuccesslbl.Text = "Authentication successful";
                        authenticationErrorlbl.Text = "";

                        ConfigHelper.ConfigBuilder(userNametxt.Text, passwordtxt.Text);

                        // Set the proper icon text
                        WebConnectorContext.appIcon.Text = IconText.IconTextCheck();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogException(ex);
                }
           
            }
        }

        private void passwordlbl_Click(object sender, EventArgs e)
        {

        }

        private void userNamelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
