using Microsoft.Win32;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.AxHost;

namespace SA_Config_Info
{
    public partial class Form1 : Form
    {
        private string FileName = "ConfigInfo.xml";
        private static readonly string[] WatchFolderPaths = new string[] {
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_4K",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_Full HD 1080p",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_HD720p",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_PREVIEW",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_SD480pwide",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_SD480p",
            "AE_PROCESSING\\TEMP_IMPORT",
        };
        private static readonly string[] SVServiceFolderPaths = new string[]
        {
            "WindowsService\\GMA_SV_AssignAfterEffectService",
            "WindowsService\\GMA_SV_CheckTimeOutService",
            "WindowsService\\GMA_SV_NotificationService",
        };
        private static readonly string[] SAServiceFolderPaths = new string[]
        {
            "WindowsService\\GMA_SA_AE_ExportTemplateService",
            "WindowsService\\GMA_SA_AfterEffectService",
            "WindowsService\\GMA_SA_ME_CheckRenderedVideoService",
            "WindowsService\\GMA_SA_ME_MediaEncoderService",
        };

        public Form1()
        {
            InitializeComponent();
            //

            lbRegion.Text = RegionInfo.CurrentRegion.Name;

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
            Configuration.GetConfigInfo(FileName);
            if (Configuration.Info != null)
            {
                ConfigInfo ci = Configuration.Info;
                txtSCIPAddress.Text = ci.ServerInfo.IPAddress;
                txtSCUserName.Text = ci.ServerInfo.UserName;
                txtSCPassword.Text = ci.ServerInfo.Password;
                txtSVServicePath.Text = ci.ServerInfo.ServicePath;
                txtDataSource.Text = ci.ServerInfo.SQLServer.DataSource;
                txtCatalog.Text = ci.ServerInfo.SQLServer.Catalog;
                txtUserID.Text = ci.ServerInfo.SQLServer.UserID;
                txtPassword.Text = ci.ServerInfo.SQLServer.Password;
                txtSAIPAddress.Text = ci.StandAloneInfo.IPAddress;
                txtSAUserName.Text = ci.StandAloneInfo.UserName;
                txtSAPassword.Text = ci.StandAloneInfo.Password;
                txtSAServicePath.Text = ci.StandAloneInfo.ServicePath;
                txtWatchFolderRoot.Text = ci.StandAloneInfo.WatchFolderRoot;

                SARadioTypeReflect(ci.StandAloneInfo.SAMachine);
                SARadioEncoderReflect(ci.StandAloneInfo.SAMachine);
                SARadioAdobeVersionReflect(ci.StandAloneInfo.SAMachine);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
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
                si.ServicePath = txtSVServicePath.Text;

                SVServiceFolder[] svServiceFolderPaths = new SVServiceFolder[3];
                int i = 0;
                foreach (string path in SVServiceFolderPaths)
                {
                    SVServiceFolder svsf = new SVServiceFolder();
                    svsf.Path = Path.Combine(txtSVServicePath.Text, path);
                    svServiceFolderPaths[i++] = svsf;
                }
                si.SVServicePaths = svServiceFolderPaths;

                // set ServerInfo and si to the same values
                ci.ServerInfo = si;

                // create SQL Server info
                SQLServer ss = new SQLServer();
                ss.DataSource = txtDataSource.Text;
                ss.Catalog = txtCatalog.Text;
                ss.UserID = txtUserID.Text;
                ss.Password = txtPassword.Text;
                ss.ConnectionString = "";
                ss.AppSettingValue = "";

                // set SQLServer and ss to the same values
                si.SQLServer = ss;

                // create Stand Alone Info
                StandAloneInfo sa = new StandAloneInfo();
                sa.IP = txtSAIPAddress.Text;
                sa.IPAddress = txtSAIPAddress.Text;
                sa.UserName = txtSAUserName.Text;
                sa.Password = txtSAPassword.Text;
                sa.ServicePath = txtSAServicePath.Text;
                sa.WatchFolderRoot = txtWatchFolderRoot.Text;

                WatchFolder[] watchFolderPaths = new WatchFolder[7];
                i = 0;
                foreach (string path in WatchFolderPaths)
                {
                    WatchFolder wf = new WatchFolder();
                    wf.Path = Path.Combine(txtWatchFolderRoot.Text, path);
                    wf.NetworkPath = Path.Combine("\\", txtSAIPAddress.Text, path);
                    watchFolderPaths[i++] = wf;
                }
                sa.WatchFolderPaths = watchFolderPaths;

                SAServiceFolder[] saServiceFolderPaths = new SAServiceFolder[4];
                i = 0;
                foreach (string path in SAServiceFolderPaths)
                {
                    SAServiceFolder sasf = new SAServiceFolder();
                    sasf.Path = Path.Combine(txtSAServicePath.Text, path);
                    saServiceFolderPaths[i++] = sasf;
                }
                sa.SAServicePaths = saServiceFolderPaths;

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

                checkedRadio = new[] { panel3 }
                       .SelectMany(g => g.Controls.OfType<RadioButton>()
                                                .Where(r => r.Checked));

                foreach (var c in checkedRadio)
                {
                    saDefine.AdobeVersion = c.Name;
                }

                sam.MachineName = Environment.MachineName;
                sam.Author = Environment.UserName;
                sam.Mission = saDefine.Mission;
                sam.Resolution = saDefine.Resolution;
                sam.Type = saDefine.Type;
                sam.Encoder = saDefine.Encoder;
                sam.AdobeVersion = saDefine.AdobeVersion;
                sam.AEPath = GetPathNoneExe("AfterFX.exe");
                sam.AEScriptPath = Path.Combine(sam.AEPath, "Scripts");
                sam.MEPath = GetPathNoneExe("Adobe Media Encoder.exe");

                sa.SAMachine = sam;

                // set StandAloneInfo and sa to the same values
                ci.StandAloneInfo = sa;

                // Serialize the Configuration Information
                serializer.Serialize(writer, ci);
                writer.Close();

                MessageBox.Show("Export XML Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        protected void SARadioTypeReflect(SAMachine sam)
        {
            try
            {
                string radioName = SADefination.GetMissionByValue(sam.Type);
                RadioButton rdButton = Controls.Find(radioName, true).FirstOrDefault() as RadioButton;
                if (rdButton != null)
                {
                    rdButton.Checked = Enabled;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        protected void SARadioEncoderReflect(SAMachine sam)
        {
            try
            {
                string radioName = SADefination.GetResolutionByValue(sam.Encoder);
                RadioButton rdButton = Controls.Find(radioName, true).FirstOrDefault() as RadioButton;
                if (rdButton != null)
                {
                    rdButton.Checked = Enabled;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void SARadioAdobeVersionReflect(SAMachine sam)
        {
            try
            {
                string radioName = SADefination.GetAdobeVersionByValue(sam.AdobeVersion);
                RadioButton rdButton = Controls.Find(radioName, true).FirstOrDefault() as RadioButton;
                if (rdButton != null)
                {
                    rdButton.Checked = Enabled;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private const string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        private string GetPathForExe(string fileName)
        {
            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey fileKey = localMachine.OpenSubKey(string.Format(@"{0}\{1}", keyBase, fileName));
            object result = null;
            if (fileKey != null)
            {
                result = fileKey.GetValue(string.Empty);
            }
            fileKey.Close();

            return result.ToString().Replace("\"", "");
        }
        
        private string GetPathNoneExe(string fileName)
        {
            return  Path.GetDirectoryName(GetPathForExe(fileName));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Application.ExitThread();
        }

        private void btnSAServicePathBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSAServicePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnWatchBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtWatchFolderRoot.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSVServicePathBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSVServicePath.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
