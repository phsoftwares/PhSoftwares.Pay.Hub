using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment
{
    public class MakePaymentOutputDTO
    {
        public Guid PaymentId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
