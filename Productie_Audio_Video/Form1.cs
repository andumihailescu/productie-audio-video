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
        private Video video;
        private Audio audio;

        public delegate void CurrentFrameHandler(object sender, EventArgs e);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            video = new Video();
            audio = new Audio();
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

        private void loadAudioBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string audioFileName = ofd.FileName;
                audio.LoadAudio(audioFileName);
            }
            audio.AudioEvent += ResetPlayPauseButton;

        }

        private void ResetPlayPauseButton(object sender, AudioEventArgs e)
        {
            if (e.HasFinished == true)
            {
                audio.IsPlayingAudio = false;
                playPauseAudioBtn.Text = "Play Audio";
            }
        }

        private void playPauseAudioBtn_Click(object sender, EventArgs e)
        {
            if (audio.IsPlayingAudio == true)
            {
                audio.IsPlayingAudio = false;
                audio.PauseAudio();
                playPauseAudioBtn.Text = "Play Audio";
            }
            else
            {
                audio.PlayAudio();
                audio.IsPlayingAudio = true;
                playPauseAudioBtn.Text = "Pause Audio";
            }
        }
    }
}