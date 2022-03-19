using Invoicing.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Client> ClientRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
