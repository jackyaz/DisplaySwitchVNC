using System;
using System.Collections.Generic;
using System.Linq;

namespace DisplaySwitch_VNC
{
    /// <summary>
    /// A class for managing screens in DisplaySwitch
    /// </summary>
    internal class VNC_Screen
    {
        #region Property Declarations
        public string FriendlyName { get; private set; }
        public string DeviceName { get; }
        public int X { get; }
        public int Y { get; }
        public int Height { get; }
        public int Width { get; }
        public bool Primary { get; }
        #endregion

        /// <summary>
        /// Enumerates from System.Windows.Forms.AllScreens with selected properties and additional custom properties
        /// </summary>
        /// <returns>A list of all currently detected screens by Windows</returns>
        public static List<VNC_Screen> EnumerateScreens()
        {
            List<VNC_Screen> screens = new List<VNC_Screen>();

            //Loop through AllScreens array and cherry-pick the properties we need
            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens) { screens.Add(new VNC_Screen(screen.DeviceName, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Height, screen.WorkingArea.Width, screen.Primary)); }

            //Order the list by screen X co-ordinate then Y co-ordinate
            screens = screens.OrderBy(s => s.X).ThenBy(s => s.Y).ToList();

            //Add friendly name in the format "Display X"
            int displaynum = 1;
            foreach (VNC_Screen screen in screens) { screen.FriendlyName = "Display " + displaynum; displaynum++; }

            //Insert placeholder VNC_Screen for All Monitors
            screens.Insert(0, (new VNC_Screen("All Monitors", "", screens[0].X, screens[0].Y, screens[0].Height, screens[0].Width, false)));

            return screens;
        }

        /// <summary>
        /// Return a specifc VNC_Screen object for a given DeviceName
        /// </summary>
        /// <param name="screenname">The DeviceName as reported by Windows/VNC Server</param>
        /// <returns>The matching VNC_Screen object</returns>
        public static VNC_Screen GetScreenByDeviceName(string screenname)
        {
            if (EnumerateScreens().Find(x => x.DeviceName == screenname) == null)
            {
                VNC_Screen _screen = GetPrimaryScreen();
                RegistryManagement.SetRegistryValue("DisplayDevice", _screen.DeviceName);
                return _screen;
            }
            else
            {
                return EnumerateScreens().Find(x => x.DeviceName == screenname);
            }
        }

        /// <summary>
        /// Returns the VNC_Screen for the Primary display
        /// </summary>
        /// <returns>The matching VNC_Screen object</returns>
        public static VNC_Screen GetPrimaryScreen()
        {
            return VNC_Screen.EnumerateScreens().Find(x => x.Primary == true);
        }

        /// <summary>
        /// Returns relative location to draw a control for a specific display
        /// </summary>
        /// <param name="collapsed">Collapsed or full form location required</param>
        /// <param name="screenname">The DeviceName of the display</param>
        /// <returns>Integer array of offset x and y co-ordinates for display</returns>
        public static int[] PositionForDisplay(bool collapsed, string screenname)
        {
            VNC_Screen screen = GetScreenByDeviceName(screenname);
            if (collapsed) { return new int[] { screen.X + 20, screen.Height - 95 - 20 }; }
            else { return new int[] { screen.X + 20, screen.Y + 20 }; }
        }

        /// <summary>
        /// Constructor for VNC_Screen class
        /// </summary>
        /// <param name="_friendlyname">The user-friendly name of the display</param>
        /// <param name="_devicename">The name of the display as reported by Windows e.g. \\.\DISPLAY1</param>
        /// <param name="_x">The x co-ordinate of the top left of the display</param>
        /// <param name="_y">The y co-ordinate of the top left of the display</param>
        /// <param name="_height">The height of the display</param>
        /// <param name="_width">The width of the disp,ay</param>
        /// <param name="_primary">If the display is the primary display e.g. contains system tray</param>
        public VNC_Screen(string _friendlyname, string _devicename, int _x, int _y, int _height, int _width, bool _primary)
        {
            FriendlyName = _friendlyname;
            DeviceName = _devicename;
            X = _x;
            Y = _y;
            Height = _height;
            Width = _width;
            Primary = _primary;
        }

        /// <summary>
        /// Constructor for VNC_Screen class when friendly name unknown
        /// </summary>
        /// <param name="_devicename">The name of the display as reported by Windows e.g. \\.\DISPLAY1</param>
        /// <param name="_x">The x co-ordinate of the top left of the display</param>
        /// <param name="_y">The y co-ordinate of the top left of the display</param>
        /// <param name="_height">The height of the display</param>
        /// <param name="_width">The width of the disp,ay</param>
        /// <param name="_primary">If the display is the primary display e.g. contains system tray</param>
        public VNC_Screen(string _devicename, int _x, int _y, int _height, int _width, bool _primary)
        {
            DeviceName = _devicename;
            X = _x;
            Y = _y;
            Height = _height;
            Width = _width;
            Primary = _primary;
        }
    }
}
