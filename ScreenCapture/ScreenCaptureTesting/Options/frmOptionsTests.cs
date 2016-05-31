using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void frmOptionsTestLoadControls()
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
        public void frmOptionsTestOkay()
        {
            optionsForm.Okay();
        }
    }
}