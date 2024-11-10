using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Inter;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IBoletoInterService
    {
        Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoInterInputDTO inputDTO);
        Task<BoletoInterInputDTO> CreateBoletoInput(CreatePaymentBoletoInterInputDTO inputDTO);
        Task<BoletoInterOutputDTO> RegisterBillingBoleto(BoletoInterInputDTO inputDTO, InterAuthorizationDetailsDTO authorizationDetailsDTO);
    }
}
