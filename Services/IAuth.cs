using Entity;

namespace Services
{
    public interface IAuth
    {
        Accounts Login(string username, string password);
        bool Register(Accounts account);
    }
}
