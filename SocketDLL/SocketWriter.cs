/*
Author: Stoica Viorel
Date: 26.05.2024
Functionality: This class implements a socket writer that sends messages over TCP/IP.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketDLL
{

    public class SocketWriter
    {
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
                    if (SochetTrimitere.IsBound == false)
                    {
                        SochetTrimitere.Bind(new IPEndPoint(IPAddress.Any, 0));
                        Console.WriteLine("incerc sa ma conectez..");
                    }
                    
                    try
                    {
                        if (SochetTrimitere.Connected == false)
                        {
                            //ip loopback 0x0100007f
                            //ip steam deck 0x4f703ef3, oglindit 0xf33e704f
                            SochetTrimitere.Connect(new IPEndPoint(new IPAddress(0xf33e704f), 2000));
                            Console.WriteLine("Conectat remote >=)");
                        }
                            if (SochetTrimitere.Connected == false || SochetTrimitere.Available > 0)
                        {
                            Console.WriteLine("Am inchis sochetul!");
                            SochetTrimitere.Close();
                            SochetTrimitere = null;
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
                        SochetTrimitere.Close();
                        SochetTrimitere = null;
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Refac sochetul pentru ca: "+e.Message);
                        SochetTrimitere.Close();
                        SochetTrimitere = null;
                        //SochetTrimitere = new Socket(SocketType.Stream, ProtocolType.Tcp);
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
            BufferMesajeTrimitere += mesaj+" ";
        }
    }
}
