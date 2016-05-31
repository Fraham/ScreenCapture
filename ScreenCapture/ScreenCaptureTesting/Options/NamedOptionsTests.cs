﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace ScreenCapture.Options.Tests
{
    [TestClass()]
    public class NamedOptionsTests
    {
        private NamedOptions namedOptions;

        [TestInitialize()]
        public void Initialize()
        {
            namedOptions = new NamedOptions("Name");
        }

        [TestMethod()]
        public void NamedOptionsConstructors()
        {
            NamedOptions namedOptions1 = new NamedOptions("Name");

            Assert.AreEqual("Name", namedOptions1.Name);
            Assert.AreEqual(ScreenSize.Width, namedOptions1.Width);
            Assert.AreEqual(ScreenSize.Height, namedOptions1.Height);
            Assert.AreEqual(ScreenSize.TopLeftPoint, namedOptions1.SourcePoint);

            NamedOptions namedOptions2 = new NamedOptions("Name", new Options(10, 20, new System.Drawing.Point(1, 2)));

            Assert.AreEqual("Name", namedOptions2.Name);
            Assert.AreEqual(10, namedOptions2.Width);
            Assert.AreEqual(20, namedOptions2.Height);
            Assert.AreEqual(new System.Drawing.Point(1, 2), namedOptions2.SourcePoint);

            NamedOptions namedOptions3 = new NamedOptions("Name", 10, 20, new System.Drawing.Point(1, 2));

            Assert.AreEqual("Name", namedOptions3.Name);
            Assert.AreEqual(10, namedOptions3.Width);
            Assert.AreEqual(20, namedOptions3.Height);
            Assert.AreEqual(new System.Drawing.Point(1, 2), namedOptions3.SourcePoint);

            NamedOptions namedOptions4 = new NamedOptions();

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

        [TestMethod()]
        public void NamedOptionsArrayList()
        {
            Assert.AreEqual(0, NamedOptions.UserNamedOptions.Count);

            namedOptions.AddToList();

            Assert.AreEqual(1, NamedOptions.UserNamedOptions.Count);

            NamedOptions namedOptions2 = new NamedOptions("Name2");

            NamedOptions.AddToList(namedOptions2);

            Assert.AreEqual(2, NamedOptions.UserNamedOptions.Count);

            namedOptions.RemoveFromList();

            Assert.AreEqual(1, NamedOptions.UserNamedOptions.Count);

            NamedOptions.RemoveFromList(namedOptions2);

            Assert.AreEqual(0, NamedOptions.UserNamedOptions.Count);
        }

        [TestMethod()]
        public void NamedOptionsLoading()
        {
            namedOptions.AddToList();

            NamedOptions.SaveOptionsToFile();

            namedOptions.RemoveFromList();

            NamedOptions.UserNamedOptions = NamedOptions.LoadOptionsFromFile();

            Assert.AreEqual(0, NamedOptions.UserNamedOptions.IndexOf(namedOptions));

            NamedOptions.UserNamedOptions = NamedOptions.LoadOptionsFromFile("options");

            Assert.AreEqual(0, NamedOptions.UserNamedOptions.IndexOf(namedOptions));

            NamedOptions.UserNamedOptions = NamedOptions.LoadOptionsFromFile("nonFile");

            Assert.AreEqual(0, NamedOptions.UserNamedOptions.Count);

            Assert.AreNotEqual(new List<NamedOptions>(), NamedOptions.UserNamedOptions);

            Assert.AreNotEqual(null, NamedOptions.UserNamedOptions);
        }

        [TestMethod()]
        public void NamedOptionsSaving()
        {
            namedOptions.AddToList();

            NamedOptions.SaveOptionsToFile();

            NamedOptions.SaveOptionsToFile("cheese");
        }
    }
}