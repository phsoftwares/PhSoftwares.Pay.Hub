using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment
{
    public class PaymentOutputDTO
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public ErrorDetailsDTO ErrorDetails { get; set; }
    }
}
