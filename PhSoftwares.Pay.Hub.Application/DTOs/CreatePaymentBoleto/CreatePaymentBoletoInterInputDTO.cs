using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Inter;

namespace PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto
{
    public class CreatePaymentBoletoInterInputDTO: CreatePaymentBoletoBaseDTO
    {
        public InterAuthorizationDetailsDTO AuthorizationDetails { get; set; }
    }
}
