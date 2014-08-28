using System.Drawing;
using System.Windows.Forms;
using System;

namespace ScreenCapture
{
    public class Options
    {
        #region Class Variables

        private bool fullscreen;
        private int height;
        private Point sourcePoint;
        private int width;

        #endregion Class Variables

        #region Constructors

        /// <summary>
        /// Making a new instance of the options class.
        /// This will store the users options for the capture.
        /// </summary>
        public Options()
        {
            Width = ScreenSize.Width;
            Height = ScreenSize.Height;
            SourcePoint = ScreenSize.TopLeftPoint;
            Fullscreen = true;
        }

        /// <summary>
        /// Making a new instance of the options class.
        /// This will store the users options for the capture.
        /// </summary>
        /// <param name="width">The width of the capture area.</param>
        /// <param name="height">The height of the capture area.</param>
        /// <param name="sourcePoint">The source point of the capture.</param>
        public Options(int width, int height, Point sourcePoint)
        {
            Width = width;
            Height = height;
            SourcePoint = sourcePoint;
            Fullscreen = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Getters and setter for the full screen.
        /// </summary>
        public bool Fullscreen
        {
            get
            {
                return this.fullscreen;
            }
            set
            {
                this.fullscreen = value;
            }
        }

        /// <summary>
        /// Getters and setter for the height.
        /// The height must be not be negative.
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 1)
                {
                    this.height = 1;

                    System.Console.WriteLine("The height was set to be less than one.");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.Y) > SystemInformation.VirtualScreen.Height)
                {
                    this.height = SystemInformation.VirtualScreen.Height - Math.Abs(SourcePoint.Y);

                    System.Console.WriteLine("The height was set too high to fit inside the screen.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

        /// <summary>
        /// Getters and setter for the source point.
        /// </summary>
        public Point SourcePoint
        {
            get
            {
                return this.sourcePoint;
            }
            set
            {
                this.sourcePoint = value;
            }
        }

        /// <summary>
        /// Getters and setter for the width.
        /// The width must be not be negative.
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 1)
                {
                    this.width = 1;

                    System.Console.WriteLine("The width was set to be less than one");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.X) > SystemInformation.VirtualScreen.Width)
                {
                    this.width = SystemInformation.VirtualScreen.Width - Math.Abs(SourcePoint.X);

                    System.Console.WriteLine("The width was set too high to fit inside the screen.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        #endregion Properties
    }
}