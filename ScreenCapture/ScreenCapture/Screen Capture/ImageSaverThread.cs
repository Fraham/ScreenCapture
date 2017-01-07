using System;
using System.Drawing;
using System.IO;

namespace ScreenCapture
{
    public class ImageSaverThread
    {
        private string folderPath;
        private Bitmap imageToSave;
        private int frameNumber;

        public ImageSaverThread(string folderPath, Bitmap imageToSave, int frameNumber)
        {
            FolderPath = folderPath;
            ImageToSave = imageToSave;
            FrameNumber = frameNumber;
        }

        public string FolderPath
        {
            get
            {
                return folderPath;
            }
            set
            {
                if (!(new Uri(value)).IsWellFormedOriginalString())
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }

                    folderPath = value;
                }
                else
                {
                    throw new FileNotFoundException("Folder not valid " + value);
                }                
            }
        }

        public Bitmap ImageToSave
        {
            get
            {
                return imageToSave;
            }

            set
            {
                imageToSave = value;
            }
        }

        public int FrameNumber
        {
            get
            {
                return frameNumber;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Frame number has to be greater than zero");
                }

                frameNumber = value;
            }
        }
    }
}
