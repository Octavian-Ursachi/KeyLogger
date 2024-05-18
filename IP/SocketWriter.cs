using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private static string BufferMesajeTrimitere;
        private static Thread ThreadTrimitere;
        private static void TrimiteDate()
        {
            while (true)
            {
                if (BufferMesajeTrimitere != "")
                {
                    if(SochetTrimitere == null)
                    {
                        SochetTrimitere = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    }
                    else
                    {
                        if (SochetTrimitere.IsBound == false)
                        {
                            SochetTrimitere.Bind(new IPEndPoint(IPAddress.Any, 0));
                        }
                        else
                        {
                            try
                            {
                                if (SochetTrimitere.Connected == false)
                                {
                                    SochetTrimitere.Connect(new IPEndPoint(new IPAddress(0x0100007f), 8085));
                                    Console.WriteLine("Conectat remote >=)");
                                }
                                else
                                {
                                    SochetTrimitere.Send(Encoding.ASCII.GetBytes(BufferMesajeTrimitere));
                                    BufferMesajeTrimitere = "";
                                }
                            }
                            catch(SocketException e)
                            {
                                Console.WriteLine("Nu m-am conectat remote pentru ca: "+e.Message);
                            }
                            catch(InvalidOperationException e)
                            {
                                Console.WriteLine("Refac sochetul pentru ca: "+e.Message);
                                SochetTrimitere = new Socket(SocketType.Stream, ProtocolType.Tcp);
                            }
                        }
                    }
                }
            }
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
