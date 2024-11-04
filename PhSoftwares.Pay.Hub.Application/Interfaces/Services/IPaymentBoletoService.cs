using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPaymentBoletoService
    {
        Task<BoletoPaymentOutputDTO> CreatePaymentBoletoSicredi(CreatePaymentBoletoSicrediInputDTO inputDTO);
        Task<BoletoPaymentOutputDTO> CreatePaymentBoletoBancoBrasil(CreatePaymentBoletoBancoBrasilInputDTO inputDTO);
    }
}
