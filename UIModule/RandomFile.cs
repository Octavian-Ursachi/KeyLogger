using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIModule
{
    public class RandomFile
    {
        static String[] OperationNames = {"Installing", "Extracting", "Copying", "Moving", "Verifying"};
        static String[] NumberedFileNames = { "soundbank", "sound", "asset", "level", "animation", "texture" };
        static Random Generator = new Random();
        public static String GetName()
        {
            return OperationNames[Generator.Next(5)] + " " + NumberedFileNames[Generator.Next(6)] + Generator.Next(1000)+Environment.NewLine;
        }
    }
}
