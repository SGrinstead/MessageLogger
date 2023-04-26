using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogger
{
    public class User
    {
        public string Name;
        public string Username;
        public List<Message> Messages;

        public User(string name, string username)
        {
            Name = name;
            Username = username;
            Messages = new List<Message>();
        }

        //Creates new message and adds to list
        public void AddMessage(string content)
        {
            Messages.Add(new Message(content));
        }

        //Writes each message in list with additional info
        public void WriteMessages()
        {
            foreach(var message in Messages)
            {
                Console.WriteLine(Name + " " + message);
            }
        }

        public void DeleteMessage()
        {
            if(Messages.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You have no messages to delete");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Which message would you like to delete?");
                MessageList();
                Console.Write("Message number: ");
                if(Int32.TryParse(Console.ReadLine(), out int result))
                {
                    Messages.RemoveAt(result - 1);
                    Console.WriteLine();
                    Console.WriteLine("Message Deleted");
                    Console.WriteLine();
                    WriteMessages();
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
            }
        }

        public void EditMessage()
        {
            string newContent = "";
            if (Messages.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("You have no messages to edit");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Which message would you like to edit");
                MessageList();
                Console.Write("Message number: ");
                if (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    while(newContent == "")
                    {
                        Console.Write("What would you like the message to say? ");
                        newContent = Console.ReadLine();
                        if (newContent.Replace(" ", "") == "")
                        {
                            Console.WriteLine("You can write a better message than that.");
                        }
                        else
                        {
                            Messages[result - 1].Content = newContent;
                            Console.WriteLine();
                            Console.WriteLine("Edited message.");
                            Console.WriteLine();
                            WriteMessages();
                        }
                    }  
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
            }
        }

        public void MessageList()
        {
            for(int i = 0; i < Messages.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Name} {Messages[i]}");
            }
        }
    }
}
