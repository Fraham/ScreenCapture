using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    public class NamedOptions : Options
    {
        private string name;

        private static ArrayList userNamedOptions = new ArrayList();

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

        public static ArrayList LoadOptionsFromFile()
        {
            return LoadOptionsFromFile("options.xml");
        }

        public static ArrayList LoadOptionsFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                using (var stream = File.OpenRead(filename))
                {
                    var obj = new Options();
                    var serializer = new XmlSerializer(obj.GetType());
                    return (ArrayList)serializer.Deserialize(stream);
                }
            }
            else
            {
                return new ArrayList();
            }
        }

        public static void SaveOptionsToFile()
        {
            SaveOptionsToFile(UserNamedOptions, "options.xml");
        }

        public static void SaveOptionsToFile(ArrayList options, string filename)
        {
            if (!(filename.ToLower().EndsWith(".xml")))
            {
                filename += ".xml";
            }

            using (var writer = new StreamWriter(filename))
            {
                var serializer = new XmlSerializer(options.GetType());
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

        public static ArrayList UserNamedOptions
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
    }
}