namespace PasswordManager
{
    public class PasswordManager : EncryptionManager
    {
        private List<PasswordEntry> _passwords { get; set; }
        
        public PasswordManager(List<PasswordEntry> passwords, string protocol, string key)
        : base(protocol, key)
        {
            _passwords = passwords ?? new List<PasswordEntry>(); // Initialize with empty list if passwords is null
        }

        
        public List<PasswordEntry> GetPasswords()
        {
            return new List<PasswordEntry>(_passwords);
        }
            
    }
}
