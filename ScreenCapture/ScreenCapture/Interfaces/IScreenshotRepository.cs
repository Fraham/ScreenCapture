using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Interfaces
{
    public interface IScreenshotRepository
    {
        void Save(Image image, ImageFormat imageFormat = null, string fileName = null);

        Image Load(string fileName = null);
    }
}
