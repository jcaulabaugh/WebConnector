using System.Windows.Forms;

namespace WebConnectorApp
{
    partial class MainControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.activitylistbox = new System.Windows.Forms.ListBox();
            this.filterslbl = new System.Windows.Forms.Label();
            this.salesTransactionslbl = new System.Windows.Forms.Label();
            this.inverntoryTransactionslbl = new System.Windows.Forms.Label();
            this.communicationslbl = new System.Windows.Forms.Label();
            this.errorslbl = new System.Windows.Forms.Label();
            this.processbtn = new System.Windows.Forms.Button();
            this.findbtn = new System.Windows.Forms.Button();
            this.findtxt = new System.Windows.Forms.TextBox();
            this.filetersmenustrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openErrorLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendErrorLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSGPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sage50ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sage100ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesTransactioncheckBox = new System.Windows.Forms.CheckBox();
            this.inventoryTransactionscheckBox = new System.Windows.Forms.CheckBox();
            this.communicationscheckBox = new System.Windows.Forms.CheckBox();
            this.errorscheckBox = new System.Windows.Forms.CheckBox();
            this.errorlbl = new System.Windows.Forms.Label();
            this.timelbl = new System.Windows.Forms.Label();
            this.filetersmenustrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // activitylistbox
            // 
            this.activitylistbox.BackColor = System.Drawing.Color.Black;
            this.activitylistbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.activitylistbox.ForeColor = System.Drawing.Color.White;
            this.activitylistbox.FormattingEnabled = true;
            this.activitylistbox.ItemHeight = 17;
            this.activitylistbox.Location = new System.Drawing.Point(249, 109);
            this.activitylistbox.Name = "activitylistbox";
            this.activitylistbox.Size = new System.Drawing.Size(619, 327);
            this.activitylistbox.TabIndex = 0;
            // 
            // filterslbl
            // 
            this.filterslbl.AutoSize = true;
            this.filterslbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.filterslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.filterslbl.Location = new System.Drawing.Point(12, 109);
            this.filterslbl.Name = "filterslbl";
            this.filterslbl.Size = new System.Drawing.Size(96, 37);
            this.filterslbl.TabIndex = 1;
            this.filterslbl.Text = "Filters";
            // 
            // salesTransactionslbl
            // 
            this.salesTransactionslbl.AutoSize = true;
            this.salesTransactionslbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.salesTransactionslbl.ForeColor = System.Drawing.Color.Black;
            this.salesTransactionslbl.Location = new System.Drawing.Point(44, 156);
            this.salesTransactionslbl.Name = "salesTransactionslbl";
            this.salesTransactionslbl.Size = new System.Drawing.Size(136, 21);
            this.salesTransactionslbl.TabIndex = 2;
            this.salesTransactionslbl.Text = "Sales Transactions";
            // 
            // inverntoryTransactionslbl
            // 
            this.inverntoryTransactionslbl.AutoSize = true;
            this.inverntoryTransactionslbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.inverntoryTransactionslbl.ForeColor = System.Drawing.Color.Black;
            this.inverntoryTransactionslbl.Location = new System.Drawing.Point(44, 223);
            this.inverntoryTransactionslbl.Name = "inverntoryTransactionslbl";
            this.inverntoryTransactionslbl.Size = new System.Drawing.Size(166, 21);
            this.inverntoryTransactionslbl.TabIndex = 3;
            this.inverntoryTransactionslbl.Text = "Inventory Transactions";
            // 
            // communicationslbl
            // 
            this.communicationslbl.AutoSize = true;
            this.communicationslbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.communicationslbl.ForeColor = System.Drawing.Color.Black;
            this.communicationslbl.Location = new System.Drawing.Point(44, 293);
            this.communicationslbl.Name = "communicationslbl";
            this.communicationslbl.Size = new System.Drawing.Size(128, 21);
            this.communicationslbl.TabIndex = 4;
            this.communicationslbl.Text = "Communications";
            // 
            // errorslbl
            // 
            this.errorslbl.AutoSize = true;
            this.errorslbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.errorslbl.ForeColor = System.Drawing.Color.Black;
            this.errorslbl.Location = new System.Drawing.Point(44, 367);
            this.errorslbl.Name = "errorslbl";
            this.errorslbl.Size = new System.Drawing.Size(52, 21);
            this.errorslbl.TabIndex = 5;
            this.errorslbl.Text = "Errors";
            // 
            // processbtn
            // 
            this.processbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.processbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processbtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.processbtn.ForeColor = System.Drawing.Color.White;
            this.processbtn.Location = new System.Drawing.Point(764, 454);
            this.processbtn.Name = "processbtn";
            this.processbtn.Size = new System.Drawing.Size(104, 31);
            this.processbtn.TabIndex = 12;
            this.processbtn.Text = "Process";
            this.processbtn.UseVisualStyleBackColor = false;
            this.processbtn.Click += new System.EventHandler(this.processbtn_Click);
            // 
            // findbtn
            // 
            this.findbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.findbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findbtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.findbtn.ForeColor = System.Drawing.Color.White;
            this.findbtn.Location = new System.Drawing.Point(601, 59);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(104, 31);
            this.findbtn.TabIndex = 13;
            this.findbtn.Text = "Find";
            this.findbtn.UseVisualStyleBackColor = false;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // findtxt
            // 
            this.findtxt.Location = new System.Drawing.Point(249, 64);
            this.findtxt.Name = "findtxt";
            this.findtxt.Size = new System.Drawing.Size(333, 20);
            this.findtxt.TabIndex = 14;
            this.findtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // filetersmenustrip
            // 
            this.filetersmenustrip.BackColor = System.Drawing.Color.Transparent;
            this.filetersmenustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.authenticationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.filetersmenustrip.Location = new System.Drawing.Point(0, 0);
            this.filetersmenustrip.Name = "filetersmenustrip";
            this.filetersmenustrip.Size = new System.Drawing.Size(897, 24);
            this.filetersmenustrip.TabIndex = 19;
            this.filetersmenustrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openErrorLogMenuItem,
            this.sendErrorLogToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openErrorLogMenuItem
            // 
            this.openErrorLogMenuItem.Name = "openErrorLogMenuItem";
            this.openErrorLogMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openErrorLogMenuItem.Text = "Open Error Log";
            this.openErrorLogMenuItem.Click += new System.EventHandler(this.openErrorLogMenuItem_Click);
            // 
            // sendErrorLogToolStripMenuItem
            // 
            this.sendErrorLogToolStripMenuItem.Name = "sendErrorLogToolStripMenuItem";
            this.sendErrorLogToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendErrorLogToolStripMenuItem.Text = "Send Error Log";
            this.sendErrorLogToolStripMenuItem.Click += new System.EventHandler(this.sendErrorLogToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem1.Text = "Close";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.authenticationToolStripMenuItem.Text = "MCNi Account";
            this.authenticationToolStripMenuItem.Click += new System.EventHandler(this.authenticationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSGPToolStripMenuItem,
            this.sage50ToolStripMenuItem1,
            this.sage100ToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mSGPToolStripMenuItem
            // 
            this.mSGPToolStripMenuItem.Name = "mSGPToolStripMenuItem";
            this.mSGPToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.mSGPToolStripMenuItem.Text = "MSGP";
            this.mSGPToolStripMenuItem.Click += new System.EventHandler(this.mSGPToolStripMenuItem_Click);
            // 
            // sage50ToolStripMenuItem1
            // 
            this.sage50ToolStripMenuItem1.Name = "sage50ToolStripMenuItem1";
            this.sage50ToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.sage50ToolStripMenuItem1.Text = "Sage 50";
            this.sage50ToolStripMenuItem1.Click += new System.EventHandler(this.sage50ToolStripMenuItem1_Click);
            // 
            // sage100ToolStripMenuItem1
            // 
            this.sage100ToolStripMenuItem1.Name = "sage100ToolStripMenuItem1";
            this.sage100ToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.sage100ToolStripMenuItem1.Text = "Sage 100";
            this.sage100ToolStripMenuItem1.Click += new System.EventHandler(this.sage100ToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // salesTransactioncheckBox
            // 
            this.salesTransactioncheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.salesTransactioncheckBox.AutoSize = true;
            this.salesTransactioncheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.salesTransactioncheckBox.Checked = true;
            this.salesTransactioncheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.salesTransactioncheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.salesTransactioncheckBox.ForeColor = System.Drawing.Color.White;
            this.salesTransactioncheckBox.Location = new System.Drawing.Point(166, 180);
            this.salesTransactioncheckBox.Name = "salesTransactioncheckBox";
            this.salesTransactioncheckBox.Size = new System.Drawing.Size(44, 31);
            this.salesTransactioncheckBox.TabIndex = 20;
            this.salesTransactioncheckBox.Text = "ON";
            this.salesTransactioncheckBox.UseVisualStyleBackColor = false;
            this.salesTransactioncheckBox.CheckedChanged += new System.EventHandler(this.salesTransactioncheckBox_CheckedChanged);
            // 
            // inventoryTransactionscheckBox
            // 
            this.inventoryTransactionscheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.inventoryTransactionscheckBox.AutoSize = true;
            this.inventoryTransactionscheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.inventoryTransactionscheckBox.Checked = true;
            this.inventoryTransactionscheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inventoryTransactionscheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.inventoryTransactionscheckBox.ForeColor = System.Drawing.Color.White;
            this.inventoryTransactionscheckBox.Location = new System.Drawing.Point(166, 247);
            this.inventoryTransactionscheckBox.Name = "inventoryTransactionscheckBox";
            this.inventoryTransactionscheckBox.Size = new System.Drawing.Size(44, 31);
            this.inventoryTransactionscheckBox.TabIndex = 21;
            this.inventoryTransactionscheckBox.Text = "ON";
            this.inventoryTransactionscheckBox.UseVisualStyleBackColor = false;
            this.inventoryTransactionscheckBox.CheckedChanged += new System.EventHandler(this.inventoryTransactionscheckBox_CheckedChanged);
            // 
            // communicationscheckBox
            // 
            this.communicationscheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.communicationscheckBox.AutoSize = true;
            this.communicationscheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.communicationscheckBox.Checked = true;
            this.communicationscheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.communicationscheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.communicationscheckBox.ForeColor = System.Drawing.Color.White;
            this.communicationscheckBox.Location = new System.Drawing.Point(166, 317);
            this.communicationscheckBox.Name = "communicationscheckBox";
            this.communicationscheckBox.Size = new System.Drawing.Size(44, 31);
            this.communicationscheckBox.TabIndex = 22;
            this.communicationscheckBox.Text = "ON";
            this.communicationscheckBox.UseVisualStyleBackColor = false;
            this.communicationscheckBox.CheckedChanged += new System.EventHandler(this.communicationscheckBox_CheckedChanged);
            // 
            // errorscheckBox
            // 
            this.errorscheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.errorscheckBox.AutoSize = true;
            this.errorscheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.errorscheckBox.Checked = true;
            this.errorscheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorscheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.errorscheckBox.ForeColor = System.Drawing.Color.White;
            this.errorscheckBox.Location = new System.Drawing.Point(166, 386);
            this.errorscheckBox.Name = "errorscheckBox";
            this.errorscheckBox.Size = new System.Drawing.Size(44, 31);
            this.errorscheckBox.TabIndex = 23;
            this.errorscheckBox.Text = "ON";
            this.errorscheckBox.UseVisualStyleBackColor = false;
            this.errorscheckBox.CheckedChanged += new System.EventHandler(this.errorscheckBox_CheckedChanged);
            // 
            // errorlbl
            // 
            this.errorlbl.AutoSize = true;
            this.errorlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.errorlbl.ForeColor = System.Drawing.Color.Red;
            this.errorlbl.Location = new System.Drawing.Point(291, 459);
            this.errorlbl.Name = "errorlbl";
            this.errorlbl.Size = new System.Drawing.Size(451, 21);
            this.errorlbl.TabIndex = 24;
            this.errorlbl.Text = "Enter user info in Authentication and Configuration forms";
            // 
            // timelbl
            // 
            this.timelbl.AutoSize = true;
            this.timelbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.timelbl.Location = new System.Drawing.Point(15, 493);
            this.timelbl.Name = "timelbl";
            this.timelbl.Size = new System.Drawing.Size(0, 21);
            this.timelbl.TabIndex = 7;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 523);
            this.Controls.Add(this.errorlbl);
            this.Controls.Add(this.errorscheckBox);
            this.Controls.Add(this.communicationscheckBox);
            this.Controls.Add(this.inventoryTransactionscheckBox);
            this.Controls.Add(this.salesTransactioncheckBox);
            this.Controls.Add(this.findtxt);
            this.Controls.Add(this.findbtn);
            this.Controls.Add(this.processbtn);
            this.Controls.Add(this.timelbl);
            this.Controls.Add(this.errorslbl);
            this.Controls.Add(this.communicationslbl);
            this.Controls.Add(this.inverntoryTransactionslbl);
            this.Controls.Add(this.salesTransactionslbl);
            this.Controls.Add(this.filterslbl);
            this.Controls.Add(this.activitylistbox);
            this.Controls.Add(this.filetersmenustrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.filetersmenustrip;
            this.Name = "MainControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCNi WebConnector";
            this.Load += new System.EventHandler(this.Filters_Load);
            this.filetersmenustrip.ResumeLayout(false);
            this.filetersmenustrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox activitylistbox;
        private System.Windows.Forms.Label filterslbl;
        private System.Windows.Forms.Label salesTransactionslbl;
        private System.Windows.Forms.Label inverntoryTransactionslbl;
        private System.Windows.Forms.Label communicationslbl;
        private System.Windows.Forms.Label errorslbl;
        private System.Windows.Forms.Button processbtn;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.TextBox findtxt;
        private System.Windows.Forms.MenuStrip filetersmenustrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox salesTransactioncheckBox;
        private System.Windows.Forms.CheckBox inventoryTransactionscheckBox;
        private System.Windows.Forms.CheckBox communicationscheckBox;
        private System.Windows.Forms.CheckBox errorscheckBox;
        private System.Windows.Forms.ToolStripMenuItem openErrorLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendErrorLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label errorlbl;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem mSGPToolStripMenuItem;
        private ToolStripMenuItem sage50ToolStripMenuItem1;
        private ToolStripMenuItem sage100ToolStripMenuItem1;
        private Label timelbl;
    }
}