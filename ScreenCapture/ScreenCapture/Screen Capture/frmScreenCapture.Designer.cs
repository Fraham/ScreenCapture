namespace ScreenCapture
{
    partial class frmScreenCapture
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
            this.btnLiveFeed = new System.Windows.Forms.Button();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureTake = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCapture = new System.Windows.Forms.MenuStrip();
            this.fbdFeedSaver = new System.Windows.Forms.FolderBrowserDialog();
            this.mnsScreenCapture.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLiveFeed
            // 
            this.btnLiveFeed.Location = new System.Drawing.Point(22, 27);
            this.btnLiveFeed.Name = "btnLiveFeed";
            this.btnLiveFeed.Size = new System.Drawing.Size(90, 23);
            this.btnLiveFeed.TabIndex = 4;
            this.btnLiveFeed.Text = "New Live Feed";
            this.btnLiveFeed.UseVisualStyleBackColor = true;
            this.btnLiveFeed.Click += new System.EventHandler(this.btnLiveFeed_Click);
            // 
            // screenToolStripMenuItem
            // 
            this.screenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsScreenCaptureTake,
            this.mnsScreenCaptureSave,
            this.mnsScreenCaptureCopy});
            this.screenToolStripMenuItem.Name = "screenToolStripMenuItem";
            this.screenToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.screenToolStripMenuItem.Text = "Screenshot";
            // 
            // mnsScreenCaptureTake
            // 
            this.mnsScreenCaptureTake.Name = "mnsScreenCaptureTake";
            this.mnsScreenCaptureTake.Size = new System.Drawing.Size(102, 22);
            this.mnsScreenCaptureTake.Text = "Take";
            this.mnsScreenCaptureTake.Click += new System.EventHandler(this.mnsScreenCaptureTake_Click);
            // 
            // mnsScreenCaptureSave
            // 
            this.mnsScreenCaptureSave.Enabled = false;
            this.mnsScreenCaptureSave.Name = "mnsScreenCaptureSave";
            this.mnsScreenCaptureSave.Size = new System.Drawing.Size(102, 22);
            this.mnsScreenCaptureSave.Text = "Save";
            this.mnsScreenCaptureSave.Click += new System.EventHandler(this.mnsScreenCaptureSave_Click);
            // 
            // mnsScreenCaptureCopy
            // 
            this.mnsScreenCaptureCopy.Enabled = false;
            this.mnsScreenCaptureCopy.Name = "mnsScreenCaptureCopy";
            this.mnsScreenCaptureCopy.Size = new System.Drawing.Size(102, 22);
            this.mnsScreenCaptureCopy.Text = "Copy";
            this.mnsScreenCaptureCopy.Click += new System.EventHandler(this.mnsScreenCaptureCopy_Click);
            // 
            // mnsScreenCaptureOptions
            // 
            this.mnsScreenCaptureOptions.Name = "mnsScreenCaptureOptions";
            this.mnsScreenCaptureOptions.Size = new System.Drawing.Size(61, 20);
            this.mnsScreenCaptureOptions.Text = "Options";
            this.mnsScreenCaptureOptions.Click += new System.EventHandler(this.mnsScreenCaptureOptions_Click);
            // 
            // mnsScreenCapture
            // 
            this.mnsScreenCapture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenToolStripMenuItem,
            this.mnsScreenCaptureOptions});
            this.mnsScreenCapture.Location = new System.Drawing.Point(0, 0);
            this.mnsScreenCapture.Name = "mnsScreenCapture";
            this.mnsScreenCapture.Size = new System.Drawing.Size(220, 24);
            this.mnsScreenCapture.TabIndex = 3;
            this.mnsScreenCapture.Text = "menuStrip1";
            // 
            // frmScreenCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 123);
            this.Controls.Add(this.btnLiveFeed);
            this.Controls.Add(this.mnsScreenCapture);
            this.MainMenuStrip = this.mnsScreenCapture;
            this.Name = "frmScreenCapture";
            this.Text = "Screen Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenCapture_FormClosing);
            this.mnsScreenCapture.ResumeLayout(false);
            this.mnsScreenCapture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLiveFeed;
        private System.Windows.Forms.ToolStripMenuItem screenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureTake;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureSave;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureCopy;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureOptions;
        private System.Windows.Forms.MenuStrip mnsScreenCapture;
        private System.Windows.Forms.FolderBrowserDialog fbdFeedSaver;
    }
}

