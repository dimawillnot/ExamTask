﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.API.Requests
{
    public class OrderSetInvoiceNumber
    {
        public int OrderId { get; set; }

        public int InvoiceNumber { get; set; }
    }
}
