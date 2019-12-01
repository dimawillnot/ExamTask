using DBO.Contexts;
using DBO.Contracts;
using DBO.Entities;
using ExamTask.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DBO.Repositories
{
    public class StatusRepository : BaseRepository<OrderStatus>, IRepository<OrderStatus>, IStatusRepository
    {
        public StatusRepository(OrdersDbContext ordersDbContext) : base(ordersDbContext)
        {
        }

        public Task<bool> IsExistStatusAsync(OrderStatusEnum orderStatusEnum)
        {
            return ordersDbContext.OrderStatuses.AnyAsync(r => r.Id == (byte)orderStatusEnum);
        }
    }
}
