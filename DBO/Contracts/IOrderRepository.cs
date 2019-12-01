using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBO.Entities;

namespace DBO.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllOrders();
        Task<Order> GetOrderAsync(long id);
        Task<List<Order>> GetOrderByIdAsync(string id);
    }
}