namespace PasswordManager
{
    public interface IUser
    {
        public bool Login();
        public bool Logout();
        public bool Save();
    }
}
