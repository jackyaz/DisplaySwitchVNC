using System;
using Microsoft.Win32;

namespace DisplaySwitch_Service_VNC
{
    public enum RegHives { HKLM_DS, HKLM, HKCU }

    /// <summary>
    /// A class to manage reading/writing to specific Registry keys
    /// </summary>
    public static class RegistryManagement
    {
        private static readonly string appname = "DisplaySwitch";

        /// <summary>
        /// Queries the Registry to detect the last user that logged in (i.e. the current user)
        /// </summary>
        /// <returns>A string containing the Security Identifier (SID) for the logged in user</returns>
        private static string GetSIDForCurrentUser()
        {
            RegistryKey regkey = GetHKLM().OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI");
            string value = "";
            try { value = regkey.GetValue("LastLoggedOnUserSID").ToString(); regkey.Close(); }
            catch { }
            return value;
        }

        /// <summary>
        /// Returns the relevant Registry key for HKLM on 32bit and 64bit Windows OS
        /// </summary>
        /// <returns>The correct Regsitry key for the system architecture</returns>
        private static RegistryKey GetHKLM()
        {
            RegistryKey localMachineRegistry;

            if (Environment.Is64BitOperatingSystem) { localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64); }
            else { localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32); }

            return localMachineRegistry;
        }

        /// <summary>
        /// Retrieves the current value for a specified String value in the Registry Key for DisplaySwitch or VNC Server
        /// </summary>
        /// <param name="reg">Whether the key to be set belongs to Local Machine or Current User</param>
        /// <param name="valuename">The name of the String to retrieve</param>
        /// <returns>The value of the String</returns>
        public static string GetRegistryValue(RegHives reg, string valuename)
        {
            RegistryKey regkey;
            if (reg == RegHives.HKLM) { regkey = RegistryManagement.GetHKLM().OpenSubKey("SOFTWARE\\RealVNC\\vncserver", false); }
            else if (reg == RegHives.HKLM_DS) { regkey = RegistryManagement.GetHKLM().OpenSubKey("SOFTWARE\\RealVNC_DisplaySwitch", false); }
            else { regkey = Registry.Users.OpenSubKey(GetSIDForCurrentUser() + "\\SOFTWARE\\RealVNC_DisplaySwitch", false); }
            string value = "";
            try { value = regkey.GetValue(valuename).ToString(); regkey.Close(); }
            catch { }
            return value;
        }

        /// <summary>
        /// Sets the value for a specified String value in the Registry Key for DisplaySwitch or VNC Server
        /// </summary>
        /// <param name="reg">Whether the key to be set belongs to Local Machine or Current User</param>
        /// <param name="valuename">The name of the String to set</param>
        /// <param name="value">The value to set</param>
        public static void SetRegistryValue(RegHives reg, string valuename, string value)
        {
            RegistryKey regkey;
            if (reg == RegHives.HKLM) { regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\RealVNC\\vncserver", true); }
            else if (reg == RegHives.HKLM_DS) { regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\RealVNC_DisplaySwitch", true); }
            else { regkey = Registry.Users.CreateSubKey(GetSIDForCurrentUser() + "\\SOFTWARE\\RealVNC_DisplaySwitch", true); }
            regkey.SetValue(valuename, value, RegistryValueKind.String);
            regkey.Close();
        }

        /// <summary>
        /// Add key to start DisplaySwitch user UI on startup for all users
        /// </summary>
        public static void SetStartup()
        {
            RegistryKey regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            regkey.SetValue(appname, "\"" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\DisplaySwitch for RealVNC\\DisplaySwitch.exe\" -startup", RegistryValueKind.String);
            regkey.Close();
        }

        /// <summary>
        /// Remove key to stop DisplaySwitch user UI appearing on startup for all users
        /// </summary>
        public static void ClearStartup()
        {
            RegistryKey regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (regkey.GetValue(appname) != null) { regkey.DeleteValue(appname); }
            regkey.Close();
        }
    }
}
