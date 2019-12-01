using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    public class ArticleVM
    {
        public long ArtNum { get; set; }

        public string Title { get; set; }

        public int Amount { get; set; }

        public decimal BrutPrice { get; set; }
    }
}
