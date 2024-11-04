using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;

namespace PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto
{
    public class CreatePaymentPixSicrediInputDTO : CreatePaymentPixBaseDTO
    {
        public SicrediAuthorizationDetailsDTO AuthorizationDetails { get; set; }
    }
}
