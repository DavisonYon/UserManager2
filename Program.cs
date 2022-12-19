// User Management App. 
// Use: Prompts for Username, Password, and Access Level

bool isLooping = false;

//Default Admin Username and Password
const string ADMIN_USERNAME = "Admin";
const string ADMIN_PASSWORD = "$2$Q#aJH#$dsf3";


List<User> users = new List<User>();
List<Guest> guests = new List<Guest>();
List<Admin> admins = new List<Admin>();

Console.WriteLine("Press 1 to Login");
Console.WriteLine("Press 2 to create new users");
string userInput = Console.ReadLine();

if (userInput == "1")
{
    Login();
} else if (userInput == "2")
{
    CreateUsers();
} else
{
    Console.WriteLine("Invalid Selection...");
}

void CreateUsers()
{
    //Login as an administrator
    Console.WriteLine("Enter an admin username: ");
    string username = Console.ReadLine();
    Console.WriteLine("Enter the password: ");
    string password = Console.ReadLine();

    if (username == ADMIN_USERNAME && password == ADMIN_PASSWORD)
    {
        isLooping = true;
        Console.Clear();
    }
    else
    {
        isLooping = false;
        Console.Clear();
        Console.WriteLine("Invalid username or password!");
        CreateUsers();
    }


    while (isLooping)
    {
        //Prompt for Username
        Console.WriteLine("Enter a username: ");
        string un = Console.ReadLine();

        //Prompt for Password
        Console.WriteLine("Enter a password: ");
        string pw = Console.ReadLine();

        //Prompt for pre-determined access levels
        Console.WriteLine("Press 1 for a Generic User.");
        Console.WriteLine("Press 2 for a Guest User.");
        Console.WriteLine("Press 3 for an Admin User.");
        Console.WriteLine("Press 0 to Login");
        int selection = int.Parse(Console.ReadLine());

        //Clear Screen
        Console.Clear();

        //Create an object
        if (selection == 1)
        {
            users.Add(new User(un, pw));
            Console.WriteLine(un + " has been created as a Generic User");
        }
        else if (selection == 2)
        {
            guests.Add(new Guest(un, pw));
            Console.WriteLine(un + " has been created as a Guest User");

        }
        else if (selection == 3)
        {
            admins.Add(new Admin(un, pw));
            Console.WriteLine(un + " has been created as an Admin User");
        } else if (selection == 0)
        {
            Login();
        }
        else
        {
            Console.WriteLine("Invalid Selection. No user created.");
        }

        Console.WriteLine("All Users:");
        foreach (User usr in users)
        {
            Console.WriteLine(usr.username);
        }
        Console.WriteLine("All Guests:");
        foreach (Guest gst in guests)
        {
            Console.WriteLine(gst.username);
        }
        Console.WriteLine("All Admins:");
        foreach (Admin adm in admins)
        {
            Console.WriteLine(adm.username);
        }
    }
}

void Login()
{
    Console.WriteLine("Enter username: ");
    string username = Console.ReadLine();
    Console.WriteLine("Enter password: ");
    string password = Console.ReadLine();

    foreach (User user in users)
    {
        if (user.username == username)
        {
            if (user.password == password)
            {
                LoadApp(username);
            } else
            {
                Console.WriteLine("Invalid Password.");
                Login();
            }
        } else
        {
            Console.WriteLine("Invalid Username.");
            Login();
        }
    }
}

void LoadApp(string username)
{
    Console.WriteLine("Hello " + username + "!");
}