using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                folderPath = value;
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
                frameNumber = value;
            }
        }
    }
}
