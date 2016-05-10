using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenCapture.Options
{
    public class Options
    {
        #region Class Variables

        private bool fullscreen;
        private int height;
        private Point sourcePoint;
        private int width;

        #endregion Class Variables

        #region Constructors

        /// <summary>
        /// Making a new instance of the options class.
        /// This will store the users options for the capture.
        /// </summary>
        public Options()
        {
            Width = ScreenSize.Width;
            Height = ScreenSize.Height;
            SourcePoint = ScreenSize.TopLeftPoint;
            Fullscreen = true;
        }

        /// <summary>
        /// Making a new instance of the options class.
        /// This will store the users options for the capture.
        /// </summary>
        public Options(Options options)
        {
            Width = options.Width;
            Height = options.Height;
            SourcePoint = options.SourcePoint;
            Fullscreen = options.Fullscreen;
        }

        /// <summary>
        /// Making a new instance of the options class.
        /// This will store the users options for the capture.
        /// </summary>
        /// <param name="width">The width of the capture area.</param>
        /// <param name="height">The height of the capture area.</param>
        /// <param name="sourcePoint">The source point of the capture.</param>
        public Options(int width, int height, Point sourcePoint)
        {
            Width = width;
            Height = height;
            SourcePoint = sourcePoint;
            Fullscreen = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Getters and setter for the full screen.
        /// </summary>
        public bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                fullscreen = value;
            }
        }

        /// <summary>
        /// Getters and setter for the height.
        /// The height must be not be negative.
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 1)
                {
                    height = 1;

                    Console.WriteLine("The height was set to be less than one.");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.Y) > SystemInformation.VirtualScreen.Height)
                {
                    height = SystemInformation.VirtualScreen.Height - Math.Abs(SourcePoint.Y);

                    Console.WriteLine("The height was set too high to fit inside the screen.");
                }
                else
                {
                    height = value;
                }
            }
        }

        /// <summary>
        /// Getters and setter for the source point.
        /// </summary>
        public Point SourcePoint
        {
            get
            {
                return this.sourcePoint;
            }
            set
            {
                if (value.X < ScreenSize.TopLeftPoint.X)
                {
                    value.X = ScreenSize.TopLeftPoint.X;

                    System.Console.WriteLine("X co-ordinate being set is smaller than the screen.");
                }
                if (value.Y < ScreenSize.TopLeftPoint.Y)
                {
                    value.Y = ScreenSize.TopLeftPoint.Y;

                    System.Console.WriteLine("Y co-ordinate being set is smaller than the screen.");
                }
                if (value.X > SystemInformation.VirtualScreen.Right)
                {
                    value.X = SystemInformation.VirtualScreen.Right;

                    System.Console.WriteLine("X co-ordinate being set is larger than the screen.");
                }
                if (value.Y > SystemInformation.VirtualScreen.Bottom)
                {
                    value.Y = SystemInformation.VirtualScreen.Bottom;

                    System.Console.WriteLine("Y co-ordinate being set is larger than the screen.");
                }

                this.sourcePoint = value;
            }
        }

        /// <summary>
        /// Getters and setter for the width.
        /// The width must be not be negative.
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 1)
                {
                    width = 1;

                    Console.WriteLine("The width was set to be less than one");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.X) > SystemInformation.VirtualScreen.Width)
                {
                    width = SystemInformation.VirtualScreen.Width - Math.Abs(SourcePoint.X);

                    Console.WriteLine("The width was set too high to fit inside the screen.");
                }
                else
                {
                    width = value;
                }
            }
        }

        /// <summary>
        /// Getters and setter for the bottom right corner.
        /// </summary>
        public Point BottomRightCorner
        {
            get
            {
                return new Point(SourcePoint.X + Width, SourcePoint.Y + Height);
            }
        }

        #endregion Properties

        /// <summary>
        /// Will save the currently loaded options to file.
        /// </summary>
        public void Save()
        {
            try
            {
                SaveFile("UserOptions.xml");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Used for when the user wants to be able to save the options to file.
        /// </summary>
        /// <param name="Filename">The chosen file name from the user. Must put .xml on the end.</param>
        public void Save(string Filename)
        {
            try
            {
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScreenCapture");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string filePath = Path.Combine(directory, Filename);

                SaveFile(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private void SaveFile(string filePath)
        {
            try
            {
                if (!(filePath.EndsWith(".xml") || filePath.EndsWith(".XML")))
                {
                    filePath += ".xml";
                }

                using (var writer = new StreamWriter(filePath))
                {
                    var serializer = new XmlSerializer(GetType());
                    serializer.Serialize(writer, this);
                    writer.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static Options LoadFromFile()
        {
            return LoadFromFile("UserOptions.xml");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static Options LoadFromFile(String FileName)
        {
            using (var stream = File.OpenRead(FileName))
            {
                var obj = new Options();
                var serializer = new XmlSerializer(obj.GetType());
                return (Options)serializer.Deserialize(stream);
            }
        }

        public override bool Equals(Object obj)
        {
            Options optionsObj = obj as Options;
            if (optionsObj == null)
            {
                return false;
            }

            return optionsObj.Height == Height && optionsObj.Width == Width && optionsObj.SourcePoint == SourcePoint && optionsObj.Fullscreen == Fullscreen;
        }

        public override int GetHashCode()
        {
            return this.Height + this.width;
        }
    }
}