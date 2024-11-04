using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;

namespace PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto
{
    public class CreatePaymentBoletoSicrediInputDTO : CreatePaymentBoletoBaseDTO
    {
        public SicrediAuthorizationDetailsDTO AuthorizationDetails { get; set; }
    }
}
