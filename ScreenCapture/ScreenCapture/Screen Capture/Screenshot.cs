using ScreenCapture.Interfaces;
using ScreenCapture.Factories;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using ScreenCapture.Options;

namespace ScreenCapture
{
    public class Screenshot
    {
        private Options.Option options;
        private Bitmap image;

        IScreenshotRepository screenshotRepository = ScreenshotFactory.GetRepository();

        /// <summary>
        /// Makes a new instance of a screenshot.
        /// It will capture an area from the source point to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="sourcePoint">The source point of the capture.</param>
        public Screenshot(int captureWidth, int captureHeight, Point sourcePoint, string name = "")
        {
            CaptureOptions = new NamedOption(name, captureWidth, captureHeight, sourcePoint);
        }

        /// <summary>
        /// Makes a new instance of a screenshot.
        /// It will capture an area from (0, 0) to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        public Screenshot(int captureWidth, int captureHeight, string name = "")
        {
            CaptureOptions = new NamedOption(name, captureWidth, captureHeight, Point.Empty);
        }

        public Screenshot(NamedOption options)
        {
            CaptureOptions = options;
        }

        public Screenshot(Bitmap image)
        {
            Image = image;
        }

        /// <summary>
        ///
        /// </summary>
        public Bitmap Capture()
        {
            /*
             * Creates a new bitmap with the width and height of the primary screen (the one with the task-bar).
             * Then it will create a graphics from the new bitmap.
             */
            Image = new Bitmap(CaptureOptions.Width, CaptureOptions.Height);
            Graphics graphics = Graphics.FromImage(Image);

            /*
             * Copy the graphics from the screen for the whole screen.
             * Then it will set the created bitmap image to the picture box.
             */
            graphics.CopyFromScreen(CaptureOptions.SourcePoint, Point.Empty, new Size(CaptureOptions.Width, CaptureOptions.Height));

            graphics.Dispose();

            return Image;
        }

        public void Save()
        {
            screenshotRepository.Save(Image);
        }

        public void Save(string fileName)
        {
            screenshotRepository.Save(Image, fileName: fileName);
        }

        public Image Load(string fileName)
        {
            return screenshotRepository.Load(fileName: fileName);
        }

        public void Copy()
        {
            Clipboard.SetImage(Image);
        }

        /*/// <summary>
        /// Will print the current screenshot.
        /// </summary>
        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(image, loc);
        }*/

        /// <summary>
        /// Getter and Setter for the capture options.
        /// This holds all the information needed for the capture.
        /// </summary>
        public Options.Option CaptureOptions
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
        ///
        /// </summary>
        public Bitmap Image
        {
            get
            {
                if (image != null)
                {
                    return image;
                }
                else
                {
                    throw new InvalidOperationException("The image has not been set");
                }
            }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("The image should not be null.");
                }
                image = value;
            }
        }
    }
}