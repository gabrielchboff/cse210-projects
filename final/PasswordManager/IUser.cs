namespace PasswordManager
{
    public interface IUser
    {
        public bool Save();
        public bool Login();
        public bool Logout();
        
    }
}
