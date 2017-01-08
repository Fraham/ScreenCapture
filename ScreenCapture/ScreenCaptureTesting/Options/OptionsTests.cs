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
        private Options.Option option1;
        private Options.Option option2;

        [TestInitialize()]
        public void Initialize()
        {
            option1 = new Options.Option(100, 100, new Point(3, 4));
            option2 = new Options.Option(200, 100, new Point(3, 4));
        }

        [TestMethod()]
        public void OptionsEqual()
        {
            Assert.AreEqual(new Options.Option(100, 100, new Point(3, 4)), option1);
            Assert.AreNotEqual(new Options.Option(100, 100, new Point(3, 4)), option2);
            Assert.AreNotEqual(new Options.Option(100, 100, new Point(3, 4)), null);
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

            option1.SourcePoint = new Point(-999999, -999999);
            Assert.AreEqual(ScreenSize.TopLeftPoint, option1.SourcePoint);

            option1.SourcePoint = new Point(999999, 999999);
            Assert.AreEqual(SystemInformation.VirtualScreen.Right, option1.SourcePoint.X);
            Assert.AreEqual(SystemInformation.VirtualScreen.Bottom, option1.SourcePoint.Y);
        }

        [TestMethod()]
        public void BottomRightCorner()
        {
            option1.SourcePoint = new Point(1, 1);
            option1.Width = 10;
            option1.Height = 10;

            Assert.AreEqual(new Point(11, 11), option1.BottomRightCorner);
            Assert.AreNotEqual(new Point(1, 4), option1.BottomRightCorner);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadThrowsFileNotFound()
        {
            Options.Option.LoadFromFile("notAFile");
        }

        [TestMethod]
        public void Load()
        {
            option1.Save();

            Assert.AreEqual(option1, Options.Option.LoadFromFile());
            Assert.AreNotEqual(option2, Options.Option.LoadFromFile());

            option2.Save();

            Assert.AreEqual(option2, Options.Option.LoadFromFile());
            Assert.AreNotEqual(option1, Options.Option.LoadFromFile());
        }

        [TestMethod]
        public void Save()
        {

        }
    }
}