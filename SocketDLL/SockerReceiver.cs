/*
* Author: Stoica Viorel
* Date: 26.05.2024
* Functionality: This class implements a socket receiver that listens for incoming TCP connections and receives data.
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
                        ExceptieSochet = "Sochetu asteapta date!";
                        SochetPrimire.Receive(DateSochet);
                        StringSochet += Encoding.ASCII.GetString(DateSochet);
                    }
                    catch (SocketException e)
                    {
                        try
                        {
                            SochetPrimire.Send(Encoding.ASCII.GetBytes("stop"));
                        }
                        catch (SocketException) {
                            ExceptieSochet = "Clientul a inchis conexiunea!";
                        }
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
