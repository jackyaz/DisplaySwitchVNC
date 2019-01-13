using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace DisplaySwitch_VNC
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
        public static bool IsVNCConnected()
        {
            List<EventLogEntry> list = new List<EventLogEntry>();

            //Retrieve all events of source VNC Server, and iterate to add to a list
            EventLog evlg = new EventLog("Application", ".", "VNC Server");
            EventLogEntryCollection col = evlg.Entries;
            foreach (EventLogEntry ev in col)
            {
                if (ev.Source == "VNC Server") { list.Add(ev); }
            }

            //Find the last entry recorded for a VNC authentication event - note we use authenticated rather than connected
            //since a connection does not necessarily indicate the user authenticated to use VNC Server
            int indexlastauth = list.FindLastIndex(x => x.Message.StartsWith("Connections: authenticated:"));

            //Find the last entry recorded for a VNC disconnection event
            int indexlastconn = list.FindLastIndex(x => x.Message.StartsWith("Connections: disconnected:"));

            //If authentication is greater than disconnection, assume a user is currently connected
            if (indexlastauth > indexlastconn) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Tests if the provided EventLog Entry contains a VNC Server authentication success, to determine if user is connected
        /// </summary>
        /// <returns>True/false if a user has authenticated</returns>
        public static bool MonitorAuths(EntryWrittenEventArgs e)
        {
            if (e.Entry.Source == "VNC Server" && e.Entry.Message.StartsWith("Connections: authenticated:")) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Tests if the provided EventLog Entry contains a VNC Server disconnection, to determine if user is no longer connected
        /// </summary>
        /// <returns>Boolean if a user has disconnected</returns>
        public static bool MonitorDisconnects(EntryWrittenEventArgs e)
        {
            if (e.Entry.Source == "VNC Server" && e.Entry.Message.StartsWith("Connections: disconnected:")) { return true; }
            else { return false; }
        }
    }
}
