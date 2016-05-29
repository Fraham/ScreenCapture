using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreenCapture.Options.Tests
{
    [TestClass()]
    public class NamedOptionsTests
    {
        NamedOptions namedOptions;

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
        }

        [TestMethod()]
        public void NamedOptionsName()
        {

        }
    }
}