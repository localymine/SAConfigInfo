using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SA_Config_Info
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
            TextWriter writer = new StreamWriter("ConfigInfo.xml");
            ConfigInfo ci = new ConfigInfo();

            // create window server credential
            ServerInfo si = new ServerInfo();
            si.IP = txtSCIPAddress.Text;
            si.IPAddress = txtSCIPAddress.Text;
            si.UserName = txtSCUserName.Text;
            si.Password = txtSCPassword.Text;

            // set ServerInfo and si to the same values
            ci.ServerInfo = si;

            // create SQL Server info
            SQLServer ss = new SQLServer();
            ss.DataSource = txtDataSource.Text;
            ss.Catalog = txtCatalog.Text;
            ss.UserID = txtUserID.Text;
            ss.Password = txtPassword.Text;

            // set SQLServer and ss to the same values
            si.SQLServer = ss;

            // create Stand Alone Info
            StandAloneInfo sa = new StandAloneInfo();
            sa.IP = txtSAIPAddress.Text;
            sa.IPAddress = txtSAIPAddress.Text;
            sa.UserName = txtSAUserName.Text;
            sa.Password = txtSAPassword.Text;

            // create mission for Stand Alone Machine
            SAMachine sam = new SAMachine();
            sam.Type = 1;
            sam.Encoder = 3;
            sam.Mission = "ME";

            sa.SAMachine = sam;


            // set StandAloneInfo and sa to the same values
            ci.StandAloneInfo = sa;

            // Serialize the Configuration Information
            serializer.Serialize(writer, ci);
            writer.Close();
        }
    }
}
