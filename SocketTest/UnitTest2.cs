/*
Author: Vasilica George
Date: 26.05.2024
Acest fișier conține o clasă de teste SocketReceiverTests care utilizează NUnit și Moq pentru a testa funcționalitatea clasei SocketReceiver .
*/
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Reflection;

namespace SocketDLL.Tests
{

    [TestFixture]
    public class SocketReceiverTests : IDisposable
    {
        private TcpClient tcpClient;
        private FieldInfo listeningSocketField;
        private FieldInfo threadField;
        private FieldInfo stringSocketField;
        private MethodInfo receiveMethod;
        private MethodInfo startMethod;
        private bool disposed = false;
        private int port;
        private ManualResetEvent serverStartedEvent;

        [SetUp]
        public void Setup()
        {
            // Initialize TcpClient
            tcpClient = new TcpClient();

            // Reflect necessary fields and methods
            listeningSocketField = typeof(SocketReceiver).GetField("SochetAscultare", BindingFlags.Static | BindingFlags.NonPublic);
            threadField = typeof(SocketReceiver).GetField("FirPrimire", BindingFlags.Static | BindingFlags.NonPublic);
            stringSocketField = typeof(SocketReceiver).GetField("StringSochet", BindingFlags.Static | BindingFlags.NonPublic);
            receiveMethod = typeof(SocketReceiver).GetMethod("PrimesteDate", BindingFlags.Static | BindingFlags.NonPublic);
            startMethod = typeof(SocketReceiver).GetMethod("PornesteServerul", BindingFlags.Static | BindingFlags.Public);

            // Reset fields
            listeningSocketField.SetValue(null, null);
            stringSocketField.SetValue(null, string.Empty);
            threadField.SetValue(null, null);

            // Start server
            serverStartedEvent = new ManualResetEvent(false);
            port = StartServer();
        }

        [TearDown]
        public void Teardown()
        {
            Dispose();
        }

        [Test]
        public void PornesteServerul_InitializesListeningSocketAndStartsThread()
        {
            // Assert
            var listeningSocket = (Socket)listeningSocketField.GetValue(null);
            Assert.That(listeningSocket, Is.Not.Null);
            var thread = (Thread)threadField.GetValue(null);
            Assert.That(thread, Is.Not.Null);
        }

        [Test]
        public void PrimesteDate_ReceivesDataCorrectly()
        {
            // Arrange
            tcpClient.Connect(IPAddress.Loopback, port);
            var stream = tcpClient.GetStream();
            var message = "Hello, SocketReceiver!";
            var data = Encoding.ASCII.GetBytes(message);

            // Act
            stream.Write(data, 0, data.Length);
            var messageReceivedEvent = new ManualResetEvent(false);
            string receivedData = string.Empty;

            // Start a new thread to wait for the data to be received
            new Thread(() =>
            {
                while (true)
                {
                    receivedData = (string)stringSocketField.GetValue(null);
                    if (!string.IsNullOrEmpty(receivedData))
                    {
                        messageReceivedEvent.Set(); // Signal that the message has been received
                        break;
                    }
                }
            }).Start();

            // Assert
            bool eventSignaled = messageReceivedEvent.WaitOne(5000);
            Assert.That(eventSignaled, Is.True);
            Assert.That(receivedData, Contains.Substring(message));
        }

        [Test]
        public void PrimesteDate_HandlesSocketException()
        {
            // Arrange
            StartServer();

            // Act
            Thread.Sleep(100); // Wait for the server to start

            // Simulate a socket exception by closing the client prematurely
            tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Loopback, port);
            tcpClient.Close();

            // Assert
            Thread.Sleep(100); // Wait for the server to process the exception
            var exceptionMessage = (string)typeof(SocketReceiver).GetField("ExceptieSochet", BindingFlags.Static | BindingFlags.Public).GetValue(null);
            Assert.That(exceptionMessage, Is.Not.Empty);
        }

