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
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnLiveFeed = new System.Windows.Forms.Button();
            this.picFeed = new System.Windows.Forms.PictureBox();
            this.btnOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFeed)).BeginInit();
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
            this.btnLiveFeed.TabIndex = 0;
            this.btnLiveFeed.Text = "Live Feed";
            this.btnLiveFeed.UseVisualStyleBackColor = true;
            this.btnLiveFeed.Click += new System.EventHandler(this.btnLiveFeed_Click);
            // 
            // picFeed
            // 
            this.picFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnOptions.TabIndex = 0;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnLiveFeed;
        private System.Windows.Forms.PictureBox picFeed;
        private System.Windows.Forms.Button btnOptions;
    }
}

