namespace WebConnectorApp
{
    partial class Sage50Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sage50Config));
            this.submitbtn = new System.Windows.Forms.Button();
            this.sdkTestbtn = new System.Windows.Forms.Button();
            this.companytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.successlbl = new System.Windows.Forms.Label();
            this.sdklbl = new System.Windows.Forms.Label();
            this.datasourcePasswordtxt = new System.Windows.Forms.TextBox();
            this.datasourceNametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datasourcelbl = new System.Windows.Forms.Label();
            this.dataSourceTestbtn = new System.Windows.Forms.Button();
            this.datasourcebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // submitbtn
            // 
            this.submitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.submitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitbtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.submitbtn.ForeColor = System.Drawing.Color.White;
            this.submitbtn.Location = new System.Drawing.Point(358, 391);
            this.submitbtn.Name = "submitbtn";
            this.submitbtn.Size = new System.Drawing.Size(120, 50);
            this.submitbtn.TabIndex = 21;
            this.submitbtn.Text = "Submit";
            this.submitbtn.UseVisualStyleBackColor = false;
            this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
            // 
            // sdkTestbtn
            // 
            this.sdkTestbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.sdkTestbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sdkTestbtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sdkTestbtn.ForeColor = System.Drawing.Color.White;
            this.sdkTestbtn.Location = new System.Drawing.Point(554, 155);
            this.sdkTestbtn.Name = "sdkTestbtn";
            this.sdkTestbtn.Size = new System.Drawing.Size(109, 36);
            this.sdkTestbtn.TabIndex = 20;
            this.sdkTestbtn.Text = "Test";
            this.sdkTestbtn.UseVisualStyleBackColor = false;
            this.sdkTestbtn.Click += new System.EventHandler(this.sdkTestbtn_Click);
            // 
            // companytxt
            // 
            this.companytxt.Location = new System.Drawing.Point(287, 166);
            this.companytxt.Name = "companytxt";
            this.companytxt.Size = new System.Drawing.Size(235, 20);
            this.companytxt.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(198, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Company";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(251, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sage 50 Configuration";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // successlbl
            // 
            this.successlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.successlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.successlbl.Location = new System.Drawing.Point(237, 487);
            this.successlbl.Name = "successlbl";
            this.successlbl.Size = new System.Drawing.Size(333, 23);
            this.successlbl.TabIndex = 23;
            this.successlbl.Text = "Configuration info saved";
            this.successlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sdklbl
            // 
            this.sdklbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.sdklbl.ForeColor = System.Drawing.Color.Red;
            this.sdklbl.Location = new System.Drawing.Point(241, 203);
            this.sdklbl.Name = "sdklbl";
            this.sdklbl.Size = new System.Drawing.Size(325, 23);
            this.sdklbl.TabIndex = 25;
            this.sdklbl.Text = "Connection Error";
            this.sdklbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datasourcePasswordtxt
            // 
            this.datasourcePasswordtxt.Location = new System.Drawing.Point(287, 304);
            this.datasourcePasswordtxt.Name = "datasourcePasswordtxt";
            this.datasourcePasswordtxt.Size = new System.Drawing.Size(235, 20);
            this.datasourcePasswordtxt.TabIndex = 29;
            // 
            // datasourceNametxt
            // 
            this.datasourceNametxt.Location = new System.Drawing.Point(287, 253);
            this.datasourceNametxt.Name = "datasourceNametxt";
            this.datasourceNametxt.Size = new System.Drawing.Size(235, 20);
            this.datasourceNametxt.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(199, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(185, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Datasource";
            // 
            // datasourcelbl
            // 
            this.datasourcelbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.datasourcelbl.ForeColor = System.Drawing.Color.Red;
            this.datasourcelbl.Location = new System.Drawing.Point(229, 347);
            this.datasourcelbl.Name = "datasourcelbl";
            this.datasourcelbl.Size = new System.Drawing.Size(349, 23);
            this.datasourcelbl.TabIndex = 32;
            this.datasourcelbl.Text = "Connection Error";
            this.datasourcelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataSourceTestbtn
            // 
            this.dataSourceTestbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dataSourceTestbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataSourceTestbtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataSourceTestbtn.ForeColor = System.Drawing.Color.White;
            this.dataSourceTestbtn.Location = new System.Drawing.Point(554, 293);
            this.dataSourceTestbtn.Name = "dataSourceTestbtn";
            this.dataSourceTestbtn.Size = new System.Drawing.Size(109, 36);
            this.dataSourceTestbtn.TabIndex = 30;
            this.dataSourceTestbtn.Text = "Test";
            this.dataSourceTestbtn.UseVisualStyleBackColor = false;
            this.dataSourceTestbtn.Click += new System.EventHandler(this.dataSourceTestbtn_Click);
            // 
            // datasourcebtn
            // 
            this.datasourcebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.datasourcebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datasourcebtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.datasourcebtn.ForeColor = System.Drawing.Color.White;
            this.datasourcebtn.Location = new System.Drawing.Point(554, 242);
            this.datasourcebtn.Name = "datasourcebtn";
            this.datasourcebtn.Size = new System.Drawing.Size(109, 36);
            this.datasourcebtn.TabIndex = 33;
            this.datasourcebtn.Text = "Datasource";
            this.datasourcebtn.UseVisualStyleBackColor = false;
            this.datasourcebtn.Click += new System.EventHandler(this.dataSourcebtn_Click);
            // 
            // Sage50Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 557);
            this.Controls.Add(this.dataSourceTestbtn);
            this.Controls.Add(this.datasourcebtn);
            this.Controls.Add(this.datasourcelbl);
            this.Controls.Add(this.datasourcePasswordtxt);
            this.Controls.Add(this.datasourceNametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sdklbl);
            this.Controls.Add(this.successlbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.submitbtn);
            this.Controls.Add(this.sdkTestbtn);
            this.Controls.Add(this.companytxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sage50Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sage50";
            this.Load += new System.EventHandler(this.Sage50_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.Button sdkTestbtn;
        private System.Windows.Forms.TextBox companytxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label successlbl;
        private System.Windows.Forms.Label sdklbl;
        private System.Windows.Forms.TextBox datasourcePasswordtxt;
        private System.Windows.Forms.TextBox datasourceNametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label datasourcelbl;
        private System.Windows.Forms.Button dataSourceTestbtn;
        private System.Windows.Forms.Button datasourcebtn;
    }
}