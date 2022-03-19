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

        public UnitOfWork(invoicingContext context)
        {
            _context = context;
        }

        public IRepository<Client> ClientRepository => _clientRepository ?? new BaseRepository<Client>(_context);

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
