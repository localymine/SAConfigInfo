﻿using SA_Config_Info;
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
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "SourceCode", "GMAWEB");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMAWEB");

            // Configure Connection DB of WebConfig, with data from xml
            UpdateWebConfig(sourcePath, targetPath);

            // copy source code
            Common.CopyAll(sourcePath, targetPath);

            // share content folder
            Common.ShareFolder(Path.Combine(targetPath, "Content"));
        }

        private void btnInstallRest_Click(object sender, EventArgs e)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "SourceCode", "GMAREST");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMAREST");

            // Configure Connection DB of WebConfig, with data from xml
            UpdateWebConfig(sourcePath, targetPath);

            // copy source code
            Common.CopyAll(sourcePath, targetPath);
        }

        private void btnInstallCdn_Click(object sender, EventArgs e)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "SourceCode", "GMACDN");
            string targetPath = Path.Combine(txtGMAWeb.Text, "GMACDN");

            // copy source code
            Common.CopyAll(sourcePath, targetPath);

            // share content folder
            Common.ShareFolder(Path.Combine(targetPath));
        }

        private void UpdateWebConfig(string sourcePath, string targetPath)
        {
            Configuration.GetConfigInfo(FileName);

            string webConfigFile = Path.Combine(sourcePath, "Web.config");

            XDocument xmlFile = XDocument.Load(webConfigFile);

            foreach (XElement xe in xmlFile.Root.Element("connectionStrings").Elements("add"))
            {
                xe.Attribute("connectionString").Value = Configuration.Info.ServerInfo.SQLServer.ConnectionString;
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
    }
}
