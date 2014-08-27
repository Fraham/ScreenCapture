namespace ScreenCapture
{
    partial class frmUserCaptureArea
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmUserCaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            //this.ClientSize = new System.Drawing.Size(518, 416);
            this.ClientSize = new System.Drawing.Size(ScreenSize.Width, ScreenSize.Height);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserCaptureArea";
            this.Opacity = 0.4D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Screen Capture";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Width = ScreenSize.Width;
            this.Height = ScreenSize.Height;
            this.Location = ScreenSize.TopLeftPoint;
            this.ResumeLayout(false);

        }

        #endregion


    }
}