using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.PaymentMethod
{
    public class PixPaymentMethodDTO:PaymentMethodDTO
    {
        public override void MakePayment()
        {
            Console.WriteLine("Pix pay test");
        }
    }
}
