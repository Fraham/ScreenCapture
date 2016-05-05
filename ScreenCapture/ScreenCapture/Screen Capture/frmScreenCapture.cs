using System;
using System.IO;
using System.Windows.Forms;

/*
 * Things to do:
 * 
 * taking a screenshot and then opening and closing the options will start the capture.
 */

namespace ScreenCapture
{
    public partial class frmScreenCapture : Form
    {
        #region Class Variables

        private Options.Options  usersOptions;

        #endregion Class Variables

        #region Constructor

        /// <summary>
        /// Makes a new instance of the form.
        /// Loads the options from file and creates the thread for the feed.
        /// </summary>
        public frmScreenCapture()
        {
            InitializeComponent();

            loadOptions();
        }

        #endregion Constructor

        #region Loading and Saving Options.Options 

        /// <summary>
        /// It will load the options from an XML file.
        /// </summary>
        private void loadOptions()
        {
            try
            {
                UsersOptions = Options.Options.LoadFromFile();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The file was not found. " + ex.ToString());
                UsersOptions = new Options.Options ();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load file - " + ex.ToString());
                UsersOptions = new Options.Options ();
            }
        }

        /// <summary>
        /// It will save the options to an XML file.
        /// </summary>
        private void saveOptions()
        {
            UsersOptions.Save();
        }

        #endregion Loading and Saving Options.Options 

        #region Form CLosing

        /// <summary>
        /// Makes sure that the thread is stopped when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveOptions();
        }

        #endregion Form CLosing

        #region Properties

        /// <summary>
        /// Holds all the options for the capture
        /// </summary>
        public Options.Options  UsersOptions
        {
            get
            {
                if (usersOptions == null)
                {
                    return new Options.Options ();
                }

                return usersOptions;
            }
            set
            {
                usersOptions = value;
            }
        }

        #endregion Properties

        #region Picture Box Context Strip

        /// <summary>
        /// Calls for the screenshot to be copied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsPictureBoxCopy_Click(object sender, EventArgs e)
        {
            copyScreenshot();
        }

        /// <summary>
        /// Calls for the screenshot to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsPictureBoxSave_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }

        #endregion Picture Box Context Strip

        #region Menu Strip

        #region Screenshot

        private void mnsScreenCaptureCopy_Click(object sender, EventArgs e)
        {
            copyScreenshot();
        }

        private void mnsScreenCaptureSave_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }

        private void mnsScreenCaptureTake_Click(object sender, EventArgs e)
        {
            takeScreenshot();
        }

        #endregion Screenshot

        #region Options.Options 

        private void mnsScreenCaptureOptions_Click(object sender, EventArgs e)
        {
            openOptionsForm();
        }

        #endregion Options.Options 

        #endregion Menu Strip

        #region Screenshot Methods

        private void copyScreenshot()
        {
            /*try
            {
                Clipboard.SetImage(picFeed.Image);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }*/
        }

        private void saveScreenshot()
        {
            /*try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPEG File | *.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picFeed.Image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }*/
        }

        private void takeScreenshot()
        {
            /*
             * It will check if the worker has already been started.
             * Then it will resume and pause to get a still image.
             *
             * If it hasn't been started already it will start and then pause
             * with a small sleep so has enough time to capture the screen.
            */
            /*
            if (WorkerObject.Started)
            {
                WorkerObject.Resume();
            }
            else
            {
                WorkerObject.Start();
            }

            Thread.Sleep(10);
            WorkerObject.Pause();
            */

            Screenshot screenshot = new Screenshot(UsersOptions);
            screenshot.Capture();

            //this.picFeed.Image = screenshot.Image;

            frmScreenshot frmShot = new frmScreenshot(screenshot);
            frmShot.Show();

            mnsScreenCaptureSave.Enabled = true;
            mnsScreenCaptureCopy.Enabled = true;
        }

        #endregion Screenshot Methods

        /// <summary>
        /// It will open the options menu in dialog form.
        /// It will load the new capture options if the user has changed the settings.
        /// </summary>
        private void openOptionsForm()
        {
            frmOptions frmO = new frmOptions(UsersOptions);
            if (frmO.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UsersOptions = frmO.UsersOptions;
            }
        }

        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            ScreenCapture.frmFeed feed = new ScreenCapture.frmFeed(this.UsersOptions);
            feed.Show();
        }
    }
}