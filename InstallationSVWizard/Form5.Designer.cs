namespace InstallationSVWizard
{
    partial class frmDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabase));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lsbBackupFiles = new System.Windows.Forms.ListBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lsbCurrentDB = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCurrentServer = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Restore DataBase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "List Backup Database";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lsbBackupFiles
            // 
            this.lsbBackupFiles.FormattingEnabled = true;
            this.lsbBackupFiles.Location = new System.Drawing.Point(86, 68);
            this.lsbBackupFiles.Name = "lsbBackupFiles";
            this.lsbBackupFiles.Size = new System.Drawing.Size(168, 69);
            this.lsbBackupFiles.TabIndex = 19;
            this.lsbBackupFiles.SelectedIndexChanged += new System.EventHandler(this.lsbBackupFiles_SelectedIndexChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(86, 182);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(150, 23);
            this.btnRestore.TabIndex = 20;
            this.btnRestore.Text = "Restore Database";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lsbCurrentDB
            // 
            this.lsbCurrentDB.FormattingEnabled = true;
            this.lsbCurrentDB.Location = new System.Drawing.Point(286, 95);
            this.lsbCurrentDB.Name = "lsbCurrentDB";
            this.lsbCurrentDB.Size = new System.Drawing.Size(168, 82);
            this.lsbCurrentDB.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Current Database";
            // 
            // cbCurrentServer
            // 
            this.cbCurrentServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentServer.FormattingEnabled = true;
            this.cbCurrentServer.Location = new System.Drawing.Point(286, 68);
            this.cbCurrentServer.Name = "cbCurrentServer";
            this.cbCurrentServer.Size = new System.Drawing.Size(168, 21);
            this.cbCurrentServer.TabIndex = 23;
            this.cbCurrentServer.SelectedIndexChanged += new System.EventHandler(this.cbCurrentServer_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(258, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(86, 156);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(168, 20);
            this.txtDatabaseName.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Database Name";
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(462, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbCurrentServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsbCurrentDB);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lsbBackupFiles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDatabase";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lsbBackupFiles;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ListBox lsbCurrentDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCurrentServer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label4;
    }
}