using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.BancoBrasil;

namespace PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto
{
    public class CreatePaymentBoletoBancoBrasilInputDTO: CreatePaymentBoletoBaseDTO
    {
        public BancoBrasilAuthorizationDetailsDTO AuthorizationDetails { get; set; }
    }
}
