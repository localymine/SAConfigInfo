﻿using Microsoft.Win32;
using System;
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
        private static readonly string[] WatchFolderPaths = new string[] {
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_4K",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_Full HD 1080p",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_HD720p",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_PREVIEW",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_SD480pwide",
            "AE_PROCESSING\\AE_RENDER\\WATCH_FOLDER_SD480p",
            "AE_PROCESSING\\TEMP_IMPORT",
        };

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
            Configuration.GetConfigInfo(FileName);
            if (Configuration.Info != null)
            {
                ConfigInfo ci = Configuration.Info;
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
                txtServicePath.Text = ci.StandAloneInfo.ServicePath;
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

                // set ServerInfo and si to the same values
                ci.ServerInfo = si;

                // create SQL Server info
                SQLServer ss = new SQLServer();
                ss.DataSource = txtDataSource.Text;
                ss.Catalog = txtCatalog.Text;
                ss.UserID = txtUserID.Text;
                ss.Password = txtPassword.Text;
                ss.ConnectionString = "";

                // set SQLServer and ss to the same values
                si.SQLServer = ss;

                // create Stand Alone Info
                StandAloneInfo sa = new StandAloneInfo();
                sa.IP = txtSAIPAddress.Text;
                sa.IPAddress = txtSAIPAddress.Text;
                sa.UserName = txtSAUserName.Text;
                sa.Password = txtSAPassword.Text;
                sa.ServicePath = txtServicePath.Text;
                sa.WatchFolderRoot = txtWatchFolderRoot.Text;

                WatchFolder[] watchFolderPaths = new WatchFolder[7];
                int i = 0;
                foreach (string path in WatchFolderPaths)
                {
                    WatchFolder wf = new WatchFolder();
                    wf.Path = Path.Combine(txtWatchFolderRoot.Text, path);
                    wf.NetworkPath = Path.Combine("\\", txtSAIPAddress.Text, path);
                    watchFolderPaths[i++] = wf;
                }
                sa.WatchFolderPaths = watchFolderPaths;

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
                sam.AEScriptPath = Path.Combine(sam.AEPath, "Support Files", "Scripts");
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
            fileName = Path.GetDirectoryName(GetPathForExe(fileName));
            return fileName.Replace("\\Support Files", "");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Application.ExitThread();
        }

        private void btnSVPathBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    txtServicePath.Text = fbd.SelectedPath;
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
    }
}
