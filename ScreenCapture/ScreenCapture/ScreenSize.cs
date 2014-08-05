using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapture
{
    class ScreenSize
    {
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
    }
}
