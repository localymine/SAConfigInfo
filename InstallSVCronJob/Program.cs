using SA_Config_Info;
using System;
using System.IO;

namespace InstallSVCronJob
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Configuration.GetConfigInfo("ConfigInfo.xml");
                if (Configuration.Info != null)
                {
                    string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "WindowsService");
                    string targetPath = Path.Combine(Configuration.Info.ServerInfo.ServicePath, "WindowsService");

                    if (Directory.Exists(sourcePath))
                    {
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        Console.WriteLine("Server Cron Job");
                        Common.CopyAll(Path.Combine(sourcePath, "GMA_SV_CheckTimeOutService"), Path.Combine(targetPath, "GMA_SV_CheckTimeOutService"));
                        Common.CopyAll(Path.Combine(sourcePath, "GMA_SV_AssignAfterEffectService"), Path.Combine(targetPath, "GMA_SV_AssignAfterEffectService"));
                        Common.CopyAll(Path.Combine(sourcePath, "GMA_SV_NotificationService"), Path.Combine(targetPath, "GMA_SV_NotificationService"));

                        //
                        Console.WriteLine("Succesfully Install Server Cron Job!");
                    }
                    else
                    {
                        Console.WriteLine("Resource Loss!");
                    }
                }
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
