using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using Vestris.ResourceLib;
using System.Runtime.InteropServices;
using Microsoft.Win32;



namespace ExeMsiCombiner
{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        public static string version = "1.0.0.1";   // internal version

        // variables used for streaming files and showing progress
        const int bufferSize = 32 * 1024;
        byte[] buffer = new byte[bufferSize];
        long totalSize;
        long amountWritten = 0;             

        bool showAdvancedOptions = true;    // true to show advanced options on the form
        string viewFile = "";               // the last installer file that was built
        string optionsFile = "";            // the last options file that was loaded/saved

        HelpForm helpForm = null;

        // -----------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            // Copy default options to the form
            Options options = new Options();
            options.CopyToForm(this);

            // Check registry for last saved options
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Team E-P\\ExeMsiCombiner");

                bool showAdvanced = (int)rk.GetValue("ShowAdvancedOptions") == 1;
                if (!showAdvanced) { linkResizeOptions_LinkClicked(null, null); }

                optionsFile = (string)rk.GetValue("LastUsedOptionsFile");

                string lastUsedOptionsString = (string)rk.GetValue("LastUsedOptions");
                Options lastUsedOptions = new Options();
                if (lastUsedOptions.LoadFromString(lastUsedOptionsString))
                {
                    lastUsedOptions.CopyToForm(this);
                }                
            }
            catch
            {
                // start in simple mode the first time the program is run
                linkResizeOptions_LinkClicked(null, null);
            }

            // Deselect the text boxes
            buttonCombine.Select();
        }

        
        // -----------------------------------------------------
        public bool RunInCommandLineMode(string [] args)
        {
            // Enable console output
            AttachConsole(-1);

            // join all options into one string
            string uberArgString = "";
            foreach (string s in args)
            {
                uberArgString += s;
            }

            // Make some options to populate from command line arguments
            Options options = new Options();
            bool optionsOk = true;

            // Display help
            if (uberArgString == "/?")
            {
                helpForm = new HelpForm();
                string helpfile = Application.StartupPath + "\\Content\\readme.mht";
                helpForm.webBrowser.Url = new Uri(helpfile);
                helpForm.Location = new Point(
                    this.Location.X + (this.Size.Width >> 1) - (helpForm.Size.Width >> 1),
                    this.Location.Y + (this.Size.Height >> 1) - (helpForm.Size.Height >> 1)
                );
                helpForm.ShowDialog();
                
                return false;
            }

            // Load from file
            else if (File.Exists(uberArgString))
            {
                optionsOk = options.Load(uberArgString);
            }

            // Load from options string
            else
            {
                optionsOk = options.LoadFromString(uberArgString);
            }

            // Print error if the options aren't right
            if (!optionsOk)
            {
                Console.WriteLine("ExeMsiCombiner Error - Failed to load options:\n\n" + uberArgString + "\n\nUse the '/?' option to get further help.");
                InfoBox.Show(null, "ExeMsiCombiner Error", "Failed to load options:\n\n" + uberArgString + "\n\nUse the '/?' option to get further help.");
                return false;
            }

            string errorMsg;
            if (!ValidateOptions(options, out errorMsg))
            {
                Console.WriteLine("ExeMsiCombiner Error\n\n" + errorMsg + "\n\nUse the '/?' option to get further help.");
                InfoBox.Show(null, "ExeMsiCombiner Error", errorMsg + "\n\nUse the '/?' option to get further help.");
                return false;
            }

            if (!CombineFiles(options, out errorMsg))
            {
                Console.WriteLine("ExeMsiCombiner Error Combining Files:\n\n" + errorMsg);
                return false;
            }

            return true;    // success
        }


        // -----------------------------------------------------
        String OpenFileDialog(string filter, string oldFileName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ofd.Filter = filter;
            ofd.FileName = oldFileName;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }

            return null;

        }


        // -----------------------------------------------------
        String SaveFileDialog(string filter, bool overwritePrompt, string oldFileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = oldFileName;
            sfd.OverwritePrompt = overwritePrompt;
            sfd.Filter = sfd.Filter = filter;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }

            return null;
        }


        // -----------------------------------------------------
        private void buttonBrowseExe_Click(object sender, EventArgs e)
        {
            string filename = OpenFileDialog("exe files|*.exe", textBoxExe.Text);
            if (filename != null)
            {
                textBoxExe.Text = filename;
            }
        }


        // -----------------------------------------------------
        private void buttonBrowseMsi_Click(object sender, EventArgs e)
        {
            string filename = OpenFileDialog("msi files|*.msi", textBoxMsi.Text);
            if (filename != null)
            {
                textBoxMsi.Text = filename;
            }
        }


        // -----------------------------------------------------
        private void buttonBrowseOutputExe_Click(object sender, EventArgs e)
        {
            string filename = SaveFileDialog("exe files|*.exe", false, textBoxOutputExe.Text);
            if (filename != null)
            {
                textBoxOutputExe.Text = filename;
            }
        }


        // -----------------------------------------------------
        private void buttonBrowseIcon_Click(object sender, EventArgs e)
        {
            string filename = OpenFileDialog("ico files|*.ico", textBoxIcon.Text);
            if (filename != null)
            {
                textBoxIcon.Text = filename;
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            // Check registry to see if we should start in full screen mode
            try
            {
                RegistryKey rk = Registry.LocalMachine.CreateSubKey("Software\\Team E-P\\ExeMsiCombiner");
                rk.SetValue("ShowAdvancedOptions", showAdvancedOptions ? 1 : 0);
                Options options = new Options(this);
                rk.SetValue("LastUsedOptions", options.SaveToRegString());
                rk.SetValue("LastUsedOptionsFile", optionsFile);
            }
            catch
            {
            }

            base.OnClosed(e);
        }


        // -----------------------------------------------------
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // -----------------------------------------------------
        private void PreCombine()
        {
            labelProgress.Visible = true;
            progressBar.Visible = true;
            linkCancelView.LinkColor = Color.Black;
            linkCancelView.Visible = true;
            labelProgress.Text = "Progress:";
            progressBar.Value = 0;
            linkCancelView.Text = "";
            linkCancelView.LinkBehavior = LinkBehavior.NeverUnderline;
            Update();
        }


        // -----------------------------------------------------
        private void PostCombine()
        {
            linkCancelView.LinkBehavior = LinkBehavior.AlwaysUnderline;
            labelProgress.Text = "Finished!";
            progressBar.Value = 100;
            viewFile = textBoxOutputExe.Text;
            linkCancelView.Text = "View";
            linkCancelView.LinkColor = Color.Blue;
        }


        // -----------------------------------------------------
        private void PostCombine2()
        {
            labelProgress.Text = "";
            progressBar.Value = 0;
            progressBar.Visible = false;
            linkCancelView.Text = "";
        }


        // -----------------------------------------------------
        bool ValidateOptions(Options options, out string errorMsg)
        {
            if (options.inputExeFile != "" && !File.Exists(options.inputExeFile))
            {
                errorMsg = "You need to select the installer exe file that goes with the msi.\n\n(Or you can leave this field blank to just use the msi [not recommended]).";
                return false;
            }

            if (!File.Exists(options.inputMsiFile))
            {
                errorMsg = "You need to select a valid msi file.";
                return false;
            }

            if (options.outputExeFile == "")
            {
                errorMsg = "You need to select a valid output file.";
                return false;
            }

            if (options.inputIcoFile != "" && !File.Exists(options.inputIcoFile))
            {
                errorMsg = "You need to choose a valid icon file (or leave it blank to use the default icon).";
                return false;
            }

            // validate the product vesion format is correct 
            if (options.useVersionInfo)
            {
                if (!Regex.IsMatch(options.versionInfo.productVersion, @"\d+\.\d+\.\d+\.\d+$"))
                {
                    errorMsg = "You need to choose a valid product version number.\n\nThe format should be #.#.#.# (where # is a number).";
                    return false;
                }
            }

            // validate the file vesion format is correct 
            if (checkBoxFileVersionInfo.Checked)
            {
                if (!Regex.IsMatch(options.versionInfo.fileVersion, @"\d+\.\d+\.\d+\.\d+$"))
                {
                    errorMsg = "You need to choose a valid file version number.\n\nThe format should be #.#.#.# (where # is a number).";
                    return false;
                }
            }

            errorMsg = "";
            return true;
        }


        // -----------------------------------------------------
        public bool ConfirmUnusualOptions(Options options)
        {
            if (options.inputExeFile == "")
            {
                DialogResult result = InfoBox.Show(this, "Confirm 'msi-only' mode", "Are you sure you want to use the msi file without using the corresponding exe file?\n[not recommended]", InfoBox.Buttons.YesNo);
                if (result != DialogResult.Yes)
                {
                    textBoxExe.Select();
                    return false;
                }
            }

            if (File.Exists(options.outputExeFile))
            {
                DialogResult result = InfoBox.Show(this, "Confirm overwrite", "Are you sure you want to overwrite the existing output file (" + Path.GetFileName(options.outputExeFile) + ")?", InfoBox.Buttons.YesNo);
                if (result != DialogResult.Yes)
                {
                    textBoxOutputExe.Select();
                    return false;
                }
            }

            return true;
        }


        // -----------------------------------------------------
        private void buttonCombine_Click(object sender, EventArgs e)
        {
            // Copy the options
            Options options = new Options(this);
            string errorMsg;

            if (!ValidateOptions(options, out errorMsg))
            {
                InfoBox.Show(this, "Error", errorMsg);
                return;
            }

            if (!ConfirmUnusualOptions(options))
            {
                return;
            }
            
            PreCombine();
            bool result = CombineFiles(options, out errorMsg);

            if (result)
            {
                PostCombine();
            }
            else
            {
                PostCombine2();
                InfoBox.Show(null, "Error Combining Files", errorMsg);
            }
        }


        // -----------------------------------------------------
        // Helpful function to convert a string into ASCII bytes
        // -----------------------------------------------------
        public static byte[] GetBytes(string text)
        {
            return ASCIIEncoding.ASCII.GetBytes(text);
        }


        // -----------------------------------------------------
        void WriteStringLP(BinaryWriter bw, string s)
        {
            // write length of string
            bw.Write((uint)s.Length);
            // write string (not 0 terminated)
            bw.Write(GetBytes(s));
        }


        // -----------------------------------------------------
        void AppendFile(BinaryWriter bw, string file)
        {
            FileInfo fi = new FileInfo(file);

            FileStream extra = File.OpenRead(file);

            // write length of file
            bw.Write((uint)fi.Length);
            
            // Write the name of the file
            WriteStringLP(bw, fi.Name);

            // write the contents of the file one block at a time
            int blockSize;
            while ((blockSize = extra.Read(buffer, 0, buffer.Length)) > 0)
            {
                this.amountWritten += blockSize;

                int progress = (int)(amountWritten / (float)totalSize * 100);
                progressBar.Value = progress;
                linkCancelView.Text = progress + "%";
                linkCancelView.Update();

                bw.Write(buffer, 0, blockSize);
            }

            extra.Close();
        }


        // -----------------------------------------------------
        string BuildCommandLine(Options options, string prefix)
        {
            // Build command line args to launch the msi
            if (options.MsiOnly())
            {
                string commandLineArgs = "msiexec.exe /i ";
                commandLineArgs += Path.GetFileName(options.inputMsiFile);
                if (options.commandLineArgs != "")
                    commandLineArgs += options.commandLineArgs + " ";
                return commandLineArgs;
            }

            // Build command line args to launch the exe
            else
            {
                string commandLineArgs = prefix;
                commandLineArgs += Path.GetFileName(options.inputExeFile);
                if (options.commandLineArgs != "")
                    commandLineArgs += " " + options.commandLineArgs;
                return commandLineArgs;
            }
        }


        // -----------------------------------------------------
        void CombineFilesUsingIExpress(Options options)
        {            
            string tempPath = Path.GetTempFileName();
            File.Delete(tempPath);
            tempPath += "\\";
            Directory.CreateDirectory(tempPath);

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            string iexpressTemplate;

            if (!options.MsiOnly())
            {
                iexpressTemplate = enc.GetString(Properties.Resources.IExpressTemplate);
                iexpressTemplate = iexpressTemplate.Replace("COMMAND_LINE", BuildCommandLine(options, ""));
                iexpressTemplate = iexpressTemplate.Replace("EXE_NAME_HERE", Path.GetFileName(options.inputExeFile));
                iexpressTemplate = iexpressTemplate.Replace("MSI_NAME_HERE", Path.GetFileName(options.inputMsiFile));
                iexpressTemplate = iexpressTemplate.Replace("OUT_FILE_AND_PATH_HERE", options.outputExeFile);
                iexpressTemplate = iexpressTemplate.Replace("TEMP_PATH_HERE", tempPath);
            }
            else
            {
                iexpressTemplate = enc.GetString(Properties.Resources.IExpressTemplateMsiOnly);
                iexpressTemplate = iexpressTemplate.Replace("COMMAND_LINE", BuildCommandLine(options, ""));
                iexpressTemplate = iexpressTemplate.Replace("MSI_NAME_HERE", Path.GetFileName(options.inputMsiFile));
                iexpressTemplate = iexpressTemplate.Replace("OUT_FILE_AND_PATH_HERE", options.outputExeFile);
                iexpressTemplate = iexpressTemplate.Replace("TEMP_PATH_HERE", tempPath);
            }

            // Write SED file to temp dir
            StreamWriter sw = new StreamWriter(tempPath + "IExpressTemplate.SED");
            sw.Write(iexpressTemplate);
            sw.Close();

            if (!options.MsiOnly())
            {
                // Write ExeMsiLauncher.exe to temp dir
                FileStream fs1 = File.Open(tempPath + "ExeMsiLauncher.exe", FileMode.Create);
                BinaryWriter bw1 = new BinaryWriter(fs1);
                bw1.Write(Properties.Resources.ExeMsiLauncher);
                bw1.Close();
                fs1.Close();

                // Write EXE file to temp dir
                File.Copy(options.inputExeFile, tempPath + Path.GetFileName(options.inputExeFile));
            }

            // Write MSI file to temp dir
            File.Copy(options.inputMsiFile, tempPath + Path.GetFileName(options.inputMsiFile));

            // Use IEXPRESS to build installer package
            ProcessStartInfo psi = new ProcessStartInfo("IEXPRESS", "/N /Q IExpressTemplate.SED");
            psi.WorkingDirectory = tempPath;
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();

            progressBar.Style = ProgressBarStyle.Marquee;
            while (!p.HasExited)
            {
                Thread.Sleep(80);
                progressBar.Refresh();
            }
            progressBar.Style = ProgressBarStyle.Continuous;

            // delete temp directory
            Directory.Delete(tempPath, true);

            // replace the icon
            if (options.inputIcoFile != "")
            {
                ReplaceIcon(options);
            }

            // replace the icon
            if (options.useVersionInfo)
            {
                ReplaceVersionInfo(options);
            }
        }

 
        // -----------------------------------------------------
        bool CombineFiles(Options options, out string errorMsg)
        {
            try
            {
                if (options.compress)
                {
                    CombineFilesUsingIExpress(options);
                    errorMsg = "";
                    return true;
                }

                // Work out the total file size (used for updating progress bar)
                amountWritten = 0;
                totalSize = 0;
                if (options.inputExeFile != "")
                {
                    totalSize += new FileInfo(options.inputExeFile).Length;
                }
                totalSize += new FileInfo(options.inputMsiFile).Length;

                // Write out the extractor
                FileStream fs = File.Open(options.outputExeFile, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                // Add the extractor program (via writing it to diskfirst
                // bw.Write(Properties.Resources.ExeMsiExtractor);
                bw.Write(Properties.Resources.ExeMsiExtractor);
                bw.Close();
                fs.Close();

                // Replace the icon if desired
                if (options.inputIcoFile != "")
                {
                    ReplaceIcon(options);
                }

                // Modify the file version info if desire
                if (options.useVersionInfo)
                {
                    ReplaceVersionInfo(options);
                }

                // open extractor file to append other information
                fs = File.Open(options.outputExeFile, FileMode.Append);
                long extractorFileLength = fs.Position;
                bw = new BinaryWriter(fs);

                // Add the command line arguments
                string commandLine = BuildCommandLine(options, "ExeMsiLauncher.exe ");
                WriteStringLP(bw, commandLine);

                // Write the launcher program
                bw.Write((uint)Properties.Resources.ExeMsiLauncher.Length);
                WriteStringLP(bw, "ExeMsiLauncher.exe");
                bw.Write(Properties.Resources.ExeMsiLauncher);

                // Add the exe file (if any)
                if (!options.MsiOnly())
                {
                    AppendFile(bw, options.inputExeFile);
                }

                // Add the msi file (required)
                AppendFile(bw, options.inputMsiFile);

                // Write extra information
                bw.Write((uint)1234567890);                         // Magic number to verify file for ExeMsiLauncher package
//              bw.Write((uint)(textBoxExe.Text == "" ? 2 : 3));    // Number of files in this package
                bw.Write((uint)(options.inputExeFile == "" ? 2 : 3));    // Number of files in this package
                bw.Write((uint)extractorFileLength);                // Number to indicate the length of the ExeMsiLauncher

                // close the files
                bw.Close();
                fs.Close();
            }
            
            catch (Exception e)
            {
                errorMsg = e.Message;
                return false;
            }

            errorMsg = "";
            return true;
        }



        // -----------------------------------------------------
        void ReplaceIcon(Options options)
        {
            // Find version info resources
            ResourceInfo ri = new ResourceInfo();
            ri.Load(options.outputExeFile);
            List<Resource> iconResources = ri.Resources[new ResourceId(Kernel32.ResourceTypes.RT_ICON)];
            List<Resource> iconGroupResources = ri.Resources[new ResourceId(Kernel32.ResourceTypes.RT_GROUP_ICON)];
            ri.Dispose();

            // Delete old icons from file
            foreach (Resource resource in iconResources)
            {
                resource.DeleteFrom(options.outputExeFile);
            }

            // Delete old icon groups from file
            foreach (Resource resource in iconGroupResources)
            {
                resource.DeleteFrom(options.outputExeFile);
            }

            // Add the new icon and iconGroup
            IconFile iconFile = new IconFile(options.inputIcoFile);
            IconDirectoryResource iconDirectoryResource = new IconDirectoryResource(iconFile);
            iconDirectoryResource.SaveTo(options.outputExeFile);
        }


        // -----------------------------------------------------
        void ReplaceVersionInfo(Options options)
        {
            // Find version info resources
            ResourceInfo ri = new ResourceInfo();
            ri.Load(options.outputExeFile);
            List<Resource> resources = ri.Resources[new ResourceId(Kernel32.ResourceTypes.RT_VERSION)];
            ri.Dispose();

            // Delete old version resource(s) from file
            foreach (Resource resource in resources)
            {
                resource.DeleteFrom(options.outputExeFile);
            }

            // Create new version info resource
            VersionResource versionResource = new VersionResource();
            versionResource.FileVersion = options.versionInfo.fileVersion;
            versionResource.ProductVersion = options.versionInfo.productVersion;

            // Set all the info / strings
            StringFileInfo stringFileInfo = new StringFileInfo();
            versionResource[stringFileInfo.Key] = stringFileInfo;
            StringTable stringFileInfoStrings = new StringTable();
            stringFileInfoStrings.LanguageID = ResourceUtil.USENGLISHLANGID;
            stringFileInfoStrings.CodePage = 1200;
            stringFileInfo.Strings.Add(stringFileInfoStrings.Key, stringFileInfoStrings);
//          stringFileInfoStrings["ProductName"] = "not used";
            stringFileInfoStrings["FileVersion"] = options.versionInfo.fileVersion;
            stringFileInfoStrings["FileDescription"] = options.versionInfo.productName;
            stringFileInfoStrings["LegalCopyright"] = options.versionInfo.legalCopyright;
            stringFileInfoStrings["CompanyName"] = options.versionInfo.companyName;
//          stringFileInfoStrings["Comments"] = "not used";
            stringFileInfoStrings["ProductVersion"] = options.versionInfo.productVersion;
            
            // Don't really understand what this chunk does, but leaving it in anyway
            VarFileInfo varFileInfo = new VarFileInfo();
            versionResource[varFileInfo.Key] = varFileInfo;
            VarTable varFileInfoTranslation = new VarTable("Translation");
            varFileInfo.Vars.Add(varFileInfoTranslation.Key, varFileInfoTranslation);
            varFileInfoTranslation[ResourceUtil.USENGLISHLANGID] = 1300;

            // Save to file
            versionResource.SaveTo(options.outputExeFile);
        }


        // -----------------------------------------------------
        private void checkBoxFileVersionInfo_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = checkBoxFileVersionInfo.Checked;
            textBoxProductVersion.Enabled = enable;
            textBoxFileVersion.Enabled = enable;
            textBoxProductName.Enabled = enable;
            textBoxCompanyName.Enabled = enable;
            textBoxLegalCopyright.Enabled = enable;
        }


        // -----------------------------------------------------
        private void linkResizeOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showAdvancedOptions = !showAdvancedOptions;
            
            checkBoxFileVersionInfo.Visible = showAdvancedOptions;
            textBoxProductVersion.Visible = showAdvancedOptions;
            textBoxFileVersion.Visible = showAdvancedOptions;
            textBoxProductName.Visible = showAdvancedOptions;
            textBoxCompanyName.Visible = showAdvancedOptions;
            textBoxLegalCopyright.Visible = showAdvancedOptions;
            textBoxCmdLineArgs.Visible = showAdvancedOptions;
            comboBoxCompression.Visible = showAdvancedOptions;

            for (int i = 1; i <= 10; i++)
            {
                Controls["labelA"+i].Visible = showAdvancedOptions;
            }

            if (showAdvancedOptions)
            {
                linkResizeOptions.Text = "Hide Advanced Options";
                Size = new Size(Size.Width, 477);
            }

            else
            {
                linkResizeOptions.Text = "Show Advanced Options";
                Size = new Size(Size.Width, 225);
            }
            
        }


        // -----------------------------------------------------
        private void linkCancelView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the containing folder
            Process.Start("Explorer", "/select," + viewFile);
        }


        // -----------------------------------------------------
        private void linkSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = SaveFileDialog("txt files|*.txt", true, optionsFile);
            if (filename == null) return;

            Options options = new Options(this);
            if (!options.Save(filename))
            {
                optionsFile = filename;
                InfoBox.Show(this, "Error", "Failed to save options file");
            }
        }


        // -----------------------------------------------------
        private void linkLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = OpenFileDialog("txt files|*.txt", optionsFile);
            if (filename == null) return;

            Options options = new Options();
            
            if (!options.Load(filename))
            {
                InfoBox.Show(this, "Error", "Failed to load options file");
            }
            else
            {
                optionsFile = filename;
                options.CopyToForm(this);
            }
        }


        // -----------------------------------------------------
        private void ShowHelp()
        {
            try
            {
                if (helpForm == null || helpForm.IsDisposed)
                {
                    helpForm = new HelpForm();
                    string helpfile = Application.StartupPath + "\\Content\\readme.mht";
                    helpForm.webBrowser.Url = new Uri(helpfile);
                    helpForm.Location = new Point(
                        this.Location.X + (this.Size.Width >> 1) - (helpForm.Size.Width >> 1),
                        this.Location.Y + (this.Size.Height >> 1) - (helpForm.Size.Height >> 1)
                    );
                    helpForm.Show();
                }
                else
                {
                    helpForm.Activate();
                }
            }
            catch
            {
                InfoBox.Show(this, "Error", "Failed to load help file");
            }
        }


        // -----------------------------------------------------
        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowHelp();
        }
    }
}
