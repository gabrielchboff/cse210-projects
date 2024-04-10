namespace PasswordManager
{
    public class EncryptionManager
    {
        private string _protocol { get; set; } 
        private string _key { get; set; }

        public EncryptionManager (string protocol, string key)
        {
            _protocol = protocol;
            _key = key;
        }

        public string Encrypt(string data)
        {
            return "";

        }

        public string Decrypt(string data)
        {
            return "";

        }



    }
}
