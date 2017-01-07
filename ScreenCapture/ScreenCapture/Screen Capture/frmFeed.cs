using System;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapture.ScreenCapture
{
    public partial class frmFeed : Form
    {
        private CaptureWorker feedWorker;
        private Options.Options usersOptions;

        private ManualResetEvent pauseThread = new ManualResetEvent(true);
        private ManualResetEvent shutdownThread = new ManualResetEvent(false);

        private Thread timerDisplayThread;

        public frmFeed(Options.Options usersOptions, string path)
        {
            InitializeComponent();

            this.UsersOptions = usersOptions;

            FeedWorker = new CaptureWorker(this.UsersOptions, path);
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
            if (running)
            {
                pauseFeed();
            }
            else
            {
                resumeFeed();
            }
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

            pauseThread = new ManualResetEvent(true);
            shutdownThread = new ManualResetEvent(false);

            timerDisplayThread = new Thread(DisplayTimer);
            running = true;
            timerDisplayThread.Start();
        }

        /// <summary>
        ///
        /// </summary>
        public void resumeFeed()
        {
            this.FeedWorker.Resume();

            pauseThread.Set();

            running = true;
        }

        /// <summary>
        ///
        /// </summary>
        public void pauseFeed()
        {
            this.FeedWorker.Pause();

            pauseThread.Reset();

            running = false;
        }

        /// <summary>
        ///
        /// </summary>
        public void stopFeed()
        {
            this.FeedWorker.Stop();

            Console.WriteLine("Elapsed Time: " + this.FeedWorker.CaptureTime.Elapsed);
            Console.WriteLine("Number of Frames: " + this.FeedWorker.Frames);

            // Signal the shutdown event
            shutdownThread.Set();

            // Make sure to resume any paused threads
            //pauseThread.Set();

            // Wait for the thread to exit
           // timerDisplayThread.Join();

            running = false;
        }

        public bool running = false;

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
        public Options.Options UsersOptions
        {
            get
            {
                if (usersOptions == null)
                {
                    return new Options.Options();
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
            if (this.FeedWorker != null && this.FeedWorker.Started)
            {
                this.FeedWorker.Stop();
            }
        }

        private void frmFeed_Load(object sender, EventArgs e)
        {
            if (this.FeedWorker == null)
            {
                this.Close();
            }
        }

        private void DisplayTimer()
        {
            while (true)
            {
                pauseThread.WaitOne(Timeout.Infinite);

                if (shutdownThread.WaitOne(0))
                    break;

                SetText(FeedWorker.CaptureTime.Elapsed.ToString());
            }
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (this.lblTimer.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblTimer.Text = text;
            }
        }
    }
}