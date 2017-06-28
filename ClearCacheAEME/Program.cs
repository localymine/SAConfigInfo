using SA_Config_Info;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClearCacheAEME
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> listPath = Common.GetMediaCachePath();
                foreach (string path in listPath)
                {
                    Empty(new DirectoryInfo(path));
                }
                //
                Empty(new DirectoryInfo(Path.GetTempPath()));
                //
                Console.WriteLine("Successfully Clean Up Cache!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void Empty(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles()) file.Delete();
            foreach (DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }
    }
}
