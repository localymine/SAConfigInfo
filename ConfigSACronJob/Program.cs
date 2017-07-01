using SA_Config_Info;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Linq;

namespace ConfigSACronJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if (Configuration.Info != null)
            {
                DBProcess db = new DBProcess(Configuration.Info.ServerInfo.SQLServer.DataSource,
                    Configuration.Info.ServerInfo.SQLServer.Catalog,
                    Configuration.Info.ServerInfo.SQLServer.UserID,
                    Configuration.Info.ServerInfo.SQLServer.Password);
                XMLProcess xml = new XMLProcess();
                int aeID = 0, meID = 0;
                switch (Configuration.Info.StandAloneInfo.SAMachine.Type)
                {
                    case "0":
                        db.SaveAE(Configuration.Info.StandAloneInfo.IPAddress,ref aeID);
                        if(aeID <= 0)
                        {
                            Console.WriteLine("Has something error while save AE config to DB. Please check again!");
                            return;
                        }
                        xml.SaveAEExportService(aeID);
                        xml.SaveAEService(aeID);
                        xml.SaveCheckNotRespondingService(aeID, 0);
                        break;
                    case "1":
                        db.SaveME(Configuration.Info.StandAloneInfo.IPAddress, ref meID);
                        if (meID <= 0)
                        {
                            Console.WriteLine("Has something error while save ME config to DB. Pleas check again!");
                            return;
                        }
                        xml.SaveMEService(meID);
                        xml.SaveMECheckRender(meID);
                        xml.SaveCheckNotRespondingService(0, meID);
                        break;
                    case "2":
                        db.SaveAE(Configuration.Info.StandAloneInfo.IPAddress, ref aeID);
                        if (aeID <= 0)
                        {
                            Console.WriteLine("Has something error while save AE config to DB. Please check again!");
                        }
                        else
                        {
                            xml.SaveAEExportService(aeID);
                            xml.SaveAEService(aeID);
                            xml.SaveCheckNotRespondingService(aeID, 0);
                        }
                        db.SaveME(Configuration.Info.StandAloneInfo.IPAddress, ref meID);
                        if(meID <= 0)
                        {
                            Console.WriteLine("Has something error while save ME config to DB. Pleas check again!");
                        }
                        else
                        {
                            xml.SaveMEService(meID);
                            xml.SaveMECheckRender(meID);
                            xml.SaveCheckNotRespondingService(0, meID);
                        }
                        if (aeID > 0 && meID > 0)
                        {
                            xml.SaveCheckNotRespondingService(aeID, meID);
                        }
                        break;
                }
                Console.ReadLine();
            }
            Console.ReadKey();
        }
    }

    public class DBProcess
    {

        private string sqlConnectionString = "";
        

        public DBProcess(string server, string databaseName, string userName, string password)
        {
            sqlConnectionString = string.Format(@"data source={0};initial catalog={1};persist security info=True;User ID={2};Password={3};",
                                                server, databaseName, userName, password);
        }

        public void SaveAE(string ipAddress, ref int id)
        {
            Console.WriteLine("Start AE save");
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format(@"INSERT INTO [dbo].[PrimaryEngines]([Name],[IPAddress],[FQDN]) output INSERTED.PEId VALUES(@name,@ip,@fqdn)");
                    cmd.Parameters.AddWithValue("@name", ipAddress);
                    cmd.Parameters.AddWithValue("@ip", ipAddress);
                    cmd.Parameters.AddWithValue("@fqdn", Configuration.Info.StandAloneInfo.SAMachine.AEFQDN);
                    cmd.CommandType = CommandType.Text;
                    id = (int)cmd.ExecuteScalar();
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    Console.WriteLine("Save AE success");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error when insert");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        public void SaveME(string ipAddress, ref int id)
        {
            Console.WriteLine("Start ME save");
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            SqlTransaction pTran = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = pTran;
                cmd.CommandText = string.Format(@"INSERT INTO [dbo].[RenderEngines] ([Name] ,[IPAddress] ,[FQDN] ,[WatchFolderPath] ,[TempFolderPath] ,[TempFolderLocalPath]) 
                                                      output INSERTED.REId 
                                                      VALUES (@Name, @IPAddress, @FQDN, @WatchFolderPath, @TempFolderPath, @TempFolderLocalPath)");
                cmd.Parameters.AddWithValue("@Name", ipAddress);
                cmd.Parameters.AddWithValue("@IPAddress", ipAddress);
                cmd.Parameters.AddWithValue("@FQDN", Configuration.Info.StandAloneInfo.SAMachine.MEFQDN);
                cmd.Parameters.AddWithValue("@WatchFolderPath", Configuration.Info.StandAloneInfo.SAWatchFolderPath);
                cmd.Parameters.AddWithValue("@TempFolderPath", Configuration.Info.StandAloneInfo.SATempFolderPath);
                cmd.Parameters.AddWithValue("@TempFolderLocalPath", Configuration.Info.StandAloneInfo.SATempFolderLocalPath);
                cmd.CommandType = CommandType.Text;
                id = (int)cmd.ExecuteScalar();
                if (id <= 0)
                {
                    Console.WriteLine("Error when insert into RenderEngines table");
                    return;
                }
                foreach (var encoder in Configuration.Info.StandAloneInfo.SAMachine.Encoders)
                {
                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.Connection = conn;
                    cmdDetail.Transaction = pTran;
                    cmdDetail.CommandText = string.Format(@"INSERT INTO [dbo].[WatchFolderDetails] ([REId] ,[ResolutionId] ,[WatchFolderName]) 
                                                      VALUES (@REId, @ResolutionId, @WatchFolderName)");
                    cmdDetail.Parameters.AddWithValue("@REId", id.ToString());
                    cmdDetail.Parameters.AddWithValue("@ResolutionId", encoder.ID);
                    cmdDetail.Parameters.AddWithValue("@WatchFolderName", encoder.WatchFolderName);
                    cmdDetail.ExecuteNonQuery();
                }
                pTran.Commit();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                Console.WriteLine("Save ME success");
            }
            catch(Exception ex)
            {
                id = 0;
                pTran.Rollback();
                Console.WriteLine("Error when insert");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }

    public class XMLProcess
    {
        public XMLProcess()
        {

        }

        public void SaveAEExportService(int id)
        {
            string appName = "GMA_SA_AE_ExportTemplateService";
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
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "AEPath":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.AEPath;
                            break;
                        case "AEInstanceId":
                            n.Attributes[1].Value = id.ToString();
                            break;
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SAServiceFolder[] folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                            SAServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                doc.Save(path);
                Console.WriteLine("Update {0} xml file success", appName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error when update {0} xml service file", appName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }

        public void SaveAEService(int id)
        {
            string appName = "GMA_SA_AfterEffectService";
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
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "AEPath":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.AEPath;
                            break;
                        case "AEInstanceId":
                            n.Attributes[1].Value = id.ToString();
                            break;
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SAServiceFolder[] folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                            SAServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                doc.Save(path);
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
        
        public void SaveMEService(int id)
        {
            string appName = "GMA_SA_ME_MediaEncoderService";
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
                    }
                }
                //Appsetting
                XmlNodeList nodeAppSetting = doc.SelectNodes("/configuration/appSettings/add");
                foreach (XmlNode n in nodeAppSetting)
                {
                    var attr = n.Attributes[0];
                    switch (attr.Value)
                    {
                        case "AEPath":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.AEPath;
                            break;
                        case "MEInstanceId":
                            n.Attributes[1].Value = id.ToString();
                            break;
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SAServiceFolder[] folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                            SAServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                doc.Save(path);
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

        public void SaveMECheckRender(int id)
        {
            string appName = "GMA_SA_ME_CheckRenderedVideoService";
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
                        case "MEInstanceId":
                            n.Attributes[1].Value = id.ToString();
                            break;
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SAServiceFolder[] folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                            SAServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                doc.Save(path);
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

        public void SaveCheckNotRespondingService(int aeID, int meID)
        {
            string appName = "GMA_SA_AEME_CheckNotRespondingService";
            Console.WriteLine("Update xml file in {0} service", appName);
            string path = Path.Combine(Environment.CurrentDirectory, string.Format(@"WindowsService\{0}\Deploy\{1}.exe.config", appName, appName));
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
                        case "AEPath":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.AEPathExe;
                            break;
                        case "AEInstanceId":
                            n.Attributes[1].Value = aeID.ToString();
                            break;
                        case "AEProcessName":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.AEProcessName;
                            break;
                        case "MEPath":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.MEPathExe;
                            break;
                        case "MEInstanceId":
                            n.Attributes[1].Value = meID.ToString();
                            break;
                        case "MEProcessName":
                            n.Attributes[1].Value = Configuration.Info.StandAloneInfo.SAMachine.MEProcessName;
                            break;
                        case "lblDataConnection":
                            n.Attributes[1].Value = Configuration.Info.ServerInfo.SQLServer.AppSettingValue;
                            break;
                        case "ServicePath":
                            SAServiceFolder[] folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                            SAServiceFolder f = folders.FirstOrDefault(m => m.Path.Contains(appName));
                            n.Attributes[1].Value = (f != null ? f.Path : "");
                            break;
                    }
                }
                doc.Save(path);
                Console.WriteLine("Update {0} xml file success", appName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when update {0} xml check not-responsding congif file", appName);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("");
            }
        }
    }
}
