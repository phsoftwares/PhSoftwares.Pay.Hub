using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IBoletoSicrediService
    {
        Task<BoletoPaymentOutputDTO> StartBillingRegistration(MakePaymentInputDTO inputDTO);
        Task<BoletoSicrediInputDTO> CreateBoletoInput(MakePaymentInputDTO inputDTO);
        Task<BoletoSicrediOutputDTO> RegisterBillingBoleto(BoletoSicrediInputDTO inputDTO, SicrediAuthorizationDetailsDTO authorizationDetailsDTO);
    }
}
