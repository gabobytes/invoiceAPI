using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Services
{
    public class InvoiceService :  IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;


        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _unitOfWork.InvoiceRepository.GetAll();
        }

        public async Task<Invoice> GetInvoice(int id)
        {
            return await _unitOfWork.InvoiceRepository.GetById(id);
        }

        public async Task<int> InsertInvoice(Invoice invoice)
        {
            await _unitOfWork.InvoiceRepository.Add(invoice);
            await _unitOfWork.SaveChangesAsync();
            return invoice.Id;
        }

       /* public async Task InsertDetail(InvoiceProduct invoiceProduct, int idFactura)
        {
            

            await _unitOfWork.InvoiceRepository.Add(invoiceProduct);
            await _unitOfWork.SaveChangesAsync();
        }*/


        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            _unitOfWork.InvoiceRepository.Update(invoice);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            await _unitOfWork.InvoiceRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}
