using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExeMsiCombiner
{
    public class Options
    {
        const string optionsHeaderString = "ExeMsiCombiner Options File, Ver. 1.0.0.0";

        public class VersionInfo
        {
            public string productVersion;
            public string fileVersion;
            public string companyName;
            public string productName;
            public string legalCopyright;

            public VersionInfo()
            {
                this.productVersion = "1.0.0.0";
                this.fileVersion = "1.0.0.0";
                this.companyName = "YourCompanyName";
                this.productName = "Setup/Installer";
                this.legalCopyright = "©YourCompanyName, Year";
            }
        }

        public string inputExeFile = "";
        public string inputMsiFile = "";
        public string inputIcoFile = "";
        public string outputExeFile = "";
        public bool useVersionInfo = false;
        public VersionInfo versionInfo = new VersionInfo();
        public string commandLineArgs = "";
        public bool compress = false;


        // Clones options
        // -----------------------------------------------------------------
        public void Clone(Options source)
        {
            inputExeFile = source.inputExeFile;
            inputMsiFile = source.inputMsiFile;
            inputIcoFile = source.inputIcoFile;
            outputExeFile = source.outputExeFile;
            useVersionInfo = source.useVersionInfo;
            versionInfo.productVersion = source.versionInfo.productVersion;
            versionInfo.fileVersion = source.versionInfo.fileVersion;
            versionInfo.companyName = source.versionInfo.companyName;
            versionInfo.productName = source.versionInfo.productName;
            versionInfo.legalCopyright = source.versionInfo.legalCopyright;
            commandLineArgs = source.commandLineArgs;
            compress = source.compress;
        }


        // Default construction
        // -----------------------------------------------------------------
        public Options()
        {
        }


        // Copy construction
        // -----------------------------------------------------------------
        public Options(Options source)
        {
            this.Clone(source);
        }

            
        // -----------------------------------------------------------------
        // Populates the options from the information on the mainForm
        // -----------------------------------------------------------------
        public Options(MainForm mainForm)
        {
            inputExeFile = mainForm.textBoxExe.Text;
            inputMsiFile = mainForm.textBoxMsi.Text;
            inputIcoFile = mainForm.textBoxIcon.Text;
            outputExeFile = mainForm.textBoxOutputExe.Text;
            useVersionInfo = mainForm.checkBoxFileVersionInfo.Checked;
            versionInfo.productVersion = mainForm.textBoxProductVersion.Text;
            versionInfo.fileVersion = mainForm.textBoxFileVersion.Text;
            versionInfo.companyName = mainForm.textBoxCompanyName.Text;
            versionInfo.productName = mainForm.textBoxProductName.Text;
            versionInfo.legalCopyright = mainForm.textBoxLegalCopyright.Text;
            commandLineArgs = mainForm.textBoxCmdLineArgs.Text;
            compress = mainForm.comboBoxCompression.SelectedIndex == 1;
        }


        // -----------------------------------------------------------------
        // Populates the options from the information on the mainForm
        // -----------------------------------------------------------------
        public void CopyToForm(MainForm mainForm)
        {
            mainForm.textBoxExe.Text = inputExeFile;
            mainForm.textBoxMsi.Text = inputMsiFile;
            mainForm.textBoxIcon.Text = inputIcoFile;
            mainForm.textBoxOutputExe.Text = outputExeFile;
            mainForm.checkBoxFileVersionInfo.Checked = useVersionInfo;
            mainForm.textBoxProductVersion.Text = versionInfo.productVersion;
            mainForm.textBoxFileVersion.Text = versionInfo.fileVersion;
            mainForm.textBoxCompanyName.Text = versionInfo.companyName;
            mainForm.textBoxProductName.Text = versionInfo.productName;
            mainForm.textBoxLegalCopyright.Text = versionInfo.legalCopyright;
            mainForm.textBoxCmdLineArgs.Text = commandLineArgs;
            mainForm.comboBoxCompression.SelectedIndex = compress ? 1 : 0;
        }


        // -----------------------------------------------------------------
        public string SaveToRegString()
        {
            string s = "";
            s+="inputExeFile=" + inputExeFile + ";";
            s+="inputMsiFile=" + inputMsiFile + ";";
            s+="inputIcoFile=" + inputIcoFile + ";";
            s+="outputExeFile=" + outputExeFile + ";";
            s+="useVersionInfo=" + (useVersionInfo ? "1" : "0") + ";";
            s+="productVersion=" + versionInfo.productVersion + ";";
            s+="fileVersion=" + versionInfo.fileVersion + ";";
            s+="companyName=" + versionInfo.companyName + ";";
            s+="productName=" + versionInfo.productName + ";";
            s+="legalCopyright=" + versionInfo.legalCopyright + ";";
            s+="commandLineArgs=" + commandLineArgs + ";";
            s+="compress=" + (compress ? "1" : "0") + ";";
            return s;
        }


        // -----------------------------------------------------------------
        public bool Save(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(optionsHeaderString);
                sw.WriteLine("inputExeFile=" + inputExeFile);
                sw.WriteLine("inputMsiFile=" + inputMsiFile);
                sw.WriteLine("inputIcoFile=" + inputIcoFile);
                sw.WriteLine("outputExeFile=" + outputExeFile);
                sw.WriteLine("useVersionInfo=" + (useVersionInfo ? "1" : "0"));
                sw.WriteLine("productVersion=" + versionInfo.productVersion);
                sw.WriteLine("fileVersion=" + versionInfo.fileVersion);
                sw.WriteLine("companyName=" + versionInfo.companyName);
                sw.WriteLine("productName=" + versionInfo.productName);
                sw.WriteLine("legalCopyright=" + versionInfo.legalCopyright);
                sw.WriteLine("commandLineArgs=" + commandLineArgs);
                sw.WriteLine("compress=" + (compress ? "1" : "0"));

                sw.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }


        // Loads options from a string. Options are seperated by ";"
        // -----------------------------------------------------------------
        public bool LoadFromString(string s)
        {
            bool rval = true;
            Options orig = new Options(this);
                       
            // Remove any extra whitespace and trailing ';'
            s = s.Trim();
            while (s.EndsWith(";"))
                s = s.Substring(0, s.Length - 1).Trim();

            string[] nameValuePairs = s.Split(";".ToCharArray());

            // Load all the options in
            foreach (string nameValuePair in nameValuePairs)
            {
                string[] nameValue = nameValuePair.Split("=".ToCharArray(), 2);
                if (nameValue.Length != 2) {rval = false; break;}
                string name = nameValue[0].Trim();
                string value = nameValue[1].Trim();

                if (name == "inputExeFile") inputExeFile = value;
                else if (name == "inputMsiFile") inputMsiFile = value;
                else if (name == "inputIcoFile") inputIcoFile = value;
                else if (name == "outputExeFile") outputExeFile = value;
                else if (name == "useVersionInfo") useVersionInfo = value == "1";
                else if (name == "productVersion") versionInfo.productVersion = value;
                else if (name == "fileVersion") versionInfo.fileVersion = value;
                else if (name == "companyName") versionInfo.companyName = value;
                else if (name == "productName") versionInfo.productName = value;
                else if (name == "legalCopyright") versionInfo.legalCopyright = value;
                else if (name == "commandLineArgs") commandLineArgs = value;
                else if (name == "compress") compress = value == "1";
                else { rval = false; break; }
            }

            // failed to load => restore original options
            if (rval == false)
            {
                this.Clone(orig);
                return false;
            }

            return true;
        }


        // Loads options from a file. Options are seperated by "\n"
        // -----------------------------------------------------------------
        public bool Load(string filename)
        {
            // Read the file into a string
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string header = sr.ReadLine();
            if (header != optionsHeaderString)
            {
                sr.Close();
                fs.Close();
                return false;
            }
            string inputString = sr.ReadToEnd();
            sr.Close();
            fs.Close();


            // replace every new line with a ; (except the last new line)
            inputString = inputString.Replace("\r", ";");
            inputString = inputString.Replace("\n", "");

            return LoadFromString(inputString);
        }

        
        // -----------------------------------------------------------------
        // Returns true if we are using msi only mode
        // -----------------------------------------------------------------
        public bool MsiOnly()
        {
            return inputExeFile == "";
        }
    }
}
