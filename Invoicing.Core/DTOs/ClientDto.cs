using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}
