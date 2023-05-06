using Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Services.Implementation
{
    public class AccountsService : IAccounts
    {
        private ApplicationDbContext _context;
        public AccountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Accounts CheckAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accounts> GetAll()
        {
            throw new NotImplementedException();
        }

        public Accounts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Accounts GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool HasAccountName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
