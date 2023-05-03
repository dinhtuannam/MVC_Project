using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AccountsService : IAccounts
    {
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

        public bool HasAccountName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
