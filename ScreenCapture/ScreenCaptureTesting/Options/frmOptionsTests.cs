using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace ScreenCapture.Tests
{
    [TestClass()]
    public class frmOptionsTests
    {

        private frmOptions optionsForm;
        private Options.Options options = new Options.Options();

        [TestInitialize()]
        public void Initialize()
        {
            optionsForm = new frmOptions(options);
        }

        [TestMethod()]
        public void frmOptionsLoadControls()
        {
            optionsForm.Show();

            //Assert.AreEqual(ScreenSize.Width, optionsForm.nudXSourcePoint.Maximum);
            //Assert.AreEqual(ScreenSize.Height, optionsForm.nudYSourcePoint.Maximum);

            Assert.AreEqual(ScreenSize.Width, optionsForm.MaxWidth);
            Assert.AreEqual(ScreenSize.Height, optionsForm.MaxHeight);

            Assert.AreEqual(SystemInformation.MonitorCount + 1, optionsForm.cmbNumberOfScreens.Items.Count);

            optionsForm.Close();
        }

        [TestMethod()]
        public void frmOptionsOkay()
        {
            optionsForm.Okay();
        }

        [TestMethod()]
        public void frmOptionsValidWidth()
        {
            optionsForm.CurrentWidth = 10;
            optionsForm.CurrentX = 10;
            optionsForm.MaxWidth = 20;

            Assert.IsTrue(optionsForm.ValidWidth());

            optionsForm.CurrentWidth = 9;
            optionsForm.CurrentX = 10;
            optionsForm.MaxWidth = 20;

            Assert.IsTrue(optionsForm.ValidWidth());

            optionsForm.CurrentWidth = 0;
            optionsForm.CurrentX = 0;
            optionsForm.MaxWidth = 20;

            Assert.IsTrue(optionsForm.ValidWidth());

            optionsForm.CurrentWidth = 11;
            optionsForm.CurrentX = 10;
            optionsForm.MaxWidth = 20;

            Assert.IsFalse(optionsForm.ValidWidth());
        }

        [TestMethod()]
        public void frmOptionsValidHeight()
        {
            optionsForm.CurrentHeight = 10;
            optionsForm.CurrentY = 10;
            optionsForm.MaxHeight = 20;

            Assert.IsTrue(optionsForm.ValidHeight());

            optionsForm.CurrentHeight = 9;
            optionsForm.CurrentY = 10;
            optionsForm.MaxHeight = 20;

            Assert.IsTrue(optionsForm.ValidHeight());

            optionsForm.CurrentHeight = 0;
            optionsForm.CurrentY = 0;
            optionsForm.MaxHeight = 20;

            Assert.IsTrue(optionsForm.ValidHeight());

            optionsForm.CurrentHeight = 11;
            optionsForm.CurrentY = 10;
            optionsForm.MaxHeight = 20;

            Assert.IsFalse(optionsForm.ValidHeight());
        }
    }
}