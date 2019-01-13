using System;
using System.ServiceProcess;
using System.Timers;

namespace DisplaySwitch_Service_VNC
{
    /// <summary>
    /// Class that contains the methods for the DisplaySwitch Service
    /// </summary>
    public partial class DisplaySwitchService : ServiceBase
    {
        System.Timers.Timer tmrCheckDisplayDevice;

        public DisplaySwitchService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Run required actions when Service starts
        /// </summary>
        protected override void OnStart(string[] args)
        {
            //Add entries for DisplaySwitch to all users' startup
            RegistryManagement.SetStartup();

            //Make sure VNC Server is configured to log connections to EventLog - required for automatic UI display when VNC session starts/ends
            if (RegistryManagement.GetRegistryValue(RegHives.HKLM, "Log") == "")
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "Log", "*:EventLog:10");
            }
            else if (RegistryManagement.GetRegistryValue(RegHives.HKLM, "Log") != "*:EventLog:10" && !RegistryManagement.GetRegistryValue(RegHives.HKLM, "Log").Contains("Connections:EventLog"))
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "Log", RegistryManagement.GetRegistryValue(RegHives.HKLM, "Log") + ",Connections:EventLog:10");
            }

            //Configure our timer to poll for Registry changes
            tmrCheckDisplayDevice = new System.Timers.Timer(100);
            tmrCheckDisplayDevice.Elapsed += new ElapsedEventHandler(tmrCheckDisplayDevice_Tick);
            tmrCheckDisplayDevice.AutoReset = true;
            tmrCheckDisplayDevice.Enabled = true;

            //When service starts, default to last recorded Primary display (this will usually be on system start)
            RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKLM_DS, "PrimaryMonitor"));
        }

        /// <summary>
        /// If service is stopped, default to Primary and remove entries for DisplaySwitch from user startup folder
        /// </summary>
        protected override void OnStop()
        {
            tmrCheckDisplayDevice.Stop();
            RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKLM_DS, "PrimaryMonitor"));
            RegistryManagement.ClearStartup();
        }

        /// <summary>
        /// If a shutdown event is detected, make sure we set Display to Primary so user can see logon screen over VNC when system comes back up
        /// </summary>
        protected override void OnShutdown()
        {
            tmrCheckDisplayDevice.Stop();
            RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKLM_DS, "PrimaryMonitor"));
        }

        /// <summary>
        /// Tracks session changes reported by Windows and makes changes to the display served by VNC Server
        /// </summary>
        /// <param name="sessionChangeDescription">The session change as reported by Windows</param>
        protected override void OnSessionChange(SessionChangeDescription sessionChangeDescription)
        {
            RegistryManagement.SetRegistryValue(RegHives.HKCU, "SessionChange", sessionChangeDescription.Reason.ToString());

            switch (sessionChangeDescription.Reason)
            {
                //When user logs on, set VNC Server to use user's selected screen
                case SessionChangeReason.SessionLogon:
                    RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKCU, "DisplayDevice"));
                    tmrCheckDisplayDevice.Start();
                    break;

                //When user logs off, set VNC Server to primary screen (to see login screen)
                case SessionChangeReason.SessionLogoff:
                    tmrCheckDisplayDevice.Stop();
                    RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKCU, "PrimaryMonitor"));
                    break;

                //When user locks their session, set VNC Server to primary screen (to see lock screen)
                case SessionChangeReason.SessionLock:
                    tmrCheckDisplayDevice.Stop();
                    RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKCU, "PrimaryMonitor"));
                    break;

                //When user unlocks their session, set VNC Server to use user's selected screen
                case SessionChangeReason.SessionUnlock:
                    RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKCU, "DisplayDevice"));
                    tmrCheckDisplayDevice.Start();
                    break;
            }
        }

        /// <summary>
        /// Event called when tmrCheckDisplayDevice elapses
        /// </summary>
        private void tmrCheckDisplayDevice_Tick(object sender, ElapsedEventArgs e)
        {
            //If the master record for DisplayDevice does not match the user's selection, update it
            if (RegistryManagement.GetRegistryValue(RegHives.HKLM, "DisplayDevice") != RegistryManagement.GetRegistryValue(RegHives.HKCU, "DisplayDevice"))
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "DisplayDevice", RegistryManagement.GetRegistryValue(RegHives.HKCU, "DisplayDevice"));
            }

            //If the master record for Primary Monitor does not match the user's selection, update it
            if (RegistryManagement.GetRegistryValue(RegHives.HKLM_DS, "PrimaryMonitor") != RegistryManagement.GetRegistryValue(RegHives.HKCU, "PrimaryMonitor"))
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM_DS, "PrimaryMonitor", RegistryManagement.GetRegistryValue(RegHives.HKCU, "PrimaryMonitor"));
            }
        }
    }
}
