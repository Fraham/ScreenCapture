using ScreenCapture.Interfaces;
using System;
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
