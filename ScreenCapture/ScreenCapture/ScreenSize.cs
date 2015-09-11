using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    public class ScreenSize
    {
        public static Point TopLeftPoint
        {
            get
            {
                return new Point(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y);
            }
        }

        public static int Height
        {
            get
            {
                return SystemInformation.VirtualScreen.Height;
            }
        }

        public static int Width
        {
            get
            {
                return SystemInformation.VirtualScreen.Width;
            }
        }
    }
}