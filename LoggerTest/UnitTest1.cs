using Moq;
using NUnit.Framework;

namespace LoggerTest
{
    public interface ILogWriter
    {
        void WriteToLog(int vkCode, string path, string text);
    }
    public class VKHandler
    {
        private readonly ILogWriter _writer;

        public VKHandler(ILogWriter writer)
        {
            _writer = writer;
        }

        public void HandleVK(int vkCode, string path, string text)
        {
            _writer.WriteToLog(vkCode, path, text);
        }
    }
    public class Tests
    {
        [TestFixture]
        public class VKHandlerTests
        {
            private Mock<ILogWriter> mockWriter;
            private VKHandler handler;

            [SetUp]
            public void Setup()
            {
                mockWriter = new Mock<ILogWriter>();
                handler = new VKHandler(mockWriter.Object);
            }

            [Test]
            public void HandleVK_CallsWriteToLog_WithCorrectParameters()
            {
                // Arrange
                int vkCode = 65; // Example VK code
                string path = "log.txt";
                string textBox = "Sample text";

                // Act
                handler.HandleVK(vkCode, path, textBox);

                // Assert
                mockWriter.Verify(w => w.WriteToLog(vkCode, path, textBox), Times.Once);
            }
        }
    }
}