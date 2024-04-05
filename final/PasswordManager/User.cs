namespace PasswordManager
{
    public class User : IUser
    {
        private string _username { get; set; }
        private string _masterPassword { get; set;}

        public User (string username, string masterPassword)
        {
            _username = username;
            _masterPassword = masterPassword;
        }
    
        public bool Save()
        {
            return true;
        }

        public bool Login()
        {
            return true;

        }

        public bool Logout()
        {
            return false;

        }


    }
}
