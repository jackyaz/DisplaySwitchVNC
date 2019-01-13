using System;
using System.Drawing;
using System.Windows.Forms;

namespace DisplaySwitch_VNC
{
    /// <summary>
    /// This form is used to allow the user to switch the shown display
    /// Form can be collapsed when VNC is connected to minimise screen real estate lost
    /// </summary>
    public partial class frmSwitchUI : Form
    {
        #region Variables

        //Variables for form state and allowed close behaviour
        private bool allowclose;
        private bool iscollapsed;

        #endregion

        #region Constructor

        /// <summary>
        /// COnstructor for the formo
        /// </summary>
        /// <param name="_allowclose">Is the form allowed to be closed (e.g. shown when VNC session not in progress)</param>
        public frmSwitchUI(bool _allowclose)
        {
            InitializeComponent();

            allowclose = _allowclose;

            //Set datasource for combobox to a list of currently connected screens
            cmbDisplaySelector.DataSource = VNC_Screen.EnumerateScreens();

            //Set combobox selection to match the current screen displayed from Registry value
            cmbDisplaySelector.SelectedIndex = VNC_Screen.EnumerateScreens().FindIndex(x => x.DeviceName == RegistryManagement.GetRegistryValue("DisplayDevice"));

            //Display full form
            RefreshSwitchUI(false);

            //Attach event handler for combobox
            cmbDisplaySelector.SelectedIndexChanged += new EventHandler(cmbDisplaySelector_SelectedIndexChanged);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Updates the location of the form relevant to the selected display
        /// </summary>
        /// <param name="collapse">Display form in a collapsed/shrunk state</param>
        private void RefreshSwitchUI(bool collapse)
        {
            //Only set if form state changing 
            if (iscollapsed != collapse)
            {
                //Set required size for form and show/hide panels with relevant controls
                if (!collapse) { this.Size = new Size(370, 95); pnlMin.Hide(); pnlMain.Show(); this.ControlBox = true; }
                else { this.Size = new Size(136, 95); pnlMain.Hide(); pnlMin.Show(); this.ControlBox = false; }
            }

            //Test if form is to be collapsed, and set the appropriate position for the form
            if (!collapse) { int[] windowpos = VNC_Screen.PositionForDisplay(false, RegistryManagement.GetRegistryValue("DisplayDevice")); this.Left = windowpos[0]; this.Top = windowpos[1]; }
            else { int[] windowpos = VNC_Screen.PositionForDisplay(true, RegistryManagement.GetRegistryValue("DisplayDevice")); this.Left = windowpos[0]; this.Top = windowpos[1]; }

            iscollapsed = collapse;
        }

        #endregion

        #region Events

        #region Controls

        /// <summary>
        /// When the combobox value is changed, set the Registry value using the selected value, and update position of form
        /// </summary>
        private void cmbDisplaySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryManagement.SetRegistryValue("DisplayDevice", cmbDisplaySelector.SelectedValue.ToString());
            RefreshSwitchUI(false);
        }

        /// <summary>
        /// Expand form from a collapsed state
        /// </summary>
        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshSwitchUI(false);
        }

        #endregion

        #region Form

        /// <summary>
        /// Make sure that the form is shown as TopMost by Windows using Windows API
        /// </summary>
        private void frmSwitchUI_Shown(object sender, EventArgs e)
        {
            NativeMethods.SetWindowPos(this.Handle, new IntPtr(-1), 0, 0, 0, 0, 0x0002 | 0x0001 | 0x0040);
        }

        /// <summary>
        /// Blocks form being closed and switches to a collapsed UI, unless form variable is set
        /// </summary>
        private void frmSwitchUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !allowclose) { e.Cancel = true; RefreshSwitchUI(true); }
        }

        #endregion

        #region EventLog

        /// <summary>
        /// Event to be fired when an Event Log entry for VNC Server has been written
        /// </summary>
        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {
            if (EventLogManagement.MonitorDisconnects(e)) { allowclose = true; this.Close(); }
        }

        #endregion

        #region Timer

        /// <summary>
        /// Event for our Registry polling Timer
        /// </summary>
        private void tmrCheckReg_Tick(object sender, EventArgs e)
        {
            //Don't fire if user is currently selecting a display
            if (!cmbDisplaySelector.DroppedDown)
            {
                //Only fire if the last session state indicates a user is currently logged in
                if (RegistryManagement.GetRegistryValue("SessionChange") == "SessionLogon" || RegistryManagement.GetRegistryValue("SessionChange") == "SessionUnlock")
                {
                    //Check if the selected value is different to the set value
                    if (cmbDisplaySelector.SelectedValue.ToString() != RegistryManagement.GetRegistryValue("DisplayDevice"))
                    {
                        //Set the combobox value to match the displayed screen from Registry
                        if (RegistryManagement.GetRegistryValue("DisplayDevice") != "") { cmbDisplaySelector.SelectedIndex = VNC_Screen.EnumerateScreens().FindIndex(x => x.DeviceName == RegistryManagement.GetRegistryValue("DisplayDevice")); }
                        else { cmbDisplaySelector.SelectedIndex = 0; }
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}
