using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Services
{
    public class ClientService :  IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<Client> GetClients()
        {
            return _unitOfWork.ClientRepository.GetAll();
        }


        public async Task<Client> GetClient(int id)
        {
            return await _unitOfWork.ClientRepository.GetById(id);
        }

        public async Task InsertAuthor(Client client)
        {

            await _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAuthor(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            await _unitOfWork.ClientRepository.Delete(id);
            return true;
        }

    }
}
