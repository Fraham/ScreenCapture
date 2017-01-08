using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenCapture.Interfaces;
using ScreenCapture.Options;
using ScreenCapture.Repositories.OptionsRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace ScreenCapture.Repositories.OptionsRepositories.Tests
{
    [TestClass()]
    public class WindowsOptionsRepositoryTests
    {
        private IOptionsRepository optionsRepository = new WindowsOptionsRepository();
        private string fileName = "userOptions.xml";

        [TestInitialize()]
        public void Initialize()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        [TestMethod()]
        public void CreateTestNamedOption_SimpleOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption());

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void CreateTestNamedOption_NameOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese"));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void CreateTestNamedOption_NameWithBasicOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese", new Option()));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void CreateTestNamedOption_NameWithDefinedOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese", new Option(10, 10, new Point())));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void CreateTest1()
        {

        }

        private ICollection<NamedOption> LoadFile()
        {
            if (File.Exists(fileName))
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var serializer = new XmlSerializer(typeof(List<NamedOption>));
                    return (List<NamedOption>)serializer.Deserialize(stream);
                }
            }
            else
            {
                Assert.Fail($"{fileName} has not been created");
                return null;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}