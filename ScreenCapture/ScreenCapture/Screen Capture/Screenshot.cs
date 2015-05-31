﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreenCapture
{
    public class Screenshot
    {
        private Options options;
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
            CaptureOptions = new Options(captureWidth, captureHeight, sourcePoint);
        }

        /// <summary>
        /// Makes a new instance of a screenshot.
        /// It will capture an area from (0, 0) to the set width and height.
        /// </summary>
        /// <param name="captureWidth">The width of capture area.</param>
        /// <param name="captureHeight">The height of capture area.</param>
        public Screenshot(int captureWidth, int captureHeight)
        {
            CaptureOptions = new Options(captureWidth, captureHeight, Point.Empty);
        }

        public Screenshot(Options options)
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
            image = new Bitmap(CaptureOptions.Width, CaptureOptions.Height);
            Graphics graphics = Graphics.FromImage(image);

            /*
             * Copy the graphics from the screen for the whole screen.
             * Then it will set the created bitmap image to the picture box.
             */
            graphics.CopyFromScreen(CaptureOptions.SourcePoint, Point.Empty, new Size(CaptureOptions.Width, CaptureOptions.Height));

            graphics.Dispose();
        }

        /// <summary>
        /// Will save the current screenshot.
        /// </summary>
        public void save()
        {

        }

        /// <summary>
        /// Will copy the current screenshot.
        /// </summary>
        public void copy()
        {

        }

        /// <summary>
        /// Will print the current screenshot.
        /// </summary>
        public void print()
        {

        }

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
        /// 
        /// </summary>
        public Bitmap Image
        {
            get 
            { 
                return image; 
            }
            set 
            { 
                image = value; 
            }
        }
    }
}
