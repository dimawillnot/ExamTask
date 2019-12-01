using DBO.Contexts;
using DBO.Contracts;
using DBO.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBO.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrdersDbContext ordersDbContext) : base(ordersDbContext)
        {
        }

        public async Task<Order> GetOrderAsync(long id)
        {
            var order = await ordersDbContext.Orders.FirstOrDefaultAsync(o => o.OxId == id);
            return order;
        }

        public Task<List<Order>> GetOrderByIdAsync(string id)
        {
            var filteredOrders = GetAllOrders().Where(o => o.OxId.ToString().Contains(id))
                                                      .ToListAsync();

            return filteredOrders;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return ordersDbContext.Orders.Include(o => o.Articles)
                                                      .Include(o => o.BillingAddresses)
                                                      .Include(o => o.Payments);
        }
    }
}
