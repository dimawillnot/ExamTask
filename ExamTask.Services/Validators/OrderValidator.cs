using DBO.Contracts;
using DBO.Repositories;
using ExamTask.Common.Models;
using ExamTask.Services.Contracts;
using ExamTask.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamTask.Services.Validators
{
    public class OrderValidator : IOrderValidator
    {
        private readonly IOrderRepository orderRepository;

        public OrderValidator(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<GeneralResult<IList<long>>> Validate(ICollection<OrderXmlModel> orders)
        {
            var result = new GeneralResult<IList<long>>()
            {
                Error = new List<long>(),
                IsSuccess = true
            };

            foreach (var order in orders)
            {
                var isExist = await orderRepository.GetAll().AnyAsync(o => o.OxId == order.Id);

                if (isExist)
                {
                    result.Error.Add(order.Id);
                    result.IsSuccess = false;
                }
            }

            if (!result.IsSuccess)
            {
                result.Message = $"Orders already exists";
                result.ErrorCode = Common.Enums.ErrorCode.OrderIsDublicated;
            }

            return result;
        }
    }
}
