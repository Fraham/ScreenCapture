using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.Repositories.ScreenshotRepositories
{
    public class WindowsScreenshotRepository : IScreenshotRepository
    {
        public Image Load(string _fileName = null)
        {
            string fileName;

            if ((fileName = _fileName) == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPEG File | *.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }
            }

            if (!File.Exists(fileName))
            {
                return null;
            }

            return Image.FromFile(fileName);
        }

        public void Save(Image image, ImageFormat _imageFormat = null, string _fileName = null)
        {
            var imageFormat = _imageFormat ?? ImageFormat.Jpeg;

            string fileName;

            if ((fileName = _fileName) == null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JPEG File | *.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }
            }

            if (!(fileName.ToLower().EndsWith("."+ imageFormat.ToString().ToLower())))
            {
                fileName += "." + imageFormat.ToString();
            }

            image.Save(fileName, imageFormat);
        }
    }
}
