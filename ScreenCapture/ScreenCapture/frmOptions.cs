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
            if (validWidth() && validHeight())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                System.Console.WriteLine("Capture area too large for the screen.");
                this.DialogResult = DialogResult.None;
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

        private bool validWidth()
        {
            if (nudWidth.Value + nudXSourcePoint.Value > maxWidth)
            {
                return false;
            }

            return true;
        }

        private bool validHeight()
        {
            if (nudHeight.Value + nudYSourcePoint.Value > maxHeight)
            {
                return false;
            }

            return true;
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }

        public Options getOptions()
        {
            return new Options((int)nudWidth.Value, (int)nudHeight.Value, new Point((int)nudXSourcePoint.Value, (int)nudYSourcePoint.Value));
        }
    }
}
