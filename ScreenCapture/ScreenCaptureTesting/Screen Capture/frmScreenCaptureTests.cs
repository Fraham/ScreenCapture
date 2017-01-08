using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }

        [TestMethod()]
        public void frmScreenCaptureTestLoadOptions()
        {
            capture.LoadOptions();
        }

        [TestMethod()]
        public void frmScreenCaptureTestSaveOptions()
        {
            //capture.SaveOptions();
        }

        [TestMethod()]
        public void frmScreenCaptureTestClose()
        {
            capture.Close();
        }

        [TestMethod()]
        public void frmScreenCaptureTestCopy()
        {
            //capture.TakeScreenshot();
            //capture.CopyScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestSave()
        {
            //capture.SaveScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestTake()
        {
            //capture.TakeScreenshot();
        }

        [TestMethod()]
        public void frmScreenCaptureTestOpenOptionsForm()
        {
            //capture.OpenOptionsForm();
        }
    }
}