namespace PasswordManager
{
    internal class Program
    {

        
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
                User user = new User(username, password);
                user.Save();
            }
            else
            {
                Console.WriteLine("The confirmation don't match!");
            }

        }

        private static User FindLogin (string user, string pass)
        {
            //Find on file
            return new User (user, pass);
        }

        private static void UserLoginMenu ()
        {
            List<string> options = new List<string>() {
                "Login",
                "Create User"
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
                    User currentUser = FindLogin(username, password);
                    currentUser.Login();
                    break;

                case 2:
                    CreateUserMenu();
                    break;
            }
        }

        private static void Main(string[] args)
        {
            List<string> _options = new List<string> {
                "Create new credential",
                "Edit credential",
                "List credentials",
                "Generate random password",
                "Quit"
            };
            Menu _mainMenu = new Menu(
                "Password Manager", 
                "A local program to manage your accounts",
                _options
            );

            do {
                UserLoginMenu();


            } while (true);


        }
            
    }
}
