using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
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
            option1 = new Options(100,100, new Point(3,4));
        }

        [TestMethod()]
        public void OptionsWidth()
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
        public void OptionsTest1()
        {

        }

        [TestMethod()]
        public void SaveTest()
        {

        }

        [TestMethod()]
        public void SaveTest1()
        {

        }

        [TestMethod()]
        public void LoadFromFileTest()
        {

        }

        [TestMethod()]
        public void OptionsTest2()
        {

        }

        [TestMethod()]
        public void OptionsTest3()
        {

        }

        [TestMethod()]
        public void SaveTest2()
        {

        }

        [TestMethod()]
        public void SaveTest3()
        {

        }

        [TestMethod()]
        public void LoadFromFileTest1()
        {

        }
    }
}