using System.Collections.Generic;
using System.Threading.Tasks;
using ExamTask.Common.Enums;
using ExamTask.Services.Models;

namespace ExamTask.Services.Contracts
{
    public interface IOrdersService
    {
        Task<List<OrderVM>> FilterOrderById(string id);
        Task<List<OrderVM>> GetAllOrders();
        Task SetOrderInvoiceAsync(int orderId, int invoice);
        Task SetOrderStatusAsync(int orderId, OrderStatusEnum statusEnum);
    }
}