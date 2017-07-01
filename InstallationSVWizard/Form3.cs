using SA_Config_Info;
using System;
using System.IO;
using System.Windows.Forms;
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

        private void btnInstallWeb_Click(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMAWEB");
                string targetPath = Path.Combine(txtGMAWeb.Text, "GMAWEB");

                // Configure Connection DB of WebConfig, with data from xml
                UpdateWebConfig(sourcePath, targetPath);

                // copy source code
                Common.CopyAll(sourcePath, targetPath);

                // share content folder
                string contentPath = Path.Combine(targetPath, "Content");
                Common.ShareFolder(contentPath);
                Common.ShareFolderPermission(contentPath, "Content", "Content");

                MessageBox.Show("Successfully Intalled GMAWEB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnInstallRest_Click(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMAREST");
                string targetPath = Path.Combine(txtGMAWeb.Text, "GMAREST");

                // Configure Connection DB of WebConfig, with data from xml
                UpdateWebConfig(sourcePath, targetPath);

                // copy source code
                Common.CopyAll(sourcePath, targetPath);

                MessageBox.Show("Successfully Intalled GMA REST API!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnInstallCdn_Click(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "SourceCode", "GMACDN");
                string targetPath = Path.Combine(txtGMAWeb.Text, "GMACDN");

                // copy source code
                Common.CopyAll(sourcePath, targetPath);

                // share content folder
                Common.ShareFolder(Path.Combine(targetPath));
                Common.ShareFolderPermission(Path.Combine(targetPath), "GMACDN", "GMACDN");

                MessageBox.Show("Successfully Intalled Basic GMA CDN!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateWebConfig(string sourcePath, string targetPath)
        {
            try
            {
                Configuration.GetConfigInfo(FileName);

                string webConfigFile = Path.Combine(sourcePath, "Web.config");

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
