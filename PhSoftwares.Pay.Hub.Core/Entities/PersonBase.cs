using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class PersonBase
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string DocumentNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public Guid CreationUserId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string AddressNeighborhood { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressState { get; set; }
        public string ZipCode { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
