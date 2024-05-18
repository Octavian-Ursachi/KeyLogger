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
        private static ILoggerWriter _writer = new VKCodeStrategy();

        void SetForm(TestUI form)
        {

        }

        public void SetStrategy(ILoggerWriter strategy)
        {
            _writer = strategy;
        }
        public void HandleVK(int vkCode, String path, TestUI form)
        {
            _writer.WriteToLog(vkCode, path, form);
        }
    }

    public class VKCodeStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            Console.WriteLine(vkCode);
            form.KeyText.AppendText(vkCode+"");
            
        }
    }

    public class ToStringStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            Console.WriteLine((Keys)vkCode);
            form.KeyText.AppendText((Keys)vkCode+"");
        }
    }

    public class ToCharStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form )
        {
            Console.WriteLine((char)vkCode);
            form.KeyText.AppendText((char)vkCode+"");
        }
    }
}
