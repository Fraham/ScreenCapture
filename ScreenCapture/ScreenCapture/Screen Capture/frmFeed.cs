using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.ScreenCapture
{
    public partial class frmFeed : Form
    {
        private CaptureWorker feedWorker;
        private Options usersOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usersOptions"></param>
        public frmFeed(Options usersOptions)
        {
            InitializeComponent();

            this.UsersOptions = usersOptions;

            FeedWorker = new CaptureWorker(this.UsersOptions, this.picFeed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            startFeed();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseFeed();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            stopFeed();
        }

        /// <summary>
        /// 
        /// </summary>
        private void startFeed()
        {
            this.FeedWorker.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void pauseFeed()
        {
            this.FeedWorker.Pause();
        }

        /// <summary>
        /// 
        /// </summary>
        private void stopFeed()
        {
            this.FeedWorker.Stop();

            Console.WriteLine("Elapsed Time: " + this.FeedWorker.CaptureTime.Elapsed);
            Console.WriteLine("Number of Frames: " + this.FeedWorker.Frames);
        }

        /// <summary>
        /// Holds all the information about the current feed.
        /// </summary>
        public CaptureWorker FeedWorker
        {
            get
            {
                return feedWorker;
            }
            set
            {
                feedWorker = value;
            }
        }

        /// <summary>
        /// Holds all the options for the capture
        /// </summary>
        public Options UsersOptions
        {
            get
            {
                if (usersOptions == null)
                {
                    return new Options();
                }

                return usersOptions;
            }
            set
            {
                usersOptions = value;
            }
        }

        private void frmFeed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.FeedWorker.Started)
            {
                this.FeedWorker.Stop();
            }
        }

        private void frmFeed_Load(object sender, EventArgs e)
        {

        }
    }
}
