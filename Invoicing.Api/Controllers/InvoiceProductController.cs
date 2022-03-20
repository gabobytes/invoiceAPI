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
    public class InvoiceProductController : ControllerBase
    {
        private readonly IInvoiceProductService _invoiceProductService;
        private readonly IMapper _mapper;

        public InvoiceProductController(IInvoiceProductService invoiceProductService,IMapper mapper)
        {
            _invoiceProductService = invoiceProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetInvoicesProducts()
        {
            var invoiceproduct = _invoiceProductService.GetInvoicesProducts();
            var invoiceproductDto = _mapper.Map<IEnumerable<InvoiceProductDto>>(invoiceproduct);
            var response = new ApiResponse<IEnumerable<InvoiceProductDto>>(invoiceproductDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InvoiceProductDto invoiceproductDto)
        {
            var invoiceProduct = _mapper.Map<InvoiceProduct>(invoiceproductDto);

            await _invoiceProductService.InsertInvoiceProduct(invoiceProduct);

            invoiceproductDto = _mapper.Map<InvoiceProductDto>(invoiceProduct);
            var response = new ApiResponse<InvoiceProductDto>(invoiceproductDto);

            return Ok(response);
        }

    }
}
