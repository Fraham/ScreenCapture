using ScreenCapture.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Interfaces
{
    public interface IOptionsRepository
    {
        NamedOption Create(NamedOption option);

        NamedOption Create(string name, int width, int height, Point sourcePoint, bool isDefault);

        NamedOption Update(string name, NamedOption option, string newName = null);

        NamedOption Update(string name, int width = 0, int height = 0, Point sourcePoint = default(Point), bool isDefault = false, string newName = null);

        NamedOption Get(string name);

        IEnumerable<NamedOption> GetAll();

        void SetDefault(NamedOption option);

        NamedOption GetDefault();
    }
}
