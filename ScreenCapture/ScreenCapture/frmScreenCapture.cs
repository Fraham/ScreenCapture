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
        Thread feedThread;
        CaptureWorker workerObject;

        public frmScreenCapture()
        {
            InitializeComponent();

            workerObject = new CaptureWorker(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height, this.picFeed);
            feedThread = new Thread(workerObject.DoCapture);            
        }

        /// <summary>
        /// It will capture the screen and stop the live capture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            workerObject.RequestStop();

            CaptureScreen();
        }

        /// <summary>
        /// It will start the thread when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            feedThread.Start();
        }

        /// <summary>
        /// Will capture a frame of the current primary screen.
        /// </summary>
        private void CaptureScreen()
        {
            /*
             * Creates a new bitmap with the width and height of the primary screen (the one with the task bar).
             * Then it will create a graphics from the new bitmap.
             */ 
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            
            /*
             * Copy the graphics from the screen for the whole screen.
             * Then it will set the created bitmap image to the picture box.
             */ 
            graphics.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.WorkingArea.Size);

            graphics.Dispose();

            if (picFeed.Image != null)
            {
                picFeed.Image.Dispose();
            }

            picFeed.Image = bitmap;
        }

        /// <summary>
        /// Makes sure that the thread is stopped when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            workerObject.RequestStop();
        }
    }
}