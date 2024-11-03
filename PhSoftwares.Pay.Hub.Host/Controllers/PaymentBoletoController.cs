using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/payment/boleto")]
    public class PaymentBoletoController : ControllerBase
    {
        private readonly ILogger<PaymentBoletoController> _logger;

        public PaymentBoletoController(ILogger<PaymentBoletoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public MakePaymentOutputDTO PostMakePaymentBoleto(MakePaymentInputDTO input)
        {
            input.PaymentMethod.MakePayment();
            return new MakePaymentOutputDTO
            {
                Success = true,
                Message = "Request received - BOLETO"
            };
        }
    }
}