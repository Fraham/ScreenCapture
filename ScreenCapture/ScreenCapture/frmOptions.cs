using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class frmOptions : Form
    {
        private int maxWidth;
        private int maxHeight;

        public frmOptions()
        {
            InitializeComponent();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if ()
            {

            }
            else
            {
                this.Close();
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            Rectangle totalSize = Rectangle.Empty;

            foreach (Screen s in Screen.AllScreens)
                totalSize = Rectangle.Union(totalSize, s.Bounds);

            nudWidth.Maximum = totalSize.Width;
            nudHeight.Maximum = totalSize.Height;

            nudXSourcePoint.Maximum = totalSize.Width;
            nudYSourcePoint.Maximum = totalSize.Height;

            maxWidth = totalSize.Width;
            maxHeight = totalSize.Height;
        }

        private bool checkWidth()
        {
            if (nudWidth.Value + nudXSourcePoint.Value > maxWidth)
            {
                return false;
            }

            return true;
        }
    }
}
