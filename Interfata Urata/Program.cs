using IP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfata_Urata
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerWriter log = new LoggerWriter();
            InterfataSimpla UI = new InterfataSimpla(log);
            SocketReceiver.PornesteServerul();
            Application.EnableVisualStyles();
            Application.Run(UI);
        }
    }
}
