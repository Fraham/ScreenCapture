using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ScreenCapture
{
    public partial class frmScreenCapture : Form
    {
        CaptureWorker workerObject;

        public frmScreenCapture()
        {
            InitializeComponent();

            workerObject = new CaptureWorker(this.picFeed);
        }

        /// <summary>
        /// It will capture the screen and stop the live capture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
        { 
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
    }
}