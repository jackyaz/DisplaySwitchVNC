using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExeMsiCombiner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                MainForm mainForm = new MainForm();
                return mainForm.RunInCommandLineMode(args) ? 0 : -1;
            }
            else
            {
                Application.Run(new MainForm());
                return 0;
            }
        }
    }
}
