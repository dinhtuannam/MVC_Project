using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStatics
    {
        IEnumerable<DetailOrder> GetTopSellingProducts(string filter);
    }
}
