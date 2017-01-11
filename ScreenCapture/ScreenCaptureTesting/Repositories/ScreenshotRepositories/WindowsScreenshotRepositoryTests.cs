using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture.Interfaces;
using ScreenCapture.Repositories.ScreenshotRepositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Repositories.ScreenshotRepositories.Tests
{
    [TestClass()]
    public class WindowsScreenshotRepositoryTests
    {
        IScreenshotRepository screenshotRepository = new WindowsScreenshotRepository();

        Bitmap image = new Bitmap(20, 20);

        [TestMethod()]
        public void WindowsScreenshotRepositoryTest_Save_Simple_Success()
        {
            string fileName = "testFile.jpeg";
            screenshotRepository.Save(image, fileName: fileName);

            var loadedImage = screenshotRepository.Load(fileName);
            Assert.IsNotNull(loadedImage);
            loadedImage.Dispose();
        }

        [TestMethod()]
        public void WindowsScreenshotRepositoryTest_Save_NoFileExtension_Success()
        {
            string fileName = "testFile1";
            screenshotRepository.Save(image, fileName: fileName);

            var loadedImage = screenshotRepository.Load(fileName + ".jpeg");
            Assert.IsNotNull(loadedImage);
            loadedImage.Dispose();
        }

        [TestMethod()]
        public void WindowsScreenshotRepositoryTest_Load_NoFile_Failure()
        {
            string fileName = "testFile2.jpeg";

            Assert.IsNull(screenshotRepository.Load(fileName));
        }

        [TestCleanup]
        public void OptionsRepositoriesTestCleanup()
        {
            var somethingElse = new string[]{ "testFile.jpeg", "testFile1.jpeg" };

            foreach (var fileName in somethingElse)
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }
    }
}