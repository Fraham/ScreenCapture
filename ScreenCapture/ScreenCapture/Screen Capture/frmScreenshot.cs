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
    public partial class frmScreenshot : Form
    {
        private Screenshot shot;

        public frmScreenshot(Screenshot shot)
        {
            InitializeComponent();

            Shot = shot;

            loadShot();
        }

        private void loadShot()
        {
            try
            {
                picScreenshot.Image = Shot.Image;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Shot.Save();
            }
            catch
            {
                MessageBox.Show("Unable to save the screenshot.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Shot.Print();
            }
            catch
            {
                MessageBox.Show("Unable to print the screenshot.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Shot.Copy();
            }
            catch
            {
                MessageBox.Show("Unable to copy the screenshot.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
