using System;
using System.Windows.Forms;
using CredentialManagement;
using SA_Config_Info;

namespace InstallationSVWizard
{
    public partial class frmCredential : Form
    {
        private bool toggle = false;

        public frmCredential()
        {
            InitializeComponent();

            try
            {
                Configuration.GetConfigInfo("ConfigInfo.xml");
                txtSAIP.Text = Configuration.Info.StandAloneInfo.IPAddress;
                txtSAUserName.Text = Configuration.Info.StandAloneInfo.UserName;
                txtSAPassword.Text = Configuration.Info.StandAloneInfo.Password;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigureCredential_Click(object sender, EventArgs e)
        {
            Credential t = new Credential();
            t.Target = txtSAIP.Text;
            t.Username = txtSAUserName.Text;
            t.Password = txtSAPassword.Text;
            t.Type = CredentialType.DomainPassword;
            t.PersistanceType = PersistanceType.Enterprise;
            t.Save();
            MessageBox.Show("Successfull Installed");
        }

        private void frmCredential_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.Alt && e.Shift && e.KeyCode == Keys.K) 
            {
                if (toggle == false)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        ctrl.Enabled = true;
                    }
                    toggle = true;
                }
                else
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                    toggle = false;
                }
            }
        }

        //private UserPrincipal CreateUser(string Username, string Password)
        //{
        //    PrincipalContext pc = new PrincipalContext(ContextType.Machine, Environment.MachineName);
        //    UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, Username);
        //    if (up == null)
        //    {
        //        up = new UserPrincipal(pc, Username, Password, true);
        //        up.UserCannotChangePassword = false;
        //        up.PasswordNeverExpires = false;
        //        up.Save(); // this is where it crashes when I run through the debugger
        //    }
        //    return up;
        //}
        //private void AddGroup(UserPrincipal Up, string GroupName)
        //{
        //    PrincipalContext pc = new PrincipalContext(ContextType.Machine, Environment.MachineName);
        //    GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, GroupName);
        //    if (!gp.Members.Contains(Up))
        //    {
        //        gp.Members.Add(Up);
        //        gp.Save();
        //    }
        //    gp.Dispose();
        //}
        //private void CreateProfile(UserPrincipal Up)
        //{
        //    int MaxPath = 240;
        //    StringBuilder pathBuf = new StringBuilder(MaxPath);
        //    uint pathLen = (uint)pathBuf.Capacity;
        //    int Res = CreateProfile(Up.Sid.ToString(), Up.SamAccountName, pathBuf, pathLen);
        //}
    }
}
