using ExamTask.Common.Enums;

namespace ExamTask.API.Requests
{
    public class OrderSetStatusRequest
    {
        public int OrderId { get; set; }

        public OrderStatusEnum Status { get; set; }
    }
}
