using System;
using SA_Config_Info;
using System.IO;

namespace InstallCronJob
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
                    string sourcePath = Path.Combine(Environment.CurrentDirectory, "WindowsService");
                    string targetPath = Path.Combine(Configuration.Info.StandAloneInfo.ServicePath, "WindowsService");

                    if (Directory.Exists(sourcePath))
                    {
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        switch (Configuration.Info.StandAloneInfo.SAMachine.Type)
                        {
                            case "0":
                                Console.WriteLine("AE");
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AE_ExportTemplateService"), Path.Combine(targetPath, "GMA_SA_AE_ExportTemplateService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AfterEffectService"), Path.Combine(targetPath, "GMA_SA_AfterEffectService"));
                                // share TEMP_FOLDER_EXPORT
                                ShareFolder();
                                break;
                            case "1":
                                Console.WriteLine("ME");
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_CheckRenderedVideoService"), Path.Combine(targetPath, "GMA_SA_ME_CheckRenderedVideoService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_MediaEncoderService"), Path.Combine(targetPath, "GMA_SA_ME_MediaEncoderService"));
                                break;
                            case "2":
                                Console.WriteLine("AE & ME");
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AfterEffectService"), Path.Combine(targetPath, "GMA_SA_AfterEffectService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AE_ExportTemplateService"), Path.Combine(targetPath, "GMA_SA_AE_ExportTemplateService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_CheckRenderedVideoService"), Path.Combine(targetPath, "GMA_SA_ME_CheckRenderedVideoService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_MediaEncoderService"), Path.Combine(targetPath, "GMA_SA_ME_MediaEncoderService"));
                                // share TEMP_FOLDER_EXPORT
                                ShareFolder();
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

        private static void ShareFolder()
        {
            // share TEMP_FOLDER_EXPORT
            SAServiceFolder[] items = Configuration.Info.StandAloneInfo.SAServicePaths;
            foreach (SAServiceFolder sasf in items)
            {
                if (sasf.Path.Contains("TEMP_FOLDER_EXPORT"))
                {
                    Common.ShareFolder(Path.Combine(sasf.Path, "TEMP_FOLDER_EXPORT"));
                }
            }
        }
    }
}
