using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    [Serializable]
    public class NamedOptions : Options
    {
        private string name;

        private static List<NamedOptions> userNamedOptions = new List<NamedOptions>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public NamedOptions(string name, Options options) : base(options)
        {
            Name = name;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NamedOptions(string name) : base()
        {
            Name = name;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sourcePoint"></param>
        public NamedOptions(string name, int width, int height, Point sourcePoint) : base(width, height, sourcePoint)
        {
            Name = name;
        }

        public NamedOptions() : base()
        {
            Name = null;
        }

        public void AddToList()
        {
            UserNamedOptions.Add(this);
        }

        public static void AddToList(NamedOptions namedOptions)
        {
            UserNamedOptions.Add(namedOptions);
        }

        public void RemoveFromList()
        {
            UserNamedOptions.Remove(this);
        }

        public static void RemoveFromList(NamedOptions namedOptions)
        {
            UserNamedOptions.Remove(namedOptions);
        }

        public static List<NamedOptions> LoadOptionsFromFile()
        {
            return LoadOptionsFromFile("options.xml");
        }

        public static List<NamedOptions> LoadOptionsFromFile(string filename)
        {
            if (!(filename.ToLower().EndsWith(".xml")))
            {
                filename += ".xml";
            }

            if (File.Exists(filename))
            {
                using (var stream = File.OpenRead(filename))
                {
                    var serializer = new XmlSerializer(typeof(List<NamedOptions>));
                    return (List<NamedOptions>)serializer.Deserialize(stream);
                }
            }
            else
            {
                return new List<NamedOptions>();
            }
        }

        public static void SaveOptionsToFile()
        {
            SaveOptionsToFile(UserNamedOptions, "options.xml");
        }

        public static void SaveOptionsToFile(string filename)
        {
            SaveOptionsToFile(UserNamedOptions, filename);
        }

        public static void SaveOptionsToFile(List<NamedOptions> options, string filename)
        {
            if (!(filename.ToLower().EndsWith(".xml")))
            {
                filename += ".xml";
            }

            using (var writer = new StreamWriter(filename))
            {
                var serializer = new XmlSerializer(typeof(List<NamedOptions>));
                serializer.Serialize(writer, options);
                writer.Flush();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = (value == null || value.Equals("")) ? "null" : value;
            }
        }

        public static List<NamedOptions> UserNamedOptions
        {
            get
            {
                return userNamedOptions;
            }

            set
            {
                userNamedOptions = value;
            }
        }

        public override bool Equals(Object obj)
        {
            NamedOptions optionsObj = obj as NamedOptions;
            if (optionsObj == null)
            {
                return false;
            }

            return optionsObj.Height == Height && optionsObj.Width == Width && optionsObj.SourcePoint == SourcePoint && optionsObj.Fullscreen == Fullscreen && optionsObj.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return this.Height + this.Width;
        }
    }
}