using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Factories
{
    public static class OptionsFactory
    {
        public static IOptionsRepository GetRepository()
        {
            var type = Type.GetType(ConfigurationManager.AppSettings["OptionsRepositoryType"]);
            return Activator.CreateInstance(type) as IOptionsRepository;
        }
    }
}
