using System;
using System.Collections.Generic;
using System.Linq;

namespace DisplaySwitch_Service_VNC
{
    public class VNC_Screen
    {
        private string friendlyname;
        private string devicename;
        private int x;
        private int y;
        private int height;
        private int width;
        private bool primary;

        public string FriendlyName { get { return friendlyname; } }
        public string DeviceName { get { return devicename; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Height { get { return height; } }
        public int Width { get { return width; } }
        public bool Primary { get { return primary; } }

        public static List<VNC_Screen> EnumerateScreens()
        {
            List<VNC_Screen> screens = new List<VNC_Screen>();

            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens) { screens.Add(new VNC_Screen(screen.DeviceName, screen.WorkingArea.X, screen.WorkingArea.Y, screen.WorkingArea.Height, screen.WorkingArea.Width, screen.Primary)); }

            screens = screens.OrderBy(s => s.x).ThenBy(s => s.y).ToList();
            int displaynum = 1;

            foreach (VNC_Screen screen in screens) { screen.friendlyname = "Display " + displaynum; displaynum++; }
            screens.Insert(0, (new VNC_Screen("All Monitors", "", 0, 0, 0, 0, false)));
            return screens;
        }

        public static VNC_Screen GetScreenByDeviceName(string name)
        {
            if (name == "") { return VNC_Screen.EnumerateScreens().Find(x => x.DeviceName == "\\\\.\\DISPLAY1"); }
            else { return VNC_Screen.EnumerateScreens().Find(x => x.DeviceName == name); }
        }

        public static VNC_Screen GetPrimaryScreen()
        {
            return VNC_Screen.EnumerateScreens().Find(x => x.Primary == true);
        }

        public static int[] StartPositionForDisplay(string screenname)
        {
            int startx = 0;
            int starty = 0;

            VNC_Screen screen = VNC_Screen.GetScreenByDeviceName(screenname);
            startx = screen.x + 25;
            starty = screen.y + 25;

            return new int[] { startx, starty };
        }

        public static int[] CollapsedPositionForDisplay(string screenname)
        {
            int startx = 0;
            int starty = 0;

            VNC_Screen screen = VNC_Screen.GetScreenByDeviceName(screenname);
            startx = screen.x + 25;
            starty = screen.height - 84 - 25;

            return new int[] { startx, starty };
        }

        public VNC_Screen(string _friendlyname, string _devicename, int _x, int _y, int _height, int _width, bool _primary)
        {
            friendlyname = _friendlyname;
            devicename = _devicename;
            x = _x;
            y = _y;
            height = _height;
            width = _width;
            primary = _primary;
        }

        public VNC_Screen(string _devicename, int _x, int _y, int _height, int _width, bool _primary)
        {
            devicename = _devicename;
            x = _x;
            y = _y;
            height = _height;
            width = _width;
            primary = _primary;
        }
    }
}
