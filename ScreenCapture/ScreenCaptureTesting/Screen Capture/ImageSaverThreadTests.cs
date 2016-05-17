using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class ImageSaverThreadTests
    {

        private ImageSaverThread ist;

        [TestInitialize()]
        public void Initialize()
        {
            Screenshot sh = new Screenshot(100, 100);
            sh.Capture();
            
            ist = new ImageSaverThread(@"C:\\", sh.Image, 1);
        }

        [TestMethod()]
        public void ImageSaverThreadFolderPath()
        {
            
        }

        [TestMethod()]
        public void ImageSaverThreadImage()
        {

        }

        [TestMethod()]
        public void ImageSaverThreadFrameNumber()
        {

        }
    }
}