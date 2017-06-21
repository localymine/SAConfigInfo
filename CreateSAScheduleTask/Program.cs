using Microsoft.Win32.TaskScheduler;
using SA_Config_Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateSAScheduleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if(Configuration.Info != null)
            {
                switch (Configuration.Info.StandAloneInfo.SAMachine.Type)
                {
                    case "0":
                        CreateAETask();
                        break;
                    case "1":
                        CreateMETask();
                        break;
                    case "2":
                        CreateAETask();
                        CreateMETask();
                        break;
                }
            }
        }

        static void CreateAETask()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    string appName = "";
                    string servicePath = "";
                    SAServiceFolder[] folders;
                    SAServiceFolder location = new SAServiceFolder();

                    #region " Export services "

                    TaskDefinition tdExport = ts.NewTask();
                    tdExport.RegistrationInfo.Description = "";
                    tdExport.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr1 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr1.StartBoundary = DateTime.Now;
                    tr1.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdExport.Triggers.Add(tr1);
                    Trigger tr2 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr2.StartBoundary = DateTime.Now;
                    tr2.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdExport.Triggers.Add(tr2);
                    Trigger tr3 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr3.StartBoundary = DateTime.Now;
                    tr3.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdExport.Triggers.Add(tr3);
                    //
                    appName = "GMA_SA_AE_ExportTemplateService";
                    servicePath = Configuration.Info.StandAloneInfo.ServicePath;
                    folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdExport.Actions.Add(new ExecAction(string.Format(@"{0}{1}\Deploy\{2}.exe", servicePath, location.Path, appName),
                        string.Format(@"{0}{1}\Deploy\{2}.txt", servicePath, location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdExport);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }

                    #endregion

                    #region " Export services "

                    TaskDefinition tdAEService = ts.NewTask();
                    tdAEService.RegistrationInfo.Description = "";
                    tdAEService.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr4 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr4.StartBoundary = DateTime.Now;
                    tr4.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAEService.Triggers.Add(tr4);
                    Trigger tr5 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr5.StartBoundary = DateTime.Now;
                    tr5.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAEService.Triggers.Add(tr5);
                    Trigger tr6 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr6.StartBoundary = DateTime.Now;
                    tr6.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAEService.Triggers.Add(tr6);
                    //
                    appName = "GMA_SA_AfterEffectService";
                    servicePath = Configuration.Info.StandAloneInfo.ServicePath;
                    folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdAEService.Actions.Add(new ExecAction(string.Format(@"{0}{1}\Deploy\{2}.exe", servicePath, location.Path, appName),
                        string.Format(@"{0}{1}\Deploy\{2}.txt", servicePath, location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdAEService);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }
                    
                    #endregion

                }
                Console.WriteLine("Create AE jobs done");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void CreateMETask()
        {
            try {
                using (TaskService ts = new TaskService())
                {
                    string appName = "";
                    string servicePath = "";
                    SAServiceFolder[] folders;
                    SAServiceFolder location = new SAServiceFolder();

                    #region " Import services "

                    TaskDefinition tdMediaEndcoder = ts.NewTask();
                    tdMediaEndcoder.RegistrationInfo.Description = "";
                    tdMediaEndcoder.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr1 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr1.StartBoundary = DateTime.Now;
                    tr1.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdMediaEndcoder.Triggers.Add(tr1);
                    Trigger tr2 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr2.StartBoundary = DateTime.Now;
                    tr2.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdMediaEndcoder.Triggers.Add(tr2);
                    Trigger tr3 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr3.StartBoundary = DateTime.Now;
                    tr3.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdMediaEndcoder.Triggers.Add(tr3);
                    //
                    appName = "GMA_SA_ME_MediaEncoderService";
                    servicePath = Configuration.Info.StandAloneInfo.ServicePath;
                    folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if(location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdMediaEndcoder.Actions.Add(new ExecAction(string.Format(@"{0}{1}\Deploy\{2}.exe", servicePath, location.Path, appName),
                        string.Format(@"{0}{1}\Logs\{2}.txt", servicePath, location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdMediaEndcoder);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }
                    
                    #endregion

                    #region " Check render video services "

                    TaskDefinition tdCheckRenderVideo = ts.NewTask();
                    tdCheckRenderVideo.RegistrationInfo.Description = "";
                    tdCheckRenderVideo.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr4 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr4.StartBoundary = DateTime.Now;
                    tr4.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckRenderVideo.Triggers.Add(tr4);
                    Trigger tr5 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr5.StartBoundary = DateTime.Now;
                    tr5.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckRenderVideo.Triggers.Add(tr5);
                    Trigger tr6 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr6.StartBoundary = DateTime.Now;
                    tr6.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckRenderVideo.Triggers.Add(tr6);
                    //
                    appName = "GMA_SA_ME_CheckRenderedVideoService";
                    servicePath = Configuration.Info.StandAloneInfo.ServicePath;
                    folders = Configuration.Info.StandAloneInfo.SAServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdCheckRenderVideo.Actions.Add(new ExecAction(string.Format(@"{0}{1}\Deploy\{2}.exe", servicePath, location.Path, appName),
                        string.Format(@"{0}{1}\Logs\{2}.txt", servicePath, location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdCheckRenderVideo);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }

                    #endregion
                }
                Console.WriteLine("Create ME jobs done");
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        
    }
}
