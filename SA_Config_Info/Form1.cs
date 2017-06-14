using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SA_Config_Info
{
    public partial class Form1 : Form
    {
        private string FileName = "ConfigInfo.xml";

        public Form1()
        {
            InitializeComponent();
            //

            if (GetLocalIPv4(NetworkInterfaceType.Ethernet) != "")
            {
                txtSAIPAddress.Text = GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
            else
            {
                txtSAIPAddress.Text = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
                serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

                FileStream fs = new FileStream(FileName, FileMode.Open);

                ConfigInfo ci;
                ci = (ConfigInfo)serializer.Deserialize(fs);

                txtSCIPAddress.Text = ci.ServerInfo.IPAddress;
                txtSCUserName.Text = ci.ServerInfo.UserName;
                txtSCPassword.Text = ci.ServerInfo.Password;
                txtDataSource.Text = ci.ServerInfo.SQLServer.DataSource;
                txtCatalog.Text = ci.ServerInfo.SQLServer.Catalog;
                txtUserID.Text = ci.ServerInfo.SQLServer.UserID;
                txtPassword.Text = ci.ServerInfo.SQLServer.Password;
                txtSAIPAddress.Text = ci.StandAloneInfo.IPAddress;
                txtSAUserName.Text = ci.StandAloneInfo.UserName;
                txtSAPassword.Text = ci.StandAloneInfo.Password;

                SARadioTypeReflect(ci.StandAloneInfo.SAMachine);
                SARadioEncoderReflect(ci.StandAloneInfo.SAMachine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
            TextWriter writer = new StreamWriter(FileName);
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
            SADefination saDefine = new SADefination();

            var checkedRadio = new[] { panel1 }
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));
            
            foreach (var c in checkedRadio)
            {
                saDefine.Mission = c.Name;
                saDefine.Type = c.Name;
            }

            checkedRadio = new[] { panel2 }
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));

            foreach (var c in checkedRadio)
            {
                saDefine.Resolution = c.Name;
                saDefine.Encoder = c.Name;
            }

            sam.Mission = saDefine.Mission;
            sam.Resolution = saDefine.Resolution;
            sam.Type = saDefine.Type;
            sam.Encoder = saDefine.Encoder;

            sa.SAMachine = sam;

            // set StandAloneInfo and sa to the same values
            ci.StandAloneInfo = sa;

            // Serialize the Configuration Information
            serializer.Serialize(writer, ci);
            writer.Close();
        }

        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }

        protected void SARadioTypeReflect(SAMachine sam)
        {
            string radioName = SADefination.GetMissionByValue(sam.Type);
            RadioButton rdButton = Controls.Find(radioName, true).FirstOrDefault() as RadioButton;
            if (rdButton != null)
            {
                rdButton.Checked = Enabled;
            }
        }

        protected void SARadioEncoderReflect(SAMachine sam)
        {
            string radioName = SADefination.GetResolutionByValue(sam.Encoder);
            RadioButton rdButton = Controls.Find(radioName, true).FirstOrDefault() as RadioButton;
            if (rdButton != null)
            {
                rdButton.Checked = Enabled;
            }
        }
    }
}
