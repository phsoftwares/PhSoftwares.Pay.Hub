using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Mappers
{
    public interface IBoletoInterMapper
    {
        Task<BoletoInterInputDTO> MapBoletoInput(CreatePaymentBoletoInterInputDTO inputDTO);
        Task<BoletoPaymentDetailsDTO> MapBoletoSicrediOutputToNormalized(BoletoInterOutputDTO inputDTO);
        Task<ErrorDetailsDTO> MapErrorDetails(BoletoDetalhesErroInterOutputDTO inputDTO);
    }
}
