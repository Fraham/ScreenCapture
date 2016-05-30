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

        public NamedOptions(string name, Options options) : base(options)
        {
            Name = name;
        }

        public NamedOptions(string name) : base()
        {
            Name = name;
        }

        public NamedOptions(string name, int width, int height, Point sourcePoint) : base(width, height, sourcePoint)
        {
            Name = name;
        }

        public void addToList()
        {
            UserNamedOptions.Add(this);
        }

        public static void addToList(NamedOptions namedOptions)
        {
            UserNamedOptions.Add(namedOptions);
        }

        public void removeFromList()
        {
            UserNamedOptions.Remove(this);
        }

        public static void removeFromList(NamedOptions namedOptions)
        {
            UserNamedOptions.Remove(namedOptions);
        }

        public ArrayList loadOptionsFromFile()
        {
            return loadOptionsFromFile("options.xml");
        }

        public ArrayList loadOptionsFromFile(String filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var obj = new Options();
                var serializer = new XmlSerializer(obj.GetType());
                return (ArrayList)serializer.Deserialize(stream);
            }
        }

        public void saveOptionsToFile()
        {
            saveOptionsToFile(UserNamedOptions, "options.xml");
        }

        public void saveOptionsToFile(ArrayList options, string filename)
        {
            if (!(filename.ToLower().EndsWith(".xml")))
            {
                filename += ".xml";
            }

            using (var writer = new StreamWriter(filename))
            {
                var serializer = new XmlSerializer(GetType());
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