using Microsoft.Win32.TaskScheduler;
using SA_Config_Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSVScheduleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration.GetConfigInfo("ConfigInfo.xml");
            if (Configuration.Info != null)
            {
                CreateTask();
            }
            Console.ReadKey();
        }

        static void CreateTask()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    string appName = "";
                    SVServiceFolder[] folders;
                    SVServiceFolder location = new SVServiceFolder();

                    #region " Assign Task  services "

                    TaskDefinition tdAssignTask = ts.NewTask();
                    tdAssignTask.RegistrationInfo.Description = "";
                    tdAssignTask.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr1 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr1.StartBoundary = DateTime.Now;
                    tr1.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAssignTask.Triggers.Add(tr1);
                    Trigger tr2 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr2.StartBoundary = DateTime.Now;
                    tr2.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAssignTask.Triggers.Add(tr2);
                    Trigger tr3 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr3.StartBoundary = DateTime.Now;
                    tr3.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdAssignTask.Triggers.Add(tr3);
                    //
                    appName = "GMA_SV_AssignAfterEffectService";
                    folders = Configuration.Info.ServerInfo.SVServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdAssignTask.Actions.Add(new ExecAction(string.Format(@"{0}\Deploy\{1}.exe", location.Path, appName),
                        string.Format(@"{0}\Deploy\{1}.txt", location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdAssignTask);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }

                    #endregion

                    #region " Timeout services "

                    TaskDefinition tdCheckTimeOut = ts.NewTask();
                    tdCheckTimeOut.RegistrationInfo.Description = "";
                    tdCheckTimeOut.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr4 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr4.StartBoundary = DateTime.Now;
                    tr4.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckTimeOut.Triggers.Add(tr4);
                    Trigger tr5 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr5.StartBoundary = DateTime.Now;
                    tr5.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckTimeOut.Triggers.Add(tr5);
                    Trigger tr6 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr6.StartBoundary = DateTime.Now;
                    tr6.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdCheckTimeOut.Triggers.Add(tr6);
                    //
                    appName = "GMA_SV_CheckTimeOutService";
                    folders = Configuration.Info.ServerInfo.SVServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdCheckTimeOut.Actions.Add(new ExecAction(string.Format(@"{0}\Deploy\{1}.exe", location.Path, appName),
                        string.Format(@"{0}\Deploy\{1}.txt", location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdCheckTimeOut);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }

                    #endregion

                    #region " Notification services "

                    TaskDefinition tdNotification = ts.NewTask();
                    tdNotification.RegistrationInfo.Description = "";
                    tdNotification.RegistrationInfo.Date = DateTime.Now;

                    Trigger tr7 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr7.StartBoundary = DateTime.Now;
                    tr7.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdNotification.Triggers.Add(tr7);
                    Trigger tr8 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr8.StartBoundary = DateTime.Now;
                    tr8.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdNotification.Triggers.Add(tr8);
                    Trigger tr9 = Trigger.CreateTrigger(TaskTriggerType.Time);
                    tr9.StartBoundary = DateTime.Now;
                    tr9.Repetition = new RepetitionPattern(new TimeSpan(0, 1, 0), TimeSpan.Zero, false);
                    tdNotification.Triggers.Add(tr9);
                    //
                    appName = "GMA_SV_NotificationService";
                    folders = Configuration.Info.ServerInfo.SVServicePaths;
                    location = folders.FirstOrDefault(m => m.Path.Contains(appName));
                    if (location != null)
                    {
                        // Create an action that will launch Notepad whenever the trigger fires
                        tdNotification.Actions.Add(new ExecAction(string.Format(@"{0}\Deploy\{1}.exe", location.Path, appName),
                        string.Format(@"{0}\Deploy\{1}.txt", location.Path, appName), null));
                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(appName, tdNotification);
                    }
                    else
                    {
                        Console.WriteLine("Service: " + appName);
                        Console.WriteLine("URL setup file not found");
                    }

                    #endregion

                }
                Console.WriteLine("Create jobs done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
