using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenCapture.Options;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ScreenCapture.Repositories.OptionsRepositories
{
    public class WindowsOptionsRepository : IOptionsRepository
    {
        private ICollection<NamedOption> options = new List<NamedOption>();
        private string fileName = "userOptions.xml";

        public NamedOption Create(NamedOption option)
        {
            return Create(option.Name, option.Width, option.Height, option.SourcePoint, option.IsDefault);
        }

        public NamedOption Create(string name, int width, int height, Point sourcePoint, bool isDefault = false)
        {
            var option = new NamedOption(name, width, height, sourcePoint, isDefault);

            if (isDefault)
            {
                SetDefault(option);
            }

            Options.Add(option);

            Save();

            return option;
        }

        public NamedOption Get(string name)
        {
            return Options.First(op => op.Name == name);
        }

        public IEnumerable<NamedOption> GetAll()
        {
            return Options;
        }

        public NamedOption Update(string name, NamedOption option, string newName = null)
        {
            return Update(name, option.Width, option.Height, option.SourcePoint, option.IsDefault);
        }

        public NamedOption Update(string name, int width, int height, Point sourcePoint, bool isDefault = false, string newName = null)
        {
            var option = Get(name);

            if (option == null)
            {
                throw new Exception($"Could not find a matching option for the name provided: {name}");
            }

            if (isDefault)
            {
                SetDefault(option);
            }

            option.Width = width;
            option.Height = height;
            option.SourcePoint = sourcePoint;

            if (!string.IsNullOrEmpty(newName))
            {
                option.Name = newName;
            }

            Save();

            return option;
        }

        public void SetDefault(NamedOption option)
        {
            GetDefault().IsDefault = false;
            option.IsDefault = true;

            Save();
        }

        public NamedOption GetDefault()
        {
            return Options.First(op => op.IsDefault == true);
        }

        private ICollection<NamedOption> Load()
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
                var newList = new List<NamedOption>();
                newList.Add(new NamedOption("Default", isDefault: true));
                Save(newList);
                return newList;
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

        private void Save()
        {
            Save(Options);
        }

        #region Properties

        private ICollection<NamedOption> Options
        {
            get
            {
                if (options == null || options.Count == 0)
                {
                    Options = Load();
                }

                return options;
            }
            set
            {
                options = value;
            }
        }

        #endregion
    }
}
