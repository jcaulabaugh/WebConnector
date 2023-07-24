
namespace WebConnectorApp
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.dataSourcelbl = new System.Windows.Forms.Label();
            this.configbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.databaselbl = new System.Windows.Forms.Label();
            this.usernameDBlbl = new System.Windows.Forms.Label();
            this.passwordDBlbl = new System.Windows.Forms.Label();
            this.dataSourcetxt = new System.Windows.Forms.TextBox();
            this.databasetxt = new System.Windows.Forms.TextBox();
            this.usernameDBtxt = new System.Windows.Forms.TextBox();
            this.passwordDBtxt = new System.Windows.Forms.TextBox();
            this.configTestbtn = new System.Windows.Forms.Button();
            this.connectionSuccesslbl = new System.Windows.Forms.Label();
            this.optionsbtn = new System.Windows.Forms.Button();
            this.databaseInfolbl = new System.Windows.Forms.Label();
            this.connectionErrorlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSourcelbl
            // 
            this.dataSourcelbl.AutoSize = true;
            this.dataSourcelbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dataSourcelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dataSourcelbl.Location = new System.Drawing.Point(152, 79);
            this.dataSourcelbl.Name = "dataSourcelbl";
            this.dataSourcelbl.Size = new System.Drawing.Size(102, 21);
            this.dataSourcelbl.TabIndex = 1;
            this.dataSourcelbl.Text = "Data Source";
            this.dataSourcelbl.Click += new System.EventHandler(this.dataSourcelbl_Click);
            // 
            // configbtn
            // 
            this.configbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.configbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.configbtn.Location = new System.Drawing.Point(330, 364);
            this.configbtn.Name = "configbtn";
            this.configbtn.Size = new System.Drawing.Size(120, 50);
            this.configbtn.TabIndex = 2;
            this.configbtn.Text = "Submit";
            this.configbtn.UseVisualStyleBackColor = true;
            this.configbtn.Click += new System.EventHandler(this.configbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // databaselbl
            // 
            this.databaselbl.AutoSize = true;
            this.databaselbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.databaselbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.databaselbl.Location = new System.Drawing.Point(153, 125);
            this.databaselbl.Name = "databaselbl";
            this.databaselbl.Size = new System.Drawing.Size(81, 21);
            this.databaselbl.TabIndex = 10;
            this.databaselbl.Text = "Database";
            // 
            // usernameDBlbl
            // 
            this.usernameDBlbl.AutoSize = true;
            this.usernameDBlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.usernameDBlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.usernameDBlbl.Location = new System.Drawing.Point(153, 173);
            this.usernameDBlbl.Name = "usernameDBlbl";
            this.usernameDBlbl.Size = new System.Drawing.Size(87, 21);
            this.usernameDBlbl.TabIndex = 11;
            this.usernameDBlbl.Text = "Username";
            // 
            // passwordDBlbl
            // 
            this.passwordDBlbl.AutoSize = true;
            this.passwordDBlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.passwordDBlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.passwordDBlbl.Location = new System.Drawing.Point(152, 218);
            this.passwordDBlbl.Name = "passwordDBlbl";
            this.passwordDBlbl.Size = new System.Drawing.Size(82, 21);
            this.passwordDBlbl.TabIndex = 12;
            this.passwordDBlbl.Text = "Password";
            // 
            // dataSourcetxt
            // 
            this.dataSourcetxt.Location = new System.Drawing.Point(269, 82);
            this.dataSourcetxt.Name = "dataSourcetxt";
            this.dataSourcetxt.Size = new System.Drawing.Size(265, 20);
            this.dataSourcetxt.TabIndex = 13;
            // 
            // databasetxt
            // 
            this.databasetxt.Location = new System.Drawing.Point(269, 128);
            this.databasetxt.Name = "databasetxt";
            this.databasetxt.Size = new System.Drawing.Size(265, 20);
            this.databasetxt.TabIndex = 14;
            // 
            // usernameDBtxt
            // 
            this.usernameDBtxt.Location = new System.Drawing.Point(269, 176);
            this.usernameDBtxt.Name = "usernameDBtxt";
            this.usernameDBtxt.Size = new System.Drawing.Size(265, 20);
            this.usernameDBtxt.TabIndex = 15;
            // 
            // passwordDBtxt
            // 
            this.passwordDBtxt.Location = new System.Drawing.Point(268, 221);
            this.passwordDBtxt.Name = "passwordDBtxt";
            this.passwordDBtxt.Size = new System.Drawing.Size(265, 20);
            this.passwordDBtxt.TabIndex = 16;
            // 
            // configTestbtn
            // 
            this.configTestbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configTestbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.configTestbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.configTestbtn.Location = new System.Drawing.Point(403, 263);
            this.configTestbtn.Name = "configTestbtn";
            this.configTestbtn.Size = new System.Drawing.Size(130, 38);
            this.configTestbtn.TabIndex = 17;
            this.configTestbtn.Text = "Test";
            this.configTestbtn.UseVisualStyleBackColor = true;
            this.configTestbtn.Click += new System.EventHandler(this.configTestbtn_Click);
            // 
            // connectionSuccesslbl
            // 
            this.connectionSuccesslbl.AutoSize = true;
            this.connectionSuccesslbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.connectionSuccesslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.connectionSuccesslbl.Location = new System.Drawing.Point(312, 323);
            this.connectionSuccesslbl.Name = "connectionSuccesslbl";
            this.connectionSuccesslbl.Size = new System.Drawing.Size(0, 21);
            this.connectionSuccesslbl.TabIndex = 18;
            // 
            // optionsbtn
            // 
            this.optionsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.optionsbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.optionsbtn.Location = new System.Drawing.Point(268, 263);
            this.optionsbtn.Name = "optionsbtn";
            this.optionsbtn.Size = new System.Drawing.Size(129, 38);
            this.optionsbtn.TabIndex = 19;
            this.optionsbtn.Text = "Options";
            this.optionsbtn.UseVisualStyleBackColor = true;
            this.optionsbtn.Click += new System.EventHandler(this.optionsbtn_Click);
            // 
            // databaseInfolbl
            // 
            this.databaseInfolbl.AutoSize = true;
            this.databaseInfolbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.databaseInfolbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.databaseInfolbl.Location = new System.Drawing.Point(300, 25);
            this.databaseInfolbl.Name = "databaseInfolbl";
            this.databaseInfolbl.Size = new System.Drawing.Size(196, 37);
            this.databaseInfolbl.TabIndex = 20;
            this.databaseInfolbl.Text = "Database Info";
            // 
            // connectionErrorlbl
            // 
            this.connectionErrorlbl.AutoSize = true;
            this.connectionErrorlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.connectionErrorlbl.ForeColor = System.Drawing.Color.Red;
            this.connectionErrorlbl.Location = new System.Drawing.Point(326, 323);
            this.connectionErrorlbl.Name = "connectionErrorlbl";
            this.connectionErrorlbl.Size = new System.Drawing.Size(0, 21);
            this.connectionErrorlbl.TabIndex = 21;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(732, 444);
            this.Controls.Add(this.connectionErrorlbl);
            this.Controls.Add(this.databaseInfolbl);
            this.Controls.Add(this.optionsbtn);
            this.Controls.Add(this.connectionSuccesslbl);
            this.Controls.Add(this.configTestbtn);
            this.Controls.Add(this.passwordDBtxt);
            this.Controls.Add(this.usernameDBtxt);
            this.Controls.Add(this.databasetxt);
            this.Controls.Add(this.dataSourcetxt);
            this.Controls.Add(this.passwordDBlbl);
            this.Controls.Add(this.usernameDBlbl);
            this.Controls.Add(this.databaselbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.configbtn);
            this.Controls.Add(this.dataSourcelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dataSourcelbl;
        private System.Windows.Forms.Button configbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label databaselbl;
        private System.Windows.Forms.Label usernameDBlbl;
        private System.Windows.Forms.Label passwordDBlbl;
        private System.Windows.Forms.TextBox dataSourcetxt;
        private System.Windows.Forms.TextBox databasetxt;
        private System.Windows.Forms.TextBox usernameDBtxt;
        private System.Windows.Forms.TextBox passwordDBtxt;
        private System.Windows.Forms.Button configTestbtn;
        public System.Windows.Forms.Label connectionSuccesslbl;
        private System.Windows.Forms.Button optionsbtn;
        private System.Windows.Forms.Label databaseInfolbl;
        private System.Windows.Forms.Label connectionErrorlbl;
    }
}