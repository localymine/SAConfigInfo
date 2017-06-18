using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace InstallationSVWizard
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
        }

        private void btnConfigureCredentials_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigureCronJob_Click(object sender, EventArgs e)
        {

        }

        private void btnInstallCronJob_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(Environment.CurrentDirectory, "InstallSVCronJob.exe");
            startInfo.WorkingDirectory = Path.GetDirectoryName(startInfo.FileName);

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {

            }
        }

        private void btnCreateScheduleTasks_Click(object sender, EventArgs e)
        {

        }

    }
}
