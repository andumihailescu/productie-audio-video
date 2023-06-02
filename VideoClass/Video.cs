using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Emgu.CV.Dnn;
using Newtonsoft.Json.Linq;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using System.Security.Cryptography;
//using static System.Net.Mime.MediaTypeNames;

namespace VideoClass
{
    public class VideoEventArgs
    {
        public VideoEventArgs(int totalFrame, int frameNo, double fps, Image currentFrameImage)
        { 
            TotalFrame = totalFrame;
            FrameNo = frameNo;
            Fps = fps;
            CurrentFrameImage = currentFrameImage;
        }
        public int TotalFrame { get; }

        public int FrameNo { get; }
        public double Fps { get; }

        public Image CurrentFrameImage { get; }
        //Aici va adaugati voi frame sau bitmap..sau ce o fi...
    }

    public class Video
    {
        private VideoCapture capture;
        private int totalFrame, frameNo;
        private double fps;
        
        private Image currentFrameImage;
        private Image backupFrameImage;
        
        private int alpha;
        private int beta;

        private bool isReadingFrame;
        private bool isGrayscaleOn;
        private bool isGammaApplied;
        private bool isRed;
        private bool isGreen;
        private bool isBlue;
        private bool carouselMode;

        private int carouselFrameIndex;

        public delegate void VideoEventHandler(object sender, VideoEventArgs e);

        public event VideoEventHandler VideoEvent;

        public void RefreshFrame()
        {
            //do something here
            //Let's raise an event 
            RaiseSampleEvent();
        }

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected void RaiseSampleEvent()
        {
            if (VideoEvent != null)
            {
                VideoEvent.Invoke(this, new VideoEventArgs(this.TotalFrame, this.FrameNo, this.Fps, this.CurrentFrameImage));
            }
        }

        public Video()
        {
            Capture = new VideoCapture();
            TotalFrame = 0;
            FrameNo = 0;
            IsReadingFrame = false;
        }

        public VideoCapture Capture { get => capture; set => capture = value; }
        public int TotalFrame { get => totalFrame; set => totalFrame = value; }
        public int FrameNo { get => frameNo; set => frameNo = value; }
        public double Fps { get => fps; set => fps = value; }
        public bool IsReadingFrame { get => isReadingFrame; set => isReadingFrame = value; }
        public bool IsGrayscaleOn { get => isGrayscaleOn; set => isGrayscaleOn = value; }
        public Image CurrentFrameImage { get => currentFrameImage; set => currentFrameImage = value; }
        public bool IsGammaApplied { get => isGammaApplied; set => isGammaApplied = value; }
        public int Alpha { get => alpha; set => alpha = value; }
        public int Beta { get => beta; set => beta = value; }
        public bool IsRed { get => isRed; set => isRed = value; }
        public bool IsGreen { get => isGreen; set => isGreen = value; }
        public bool IsBlue { get => isBlue; set => isBlue = value; }
        public bool CarouselMode { get => carouselMode; set => carouselMode = value; }
        public int CarouselFrameIndex { get => carouselFrameIndex; set => carouselFrameIndex = value; }
        public Image BackupFrameImage { get => backupFrameImage; set => backupFrameImage = value; }

        private void ResetFlags()
        {
            IsGrayscaleOn = false;
            IsGammaApplied = false;
            IsRed = false;
            IsGreen = false;
            IsBlue = false;
            CarouselMode = false;
            CarouselFrameIndex = 0;
        }

        public void LoadVideo(string videoFileName)
        {
            ResetFlags();

            Capture = new VideoCapture(videoFileName);
            Mat m = new Mat();
            Capture.Read(m);

            CurrentFrameImage = m.ToImage<Bgr, Byte>().ToBitmap();
            BackupFrameImage = (Image)CurrentFrameImage.Clone();

            totalFrame = (int)Capture.Get(CapProp.FrameCount);
            fps = Capture.Get(CapProp.Fps);
            frameNo = 1;
        }

        public async void ReadAllFrames()
        {
            while (VideoIsPlaying() == true && FrameNo < TotalFrame)
            {
                FrameNo += 1;
                Mat m = Capture.QueryFrame();

                CurrentFrameImage = m.ToImage<Bgr, Byte>().ToBitmap();
                BackupFrameImage = (Image)CurrentFrameImage.Clone();
                if (IsGrayscaleOn == true)
                {
                    ConvertFrameToGrayscale();
                }
                if (IsGammaApplied == true)
                {
                    ApplyGammaToFrame();
                }
                if (IsRed == true)
                {
                    ConvertFrameToRed();
                }
                if (IsGreen == true)
                {
                    ConvertFrameToGreen();
                }
                if (IsBlue == true)
                {
                    ConvertFrameToBlue();
                }
                if (CarouselMode == true)
                {
                    ApplyCarouselToFrame();
                }
                RefreshFrame();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
            }
        }

