using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public interface IOrders
	{
        Task<Order> InsertOrder(Order order);
        Task InsertDetailOrder(List<DetailOrder> detailOrder);
        IEnumerable<Order> GetById(string id);
        IEnumerable<DetailOrder> GetDetailById(int id);
    }
}
