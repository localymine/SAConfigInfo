using System;
using SA_Config_Info;
using System.IO;

namespace InstallAEJSX
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if (Configuration.Info != null)
            {
                string sourcePath = Path.Combine(Environment.CurrentDirectory, "AEScripts");
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
                    // share TEMP_IMPORT folder
                }
                Console.WriteLine("Succesfully Configurate ME Watch Folder!");
                Console.WriteLine("In order to intergrate with ME, Please Set up manually.");
                Console.WriteLine("Reference: https://helpx.adobe.com/media-encoder/how-to/create-watch-folder.html");
            }
            Console.ReadKey();
        }
    }
}
