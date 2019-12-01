using System;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    public class PaymentVM
    {
        public string MethodName { get; set; }

        public decimal Amount { get; set; }
    }
}
