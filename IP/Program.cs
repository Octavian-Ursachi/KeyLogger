/*
 * Main entry for user interface
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogicModule;

namespace IP
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            AppLogicModule.ProgramUI.Main();
        }
    }
}
