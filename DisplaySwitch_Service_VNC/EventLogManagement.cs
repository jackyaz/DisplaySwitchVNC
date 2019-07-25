using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DisplaySwitch_Service_VNC
{
    /// <summary>
    /// Class to manage VNC session states via Windows Event Log
    /// Currently designed for single user sessions - issues will occur with concurrent users and disconnects
    /// </summary>
    internal static class EventLogManagement
    {
        /// <summary>
        /// Checks if a VNC session is currently in progress
        /// </summary>
        /// <returns>Boolean whether VNC Session in progress</returns>
        public static void WriteEvent()
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Computer shutdown detected", EventLogEntryType.Warning, 1410);
            }
        }
    }
}
