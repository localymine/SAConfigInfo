using SA_Config_Info;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace InstallationSVWizard
{
    public partial class frmSVSource : Form
    {
        private string FileName = "ConfigInfo.xml";

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

        private void InstallWeb(IProgress<int> progress)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMAWEB");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMAWEB");

            // Configure Connection DB of WebConfig, with data from xml
            UpdateWebConfig(sourcePath, targetPath);

            // copy source code
            Common.CopyAll(sourcePath, targetPath, progress);

            // share content folder
            string contentPath = Path.Combine(targetPath, "Content");
            Common.ShareFolder(contentPath);
            Common.ShareFolderPermission(contentPath, "Content", "Content");
        }

        private async void btnInstallWeb_Click(object sender, EventArgs e)
        {
            try
            {
                progressBarWEB.Maximum = 100;
                progressBarWEB.Step = 1;

                var progress = new Progress<int>(v =>
                {
                    progressBarWEB.Value = v;
                });

                await Task.Run(() => InstallWeb(progress));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MessageBox.Show("Successfully Intalled GMAWEB!");
            }
        }

        private void InstallREST(IProgress<int> progress)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMAREST");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMAREST");

            // Configure Connection DB of WebConfig, with data from xml
            UpdateWebConfig(sourcePath, targetPath);

            // copy source code
            Common.CopyAll(sourcePath, targetPath, progress);
        }

        private async void btnInstallRest_Click(object sender, EventArgs e)
        {
            try
            {
                progressBarREST.Maximum = 100;
                progressBarREST.Step = 1;

                var progress = new Progress<int>(v =>
                {
                    progressBarREST.Value = v;
                });

                await Task.Run(() => InstallREST(progress));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MessageBox.Show("Successfully Intalled GMA REST API!");
            }
        }

        private void InstallCDN(IProgress<int> progress)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMACDN");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMACDN");

            // copy source code
            Common.CopyAll(sourcePath, targetPath, progress);

            // share content folder
            Common.ShareFolder(Path.Combine(targetPath));
            Common.ShareFolderPermission(Path.Combine(targetPath), "GMACDN", "GMACDN");
        }

        private async void btnInstallCdn_Click(object sender, EventArgs e)
        {
            try
            {
                progressBarCDN.Maximum = 100;
                progressBarCDN.Step = 1;

                var progress = new Progress<int>(v =>
                {
                    progressBarCDN.Value = v;
                });

                await Task.Run(() => InstallCDN(progress));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MessageBox.Show("Successfully Intalled Basic GMA CDN!");
            }
        }

        private void UpdateWebConfig(string sourcePath, string targetPath)
        {   
            try
            {
                string webConfigFile = Path.Combine(sourcePath, "Web.config");
                Configuration.GetConfigInfo(FileName);
                XDocument xmlFile = XDocument.Load(webConfigFile);

                foreach (XElement xe in xmlFile.Root.Element("connectionStrings").Elements("add"))
                {
                    switch (xe.Attribute("name").Value)
                    {
                        case "StandardDataLibraryEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringStandardDataLibraryEntities;
                            break;
                        case "TemplateEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringTemplateEntities;
                            break;
                        case "UserEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionString;
                            break;
                        case "EmailConfigEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringEmailConfigEntities;
                            break;
                        case "Resolution":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringResolution;
                            break;
                        case "GMA_CategoryEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringGMA_CategoryEntities;
                            break;
                        case "EmailTemplateEntities":
                            xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringEmailTemplateEntities;
                            break;
                    }
                }

                foreach (XElement xe in xmlFile.Root.Element("appSettings").Elements("add"))
                {
                    if (xe.Attribute("key").Value == "lblDataConnection")
                    {
                        xe.Attribute("value").Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                    }
                }

                foreach (XElement xe in xmlFile.Root.Element("system.web").Elements("sessionState"))
                {
                    xe.Attribute("sqlConnectionString").Value = Configuration.Info.ServerInfo.SQLServer.SessionState;
                }

                xmlFile.Save(webConfigFile);

                //
                Common.HotFixSaveRawXml(xmlFile, webConfigFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
