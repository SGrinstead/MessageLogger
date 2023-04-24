using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger.UnitTests
{
    public class MessageManagerTest
    {
        [Fact]
        public void MessageManager_Constructor_InitializesProperties()
        {
            MessageManager messageManager = new MessageManager();

            Assert.Equal(new List<User>(), messageManager.Users);
        }

        [Fact]
        public void MessageManager_AddUser_AddsUserToList()
        {
            MessageManager messageManager = new MessageManager();
            User user = new User("Seth", "sgrinstead");

            messageManager.AddUser(user);

            Assert.Equal(user, messageManager.Users[0]);
        }

        [Fact]
        public void MessageManager_GetUser_ReturnsUserWithUsernameOrFalse()
        {
            MessageManager messageManager = new MessageManager();
            User user = new User("Seth", "sgrinstead");
            messageManager.AddUser(user);

            Assert.Equal(user, messageManager.GetUser("sgrinstead"));
            Assert.False(messageManager.GetUser("john"));
        }

        [Fact]
        public void MessageManager_AllMessages_ReturnsListOfAllMessagesFromAllUsers()
        {
            MessageManager messageManager = new MessageManager();
            User user = new User("Seth", "sgrinstead");
            User user2 = new User("John", "jmoney");
            user.AddMessage("hello");
            user2.AddMessage("hey");
            messageManager.AddUser(user);
            messageManager.AddUser(user2);

            Assert.Equal(2, messageManager.AllMessages().Count);
        }

        [Fact]
        public void MessageManager_RecentMessages_ReturnsNumMostRecentMessages()
        {
            MessageManager messageManager = new MessageManager();
            User user = new User("Seth", "sgrinstead");
            User user2 = new User("John", "jmoney");
            User user3 = new User("Megan", "mmcmahon");
            user3.AddMessage("Hello Universe!");
            user.AddMessage("hello");
            user2.AddMessage("hey");
            messageManager.AddUser(user);
            messageManager.AddUser(user2);
            messageManager.AddUser(user3);

            var recent2 = messageManager.RecentMessages(2);

            Assert.Equal(2, recent2.Count);
            Assert.Equal("hello", recent2[0].Content);
            Assert.Equal("hey", recent2[1].Content);
        }
    }
}
