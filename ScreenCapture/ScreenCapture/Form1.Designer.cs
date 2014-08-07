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
            this.components = new System.ComponentModel.Container();
            this.picFeed = new System.Windows.Forms.PictureBox();
            this.cmsPictureBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPictureBoxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPictureBoxSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCapture = new System.Windows.Forms.MenuStrip();
            this.screenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureTake = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.liveFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCapturePause = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsScreenCaptureResume = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).BeginInit();
            this.cmsPictureBox.SuspendLayout();
            this.mnsScreenCapture.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFeed
            // 
            this.picFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFeed.ContextMenuStrip = this.cmsPictureBox;
            this.picFeed.Location = new System.Drawing.Point(12, 27);
            this.picFeed.Name = "picFeed";
            this.picFeed.Size = new System.Drawing.Size(927, 576);
            this.picFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFeed.TabIndex = 1;
            this.picFeed.TabStop = false;
            // 
            // cmsPictureBox
            // 
            this.cmsPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPictureBoxCopy,
            this.cmsPictureBoxSave});
            this.cmsPictureBox.Name = "cmsPictureBox";
            this.cmsPictureBox.Size = new System.Drawing.Size(103, 48);
            // 
            // cmsPictureBoxCopy
            // 
            this.cmsPictureBoxCopy.Name = "cmsPictureBoxCopy";
            this.cmsPictureBoxCopy.Size = new System.Drawing.Size(102, 22);
            this.cmsPictureBoxCopy.Text = "Copy";
            this.cmsPictureBoxCopy.Click += new System.EventHandler(this.cmsPictureBoxCopy_Click);
            // 
            // cmsPictureBoxSave
            // 
            this.cmsPictureBoxSave.Name = "cmsPictureBoxSave";
            this.cmsPictureBoxSave.Size = new System.Drawing.Size(102, 22);
            this.cmsPictureBoxSave.Text = "Save";
            this.cmsPictureBoxSave.Click += new System.EventHandler(this.cmsPictureBoxSave_Click);
            // 
            // mnsScreenCapture
            // 
            this.mnsScreenCapture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenToolStripMenuItem,
            this.liveFeedToolStripMenuItem,
            this.mnsScreenCaptureOptions});
            this.mnsScreenCapture.Location = new System.Drawing.Point(0, 0);
            this.mnsScreenCapture.Name = "mnsScreenCapture";
            this.mnsScreenCapture.Size = new System.Drawing.Size(951, 24);
            this.mnsScreenCapture.TabIndex = 3;
            this.mnsScreenCapture.Text = "menuStrip1";
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
            this.mnsScreenCaptureSave.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCaptureSave.Text = "Save";
            this.mnsScreenCaptureSave.Click += new System.EventHandler(this.mnsScreenCaptureSave_Click);
            // 
            // mnsScreenCaptureCopy
            // 
            this.mnsScreenCaptureCopy.Enabled = false;
            this.mnsScreenCaptureCopy.Name = "mnsScreenCaptureCopy";
            this.mnsScreenCaptureCopy.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCaptureCopy.Text = "Copy";
            this.mnsScreenCaptureCopy.Click += new System.EventHandler(this.mnsScreenCaptureCopy_Click);
            // 
            // liveFeedToolStripMenuItem
            // 
            this.liveFeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsScreenCaptureStart,
            this.mnsScreenCaptureResume,
            this.mnsScreenCapturePause,
            this.mnsScreenCaptureStop});
            this.liveFeedToolStripMenuItem.Name = "liveFeedToolStripMenuItem";
            this.liveFeedToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.liveFeedToolStripMenuItem.Text = "Live Feed";
            // 
            // mnsScreenCaptureStart
            // 
            this.mnsScreenCaptureStart.Name = "mnsScreenCaptureStart";
            this.mnsScreenCaptureStart.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCaptureStart.Text = "Start";
            this.mnsScreenCaptureStart.Click += new System.EventHandler(this.mnsScreenCaptureStart_Click);
            // 
            // mnsScreenCapturePause
            // 
            this.mnsScreenCapturePause.Enabled = false;
            this.mnsScreenCapturePause.Name = "mnsScreenCapturePause";
            this.mnsScreenCapturePause.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCapturePause.Text = "Pause";
            this.mnsScreenCapturePause.Click += new System.EventHandler(this.mnsScreenCapturePause_Click);
            // 
            // mnsScreenCaptureStop
            // 
            this.mnsScreenCaptureStop.Enabled = false;
            this.mnsScreenCaptureStop.Name = "mnsScreenCaptureStop";
            this.mnsScreenCaptureStop.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCaptureStop.Text = "Stop";
            this.mnsScreenCaptureStop.Click += new System.EventHandler(this.mnsScreenCaptureStop_Click);
            // 
            // mnsScreenCaptureOptions
            // 
            this.mnsScreenCaptureOptions.Name = "mnsScreenCaptureOptions";
            this.mnsScreenCaptureOptions.Size = new System.Drawing.Size(61, 20);
            this.mnsScreenCaptureOptions.Text = "Options";
            this.mnsScreenCaptureOptions.Click += new System.EventHandler(this.mnsScreenCaptureOptions_Click);
            // 
            // mnsScreenCaptureResume
            // 
            this.mnsScreenCaptureResume.Enabled = false;
            this.mnsScreenCaptureResume.Name = "mnsScreenCaptureResume";
            this.mnsScreenCaptureResume.Size = new System.Drawing.Size(152, 22);
            this.mnsScreenCaptureResume.Text = "Resume";
            this.mnsScreenCaptureResume.Click += new System.EventHandler(this.mnsScreenCaptureResume_Click);
            // 
            // frmScreenCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 615);
            this.Controls.Add(this.mnsScreenCapture);
            this.Controls.Add(this.picFeed);
            this.MainMenuStrip = this.mnsScreenCapture;
            this.Name = "frmScreenCapture";
            this.Text = "Screen Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenCapture_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).EndInit();
            this.cmsPictureBox.ResumeLayout(false);
            this.mnsScreenCapture.ResumeLayout(false);
            this.mnsScreenCapture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFeed;
        private System.Windows.Forms.ContextMenuStrip cmsPictureBox;
        private System.Windows.Forms.ToolStripMenuItem cmsPictureBoxCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsPictureBoxSave;
        private System.Windows.Forms.MenuStrip mnsScreenCapture;
        private System.Windows.Forms.ToolStripMenuItem screenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureTake;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureSave;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureCopy;
        private System.Windows.Forms.ToolStripMenuItem liveFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureStart;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCapturePause;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureStop;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureOptions;
        private System.Windows.Forms.ToolStripMenuItem mnsScreenCaptureResume;
    }
}

