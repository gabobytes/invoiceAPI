using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Services
{
    public class InvoiceProductService :  IInvoiceProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceProductService(IUnitOfWork unitOfwork)
        {
            _unitOfWork = unitOfwork;
        }

        public IEnumerable<InvoiceProduct> GetInvoicesProducts()
        {
            return _unitOfWork.InvoiceProductRepository.GetAll();
        }

        public async Task InsertInvoiceProduct(InvoiceProduct invoiceProduct)
        {
            int idInvoice = invoiceProduct.Idinvoice;

            var invoice = _unitOfWork.InvoiceRepository.GetById(idInvoice);

            if (invoice == null)
            {
                throw new Exception("Factura no existente");
            }

            await _unitOfWork.InvoiceProductRepository.Add(invoiceProduct);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
