using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;
using ScreenCapture.Options;
using System.IO;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class ScreenshotTests
    {
        private Screenshot screenshot1;

        private int captureWidth = 100;
        private int captureHeight = 100;
        private Point captureSourcePoint = new Point(0, 0);

        [TestInitialize()]
        public void Initialize()
        {
            screenshot1 = new Screenshot(captureWidth, captureHeight, captureSourcePoint);
        }

        [TestMethod()]
        public void SceenshotImage()
        {
            try
            {
                screenshot1.Image = null;
                Assert.Fail("Should Error as image is null.");
            }
            catch
            {

            }
        }

        [TestMethod()]
        public void SceenshotCapture()
        {
            screenshot1.Capture();

            Assert.IsNotNull(screenshot1.Image);

            Assert.AreEqual(captureWidth, screenshot1.Image.Width);

            Assert.AreEqual(captureHeight, screenshot1.Image.Height);
        }

        [TestMethod()]
        public void SceenshotCopy()
        {
            screenshot1.Capture();

            screenshot1.Copy();

            Assert.AreEqual(screenshot1.Image.Height, Clipboard.GetImage().Height);

            Assert.AreEqual(screenshot1.Image.Width, Clipboard.GetImage().Width);

            Assert.AreEqual(screenshot1.Image.Size, Clipboard.GetImage().Size);

            Assert.AreEqual(captureHeight, Clipboard.GetImage().Height);

            Assert.AreEqual(captureWidth, Clipboard.GetImage().Width);
        }

        [TestMethod()]
        public void SceenshotConstructors()
        {
            Point testPoint = new Point(10, 30);
            int testWidth = 120;
            int testHeight = 140;

            //----------------------------------

            screenshot1 = new Screenshot(captureWidth, captureHeight, captureSourcePoint);

            Assert.AreEqual(captureWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(captureHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(captureSourcePoint, screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(testWidth, testHeight, testPoint);

            Assert.AreEqual(testWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(testHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(testPoint, screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(captureWidth, captureHeight);

            Assert.AreEqual(captureWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(captureHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(new Point(0, 0), screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(testWidth, testHeight);

            Assert.AreEqual(testWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(testHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(new Point(0, 0), screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(new Options.Option(captureWidth, captureHeight, captureSourcePoint));

            Assert.AreEqual(captureWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(captureHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(captureSourcePoint, screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(new Options.Option(testWidth, testHeight, testPoint));

            Assert.AreEqual(testWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(testHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(testPoint, screenshot1.CaptureOptions.SourcePoint);

            Screenshot screenshot2 = new Screenshot(screenshot1.Capture());
        }

        [TestMethod()]
        public void SceenshotSave()
        {
            string filename = "test.jpeg";

            screenshot1.Capture();

            screenshot1.Save(filename);

            Assert.AreEqual(screenshot1.Image, screenshot1.Load(filename));

            string filename2 = "testing";

            screenshot1.Save(filename2);

            Assert.AreEqual(screenshot1.Image, screenshot1.Load(filename));
        }

        [TestMethod()]
        public void SceenshotPrint()
        {
            /*screenshot1.Capture();

            screenshot1.Print();*/
        }

    }
}