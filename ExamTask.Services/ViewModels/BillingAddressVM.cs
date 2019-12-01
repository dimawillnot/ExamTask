using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExamTask.Services.Models
{
    public class BillingAddressVM
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public short Streetnr { get; set; }

        public string City { get; set; }

        public CountryVM Country { get; set; }

        public int Zip { get; set; }
    }
}
