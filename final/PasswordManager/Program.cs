namespace PasswordManager
{
    internal class Program
    {
        static byte[] key = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
        static byte[] iv = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
        static List<PasswordEntry> emptyPasswords = new List<PasswordEntry>();
        
        private static void CreateUserMenu ()
        {
            Console.Write("Create a username: ");
            string username = Console.ReadLine();
            Console.Write("Create a master password: ");
            string password = Console.ReadLine();
            Console.Write("Type again the master password to confirm: ");
            string passwordConfirmation = Console.ReadLine();


            if (password == passwordConfirmation)
            {
                User user = new User(username, password, emptyPasswords, key, iv);
                user.Save();
            }
            else
            {
                Console.WriteLine("The confirmation don't match!");
            }

        }

        private static bool FindLogin (string user, string pass)
        {
            //Find on file
            User newUser = new User (user, pass, emptyPasswords, key, iv);
            bool valid = newUser.Login(user, pass);
            return valid;
        }

        private static void UserLoginMenu ()
        {
            List<string> options = new List<string>() {
                "Login",
                "Create User",
                "Quit"
            };

            Menu loginMenu = new Menu("Password Manager", "Choose some option:", options);
            loginMenu.Display();
            int choice = 0;
            choice = loginMenu.GetChoice();
            switch (choice)
            {
                case 1:

                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    bool valid = FindLogin(username, password);

                    if (valid)
                    {

                        User newUser = new User (username, password, emptyPasswords, key, iv);
                        newUser.SavePass();
                        MainMenu(newUser);

                    }
                    else
                    {
                        Console.WriteLine("Something is not right");
                    }
                    break;

                case 2:
                    CreateUserMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Something is not right.");
                    break;


            }
        }

        private static void MainMenu(User mainUser){
            mainUser.LoadPass();
            List<string> _options = new List<string> {
                "Create new credential",
                "List credentials",
                "Generate random password",
                "Quit"
            };
            Menu _mainMenu = new Menu(
                "Password Manager", 
                "A local program to manage your accounts",
                _options
            );
            _mainMenu.Display();
            int mChoice =_mainMenu.GetChoice();
            switch(mChoice)
            {
                case 1:

                    Console.WriteLine("Type the username: ");
                    string user = Console.ReadLine();

                    Console.WriteLine("Type the password to keep: ");
                    string pass = Console.ReadLine();

                    Console.Write("Type again the password to confirm: ");

                    string passConfirmation = Console.ReadLine();

                    if (pass == passConfirmation)
                    {
                        PasswordEntry passEntry = new PasswordEntry(user, pass);
                        mainUser.AppendPass(passEntry);
                        mainUser.SavePass();
                        Console.WriteLine("Success!");
                        
                    }
                    else
                    {
                        Console.WriteLine("The password confirmations is not right.");
                    }
                    break;
                case 2:
                    mainUser.DisplayCredentials();
                    break;
                case 3:
                    PasswordGenerator gen = new PasswordGenerator();
                    Console.Write("Type a length for the password: ");
                    int len = int.Parse(Console.ReadLine());
                    Console.WriteLine(gen.Generate(len));
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Something is not right.");
                    break;




            }




        }

        private static void Main(string[] args)
        {
            do {

                UserLoginMenu();
            } while (true);

        }
            
    }
}
