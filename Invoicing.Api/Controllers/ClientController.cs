using AutoMapper;
using Invoicing.Api.Responses;
using Invoicing.Core.Data;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient (int id)
        {
            var client = await _clientService.GetClient(id);
            var clientDto = _mapper.Map<ClientDto>(client);
            var response = new ApiResponse<ClientDto>(clientDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);

            await _clientService.InsertClient(client);

            clientDto = _mapper.Map<ClientDto>(client);
            var response = new ApiResponse<ClientDto>(clientDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;

            var result = await _clientService.UpdateClient(client);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteClient(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

    }
}
