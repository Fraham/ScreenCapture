using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenCapture
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
                return this.fullscreen;
            }
            set
            {
                this.fullscreen = value;
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
                return this.height;
            }
            set
            {
                if (value < 1)
                {
                    this.height = 1;

                    System.Console.WriteLine("The height was set to be less than one.");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.Y) > SystemInformation.VirtualScreen.Height)
                {
                    this.height = SystemInformation.VirtualScreen.Height - Math.Abs(SourcePoint.Y);

                    System.Console.WriteLine("The height was set too high to fit inside the screen.");
                }
                else
                {
                    this.height = value;
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
                return this.width;
            }
            set
            {
                if (value < 1)
                {
                    this.width = 1;

                    System.Console.WriteLine("The width was set to be less than one");
                }
                else if (Math.Abs(value) + Math.Abs(SourcePoint.X) > SystemInformation.VirtualScreen.Width)
                {
                    this.width = SystemInformation.VirtualScreen.Width - Math.Abs(SourcePoint.X);

                    System.Console.WriteLine("The width was set too high to fit inside the screen.");
                }
                else
                {
                    this.width = value;
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
        /// <param name="Filename">The choosen file name from the user. Must put .xml on the end.</param>
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
        public static Options LoadFromFile()
        {
            try
            {
                using (var stream = File.OpenRead("UserOptions.xml"))
                {
                    var obj = new Options();
                    var serializer = new XmlSerializer(obj.GetType());
                    return (Options)serializer.Deserialize(stream);
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}