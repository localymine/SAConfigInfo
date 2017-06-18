using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA_Config_Info;
using System.IO;

namespace InstallCronJob
{
    class Program
    {
        static void Main(string[] args)
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
                    //foreach (string srcPath in Directory.GetFiles(sourcePath))
                    //{
                    //    File.Copy(srcPath, srcPath.Replace(sourcePath, targetPath), true);
                    //}
                    //Console.WriteLine("Succesfully Install Cron Job!");
                }

                Console.WriteLine(sourcePath);
                Console.WriteLine(targetPath);
            }
            Console.ReadKey();
        }
    }
}
