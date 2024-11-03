using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class FinancialInstitution
    {
        public Guid Id { get; set; }
        public required string AccountNumber { get; set; }
        public required string Document { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
