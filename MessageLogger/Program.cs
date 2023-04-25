// See https://aka.ms/new-console-template for more information
using MessageLogger;

MessageManager allUsers = new MessageManager();
User currentUser;
string input = "";

Console.WriteLine("Welcome to Message Logger!");

currentUser = AddUser(allUsers);

while (true)
{
    Console.Write("Add a message: ");
    input = Console.ReadLine();

    if(input == "")
    {
        Console.WriteLine("You can write a better message than that.");
    }
    else if(input.ToLower() == "quit") //exits loop
    {
        break;
    }
    else if (input.ToLower() == "log out" || input.ToLower() == "logout")
    {
        while(!(input.ToLower() == "new" || input.ToLower() == "existing"))
        {
            Console.WriteLine();
            Console.Write("Would you like to log in to a 'new' or 'existing' user? ");
            input = Console.ReadLine();
            if (input.ToLower() == "new") //reates new User in allUsers
            {
                currentUser = AddUser(allUsers);
            }
            else if (input.ToLower() == "existing") //finds existing User in allUsers
            {
                currentUser = LogIn(allUsers);
                currentUser.WriteMessages();
            }
            else
            {
                Console.WriteLine("Please enter either 'new' or 'existing'.");
            }
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

//Helper method to create a new User and add it to allUsers
static User AddUser(MessageManager allUsers)
{
    string name = "";
    string username = "";
    Console.WriteLine();
    Console.WriteLine("Let's create a user profile for you.");
    while(name == "")
    {
        Console.Write("What is your name? ");
        name = Console.ReadLine();
        if(name == "")
        {
            Console.WriteLine("Please enter a valid name.");
        }
    }
    while(username == "")
    {
        Console.Write("What is your username? (one word, no spaces!) ");
        username = Console.ReadLine();
        if(username == "")
        {
            Console.WriteLine("Please enter a valid username.");
        }
    }
    allUsers.AddUser(new User(name, username));
    Console.WriteLine();
    Console.WriteLine("To log out of your user profile, enter 'log out'. to quit the application, enter 'quit'");
    return allUsers.GetUser(username);
}

//Helper method to log into existing user
static User LogIn(MessageManager allUsers)
{
    string username;
    while (true)
    {
        //checks if username is connected to an existing user
        Console.Write("What is your username? ");
        username = Console.ReadLine();
        if (allUsers.GetUser(username) == null)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid Username, please try again."); //try again
        }
        else break;
    }
    User currentUser = allUsers.GetUser(username);
    Console.WriteLine();
    Console.WriteLine($"Welcome back, {currentUser.Name}!");
    return currentUser;
}