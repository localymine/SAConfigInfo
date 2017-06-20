using SA_Config_Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallationSVWizard
{
    public partial class frmSVSource : Form
    {
        public frmSVSource()
        {
            InitializeComponent();
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGMAWeb.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGMARest.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnCdn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtGMACdn.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnInstallWeb_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInstallRest_Click(object sender, EventArgs e)
        {

        }

        private void btnInstallCdn_Click(object sender, EventArgs e)
        {

        }
    }
}
