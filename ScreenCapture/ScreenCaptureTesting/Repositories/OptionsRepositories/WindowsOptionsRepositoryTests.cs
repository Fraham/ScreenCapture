﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void OptionsRepositoriesInitialize()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        [TestMethod()]
        public void OptionsRepositoriesCreateTestNamedOption_SimpleOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption());

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void OptionsRepositoriesCreateTestNamedOption_NameOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese"));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void OptionsRepositoriesCreateTestNamedOption_NameWithBasicOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese", new Option()));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void OptionsRepositoriesCreateTestNamedOption_NameWithDefinedOption_Success()
        {
            var option = optionsRepository.Create(new NamedOption("Cheese", new Option(10, 10, new Point())));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void OptionsRepositoriesCreateTestNamedOption_NameWithDefinedOptionFileExists_Success()
        {
            var list = new List<NamedOption>();
            list.Add(new NamedOption());
            Save(list);

            var option = optionsRepository.Create(new NamedOption("Cheese", new Option(10, 10, new Point())));

            List<NamedOption> options = LoadFile().ToList<NamedOption>();

            Assert.IsNotNull(options);
            Assert.AreEqual(2, options.Count);
            Assert.AreEqual(option, options[1]);
        }

        [TestMethod()]
        public void OptionsRepositoriesGetDefault()
        {
            var option1 = optionsRepository.Create(new NamedOption("Option 1", isDefault: true));

            Assert.AreEqual(option1, optionsRepository.GetDefault());

            var option2 = optionsRepository.Create(new NamedOption("Option 2", isDefault: false));

            Assert.AreEqual(option1, optionsRepository.GetDefault());

            var option3 = optionsRepository.Create(new NamedOption("Option 3", isDefault: true));

            Assert.AreEqual(option3, optionsRepository.GetDefault());
        }

        [TestMethod()]
        public void OptionsRepositoriesSetDefault()
        {
            var option1 = optionsRepository.Create(new NamedOption("Option 1", isDefault: true));

            Assert.AreEqual(option1, optionsRepository.GetDefault());

            var option2 = optionsRepository.Create(new NamedOption("Option 2", isDefault: true));

            Assert.AreEqual(option2, optionsRepository.GetDefault());

            optionsRepository.SetDefault(option1);
            Assert.AreEqual(option1, optionsRepository.GetDefault());

            var option3 = optionsRepository.Create(new NamedOption("Option 3", isDefault: true));

            Assert.AreEqual(option3, optionsRepository.GetDefault());

            optionsRepository.SetDefault(option1);
            Assert.AreEqual(option1, optionsRepository.GetDefault());
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_WidthChange_Success()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            optionsRepository.Update(optionName, width: 20);

            Assert.AreEqual(20, optionsRepository.Get(optionName).Width);
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_HeightChange_Success()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            optionsRepository.Update(optionName, height: 20);

            Assert.AreEqual(20, optionsRepository.Get(optionName).Height);
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_SourcePointChange_Success()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            optionsRepository.Update(optionName, sourcePoint: new Point(30, 30));

            Assert.AreEqual(new Point(30, 30), optionsRepository.Get(optionName).SourcePoint);
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_NameChange_Success()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            const string newName = "NewName";
            optionsRepository.Update(optionName, newName: newName);

            Assert.IsNotNull(optionsRepository.Get(newName));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void OptionsRepositoriesUpdate_OptionNotSetUp_Failure()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            const string newName = "NewName";
            optionsRepository.Update(newName, newName: newName);
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_SetDefault_Success()
        {
            string optionName = "Option 1";
            optionsRepository.Create(new NamedOption(optionName));

            var option = optionsRepository.Update(optionName, isDefault: true);

            Assert.AreEqual(option, optionsRepository.GetDefault());
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_HeightChangeNamedOption_Success()
        {
            string optionName = "Option 1";
            var option = optionsRepository.Create(new NamedOption(optionName));
            option.Height = 20;

            optionsRepository.Update(optionName, option);

            Assert.AreEqual(20, optionsRepository.Get(optionName).Height);
        }

        [TestMethod()]
        public void OptionsRepositoriesUpdate_GetAll_Success()
        {
            var list = optionsRepository.GetAll();

            Assert.AreEqual(1, list.Count());
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

        private void Save(IEnumerable<NamedOption> options)
        {
            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(List<NamedOption>));
                serializer.Serialize(writer, options);
                writer.Flush();
            }
        }

        [TestCleanup]
        public void OptionsRepositoriesTestCleanup()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}