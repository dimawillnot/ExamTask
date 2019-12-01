using System;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    [Serializable, XmlRoot("paymants")]
    public class PaymentXmlModel
    {
        [XmlElement(ElementName = "method-name")]
        public string MethodName { get; set; }

        [XmlElement(ElementName = "amount")]
        public decimal Amount { get; set; }
    }
}
