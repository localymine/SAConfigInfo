using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA_Config_Info;
using System.IO;
using System.Xml.Linq;

namespace ConfigSVCronJob
{
    class Program
    {
        private static string FileName = "ConfigInfo.xml";
        private static string[] cronJobList = new string[] {
            "GMA_SV_AssignAfterEffectService",
            "GMA_SV_CheckTimeOutService",
            "GMA_SV_NotificationService"
        };

        static void Main(string[] args)
        {
            try
            {
                Configuration.GetConfigInfo(FileName);

                string sourcePath = Path.Combine(Environment.CurrentDirectory, "WindowsService");
                SVServiceFolder[] svsf = Configuration.Info.ServerInfo.SVServicePaths;
                foreach (SVServiceFolder item in svsf)
                {
                    Console.WriteLine(item.Path);
                }

                //foreach (string cronjob in cronJobList)
                //{

                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        private void UpdateWebConfig(string sourcePath, string targetPath)
        {


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
