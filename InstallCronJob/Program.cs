﻿using System;
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
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AfterEffectService"), Path.Combine(targetPath, "GMA_SA_AfterEffectService"));
                                // todo: share TEMP_FOLDER_EXPORT
                                break;
                            case "1":
                                Console.WriteLine("ME");
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_CheckRenderedVideoService"), Path.Combine(targetPath, "GMA_SA_ME_CheckRenderedVideoService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_MediaEncoderService"), Path.Combine(targetPath, "GMA_SA_ME_MediaEncoderService"));
                                // todo: share TEMP_FOLDER_EXPORT
                                break;
                            case "2":
                                Console.WriteLine("AE & ME");
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_AfterEffectService"), Path.Combine(targetPath, "GMA_SA_AfterEffectService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_CheckRenderedVideoService"), Path.Combine(targetPath, "GMA_SA_ME_CheckRenderedVideoService"));
                                Common.CopyAll(Path.Combine(sourcePath, "GMA_SA_ME_MediaEncoderService"), Path.Combine(targetPath, "GMA_SA_ME_MediaEncoderService"));
                                // todo: share TEMP_FOLDER_EXPORT
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
    }
}
