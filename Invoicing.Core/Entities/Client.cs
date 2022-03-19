using Invoicing.Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Invoicing.Core.Data
{
    public partial class Client: BaseEntity
    {
        public Client()
        {
            Invoice = new HashSet<Invoice>();
        }

        
        public string Document { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
