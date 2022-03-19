using Invoicing.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Task<Client> GetClient(int id);        
        Task InsertClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}