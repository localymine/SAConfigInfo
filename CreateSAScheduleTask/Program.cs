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


                    // Create an action that will launch Notepad whenever the trigger fires
                    tdExport.Actions.Add(new ExecAction(@"D:\\WindowsService\\GMA_SA_AE_ExportTemplateService\\Deploy\\GMA_SA_AE_ExportTemplateService.exe",
                        @"D:\\WindowsService\\GMA_SA_AE_ExportTemplateService\\logs\\GMA_SA_AE_ExportTemplateService.txt", null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("GMA_SA_AE_ExportTemplateService", tdExport);

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


                    // Create an action that will launch Notepad whenever the trigger fires
                    tdAEService.Actions.Add(new ExecAction(@"D:\\WindowsService\\GMA_SA_AfterEffectService\\Deploy\\GMA_SA_AfterEffectService.exe",
                        @"D:\\WindowsService\\GMA_SA_AfterEffectService\\logs\\GMA_SA_AfterEffectService.txt", null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("GMA_SA_AfterEffectService", tdAEService);

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


                    // Create an action that will launch Notepad whenever the trigger fires
                    tdMediaEndcoder.Actions.Add(new ExecAction(@"D:\\WindowsService\\GMA_SA_ME_MediaEncoderService\\Deploy\\GMA_SA_ME_MediaEncoderService.exe",
                        @"D:\\WindowsService\\GMA_SA_ME_MediaEncoderService\\logs\\GMA_SA_ME_MediaEncoderService.txt", null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("GMA_SA_ME_MediaEncoderService", tdMediaEndcoder);

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


                    // Create an action that will launch Notepad whenever the trigger fires
                    tdCheckRenderVideo.Actions.Add(new ExecAction(@"D:\\WindowsService\\GMA_SA_ME_CheckRenderedVideoService\\Deploy\\GMA_SA_ME_CheckRenderedVideoService.exe",
                        @"D:\\WindowsService\\GMA_SA_ME_CheckRenderedVideoService\\logs\\GMA_SA_ME_CheckRenderedVideoService.txt", null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("GMA_SA_ME_CheckRenderedVideoService", tdCheckRenderVideo);

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
