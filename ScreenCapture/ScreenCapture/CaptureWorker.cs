using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace ScreenCapture
{
    internal class CaptureWorker
    {
        private int captureHeight;
        private int captureWidth;
        private PictureBox picBox;

        private volatile bool shouldStop;

        /// <summary>
        /// Makes a new instance of a capture worker.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(int captureWidth, int captureHeight, PictureBox picBox)
        {
            CaptureWidth = captureWidth;
            CaptureHeight = captureHeight;
            PicBox = picBox;
        }

        /// <summary>
        ///
        /// </summary>
        public void DoCapture()
        {
            /*
             * Creates a new bitmap with the width and height of the primary screen (the one with the taskbar).
             * Then it will create a graphics from the new bitmap.
             */
            Bitmap bitmap = new Bitmap(CaptureWidth, CaptureHeight);
            Graphics graphics = Graphics.FromImage(bitmap);

            /*
             * Copy the graphics from the screen for the whole screen.
             * Then it will set the created bitmap image to the picture box.
             */
            //graphics.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.WorkingArea.Size);
            graphics.CopyFromScreen(Point.Empty, Point.Empty, new Size(CaptureWidth, CaptureHeight));

            /*if (PicBox.Image != null)
            {
                PicBox.Image.Dispose();
            }*/

            PicBox.Image = bitmap;
        }

        /// <summary>
        ///
        /// </summary>
        public void RequestStop()
        {
            shouldStop = true;
        }

        #region Getters and Setters

        /// <summary>
        /// Getter and Setter for the capture height.
        ///
        /// When setting the value for the height must be not be negative.
        /// </summary>
        public int CaptureHeight
        {
            get
            {
                return this.captureHeight;
            }

            set
            {
                if (value < 0)
                {
                    this.captureHeight = 0;
                }
                else
                {
                    this.captureHeight = value;
                }
            }
        }

        /// <summary>
        /// Getter and Setter for the capture width.
        ///
        /// When setting the value for the width must be not be negative.
        /// </summary>
        public int CaptureWidth
        {
            get
            {
                return this.captureWidth;
            }

            set
            {
                if (value < 0)
                {
                    this.captureWidth = 0;
                }
                else
                {
                    this.captureWidth = value;
                }
            }
        }

        /// <summary>
        /// Getter and Setter for picture box.
        ///
        /// When setting the value for the picture box must not be null.
        /// </summary>
        public PictureBox PicBox
        {
            get
            {
                return this.picBox;
            }

            set
            {
                if (value != null)
                {
                    //make an error message.
                }
                else
                {
                    picBox = value;
                }
            }
        }

        #endregion Getters and Setters
    }
}