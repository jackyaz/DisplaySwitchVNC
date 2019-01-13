namespace DisplaySwitch_VNC
{
    partial class frmSwitchUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSwitchUI));
            this.evtlogDisconnected = new System.Diagnostics.EventLog();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cmbDisplaySelector = new System.Windows.Forms.ComboBox();
            this.lblDisplaySelectorSub = new System.Windows.Forms.Label();
            this.lblDisplaySelector = new System.Windows.Forms.Label();
            this.pnlMin = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.tmrCheckReg = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.evtlogDisconnected)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlMin.SuspendLayout();
            this.SuspendLayout();
            // 
            // evtlogDisconnected
            // 
            this.evtlogDisconnected.EnableRaisingEvents = true;
            this.evtlogDisconnected.Log = "Application";
            this.evtlogDisconnected.SynchronizingObject = this;
            this.evtlogDisconnected.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog1_EntryWritten);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cmbDisplaySelector);
            this.pnlMain.Controls.Add(this.lblDisplaySelectorSub);
            this.pnlMain.Controls.Add(this.lblDisplaySelector);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(50, 64);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(354, 64);
            this.pnlMain.TabIndex = 0;
            // 
            // cmbDisplaySelector
            // 
            this.cmbDisplaySelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDisplaySelector.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDisplaySelector.DisplayMember = "FriendlyName";
            this.cmbDisplaySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplaySelector.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.cmbDisplaySelector.FormattingEnabled = true;
            this.cmbDisplaySelector.Location = new System.Drawing.Point(240, 13);
            this.cmbDisplaySelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDisplaySelector.Name = "cmbDisplaySelector";
            this.cmbDisplaySelector.Size = new System.Drawing.Size(111, 24);
            this.cmbDisplaySelector.TabIndex = 4;
            this.cmbDisplaySelector.ValueMember = "DeviceName";
            // 
            // lblDisplaySelectorSub
            // 
            this.lblDisplaySelectorSub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisplaySelectorSub.AutoSize = true;
            this.lblDisplaySelectorSub.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDisplaySelectorSub.Location = new System.Drawing.Point(25, 32);
            this.lblDisplaySelectorSub.Name = "lblDisplaySelectorSub";
            this.lblDisplaySelectorSub.Size = new System.Drawing.Size(191, 14);
            this.lblDisplaySelectorSub.TabIndex = 1;
            this.lblDisplaySelectorSub.Text = "List is sorted left to right, top to bottom";
            this.lblDisplaySelectorSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplaySelector
            // 
            this.lblDisplaySelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisplaySelector.AutoSize = true;
            this.lblDisplaySelector.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDisplaySelector.Location = new System.Drawing.Point(3, 7);
            this.lblDisplaySelector.Name = "lblDisplaySelector";
            this.lblDisplaySelector.Size = new System.Drawing.Size(234, 16);
            this.lblDisplaySelector.TabIndex = 0;
            this.lblDisplaySelector.Text = "Choose display to show in VNC Viewer";
            this.lblDisplaySelector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMin
            // 
            this.pnlMin.Controls.Add(this.btnShow);
            this.pnlMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMin.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.pnlMin.Location = new System.Drawing.Point(0, 0);
            this.pnlMin.Name = "pnlMin";
            this.pnlMin.Size = new System.Drawing.Size(354, 56);
            this.pnlMin.TabIndex = 8;
            this.pnlMin.Visible = false;
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShow.Location = new System.Drawing.Point(0, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(354, 56);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tmrCheckReg
            // 
            this.tmrCheckReg.Enabled = true;
            this.tmrCheckReg.Tick += new System.EventHandler(this.tmrCheckReg_Tick);
            // 
            // frmSwitchUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(354, 56);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMin);
            this.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSwitchUI";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Display Switch";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSwitchUI_FormClosing);
            this.Shown += new System.EventHandler(this.frmSwitchUI_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.evtlogDisconnected)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlMin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog evtlogDisconnected;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblDisplaySelectorSub;
        private System.Windows.Forms.Label lblDisplaySelector;
        private System.Windows.Forms.Panel pnlMin;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Timer tmrCheckReg;
        private System.Windows.Forms.ComboBox cmbDisplaySelector;
    }
}

