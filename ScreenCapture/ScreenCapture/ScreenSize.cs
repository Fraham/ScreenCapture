using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    internal class ScreenSize
    {
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