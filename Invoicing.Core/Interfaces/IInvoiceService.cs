using Invoicing.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<bool> DeleteInvoice(int id);
        Task<Invoice> GetInvoice(int id);
        IEnumerable<Invoice> GetInvoices();
        Task<int> InsertInvoice(Invoice invoice);
        Task<bool> UpdateInvoice(Invoice invoice);
    }
}