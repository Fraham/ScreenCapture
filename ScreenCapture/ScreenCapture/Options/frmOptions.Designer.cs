namespace ScreenCapture
{
    partial class frmOptions
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpFullScreen = new System.Windows.Forms.GroupBox();
            this.radNotFullScreen = new System.Windows.Forms.RadioButton();
            this.radFullScreen = new System.Windows.Forms.RadioButton();
            this.grpCaptureOptions = new System.Windows.Forms.GroupBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblYSourcePoint = new System.Windows.Forms.Label();
            this.lblXSourcePoint = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudYSourcePoint = new System.Windows.Forms.NumericUpDown();
            this.nudXSourcePoint = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.btnSelectCaptureArea = new System.Windows.Forms.Button();
            this.btnShowCaptureArea = new System.Windows.Forms.Button();
            this.grpScreenSelect = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpFullScreen.SuspendLayout();
            this.grpCaptureOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYSourcePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXSourcePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.grpScreenSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(142, 334);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(45, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(193, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpFullScreen
            // 
            this.grpFullScreen.Controls.Add(this.radNotFullScreen);
            this.grpFullScreen.Controls.Add(this.radFullScreen);
            this.grpFullScreen.Location = new System.Drawing.Point(12, 12);
            this.grpFullScreen.Name = "grpFullScreen";
            this.grpFullScreen.Size = new System.Drawing.Size(240, 69);
            this.grpFullScreen.TabIndex = 1;
            this.grpFullScreen.TabStop = false;
            this.grpFullScreen.Text = "Full Screen";
            // 
            // radNotFullScreen
            // 
            this.radNotFullScreen.AutoSize = true;
            this.radNotFullScreen.Checked = true;
            this.radNotFullScreen.Location = new System.Drawing.Point(25, 19);
            this.radNotFullScreen.Name = "radNotFullScreen";
            this.radNotFullScreen.Size = new System.Drawing.Size(98, 17);
            this.radNotFullScreen.TabIndex = 2;
            this.radNotFullScreen.TabStop = true;
            this.radNotFullScreen.Text = "Not Full Screen";
            this.radNotFullScreen.UseVisualStyleBackColor = true;
            this.radNotFullScreen.CheckedChanged += new System.EventHandler(this.radNotFullScreen_CheckedChanged);
            // 
            // radFullScreen
            // 
            this.radFullScreen.AutoSize = true;
            this.radFullScreen.Location = new System.Drawing.Point(25, 42);
            this.radFullScreen.Name = "radFullScreen";
            this.radFullScreen.Size = new System.Drawing.Size(78, 17);
            this.radFullScreen.TabIndex = 3;
            this.radFullScreen.Text = "Full Screen";
            this.radFullScreen.UseVisualStyleBackColor = true;
            // 
            // grpCaptureOptions
            // 
            this.grpCaptureOptions.Controls.Add(this.lblHeight);
            this.grpCaptureOptions.Controls.Add(this.lblYSourcePoint);
            this.grpCaptureOptions.Controls.Add(this.lblXSourcePoint);
            this.grpCaptureOptions.Controls.Add(this.lblWidth);
            this.grpCaptureOptions.Controls.Add(this.nudHeight);
            this.grpCaptureOptions.Controls.Add(this.nudYSourcePoint);
            this.grpCaptureOptions.Controls.Add(this.nudXSourcePoint);
            this.grpCaptureOptions.Controls.Add(this.nudWidth);
            this.grpCaptureOptions.Location = new System.Drawing.Point(12, 201);
            this.grpCaptureOptions.Name = "grpCaptureOptions";
            this.grpCaptureOptions.Size = new System.Drawing.Size(240, 127);
            this.grpCaptureOptions.TabIndex = 0;
            this.grpCaptureOptions.TabStop = false;
            this.grpCaptureOptions.Text = "Capture Options";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(22, 47);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height:";
            // 
            // lblYSourcePoint
            // 
            this.lblYSourcePoint.AutoSize = true;
            this.lblYSourcePoint.Location = new System.Drawing.Point(22, 99);
            this.lblYSourcePoint.Name = "lblYSourcePoint";
            this.lblYSourcePoint.Size = new System.Drawing.Size(81, 13);
            this.lblYSourcePoint.TabIndex = 2;
            this.lblYSourcePoint.Text = "Y Source Point:";
            // 
            // lblXSourcePoint
            // 
            this.lblXSourcePoint.AutoSize = true;
            this.lblXSourcePoint.Location = new System.Drawing.Point(22, 73);
            this.lblXSourcePoint.Name = "lblXSourcePoint";
            this.lblXSourcePoint.Size = new System.Drawing.Size(81, 13);
            this.lblXSourcePoint.TabIndex = 2;
            this.lblXSourcePoint.Text = "X Source Point:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(22, 21);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Width:";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(109, 45);
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(120, 20);
            this.nudHeight.TabIndex = 3;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudYSourcePoint
            // 
            this.nudYSourcePoint.Location = new System.Drawing.Point(109, 97);
            this.nudYSourcePoint.Name = "nudYSourcePoint";
            this.nudYSourcePoint.Size = new System.Drawing.Size(120, 20);
            this.nudYSourcePoint.TabIndex = 3;
            // 
            // nudXSourcePoint
            // 
            this.nudXSourcePoint.Location = new System.Drawing.Point(109, 71);
            this.nudXSourcePoint.Name = "nudXSourcePoint";
            this.nudXSourcePoint.Size = new System.Drawing.Size(120, 20);
            this.nudXSourcePoint.TabIndex = 3;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(109, 19);
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(120, 20);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSelectCaptureArea
            // 
            this.btnSelectCaptureArea.Location = new System.Drawing.Point(12, 87);
            this.btnSelectCaptureArea.Name = "btnSelectCaptureArea";
            this.btnSelectCaptureArea.Size = new System.Drawing.Size(240, 23);
            this.btnSelectCaptureArea.TabIndex = 4;
            this.btnSelectCaptureArea.Text = "Select Capture Area";
            this.btnSelectCaptureArea.UseVisualStyleBackColor = true;
            this.btnSelectCaptureArea.Click += new System.EventHandler(this.btnSelectCaptureArea_Click);
            // 
            // btnShowCaptureArea
            // 
            this.btnShowCaptureArea.Location = new System.Drawing.Point(12, 116);
            this.btnShowCaptureArea.Name = "btnShowCaptureArea";
            this.btnShowCaptureArea.Size = new System.Drawing.Size(240, 23);
            this.btnShowCaptureArea.TabIndex = 4;
            this.btnShowCaptureArea.Text = "Show Capture Area";
            this.btnShowCaptureArea.UseVisualStyleBackColor = true;
            this.btnShowCaptureArea.Click += new System.EventHandler(this.btnShowCaptureArea_Click);
            // 
            // grpScreenSelect
            // 
            this.grpScreenSelect.Controls.Add(this.comboBox1);
            this.grpScreenSelect.Location = new System.Drawing.Point(12, 145);
            this.grpScreenSelect.Name = "grpScreenSelect";
            this.grpScreenSelect.Size = new System.Drawing.Size(240, 50);
            this.grpScreenSelect.TabIndex = 1;
            this.grpScreenSelect.TabStop = false;
            this.grpScreenSelect.Text = "Screen Select";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 369);
            this.Controls.Add(this.btnShowCaptureArea);
            this.Controls.Add(this.btnSelectCaptureArea);
            this.Controls.Add(this.grpCaptureOptions);
            this.Controls.Add(this.grpScreenSelect);
            this.Controls.Add(this.grpFullScreen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmOptions";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.grpFullScreen.ResumeLayout(false);
            this.grpFullScreen.PerformLayout();
            this.grpCaptureOptions.ResumeLayout(false);
            this.grpCaptureOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYSourcePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXSourcePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.grpScreenSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpFullScreen;
        private System.Windows.Forms.GroupBox grpCaptureOptions;
        private System.Windows.Forms.RadioButton radNotFullScreen;
        private System.Windows.Forms.RadioButton radFullScreen;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblYSourcePoint;
        private System.Windows.Forms.Label lblXSourcePoint;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudYSourcePoint;
        private System.Windows.Forms.NumericUpDown nudXSourcePoint;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Button btnSelectCaptureArea;
        private System.Windows.Forms.Button btnShowCaptureArea;
        private System.Windows.Forms.GroupBox grpScreenSelect;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}