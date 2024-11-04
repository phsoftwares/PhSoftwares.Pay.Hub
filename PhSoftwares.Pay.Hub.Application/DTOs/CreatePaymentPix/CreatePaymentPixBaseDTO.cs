using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;

namespace PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto
{
    public class CreatePaymentPixBaseDTO
    {
        public PayerDTO Payer { get; set; }
        public RecipientDTO Recipient { get; set; }
        public BoletoPaymentMethodDTO PaymentMethod { get; set; }
    }
}
