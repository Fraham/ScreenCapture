using System;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenCapture
{
    public partial class frmScreenCapture : Form
    {
        #region Class Variables

        private Options usersOptions;
        private CaptureWorker workerObject;

        #endregion Class Variables

        #region Constructor

        public frmScreenCapture()
        {
            InitializeComponent();

            loadOptions();

            WorkerObject = new CaptureWorker(UsersOptions, this.picFeed);
        }

        #endregion Constructor

        #region Click Events

        /// <summary>
        /// It will start the thread when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiveFeed_Click(object sender, EventArgs e)
        {
            if (WorkerObject.Started)
            {
                WorkerObject.Resume();
            }
            else
            {
                WorkerObject.Start();
            }
        }

        /// <summary>
        /// Will open the options form.
        /// If the user clicks okay it will change the new options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions frmO = new frmOptions(UsersOptions);
            if (frmO.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UsersOptions = frmO.UsersOptions;
                changeCaptureOptions();
            }
        }

        /// <summary>
        /// It will capture the screen and stop the live capture.
        /// This uses the same settings as the live feed but it will only take one frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            takeScreenshot();
        }

        #endregion Click Events

        #region Loading and Saving Options

        /// <summary>
        /// It will load the options from an XML file.
        /// </summary>
        private void loadOptions()
        {
            try
            {
                using (var stream = System.IO.File.OpenRead("UserOptions.xml"))
                {
                    var serializer = new XmlSerializer(UsersOptions.GetType());
                    UsersOptions = (Options)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// It will save the options to an XML file.
        /// </summary>
        private void saveOptions()
        {
            try
            {
                using (var writer = new System.IO.StreamWriter("UserOptions.xml"))
                {
                    var serializer = new XmlSerializer(UsersOptions.GetType());
                    serializer.Serialize(writer, UsersOptions);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        #endregion Loading and Saving Options

        #region Change Capture Options

        /// <summary>
        /// It will update the options for the capture.
        /// </summary>
        private void changeCaptureOptions()
        {
            WorkerObject.Pause();
            WorkerObject.CaptureOptions = UsersOptions;
            WorkerObject.Resume();
        }

        #endregion Change Capture Options

        #region Form CLosing

        /// <summary>
        /// Makes sure that the thread is stopped when the form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WorkerObject.Started)
            {
                WorkerObject.Stop();
            }

            saveOptions();
        }

        #endregion Form CLosing

        #region Properties

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

        /// <summary>
        /// Holds all the information about the current capture.
        /// </summary>
        public CaptureWorker WorkerObject
        {
            get
            {
                return workerObject;
            }
            set
            {
                workerObject = value;
            }
        }

        #endregion Properties

        #region Picture Box Context Strip

        private void cmsPictureBoxCopy_Click(object sender, EventArgs e)
        {
            copyScreenshot();
        }

        private void cmsPictureBoxSave_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }

        #endregion Picture Box Context Strip

        #region Menu Strip

        #region Screenshot

        private void mnsScreenCaptureCopy_Click(object sender, EventArgs e)
        {
            copyScreenshot();
        }

        private void mnsScreenCaptureSave_Click(object sender, EventArgs e)
        {
            saveScreenshot();
        }

        private void mnsScreenCaptureTake_Click(object sender, EventArgs e)
        {
            takeScreenshot();
        }
        #endregion Screenshot

        #region Live Feed

        private void mnsScreenCapturePause_Click(object sender, EventArgs e)
        {
        }

        private void mnsScreenCaptureStart_Click(object sender, EventArgs e)
        {
        }
        private void mnsScreenCaptureStop_Click(object sender, EventArgs e)
        {
        }

        #endregion Live Feed

        #region Options

        private void mnsScreenCaptureOptions_Click(object sender, EventArgs e)
        {
        }

        #endregion Options

        #endregion Menu Strip

        #region Screenshot Methods

        private void copyScreenshot()
        {
            try
            {
                if (!WorkerObject.Capturing)
                {
                    Clipboard.SetImage(picFeed.Image);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        private void saveScreenshot()
        {
            try
            {
                if (!WorkerObject.Capturing)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "JPEG File | *.jpeg";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        picFeed.Image.Save(dialog.FileName, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        private void takeScreenshot()
        {
            /*
             * It will check if the worker has already been started.
             * Then it will resume and pause to get a still image.
             *
             * If it hasn't been started already it will start and then pause
             * with a small sleep so has enough time to capture the screen.
            */
            if (WorkerObject.Started)
            {
                WorkerObject.Resume();
                Thread.Sleep(10);
                WorkerObject.Pause();
            }
            else
            {
                WorkerObject.Start();
                Thread.Sleep(10);
                WorkerObject.Pause();
            }

            mnsScreenCaptureSave.Enabled = true;
            mnsScreenCaptureCopy.Enabled = true;
        }

        #endregion Screenshot Methods
    }
}