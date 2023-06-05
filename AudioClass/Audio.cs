using NAudio.Wave.SampleProviders;
using NAudio.Wave;

namespace AudioClass
{
    public class AudioEventArgs
    {
        public AudioEventArgs(bool hasFinished)
        {
            HasFinished = hasFinished;
        }

        public bool HasFinished { get; }
    }

    public class Audio
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private bool isPlayingAudio;
        private bool hasFinished;
        private string currentAudioFileName;

        public bool IsPlayingAudio { get => isPlayingAudio; set => isPlayingAudio = value; }
        public bool HasFinished { get => hasFinished; set => hasFinished = value; }
        public string CurrentAudioFileName { get => currentAudioFileName; set => currentAudioFileName = value; }

        public delegate void AudioEventHandler(object sender, AudioEventArgs e);

        public event AudioEventHandler AudioEvent;

        public void RaiseAudioEvent()
        {
            RaiseSampleEvent();
        }

        protected void RaiseSampleEvent()
        {
            if (AudioEvent != null)
            {
                AudioEvent.Invoke(this, new AudioEventArgs(this.HasFinished));
            }
        }

        public Audio()
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;
        }

        public void LoadAudio(string audioFilename)
        {
            HasFinished = false;
            CurrentAudioFileName = audioFilename;
            audioFile = new AudioFileReader(CurrentAudioFileName);
            outputDevice.Init(audioFile);
        }

        public void PlayAudio()
        {
            if (HasFinished == true)
            {
                audioFile = new AudioFileReader(CurrentAudioFileName);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        public void PauseAudio()
        {
            outputDevice.Pause();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            HasFinished = true;
            RaiseAudioEvent();
        }
    }
}