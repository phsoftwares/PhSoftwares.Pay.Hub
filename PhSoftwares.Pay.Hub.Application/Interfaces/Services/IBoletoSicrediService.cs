using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IBoletoSicrediService
    {
        Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoSicrediInputDTO inputDTO);
        Task<BoletoSicrediInputDTO> CreateBoletoInput(CreatePaymentBoletoSicrediInputDTO inputDTO);
        Task<BoletoSicrediOutputDTO> RegisterBillingBoleto(BoletoSicrediInputDTO inputDTO, SicrediAuthorizationDetailsDTO authorizationDetailsDTO);
    }
}
