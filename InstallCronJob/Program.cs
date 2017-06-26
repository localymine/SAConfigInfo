using System;
using SA_Config_Info;
using System.IO;
using System.Threading;

namespace InstallCronJob
{
    class Program
    {
        private static readonly string[] AEServiceNames = { "GMA_SA_AE_ExportTemplateService", "GMA_SA_AfterEffectService", "GMA_SA_AEME_CheckNotRespondingService" };
        private static readonly string[] MEServiceNames = { "GMA_SA_ME_CheckRenderedVideoService", "GMA_SA_ME_MediaEncoderService", "GMA_SA_AEME_CheckNotRespondingService" };

        static void Main(string[] args)
        {
            try
            {
                Configuration.GetConfigInfo("ConfigInfo.xml");
                if (Configuration.Info != null)
                {
                    string sourcePath = Path.Combine(Environment.CurrentDirectory, "WindowsService");

                    if (Directory.Exists(sourcePath))
                    {
                        switch (Configuration.Info.StandAloneInfo.SAMachine.Type)
                        {
                            case "0":
                                Console.WriteLine("AE");
                                //
                                CopyServices(sourcePath, AEServiceNames, false);
                                break;
                            case "1":
                                Console.WriteLine("ME");
                                //
                                CopyServices(sourcePath, MEServiceNames, false);
                                break;
                            case "2":
                                Console.WriteLine("AE & ME");
                                //
                                CopyServices(sourcePath, null, true);
                                break;
                        }
                        //
                        Console.WriteLine("Succesfully Install Cron Job!");
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

        private static void ShareFolder(string path, string serviceFolderName)
        {
            // share TEMP_FOLDER_EXPORT
            if (AEServiceNames[0] == serviceFolderName)
            {
                Common.ShareFolder(Path.Combine(path, "TEMP_FOLDER_EXPORT"));
            }
            else if (AEServiceNames[1] == serviceFolderName)
            {
                Common.ShareFolder(Path.Combine(path, "TEMP_FOLDER_IMPORT"));
            }
        }

        private static void CopyServices(string sourcePath, string[] ServiceNames = null, bool flag = false)
        {
            SAServiceFolder[] items = Configuration.Info.StandAloneInfo.SAServicePaths;
            //
            string ServiceFolderName;
            //
            if (flag == true)
            {
                foreach (SAServiceFolder sasf in items)
                {
                    ServiceFolderName = Common.GetLastFolderName(sasf.Path);
                    //
                    if (!Directory.Exists(sasf.Path))
                    {
                        Directory.CreateDirectory(sasf.Path);
                    }
                    //
                    Common.CopyAll(Path.Combine(sourcePath, ServiceFolderName), sasf.Path);
                    //
                    ShareFolder(sasf.Path, ServiceFolderName);
                }
                //
                using (var progress = new ProgressBar())
                {
                    int bar = 300;
                    for (int i = 0; i <= bar; i++)
                    {
                        progress.Report((double)i / bar);
                        Thread.Sleep(20);
                    }
                }
            }
            else
            {
                foreach (SAServiceFolder sasf in items)
                {
                    ServiceFolderName = Common.GetLastFolderName(sasf.Path);
                    //
                    if (Array.Exists(ServiceNames, e => e.Contains(ServiceFolderName)))
                    {
                        if (!Directory.Exists(sasf.Path))
                        {
                            Directory.CreateDirectory(sasf.Path);
                        }
                        //
                        Common.CopyAll(Path.Combine(sourcePath, ServiceFolderName), sasf.Path);
                        //
                        ShareFolder(sasf.Path, ServiceFolderName);
                    }

                }
                //
                using (var progress = new ProgressBar())
                {
                    int bar = 300;
                    for (int i = 0; i <= bar; i++)
                    {
                        progress.Report((double)i / bar);
                        Thread.Sleep(20);
                    }
                }
            }
                

            
        }
    }
}
