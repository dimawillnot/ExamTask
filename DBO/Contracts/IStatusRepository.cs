using System.Threading.Tasks;
using DBO.Entities;
using ExamTask.Common.Enums;

namespace DBO.Contracts
{
    public interface IStatusRepository : IRepository<OrderStatus>
    {
        Task<bool> IsExistStatusAsync(OrderStatusEnum orderStatusEnum);
    }
}