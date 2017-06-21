namespace InstallationWizard
{
    partial class frm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfigureCredentials = new System.Windows.Forms.Button();
            this.btnConfigureCronJob = new System.Windows.Forms.Button();
            this.btnInstallCronJob = new System.Windows.Forms.Button();
            this.btnCreateScheduleTasks = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Install Cron Job && Schedule Tasks";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 64);
            this.label2.TabIndex = 2;
            this.label2.Text = "1. Configure the Connection of the Cron Job\r\n2. Install the Cron Job\r\n3. Share \"T" +
    "EMP_FOLDER_EXPORT\" Folder\r\n4. Create the Schedule Tasks";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(87, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 46);
            this.label3.TabIndex = 5;
            this.label3.Text = "Configure Window Credentials";
            // 
            // btnConfigureCredentials
            // 
            this.btnConfigureCredentials.Location = new System.Drawing.Point(87, 125);
            this.btnConfigureCredentials.Name = "btnConfigureCredentials";
            this.btnConfigureCredentials.Size = new System.Drawing.Size(150, 23);
            this.btnConfigureCredentials.TabIndex = 6;
            this.btnConfigureCredentials.Text = "Configure Credentials";
            this.btnConfigureCredentials.UseVisualStyleBackColor = true;
            this.btnConfigureCredentials.Click += new System.EventHandler(this.btnConfigureCredentials_Click);
            // 
            // btnConfigureCronJob
            // 
            this.btnConfigureCronJob.Location = new System.Drawing.Point(87, 257);
            this.btnConfigureCronJob.Name = "btnConfigureCronJob";
            this.btnConfigureCronJob.Size = new System.Drawing.Size(150, 23);
            this.btnConfigureCronJob.TabIndex = 7;
            this.btnConfigureCronJob.Text = "Configure Cron Job";
            this.btnConfigureCronJob.UseVisualStyleBackColor = true;
            this.btnConfigureCronJob.Click += new System.EventHandler(this.btnConfigureCronJob_Click);
            // 
            // btnInstallCronJob
            // 
            this.btnInstallCronJob.Location = new System.Drawing.Point(87, 287);
            this.btnInstallCronJob.Name = "btnInstallCronJob";
            this.btnInstallCronJob.Size = new System.Drawing.Size(150, 23);
            this.btnInstallCronJob.TabIndex = 8;
            this.btnInstallCronJob.Text = "Install Cron Job";
            this.btnInstallCronJob.UseVisualStyleBackColor = true;
            this.btnInstallCronJob.Click += new System.EventHandler(this.btnInstallCronJob_Click);
            // 
            // btnCreateScheduleTasks
            // 
            this.btnCreateScheduleTasks.Location = new System.Drawing.Point(87, 317);
            this.btnCreateScheduleTasks.Name = "btnCreateScheduleTasks";
            this.btnCreateScheduleTasks.Size = new System.Drawing.Size(150, 23);
            this.btnCreateScheduleTasks.TabIndex = 9;
            this.btnCreateScheduleTasks.Text = "Create Schedule Tasks";
            this.btnCreateScheduleTasks.UseVisualStyleBackColor = true;
            this.btnCreateScheduleTasks.Click += new System.EventHandler(this.btnCreateScheduleTasks_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(13, 76);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 372);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnCreateScheduleTasks);
            this.Controls.Add(this.btnInstallCronJob);
            this.Controls.Add(this.btnConfigureCronJob);
            this.Controls.Add(this.btnConfigureCredentials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm2";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Install Cron Job And Schedule Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfigureCredentials;
        private System.Windows.Forms.Button btnConfigureCronJob;
        private System.Windows.Forms.Button btnInstallCronJob;
        private System.Windows.Forms.Button btnCreateScheduleTasks;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}