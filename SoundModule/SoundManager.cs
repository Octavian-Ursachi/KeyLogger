/*
* Author: Ursachi Octavian
* Date: 26.05.2024
* Functionality: This class is responsible for managing the playback of sound files. It supports operations 
* such as play, stop, resume, mute, and setting volume. The sound files are embedded resources within the DLL.
*/



using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;

namespace SoundModule
{
    public class SoundManager
    {
        private MediaPlayer player;
        private bool isPlaying;

        public SoundManager()
        {
            player = new MediaPlayer();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SoundModule.res.ElectroBoomVice.mp3";

            // Create a temporary file to hold the embedded resource
            var tempFile = Path.Combine(Path.GetTempPath(), "ElectroBoomVice.mp3");
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            using (FileStream fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
            {
                resourceStream.CopyTo(fileStream);
            }

            player.Open(new Uri(tempFile));
        }

        public void SetVolume(int volume)
        {
            if (volume < 0 || volume > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0 and 100.");
            }
            player.Volume = volume / 100.0f;
        }

        public void Mute()
        {
            player.Volume = 0;
        }

        public void Stop()
        {
            player.Pause();
            isPlaying = false;
        }

        public void Resume()
        {
            if (!isPlaying)
            {
                player.Play();
                isPlaying = true;
            }
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }

        public void Play()
        {
            player.Volume = 0.3f; // 30%
            try
            {
                player.Play();
                isPlaying = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}
