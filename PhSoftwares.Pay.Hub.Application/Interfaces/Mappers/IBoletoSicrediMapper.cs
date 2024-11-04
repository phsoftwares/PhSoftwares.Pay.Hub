using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;

namespace PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers
{
    public interface IBoletoSicrediMapper
    {
        Task<BoletoSicrediInputDTO> MapBoletoInput(MakePaymentInputDTO inputDTO);
        Task<BoletoPaymentDetailsDTO> MapBoletoSicrediOutputToNormalized(BoletoSicrediOutputDTO inputDTO);
    }
}
