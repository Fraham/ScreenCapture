using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmOptions : Form
    {
        #region Class Variables

        private int maxHeight;
        private int maxWidth;
        private Options usersOptions;

        #endregion Class Variables

        public frmOptions()
        {
            InitializeComponent();
        }

        #region Click Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validWidth() && validHeight())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                System.Console.WriteLine("Capture area too large for the screen.");
                this.DialogResult = DialogResult.None;
            }
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        private void radNotFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (radFullScreen.Checked)
            {
                grpCaptureOptions.Enabled = false;
            }
            else
            {
                grpCaptureOptions.Enabled = true;
            }
        }
        #endregion Click Events

        #region Form Loading

        private void frmOptions_Load(object sender, EventArgs e)
        {
            Rectangle totalSize = Rectangle.Empty;

            foreach (Screen s in Screen.AllScreens)
                totalSize = Rectangle.Union(totalSize, s.Bounds);

            nudWidth.Maximum = totalSize.Width;
            nudHeight.Maximum = totalSize.Height;

            nudXSourcePoint.Maximum = totalSize.Width;
            nudYSourcePoint.Maximum = totalSize.Height;

            maxWidth = totalSize.Width;
            maxHeight = totalSize.Height;
        }

        #endregion Form Loading

        #region Validation Checks

        private bool validHeight()
        {
            if (nudHeight.Value + nudYSourcePoint.Value > maxHeight)
            {
                return false;
            }

            return true;
        }

        private bool validWidth()
        {
            if (nudWidth.Value + nudXSourcePoint.Value > maxWidth)
            {
                return false;
            }

            return true;
        }

        #endregion Validation Checks

        #region Properties

        public Options UsersOptions
        {
            get
            {
                return new Options((int)nudWidth.Value, (int)nudHeight.Value, new Point((int)nudXSourcePoint.Value, (int)nudYSourcePoint.Value));
            }
            set
            {
                usersOptions = value;
            }
        }

        #endregion Properties
    }
}