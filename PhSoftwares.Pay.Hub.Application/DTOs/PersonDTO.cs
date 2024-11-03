using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class PersonDTO
    {
        public required string FullName { get; set; }
        public required string DocumentNumber { get; set; }
        public AddressDTO Adress { get; set; }
    }
}