        [Test]
        public void CitesteDate_ReadsAndClearsBuffer()
        {
            // Arrange
            var stringSocketField = typeof(SocketReceiver).GetField("StringSochet", BindingFlags.Static | BindingFlags.NonPublic);
            stringSocketField.SetValue(null, "TestMessage");

            // Act
            var result = typeof(SocketReceiver).GetMethod("CitesteDate", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);

            // Assert
            Assert.That(result, Is.EqualTo("TestMessage"));
            var buffer = (string)stringSocketField.GetValue(null);
            Assert.That(buffer, Is.Empty);
        }

        private int StartServer()
        {
            int port;
            var serverThread = new Thread(() =>
            {
                port = new Random().Next(5000, 6000); // Use a random port
                startMethod.Invoke(null, new object[] { port });
                serverStartedEvent.Set();
            });

            serverThread.Start();
            serverStartedEvent.WaitOne(); // Wait for the server to start

            var listeningSocket = (Socket)listeningSocketField.GetValue(null);
            var endpoint = (IPEndPoint)listeningSocket.LocalEndPoint;
            return endpoint.Port;
        }

        [Test]
        public void PrimesteDate_HandlesClientDisconnection()
        {
            // Arrange
            tcpClient.Connect(IPAddress.Loopback, port);
            var stream = tcpClient.GetStream();
            var message = "Hello, SocketReceiver!";
            var data = Encoding.ASCII.GetBytes(message);

            // Act
            stream.Write(data, 0, data.Length);
            tcpClient.Close(); // Close the client to simulate disconnection
            Thread.Sleep(100); // Wait a bit for server to process

            // Assert
            var receivedData = (string)stringSocketField.GetValue(null);
            Assert.That(receivedData, Contains.Substring(message));
            var exceptionMessage = (string)typeof(SocketReceiver).GetField("ExceptieSochet", BindingFlags.Static | BindingFlags.Public).GetValue(null);
            Assert.That(exceptionMessage, Is.Not.Empty);
        }

        [Test]
        public void PrimesteDate_ReceivesMultipleMessagesCorrectly()
        {
            // Arrange
            tcpClient.Connect(IPAddress.Loopback, port);
            var stream = tcpClient.GetStream();
            var message1 = "Hello, ";
            var message2 = "SocketReceiver!";
            var data1 = Encoding.ASCII.GetBytes(message1);
            var data2 = Encoding.ASCII.GetBytes(message2);

            // Act
            stream.Write(data1, 0, data1.Length);
            var message1ReceivedEvent = new ManualResetEvent(false);
            string receivedData1 = string.Empty;
            new Thread(() =>
            {
                while (true)
                {
                    receivedData1 = (string)stringSocketField.GetValue(null);
                    if (receivedData1.Contains(message1))
                    {
                        message1ReceivedEvent.Set();
                        break;
                    }
                }
            }).Start();

            bool event1Signaled = message1ReceivedEvent.WaitOne(5000);
            Assert.That(event1Signaled, Is.True);
            stream.Write(data2, 0, data2.Length);
            var message2ReceivedEvent = new ManualResetEvent(false);
            string receivedData2 = string.Empty;
            new Thread(() =>
            {
                while (true)
                {
                    receivedData2 = (string)stringSocketField.GetValue(null);
                    if (receivedData2.Contains(message2))
                    {
                        message2ReceivedEvent.Set();
                        break;
                    }
                }
            }).Start();

            bool event2Signaled = message2ReceivedEvent.WaitOne(5000);
            Assert.That(event2Signaled, Is.True);
            var finalReceivedData = (string)stringSocketField.GetValue(null);
            Assert.That(finalReceivedData, Is.EqualTo(message1 + message2));
        }

        public void Dispose()
        {
            if (!disposed)
            {
                listeningSocketField.SetValue(null, null);
                stringSocketField.SetValue(null, string.Empty);
                threadField.SetValue(null, null);
                tcpClient?.Close();
                disposed = true;
            }
        }
    }
}
