using System;
using System.Collections.Generic;

namespace DBO.Entities
{
    public partial class Payment
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public decimal Amount { get; set; }
        public long OrderOxId { get; set; }

        public Order OrderOx { get; set; }
    }
}
