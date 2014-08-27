using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    internal class ScreenSize
    {
        public static Point TopLeftPoint
        {
            get
            {
                Point TopLeftPoint = new Point();
                Rectangle oldRectangle = Rectangle.Empty;
                Rectangle newRectangle = Rectangle.Empty;

                foreach (Screen s in Screen.AllScreens)
                {
                    if (s.Equals(Screen.PrimaryScreen))
                    {
                        break;
                    }

                    newRectangle = oldRectangle = Rectangle.Union(oldRectangle, s.Bounds);
                }

                if (newRectangle.Width > Screen.PrimaryScreen.WorkingArea.Width)
                {
                    TopLeftPoint.X = -newRectangle.Width;
                }

                if (newRectangle.Height > Screen.PrimaryScreen.WorkingArea.Height)
                {
                    TopLeftPoint.Y = -newRectangle.Height;
                }

                return TopLeftPoint;
            }
        }

        public static int Height
        {
            get
            {
                Rectangle totalSize = Rectangle.Empty;

                foreach (Screen s in Screen.AllScreens)
                    totalSize = Rectangle.Union(totalSize, s.Bounds);

                return totalSize.Height;
            }
        }

        public static int Width
        {
            get
            {
                Rectangle totalSize = Rectangle.Empty;

                foreach (Screen s in Screen.AllScreens)
                    totalSize = Rectangle.Union(totalSize, s.Bounds);

                return totalSize.Width;
            }
        }
    }
}