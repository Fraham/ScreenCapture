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
        Thread t;

        public frmScreenCapture()
        {
            InitializeComponent();

            t = new Thread(LiveFeed);
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {

        }

        private void btnLiveFeed_Click(object sender, EventArgs e)
        {

        }

        private void Capture()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.WorkingArea.Size);
            picFeed.Image = bitmap;
        }

        private void LiveFeed()
        {

        }
    }
}