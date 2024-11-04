using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.BancoBrasil;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IBoletoBancoBrasilService
    {
        Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoBancoBrasilInputDTO inputDTO);
        Task<BoletoBancoBrasilInputDTO> CreateBoletoInput(CreatePaymentBoletoBancoBrasilInputDTO inputDTO);
        Task<BoletoBancoBrasilOutputDTO> RegisterBillingBoleto(BoletoBancoBrasilInputDTO inputDTO, BancoBrasilAuthorizationDetailsDTO authorizationDetailsDTO);
    }
}
