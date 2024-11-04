using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;

namespace PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers
{
    public interface IBoletoSicrediMapper
    {
        Task<BoletoSicrediInputDTO> MapBoletoInput(CreatePaymentBoletoSicrediInputDTO inputDTO);
        Task<BoletoPaymentDetailsDTO> MapBoletoSicrediOutputToNormalized(BoletoSicrediOutputDTO inputDTO);
        Task<ErrorDetailsDTO> MapErrorDetails(BoletoSicrediErroOutputDTO inputDTO);
    }
}
