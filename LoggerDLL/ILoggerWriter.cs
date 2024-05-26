using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerDLL
{
    public interface ILoggerWriter
    {
        void WriteToLog(int vkCode, string path, TextBox text);
    }
}
