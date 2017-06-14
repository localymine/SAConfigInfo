using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SA_Config_Info
{

    [XmlRootAttribute("Configuration", Namespace="", IsNullable=false)]

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

        public SQLServer SQLServer;
    }

    public class SQLServer
    {
        public string DataSource;
        public string Catalog;
        public string UserID;
        public string Password;
    }

    public class StandAloneInfo
    {
        [XmlAttribute]
        public string IP;
        public string IPAddress;
        public string UserName;
        public string Password;

        public SAMachine SAMachine;
    }

    public class SAMachine
    {
        [XmlAttribute]
        public string Mission;
        [XmlAttribute]
        public string Resolution;
        public string Type;
        public string Encoder;
    }

    public class SADefination
    {
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
            new KeyValuePair<string, string[]>("rdPreview", new string[] { "Preview", "-1" }),
            new KeyValuePair<string, string[]>("rdSD480p", new string[] { "SD 480p", "2" }),
            new KeyValuePair<string, string[]>("rdSD480pwide", new string[] { "SD 480p wide", "3" }),
            new KeyValuePair<string, string[]>("rdHD720p", new string[] { "HD 720p", "0" }),
            new KeyValuePair<string, string[]>("rdHD1080p", new string[] { "Full HD 1080p", "4" }),
            new KeyValuePair<string, string[]>("rd4K", new string[] { "4K", "1" }),
        };

        public static List<string[]> GetResolutionByKey(string filterByKey)
        {
            return KvpResolution.Where(i => i.Key == filterByKey).Select(i => i.Value).ToList();
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
}
