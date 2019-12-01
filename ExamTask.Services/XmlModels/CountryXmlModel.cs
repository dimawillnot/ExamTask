using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    [Serializable]
    public class CountryXmlModel
    {
        [XmlElement("geo")]
        public string Geo { get; set; }
    }
}
