using ScreenCapture.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.Repositories.ScreenshotRepositories
{
    public class WindowsScreenshotRepository : IScreenshotRepository
    {
        public Image Load(string fileName = null)
        {
            throw new NotImplementedException();
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

            if (!(fileName.ToLower().EndsWith(".jpeg")))
            {
                fileName += ".jpeg";
            }

            image.Save(fileName, imageFormat);
        }
    }
}
