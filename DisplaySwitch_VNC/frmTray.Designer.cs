namespace DisplaySwitch_VNC
{
    partial class frmTray
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTray));
            this.nticoMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contxtMenuNotIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.evtlgAuthenticated = new System.Diagnostics.EventLog();
            this.bgwShowSwitchUI = new System.ComponentModel.BackgroundWorker();
            this.srvctrlVNCServer = new System.ServiceProcess.ServiceController();
            this.tmrShowSwitchUI = new System.Windows.Forms.Timer(this.components);
            this.srvctrlDisplaySwitch = new System.ServiceProcess.ServiceController();
            this.tmrCheckPrimaryScreen = new System.Windows.Forms.Timer(this.components);
            this.contxtMenuNotIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evtlgAuthenticated)).BeginInit();
            this.SuspendLayout();
            // 
            // nticoMain
            // 
            this.nticoMain.ContextMenuStrip = this.contxtMenuNotIcon;
            this.nticoMain.Icon = ((System.Drawing.Icon)(resources.GetObject("nticoMain.Icon")));
            this.nticoMain.Text = "RealVNC DisplaySwitch";
            this.nticoMain.Visible = true;
            this.nticoMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nticoMain_MouseDoubleClick);
            // 
            // contxtMenuNotIcon
            // 
            this.contxtMenuNotIcon.AllowMerge = false;
            this.contxtMenuNotIcon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contxtMenuNotIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxtMenuNotIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuItemShow,
            this.toolMenuItemExit});
            this.contxtMenuNotIcon.Name = "contxtMenuNotIcon";
            this.contxtMenuNotIcon.Size = new System.Drawing.Size(106, 48);
            // 
            // toolMenuItemShow
            // 
            this.toolMenuItemShow.Name = "toolMenuItemShow";
            this.toolMenuItemShow.Size = new System.Drawing.Size(105, 22);
            this.toolMenuItemShow.Text = "Show";
            this.toolMenuItemShow.Click += new System.EventHandler(this.toolMenuItemShow_Click);
            // 
            // toolMenuItemExit
            // 
            this.toolMenuItemExit.Name = "toolMenuItemExit";
            this.toolMenuItemExit.ShowShortcutKeys = false;
            this.toolMenuItemExit.Size = new System.Drawing.Size(105, 22);
            this.toolMenuItemExit.Text = "Exit";
            this.toolMenuItemExit.Click += new System.EventHandler(this.toolMenuItemExit_Click);
            // 
            // evtlgAuthenticated
            // 
            this.evtlgAuthenticated.EnableRaisingEvents = true;
            this.evtlgAuthenticated.Log = "Application";
            this.evtlgAuthenticated.SynchronizingObject = this;
            this.evtlgAuthenticated.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.evtlgAuthenticated_EntryWritten);
            // 
            // bgwShowSwitchUI
            // 
            this.bgwShowSwitchUI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwShowSwitchUI_DoWork);
            this.bgwShowSwitchUI.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwShowSwitchUI_RunWorkerCompleted);
            // 
            // srvctrlVNCServer
            // 
            this.srvctrlVNCServer.ServiceName = "vncserver";
            // 
            // tmrShowSwitchUI
            // 
            this.tmrShowSwitchUI.Enabled = true;
            this.tmrShowSwitchUI.Tick += new System.EventHandler(this.tmrShowSwitchUI_Tick);
            // 
            // srvctrlDisplaySwitch
            // 
            this.srvctrlDisplaySwitch.ServiceName = "VNC Server DisplaySwitch";
            // 
            // tmrCheckPrimaryScreen
            // 
            this.tmrCheckPrimaryScreen.Enabled = true;
            this.tmrCheckPrimaryScreen.Interval = 1000;
            this.tmrCheckPrimaryScreen.Tick += new System.EventHandler(this.tmrCheckPrimaryScreen_Tick);
            // 
            // frmTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(148, 29);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTray";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DisplaySwitch Tray UI";
            this.Shown += new System.EventHandler(this.frmTray_Shown);
            this.contxtMenuNotIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evtlgAuthenticated)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nticoMain;
        private System.Windows.Forms.ContextMenuStrip contxtMenuNotIcon;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItemExit;
        private System.Diagnostics.EventLog evtlgAuthenticated;
        private System.ComponentModel.BackgroundWorker bgwShowSwitchUI;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItemShow;
        private System.ServiceProcess.ServiceController srvctrlVNCServer;
        private System.Windows.Forms.Timer tmrShowSwitchUI;
        private System.ServiceProcess.ServiceController srvctrlDisplaySwitch;
        private System.Windows.Forms.Timer tmrCheckPrimaryScreen;
    }
}