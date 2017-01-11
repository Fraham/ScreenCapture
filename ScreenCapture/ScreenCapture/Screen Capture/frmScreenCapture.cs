using ScreenCapture.Options;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ScreenCapture.Factories;
using ScreenCapture.Interfaces;

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

        private Screenshot screenshot;

        private IOptionsRepository optionsRepository = OptionsFactory.GetRepository();

        #endregion Class Variables

        #region Constructor

        /// <summary>
        /// Makes a new instance of the form.
        /// Loads the options from file and creates the thread for the feed.
        /// </summary>
        public frmScreenCapture()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Form CLosing

        /// <summary>
        /// Makes sure that the thread is stopped when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        #endregion Form CLosing


        #region Picture Box Context Strip

        /// <summary>
        /// Calls for the screenshot to be copied.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsPictureBoxCopy_Click(object sender, EventArgs e)
        {
            CopyScreenshot();
        }

        /// <summary>
        /// Calls for the screenshot to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsPictureBoxSave_Click(object sender, EventArgs e)
        {
            SaveScreenshot();
        }

        #endregion Picture Box Context Strip

        #region Menu Strip

        #region Screenshot

        private void mnsScreenCaptureCopy_Click(object sender, EventArgs e)
        {
            CopyScreenshot();
        }

        private void mnsScreenCaptureSave_Click(object sender, EventArgs e)
        {
            SaveScreenshot();
        }

        private void mnsScreenCaptureTake_Click(object sender, EventArgs e)
        {
            TakeScreenshot();
        }

        #endregion Screenshot

        #region Options

        private void mnsScreenCaptureOptions_Click(object sender, EventArgs e)
        {
            OpenOptionsForm();
        }

        #endregion Options.Options

        #endregion Menu Strip

        #region Screenshot Methods

        public void CopyScreenshot()
        {
            screenshot.Copy();
        }

        public void SaveScreenshot()
        {
            screenshot.Save();
        }

        public void TakeScreenshot()
        {
            screenshot = new Screenshot(optionsRepository.GetDefault());
            screenshot.Capture();

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
        public void OpenOptionsForm()
        {
            frmOptions frmO = new frmOptions(optionsRepository.GetDefault());
        }

        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdFeedSaver.ShowDialog();
            if (result == DialogResult.OK)
            {
                ScreenCapture.frmFeed feed = new ScreenCapture.frmFeed(optionsRepository.GetDefault(), fbdFeedSaver.SelectedPath);
                feed.Show();
            }
        }
    }
}