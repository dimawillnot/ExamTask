using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    [Serializable]
    public class BillingAddressXmlModel
    {
        [XmlElement(ElementName = "billemail")]
        public string Email { get; set; }

        [XmlElement(ElementName = "billfname")]
        public string Name { get; set; }

        [XmlElement(ElementName = "billstreet")]
        public string Street { get; set; }

        [XmlElement(ElementName = "billstreetnr")]
        public short Streetnr { get; set; }

        [XmlElement(ElementName = "billcity")]
        public string City { get; set; }

        [XmlElement(ElementName = "country")]
        public CountryXmlModel Country { get; set; }

        [XmlElement(ElementName = "billzip")]
        public int Zip { get; set; }
    }
}
