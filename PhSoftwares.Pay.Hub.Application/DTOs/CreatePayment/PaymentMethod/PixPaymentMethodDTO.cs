using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod
{
    public class PixPaymentMethodDTO : PaymentMethodDTO
    {
        public string KeyPix { get; set; }
        public PixPaymentMethodDTO() { }
    }
}
