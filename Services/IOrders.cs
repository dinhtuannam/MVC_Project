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
        Task UpdateAsSync(Order order);
        Task DeleteAsSync(int id);
        Order GetOrderById(int orderID);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetById(string id);
        IEnumerable<DetailOrder> GetDetailById(int id);
    }
}
