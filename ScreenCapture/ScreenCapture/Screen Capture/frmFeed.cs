using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.Screen_Capture
{
    public partial class frmFeed : Form
    {
        private CaptureWorker feedWorker;
        private Options usersOptions;

        /// <summary>
        /// 
        /// </summary>
        public frmFeed(Options UsersOptions)
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void startFeed()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void pauseFeed()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void stopFeed()
        {

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
    }
}
