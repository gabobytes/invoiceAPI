using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using Invoicing.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Repositories
{
    public class InvoiceProductRepository: BaseRepository<InvoiceProduct>, IInvoiceProductRepository
    {
        public InvoiceProductRepository(invoicingContext context) : base(context) { }
    }
}
