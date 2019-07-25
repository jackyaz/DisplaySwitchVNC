using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;

namespace DisplaySwitch_Service_VNC
{
    /// <summary>
    /// A class for managing Service installation actions
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the DisplaySwitch service once the service has been installed
        /// </summary>
        private void serviceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName))
            {
                sc.Start();
            }
        }

        /// <summary>
        /// Once DisplaySwitch service is installed, remove the InstallState file (looks messy!)
        /// </summary>
        private void serviceInstaller_Committing(object sender, InstallEventArgs e)
        {
            string installedPath = string.Empty;
            installedPath = Context.Parameters["assemblypath"];
            installedPath = installedPath.Substring(0, installedPath.LastIndexOf('\\'));

            File.Delete(Path.Combine(installedPath, "DisplaySwitch_Service_VNC.InstallState"));
        }

        /// <summary>
        /// Sets the path for this installing assembly
        /// </summary>
        private void serviceInstaller_BeforeInstall(object sender, InstallEventArgs e)
        {
            base.Context.Parameters["assemblyPath"] = string.Format("\"{0}\" /service", base.Context.Parameters["assemblyPath"]);
        }
    }
}
