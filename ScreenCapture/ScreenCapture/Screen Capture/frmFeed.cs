using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.ScreenCapture
{
    public partial class frmFeed : Form
    {
        private CaptureWorker feedWorker;
        private Options.Options  usersOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usersOptions"></param>
        public frmFeed(Options.Options  usersOptions)
        {
            InitializeComponent();

            this.UsersOptions = usersOptions;

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
        public void startFeed()
        {
            this.FeedWorker.Start();

            this.btnSaveFeed.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void resumeFeed()
        {
            this.FeedWorker.Resume();
        }
        /// <summary>
        /// 
        /// </summary>
        public void pauseFeed()
        {
            this.FeedWorker.Pause();
        }

        /// <summary>
        /// 
        /// </summary>
        public void stopFeed()
        {
            this.FeedWorker.Stop();

            Console.WriteLine("Elapsed Time: " + this.FeedWorker.CaptureTime.Elapsed);
            Console.WriteLine("Number of Frames: " + this.FeedWorker.Frames);
            Console.WriteLine("Number of Pictures: " + this.FeedWorker.FeedPictures.Count);

            this.btnSaveFeed.Enabled = true;
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

        private void btnSaveFeed_Click(object sender, EventArgs e)
        {
            saveFeedImages();
        }

        public void saveFeedImages()
        {
            DialogResult result = fbdFeedSaver.ShowDialog();
            if (result == DialogResult.OK)
            {
                feedWorker.saveFeedImages(fbdFeedSaver.SelectedPath);
            }
        }
    }
}
