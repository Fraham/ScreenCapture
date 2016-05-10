namespace ScreenCapture.ScreenCapture
{
    partial class frmFeed
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
            this.picFeed = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.fbdFeedSaver = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveFeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // picFeed
            // 
            this.picFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picFeed.Location = new System.Drawing.Point(12, 41);
            this.picFeed.Name = "picFeed";
            this.picFeed.Size = new System.Drawing.Size(949, 654);
            this.picFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFeed.TabIndex = 2;
            this.picFeed.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(93, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(174, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSaveFeed
            // 
            this.btnSaveFeed.Enabled = false;
            this.btnSaveFeed.Location = new System.Drawing.Point(255, 12);
            this.btnSaveFeed.Name = "btnSaveFeed";
            this.btnSaveFeed.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFeed.TabIndex = 3;
            this.btnSaveFeed.Text = "Save";
            this.btnSaveFeed.UseVisualStyleBackColor = true;
            this.btnSaveFeed.Click += new System.EventHandler(this.btnSaveFeed_Click);
            // 
            // frmFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 707);
            this.Controls.Add(this.btnSaveFeed);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.picFeed);
            this.MinimumSize = new System.Drawing.Size(20, 39);
            this.Name = "frmFeed";
            this.Text = "Feed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFeed_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.FolderBrowserDialog fbdFeedSaver;
        private System.Windows.Forms.Button btnSaveFeed;
    }
}