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
        public void Image()
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
        public void Capture()
        {
            screenshot1.Capture();

            Assert.IsNotNull(screenshot1.Image);

            Assert.AreEqual(captureWidth, screenshot1.Image.Width);

            Assert.AreEqual(captureHeight, screenshot1.Image.Height);
        }

        [TestMethod()]
        public void Copy()
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
        public void Constructors()
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

            screenshot1 = new Screenshot(new Options.Options(captureWidth, captureHeight, captureSourcePoint));

            Assert.AreEqual(captureWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(captureHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(captureSourcePoint, screenshot1.CaptureOptions.SourcePoint);

            //----------------------------------

            screenshot1 = new Screenshot(new Options.Options(testWidth, testHeight, testPoint));

            Assert.AreEqual(testWidth, screenshot1.CaptureOptions.Width);

            Assert.AreEqual(testHeight, screenshot1.CaptureOptions.Height);

            Assert.AreEqual(testPoint, screenshot1.CaptureOptions.SourcePoint);
        }

        [TestMethod()]
        public void Save()
        {
            string filename = "test.jpeg";

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            screenshot1.Capture();

            screenshot1.Save("test.jpeg");

            Assert.IsTrue(File.Exists(filename));
        }

        [TestMethod()]
        public void Print()
        {
            /*screenshot1.Capture();

            screenshot1.Print();*/
        }

    }
}