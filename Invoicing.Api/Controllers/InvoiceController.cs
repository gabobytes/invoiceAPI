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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _invoiceService.GetInvoices();
            var invoicesDto = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            var response = new ApiResponse<IEnumerable<InvoiceDto>>(invoicesDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);

            await _invoiceService.InsertInvoice(invoice);

            invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            var response = new ApiResponse<InvoiceDto>(invoiceDto);

            int idFactua = response.Data.Id;

            return Ok(response.Data.Id);
        }
    }
}
