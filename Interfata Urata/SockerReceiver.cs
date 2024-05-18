using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interfata_Urata
{
    public class SocketReceiver
    {
        private static Socket SochetAscultare;
        private static Thread FirPrimire;
        private static byte[] DateSochet;
        public static void PornesteServerul()
        {
            SochetAscultare = new Socket(SocketType.Stream, ProtocolType.Tcp);
            SochetAscultare.Bind(new IPEndPoint(IPAddress.Any, 8000));
            SochetAscultare.Listen(1);
            FirPrimire = new Thread(SocketReceiver.PrimesteDate);
            FirPrimire.IsBackground = true;
            FirPrimire.Start();
        }
        private static void PrimesteDate()
        {
            while (true)//Bucla de acceptare de conexiuni
            {
                Socket SochetPrimire = SochetAscultare.Accept();
                while (true)//Bucla de primire de mesaje
                {
                    DateSochet = new byte[SochetPrimire.Available];
                    SochetPrimire.Receive(DateSochet);
                    Console.WriteLine(DateSochet.ToString());
                    DateSochet = null;
                }
            }
        }
    }
}
