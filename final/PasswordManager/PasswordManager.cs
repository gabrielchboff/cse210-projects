namespace PasswordManager
{
    public class PasswordManager : EncryptionManager
    {
        protected List<PasswordEntry> _passwords { get; set; }
        
        public PasswordManager(List<PasswordEntry> passwords, byte[] key, byte[] iv)
        : base(key, iv)
        {
            _passwords = passwords ?? new List<PasswordEntry>(); // Initialize with empty list if passwords is null
        }
        
        public virtual List<PasswordEntry> GetPasswords()
        {
            return new List<PasswordEntry>(_passwords);
        }

        

        public void AppendPass(PasswordEntry pass)
        {
            _passwords.Add(pass);
        }

        public void SavePass(){
            using(StreamWriter writer = new StreamWriter("pass.txt"))
            {
                for (int i = 0; i < _passwords.Count; i++)
                {
                    writer.WriteLine($"{_passwords[i].GetUser()},{_passwords[i].GetPassword()}");
                }
            }
            Encrypt("pass.txt", "pass.bin");
            File.Delete("pass.txt");
        }

        public void LoadPass()
        {
            Decrypt("pass.bin", "pass.txt");
            string[] decryptedText = File.ReadAllLines("pass.txt");
            List<string> lines = new List<string>(decryptedText);
            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(",");
                PasswordEntry pass = new PasswordEntry(line[0], line[1]);
                _passwords.Add(pass);
            }

            File.Delete("pass.txt");


        }

    }
}
