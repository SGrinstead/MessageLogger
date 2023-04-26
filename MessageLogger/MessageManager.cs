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

        //Adds user to list of users
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        //returns user with matching username or false if no match
        public User GetUser(string username)
        {
            foreach(var user in Users)
            {
                if(username == user.Username)
                {
                    return user;
                }
            }
            return null;
        }

        //Writes how many messages each user wrote
        public void MessageCount()
        {
            foreach(var user in Users)
            {
                Console.WriteLine($"{user.Name} wrote {user.Messages.Count} messages.");
            }
        }

        //returns list of all messages
        public List<Message> AllMessages()
        {
            List<Message> messages = new List<Message>();
            foreach(var user in Users)
            {
                messages.AddRange(user.Messages);
            }
            return messages;
        }

        //returns num most recent messages
        public List<Message> RecentMessages(int num)
        {
            List<Message> messages = AllMessages();
            //uses datetime compare to sort messages by CreatedAt value
            messages.Sort((x, y) => DateTime.Compare(x.CreatedAt, y.CreatedAt));
            //if less than num messages exist, returns all messages
            if(num > messages.Count)
            {
                return messages;
            }
            //returns num most recent messages
            else
            {
                List<Message> recent = new List<Message>();
                recent = messages.GetRange(messages.Count - num, num);
                return recent;
            }
        }

        //returns true if username already exists
        public bool UsernameIsTaken(string username)
        {
            bool taken = false;
            foreach(var user in Users)
            {
                if(username == user.Username)
                {
                    taken = true;
                }
            }
            return taken;
        }
    }
}
