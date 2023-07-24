using System;
using System.Windows.Forms;
using ConnectorLibrary.DataAccess;
using ConnectorLibrary.Models;
using ConnectorLibrary.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WebConnectorApp
{
    public partial class Sage100Config : Form
    {
        public Sage100Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for submitting the user info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitbtn_Click(object sender, EventArgs e)
        {
            if (ConnectionTestModel.Sage100ConnectionStatus)
            {
                ConfigHelper.ConfigSage100Builder(pathtxt.Text, companytxt.Text, usernametxt.Text, passwordtxt.Text);
                successlbl.Text = "Configuration info saved";
                successlbl.Visible = true;
            }
            else
            {
                testErrorlbl.Text = "Test Connection";
                testErrorlbl.Visible = true;
                successlbl.Visible = false;
            }
        }

        /// <summary>
        /// On form load making sure the labels are correctly configured
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sage100_Load(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
            testErrorlbl.Visible = false;
            testErrorlbl.Text = "Test Connection";

            successlbl.Visible = false;
            successlbl.Text = "Connection Successful";

            fieldslbl.Visible = false;
            fieldslbl.Text = "Fill out all fields";
        }

        /// <summary>
        /// Method for testing the users information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testbtn_Click(object sender, EventArgs e)
        {
            if (pathtxt.Text != "" && companytxt.Text != "" && usernametxt.Text != "" && passwordtxt.Text != "")
            {
                Sage100Connector.Sage100ConnectionTest(pathtxt.Text, companytxt.Text, usernametxt.Text, passwordtxt.Text);

                if (ConnectionTestModel.Sage100ConnectionStatus)
                {
                    fieldslbl.Visible = false;
                    testErrorlbl.Visible = false;
                    successlbl.Visible = true;
                }
                else
                {
                    fieldslbl.Visible = false;
                    testErrorlbl.Visible = true;
                    testErrorlbl.Text = "Connection Error";
                }
            }
            else
            {
                fieldslbl.Visible = true;
            }
        }

        /// <summary>
        /// Opens the required path for Sage 100. Typically (C:\sage\Sage 100 Standard\MAS90\Home)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pathbtn_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = pathtxt.Text;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathtxt.Text = dialog.FileName;
            }
        }
    }
}
