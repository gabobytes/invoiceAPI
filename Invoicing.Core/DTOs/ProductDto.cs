using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public decimal Value { get; set; }
    }
}
