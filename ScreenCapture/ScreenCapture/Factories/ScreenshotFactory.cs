using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ScreenCapture.Factories
{
    public static class ScreenshotFactory
    {
        public static IScreenshotRepository GetRepository()
        {
            var type = Type.GetType(ConfigurationManager.AppSettings["ScreenshotRepositoryType"]);
            return Activator.CreateInstance(type) as IScreenshotRepository;
        }
    }
}
