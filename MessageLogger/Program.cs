// See https://aka.ms/new-console-template for more information
using MessageLogger;

MessageManager allUsers = new MessageManager();
User currentUser;
string name;
string username;
string input = "";

Console.WriteLine("Welcome to Message Logger!");

Console.WriteLine();
Console.WriteLine("Let's create a user profile for you.");
Console.Write("What is your name? ");
name = Console.ReadLine();
Console.Write("What is your username? (one word, no spaces!) ");
username = Console.ReadLine();
allUsers.AddUser(new User(name, username));
currentUser = allUsers.GetUser(username);
Console.WriteLine();
Console.WriteLine("To log out of your user profile, enter 'log out'. to quit the application, enter 'quit'");

while (true)
{
    Console.Write("Add a message: ");
    input = Console.ReadLine();

    if(input.ToLower() == "quit")
    {
        break;
    }
    else if (input.ToLower() == "log out")
    {
        Console.WriteLine();
        Console.Write("Would you like to log in to a 'new' or 'existing' user? ");
        input = Console.ReadLine();
        if (input.ToLower() == "new")
        {
            Console.WriteLine();
            Console.WriteLine("Let's create a user profile for you.");
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.Write("What is your username? (one word, no spaces!) ");
            username = Console.ReadLine();
            allUsers.AddUser(new User(name, username));
            currentUser = allUsers.GetUser(username);
            Console.WriteLine();
            Console.WriteLine("To log out of your user profile, enter 'log out'. to quit the application, enter 'quit'");
        }
        else if(input.ToLower() == "existing")
        {
            Console.Write("What is your username? ");
            username = Console.ReadLine();
            currentUser = allUsers.GetUser(username);
            Console.WriteLine();
            Console.WriteLine($"Welcome back, {currentUser.Name}!");
            currentUser.WriteMessages();
        }
    }
    else
    {
        Console.WriteLine();
        currentUser.AddMessage(input);
        currentUser.WriteMessages();
    }
}

Console.WriteLine();
Console.WriteLine("Thanks for using Message Logger!");
allUsers.MessageCount();

//static void AddUser()
//{
//    Console.WriteLine();
//    Console.WriteLine("Let's create a user profile for you.");
//    Console.Write("What is your name? ");
//    name = Console.ReadLine();
//    Console.Write("What is your username? (one word, no spaces!) ");
//    username = Console.ReadLine();
//    allUsers.AddUser(new User(name, username));
//    currentUser = allUsers.GetUser(username);
//    Console.WriteLine();
//    Console.WriteLine("To log out of your user profile, enter 'log out'. to quit the application, enter 'quit'");

//}