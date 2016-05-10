using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Threading;

namespace ScreenCapture
{
    public class Screenshot
    {
        private Options.Options options;
        private Bitmap image;

        /// <summary>
        /// Makes a new instance of a screenshot.
        /// It will capture an area from the source point to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        /// <param name="sourcePoint">The source point of the capture.</param>
        public Screenshot(int captureWidth, int captureHeight, Point sourcePoint)
        {
            CaptureOptions = new Options.Options(captureWidth, captureHeight, sourcePoint);
        }

        /// <summary>
        /// Makes a new instance of a screenshot.
        /// It will capture an area from (0, 0) to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        public Screenshot(int captureWidth, int captureHeight)
        {
            CaptureOptions = new Options.Options(captureWidth, captureHeight, Point.Empty);
        }

        public Screenshot(Options.Options  options)
        {
            CaptureOptions = options;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Capture()
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
        }
        
        public void Save()
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPEG File | *.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
            catch
            {
                throw;
            }
        }

        public void Save(string fileName)
        {
            Image.Save(fileName, ImageFormat.Jpeg);            
        }

        public void Copy()
        {
            try
            {
                Clipboard.SetImage(Image);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
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
        }

        /// <summary>
        /// Getter and Setter for the capture options.
        /// This holds all the information needed for the capture.
        /// </summary>
        public Options.Options CaptureOptions
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
