using System.Windows.Forms;

namespace ScreenCapture
{
    internal class CaptureWorker
    {
        private int captureHeight;
        private int captureWidth;
        private PictureBox picBox;

        private volatile bool shouldStop;

        /// <summary>
        ///
        /// </summary>
        /// <param name="captureWidth"></param>
        /// <param name="captureHeight"></param>
        /// <param name="picBox"></param>
        public CaptureWorker(int captureWidth, int captureHeight, PictureBox picBox)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public void DoCapture()
        {
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