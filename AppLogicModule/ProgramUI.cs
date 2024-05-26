/*
* Functionality: This class serves as the entry point for the user interface application. It initializes the main UI and installs a low-level keyboard hook.
*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HookDLL;
using UIModule;

namespace AppLogicModule
{
    public class ProgramUI
    {
        public static void Main()
        {
            Interfata_Finala UI = new Interfata_Finala();
            LLKeyboardHook hook = new LLKeyboardHook();

            hook.Install();

            Application.EnableVisualStyles();
            Application.Run(UI);

            hook.Uninstall();

        }
    }


}
