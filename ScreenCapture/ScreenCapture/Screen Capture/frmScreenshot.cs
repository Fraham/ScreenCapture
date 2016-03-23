﻿using System;
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

        /// <summary>
        /// Creates a new form which is display a screenshot which is given as a parameter.
        /// </summary>
        /// <param name="shot">The screenshot which should be displayed on form.</param>
        public frmScreenshot(Screenshot shot)
        {
            InitializeComponent();

            Shot = shot;

            loadShot();
        }

        /// <summary>
        /// Loads the screenshot onto the picture box.
        /// </summary>
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

        /// <summary>
        /// Saves the screenshot
        /// </summary>
        private void saveShot()
        {
            shot.save();
        }

        /// <summary>
        /// Copies the screenshot
        /// </summary>
        private void copyShot()
        {
            shot.copy();
        }

        /// <summary>
        /// Prints the screenshot
        /// </summary>
        private void printShot()
        {
            shot.print();
        }

        /// <summary>
        /// 
        /// </summary>
        public Screenshot Shot
        {
            get
            {
                //check if null
                return shot;
            }
            set
            {
                //check if null
                shot = value;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveShot();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyShot();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printShot();

            try
            {
                Shot.Save();
            }
            catch
            {
                MessageBox.Show("Unable to save the screenshot.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void printToolStripMenuItem_Click(object sender, EventArgs e)
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
        }*/
    }
}
