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
    public class frmScreenCaptureTests
    {
        private frmScreenCapture capture;

        [TestInitialize()]
        public void Initialize()
        {
            capture = new frmScreenCapture();
            capture.TakeScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestLoadOptions()
        {
            capture.LoadOptions();
        }

        [TestMethod()]
        public void frmScreenCaptureTestSaveOptions()
        {
            capture.SaveOptions();
        }

        [TestMethod()]
        public void frmScreenCaptureTestClose()
        {
            capture.Close();
        }

        [TestMethod()]
        public void frmScreenCaptureTestCopy()
        {
            capture.CopyScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestSave()
        {
            //capture.SaveScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestTake()
        {
            capture.TakeScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestOpenOptionsForm()
        {
            //capture.OpenOptionsForm();
        }
    }
}