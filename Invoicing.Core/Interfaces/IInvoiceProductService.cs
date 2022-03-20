using Invoicing.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IInvoiceProductService
    {
        IEnumerable<InvoiceProduct> GetInvoicesProducts();
        Task InsertInvoiceProduct(InvoiceProduct invoiceProduct);
    }
}