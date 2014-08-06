using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenCapture
{
    public class CaptureWorker
    {
        #region Class Variables

        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private Thread _thread;
        private int frames = 0;
        private Options options;
        private PictureBox picBox;
        private bool started = false;
        private bool capturing = false;
        private Stopwatch captureTime;

        #endregion Class Variables

        #region Constructors

        /// <summary>
        /// Makes a new instance of a capture worker.
        /// It will capture an area from the source point to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        /// <param name="sourcePoint">The source point of the capture.</param>
        public CaptureWorker(int captureWidth, int captureHeight, PictureBox picBox, Point sourcePoint)
        {
            CaptureOptions = new Options(captureWidth, captureHeight, sourcePoint);

            PicBox = picBox;
        }

        /// <summary>
        /// Makes a new instance of a capture worker.
        /// It will capture an area from (0, 0) to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(int captureWidth, int captureHeight, PictureBox picBox)
        {
            CaptureOptions = new Options(captureWidth, captureHeight, Point.Empty);

            PicBox = picBox;
        }

        /// <summary>
        /// Makes a new instance of a capture worker.
        /// It will capture an area from the set x and y to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        /// <param name="x">The x co-ordinate of the source of the source</param>
        /// <param name="y">The y co-ordinate of the source of the source</param>
        public CaptureWorker(int captureWidth, int captureHeight, PictureBox picBox, int x, int y)
        {
            CaptureOptions = new Options(captureWidth, captureHeight, new Point(x, y));

            PicBox = picBox;
        }

        /// <summary>
        /// Makes a new instance of a capture worker
        /// It will set the height and width of the capture to the full area of displays.
        /// It will be able to capture the screen over multiple displays.
        /// </summary>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(PictureBox picBox)
        {
            CaptureOptions = new Options(ScreenSize.Width, ScreenSize.Height, Point.Empty);

            PicBox = picBox;
        }

        /// <summary>
        /// Makes a new instance of a capture worker
        /// It will capture an area using the options provided.
        /// </summary>
        /// <param name="options">The options for the capture.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(Options options, PictureBox picBox)
        {
            CaptureOptions = options;
            PicBox = picBox;
        }

        #endregion Constructors

        #region Threading

        /// <summary>
        /// This will pause the thread from running.
        /// It can be resumed by using Resume function.
        /// </summary>
        public void Pause()
        {
            Capturing = false;
            _pauseEvent.Reset();
        }

        /// <summary>
        /// Used to restart the thread when it has been paused by the Pause function.
        /// </summary>
        public void Resume()
        {
            Capturing = true;
            _pauseEvent.Set();
        }

        /// <summary>
        /// This will start the thread from running.
        /// </summary>
        public void Start()
        {
            Started = true;
            Capturing = true;
            _thread = new Thread(DoCapture);
            _thread.Start();
        }

        /// <summary>
        /// This will completely stop the running thread.
        /// It will allow for the currently paused thread to resume again.
        /// It will allow the current thread to finish a loop around before stopping.
        /// </summary>
        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();

            // Make sure to resume any paused threads
            _pauseEvent.Set();

            // Wait for the thread to exit
            _thread.Join();
        }

        #endregion Threading

        #region Capture

        /// <summary>
        /// This will run the capture code until the signal to stop the thread.
        /// The call comes form the global variable shouldStop which can be changed to false by calling RequestStop.
        /// Once the request to stop the thread is made it will finish until the end of the current thread and then it will stop looping.
        /// The capture uses the global variables CaptureWidth and CaptureHeight as the width and height of the capture.
        /// It will display the capture on the picture box that was used when creating the new class.
        /// </summary>
        public void DoCapture()
        {
            try
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
                    Bitmap bitmap = new Bitmap(CaptureOptions.Width, CaptureOptions.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);

                    /*
                     * Copy the graphics from the screen for the whole screen.
                     * Then it will set the created bitmap image to the picture box.
                     */
                    graphics.CopyFromScreen(CaptureOptions.SourcePoint, Point.Empty, new Size(CaptureOptions.Width, CaptureOptions.Height));

                    graphics.Dispose();

                    if (PicBox.Image != null)
                    {
                        PicBox.Image.Dispose();
                    }

                    PicBox.Image = bitmap;

                    frames++;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        #endregion Capture

        #region Properties

        /// <summary>
        /// Getter and Setter for the capture options.
        /// This holds all the information needed for the capture.
        /// </summary>
        public Options CaptureOptions
        {
            get
            {
                return this.options;
            }
            set
            {
                this.options = value;
            }
        }

        /// <summary>
        /// Getter and Setter for the frames variable.
        /// The variable is used to count the amount of frames processed.
        /// </summary>
        public int Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        /// <summary>
        /// Getter and Setter for picture box.
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
                    System.Console.WriteLine("Null picture box.");

                    picBox = new PictureBox();
                }
                else
                {
                    picBox = value;
                }
            }
        }

        /// <summary>
        /// Getter and Setter for the started variable.
        /// The variable is boolean so can only be true or false.
        /// </summary>
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

        /// <summary>
        /// Getter and Setter for the capturing variable.
        /// The variable is boolean so can only be true or false.
        /// </summary>
        public bool Capturing
        {
            get
            {
                return this.capturing;
            }
            set
            {
                this.capturing = value;
            }
        }

        #endregion Properties
    }
}