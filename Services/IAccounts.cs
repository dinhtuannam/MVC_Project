using Entity;

namespace Services
{
    public interface IAccounts
    {
        IEnumerable<Accounts> GetAll();
    }
}