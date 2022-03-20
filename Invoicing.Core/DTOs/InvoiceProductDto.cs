using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.DTOs
{
    public class InvoiceProductDto
    {
        public int Id { get; set; }
        public int Idinvoice { get; set; }
        public int Idproduct { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}
