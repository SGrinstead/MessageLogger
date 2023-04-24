using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger
{
    public class MessageManager
    {
        public List<User> Users;

        public MessageManager()
        {
            Users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public dynamic GetUser(string username)
        {
            foreach(var user in Users)
            {
                if(username == user.Username)
                {
                    return user;
                }
            }
            return false;
        }

        public void MessageCount()
        {
            foreach(var user in Users)
            {
                Console.WriteLine($"{user.Name} wrote {user.Messages.Count} messages.");
            }
        }

        public List<Message> AllMessages()
        {
            List<Message> messages = new List<Message>();
            foreach(var user in Users)
            {
                messages.AddRange(user.Messages);
            }
            return messages;
        }

        public List<Message> RecentMessages(int num)
        {
            List<Message> messages = AllMessages();
            messages.Sort((x, y) => DateTime.Compare(x.CreatedAt, y.CreatedAt));
            if(num > messages.Count)
            {
                return messages;
            }
            else
            {
                List<Message> recent = new List<Message>();
                recent = messages.GetRange(messages.Count - num, num);
                return recent;
            }
        }
    }
}
