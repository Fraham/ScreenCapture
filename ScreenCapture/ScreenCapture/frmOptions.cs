using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmOptions : Form
    {
        #region Class Variables

        private frmUserCaptureArea frmUCA = null;
        private int maxHeight;
        private int maxWidth;
        private Options usersOptions;

        #endregion Class Variables

        #region Constructor

        /// <summary>
        /// Makes a new instance of a Options menu form.
        /// </summary>
        /// <param name="options">The options that are currently doing run.</param>
        public frmOptions(Options options)
        {
            UsersOptions = options;
            InitializeComponent();
        }

        #endregion Constructor

        #region Click Events

        /// <summary>
        /// It will close the form discarding the new options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// It will save the new options.
        /// It will check to make sure that all the new values are correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validWidth() && validHeight())
            {
                if (radFullScreen.Checked)
                {
                    UsersOptions = new Options();
                }
                else
                {
                    UsersOptions = MakeOptions();
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                System.Console.WriteLine("Capture area too large for the screen.");
                this.DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// It will only close when the values are correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        /// <summary>
        /// Will make the capture options enabled or disabled depending whether full-screen is on or off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the form loads.
        /// It will set the limits on the options numeric up and downs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOptions_Load(object sender, EventArgs e)
        {
            nudWidth.Maximum = ScreenSize.Width;
            nudHeight.Maximum = ScreenSize.Height;

            nudXSourcePoint.Maximum = ScreenSize.Width;
            nudYSourcePoint.Maximum = ScreenSize.Height;

            nudXSourcePoint.Minimum = ScreenSize.TopLeftPoint.X;
            nudYSourcePoint.Minimum = ScreenSize.TopLeftPoint.Y;

            maxWidth = ScreenSize.Width;
            maxHeight = ScreenSize.Height;

            LoadOptions();
        }

        #endregion Form Loading

        #region Validation Checks

        /// <summary>
        /// It will check if its a valid height.
        /// </summary>
        /// <returns>If the height and the source point are less than the max height.</returns>
        private bool validHeight()
        {
            if (nudHeight.Value + Math.Abs(nudYSourcePoint.Value) > maxHeight)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// It will check if its a valid width.
        /// </summary>
        /// <returns>If the width and the source point are less than the max width.</returns>
        private bool validWidth()
        {
            if (nudWidth.Value + Math.Abs(nudXSourcePoint.Value) > maxWidth)
            {
                return false;
            }

            return true;
        }

        #endregion Validation Checks

        #region Properties

        /// <summary>
        /// Holds all the options for the capture
        /// </summary>
        public Options UsersOptions
        {
            get
            {
                return usersOptions;
            }
            set
            {
                usersOptions = value;
            }
        }

        #endregion Properties

        #region User Capture

        /// <summary>
        /// When the user clicks the button it will send to run the user capture area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCaptureArea_Click(object sender, EventArgs e)
        {
            DoUserCaptureArea();
        }

        /// <summary>
        /// Opens the form to allow the user to capture their desired area. It will then load the
        /// options back into the form again.
        /// </summary>
        private void DoUserCaptureArea()
        {
            /*
             * It will check if the form is already open, if so then it will dispose it.
             * It will open the form with the current options.
            */
            if (frmUCA != null)
            {
                frmUCA.Dispose();
                frmUCA = null;
            }

            frmUCA = new frmUserCaptureArea(MakeOptions());
            frmUCA.InstanceRef = this;

            this.Hide();
            Application.DoEvents();

            /*
             * If the response from the form is OK then it will get the options from user capture form and make sure that it is correct and then load them onto the form.
             */

            if (frmUCA.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UsersOptions = frmUCA.CaptureOptions;

                if (UsersOptions.Width < ScreenSize.Width && UsersOptions.Height < ScreenSize.Height)
                {
                    UsersOptions.Fullscreen = false;
                }

                UsersOptions.SourcePoint = new Point(UsersOptions.SourcePoint.X + ScreenSize.TopLeftPoint.X, UsersOptions.SourcePoint.Y + ScreenSize.TopLeftPoint.Y);

                LoadOptions();
            }
        }

        #endregion User Capture

        #region Options

        /// <summary>
        /// Loads the options from UserOptions into the right control.
        /// </summary>
        private void LoadOptions()
        {
            nudHeight.Value = UsersOptions.Height;
            nudWidth.Value = UsersOptions.Width;

            nudXSourcePoint.Value = UsersOptions.SourcePoint.X;
            nudYSourcePoint.Value = UsersOptions.SourcePoint.Y;

            radFullScreen.Checked = UsersOptions.Fullscreen;
        }

        /// <summary>
        /// Gets the capture information from the form and creates, returns a new Options.
        /// </summary>
        /// <returns></returns>
        private Options MakeOptions()
        {
            return UsersOptions = new Options((int)nudWidth.Value, (int)nudHeight.Value, new Point((int)nudXSourcePoint.Value, (int)nudYSourcePoint.Value));
        }

        #endregion Options

        private void btnShowCaptureArea_Click(object sender, EventArgs e)
        {

        }

        private void showCaptureForm(bool show)
        {

        }
    }
}