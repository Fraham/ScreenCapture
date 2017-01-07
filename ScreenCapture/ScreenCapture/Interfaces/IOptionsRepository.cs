using ScreenCapture.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Interfaces
{
    public interface IOptionsRepository
    {
        void Create(NamedOptions option);

        void Update(NamedOptions option);

        NamedOptions Get(string name);

        ICollection<NamedOptions> GetAll();
    }
}
