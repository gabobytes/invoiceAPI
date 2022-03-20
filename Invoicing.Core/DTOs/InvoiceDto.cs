using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int Idclient { get; set; }
        public DateTime Date { get; set; }
    }
}
