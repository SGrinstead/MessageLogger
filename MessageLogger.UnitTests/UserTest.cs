using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger.UnitTests
{
    public class UserTest
    {
        [Fact]
        public void User_Constructor_InitializesProperties()
        {
            User user = new User("Seth", "sgrinstead");

            Assert.Equal("Seth", user.Name);
            Assert.Equal("sgrinstead", user.Username);
            Assert.Equal(new List<Message>(), user.Messages);
        }

        [Fact]
        public void User_AddMessage_AddsMessageToMessagesList()
        {
            User user = new User("Seth", "sgrinstead");
            user.AddMessage("Hello World");

            Assert.Equal("Hello World", user.Messages[0].Content);
        }
    }
}
