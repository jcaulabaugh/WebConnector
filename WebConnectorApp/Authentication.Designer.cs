
namespace WebConnectorApp
{
    partial class Authentication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
            this.loginbtn = new System.Windows.Forms.Button();
            this.userNametxt = new System.Windows.Forms.TextBox();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.userNamelbl = new System.Windows.Forms.Label();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.userNameErrorlbl = new System.Windows.Forms.Label();
            this.passwordErrorlbl = new System.Windows.Forms.Label();
            this.authenticationSuccesslbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.authenticationInstructionslbl = new System.Windows.Forms.Label();
            this.authenticationErrorlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginbtn
            // 
            this.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.loginbtn.Location = new System.Drawing.Point(248, 274);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(129, 47);
            this.loginbtn.TabIndex = 0;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // userNametxt
            // 
            this.userNametxt.Location = new System.Drawing.Point(238, 156);
            this.userNametxt.Name = "userNametxt";
            this.userNametxt.Size = new System.Drawing.Size(218, 20);
            this.userNametxt.TabIndex = 1;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(238, 220);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(218, 20);
            this.passwordtxt.TabIndex = 2;
            // 
            // userNamelbl
            // 
            this.userNamelbl.AutoSize = true;
            this.userNamelbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.userNamelbl.Location = new System.Drawing.Point(140, 153);
            this.userNamelbl.Name = "userNamelbl";
            this.userNamelbl.Size = new System.Drawing.Size(87, 21);
            this.userNamelbl.TabIndex = 3;
            this.userNamelbl.Text = "Username";
            this.userNamelbl.Click += new System.EventHandler(this.userNamelbl_Click);
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.passwordlbl.Location = new System.Drawing.Point(145, 217);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(82, 21);
            this.passwordlbl.TabIndex = 4;
            this.passwordlbl.Text = "Password";
            this.passwordlbl.Click += new System.EventHandler(this.passwordlbl_Click);
            // 
            // userNameErrorlbl
            // 
            this.userNameErrorlbl.AutoSize = true;
            this.userNameErrorlbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameErrorlbl.ForeColor = System.Drawing.Color.Red;
            this.userNameErrorlbl.Location = new System.Drawing.Point(235, 127);
            this.userNameErrorlbl.Name = "userNameErrorlbl";
            this.userNameErrorlbl.Size = new System.Drawing.Size(0, 17);
            this.userNameErrorlbl.TabIndex = 5;
            // 
            // passwordErrorlbl
            // 
            this.passwordErrorlbl.AutoSize = true;
            this.passwordErrorlbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordErrorlbl.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorlbl.Location = new System.Drawing.Point(236, 192);
            this.passwordErrorlbl.Name = "passwordErrorlbl";
            this.passwordErrorlbl.Size = new System.Drawing.Size(0, 17);
            this.passwordErrorlbl.TabIndex = 6;
            // 
            // authenticationSuccesslbl
            // 
            this.authenticationSuccesslbl.AutoSize = true;
            this.authenticationSuccesslbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationSuccesslbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.authenticationSuccesslbl.Location = new System.Drawing.Point(216, 350);
            this.authenticationSuccesslbl.Name = "authenticationSuccesslbl";
            this.authenticationSuccesslbl.Size = new System.Drawing.Size(0, 17);
            this.authenticationSuccesslbl.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // authenticationInstructionslbl
            // 
            this.authenticationInstructionslbl.AutoSize = true;
            this.authenticationInstructionslbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationInstructionslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.authenticationInstructionslbl.Location = new System.Drawing.Point(139, 50);
            this.authenticationInstructionslbl.Name = "authenticationInstructionslbl";
            this.authenticationInstructionslbl.Size = new System.Drawing.Size(378, 37);
            this.authenticationInstructionslbl.TabIndex = 9;
            this.authenticationInstructionslbl.Text = "Login to your MCNI account";
            // 
            // authenticationErrorlbl
            // 
            this.authenticationErrorlbl.AutoSize = true;
            this.authenticationErrorlbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticationErrorlbl.ForeColor = System.Drawing.Color.Red;
            this.authenticationErrorlbl.Location = new System.Drawing.Point(114, 350);
            this.authenticationErrorlbl.Name = "authenticationErrorlbl";
            this.authenticationErrorlbl.Size = new System.Drawing.Size(0, 17);
            this.authenticationErrorlbl.TabIndex = 10;
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 396);
            this.Controls.Add(this.authenticationErrorlbl);
            this.Controls.Add(this.authenticationInstructionslbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.authenticationSuccesslbl);
            this.Controls.Add(this.passwordErrorlbl);
            this.Controls.Add(this.userNameErrorlbl);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.userNamelbl);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.userNametxt);
            this.Controls.Add(this.loginbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authentication";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.TextBox userNametxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label userNamelbl;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.Label userNameErrorlbl;
        private System.Windows.Forms.Label passwordErrorlbl;
        private System.Windows.Forms.Label authenticationSuccesslbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label authenticationInstructionslbl;
        private System.Windows.Forms.Label authenticationErrorlbl;
    }
}