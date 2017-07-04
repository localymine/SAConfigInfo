using System;
using SA_Config_Info;
using System.IO;
using System.Linq;
using System.Xml;

namespace ConfigSVCronJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if(Configuration.Info != null)
            {
                XMLProcess xml = new XMLProcess();
                xml.SaveAssignTaskService();
                xml.SaveCheckTimeOutService();
                xml.SaveNotificationService();
            }
            Console.ReadKey();
        }
    }

    public class XMLProcess
    {
        public XMLProcess()
        {

        }

        public void SaveAssignTaskService()
        {
            string appName = "GMA_SV_AssignAfterEffectService";
            Console.WriteLine("Update xml file in {0} service", appName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), string.Format(@"WindowsService\{0}\Deploy\{1}.exe.config", appName, appName));
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("xml file not found");
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                //Connectionstring
                XmlNodeList nodeConnectionString = doc.SelectNodes("/configuration/connectionStrings/add");
                foreach (XmlNode n in nodeConnectionString)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "TemplateEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringTemplateEntities;
                            break;
                        case "StandardDataLibraryEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringStandardDataLibraryEntities;
                            break;
                        case "UserEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionString;
                            break;
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SVServiceFolder[] folders = Configuration.Info.ServerInfo.SVServicePaths;
                            SVServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                //doc.Save(path);
                //
                Common.HotFixSaveRawXml(doc, path);
                //
                Console.WriteLine("Update {0} xml file success", appName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when update {0} xml service file", appName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        public void SaveCheckTimeOutService()
        {
            string appName = "GMA_SV_CheckTimeOutService";
            Console.WriteLine("Update xml file in {0} service", appName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), string.Format(@"WindowsService\{0}\Deploy\{1}.exe.config", appName, appName));
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("xml file not found");
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                //Connectionstring
                XmlNodeList nodeConnectionString = doc.SelectNodes("/configuration/connectionStrings/add");
                foreach (XmlNode n in nodeConnectionString)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "StandardDataLibraryEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringStandardDataLibraryEntities;
                            break;
                        case "TemplateEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringTemplateEntities;
                            break;
                        case "UserEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionString;
                            break;
                        case "EmailConfigEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringEmailConfigEntities;
                            break;
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SVServiceFolder[] folders = Configuration.Info.ServerInfo.SVServicePaths;
                            SVServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                //doc.Save(path);
                //
                Common.HotFixSaveRawXml(doc, path);
                //
                Console.WriteLine("Update {0} xml file success", appName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when update {0} xml service file", appName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        public void SaveNotificationService()
        {
            string appName = "GMA_SV_NotificationService";
            Console.WriteLine("Update xml file in {0} service", appName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), string.Format(@"WindowsService\{0}\Deploy\{1}.exe.config", appName, appName));
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("xml file not found");
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                //Connectionstring
                XmlNodeList nodeConnectionString = doc.SelectNodes("/configuration/connectionStrings/add");
                foreach (XmlNode n in nodeConnectionString)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "StandardDataLibraryEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringStandardDataLibraryEntities;
                            break;
                        case "TemplateEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringTemplateEntities;
                            break;
                        case "UserEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionString;
                            break;
                        case "EmailConfigEntities":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.ConnectionStringEmailConfigEntities;
                            break;
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SVServiceFolder[] folders = Configuration.Info.ServerInfo.SVServicePaths;
                            SVServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                //doc.Save(path);
                //
                Common.HotFixSaveRawXml(doc, path);
                //
                Console.WriteLine("Update {0} xml file success", appName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when update {0} xml service file", appName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }
        
    }
}
