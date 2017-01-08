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
        public NamedOption Create(NamedOption option)
        {
            throw new NotImplementedException();
        }

        public NamedOption Create(string name, int width, int height, Point sourcePoint, bool isDefault = false)
        {
            throw new NotImplementedException();
        }

        public NamedOption Get(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NamedOption> GetAll()
        {
            throw new NotImplementedException();
        }

        public NamedOption GetDefault()
        {
            throw new NotImplementedException();
        }

        public void SetDefault(NamedOption option)
        {
            throw new NotImplementedException();
        }

        public NamedOption Update(string name, NamedOption option, string newName = null)
        {
            throw new NotImplementedException();
        }

        public NamedOption Update(string name, int width, int height, Point sourcePoint, bool isDefault = false, string newName = null)
        {
            throw new NotImplementedException();
        }
    }
}
