using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IP
{

    public class SocketWriter
    {
        private static bool ocupat = false;
        private static Socket SochetTrimitere;
        private static String BufferMesajeTrimitere;
        private static Thread ThreadTrimitere;
        private static void TrimiteDate()
        {
            //ocupat = true;
            while (true)
            {
                if(BufferMesajeTrimitere != "")
                {
                    Console.WriteLine(BufferMesajeTrimitere);
                    BufferMesajeTrimitere = "";
                }
            }
            /*if (SochetTrimitere.Connected)
            {

            }
            else
            {

            }*/
            //ocupat = false;
        }

        public static void WriteToSocket(String mesaj){
            if(ThreadTrimitere == null){
                ThreadTrimitere = new Thread(SocketWriter.TrimiteDate);
                ThreadTrimitere.IsBackground = true;
                ThreadTrimitere.Start();
            }
            BufferMesajeTrimitere += mesaj;
        }
    }
}
