using System;
using System.Collections.Generic;

namespace DBO.Entities
{
    public partial class Article
    {
        public int Id { get; set; }
        public long Nomenclature { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public double BrutPrice { get; set; }
        public long OrderOxId { get; set; }

        public Order OrderOx { get; set; }
    }
}
