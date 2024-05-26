/*
Author: Vasilica George
Date: 26.05.2024
Acest fișier conține o clasă de teste SocketWriterTests care utilizează NUnit și Moq pentru a testa funcționalitatea clasei SocketWriter.
*/
using NUnit.Framework;
using Moq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SocketDLL.Tests
{
    [TestFixture]
    public class SocketWriterTests
    {
        private Mock<Socket> mockSocket;
        private FieldInfo socketField;
        private FieldInfo bufferField;
        private FieldInfo threadField;
        private MethodInfo threadMethod;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock socket
            mockSocket = new Mock<Socket>(SocketType.Stream, ProtocolType.Tcp);
            socketField = typeof(SocketWriter).GetField("SochetTrimitere", BindingFlags.Static | BindingFlags.NonPublic);
            bufferField = typeof(SocketWriter).GetField("BufferMesajeTrimitere", BindingFlags.Static | BindingFlags.NonPublic);
            threadField = typeof(SocketWriter).GetField("ThreadTrimitere", BindingFlags.Static | BindingFlags.NonPublic);
            threadMethod = typeof(SocketWriter).GetMethod("TrimiteDate", BindingFlags.Static | BindingFlags.NonPublic);

            // Reset fields
            socketField.SetValue(null, mockSocket.Object);
            bufferField.SetValue(null, string.Empty);
            threadField.SetValue(null, null);
        }

        [Test]
        public void WriteToSocket_InitializesThreadAndAddsMessageToBuffer()
        {
            // Act
            SocketWriter.WriteToSocket("TestMessage");

            // Assert
            var buffer = (string)bufferField.GetValue(null);
            Assert.That(buffer, Is.EqualTo("TestMessage "));
            var thread = (Thread)threadField.GetValue(null);
            Assert.That(thread, Is.Not.Null);
        }

        [Test]
        public void WriteToSocket_InitializesAndStartsThread()
        {
            // Act
            SocketWriter.WriteToSocket("TestMessage");

            // Assert
            var buffer = (string)bufferField.GetValue(null);
            Assert.That(buffer, Is.EqualTo("TestMessage "));
            var thread = (Thread)threadField.GetValue(null);
            Assert.That(thread, Is.Not.Null);
            Assert.That(thread.IsAlive, Is.True);
        }
        [Test]
        public void WriteToSocket_InitializesEmpty()
        {
            // Act
            SocketWriter.WriteToSocket("");

            // Assert
            var buffer = (string)bufferField.GetValue(null);
            Assert.That(buffer, Is.EqualTo(" "));
            var thread = (Thread)threadField.GetValue(null);
            Assert.That(thread, Is.Not.Null);
            Assert.That(thread.IsAlive, Is.True);
        }



        private void SetSocketConnected(bool connected)
        {
            var connectedField = typeof(Socket).GetProperty("Connected", BindingFlags.Instance | BindingFlags.NonPublic);
            if (connectedField != null)
            {
                connectedField.SetValue(mockSocket.Object, connected, null);
            }
        }
    }
}
