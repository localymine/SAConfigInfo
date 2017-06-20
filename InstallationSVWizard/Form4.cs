using System;
using System.Windows.Forms;


namespace InstallationSVWizard
{
    public partial class frmCredential : Form
    {
        public frmCredential()
        {
            InitializeComponent();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigureCredential_Click(object sender, EventArgs e)
        {

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
