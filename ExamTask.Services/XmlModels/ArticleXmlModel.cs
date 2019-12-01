using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    [XmlType("orderarticle")]
    public class ArticleXmlModel
    {
        [XmlElement(ElementName = "artnum")]
        public long ArtNum { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "amount")]
        public int Amount { get; set; }

        [XmlElement(ElementName = "brutprice")]
        public decimal BrutPrice { get; set; }
    }
}
