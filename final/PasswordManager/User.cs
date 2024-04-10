using System.Text;

namespace PasswordManager
{
    public class User: PasswordManager
    {
        private string _username { get; set; }
        private string _masterPassword { get; set;}

        public User (string username, string masterPassword, List<PasswordEntry> passwords ,byte[] key, byte[] iv)
        : base(passwords, key, iv)
        {
            _username = username;
            _masterPassword = masterPassword;
        }

        public bool Save()
        {
            bool valid = false;
            string data = $"{_username},{_masterPassword}";
            using(StreamWriter writer = new StreamWriter("login.txt"))
            {
                writer.WriteLine(data);
            }
            Encrypt("login.txt", "login.bin");
            File.Delete("login.txt");
            valid = true;
            return valid;
        }

        public override List<PasswordEntry> GetPasswords()
        {
            for (int i = 0; i < _passwords.Count; i++)
            {
                Console.WriteLine($"Username: {_passwords[i].GetUser()}\nPassword: {_passwords[i].GetPassword()}");
            }
            return _passwords;
        }
        
        
        public void DisplayCredentials() 
        {

            List<PasswordEntry> passes = GetPasswords();
        }

        public bool Login(string username, string password)
        {
            bool valid = false;
            Decrypt("login.bin", "login.txt");
            string decryptedText = File.ReadAllText("login.txt");
            string[] newData = decryptedText.Split(",");
            string current_password = newData[1];
            string current_username = newData[0];
            File.Delete("login.txt");
            valid = current_password.Trim() == password.Trim() && current_username.Trim() == username.Trim();
            return valid;

        }

        public bool Logout()
        {
            Console.WriteLine("goodbye!");
            return false;

        }


    }
}
