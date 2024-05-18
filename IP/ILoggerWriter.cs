using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP
{
    public interface ILoggerWriter
    {
        void WriteToLog(int vkCode, String path, TestUI form);

    }
}
