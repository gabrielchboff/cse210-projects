namespace PasswordManager
{
    public class PasswordGenerator
    {
        private bool _upper = false;
        private bool _number = false;
        private bool _specialChar = false;

        public PasswordGenerator ()
        {

        }

        public PasswordGenerator (bool upper, bool number, bool specialChar)
        {
            _upper = upper;
            _number = number;
            _specialChar = specialChar;
        }

        public string Generate ()
        {
            return "";
        }
        
    }
}
