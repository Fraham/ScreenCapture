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
    public class frmUserCaptureAreaTests
    {
        private frmUserCaptureArea captureArea;

        [TestInitialize()]
        public void Initialize()
        {
            captureArea = new frmUserCaptureArea(new Options.Option(100, 100, new Point(3, 4)), false);
        }

        [TestMethod()]
        public void SetClickAction()
        {
            //captureArea.SetClickAction(frmUserCaptureArea.CursPos.BottomLine);
        }

        [TestMethod()]
        public void CaptureOptions()
        {
            Assert.AreEqual(new Options.Option(100, 100, new Point(3, 4)), captureArea.CaptureOptions);

            captureArea.CaptureOptions = new Options.Option(101, 110, new Point(4, 6));

            Assert.AreNotEqual(new Options.Option(100, 100, new Point(3, 4)), captureArea.CaptureOptions);

            Assert.AreEqual(new Options.Option(101, 110, new Point(4, 6)), captureArea.CaptureOptions);
        }
    }
}