using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.ScreenCapture
{
    public partial class frmScreenshot : Form
    {
        private Screenshot shot;

        public frmScreenshot(Screenshot shot)
        {
            InitializeComponent();

            loadShot();
        }

        private void loadShot()
        {
            picScreenshot.Image = Shot.Image;
        }

        public Screenshot Shot
        {
            get
            {
                return shot;
            }
            set
            {
                shot = value;
            }
        }
    }
}
