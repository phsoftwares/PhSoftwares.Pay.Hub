using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment
{
    public class MakePaymentInputDTO
    {
        public PaymentMethodDTO PaymentMethod { get; set; }
        public PayerDTO Payer { get; set; }
        public RecipientDTO Recipient { get; set; }
    }
}
