using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenCapture.Repositories
{
    public class FakeScreenshotRepository : IScreenshotRepository
    {
        private Dictionary<string, Image> images = new Dictionary<string, Image>();

        public Image Load(string fileName = null)
        {
            if (fileName == null)
            {
                throw new ArgumentException("File name can not be null");
            }

            Image returnedImage;
            images.TryGetValue(fileName, out returnedImage);
            return returnedImage;
        }

        public void Save(Image image, ImageFormat _imageFormat = null, string _fileName = null)
        {
            var imageFormat = _imageFormat ?? ImageFormat.Jpeg;

            var fileName = _fileName ?? image.ToString() + imageFormat.ToString();

            images.Add(fileName, image);
        }
    }
}
