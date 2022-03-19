using AutoMapper;
using Invoicing.Core.Data;
using Invoicing.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

        }
    }
}
