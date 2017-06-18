namespace InstallationSVWizard
{
    partial class frm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm1));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfigureCredentials = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnCreateScheduleTasks = new System.Windows.Forms.Button();
            this.btnInstallCronJob = new System.Windows.Forms.Button();
            this.btnConfigureCronJob = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 64);
            this.label2.TabIndex = 4;
            this.label2.Text = "1. Configure the Connection of the Cron Job\r\n2. Install the Cron Job\r\n3. Create t" +
    "he Schedule Tasks";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Install Server Cron Job And Schedule Tasks";
            // 
            // btnConfigureCredentials
            // 
            this.btnConfigureCredentials.Location = new System.Drawing.Point(87, 125);
            this.btnConfigureCredentials.Name = "btnConfigureCredentials";
            this.btnConfigureCredentials.Size = new System.Drawing.Size(150, 23);
            this.btnConfigureCredentials.TabIndex = 10;
            this.btnConfigureCredentials.Text = "Configure Credentials";
            this.btnConfigureCredentials.UseVisualStyleBackColor = true;
            this.btnConfigureCredentials.Click += new System.EventHandler(this.btnConfigureCredentials_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(87, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 46);
            this.label3.TabIndex = 9;
            this.label3.Text = "Configure Window Credentials";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(13, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Location = new System.Drawing.Point(37, 90);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // btnCreateScheduleTasks
            // 
            this.btnCreateScheduleTasks.Location = new System.Drawing.Point(87, 316);
            this.btnCreateScheduleTasks.Name = "btnCreateScheduleTasks";
            this.btnCreateScheduleTasks.Size = new System.Drawing.Size(150, 23);
            this.btnCreateScheduleTasks.TabIndex = 13;
            this.btnCreateScheduleTasks.Text = "Create Schedule Tasks";
            this.btnCreateScheduleTasks.UseVisualStyleBackColor = true;
            this.btnCreateScheduleTasks.Click += new System.EventHandler(this.btnCreateScheduleTasks_Click);
            // 
            // btnInstallCronJob
            // 
            this.btnInstallCronJob.Location = new System.Drawing.Point(87, 286);
            this.btnInstallCronJob.Name = "btnInstallCronJob";
            this.btnInstallCronJob.Size = new System.Drawing.Size(150, 23);
            this.btnInstallCronJob.TabIndex = 12;
            this.btnInstallCronJob.Text = "Install Cron Job";
            this.btnInstallCronJob.UseVisualStyleBackColor = true;
            this.btnInstallCronJob.Click += new System.EventHandler(this.btnInstallCronJob_Click);
            // 
            // btnConfigureCronJob
            // 
            this.btnConfigureCronJob.Location = new System.Drawing.Point(87, 256);
            this.btnConfigureCronJob.Name = "btnConfigureCronJob";
            this.btnConfigureCronJob.Size = new System.Drawing.Size(150, 23);
            this.btnConfigureCronJob.TabIndex = 11;
            this.btnConfigureCronJob.Text = "Configure Cron Job";
            this.btnConfigureCronJob.UseVisualStyleBackColor = true;
            this.btnConfigureCronJob.Click += new System.EventHandler(this.btnConfigureCronJob_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 372);
            this.Controls.Add(this.btnCreateScheduleTasks);
            this.Controls.Add(this.btnInstallCronJob);
            this.Controls.Add(this.btnConfigureCronJob);
            this.Controls.Add(this.btnConfigureCredentials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Install Cron Job";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfigureCredentials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCreateScheduleTasks;
        private System.Windows.Forms.Button btnInstallCronJob;
        private System.Windows.Forms.Button btnConfigureCronJob;
    }
}