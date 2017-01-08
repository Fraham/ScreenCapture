using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenCapture.Interfaces;
using ScreenCapture.Options;

namespace ScreenCapture.Repositories.OptionsRepositories
{
    public class FakeOptionsRepository : IOptionsRepository
    {
        private ICollection<NamedOption> options = new List<NamedOption>();

        public NamedOption Create(NamedOption option)
        {
            if (option.IsDefault)
            {
                SetDefault(option);
            }

            Options.Add(option);

            return option;
        }

        public NamedOption Create(string name, int width, int height, Point sourcePoint, bool isDefault = false)
        {
            var option = new NamedOption(name, width, height, sourcePoint, isDefault);

            if (isDefault)
            {
                SetDefault(option);
            }

            Options.Add(option);

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

        public NamedOption GetDefault()
        {
            return Options.First(op => op.IsDefault);
        }

        public void SetDefault(NamedOption option)
        {
            GetDefault().IsDefault = false;
            option.IsDefault = true;
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

            return option;
        }

        private ICollection<NamedOption> CreateData()
        {
            var options = new List<NamedOption>();

            options.Add(new NamedOption());
            options.Add(new NamedOption());

            return options;
        }

        #region Properties

        private ICollection<NamedOption> Options
        {
            get
            {
                if (options == null || options.Count == 0)
                {
                    Options = CreateData();
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
