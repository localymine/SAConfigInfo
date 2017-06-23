using System;
using SA_Config_Info;
using CredentialManagement;

namespace ConfigSACredential
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if(Configuration.Info != null)
            {
                Credential t = new Credential();
                t.Target = Configuration.Info.ServerInfo.IPAddress;
                t.Username = Configuration.Info.ServerInfo.UserName;
                t.Password = Configuration.Info.ServerInfo.Password;
                t.Type = CredentialType.DomainPassword;
                t.PersistanceType = PersistanceType.Enterprise;
                t.Save();
                Console.WriteLine("Success");
                Console.ReadKey();
            }
        }
    }
}
