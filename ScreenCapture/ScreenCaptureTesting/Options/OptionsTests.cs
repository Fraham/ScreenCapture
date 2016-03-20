using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class OptionsTests
    {
        private Options option1;
        [TestInitialize()]
        public void Initialize()
        {
            option1 = new Options(100, 100, new Point(3, 4));
        }

        [TestMethod()]
        public void Width()
        {
            Assert.AreEqual(100, option1.Width);
            Assert.AreNotEqual(200, option1.Width);

            option1.Width = 50;

            Assert.AreEqual(50, option1.Width);
            Assert.AreNotEqual(100, option1.Width);

            option1.Width = -1;

            Assert.AreEqual(1, option1.Width);
            Assert.AreNotEqual(-1, option1.Width);

            option1.Width = 50000000;

            Assert.AreEqual(SystemInformation.VirtualScreen.Width - Math.Abs(option1.SourcePoint.X), option1.Width);
        }

        [TestMethod()]
        public void Height()
        {
            Assert.AreEqual(100, option1.Height);
            Assert.AreNotEqual(200, option1.Height);

            option1.Height = 50;

            Assert.AreEqual(50, option1.Height);
            Assert.AreNotEqual(100, option1.Height);

            option1.Height = -1;

            Assert.AreEqual(1, option1.Height);
            Assert.AreNotEqual(-1, option1.Height);

            option1.Height = 50000000;

            Assert.AreEqual(SystemInformation.VirtualScreen.Height - Math.Abs(option1.SourcePoint.Y), option1.Height);
        }

        [TestMethod()]
        public void SourcePoint()
        {
            Assert.AreEqual(new Point(3, 4), option1.SourcePoint);
            Assert.AreNotEqual(new Point(1, 4), option1.SourcePoint);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadThrowsFileNotFound()
        {
            Options.LoadFromFile("notAFile");
        }


    }
}