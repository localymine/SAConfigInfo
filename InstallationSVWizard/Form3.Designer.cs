namespace InstallationSVWizard
{
    partial class frmSVSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSVSource));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGMAWeb = new System.Windows.Forms.TextBox();
            this.btnWeb = new System.Windows.Forms.Button();
            this.btnInstallWeb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGMARest = new System.Windows.Forms.TextBox();
            this.btnRest = new System.Windows.Forms.Button();
            this.btnInstallRest = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtGMACdn = new System.Windows.Forms.TextBox();
            this.btnCdn = new System.Windows.Forms.Button();
            this.btnInstallCdn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBarWEB = new System.Windows.Forms.ProgressBar();
            this.progressBarREST = new System.Windows.Forms.ProgressBar();
            this.progressBarCDN = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Install GMAWEB, GMAREST And GMACDN";
            // 
            // txtGMAWeb
            // 
            this.txtGMAWeb.Location = new System.Drawing.Point(85, 68);
            this.txtGMAWeb.Name = "txtGMAWeb";
            this.txtGMAWeb.Size = new System.Drawing.Size(284, 20);
            this.txtGMAWeb.TabIndex = 7;
            this.txtGMAWeb.Text = "C:\\inetpub\\wwwroot";
            // 
            // btnWeb
            // 
            this.btnWeb.Location = new System.Drawing.Point(369, 67);
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(75, 23);
            this.btnWeb.TabIndex = 8;
            this.btnWeb.Text = "Browser";
            this.btnWeb.UseVisualStyleBackColor = true;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // btnInstallWeb
            // 
            this.btnInstallWeb.Location = new System.Drawing.Point(85, 93);
            this.btnInstallWeb.Name = "btnInstallWeb";
            this.btnInstallWeb.Size = new System.Drawing.Size(75, 23);
            this.btnInstallWeb.TabIndex = 9;
            this.btnInstallWeb.Text = "Install";
            this.btnInstallWeb.UseVisualStyleBackColor = true;
            this.btnInstallWeb.Click += new System.EventHandler(this.btnInstallWeb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Install WEB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Install REST API";
            // 
            // txtGMARest
            // 
            this.txtGMARest.Location = new System.Drawing.Point(85, 171);
            this.txtGMARest.Name = "txtGMARest";
            this.txtGMARest.Size = new System.Drawing.Size(284, 20);
            this.txtGMARest.TabIndex = 7;
            this.txtGMARest.Text = "C:\\inetpub\\wwwroot";
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(369, 170);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(75, 23);
            this.btnRest.TabIndex = 8;
            this.btnRest.Text = "Browser";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // btnInstallRest
            // 
            this.btnInstallRest.Location = new System.Drawing.Point(85, 196);
            this.btnInstallRest.Name = "btnInstallRest";
            this.btnInstallRest.Size = new System.Drawing.Size(75, 23);
            this.btnInstallRest.TabIndex = 9;
            this.btnInstallRest.Text = "Install";
            this.btnInstallRest.UseVisualStyleBackColor = true;
            this.btnInstallRest.Click += new System.EventHandler(this.btnInstallRest_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(14, 263);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // txtGMACdn
            // 
            this.txtGMACdn.Location = new System.Drawing.Point(85, 279);
            this.txtGMACdn.Name = "txtGMACdn";
            this.txtGMACdn.Size = new System.Drawing.Size(284, 20);
            this.txtGMACdn.TabIndex = 7;
            this.txtGMACdn.Text = "D:\\";
            // 
            // btnCdn
            // 
            this.btnCdn.Location = new System.Drawing.Point(369, 278);
            this.btnCdn.Name = "btnCdn";
            this.btnCdn.Size = new System.Drawing.Size(75, 23);
            this.btnCdn.TabIndex = 8;
            this.btnCdn.Text = "Browser";
            this.btnCdn.UseVisualStyleBackColor = true;
            this.btnCdn.Click += new System.EventHandler(this.btnCdn_Click);
            // 
            // btnInstallCdn
            // 
            this.btnInstallCdn.Location = new System.Drawing.Point(85, 304);
            this.btnInstallCdn.Name = "btnInstallCdn";
            this.btnInstallCdn.Size = new System.Drawing.Size(75, 23);
            this.btnInstallCdn.TabIndex = 9;
            this.btnInstallCdn.Text = "Install";
            this.btnInstallCdn.UseVisualStyleBackColor = true;
            this.btnInstallCdn.Click += new System.EventHandler(this.btnInstallCdn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Install CDN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Please add more configuration from IIS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Please add more configuration from IIS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Please add more configuration from IIS";
            // 
            // progressBarWEB
            // 
            this.progressBarWEB.Location = new System.Drawing.Point(85, 87);
            this.progressBarWEB.Name = "progressBarWEB";
            this.progressBarWEB.Size = new System.Drawing.Size(284, 3);
            this.progressBarWEB.TabIndex = 13;
            // 
            // progressBarREST
            // 
            this.progressBarREST.Location = new System.Drawing.Point(85, 190);
            this.progressBarREST.Name = "progressBarREST";
            this.progressBarREST.Size = new System.Drawing.Size(284, 3);
            this.progressBarREST.TabIndex = 14;
            // 
            // progressBarCDN
            // 
            this.progressBarCDN.Location = new System.Drawing.Point(85, 298);
            this.progressBarCDN.Name = "progressBarCDN";
            this.progressBarCDN.Size = new System.Drawing.Size(284, 3);
            this.progressBarCDN.TabIndex = 15;
            // 
            // frmSVSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 372);
            this.Controls.Add(this.progressBarCDN);
            this.Controls.Add(this.progressBarREST);
            this.Controls.Add(this.progressBarWEB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInstallCdn);
            this.Controls.Add(this.btnInstallRest);
            this.Controls.Add(this.btnCdn);
            this.Controls.Add(this.btnInstallWeb);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.txtGMACdn);
            this.Controls.Add(this.btnWeb);
            this.Controls.Add(this.txtGMARest);
            this.Controls.Add(this.txtGMAWeb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSVSource";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Install Web & REST API";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGMAWeb;
        private System.Windows.Forms.Button btnWeb;
        private System.Windows.Forms.Button btnInstallWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGMARest;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.Button btnInstallRest;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtGMACdn;
        private System.Windows.Forms.Button btnCdn;
        private System.Windows.Forms.Button btnInstallCdn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBarWEB;
        private System.Windows.Forms.ProgressBar progressBarREST;
        private System.Windows.Forms.ProgressBar progressBarCDN;
    }
}