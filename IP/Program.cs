using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP
{
    class Keylogger
    {
        [STAThread]
        static void Main(string[] args)
        {
            LoggerWriter logger = new LoggerWriter();
            Interfata_Finala UI = new Interfata_Finala();
            //LLKeyboardHook hook = new LLKeyboardHook(UI, logger);

            //hook.Install();

            Application.EnableVisualStyles();
            Application.Run(UI);

            //hook.Uninstall();

        }
    }


}
