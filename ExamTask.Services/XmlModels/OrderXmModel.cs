using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    [XmlType("order")]
    public class OrderXmlModel
    {
        [XmlElement(ElementName ="oxid")]
        public long Id { get; set; }

        [XmlElement(ElementName = "orderdate")]
        public DateTime OrderDate { get; set; }

        [XmlElement(ElementName = "billingaddress")]
        public BillingAddressXmlModel BillingAddress { get; set; }

        [XmlArray("payments")]
        [XmlArrayItem("payment")]
        public List<PaymentXmlModel> Payments { get; set; }

        [XmlArray("articles")]
        [XmlArrayItem("orderarticle")]
        public List<ArticleXmlModel> Articles { get; set; }

        [XmlIgnore]
        public short? OrderStatusID { get; set; }
    }
}
