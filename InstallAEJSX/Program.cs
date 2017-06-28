using System;
using SA_Config_Info;
using System.IO;
using System.Text.RegularExpressions;

namespace InstallAEJSX
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if (Configuration.Info != null)
            {
                string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "AEScripts");
                string targetPath = Configuration.Info.StandAloneInfo.SAMachine.AEScriptPath;
                //
                if (Directory.Exists(sourcePath))
                {
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    foreach (string srcPath in Directory.GetFiles(sourcePath))
                    {
                        string text = File.ReadAllText(srcPath);
                        //
                        string result = "";
                        string pattern = @"var.*\btxt\b";
                        string path = "";
                        Regex rgxMatch1 = new Regex(@"GMA_SA_AE_ExportTemplateService");
                        Regex rgxMatch2 = new Regex(@"GMA_SA_AfterEffectService");
                        Regex rgx = new Regex(pattern);
                        if (rgxMatch1.IsMatch(text))
                        {
                            path = "var textFilePath = \"" + Configuration.Info.StandAloneInfo.SAMachine.AEExportProjectPath;
                            result = rgx.Replace(text, path);
                        }
                        else if(rgxMatch2.IsMatch(text))
                        {
                            path = "var textFilePath = \"" + Configuration.Info.StandAloneInfo.SAMachine.AEProjectPath;
                            result = rgx.Replace(text, path);
                        }
                        //
                        File.WriteAllText(srcPath, result);
                        //
                        File.Copy(srcPath, srcPath.Replace(sourcePath, targetPath), true);
                    }
                    Console.WriteLine("Succesfully Install AE Scripts!");
                }
                //
                WatchFolder[] items = Configuration.Info.StandAloneInfo.WatchFolderPaths;
                foreach(WatchFolder wf in items)
                {
                    if (!Directory.Exists(wf.Path))
                    {
                        Directory.CreateDirectory(wf.Path);
                    }
                    // share AE_PROCESSING folder
                    if ((wf.Path).Contains("AE_PROCESSING"))
                    {
                        Common.ShareFolder(wf.Path);
                    }
                }
                Console.WriteLine("Succesfully Configurate ME Watch Folder!");
                Console.WriteLine("In order to intergrate with ME, Please Set up manually.");
                Console.WriteLine("Reference: https://helpx.adobe.com/media-encoder/how-to/create-watch-folder.html");
            }
            Console.ReadKey();
        }
    }
}
