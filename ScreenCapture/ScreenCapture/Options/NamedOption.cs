using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    [Serializable]
    public class NamedOption : Option
    {
        private string name;
        private bool isDefault;

        //private static List<NamedOption> userNamedOptions = new List<NamedOption>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public NamedOption(string name, Option options, bool isDefault = false) : base(options)
        {
            Name = name;
            IsDefault = isDefault;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public NamedOption(string name, bool isDefault = false) : base()
        {
            Name = name;
            IsDefault = isDefault;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sourcePoint"></param>
        public NamedOption(string name, int width, int height, Point sourcePoint, bool isDefault = false) : base(width, height, sourcePoint)
        {
            Name = name;
            IsDefault = isDefault;
        }

        public NamedOption() : base()
        {
            Name = null;
        }

        //public void AddToList()
        //{
        //    UserNamedOptions.Add(this);
        //}

        //public static void AddToList(NamedOption namedOptions)
        //{
        //    UserNamedOptions.Add(namedOptions);
        //}

        //public void RemoveFromList()
        //{
        //    UserNamedOptions.Remove(this);
        //}

        //public static void RemoveFromList(NamedOption namedOptions)
        //{
        //    UserNamedOptions.Remove(namedOptions);
        //}

        //public static List<NamedOption> LoadOptionsFromFile()
        //{
        //    return LoadOptionsFromFile("options.xml");
        //}

        //public static List<NamedOption> LoadOptionsFromFile(string filename)
        //{
        //    if (!(filename.ToLower().EndsWith(".xml")))
        //    {
        //        filename += ".xml";
        //    }

        //    if (File.Exists(filename))
        //    {
        //        using (var stream = File.OpenRead(filename))
        //        {
        //            var serializer = new XmlSerializer(typeof(List<NamedOption>));
        //            return (List<NamedOption>)serializer.Deserialize(stream);
        //        }
        //    }
        //    else
        //    {
        //        return new List<NamedOption>();
        //    }
        //}

        //public static void SaveOptionsToFile()
        //{
        //    SaveOptionsToFile(UserNamedOptions, "options.xml");
        //}

        //public static void SaveOptionsToFile(string filename)
        //{
        //    SaveOptionsToFile(UserNamedOptions, filename);
        //}

        //public static void SaveOptionsToFile(List<NamedOption> options, string filename)
        //{
        //    if (!(filename.ToLower().EndsWith(".xml")))
        //    {
        //        filename += ".xml";
        //    }

        //    using (var writer = new StreamWriter(filename))
        //    {
        //        var serializer = new XmlSerializer(typeof(List<NamedOption>));
        //        serializer.Serialize(writer, options);
        //        writer.Flush();
        //    }
        //}

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

        public bool IsDefault
        {
            get
            {
                return isDefault;
            }
            set
            {
                isDefault = value;
            }
        }

        //public static List<NamedOption> UserNamedOptions
        //{
        //    get
        //    {
        //        return userNamedOptions;
        //    }

        //    set
        //    {
        //        userNamedOptions = value;
        //    }
        //}

        public override bool Equals(Object obj)
        {
            NamedOption optionsObj = obj as NamedOption;
            if (optionsObj == null)
            {
                return false;
            }

            return optionsObj.Height == Height && optionsObj.Width == Width && optionsObj.SourcePoint == SourcePoint && optionsObj.Fullscreen == Fullscreen && optionsObj.Name.Equals(Name) && IsDefault == optionsObj.isDefault;
        }

        public override int GetHashCode()
        {
            return this.Height + this.Width;
        }
    }
}