using Invoicing.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoicing.Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> DeleteAuthor(int id);
        Task<Client> GetClient(int id);
        IEnumerable<Client> GetClients();
        Task InsertAuthor(Client client);
        Task<bool> UpdateAuthor(Client client);
    }
}