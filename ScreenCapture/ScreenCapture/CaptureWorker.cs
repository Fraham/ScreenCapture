﻿using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ScreenCapture
{
    internal class CaptureWorker
    {
        private int captureHeight;
        private int captureWidth;
        private PictureBox picBox;
        private bool started = false;

        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private Thread _thread;

        /// <summary>
        /// Makes a new instance of a capture worker.
        ///
        /// It will capture an area from (0, 0) to the set width and height.
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

        public void Start()
        {
            Started = true;

            _thread = new Thread(DoCapture);
            _thread.Start();            
        }

        public void Pause()
        {
            _pauseEvent.Reset();
        }

        public void Resume()
        {
            _pauseEvent.Set();
            System.Console.WriteLine("Resume Thread");
        }

        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();

            // Make sure to resume any paused threads
            _pauseEvent.Set();

            // Wait for the thread to exit
            _thread.Join();
        }

        /// <summary>
        /// Makes a new instance of a capture worker
        ///
        /// It will set the height and width of the capture to the full area of displays.
        /// It will be able to capture the screen over multiple displays.
        /// </summary>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(PictureBox picBox)
        {
            Rectangle totalSize = Rectangle.Empty;

            foreach (Screen s in Screen.AllScreens)
                totalSize = Rectangle.Union(totalSize, s.Bounds);

            CaptureWidth = totalSize.Width;
            CaptureHeight = totalSize.Height;
        }

        /// <summary>
        /// This will run the capture code until the signal to stop the thread.
        ///
        /// The call comes form the global variable shouldStop which can be changed to false by calling RequestStop.
        ///
        /// Once the request to stop the thread is made it will finish until the end of the current thread and then it will stop looping.
        ///
        /// The capture uses the global variables CaptureWidth and CaptureHeight as the width and height of the capture.
        /// It will display the capture on the picture box that was used when creating the new class.
        /// </summary>
        public void DoCapture()
        {
            while (true)
            {
                _pauseEvent.WaitOne(Timeout.Infinite);

                if (_shutdownEvent.WaitOne(0))
                    break;

                /*
                 * Creates a new bitmap with the width and height of the primary screen (the one with the task-bar).
                 * Then it will create a graphics from the new bitmap.
                 */
                Bitmap bitmap = new Bitmap(CaptureWidth, CaptureHeight);
                Graphics graphics = Graphics.FromImage(bitmap);

                /*
                 * Copy the graphics from the screen for the whole screen.
                 * Then it will set the created bitmap image to the picture box.
                 */
                graphics.CopyFromScreen(Point.Empty, Point.Empty, new Size(CaptureWidth, CaptureHeight));

                graphics.Dispose();

                if (PicBox.Image != null)
                {
                    PicBox.Image.Dispose();
                }

                PicBox.Image = bitmap;
            }
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
                if (value == null)
                {
                    //make an error message.
                }
                else
                {
                    picBox = value;
                }
            }
        }

        public bool Started
        {
            get
            {
                return this.started;
            }
            set
            {
                this.started = value;
            }
        }

        #endregion Getters and Setters
    }
}