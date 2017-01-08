using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace ScreenCapture.Options.Tests
{
    [TestClass()]
    public class NamedOptionsTests
    {
        private NamedOption namedOptions;

        [TestInitialize()]
        public void Initialize()
        {
            namedOptions = new NamedOption("Name");
        }

        [TestMethod()]
        public void NamedOptionsConstructors()
        {
            NamedOption namedOptions1 = new NamedOption("Name");

            Assert.AreEqual("Name", namedOptions1.Name);
            Assert.AreEqual(ScreenSize.Width, namedOptions1.Width);
            Assert.AreEqual(ScreenSize.Height, namedOptions1.Height);
            Assert.AreEqual(ScreenSize.TopLeftPoint, namedOptions1.SourcePoint);

            NamedOption namedOptions2 = new NamedOption("Name", new Option(10, 20, new System.Drawing.Point(1, 2)));

            Assert.AreEqual("Name", namedOptions2.Name);
            Assert.AreEqual(10, namedOptions2.Width);
            Assert.AreEqual(20, namedOptions2.Height);
            Assert.AreEqual(new System.Drawing.Point(1, 2), namedOptions2.SourcePoint);

            NamedOption namedOptions3 = new NamedOption("Name", 10, 20, new System.Drawing.Point(1, 2));

            Assert.AreEqual("Name", namedOptions3.Name);
            Assert.AreEqual(10, namedOptions3.Width);
            Assert.AreEqual(20, namedOptions3.Height);
            Assert.AreEqual(new System.Drawing.Point(1, 2), namedOptions3.SourcePoint);

            NamedOption namedOptions4 = new NamedOption();

            Assert.AreEqual("null", namedOptions4.Name);
            Assert.AreEqual(ScreenSize.Width, namedOptions4.Width);
            Assert.AreEqual(ScreenSize.Height, namedOptions4.Height);
            Assert.AreEqual(ScreenSize.TopLeftPoint, namedOptions4.SourcePoint);
        }

        [TestMethod()]
        public void NamedOptionsName()
        {
            Assert.AreEqual("Name", namedOptions.Name);

            namedOptions.Name = "";

            Assert.AreEqual("null", namedOptions.Name);

            namedOptions.Name = null;

            Assert.AreEqual("null", namedOptions.Name);
        }

        //[TestMethod()]
        //public void NamedOptionsArrayList()
        //{
        //    Assert.AreEqual(0, NamedOption.UserNamedOptions.Count);

        //    namedOptions.AddToList();

        //    Assert.AreEqual(1, NamedOption.UserNamedOptions.Count);

        //    NamedOption namedOptions2 = new NamedOption("Name2");

        //    NamedOption.AddToList(namedOptions2);

        //    Assert.AreEqual(2, NamedOption.UserNamedOptions.Count);

        //    namedOptions.RemoveFromList();

        //    Assert.AreEqual(1, NamedOption.UserNamedOptions.Count);

        //    NamedOption.RemoveFromList(namedOptions2);

        //    Assert.AreEqual(0, NamedOption.UserNamedOptions.Count);
        //}

        //[TestMethod()]
        //public void NamedOptionsLoading()
        //{
        //    namedOptions.AddToList();

        //    NamedOption.SaveOptionsToFile();

        //    namedOptions.RemoveFromList();

        //    NamedOption.UserNamedOptions = NamedOption.LoadOptionsFromFile();

        //    Assert.AreEqual(0, NamedOption.UserNamedOptions.IndexOf(namedOptions));

        //    NamedOption.UserNamedOptions = NamedOption.LoadOptionsFromFile("options");

        //    Assert.AreEqual(0, NamedOption.UserNamedOptions.IndexOf(namedOptions));

        //    NamedOption.UserNamedOptions = NamedOption.LoadOptionsFromFile("nonFile");

        //    Assert.AreEqual(0, NamedOption.UserNamedOptions.Count);

        //    Assert.AreNotEqual(new List<NamedOption>(), NamedOption.UserNamedOptions);

        //    Assert.AreNotEqual(null, NamedOption.UserNamedOptions);
        //}

        //[TestMethod()]
        //public void NamedOptionsSaving()
        //{
        //    namedOptions.AddToList();

        //    NamedOption.SaveOptionsToFile();

        //    NamedOption.SaveOptionsToFile("cheese");
        //}
    }
}