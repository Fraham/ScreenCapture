using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ScreenCapture.Options;

namespace ScreenCapture
{
    public partial class frmOptions : Form
    {
        #region Class Variables

        private frmUserCaptureArea frmUCA = null;
        private int maxHeight;
        public int MaxHeight
        {
            get { return maxHeight; }
            set { maxHeight = value; }
        }
        private int maxWidth;
        public int MaxWidth
        {
            get { return maxWidth; }
            set { maxWidth = value; }
        }

        private int currentHeight;
        private int currentWidth;
        private int currentX;
        private int currentY;
        private NamedOption usersOptions;

        private bool loading = false;

        #endregion Class Variables

        #region Constructor

        /// <summary>
        /// Makes a new instance of a Option.Option.Option.Option menu form.
        /// </summary>
        /// <param name="options">The options that are currently doing run.</param>
        public frmOptions(NamedOption options)
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
            Okay();
        }

        public void Okay()
        {
            if (ValidWidth() && ValidHeight())
            {
                if (radFullScreen.Checked)
                {
                    UsersOptions = new NamedOption();
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
            grpCaptureOptions.Enabled = !radFullScreen.Checked;
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
            MaxWidth = ScreenSize.Width;
            MaxHeight = ScreenSize.Height;

            for (int i = 1; i <= SystemInformation.MonitorCount; i++)
            {
                cmbNumberOfScreens.Items.Add("Screen: " + i);
            }

            cmbNumberOfScreens.Items.Add("No Screen Selected");

            cmbNumberOfScreens.SelectedIndex = SystemInformation.MonitorCount;

            LoadOptions();
        }

        #endregion Form Loading

        #region Validation Checks

        /// <summary>
        /// It will check if its a valid height.
        /// </summary>
        /// <returns>If the height and the source point are less than the max height.</returns>
        public bool ValidHeight()
        {
            if (CurrentHeight + Math.Abs(CurrentY) > MaxHeight)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// It will check if its a valid width.
        /// </summary>
        /// <returns>If the width and the source point are less than the max width.</returns>
        public bool ValidWidth()
        {
            if (CurrentWidth + Math.Abs(CurrentX) > MaxWidth)
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
        public NamedOption UsersOptions
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

        public int CurrentHeight
        {
            get
            {
                return currentHeight;
            }

            set
            {
                currentHeight = value;
            }
        }

        public int CurrentWidth
        {
            get
            {
                return currentWidth;
            }

            set
            {
                currentWidth = value;
            }
        }

        public int CurrentX
        {
            get
            {
                return currentX;
            }

            set
            {
                currentX = value;
            }
        }

        public int CurrentY
        {
            get
            {
                return currentY;
            }

            set
            {
                currentY = value;
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
            DoUserCaptureArea(false);
        }

        private void btnShowCaptureArea_Click(object sender, EventArgs e)
        {
            DoUserCaptureArea(true);
        }

        /// <summary>
        /// Opens the form to allow the user to capture their desired area. It will then load the
        /// options back into the form again.
        /// </summary>
        private void DoUserCaptureArea(bool show)
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

            frmUCA = new frmUserCaptureArea(MakeOptions(), show);
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

        #region Options.Options

        /// <summary>
        /// Loads the options from UserOptions into the right control.
        /// </summary>
        private void LoadOptions()
        {
            loading = true;

            nudHeight.Value = UsersOptions.Height;
            nudWidth.Value = UsersOptions.Width;

            nudXSourcePoint.Value = UsersOptions.SourcePoint.X;
            nudYSourcePoint.Value = UsersOptions.SourcePoint.Y;

            radFullScreen.Checked = UsersOptions.Fullscreen;

            loading = false;

            captureOptionsChanged();
        }

        /// <summary>
        /// Gets the capture information from the form and creates, returns a new Option.Option.
        /// </summary>
        /// <returns></returns>
        private NamedOption MakeOptions()
        {
            return UsersOptions = new NamedOption(txtProfileName.Text, (int)CurrentWidth, (int)CurrentHeight, new Point((int)CurrentX, (int)CurrentY));
        }

        #endregion Options.Options



        private void cmbNumberOfScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemInformation.MonitorCount == cmbNumberOfScreens.SelectedIndex)
            {
                return;
            }
            else
            {
                Screen[] screens = Screen.AllScreens;

                UsersOptions.Height = screens[cmbNumberOfScreens.SelectedIndex].Bounds.Height;
                UsersOptions.Width = screens[cmbNumberOfScreens.SelectedIndex].Bounds.Width;

                UsersOptions.SourcePoint = new Point(screens[cmbNumberOfScreens.SelectedIndex].Bounds.Left, screens[cmbNumberOfScreens.SelectedIndex].Bounds.Top);

                LoadOptions();
            }
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            CurrentWidth = (int)nudWidth.Value;
            captureOptionsChanged();
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            CurrentHeight = (int)nudHeight.Value;
            captureOptionsChanged();
        }

        private void nudXSourcePoint_ValueChanged(object sender, EventArgs e)
        {
            CurrentX = (int)nudXSourcePoint.Value;
            captureOptionsChanged();
        }

        private void nudYSourcePoint_ValueChanged(object sender, EventArgs e)
        {
            CurrentY = (int)nudYSourcePoint.Value;
            captureOptionsChanged();
        }

        private void captureOptionsChanged()
        {
            if (!loading)
            {
                int count = 0;

                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.Bounds.Width == CurrentWidth && screen.Bounds.Height == CurrentHeight && screen.Bounds.X == CurrentX && screen.Bounds.Y == CurrentY)
                    {
                        cmbNumberOfScreens.SelectedIndex = count;

                        return;
                    }

                    count++;
                }

                if (count == SystemInformation.MonitorCount)
                {
                    cmbNumberOfScreens.SelectedIndex = count;
                }
            }
        }

        private void btnSaveUserProfile_Click(object sender, EventArgs e)
        {
            if (string.Equals(txtProfileName.Text, ""))
            {
                System.Console.WriteLine("Profile has not been given a name.");

                MessageBox.Show("The profile needs a name before it can be saved.", this.Text + " - Error", MessageBoxButtons.OK);
            }
            else
            {
                //check if the file exist, check if the want to overwrite
                MakeOptions();
                SaveOptions(txtProfileName.Text + ".XML");
                //save the options
            }
        }

        /// <summary>
        /// It will save the options to an XML file.
        /// </summary>
        private void SaveOptions(string Filename)
        {
            try
            {
                //UsersOptions.Save(Filename);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The file was not found.");
                Console.WriteLine(ex.ToString());
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}