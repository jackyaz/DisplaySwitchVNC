using System;
using System.Runtime.InteropServices;

namespace DisplaySwitch_VNC
{
    /// <summary>
    /// Class containing functions that interact with native Windows APIs
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Sets a window's position and z-layer, when Windows Forms is unable to reliably
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }
}
