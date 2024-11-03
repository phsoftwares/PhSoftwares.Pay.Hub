using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class PaymentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
