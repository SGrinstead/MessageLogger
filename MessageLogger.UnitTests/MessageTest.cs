namespace MessageLogger.UnitTests
{
    public class MessageTest   
    {
        [Fact]
        public void Message_Constructor_InitializesProperties()
        {
            Message message = new Message("Test message");

            Assert.Equal("Test message", message.Content);
            Assert.Equal(DateTime.Now.ToString("t"), message.CreatedAt.ToString("t"));
        }

        [Fact]
        public void Message_ToString_ReturnsCustomString()
        {
            Message message = new Message("Test message");

            Assert.Equal($"{message.CreatedAt.ToString("t")}: {message.Content}", message.ToString());
        }
    }
}