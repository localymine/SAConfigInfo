﻿namespace SA_Config_Info
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rd4K = new System.Windows.Forms.RadioButton();
            this.rdHD1080p = new System.Windows.Forms.RadioButton();
            this.rdHD720p = new System.Windows.Forms.RadioButton();
            this.rdSD480pwide = new System.Windows.Forms.RadioButton();
            this.rdSD480p = new System.Windows.Forms.RadioButton();
            this.rdPreview = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSAPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSAUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdBoth = new System.Windows.Forms.RadioButton();
            this.rdME = new System.Windows.Forms.RadioButton();
            this.rdAE = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSAIPAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSCPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSCUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSCIPAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCatalog);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDataSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Connection";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(253, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(80, 81);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(253, 20);
            this.txtUserID.TabIndex = 6;
            this.txtUserID.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User ID";
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(80, 54);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(253, 20);
            this.txtCatalog.TabIndex = 5;
            this.txtCatalog.Text = "GMA_DB_PROD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initial Catalog";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(80, 27);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(253, 20);
            this.txtDataSource.TabIndex = 4;
            this.txtDataSource.Text = "WEBSERVER001\\SQLEXPRESS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSAPassword);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSAUserName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSAIPAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 200);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SA Information";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rd4K);
            this.panel2.Controls.Add(this.rdHD1080p);
            this.panel2.Controls.Add(this.rdHD720p);
            this.panel2.Controls.Add(this.rdSD480pwide);
            this.panel2.Controls.Add(this.rdSD480p);
            this.panel2.Controls.Add(this.rdPreview);
            this.panel2.Location = new System.Drawing.Point(80, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 51);
            this.panel2.TabIndex = 12;
            // 
            // rd4K
            // 
            this.rd4K.AutoSize = true;
            this.rd4K.Location = new System.Drawing.Point(176, 27);
            this.rd4K.Name = "rd4K";
            this.rd4K.Size = new System.Drawing.Size(38, 17);
            this.rd4K.TabIndex = 5;
            this.rd4K.TabStop = true;
            this.rd4K.Text = "4K";
            this.rd4K.UseVisualStyleBackColor = true;
            // 
            // rdHD1080p
            // 
            this.rdHD1080p.AutoSize = true;
            this.rdHD1080p.Location = new System.Drawing.Point(76, 27);
            this.rdHD1080p.Name = "rdHD1080p";
            this.rdHD1080p.Size = new System.Drawing.Size(93, 17);
            this.rdHD1080p.TabIndex = 4;
            this.rdHD1080p.TabStop = true;
            this.rdHD1080p.Text = "Full HD 1080p";
            this.rdHD1080p.UseVisualStyleBackColor = true;
            // 
            // rdHD720p
            // 
            this.rdHD720p.AutoSize = true;
            this.rdHD720p.Location = new System.Drawing.Point(4, 27);
            this.rdHD720p.Name = "rdHD720p";
            this.rdHD720p.Size = new System.Drawing.Size(65, 17);
            this.rdHD720p.TabIndex = 3;
            this.rdHD720p.TabStop = true;
            this.rdHD720p.Text = "HD720p";
            this.rdHD720p.UseVisualStyleBackColor = true;
            // 
            // rdSD480pwide
            // 
            this.rdSD480pwide.AutoSize = true;
            this.rdSD480pwide.Location = new System.Drawing.Point(145, 3);
            this.rdSD480pwide.Name = "rdSD480pwide";
            this.rdSD480pwide.Size = new System.Drawing.Size(86, 17);
            this.rdSD480pwide.TabIndex = 2;
            this.rdSD480pwide.TabStop = true;
            this.rdSD480pwide.Text = "SD480pwide";
            this.rdSD480pwide.UseVisualStyleBackColor = true;
            // 
            // rdSD480p
            // 
            this.rdSD480p.AutoSize = true;
            this.rdSD480p.Location = new System.Drawing.Point(74, 3);
            this.rdSD480p.Name = "rdSD480p";
            this.rdSD480p.Size = new System.Drawing.Size(64, 17);
            this.rdSD480p.TabIndex = 1;
            this.rdSD480p.TabStop = true;
            this.rdSD480p.Text = "SD480p";
            this.rdSD480p.UseVisualStyleBackColor = true;
            // 
            // rdPreview
            // 
            this.rdPreview.AutoSize = true;
            this.rdPreview.Location = new System.Drawing.Point(4, 3);
            this.rdPreview.Name = "rdPreview";
            this.rdPreview.Size = new System.Drawing.Size(63, 17);
            this.rdPreview.TabIndex = 0;
            this.rdPreview.TabStop = true;
            this.rdPreview.Text = "Preview";
            this.rdPreview.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Encoder";
            // 
            // txtSAPassword
            // 
            this.txtSAPassword.Location = new System.Drawing.Point(80, 78);
            this.txtSAPassword.Name = "txtSAPassword";
            this.txtSAPassword.Size = new System.Drawing.Size(253, 20);
            this.txtSAPassword.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Password";
            // 
            // txtSAUserName
            // 
            this.txtSAUserName.Location = new System.Drawing.Point(80, 51);
            this.txtSAUserName.Name = "txtSAUserName";
            this.txtSAUserName.Size = new System.Drawing.Size(253, 20);
            this.txtSAUserName.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "User Name";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdBoth);
            this.panel1.Controls.Add(this.rdME);
            this.panel1.Controls.Add(this.rdAE);
            this.panel1.Location = new System.Drawing.Point(80, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 26);
            this.panel1.TabIndex = 11;
            // 
            // rdBoth
            // 
            this.rdBoth.AutoSize = true;
            this.rdBoth.Location = new System.Drawing.Point(182, 4);
            this.rdBoth.Name = "rdBoth";
            this.rdBoth.Size = new System.Drawing.Size(67, 17);
            this.rdBoth.TabIndex = 2;
            this.rdBoth.TabStop = true;
            this.rdBoth.Text = "AE + ME";
            this.rdBoth.UseVisualStyleBackColor = true;
            // 
            // rdME
            // 
            this.rdME.AutoSize = true;
            this.rdME.Location = new System.Drawing.Point(92, 4);
            this.rdME.Name = "rdME";
            this.rdME.Size = new System.Drawing.Size(41, 17);
            this.rdME.TabIndex = 1;
            this.rdME.TabStop = true;
            this.rdME.Text = "ME";
            this.rdME.UseVisualStyleBackColor = true;
            // 
            // rdAE
            // 
            this.rdAE.AutoSize = true;
            this.rdAE.Location = new System.Drawing.Point(4, 4);
            this.rdAE.Name = "rdAE";
            this.rdAE.Size = new System.Drawing.Size(39, 17);
            this.rdAE.TabIndex = 0;
            this.rdAE.TabStop = true;
            this.rdAE.Text = "AE";
            this.rdAE.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "SA Type";
            // 
            // txtSAIPAddress
            // 
            this.txtSAIPAddress.Location = new System.Drawing.Point(80, 24);
            this.txtSAIPAddress.Name = "txtSAIPAddress";
            this.txtSAIPAddress.Size = new System.Drawing.Size(253, 20);
            this.txtSAIPAddress.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP Address";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSCPassword);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSCUserName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtSCIPAddress);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 111);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Window Server Credential";
            // 
            // txtSCPassword
            // 
            this.txtSCPassword.Location = new System.Drawing.Point(80, 77);
            this.txtSCPassword.Name = "txtSCPassword";
            this.txtSCPassword.Size = new System.Drawing.Size(253, 20);
            this.txtSCPassword.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Password";
            // 
            // txtSCUserName
            // 
            this.txtSCUserName.Location = new System.Drawing.Point(80, 50);
            this.txtSCUserName.Name = "txtSCUserName";
            this.txtSCUserName.Size = new System.Drawing.Size(253, 20);
            this.txtSCUserName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "User Name";
            // 
            // txtSCIPAddress
            // 
            this.txtSCIPAddress.Location = new System.Drawing.Point(80, 23);
            this.txtSCIPAddress.Name = "txtSCIPAddress";
            this.txtSCIPAddress.Size = new System.Drawing.Size(253, 20);
            this.txtSCIPAddress.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "IP Address";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 485);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(168, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Import SA Info";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(183, 485);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(168, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export SA Info";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 518);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SA Configuration Information";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdBoth;
        private System.Windows.Forms.RadioButton rdME;
        private System.Windows.Forms.RadioButton rdAE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSAIPAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSCUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSCIPAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rd4K;
        private System.Windows.Forms.RadioButton rdHD1080p;
        private System.Windows.Forms.RadioButton rdHD720p;
        private System.Windows.Forms.RadioButton rdSD480pwide;
        private System.Windows.Forms.RadioButton rdSD480p;
        private System.Windows.Forms.RadioButton rdPreview;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSAPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSAUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSCPassword;
        private System.Windows.Forms.Label label9;
    }
}

