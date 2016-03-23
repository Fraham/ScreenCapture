using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class ScreenshotTests
    {
        private Screenshot screenshot1;

        private int captureWidth = 100;
        private int captureHeight = 100;        

        [TestInitialize()]
        public void Initialize()
        {
            screenshot1 = new Screenshot(captureWidth, captureHeight);
        }

        [TestMethod()]
        public void Capture()
        {
            screenshot1.Image = null;
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
    }
}