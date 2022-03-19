using Invoicing.Core.Data;
using Invoicing.Core.Interfaces;
using Invoicing.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Repositories
{
    public class ClientRepository: BaseRepository<Client>, IClientRepository
    {

        public ClientRepository(invoicingContext context ) : base(context) { }     
    }
}
