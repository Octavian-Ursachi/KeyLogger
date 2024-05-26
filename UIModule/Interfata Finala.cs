/*
 * Author: Serediuc Andrei-Gheorghe
 * Date : 26.05.2024
 */


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
using SoundModule;


namespace UIModule
{
    public partial class Interfata_Finala : Form
    {
        private SoundManager BoxaPortabila;

        private Timer timer;
        private int elapsedSeconds;
        private int totalSeconds = new Random().Next(120, 500);

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
            ///

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            textBox1.Text = "C:\\Program Files";
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Incrementare secunde trecute
            elapsedSeconds++;

            // Calculează progresul
            int progress = (int)((double)elapsedSeconds / totalSeconds * 100);

            // Actualizează progress bar-ul
            progressBar1.Value = Math.Min(progress, 100);

            int SecondsLeft = totalSeconds - elapsedSeconds;
            int MinutesLeft =  (int)Math.Floor((double)SecondsLeft / (double)60);
            if (MinutesLeft >= 1)
            {
                TimeLeftLabel.Text = MinutesLeft.ToString()+" minutes and "+SecondsLeft%60+" seconds left";
            }
            else
            {
                TimeLeftLabel.Text = SecondsLeft.ToString() + " seconds left";
            }
            // Oprește timer-ul când progresul este complet
            if (elapsedSeconds >= totalSeconds)
            {
                timer.Stop();
                TimeLeftLabel.Text = "Install Complete";
                MessageBox.Show("Installation complete!");
            }

            //Updateaza textul de progres
            textBox2.AppendText(RandomFile.GetName());
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
            btnInstall.Enabled = false;
            btnInstall.Text = "Installing";
            btnInstall.BackColor = SystemColors.ControlDarkDark;

            checkBox1.Enabled = false;
            checkBox1.BackColor = SystemColors.ControlDarkDark;

            textBox1.Enabled = false;
            btnBrowse.Enabled = false;
            btnBrowse.BackColor = SystemColors.ControlDarkDark;
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sunet
            if (BoxaPortabila.IsPlaying())
            {
                BoxaPortabila.Mute();
                btnMute.Text = "UNMUTE";
            }
            else
            {
                BoxaPortabila.Unmute();
                btnMute.Text = "MUTE";
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
            
        }
    }
}
