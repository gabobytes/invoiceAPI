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
        private readonly IInvoiceProductService _invoiceProductService;

        public InvoiceController(IInvoiceService invoiceService, 
            IMapper mapper,
            IInvoiceProductService invoiceProductService)
        {
            _invoiceService = invoiceService;
            _invoiceProductService = invoiceProductService;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> PostInvoice(InvoiceRegisterDTO invoiceRegisterDto)
        {
            var invoiceDto = new Invoice() {
                Idclient = invoiceRegisterDto.Idclient,
                Date = DateTime.Now
            };
            var invoice = _mapper.Map<Invoice>(invoiceDto);

            var idFactura = await _invoiceService.InsertInvoice(invoice);

            try
            {
                foreach (var item in invoiceRegisterDto.ProductsInvoice)
                {
                    var detailInvoice = new InvoiceProduct()
                    {
                        Idinvoice = idFactura,
                        Idproduct = item.Id,
                        Quantity = item.Quantity,
                        Value = item.Value
                        
                    };
                    await _invoiceProductService.InsertInvoiceProduct(detailInvoice);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

            return Ok();
        }
    }
}
