using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod
{
    public class CreditCardPaymentMethodDTO : PaymentMethodDTO
    {
        public CardDetails CardDetails { get; set; }
    }
}
