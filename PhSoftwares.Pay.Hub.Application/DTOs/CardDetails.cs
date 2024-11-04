using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class CardDetails
    {
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { set; get; }    
    }
}
