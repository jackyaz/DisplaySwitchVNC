using System;
using System.Windows.Forms;

namespace DisplaySwitch_VNC
{
    /// <summary>
    /// This form is used to launch the main SwitchUI, while remaining as running in the background
    /// </summary>
    public partial class frmTray : Form
    {
        #region Overrides

        /// <summary>
        /// These are used to let frmTray launch as a truly hidden form with no brief UI flashing
        /// </summary>
        private bool _canShow = false;

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(_canShow && value);
        }

        protected override CreateParams CreateParams
        {
            get { var cp = base.CreateParams; cp.ExStyle |= 0x80; return cp; }
        }

        #endregion

        /// <summary>
        /// Constructor for frmTray
        /// </summary>
        /// <param name="showui">Whether frmSwitchUI should be shown when frmTray starts</param>
        public frmTray(bool showui)
        {
            InitializeComponent();

            //Reduce form size to 0 i.e. hidden
            this.Size = new System.Drawing.Size(0, 0);

            //Check if a VNC session is already in progress, show frmSwitchUI if so
            if (EventLogManagement.IsVNCConnected()) { ShowSwitchUI(false); }

            //If specified, show frmSwitchUI now
            if (showui) { ShowSwitchUI(true); }

            //Tidy up property for SetVisibleCore override
            _canShow = true;
            this.Show();
        }

        #region Methods

        /// <summary>
        /// Opens frmSwitchUI for swtiching displays. Checks if an instance is already showing, to prevent multiple forms
        /// </summary>
        /// <param name="allowclose">Whether frmSwitchUI can close, or collapse</param>
        private void ShowSwitchUI(bool allowclose)
        {
            if (!bgwShowSwitchUI.IsBusy) { bgwShowSwitchUI.RunWorkerAsync(allowclose); }
        }

        #endregion

        #region Events

        #region EventLog

        /// <summary>
        /// Event fired when Event Log entry written by VNC Server
        /// </summary>
        private void evtlgAuthenticated_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {
            //If log entry is a VNC authentication, show frmSwitchUI and block closure - collapsable only
            if (EventLogManagement.MonitorAuths(e)) { ShowSwitchUI(false); }
        }

        #endregion

        #region BackgroundWorker

        /// <summary>
        /// Actions to carry out on the background thread
        /// We use it to show frmSwitchUI on a separate thread so frmTray can continue to process events while frmSwitchUI is shown
        /// </summary>
        private void bgwShowSwitchUI_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            frmSwitchUI frm = new frmSwitchUI(Convert.ToBoolean(e.Argument));
            frm.ShowDialog();
        }

        /// <summary>
        /// Event when the BackgroundWorker has completed i.e. frmSwitchUI has been closed
        /// </summary>
        private void bgwShowSwitchUI_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //If a VNC session is still running, bring back the SwitchUI
            if (EventLogManagement.IsVNCConnected()) { ShowSwitchUI(false); }
        }

        #endregion

        #region NotifyIcon

        /// <summary>
        /// Event when notification/system tray icon is double clicked
        /// </summary>
        private void nticoMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Show SwitchUI form and allow it to be closed
            ShowSwitchUI(true);
        }

        #endregion

        #region ToolStrip

        /// <summary>
        /// Event when the Show item is clicked on the tray icon context menu
        /// </summary>
        private void toolMenuItemShow_Click(object sender, EventArgs e)
        {
            //Show SwitchUI form and allow it to be closed rather than collapsed
            ShowSwitchUI(true);
        }

        /// <summary>
        /// Event when the Exit item is clicked on the tray icon context menu
        /// </summary>
        private void toolMenuItemExit_Click(object sender, EventArgs e)
        {
            //Close this form which will cause Application to exit since frmTray is main form
            this.Close();
        }

        #endregion

        #region Form

        /// <summary>
        /// Actions to run when the form is shown
        /// </summary>
        private void frmTray_Shown(object sender, EventArgs e)
        {
            //Toggle notification/system tray icon - for some reason it doesn't show reliably without
            nticoMain.Visible = false;
            nticoMain.Visible = true;

            //Hide the form for frmTray - we're only concerned with the tray icon
            //We do this so the SwitchUI can be launched as a separate form from the main application
            _canShow = false;
            this.Hide();

            //Query our service state - catch error if DisplaySwitch service is not installed for some reason
            try
            {
                //Check if our DisplaySwitch service is running - exit if not
                if (srvctrlDisplaySwitch.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    MessageBox.Show("VNC Display Switch service not running, exiting", "Display Switch for Service Mode VNC Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("VNC Display Switch service not found", "Display Switch for Service Mode VNC Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //Query VNC Server service state - catch error if VNC Server service is not installed for some reason
            try
            {
                //Check if VNC Server service is running - exit if not
                if (srvctrlVNCServer.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    MessageBox.Show("VNC Server service not running, exiting", "Display Switch for Service Mode VNC Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("VNC Server service not found", "Display Switch for Service Mode VNC Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        #endregion

        #region Timers

        /// <summary>
        /// Event fired when tmrShowSwitchUI elapses - used to force frmSwitchUI to show if invoked via an appropriate command
        /// </summary>
        private void tmrShowSwitchUI_Tick(object sender, EventArgs e)
        {
            bool showuinow = false;

            if (RegistryManagement.GetRegistryValue("ShowUINow") != "") { showuinow = Convert.ToBoolean(RegistryManagement.GetRegistryValue("ShowUINow")); }

            if (showuinow) { RegistryManagement.SetRegistryValue("ShowUINow", "false"); ShowSwitchUI(true); }
        }

        /// <summary>
        /// Event fired when tmrCheckPrimaryScreen elapses - used to ensure we have recorded the correct primary display
        /// </summary>
        private void tmrCheckPrimaryScreen_Tick(object sender, EventArgs e)
        {
            if (RegistryManagement.GetRegistryValue("PrimaryMonitor") != VNC_Screen.GetPrimaryScreen().DeviceName)
            {
                RegistryManagement.SetRegistryValue("PrimaryMonitor", VNC_Screen.GetPrimaryScreen().DeviceName);
            }
        }

        #endregion

        #endregion
    }
}