using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

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
        public int Type;
        public int Encoder;
    }
}
