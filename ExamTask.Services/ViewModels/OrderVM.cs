using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    public class OrderVM
    {
        public long Id { get; set; }

        public DateTime OrderDate { get; set; }

        public BillingAddressVM BillingAddress { get; set; }

        public List<PaymentVM> Payments { get; set; }

        [XmlArrayItem("")]
        public List<ArticleVM> Articles { get; set; }

        [XmlIgnore]
        public short? OrderStatusID { get; set; }
    }
}
