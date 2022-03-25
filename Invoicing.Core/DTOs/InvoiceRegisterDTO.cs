using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.DTOs
{
    public class InvoiceRegisterDTO
    {
        public int Id { get; set; }
        public int Idclient { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceProductDto> ProductsInvoice { get; set; }
        
    }
}
