using System;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmScreenCapture : Form
    {
        private CaptureWorker workerObject;

        public frmScreenCapture()
        {
            InitializeComponent();

            workerObject = new CaptureWorker(this.picFeed);
        }

        #region Click Events

        /// <summary>
        /// It will start the thread when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            if (workerObject.Started)
            {
                workerObject.Resume();
            }
            else
            {
                workerObject.Start();
            }
        }

        /// <summary>
        /// It will capture the screen and stop the live capture.
        /// This uses the same settings as the live feed but it will only take one frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            /*
             * It will check if the worker has already been started.
             * Then it will resume and pause to get a still image.
             *
             * If it hasn't been started already it will start and then pause
             * with a small sleep so has enough time to capture the screen.
            */
            if (workerObject.Started)
            {
                workerObject.Resume();
                workerObject.Pause();
            }
            else
            {
                workerObject.Start();
                Thread.Sleep(10);
                workerObject.Pause();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions frmO = new frmOptions();
            frmO.ShowDialog();
        }

        #endregion Click Events

        #region Form CLosing

        /// <summary>
        /// Makes sure that the thread is stopped when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workerObject.Started)
            {
                workerObject.Stop();
            }
        }

        #endregion Form CLosing
    }
}