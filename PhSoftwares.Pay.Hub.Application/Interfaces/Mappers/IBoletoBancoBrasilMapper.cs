using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Mappers
{
    public interface IBoletoBancoBrasilMapper
    {
        Task<BoletoBancoBrasilInputDTO> MapBoletoInput(CreatePaymentBoletoBancoBrasilInputDTO inputDTO);
        Task<BoletoPaymentDetailsDTO> MapBoletoBancoBrasilOutputToNormalized(BoletoBancoBrasilOutputDTO inputDTO);
        Task<ErrorDetailsDTO> MapErrorDetails(BoletoBancoBrasilErroOutputDTO inputDTO);
    }
}
