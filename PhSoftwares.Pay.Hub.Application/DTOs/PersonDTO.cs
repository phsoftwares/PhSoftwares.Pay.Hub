using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class PersonDTO
    {
        public Guid? Id { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string DocumentNumber { get; set; }
        public AddressDTO Adress { get; set; }
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