        public bool VideoIsPlaying()
        {
            if (IsReadingFrame == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlayVideo()
        {
            if (Capture == null)
            {
                return;
            }
            IsReadingFrame = true;
            ReadAllFrames();
        }
        public void PauseVideo()
        {
            IsReadingFrame = false;
        }

        public void ConvertToOriginal()
        {
            ResetFlags();
            ConvertFrameToOriginal();
        }

        private void ConvertFrameToOriginal()
        {
            CurrentFrameImage = (Image)BackupFrameImage.Clone();
        }

        public void ConvertToGrayscale()
        {
            IsGrayscaleOn = true;
            ConvertFrameToGrayscale();
        }

        private void ConvertFrameToGrayscale()
        {
            Image<Gray, byte> tempImage = new Bitmap(CurrentFrameImage).ToImage<Gray, byte>();
            CurrentFrameImage = tempImage.ToBitmap();
        }

        public void ApplyGamma(int alpha, int beta)
        {
            this.alpha = alpha;
            this.beta = beta;
            IsGammaApplied = true;
            ApplyGammaToFrame();
        }

        private void ApplyGammaToFrame()
        {
            Image<Bgr, byte> tempImage = new Bitmap(CurrentFrameImage).ToImage<Bgr, byte>();
            CurrentFrameImage = (tempImage.Mul(alpha) + beta).ToBitmap();
        }

        public void ConvertToRed()
        {
            IsRed = true;
            IsGreen = false;
            IsBlue = false;
            ConvertFrameToNormal();
            ConvertFrameToRed();
        }

        public void ConvertToGreen()
        {
            IsRed = false;
            IsGreen = true;
            IsBlue = false;
            ConvertFrameToNormal();
            ConvertFrameToGreen();
        }

        public void ConvertToBlue()
        {
            IsRed = false;
            IsGreen = false;
            IsBlue = true;
            ConvertFrameToNormal();
            ConvertFrameToBlue();
        }

        public void ConvertToNormal()
        {
            IsRed = false;
            IsGreen = false;
            IsBlue = false;
            ConvertFrameToNormal();
        }

        private void ConvertFrameToRed()
        {
            Image<Bgr, byte> originalImage = new Bitmap(CurrentFrameImage).ToImage<Bgr, byte>();
            Image<Gray, byte> redChannel = originalImage.Split()[2];
            Image<Bgr, byte> outputImage = new Image<Bgr, byte>(redChannel.Width, redChannel.Height);
            outputImage.SetValue(new Bgr(0, 0, 0));
            outputImage[2] = redChannel;
            CurrentFrameImage = outputImage.ToBitmap();
        }

        private void ConvertFrameToGreen()
        {
            Image<Bgr, byte> originalImage = new Bitmap(CurrentFrameImage).ToImage<Bgr, byte>();
            Image<Gray, byte> greenChannel = originalImage.Split()[1];
            Image<Bgr, byte> outputImage = new Image<Bgr, byte>(greenChannel.Width, greenChannel.Height);
            outputImage.SetValue(new Bgr(0, 0, 0));
            outputImage[1] = greenChannel;
            CurrentFrameImage = outputImage.ToBitmap();
        }

        private void ConvertFrameToBlue()
        {
            Image<Bgr, byte> originalImage = new Bitmap(CurrentFrameImage).ToImage<Bgr, byte>();
            Image<Gray, byte> blueChannel = originalImage.Split()[0];
            Image<Bgr, byte> outputImage = new Image<Bgr, byte>(blueChannel.Width, blueChannel.Height);
            outputImage.SetValue(new Bgr(0, 0, 0));
            outputImage[0] = blueChannel;
            CurrentFrameImage = outputImage.ToBitmap();
        }

        private void ConvertFrameToNormal()
        {
            CurrentFrameImage = (Image)BackupFrameImage.Clone();
        }

        public void ApplyCarousel()
        {
            CarouselMode = true;
            IsGrayscaleOn = false;
            IsGammaApplied = false;
            IsRed = false;
            IsGreen = false;
            IsBlue = false;
            ApplyCarouselToFrame();
        }

        private void ApplyCarouselToFrame()
        {
            switch (CarouselFrameIndex)
            {
                case 0:
                    ConvertFrameToGrayscale();
                    break;
                case 1:
                    ConvertFrameToRed();
                    break;
                case 2:
                    ConvertFrameToGreen();
                    break;
                case 3:
                    ConvertFrameToBlue();
                    break;
            }

            CarouselFrameIndex++;
            CarouselFrameIndex %= 4;
        }
    }
}
