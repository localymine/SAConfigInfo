using System;
using System.Linq;
using System.Windows.Forms;

namespace InstallationSVWizard
{
    public partial class frmParent : Form
    {
        Form[] frm = { new frmSVSource(), new frm1() };
        int top = -1;
        int count;

        public frmParent()
        {
            count = frm.Count();
            InitializeComponent();
        }

        private void LoadNewForm()
        {
            frm[top].TopLevel = false;
            frm[top].Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frm[top]);
            frm[top].Show();
        }

        private void Next()
        {
            top++;
            if (top >= count)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top + 1 == count)
                {
                    btnNext.Enabled = false;
                }
            }

            if (top <= 0)
            {
                btnBack.Enabled = false;
            }
        }

        private void Back()
        {
            top--;
            if (top <= -1)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top - 1 <= -1)
                {
                    btnBack.Enabled = false;
                }
            }

            if (top >= count)
            {
                btnNext.Enabled = false;
            }
        }

        private void frmParent_Load(object sender, EventArgs e)
        {
            Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
