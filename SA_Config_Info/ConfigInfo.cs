using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.Win32;
using System.Management;
using System.Threading;

namespace SA_Config_Info
{

    [XmlRootAttribute("Configuration", IsNullable=false)]

    public class ConfigInfo
    {
        public ServerInfo ServerInfo;
        public StandAloneInfo StandAloneInfo;
    }

    public class ServerInfo
    {
        [XmlAttribute]
        public string IP;
        public string IPAddress;
        public string UserName;
        public string Password;
        public string ServicePath;
        [XmlArrayAttribute("Paths")]
        public SVServiceFolder[] SVServicePaths;

        public SQLServer SQLServer;
    }

    public class SVServiceFolder
    {
        public string Path;
    }

    public class SQLServer
    {
        public string DataSource;
        public string Catalog;
        public string UserID;
        public string Password;

        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                return (_connectionString != null ? _connectionString : "");
            }
            set
            {
                string connection = "metadata=res://*/User.csdl|res://*/User.ssdl|res://*/User.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionString = connection;
            }
        }

        private string _connectionStringTemplateEntities;
        public string ConnectionStringTemplateEntities
        {
            get
            {
                return (_connectionStringTemplateEntities != null ? _connectionStringTemplateEntities : "");
            }
            set
            {
                string connection = "metadata=res://*/Template.csdl|res://*/Template.ssdl|res://*/Template.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringTemplateEntities = connection;
            }
        }

        private string _connectionStringStandardDataLibraryEntities;
        public string ConnectionStringStandardDataLibraryEntities
        {
            get
            {
                return (_connectionStringStandardDataLibraryEntities != null ? _connectionStringStandardDataLibraryEntities : "");
            }
            set
            {
                string connection = "metadata=res://*/StandardDataLibrary.csdl|res://*/StandardDataLibrary.ssdl|res://*/StandardDataLibrary.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringStandardDataLibraryEntities = connection;
            }
        }

        private string _connectionStringEmailConfigEntities;
        public string ConnectionStringEmailConfigEntities
        {
            get
            {
                return (_connectionStringEmailConfigEntities != null ? _connectionStringEmailConfigEntities : "");
            }
            set
            {
                string connection = "metadata=res://*/EmailConfig.csdl|res://*/EmailConfig.ssdl|res://*/EmailConfig.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringEmailConfigEntities = connection;
            }
        }

        private string _connectionStringResolution;
        public string ConnectionStringResolution
        {
            get
            {
                return (_connectionStringResolution != null ? _connectionStringResolution : "");
            }
            set
            {
                string connection = "metadata=res://*/VideoResolution.csdl|res://*/VideoResolution.ssdl|res://*/VideoResolution.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringResolution = connection;
            }
        }

        private string _connectionStringGMA_CategoryEntities;
        public string ConnectionStringGMA_CategoryEntities
        {
            get
            {
                return (_connectionStringGMA_CategoryEntities != null ? _connectionStringGMA_CategoryEntities : "");
            }
            set
            {
                string connection = "metadata=res://*/Category.csdl|res://*/Category.ssdl|res://*/Category.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringGMA_CategoryEntities = connection;
            }
        }

        private string _connectionStringEmailTemplateEntities;
        public string ConnectionStringEmailTemplateEntities
        {
            get
            {
                return (_connectionStringEmailTemplateEntities != null ? _connectionStringEmailTemplateEntities : "");
            }
            set
            {
                string connection = "metadata=res://*/EmailTemplate.csdl|res://*/EmailTemplate.ssdl|res://*/EmailTemplate.msl;provider=System.Data.SqlClient;provider connection string=&quot;"
                    + "data source =" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;user id=" + UserID
                    + ";password=" + Password
                    + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";
                _connectionStringEmailTemplateEntities = connection;
            }
        }

        private string _appSettingValue;
        public string AppSettingValue
        {
            get
            {
                return (_appSettingValue != null ? _appSettingValue : "");
            }
            set
            {
                string settingValue = ""
                    + "data source=" + DataSource
                    + ";initial catalog=" + Catalog
                    + ";persist security info=True;User ID=" + UserID
                    + ";Password=" + Password + ";";
                _appSettingValue = settingValue;
            }
        }

        private string _sessionState;
        public string SessionState
        {
            get
            {
                return (_sessionState != null ? _sessionState : "");
            }
            set
            {
                string settingValue = ""
                    + "data source=" + DataSource
                    + ";initial catalog=ASPState"
                    + "; user id=" + UserID
                    + "; password=" + Password + ";";
                _sessionState = settingValue;
            }
        }
    }

    public class StandAloneInfo
    {
        [XmlAttribute]
        public string IP;
        public string IPAddress;
        public string UserName;
        public string Password;

        public string ServicePath;
        [XmlArrayAttribute("SAPaths")]
        public SAServiceFolder[] SAServicePaths;

        public string WatchFolderRoot;
        public string SAWatchFolderPath;
        public string SATempFolderPath;
        public string SATempFolderLocalPath;

        [XmlArrayAttribute("Paths")]
        public WatchFolder[] WatchFolderPaths;

        public SAMachine SAMachine;
    }

    public class WatchFolder
    {
        public string Path;
        public string NetworkPath;
    }

    public class SAServiceFolder
    {
        public string Path;
    }

    public class SAMachine
    {
        [XmlAttribute]
        public string Mission;

        [XmlArrayAttribute("Resolutions", IsNullable = false)]
        public Encoder[] Encoders;

        public string AEFQDN;
        public string MEFQDN;

        public string MachineName;
        public string Author;
        public string Type;
        public string AdobeVersion;

        public string AEPath;
        public string AEPathExe;
        public string AEProcessName;
        public string AEScriptPath;
        public string MEPath;
        public string MEPathExe;
        public string MEProcessName;

        private string _AEExportProjectPath;
        public string AEExportProjectPath
        {
            get
            {
                return _AEExportProjectPath;
            }
            set
            {
                string temp = value.Replace("\\\\\\\\", "\\\\");
                temp = temp.Replace("\\\\", "\\");
                temp = temp.Replace("\\\\", "|");
                temp = temp.Replace("\\", "|");
                temp = temp.Replace("|", "\\\\");
                _AEExportProjectPath = temp;
            }
        }

        private string _AEProjectPath;
        public string AEProjectPath
        {
            get
            {
                return _AEProjectPath;
            }
            set
            {
                string temp = value.Replace("\\\\\\\\", "\\\\");
                temp = temp.Replace("\\\\", "\\");
                temp = temp.Replace("\\\\", "|");
                temp = temp.Replace("\\", "|");
                temp = temp.Replace("|", "\\\\");
                _AEProjectPath = temp;
            }
        }

    }

    public class Encoder
    {
        public string ID;
        public string Name;
        public string WatchFolderName;
    }

    public class SADefination
    {
        private static List<KeyValuePair<string, string>> KvpAdobeVersion = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("rdCC2015", "CC 2015"),
            new KeyValuePair<string, string>("rdCC2017", "CC 2017"),
        };

        public static List<string> GetAdobeVersionByKey(string filterByKey)
        {
            return KvpAdobeVersion.Where(i => i.Key == filterByKey).Select(i => i.Value).ToList();
        }

        public static string GetAdobeVersionByValue(string filterByValue)
        {
            foreach (KeyValuePair<string, string> pair in KvpAdobeVersion)
            {
                if (pair.Value == filterByValue)
                {
                    return pair.Key;
                }
            }
            return "";
        }

        private string _AdobeVersion;
        public string AdobeVersion
        {
            get
            {
                return _AdobeVersion;
            }
            set
            {
                List<string> version = GetAdobeVersionByKey(value);
                _AdobeVersion = version[0];
            }
        }

        private static List<KeyValuePair<string, string[]>> KvpMission = new List<KeyValuePair<string, string[]>>()
        {
            new KeyValuePair<string, string[]>("rdAE", new string[] { "AE", "0" }),
            new KeyValuePair<string, string[]>("rdME", new string[] { "ME", "1" }),
            new KeyValuePair<string, string[]>("rdBoth", new string[] { "BOTH", "2" }),
        };

        public static List<string[]> GetMissionByKey(string filterByKey)
        {
            return KvpMission.Where(i => i.Key == filterByKey).Select(i => i.Value).ToList();
        }

        public static string GetMissionByValue(string filterByValue)
        {
            foreach (KeyValuePair<string, string[]> pair in KvpMission)
            {
                if (pair.Value[1] == filterByValue)
                {
                    return pair.Key;
                }
            }
            return "";
        }

        private string _mission;
        public string Mission
        {
            get
            {
                return _mission;
            }
            set
            {
                List<string[]> list = GetMissionByKey(value);
                _mission = list[0][0];
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                List<string[]> list = GetMissionByKey(value);
                _type = list[0][1];
            }
        }

        private static List<KeyValuePair<string, string[]>> KvpResolution = new List<KeyValuePair<string, string[]>>()
        {
            new KeyValuePair<string, string[]>("ckPreview", new string[] { "Preview", "0", "WATCH_FOLDER_PREVIEW" }),
            new KeyValuePair<string, string[]>("ckSD480p", new string[] { "SD 480p", "1", "WATCH_FOLDER_SD480p" }),
            new KeyValuePair<string, string[]>("ckSD480pwide", new string[] { "SD 480p wide", "2", "WATCH_FOLDER_SD480pwide" }),
            new KeyValuePair<string, string[]>("ckHD720p", new string[] { "HD 720p", "3", "WATCH_FOLDER_HD720p" }),
            new KeyValuePair<string, string[]>("ckHD1080p", new string[] { "Full HD 1080p", "4", "WATCH_FOLDER_Full HD 1080p" }),
            new KeyValuePair<string, string[]>("ck4K", new string[] { "4K", "5", "WATCH_FOLDER_4K" }),
        };

        public static List<string[]> GetResolutionByKey(string filterByKey)
        {
            return KvpResolution.Where(i => i.Key == filterByKey).Select(i => i.Value).ToList();
        }

        public static string GetResolutionByKey(string filterByKey, int index)
        {
            List<string[]> list = KvpResolution.Where(i => i.Key == filterByKey).Select(i => i.Value).ToList();
            return list[0][index];
        }

        public static string GetResolutionByValue(string filterByValue)
        {
            foreach (KeyValuePair<string, string[]> pair in KvpResolution)
            {
                if (pair.Value[1] == filterByValue)
                {
                    return pair.Key;
                }
            }
            return "";
        }

        private string _resolution;
        public string Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                List<string[]> list = GetResolutionByKey(value);
                _resolution = list[0][0];
            }
        }

        private string _encoder;
        public string Encoder
        {
            get
            {
                return _encoder;
            }
            set
            {
                List<string[]> list = GetResolutionByKey(value);
                _encoder = list[0][1];
            }
        }
    }

    public class Configuration
    {
        public static ConfigInfo Info;
        public static void GetConfigInfo(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
                serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open);

                    if (fs.Length > 0)
                    {
                        
                        Info = (ConfigInfo)serializer.Deserialize(fs);
                    }
                    //
                    fs.Close();
                }
                else
                {
                    Info = null;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }
    }

    public class Common
    {
        public static void CopyAll(string SourcePath, string DestinationPath, IProgress<int> progress = null)
        {
            Object countLock = new Object();
            string[] directories = System.IO.Directory.GetDirectories(SourcePath, "*.*", SearchOption.AllDirectories);

            if (!Directory.Exists(DestinationPath))
                Directory.CreateDirectory(DestinationPath);

            Parallel.ForEach(directories, dirPath =>
            {
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                if (progress != null)
                {
                    lock (countLock) { UpdateProgressBar(progress, directories.Count()); }
                }
            });

            string[] files = System.IO.Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(files, newPath =>
            {
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                if (progress != null)
                {
                    lock (countLock) { UpdateProgressBar(progress, files.Count()); }
                }
            });
        }

        private static void UpdateProgressBar(IProgress<int> progress, int count)
        {
            for(int j = 0; j < count; j++)
            {
                if (progress != null)
                {
                    progress.Report((j + 1) * 100 / count);
                }
            }
            
        }

        public static void ShareFolder(string path)
        {
            DirectorySecurity direcSec = Directory.GetAccessControl(path);
            // Using this instead of the "Everyone" string means we work on non-English systems.
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            direcSec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(path, direcSec);
        }

        public static int ShareFolderPermission(string FolderPath, string ShareName, string Description)
        {
            try
            {
                // Calling Win32_Share class to create a shared folder
                ManagementClass managementClass = new ManagementClass("Win32_Share");
                // Get the parameter for the Create Method for the folder
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
                ManagementBaseObject outParams;
                // Assigning the values to the parameters
                inParams["Description"] = Description;
                inParams["Name"] = ShareName;
                inParams["Path"] = FolderPath;
                inParams["Type"] = 0x0;
                // Finally Invoke the Create Method to do the process
                outParams = managementClass.InvokeMethod("Create", inParams, null);
                // Validation done here to check sharing is done or not
                if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
                    // Folder might be already in share or unable to share the directory
                    return 0;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static string GetLastFolderName(string path)
        {
            return Path.GetFileName(path).TrimEnd(Path.DirectorySeparatorChar).TrimEnd(Path.AltDirectorySeparatorChar);
        }

        public static List<string> GetMediaCachePath()
        {
            List<string> lstPaths = new List<string>();
            //
            string keyBase = @"Software\Adobe";
            RegistryKey hKeyCurrentUser = Registry.CurrentUser;
            RegistryKey adobePaths = hKeyCurrentUser.OpenSubKey(keyBase);
            foreach (string item in adobePaths.GetSubKeyNames())
            {
                if (item.Contains("Common"))
                {
                    using (RegistryKey tempKey = adobePaths.OpenSubKey(item))
                    {
                        foreach (string media in tempKey.GetSubKeyNames())
                        {
                            if (media.Contains("Media Cache"))
                            {
                                using (RegistryKey mediaKey = tempKey.OpenSubKey(media))
                                {
                                    foreach (string valueName in mediaKey.GetValueNames())
                                    {
                                        string tempStr = mediaKey.GetValue(valueName).ToString();
                                        if (tempStr != "0")
                                        {
                                            lstPaths.Add(mediaKey.GetValue(valueName).ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return lstPaths;
        }
    }
}
