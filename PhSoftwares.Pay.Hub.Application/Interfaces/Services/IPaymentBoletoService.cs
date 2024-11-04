using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPaymentBoletoService
    {
        Task<BoletoPaymentOutputDTO> MakePayment(MakePaymentInputDTO makePaymentInputDTO);
    }
}
