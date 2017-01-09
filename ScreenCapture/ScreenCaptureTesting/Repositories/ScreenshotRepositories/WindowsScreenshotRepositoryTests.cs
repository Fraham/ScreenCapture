using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture.Interfaces;
using ScreenCapture.Repositories.ScreenshotRepositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Repositories.ScreenshotRepositories.Tests
{
    [TestClass()]
    public class WindowsScreenshotRepositoryTests
    {
        IScreenshotRepository screenshotRepository = new WindowsScreenshotRepository();

        [TestMethod()]
        public void SaveTest()
        {
            string fileName = "testFile.jpeg";
            screenshotRepository.Save(new Bitmap(20, 20), fileName: fileName);

            Assert.IsNotNull(screenshotRepository.Load(fileName));
        }
    }
}