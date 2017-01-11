using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace ScreenCapture
{
    public class CaptureWorker
    {
        #region Class Variables

        private ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private Thread _thread;
        private int frames = 0;
        private Options.Option options;
        private bool started = false;
        private bool capturing = false;
        private Stopwatch captureTime;

        private string path;

        #endregion Class Variables

        #region Constructors

        /// <summary>
        /// Makes a new instance of a capture worker It will capture an area using the options provided.
        /// </summary>
        /// <param name="options">The options for the capture.</param>
        /// <param name="picBox">The picture box being used to display the capture.</param>
        public CaptureWorker(Options.Option options, string path)
        {
            CaptureOptions = options;

            this.Path = path;
        }

        #endregion Constructors

        #region Threading

        /// <summary>
        /// This will pause the thread from running. It can be resumed by using Resume function.
        /// </summary>
        public void Pause()
        {
            Capturing = false;
            CaptureTime.Stop();
            _pauseEvent.Reset();
        }

        /// <summary>
        /// Used to restart the thread when it has been paused by the Pause function.
        /// </summary>
        public void Resume()
        {
            Capturing = true;
            CaptureTime.Start();
            _pauseEvent.Set();
        }

        /// <summary>
        /// This will start the thread from running.
        /// </summary>
        public void Start()
        {
            _pauseEvent = new ManualResetEvent(true);
            _shutdownEvent = new ManualResetEvent(false);
            Started = true;
            Capturing = true;
            CaptureTime.Restart();
            _thread = new Thread(DoCapture);
            _thread.Start();

            frames = 0;
        }

        /// <summary>
        /// This will completely stop the running thread. It will allow for the currently paused
        /// thread to resume again. It will allow the current thread to finish a loop around before stopping.
        /// </summary>
        public void Stop()
        {
            if (started)
            {
                CaptureTime.Stop();
                // Signal the shutdown event
                _shutdownEvent.Set();

                // Make sure to resume any paused threads
                _pauseEvent.Set();

                // Wait for the thread to exit
                _thread.Join();

                Started = false;
                Capturing = false;
            }
        }

        #endregion Threading

        #region Capture

        /// <summary>
        /// This will run the capture code until the signal to stop the thread. The call comes form
        /// the global variable shouldStop which can be changed to false by calling RequestStop. Once
        /// the request to stop the thread is made it will finish until the end of the current thread
        /// and then it will stop looping. The capture uses the global variables CaptureWidth and
        /// CaptureHeight as the width and height of the capture. It will display the capture on the
        /// picture box that was used when creating the new class.
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
                Bitmap image = new Bitmap(CaptureOptions.Width, CaptureOptions.Height);
                Graphics graphics = Graphics.FromImage(image);

                /*
                 * Copy the graphics from the screen for the whole screen.
                 * Then it will set the created bitmap image to the picture box.
                 */
                graphics.CopyFromScreen(CaptureOptions.SourcePoint, Point.Empty, new Size(CaptureOptions.Width, CaptureOptions.Height));

                graphics.Dispose();

                //PicBox.Image = image;

                ThreadPool.QueueUserWorkItem(saveFeedImages, new ImageSaverThread(Path, image.Clone() as Bitmap, Frames));

                saveFeedImages(new ImageSaverThread(Path, image.Clone() as Bitmap, Frames));

                frames++;
            }
        }

        #endregion Capture

        #region Properties

        /// <summary>
        /// Getter and Setter for the capture options. This holds all the information needed for the capture.
        /// </summary>
        public Options.Option CaptureOptions
        {
            get
            {
                return options;
            }
            set
            {
                options = value;
            }
        }

        /// <summary>
        /// Getter and Setter for the frames variable. The variable is used to count the amount of
        /// frames processed.
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
        /// Getter and Setter for the started variable. The variable is boolean so can only be true
        /// or false.
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
        /// Getter and Setter for the capturing variable. The variable is boolean so can only be true
        /// or false.
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

        /// <summary>
        /// Getter and Setter for capture time. When setting the value for the capture time must not
        /// be null.
        /// </summary>
        public Stopwatch CaptureTime
        {
            get
            {
                if (captureTime == null)
                {
                    return captureTime = new Stopwatch();
                }
                else
                {
                    return captureTime;
                }
            }
            set
            {
                if (value == null)
                {
                    System.Console.WriteLine("Null capture time.");

                    captureTime = new Stopwatch();
                }
                else
                {
                    captureTime = value;
                }
            }
        }

        /// <summary>
        /// The path variable were the feed images will be saved. If the path is null is it throw an
        /// ArgumentNullException. If the path does not exist then it will create it.
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The path is null");
                }
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                path = value;
            }
        }

        #endregion Properties

        /// <summary>
        /// Will save an image to file. Used in the feed to save the captured images. It is part of a
        /// thread pool to allow for execution of saving while still capturing.
        /// </summary>
        /// <param name="objectRef">The ImagerSaverThread is used.</param>
        public void saveFeedImages(object objectRef)
        {
            ImageSaverThread threaData = objectRef as ImageSaverThread;

            if (!Directory.Exists(threaData.FolderPath))
            {
                Directory.CreateDirectory(threaData.FolderPath);
            }

            if (!threaData.FolderPath.ToLower().EndsWith(@"\"))
            {
                threaData.FolderPath += @"\";
            }

            threaData.ImageToSave.Save(string.Format("{0}image{1}.jpeg", threaData.FolderPath, threaData.FrameNumber));

            threaData.ImageToSave.Dispose();
        }
    }
}