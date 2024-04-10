namespace PasswordManager
{
    public class PasswordEntry 
    {
        private string _user; 
        private string _pass;

        public PasswordEntry(string user, string pass)
        {
            _user = user;
            _pass = pass;
        }

        public string GetUser()
        {
            return _user;
        }

        public void SetUser (string user)
        {
            _user = user;
        }

        public string GetPassword()
        {
            return _pass;
        }

        public void SetPassword (string pass)
        {
            _pass = pass;
        }

    }
}
