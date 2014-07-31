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
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnLiveFeed = new System.Windows.Forms.Button();
            this.picFeed = new System.Windows.Forms.PictureBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.cmsPictureBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).BeginInit();
            this.cmsPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(12, 12);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(75, 23);
            this.btnScreenshot.TabIndex = 0;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnLiveFeed
            // 
            this.btnLiveFeed.Location = new System.Drawing.Point(93, 12);
            this.btnLiveFeed.Name = "btnLiveFeed";
            this.btnLiveFeed.Size = new System.Drawing.Size(75, 23);
            this.btnLiveFeed.TabIndex = 1;
            this.btnLiveFeed.Text = "Live Feed";
            this.btnLiveFeed.UseVisualStyleBackColor = true;
            this.btnLiveFeed.Click += new System.EventHandler(this.btnLiveFeed_Click);
            // 
            // picFeed
            // 
            this.picFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFeed.ContextMenuStrip = this.cmsPictureBox;
            this.picFeed.Location = new System.Drawing.Point(12, 41);
            this.picFeed.Name = "picFeed";
            this.picFeed.Size = new System.Drawing.Size(927, 562);
            this.picFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFeed.TabIndex = 1;
            this.picFeed.TabStop = false;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(174, 12);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(61, 23);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // cmsPictureBox
            // 
            this.cmsPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.cmsPictureBox.Name = "cmsPictureBox";
            this.cmsPictureBox.Size = new System.Drawing.Size(103, 48);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // frmScreenCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 615);
            this.Controls.Add(this.picFeed);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnLiveFeed);
            this.Controls.Add(this.btnScreenshot);
            this.Name = "frmScreenCapture";
            this.Text = "Screen Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenCapture_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).EndInit();
            this.cmsPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnLiveFeed;
        private System.Windows.Forms.PictureBox picFeed;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip cmsPictureBox;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

