using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggerDLL;
using SocketDLL;
using UIModule;

namespace AppLogicModule
{
    public static class ProgramAI
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            LoggerWriter log = new LoggerWriter();
            InterfataSimpla UI = new InterfataSimpla(log);
            SocketReceiver.PornesteServerul();
            Application.EnableVisualStyles();
            Application.Run(UI);
        }
    }
}
