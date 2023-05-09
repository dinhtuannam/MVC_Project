using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDiscounts
    {
        Discount GetByName(string name);
        IEnumerable<Discount> GetAll();
        Discount GetById(int id);
    }
}
