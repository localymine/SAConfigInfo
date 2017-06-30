using Microsoft.Win32;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Collections.Generic;

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
            "AE_PROCESSING",
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
            "WindowsService\\GMA_SA_AEME_CheckNotRespondingService",
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
                SACheckEncoderReflect(ci.StandAloneInfo.SAMachine);

                txtAEfqdn.Text = ci.StandAloneInfo.SAMachine.AEFQDN;
                txtMEfqdn.Text = ci.StandAloneInfo.SAMachine.MEFQDN;

                SARadioAdobeVersionReflect(ci.StandAloneInfo.SAMachine);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(FileName);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
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
                ss.SessionState = "";

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
                sa.SAWatchFolderPath = Path.Combine("\\\\", txtSAIPAddress.Text, "AE_PROCESSING\\AE_RENDER");
                sa.SATempFolderPath = Path.Combine("\\\\", txtSAIPAddress.Text, "AE_PROCESSING\\TEMP_IMPORT");
                sa.SATempFolderLocalPath = Path.Combine("\\\\", txtSAIPAddress.Text, "AE_PROCESSING\\TEMP_IMPORT"); ;

                WatchFolder[] watchFolderPaths = new WatchFolder[8];
                i = 0;
                foreach (string path in WatchFolderPaths)
                {
                    WatchFolder wf = new WatchFolder();
                    wf.Path = Path.Combine(txtWatchFolderRoot.Text, path);
                    wf.NetworkPath = Path.Combine("\\", txtSAIPAddress.Text, path);
                    watchFolderPaths[i++] = wf;
                }
                sa.WatchFolderPaths = watchFolderPaths;

                SAServiceFolder[] saServiceFolderPaths = new SAServiceFolder[5];
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

                var checkedCheckbox = new[] { panel2 }
                       .SelectMany(g => g.Controls.OfType<CheckBox>()
                                                .Where(r => r.Checked));
                Encoder[] grEncoders = new Encoder[6];
                i = 0;
                foreach (var c in checkedCheckbox)
                {
                    Encoder en = new Encoder();
                    en.ID = SADefination.GetResolutionByKey(c.Name, 1);
                    en.Name = c.Name;
                    en.WatchFolderName = SADefination.GetResolutionByKey(c.Name, 2);
                    grEncoders[i++] = en;
                }
                sam.Encoders = grEncoders;

                if (rdAE.Checked == true)
                {
                    sam.AEFQDN = txtAEfqdn.Text;
                }
                else if (rdME.Checked == true)
                {
                    sam.MEFQDN = txtMEfqdn.Text;
                }
                else
                {
                    sam.AEFQDN = txtAEfqdn.Text;
                    sam.MEFQDN = txtMEfqdn.Text;
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
                sam.Type = saDefine.Type;

                sam.AdobeVersion = saDefine.AdobeVersion;
                string tmpAEPath = GetPathNoneExe("AfterFX.exe");
                if (!String.IsNullOrEmpty(tmpAEPath) && tmpAEPath.Contains(sam.AdobeVersion))
                {
                    sam.AEPath = tmpAEPath;
                    sam.AEPathExe = GetPathForExe("AfterFX.exe");
                    sam.AEProcessName = Path.GetFileName(sam.AEPathExe).Replace(".exe", "");
                    sam.AEScriptPath = Path.Combine(sam.AEPath, "Scripts");
                }
                string tmpMEPath = GetPathNoneExe("Adobe Media Encoder.exe");
                if (!String.IsNullOrEmpty(tmpMEPath) && tmpMEPath.Contains(sam.AdobeVersion))
                {
                    sam.MEPath = tmpMEPath;
                    sam.MEPathExe = GetPathForExe("Adobe Media Encoder.exe");
                    sam.MEProcessName = Path.GetFileName(sam.MEPathExe).Replace(".exe", "");
                }

                List<string> listTemp;
                DBProcess db = new DBProcess(txtDataSource.Text, txtCatalog.Text, txtUserID.Text, txtPassword.Text);
                List<KeyValuePair<string, string>> listTempKeyValue =  db.GetTempPath();

                listTemp = listTempKeyValue.Where(x => x.Key == "TempFilePathExport").Select(x => x.Value).ToList();
                sam.AEExportProjectPath = txtSAServicePath.Text + @"\\WindowsService\\GMA_SA_AE_ExportTemplateService\\" + listTemp[0].ToString();

                listTemp = listTempKeyValue.Where(x => x.Key == "TempFilePathImport").Select(x => x.Value).ToList();
                sam.AEProjectPath = txtSAServicePath.Text + @"\\WindowsService\\GMA_SA_AfterEffectService\\" + listTemp[0].ToString();

                sa.SAMachine = sam;

                // set StandAloneInfo and sa to the same values
                ci.StandAloneInfo = sa;

                // Serialize the Configuration Information
                serializer.Serialize(writer, ci);

                MessageBox.Show("Export XML Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer.Close();
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

        protected void SACheckEncoderReflect(SAMachine sam)
        {
            try
            {
                var checkedCheckbox = new[] { panel2 }
                       .SelectMany(g => g.Controls.OfType<CheckBox>()
                                                .Where(r => r.Checked));
                foreach (var c in checkedCheckbox)
                {
                    c.Checked = false;
                }
                //
                Encoder[] grEncodes = sam.Encoders;
                foreach (Encoder item in grEncodes)
                {
                    CheckBox ckButton = Controls.Find(item.Name, true).FirstOrDefault() as CheckBox;
                    if (ckButton != null)
                    {
                        ckButton.Checked = Enabled;
                    }
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

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void rdAE_CheckedChanged(object sender, EventArgs e)
        {
            txtAEfqdn.Enabled = true;
            txtMEfqdn.Enabled = false;
        }

        private void rdME_CheckedChanged(object sender, EventArgs e)
        {
            txtAEfqdn.Enabled = false;
            txtMEfqdn.Enabled = true;
        }

        private void rdBoth_CheckedChanged(object sender, EventArgs e)
        {
            txtAEfqdn.Enabled = true;
            txtMEfqdn.Enabled = true;
        }
    }

    public class DBProcess
    {

        private string sqlConnectionString = string.Empty;
        private SqlConnection conn;


        public DBProcess(string server, string databaseName, string userName, string password)
        {
            sqlConnectionString = string.Format(@"data source={0};initial catalog={1};persist security info=True;User ID={2};Password={3};",
                                                server, databaseName, userName, password);
        }

        private void OpenConnection()
        {
            conn = new SqlConnection(sqlConnectionString);
            conn.Open();
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public List<KeyValuePair<string, string>> GetTempPath()
        {
            try
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                //
                OpenConnection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "select ConfigKeyName, ConfigKeyValue from ConfigMaster where ConfigKeyName LIKE 'TempFilePathExport' OR ConfigKeyName LIKE 'TempFilePathImport'";
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new KeyValuePair<string,string>(dr["ConfigKeyName"].ToString(), dr["ConfigKeyValue"].ToString()));
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
