using AutoMapper;
using Invoicing.Api.Responses;
using Invoicing.Core.DTOs;
using Invoicing.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _clientService.GetClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            var response = new ApiResponse<IEnumerable<ClientDto>>(clientsDto);

            return Ok(response);
        }
    }
}
