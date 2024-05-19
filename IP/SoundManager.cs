using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace IP
{
    class SoundManager
    {
        private MediaPlayer player;
        private bool stare;
        public SoundManager() 
        {
            player = new MediaPlayer();
            String path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            player.Open(new Uri(path + @"\IP\res\ElectroBoomVice.mp3"));
        }
        //C:\Users\ursac\source\repos\IP\IP\res\ElectronicBoom.wav

        public void SetVolume(int volume)
        {
            player.Volume = volume / 100.0f;
        }

        public void Mute()
        {
            player.Volume = 0;
        }

        public void Stop()
        {
            player.Pause();
            stare = false;
        }
        public void Resume()
        {
            player.Play();
            stare = true;
        }
        public bool IsPlaying()
        {
            return stare;
        }

        public void Play()
        {
            player.Volume = 30/100.0f;
            try
            {
                player.Play();
                stare = true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
                
        }
    }
}
