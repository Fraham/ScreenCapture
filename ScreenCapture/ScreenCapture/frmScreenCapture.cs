using System;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenCapture
{
    public partial class frmScreenCapture : Form
    {
        private CaptureWorker workerObject;
        private Options usersOptions;

        public frmScreenCapture()
        {
            InitializeComponent();

            loadOptions();

            WorkerObject = new CaptureWorker(UsersOptions, this.picFeed);
        }

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
        /// It will capture the screen and stop the live capture.
        /// This uses the same settings as the live feed but it will only take one frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenshot_Click(object sender, EventArgs e)
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
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions frmO = new frmOptions(UsersOptions);
            if (frmO.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UsersOptions = frmO.UsersOptions;
                changeCaptureOptions();
            }
        }

        #endregion Click Events

        #region Loading and Saving Options

        private void saveOptions()
        {
            using (var writer = new System.IO.StreamWriter("UserOptions.xml"))
            {
                var serializer = new XmlSerializer(UsersOptions.GetType());
                serializer.Serialize(writer, UsersOptions);
                writer.Flush();
            }
        }

        private void loadOptions()
        {
            using (var stream = System.IO.File.OpenRead("UserOptions.xml"))
            {
                var serializer = new XmlSerializer(UsersOptions.GetType());
                UsersOptions = (Options)serializer.Deserialize(stream);
            }
        }

        #endregion Loading and Saving Options

        private void changeCaptureOptions()
        {
            WorkerObject.Pause();
            WorkerObject.CaptureOptions = UsersOptions;
            WorkerObject.Resume();
        }

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

        public Options UsersOptions
        {
            get
            {
                if(usersOptions == null)
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
    }
}