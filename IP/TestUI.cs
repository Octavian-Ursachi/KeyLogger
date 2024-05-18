using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace IP
{
    public partial class TestUI : Form
    {
        LoggerWriter log;
        SoundManager player;
        public TestUI(LoggerWriter log)
        {
            player = new SoundManager();
            this.log = log;
            InitializeComponent();    
            KeyText.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.SetStrategy(new VKCodeStrategy());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.SetStrategy(new ToStringStrategy());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.SetStrategy(new ToCharStrategy());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log.SetStrategy(new SmartStrategy());
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(Music.Checked) 
                player.Play();
            else
                player.Mute();
        }

        /* TODO : SetVolume based on volume bar */
    }
}
