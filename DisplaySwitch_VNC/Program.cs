using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DisplaySwitch_VNC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            string[] envargs = Environment.GetCommandLineArgs();

            //Run custom actions if command line switches are present
            if (envargs.Length > 1)
            {
                for (int index = 1; index < envargs.Length; index++)
                {
                    envargs[index] = envargs[index].TrimStart('-');

                    switch (envargs[index])
                    {
                        //If application already running, force the UI to appear (this is used in Desktop shortcut)
                        case "showui":
                            if (AlreadyRunning()) { Application.Run(new frmTray(true)); }
                            else { RegistryManagement.SetRegistryValue("ShowUINow", "true"); }
                            break;
                        //Start application with main UI not visible, used for logon event
                        case "startup":
                            Application.Run(new frmTray(false));
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                //If already running, show UI, else exit program
                if (AlreadyRunning()) { Application.Run(new frmTray(true)); }
            }
        }
        
        /// <summary>
        /// Checks if DisplaySwitch.exe (UI application) is already running for the current user
        /// </summary>
        /// <returns>True/false if the application is detected as running for current user</returns>
        private static bool AlreadyRunning()
        {
            Process[] sameAsThisSession = Process.GetProcessesByName("DisplaySwitch").Where(p => p.SessionId == Process.GetCurrentProcess().SessionId).ToArray();

            if (sameAsThisSession.Length == 1) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Write an entry to event log if there are any unhandled exceptions we have not handled elsewhere
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(error.Message + Environment.NewLine + Environment.NewLine + error.TargetSite.ToString(), EventLogEntryType.Error, 1410);
            }
        }
    }
}
