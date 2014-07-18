using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreenCapture
{
    class Options
    {
        private int width;
        private int height;
        private Point sourcePoint;
        private bool fullscreen;

        public Options()
        {
            Width = 0;
            Height = 0;
            SourcePoint = new Point();
            Fullscreen = false;
        }

        public Options(int width, int height, Point sourcePoint, bool fullscreen)
        {
            Width = width;
            Height = height;
            SourcePoint = sourcePoint;
            Fullscreen = fullscreen;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    this.width = 0;

                    System.Console.WriteLine("The width was set to be less than zero");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    this.height = 0;

                    System.Console.WriteLine("The height was set to be less than zero");
                }
                else
                {
                    this.height = value;
                }
            }
        }

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
    }
}
