using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using VideoClass;
using AudioClass;

namespace ProductieAudioVideo
{
    public partial class Form1 : Form
    {
        private Image<Bgr, Byte> Initial_Image;
        private Image<Bgr, Byte> Final_Image;

        private Video video;

        public delegate void CurrentFrameHandler(object sender, EventArgs e);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            video = new Video();
        }

        private void enableRgbRadioButtons()
        {
            radioButtonNormal.Checked = true;
            radioButtonRed.Enabled = true;
            radioButtonGreen.Enabled = true;
            radioButtonBlue.Enabled = true;
            radioButtonNormal.Enabled = true;
        }

        private void disableRgbRadioButtons()
        {
            radioButtonNormal.Checked = true;
            radioButtonRed.Enabled = false;
            radioButtonGreen.Enabled = false;
            radioButtonBlue.Enabled = false;
            radioButtonNormal.Enabled = false;
        }

        private void originalBtn_Click(object sender, EventArgs e)
        {
            enableRgbRadioButtons();
            video.ConvertToOriginal();
            video.RefreshFrame();
        }

        private void grayscaleBtn_Click(object sender, EventArgs e)
        {
            disableRgbRadioButtons();
            video.ConvertToGrayscale();
            video.RefreshFrame();
        }

        //Histogram
        /*private void button3_Click(object sender, EventArgs e)
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(Initial_Image, 255);
            v.Show();
        }*/

        private void gammaBtn_Click(object sender, EventArgs e)
        {
            int alpha;
            int beta;
            if (!string.IsNullOrEmpty(alphaBox.Text) && !string.IsNullOrEmpty(betaBox.Text))
            {
                alpha = Convert.ToInt16(alphaBox.Text);
                beta = Convert.ToInt16(betaBox.Text);
                disableRgbRadioButtons();
                video.ApplyGamma(alpha, beta);
                video.RefreshFrame();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Initial_Image._GammaCorrect(0.5);
            //pictureBox3.Image = Initial_Image.ToBitmap();

            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(Initial_Image, 255);
            v.Show();
        }

        private void loadVideoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string videoFileName = ofd.FileName;
                video.LoadVideo(videoFileName);
            }
            video.VideoEvent += DisplayFrame;
            video.RefreshFrame();
            enableRgbRadioButtons();
        }

        private void DisplayFrame(object sender, VideoEventArgs e)
        {
            videoBox.Image = e.CurrentFrameImage;

            frameLabel.Text = "Current frame: " + e.FrameNo;
            totalFramesLabel.Text = "Total frames: " + e.TotalFrame;
            fpsLabel.Text = "Video frame rate: " + e.Fps;

            numericUpDown1.Value = e.FrameNo;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = e.TotalFrame;
        }

        private void playPauseBtn_Click(object sender, EventArgs e)
        {
            if (video.VideoIsPlaying() == true)
            {
                video.PauseVideo();

                playPauseBtn.Text = "Play Video";
            }
            else
            {
                video.PlayVideo();

                playPauseBtn.Text = "Pause Video";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string[] FileNames = Directory.GetFiles(@"D:\School\Productie Audio Video\Laborator2\Laborator2\Images", "*.png");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    //beforeImg.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4");

            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);


            string destionpath = @"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\Video with logo.mp4";
            using (VideoWriter writer = new VideoWriter(destionpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                Image<Bgr, byte> logo = new Image<Bgr, byte>(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\logo.png");
                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(Width - logo.Width - 30, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            VideoCapture capture1 = new VideoCapture(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\Dip BW\First Video Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4");
            VideoCapture capture2 = new VideoCapture(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\Dip BW\SecondVideo.mp4");

            int Fourcc = Convert.ToInt32(capture1.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture1.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture1.Get(CapProp.FrameHeight));
            var Fps = capture1.Get(CapProp.Fps);
            var TotalFrame1 = capture1.Get(CapProp.FrameCount);
            var TotalFrame2 = capture2.Get(CapProp.FrameCount);
            var TotalFrames = TotalFrame1 + TotalFrame2;


            string destionpath = @"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\Dip BW\Transition.mp4";
            using (VideoWriter writer = new VideoWriter(destionpath, Fourcc, Fps, new Size(Width, Height), true))
            {

                Image<Bgr, byte> white = new Image<Bgr, byte>(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\logo.png");
                Image<Bgr, byte> black = new Image<Bgr, byte>(@"D:\School\Productie Audio Video\Laborator2\Laborator2\AviTest\logo.png");
                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame1)
                {
                    capture1.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    /*img.ROI = new Rectangle(Width - black.Width - 30, 10, black.Width, black.Height);
                    black.CopyTo(img);

                    img.ROI = Rectangle.Empty;*/

                    writer.Write(img.Mat);
                    FrameNo++;
                }

                FrameNo = 1;

                while (FrameNo < TotalFrame2)
                {
                    capture2.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    /*img.ROI = new Rectangle(Width - black.Width - 30, 10, black.Width, black.Height);
                    black.CopyTo(img);

                    img.ROI = Rectangle.Empty;*/

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }
        }

        private void extractColorChannel(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            switch (radioButton.Name)
            {
                case "radioButtonRed":
                    video.ConvertToRed();
                    break;
                case "radioButtonGreen":
                    video.ConvertToGreen();
                    break;
                case "radioButtonBlue":
                    video.ConvertToBlue();
                    break;
                case "radioButtonNormal":
                    video.ConvertToNormal();
                    break;
            }
            video.RefreshFrame();
        }

        private void carouselBtn_Click(object sender, EventArgs e)
        {
            disableRgbRadioButtons();
            video.ApplyCarousel();
            video.RefreshFrame();
        }
    }
}