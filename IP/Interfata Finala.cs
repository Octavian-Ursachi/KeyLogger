using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IP
{
    public partial class Interfata_Finala : Form
    {
        private SoundManager BoxaPortabila;
        public Interfata_Finala()
        {
          
            InitializeComponent();
            BoxaPortabila = new SoundManager();
            BoxaPortabila.Play();

            //margine de la butonae facute alba
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.FlatAppearance.BorderSize = 1;
            btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.White;

            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.FlatAppearance.BorderSize = 1;
            btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.White;

            btnMute.FlatStyle = FlatStyle.Flat;
            btnMute.FlatAppearance.BorderSize = 1;
            btnMute.FlatAppearance.BorderColor = System.Drawing.Color.White;

            ////////////////////////////////////////////
        }



        private void Interfata_Finala_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sunet
            if (BoxaPortabila.IsPlaying())
            {
                BoxaPortabila.Stop();
            }
            else
            {
                BoxaPortabila.Resume();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            BoxaPortabila.SetVolume(trackBar1.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
