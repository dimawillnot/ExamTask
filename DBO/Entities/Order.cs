using System;
using System.Collections.Generic;

namespace DBO.Entities
{
    public partial class Order
    {
        public Order()
        {
            Articles = new List<Article>();
            Payments = new List<Payment>();
        }

        public long OxId { get; set; }
        public DateTime OrderDatetime { get; set; }
        public byte? OrderStatus { get; set; }
        public int? InvoiceNumber { get; set; }

        public  OrderStatus OrderStatusNavigation { get; set; }
        public  BillingAddress BillingAddresses { get; set; }
        public  List<Article> Articles { get; set; }
        public  List<Payment> Payments { get; set; }
    }
}
