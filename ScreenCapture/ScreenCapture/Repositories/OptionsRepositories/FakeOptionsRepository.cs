using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenCapture.Interfaces;
using ScreenCapture.Options;

namespace ScreenCapture.Repositories.OptionsRepositories
{
    public class FakeOptionsRepository : IOptionsRepository
    {
        public void Create(NamedOptions option)
        {
            throw new NotImplementedException();
        }

        public NamedOptions Get(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<NamedOptions> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(NamedOptions option)
        {
            throw new NotImplementedException();
        }
    }
}
