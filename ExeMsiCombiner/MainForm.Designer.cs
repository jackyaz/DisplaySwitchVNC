namespace ExeMsiCombiner
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowseExe = new System.Windows.Forms.Button();
            this.textBoxExe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMsi = new System.Windows.Forms.TextBox();
            this.buttonBrowseMsi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBrowseOutputExe = new System.Windows.Forms.Button();
            this.textBoxOutputExe = new System.Windows.Forms.TextBox();
            this.buttonCombine = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.linkLoad = new System.Windows.Forms.LinkLabel();
            this.linkSave = new System.Windows.Forms.LinkLabel();
            this.linkResizeOptions = new System.Windows.Forms.LinkLabel();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.labelIco = new System.Windows.Forms.Label();
            this.textBoxIcon = new System.Windows.Forms.TextBox();
            this.buttonBrowseIcon = new System.Windows.Forms.Button();
            this.labelA3 = new System.Windows.Forms.Label();
            this.labelA4 = new System.Windows.Forms.Label();
            this.textBoxProductVersion = new System.Windows.Forms.TextBox();
            this.textBoxFileVersion = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelA5 = new System.Windows.Forms.Label();
            this.textBoxLegalCopyright = new System.Windows.Forms.TextBox();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.labelA6 = new System.Windows.Forms.Label();
            this.labelA7 = new System.Windows.Forms.Label();
            this.checkBoxFileVersionInfo = new System.Windows.Forms.CheckBox();
            this.labelA2 = new System.Windows.Forms.Label();
            this.labelA1 = new System.Windows.Forms.Label();
            this.linkCancelView = new System.Windows.Forms.LinkLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.textBoxCmdLineArgs = new System.Windows.Forms.TextBox();
            this.labelA9 = new System.Windows.Forms.Label();
            this.labelA8 = new System.Windows.Forms.Label();
            this.labelA10 = new System.Windows.Forms.Label();
            this.comboBoxCompression = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Exe File:";
            // 
            // buttonBrowseExe
            // 
            this.buttonBrowseExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseExe.Location = new System.Drawing.Point(613, 12);
            this.buttonBrowseExe.Name = "buttonBrowseExe";
            this.buttonBrowseExe.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseExe.TabIndex = 1;
            this.buttonBrowseExe.Text = "Browse...";
            this.buttonBrowseExe.UseVisualStyleBackColor = true;
            this.buttonBrowseExe.Click += new System.EventHandler(this.buttonBrowseExe_Click);
            // 
            // textBoxExe
            // 
            this.textBoxExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExe.Location = new System.Drawing.Point(100, 14);
            this.textBoxExe.Name = "textBoxExe";
            this.textBoxExe.Size = new System.Drawing.Size(500, 20);
            this.textBoxExe.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input Msi File:";
            // 
            // textBoxMsi
            // 
            this.textBoxMsi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMsi.Location = new System.Drawing.Point(100, 40);
            this.textBoxMsi.Name = "textBoxMsi";
            this.textBoxMsi.Size = new System.Drawing.Size(500, 20);
            this.textBoxMsi.TabIndex = 2;
            // 
            // buttonBrowseMsi
            // 
            this.buttonBrowseMsi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseMsi.Location = new System.Drawing.Point(613, 38);
            this.buttonBrowseMsi.Name = "buttonBrowseMsi";
            this.buttonBrowseMsi.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseMsi.TabIndex = 3;
            this.buttonBrowseMsi.Text = "Browse...";
            this.buttonBrowseMsi.UseVisualStyleBackColor = true;
            this.buttonBrowseMsi.Click += new System.EventHandler(this.buttonBrowseMsi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Output Exe File:";
            // 
            // buttonBrowseOutputExe
            // 
            this.buttonBrowseOutputExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseOutputExe.Location = new System.Drawing.Point(613, 90);
            this.buttonBrowseOutputExe.Name = "buttonBrowseOutputExe";
            this.buttonBrowseOutputExe.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOutputExe.TabIndex = 7;
            this.buttonBrowseOutputExe.Text = "Browse...";
            this.buttonBrowseOutputExe.UseVisualStyleBackColor = true;
            this.buttonBrowseOutputExe.Click += new System.EventHandler(this.buttonBrowseOutputExe_Click);
            // 
            // textBoxOutputExe
            // 
            this.textBoxOutputExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputExe.Location = new System.Drawing.Point(100, 92);
            this.textBoxOutputExe.Name = "textBoxOutputExe";
            this.textBoxOutputExe.Size = new System.Drawing.Size(500, 20);
            this.textBoxOutputExe.TabIndex = 6;
            // 
            // buttonCombine
            // 
            this.buttonCombine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCombine.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCombine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonCombine.Location = new System.Drawing.Point(613, 418);
            this.buttonCombine.Name = "buttonCombine";
            this.buttonCombine.Size = new System.Drawing.Size(75, 23);
            this.buttonCombine.TabIndex = 17;
            this.buttonCombine.Text = "Combine!";
            this.buttonCombine.UseVisualStyleBackColor = false;
            this.buttonCombine.Click += new System.EventHandler(this.buttonCombine_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(11, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(679, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "_________________________________________________________________________________" +
                "_______________________________";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(525, 418);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // linkLoad
            // 
            this.linkLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLoad.AutoSize = true;
            this.linkLoad.Location = new System.Drawing.Point(542, 375);
            this.linkLoad.Name = "linkLoad";
            this.linkLoad.Size = new System.Drawing.Size(70, 13);
            this.linkLoad.TabIndex = 20;
            this.linkLoad.TabStop = true;
            this.linkLoad.Text = "Load Options";
            this.linkLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLoad_LinkClicked);
            // 
            // linkSave
            // 
            this.linkSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkSave.AutoSize = true;
            this.linkSave.Location = new System.Drawing.Point(618, 375);
            this.linkSave.Name = "linkSave";
            this.linkSave.Size = new System.Drawing.Size(71, 13);
            this.linkSave.TabIndex = 21;
            this.linkSave.TabStop = true;
            this.linkSave.Text = "Save Options";
            this.linkSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSave_LinkClicked);
            // 
            // linkResizeOptions
            // 
            this.linkResizeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkResizeOptions.AutoSize = true;
            this.linkResizeOptions.Location = new System.Drawing.Point(12, 375);
            this.linkResizeOptions.Name = "linkResizeOptions";
            this.linkResizeOptions.Size = new System.Drawing.Size(120, 13);
            this.linkResizeOptions.TabIndex = 18;
            this.linkResizeOptions.TabStop = true;
            this.linkResizeOptions.Text = "Hide Advanced Options";
            this.linkResizeOptions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResizeOptions_LinkClicked);
            // 
            // linkHelp
            // 
            this.linkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHelp.AutoSize = true;
            this.linkHelp.Location = new System.Drawing.Point(477, 375);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(59, 13);
            this.linkHelp.TabIndex = 19;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "Help && Info";
            this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
            // 
            // labelIco
            // 
            this.labelIco.AutoSize = true;
            this.labelIco.Location = new System.Drawing.Point(22, 69);
            this.labelIco.Name = "labelIco";
            this.labelIco.Size = new System.Drawing.Size(71, 13);
            this.labelIco.TabIndex = 0;
            this.labelIco.Text = "Input Ico File:";
            // 
            // textBoxIcon
            // 
            this.textBoxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIcon.Location = new System.Drawing.Point(100, 66);
            this.textBoxIcon.Name = "textBoxIcon";
            this.textBoxIcon.Size = new System.Drawing.Size(500, 20);
            this.textBoxIcon.TabIndex = 4;
            // 
            // buttonBrowseIcon
            // 
            this.buttonBrowseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseIcon.Location = new System.Drawing.Point(613, 64);
            this.buttonBrowseIcon.Name = "buttonBrowseIcon";
            this.buttonBrowseIcon.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseIcon.TabIndex = 5;
            this.buttonBrowseIcon.Text = "Browse...";
            this.buttonBrowseIcon.UseVisualStyleBackColor = true;
            this.buttonBrowseIcon.Click += new System.EventHandler(this.buttonBrowseIcon_Click);
            // 
            // labelA3
            // 
            this.labelA3.AutoSize = true;
            this.labelA3.Location = new System.Drawing.Point(5, 166);
            this.labelA3.Name = "labelA3";
            this.labelA3.Size = new System.Drawing.Size(85, 13);
            this.labelA3.TabIndex = 19;
            this.labelA3.Text = "Product Version:";
            // 
            // labelA4
            // 
            this.labelA4.AutoSize = true;
            this.labelA4.Location = new System.Drawing.Point(26, 192);
            this.labelA4.Name = "labelA4";
            this.labelA4.Size = new System.Drawing.Size(64, 13);
            this.labelA4.TabIndex = 13;
            this.labelA4.Text = "File Version:";
            // 
            // textBoxProductVersion
            // 
            this.textBoxProductVersion.Enabled = false;
            this.textBoxProductVersion.Location = new System.Drawing.Point(99, 163);
            this.textBoxProductVersion.Name = "textBoxProductVersion";
            this.textBoxProductVersion.Size = new System.Drawing.Size(124, 20);
            this.textBoxProductVersion.TabIndex = 9;
            // 
            // textBoxFileVersion
            // 
            this.textBoxFileVersion.Enabled = false;
            this.textBoxFileVersion.Location = new System.Drawing.Point(99, 189);
            this.textBoxFileVersion.Name = "textBoxFileVersion";
            this.textBoxFileVersion.Size = new System.Drawing.Size(124, 20);
            this.textBoxFileVersion.TabIndex = 10;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProductName.Enabled = false;
            this.textBoxProductName.Location = new System.Drawing.Point(99, 215);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(588, 20);
            this.textBoxProductName.TabIndex = 11;
            // 
            // labelA5
            // 
            this.labelA5.AutoSize = true;
            this.labelA5.Location = new System.Drawing.Point(12, 218);
            this.labelA5.Name = "labelA5";
            this.labelA5.Size = new System.Drawing.Size(78, 13);
            this.labelA5.TabIndex = 11;
            this.labelA5.Text = "Product Name:";
            // 
            // textBoxLegalCopyright
            // 
            this.textBoxLegalCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLegalCopyright.Enabled = false;
            this.textBoxLegalCopyright.Location = new System.Drawing.Point(99, 267);
            this.textBoxLegalCopyright.Name = "textBoxLegalCopyright";
            this.textBoxLegalCopyright.Size = new System.Drawing.Size(588, 20);
            this.textBoxLegalCopyright.TabIndex = 13;
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCompanyName.Enabled = false;
            this.textBoxCompanyName.Location = new System.Drawing.Point(99, 241);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(588, 20);
            this.textBoxCompanyName.TabIndex = 12;
            // 
            // labelA6
            // 
            this.labelA6.AutoSize = true;
            this.labelA6.Location = new System.Drawing.Point(5, 244);
            this.labelA6.Name = "labelA6";
            this.labelA6.Size = new System.Drawing.Size(85, 13);
            this.labelA6.TabIndex = 12;
            this.labelA6.Text = "Company Name:";
            // 
            // labelA7
            // 
            this.labelA7.AutoSize = true;
            this.labelA7.Location = new System.Drawing.Point(7, 270);
            this.labelA7.Name = "labelA7";
            this.labelA7.Size = new System.Drawing.Size(83, 13);
            this.labelA7.TabIndex = 10;
            this.labelA7.Text = "Legal Copyright:";
            // 
            // checkBoxFileVersionInfo
            // 
            this.checkBoxFileVersionInfo.AutoSize = true;
            this.checkBoxFileVersionInfo.Location = new System.Drawing.Point(12, 141);
            this.checkBoxFileVersionInfo.Name = "checkBoxFileVersionInfo";
            this.checkBoxFileVersionInfo.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFileVersionInfo.TabIndex = 8;
            this.checkBoxFileVersionInfo.UseVisualStyleBackColor = true;
            this.checkBoxFileVersionInfo.CheckedChanged += new System.EventHandler(this.checkBoxFileVersionInfo_CheckedChanged);
            // 
            // labelA2
            // 
            this.labelA2.AutoSize = true;
            this.labelA2.Location = new System.Drawing.Point(30, 141);
            this.labelA2.Name = "labelA2";
            this.labelA2.Size = new System.Drawing.Size(107, 13);
            this.labelA2.TabIndex = 0;
            this.labelA2.Text = "Use File Version Info:";
            // 
            // labelA1
            // 
            this.labelA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelA1.AutoSize = true;
            this.labelA1.Enabled = false;
            this.labelA1.Location = new System.Drawing.Point(11, 116);
            this.labelA1.Name = "labelA1";
            this.labelA1.Size = new System.Drawing.Size(679, 13);
            this.labelA1.TabIndex = 3;
            this.labelA1.Text = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" +
                " _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _";
            // 
            // linkCancelView
            // 
            this.linkCancelView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkCancelView.AutoSize = true;
            this.linkCancelView.Location = new System.Drawing.Point(471, 422);
            this.linkCancelView.Name = "linkCancelView";
            this.linkCancelView.Size = new System.Drawing.Size(40, 13);
            this.linkCancelView.TabIndex = 22;
            this.linkCancelView.TabStop = true;
            this.linkCancelView.Text = "Cancel";
            this.linkCancelView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCancelView.Visible = false;
            this.linkCancelView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCancelView_LinkClicked);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(100, 425);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(352, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 21;
            this.progressBar.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(39, 423);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(51, 13);
            this.labelProgress.TabIndex = 10;
            this.labelProgress.Text = "Progress:";
            this.labelProgress.Visible = false;
            // 
            // textBoxCmdLineArgs
            // 
            this.textBoxCmdLineArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCmdLineArgs.Location = new System.Drawing.Point(99, 316);
            this.textBoxCmdLineArgs.Name = "textBoxCmdLineArgs";
            this.textBoxCmdLineArgs.Size = new System.Drawing.Size(588, 20);
            this.textBoxCmdLineArgs.TabIndex = 14;
            // 
            // labelA9
            // 
            this.labelA9.AutoSize = true;
            this.labelA9.Location = new System.Drawing.Point(12, 319);
            this.labelA9.Name = "labelA9";
            this.labelA9.Size = new System.Drawing.Size(78, 13);
            this.labelA9.TabIndex = 10;
            this.labelA9.Text = "Cmd Line Args:";
            // 
            // labelA8
            // 
            this.labelA8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelA8.AutoSize = true;
            this.labelA8.Enabled = false;
            this.labelA8.Location = new System.Drawing.Point(10, 289);
            this.labelA8.Name = "labelA8";
            this.labelA8.Size = new System.Drawing.Size(679, 13);
            this.labelA8.TabIndex = 3;
            this.labelA8.Text = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" +
                " _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _";
            // 
            // labelA10
            // 
            this.labelA10.AutoSize = true;
            this.labelA10.Location = new System.Drawing.Point(22, 345);
            this.labelA10.Name = "labelA10";
            this.labelA10.Size = new System.Drawing.Size(70, 13);
            this.labelA10.TabIndex = 10;
            this.labelA10.Text = "Compression:";
            // 
            // comboBoxCompression
            // 
            this.comboBoxCompression.FormattingEnabled = true;
            this.comboBoxCompression.Items.AddRange(new object[] {
            "Optimised for speed [recommended]",
            "Optimised for size [using iexpress]"});
            this.comboBoxCompression.Location = new System.Drawing.Point(99, 342);
            this.comboBoxCompression.Name = "comboBoxCompression";
            this.comboBoxCompression.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCompression.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 452);
            this.Controls.Add(this.comboBoxCompression);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkBoxFileVersionInfo);
            this.Controls.Add(this.labelA3);
            this.Controls.Add(this.labelA4);
            this.Controls.Add(this.textBoxProductVersion);
            this.Controls.Add(this.textBoxFileVersion);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.labelA5);
            this.Controls.Add(this.textBoxCmdLineArgs);
            this.Controls.Add(this.textBoxLegalCopyright);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.labelA6);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelA10);
            this.Controls.Add(this.labelA9);
            this.Controls.Add(this.labelA7);
            this.Controls.Add(this.linkSave);
            this.Controls.Add(this.linkResizeOptions);
            this.Controls.Add(this.linkCancelView);
            this.Controls.Add(this.linkHelp);
            this.Controls.Add(this.linkLoad);
            this.Controls.Add(this.labelA8);
            this.Controls.Add(this.labelA1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxOutputExe);
            this.Controls.Add(this.textBoxMsi);
            this.Controls.Add(this.textBoxIcon);
            this.Controls.Add(this.textBoxExe);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCombine);
            this.Controls.Add(this.buttonBrowseOutputExe);
            this.Controls.Add(this.buttonBrowseMsi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBrowseIcon);
            this.Controls.Add(this.buttonBrowseExe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelA2);
            this.Controls.Add(this.labelIco);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExeMsiCombiner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowseExe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBrowseMsi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBrowseOutputExe;
        private System.Windows.Forms.Button buttonCombine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.LinkLabel linkLoad;
        private System.Windows.Forms.LinkLabel linkSave;
        private System.Windows.Forms.LinkLabel linkResizeOptions;
        private System.Windows.Forms.LinkLabel linkHelp;
        private System.Windows.Forms.Label labelIco;
        private System.Windows.Forms.Button buttonBrowseIcon;
        private System.Windows.Forms.Label labelA3;
        private System.Windows.Forms.Label labelA4;
        private System.Windows.Forms.Label labelA5;
        private System.Windows.Forms.Label labelA6;
        private System.Windows.Forms.Label labelA7;
        private System.Windows.Forms.Label labelA2;
        private System.Windows.Forms.Label labelA1;
        private System.Windows.Forms.LinkLabel linkCancelView;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelA9;
        private System.Windows.Forms.Label labelA8;
        private System.Windows.Forms.Label labelA10;
        public System.Windows.Forms.TextBox textBoxExe;
        public System.Windows.Forms.TextBox textBoxMsi;
        public System.Windows.Forms.TextBox textBoxOutputExe;
        public System.Windows.Forms.TextBox textBoxIcon;
        public System.Windows.Forms.TextBox textBoxProductVersion;
        public System.Windows.Forms.TextBox textBoxFileVersion;
        public System.Windows.Forms.TextBox textBoxProductName;
        public System.Windows.Forms.TextBox textBoxLegalCopyright;
        public System.Windows.Forms.TextBox textBoxCompanyName;
        public System.Windows.Forms.CheckBox checkBoxFileVersionInfo;
        public System.Windows.Forms.TextBox textBoxCmdLineArgs;
        public System.Windows.Forms.ComboBox comboBoxCompression;
    }
}

