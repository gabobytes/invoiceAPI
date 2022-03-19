using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Invoicing.Core.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            Invoiceproduct = new HashSet<Invoiceproduct>();
        }

        public int Idinvoice { get; set; }
        public int Idclient { get; set; }
        public DateTime Date { get; set; }

        public virtual Client IdclientNavigation { get; set; }
        public virtual ICollection<Invoiceproduct> Invoiceproduct { get; set; }
    }
}
