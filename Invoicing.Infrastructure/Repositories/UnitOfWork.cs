using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using Invoicing.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly invoicingContext _context;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<InvoiceProduct> _invoiceRepositoryProduct;

        public UnitOfWork(invoicingContext context)
        {
            _context = context;
        }

        public IRepository<Client> ClientRepository => _clientRepository ?? new BaseRepository<Client>(_context);
        public IRepository<Product> ProductRepository => _productRepository ?? new BaseRepository<Product>(_context);
        public IRepository<Invoice> InvoiceRepository => _invoiceRepository ?? new BaseRepository<Invoice>(_context);
        public IRepository<InvoiceProduct> InvoiceProductRepository => _invoiceRepositoryProduct ?? new BaseRepository<InvoiceProduct>(_context);

        public void Dispose()
        {
           if(_context !=null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
