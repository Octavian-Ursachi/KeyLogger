using Interfata_Urata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP
{
    public interface ILoggerWriter
    {
        void WriteToLog(int vkCode, String path, InterfataSimpla form);

    }
}
