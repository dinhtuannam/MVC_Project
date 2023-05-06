using Entity;

namespace Services
{
    public interface IAccounts
    {
        IEnumerable<Accounts> GetAll();
        Accounts GetById(int id);
        Accounts GetByName(string name);
        bool HasAccountName(string username);
        Accounts CheckAccount(string username,string password);
    }
}