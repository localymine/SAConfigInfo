namespace SA_Config_Info
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureHelp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureHelp
            // 
            this.pictureHelp.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pictureHelp.Image = ((System.Drawing.Image)(resources.GetObject("pictureHelp.Image")));
            this.pictureHelp.Location = new System.Drawing.Point(0, 0);
            this.pictureHelp.Margin = new System.Windows.Forms.Padding(0);
            this.pictureHelp.Name = "pictureHelp";
            this.pictureHelp.Size = new System.Drawing.Size(799, 809);
            this.pictureHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureHelp.TabIndex = 0;
            this.pictureHelp.TabStop = false;
            this.pictureHelp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureHelp_MouseDown);
            this.pictureHelp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureHelp_MouseMove);
            this.pictureHelp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureHelp_MouseUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 741);
            this.Controls.Add(this.pictureHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureHelp;
    }
}