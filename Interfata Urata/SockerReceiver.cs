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
        private static string StringSochet = "";
        public static string ExceptieSochet = "";
        public static void PornesteServerul()
        {
            SochetAscultare = new Socket(SocketType.Stream, ProtocolType.Tcp);
            SochetAscultare.Bind(new IPEndPoint(IPAddress.Any, 2000));
            SochetAscultare.Listen(1);
            FirPrimire = new Thread(PrimesteDate);
            FirPrimire.IsBackground = true;
            FirPrimire.Start();
        }
        private static void PrimesteDate()
        {
            int i = 0;
            while (true)//Bucla de acceptare de conexiuni
            {
                ExceptieSochet = "Astept conexiune!";
                Socket SochetPrimire = SochetAscultare.Accept();
                SochetPrimire.ReceiveTimeout = 1000;
                while (true)//Bucla de primire de mesaje
                {
                    if(SochetPrimire.Connected == false)
                    {
                        break;
                    }
                    try
                    {
                        byte[] DateSochet = new byte[SochetPrimire.Available];
                        ExceptieSochet = "Sochetu asteapta date!"+i;
                        SochetPrimire.Receive(DateSochet);
                        StringSochet += Encoding.ASCII.GetString(DateSochet);
                        i++;
                    }
                    catch (SocketException e)
                    {
                        SochetPrimire.Send(Encoding.ASCII.GetBytes("stop"));
                        SochetPrimire.Close();
                        ExceptieSochet = e.Message;
                        break;
                    }
                    catch (ObjectDisposedException e)
                    {
                        ExceptieSochet = e.Message;
                        break;
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            }
        }
        public static string CitesteDate()
        {
            if(StringSochet != null)
            {
                string StringAux = StringSochet;
                StringSochet = "";
                return StringAux;
            }
            else
            {
                return "";
            }
        }
    }
}
