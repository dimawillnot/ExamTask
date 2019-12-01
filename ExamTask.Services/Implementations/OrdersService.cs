using DBO.Contracts;
using ExamTask.Common.Enums;
using ExamTask.Common.Exceptions;
using ExamTask.Services.Converters;
using ExamTask.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.Services.Contracts
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IStatusRepository statusRepository;
        private readonly IXmlOrdersImporter importer;

        public OrdersService(IOrderRepository orderRepository, IStatusRepository statusRepository, IXmlOrdersImporter importer)
        {
            this.orderRepository = orderRepository;
            this.statusRepository = statusRepository;
            this.importer = importer;
        }

        public async Task<List<OrderVM>> FilterOrderById(string id)
        {
            var dbOrders = await orderRepository.GetOrderByIdAsync(id);
           var orders = dbOrders.Select(o => OrderConverter.ConvertToVM(o)).ToList();

            return orders;
        }

        public async Task<List<OrderVM>> GetAllOrders()
        {
            var dbOrders = await orderRepository.GetAllOrders().ToListAsync();
            return dbOrders.Select(o => OrderConverter.ConvertToVM(o)).ToList();
        }

        public async Task SetOrderStatusAsync(int orderId, OrderStatusEnum statusEnum)
        {
            var order = orderRepository.FindById(orderId);
            var statusIsExist = await statusRepository.IsExistStatusAsync(statusEnum);
            if (order == null)
            {
                throw new ValidationException(ErrorCode.OrderNotFound);
            }

            if (!statusIsExist)
            {
                throw new ValidationException(ErrorCode.StatusNotFound);
            }

            order.OrderStatus = (byte)statusEnum;

            await orderRepository.UpdateAsync(order);
        }

        public Task SetOrderInvoiceAsync(int orderId, int invoice)
        {
            var order = orderRepository.FindById(orderId);
            if (order == null)
            {
                throw new ValidationException(ErrorCode.OrderNotFound);
            }

            order.InvoiceNumber = invoice;

            return orderRepository.UpdateAsync(order);
        }
    }
}
