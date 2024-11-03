using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.PaymentMethod
{
    public class BoletoPaymentMethodDTO:PaymentMethodDTO
    {
        public required string OurNumber { get; set; }
        public override void MakePayment()
        {
            Console.WriteLine("Boleto pay test");
        }
    }
}
