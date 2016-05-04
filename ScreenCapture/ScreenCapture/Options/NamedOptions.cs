using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    class NamedOptions : Options
    {
        private string name;

        private static ArrayList userNamedOptions;

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
                serializer.Serialize(writer, this);
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
                name = value;
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
