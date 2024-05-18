using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace IP
{
    class SoundManager
    {
        private MediaPlayer player;

        public SoundManager() 
        {
            player = new MediaPlayer();
            String path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            player.Open(new Uri(path + @"\IP\res\ElectronicBoom.wav"));
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
            player.Stop();
        }

        public void Play()
        {
            player.Volume = 1/100.0f;
            try
            {
                player.Play();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
                
        }
    }
}
