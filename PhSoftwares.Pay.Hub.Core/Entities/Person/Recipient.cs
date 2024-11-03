using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities.Person
{
    public class Recipient: PersonBase
    {
        public string BankAgency { get; set; }
        public string BankAccount { get; set; }
    }
}
