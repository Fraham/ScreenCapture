using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class frmScreenshotTests
    {
        private frmScreenshot frms;
        private Screenshot screenshot;

        [TestInitialize()]
        public void Initialize()
        {
            screenshot = new Screenshot(100, 100, new System.Drawing.Point(0, 0));
            screenshot.Capture();

            frms = new frmScreenshot(screenshot);
        }

        [TestMethod()]
        public void frmScreenshotConstructor()
        {
            Assert.IsNotNull(frms.Shot);            
        }
    }
}