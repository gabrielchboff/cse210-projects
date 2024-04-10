namespace PasswordManager
{
    public class PasswordManager : EncryptionManager
    {
        private List<PasswordEntry> _passwords { get; set; }
        
        public PasswordManager(List<PasswordEntry> passwords, string protocol, string key) : base (string protocol, string key)
        {
            _passwords = passwords;
        }

        public PasswordManager()
        {

        }
        
        public List<PasswordEntry> GetPasswords()
        {
            return _passwords;
        }



            
    }
}
