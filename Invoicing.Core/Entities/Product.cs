using Invoicing.Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Invoicing.Core.Data
{
    public partial class Product: BaseEntity
    {
        public Product()
        {
            Invoiceproduct = new HashSet<InvoiceProduct>();
        }

        
        public string Productname { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<InvoiceProduct> Invoiceproduct { get; set; }
    }
}
