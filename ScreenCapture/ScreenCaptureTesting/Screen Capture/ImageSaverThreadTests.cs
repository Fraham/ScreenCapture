using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            
            ist = new ImageSaverThread(@"C:\Users\Graham\Desktop\test", sh.Image, 1);
        }

        [TestMethod()]
        public void ImageSaverThreadFolderPath()
        {
            Assert.AreEqual(@"C:\Users\Graham\Desktop\test", ist.FolderPath);

            ist.FolderPath = @"C:\Users\Graham\Desktop\test\cheese";

            Assert.AreEqual(@"C:\Users\Graham\Desktop\test\cheese", ist.FolderPath);
        }

        [TestMethod()]
        public void ImageSaverThreadImage()
        {

        }

        [TestMethod()]
        public void ImageSaverThreadFrameNumber()
        {
            Assert.AreEqual(1, ist.FrameNumber);

            ist.FrameNumber = 2;

            Assert.AreEqual(2, ist.FrameNumber);

            try
            {
                ist.FrameNumber = -1;

                Assert.Fail("Should throw an Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Frame number has to be greater than zero", ae.Message);
            }
        }
    }
}