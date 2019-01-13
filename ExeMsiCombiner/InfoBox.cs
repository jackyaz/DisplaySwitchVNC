using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExeMsiCombiner
{
    public partial class InfoBox : Form
    {
        // -----------------------------------------------------------------
        public enum Buttons
        {
            Ok,
            YesNo,
            YesNoCancel
        }


        // -----------------------------------------------------------------
        public InfoBox(string title, string msg, Buttons buttons)
        {
            InitializeComponent();

            Text = title;

            message.Text = msg;

            Size = new Size(Size.Width, Size.Height + message.Height);

            if (buttons == Buttons.Ok)
            {
                OK_OK.Show();
            }

            if (buttons == Buttons.YesNo)
            {
                YesNo_Yes.Show();
                YesNo_No.Show();
            }

            if (buttons == Buttons.YesNoCancel)
            {
                YesNoCancel_Yes.Show();
                YesNoCancel_No.Show();
                YesNoCancel_Cancel.Show();
            }
        }


        // -----------------------------------------------------------------
        // Brings up a basic message box with an OK button
        // -----------------------------------------------------------------
        public static DialogResult Show(IWin32Window owner, string title, string promptText)
        {
            InfoBox infoBoxDialog = new InfoBox(title, promptText, Buttons.Ok);

            return infoBoxDialog.ShowDialog(owner);
        }


        // -----------------------------------------------------------------
        // Brings up a basic message box, with the chosen button
        // -----------------------------------------------------------------
        public static DialogResult Show(IWin32Window owner, string title, string message, Buttons buttons)
        {
            InfoBox infoBoxDialog = new InfoBox(title, message, buttons);

            return infoBoxDialog.ShowDialog(owner);
        }

        private void InfoBox_Load(object sender, EventArgs e)
        {

        }
    }
}
