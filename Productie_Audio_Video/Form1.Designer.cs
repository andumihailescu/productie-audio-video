using Emgu.CV.Structure;
using System.Windows.Forms;

namespace ProductieAudioVideo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grayscaleBtn = new Button();
            button3 = new Button();
            gammaBtn = new Button();
            alphaBox = new TextBox();
            betaBox = new TextBox();
            alphaLabel = new Label();
            betaLabel = new Label();
            button5 = new Button();
            videoBox = new PictureBox();
            loadVideoBtn = new Button();
            numericUpDown1 = new NumericUpDown();
            frameLabel = new Label();
            playPauseBtn = new Button();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            fpsLabel = new Label();
            totalFramesLabel = new Label();
            originalBtn = new Button();
            radioButtonNormal = new RadioButton();
            radioButtonRed = new RadioButton();
            radioButtonGreen = new RadioButton();
            radioButtonBlue = new RadioButton();
            extractRGBGroup = new GroupBox();
            groupBox2 = new GroupBox();
            carouselBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)videoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            extractRGBGroup.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grayscaleBtn
            // 
            grayscaleBtn.Location = new Point(12, 62);
            grayscaleBtn.Name = "grayscaleBtn";
            grayscaleBtn.Size = new Size(109, 29);
            grayscaleBtn.TabIndex = 2;
            grayscaleBtn.Text = "Grayscale";
            grayscaleBtn.UseVisualStyleBackColor = true;
            grayscaleBtn.Click += grayscaleBtn_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1224, 195);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            // 
            // gammaBtn
            // 
            gammaBtn.Location = new Point(3, 90);
            gammaBtn.Name = "gammaBtn";
            gammaBtn.Size = new Size(109, 29);
            gammaBtn.TabIndex = 6;
            gammaBtn.Text = "Gamma";
            gammaBtn.UseVisualStyleBackColor = true;
            gammaBtn.Click += gammaBtn_Click;
            // 
            // alphaBox
            // 
            alphaBox.Location = new Point(9, 55);
            alphaBox.Name = "alphaBox";
            alphaBox.Size = new Size(41, 27);
            alphaBox.TabIndex = 7;
            // 
            // betaBox
            // 
            betaBox.Location = new Point(65, 54);
            betaBox.Name = "betaBox";
            betaBox.Size = new Size(41, 27);
            betaBox.TabIndex = 8;
            // 
            // alphaLabel
            // 
            alphaLabel.AutoSize = true;
            alphaLabel.Location = new Point(9, 24);
            alphaLabel.Name = "alphaLabel";
            alphaLabel.Size = new Size(46, 20);
            alphaLabel.TabIndex = 9;
            alphaLabel.Text = "alpha";
            // 
            // betaLabel
            // 
            betaLabel.AutoSize = true;
            betaLabel.Location = new Point(65, 24);
            betaLabel.Name = "betaLabel";
            betaLabel.Size = new Size(39, 20);
            betaLabel.TabIndex = 10;
            betaLabel.Text = "beta";
            // 
            // button5
            // 
            button5.Location = new Point(1224, 160);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 11;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // videoBox
            // 
            videoBox.Location = new Point(180, 20);
            videoBox.Name = "videoBox";
            videoBox.Size = new Size(960, 540);
            videoBox.SizeMode = PictureBoxSizeMode.Zoom;
            videoBox.TabIndex = 12;
            videoBox.TabStop = false;
            // 
            // loadVideoBtn
            // 
            loadVideoBtn.Location = new Point(180, 589);
            loadVideoBtn.Name = "loadVideoBtn";
            loadVideoBtn.Size = new Size(94, 29);
            loadVideoBtn.TabIndex = 13;
            loadVideoBtn.Text = "Load Video";
            loadVideoBtn.UseVisualStyleBackColor = true;
            loadVideoBtn.Click += loadVideoBtn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(990, 589);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 14;
            // 
            // frameLabel
            // 
            frameLabel.AutoSize = true;
            frameLabel.Location = new Point(751, 563);
            frameLabel.Name = "frameLabel";
            frameLabel.Size = new Size(107, 20);
            frameLabel.TabIndex = 15;
            frameLabel.Text = "Current frame: ";
            // 
            // playPauseBtn
            // 
            playPauseBtn.Location = new Point(551, 589);
            playPauseBtn.Name = "playPauseBtn";
            playPauseBtn.Size = new Size(125, 29);
            playPauseBtn.TabIndex = 16;
            playPauseBtn.Text = "Play Video";
            playPauseBtn.UseVisualStyleBackColor = true;
            playPauseBtn.Click += playPauseBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1224, 230);
            button1.Name = "button1";
            button1.Size = new Size(109, 29);
            button1.TabIndex = 18;
            button1.Text = "Blend Images";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1226, 265);
            button2.Name = "button2";
            button2.Size = new Size(113, 29);
            button2.TabIndex = 19;
            button2.Text = "Video Overlay";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1226, 300);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 20;
            button4.Text = "Dip to BW";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new Point(751, 603);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(128, 20);
            fpsLabel.TabIndex = 21;
            fpsLabel.Text = "Video frame rate: ";
            // 
            // totalFramesLabel
            // 
            totalFramesLabel.AutoSize = true;
            totalFramesLabel.Location = new Point(751, 583);
            totalFramesLabel.Name = "totalFramesLabel";
            totalFramesLabel.Size = new Size(98, 20);
            totalFramesLabel.TabIndex = 22;
            totalFramesLabel.Text = "Total frames: ";
            // 
            // originalBtn
            // 
            originalBtn.Location = new Point(12, 20);
            originalBtn.Name = "originalBtn";
            originalBtn.Size = new Size(109, 29);
            originalBtn.TabIndex = 23;
            originalBtn.Text = "Original";
            originalBtn.UseVisualStyleBackColor = true;
            originalBtn.Click += originalBtn_Click;
            // 
            // radioButtonNormal
            // 
            radioButtonNormal.AutoSize = true;
            radioButtonNormal.Enabled = false;
            radioButtonNormal.Location = new Point(15, 117);
            radioButtonNormal.Name = "radioButtonNormal";
            radioButtonNormal.Size = new Size(80, 24);
            radioButtonNormal.TabIndex = 24;
            radioButtonNormal.Text = "Normal";
            radioButtonNormal.UseVisualStyleBackColor = true;
            radioButtonNormal.CheckedChanged += extractColorChannel;
            // 
            // radioButtonRed
            // 
            radioButtonRed.AutoSize = true;
            radioButtonRed.Enabled = false;
            radioButtonRed.Location = new Point(15, 27);
            radioButtonRed.Name = "radioButtonRed";
            radioButtonRed.Size = new Size(56, 24);
            radioButtonRed.TabIndex = 25;
            radioButtonRed.TabStop = true;
            radioButtonRed.Text = "Red";
            radioButtonRed.UseVisualStyleBackColor = true;
            radioButtonRed.CheckedChanged += extractColorChannel;
            // 
            // radioButtonGreen
            // 
            radioButtonGreen.AutoSize = true;
            radioButtonGreen.Enabled = false;
            radioButtonGreen.Location = new Point(15, 57);
            radioButtonGreen.Name = "radioButtonGreen";
            radioButtonGreen.Size = new Size(69, 24);
            radioButtonGreen.TabIndex = 26;
            radioButtonGreen.TabStop = true;
            radioButtonGreen.Text = "Green";
            radioButtonGreen.UseVisualStyleBackColor = true;
            radioButtonGreen.CheckedChanged += extractColorChannel;
            // 
            // radioButtonBlue
            // 
            radioButtonBlue.AutoSize = true;
            radioButtonBlue.Enabled = false;
            radioButtonBlue.Location = new Point(15, 87);
            radioButtonBlue.Name = "radioButtonBlue";
            radioButtonBlue.Size = new Size(59, 24);
            radioButtonBlue.TabIndex = 27;
            radioButtonBlue.TabStop = true;
            radioButtonBlue.Text = "Blue";
            radioButtonBlue.UseVisualStyleBackColor = true;
            radioButtonBlue.CheckedChanged += extractColorChannel;
            // 
            // extractRGBGroup
            // 
            extractRGBGroup.Controls.Add(radioButtonNormal);
            extractRGBGroup.Controls.Add(radioButtonRed);
            extractRGBGroup.Controls.Add(radioButtonBlue);
            extractRGBGroup.Controls.Add(radioButtonGreen);
            extractRGBGroup.Location = new Point(12, 236);
            extractRGBGroup.Name = "extractRGBGroup";
            extractRGBGroup.Size = new Size(112, 147);
            extractRGBGroup.TabIndex = 30;
            extractRGBGroup.TabStop = false;
            extractRGBGroup.Text = "Extract R/G/B";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(betaLabel);
            groupBox2.Controls.Add(alphaBox);
            groupBox2.Controls.Add(betaBox);
            groupBox2.Controls.Add(alphaLabel);
            groupBox2.Controls.Add(gammaBtn);
            groupBox2.Location = new Point(9, 105);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(120, 125);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Apply Gamma";
            // 
            // carouselBtn
            // 
            carouselBtn.Location = new Point(12, 389);
            carouselBtn.Name = "carouselBtn";
            carouselBtn.Size = new Size(109, 29);
            carouselBtn.TabIndex = 32;
            carouselBtn.Text = "Carousel";
            carouselBtn.UseVisualStyleBackColor = true;
            carouselBtn.Click += carouselBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 653);
            Controls.Add(carouselBtn);
            Controls.Add(groupBox2);
            Controls.Add(extractRGBGroup);
            Controls.Add(originalBtn);
            Controls.Add(totalFramesLabel);
            Controls.Add(fpsLabel);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(playPauseBtn);
            Controls.Add(frameLabel);
            Controls.Add(numericUpDown1);
            Controls.Add(loadVideoBtn);
            Controls.Add(videoBox);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(grayscaleBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)videoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            extractRGBGroup.ResumeLayout(false);
            extractRGBGroup.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button grayscaleBtn;
        private Button button3;
        private Button gammaBtn;
        private TextBox alphaBox;
        private TextBox betaBox;
        private Label alphaLabel;
        private Label betaLabel;
        private Button button5;
        private PictureBox videoBox;
        private Button loadVideoBtn;
        private NumericUpDown numericUpDown1;
        private Label frameLabel;
        private Button playPauseBtn;
        private Button button1;
        private Button button2;
        private Button button4;
        private Label fpsLabel;
        private Label totalFramesLabel;
        private Button originalBtn;
        private RadioButton radioButtonNormal;
        private RadioButton radioButtonRed;
        private RadioButton radioButtonGreen;
        private RadioButton radioButtonBlue;
        private GroupBox extractRGBGroup;
        private GroupBox groupBox2;
        private Button carouselBtn;
    }
}