using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/payment/boleto")]
    [Authorize]
    public class PaymentBoletoController : Controller
    {
        private readonly ILogger<PaymentBoletoController> _logger;
        private readonly IPaymentBoletoService _paymentBoletoService;

        public PaymentBoletoController(ILogger<PaymentBoletoController> logger, IPaymentBoletoService paymentBoletoService)
        {
            _logger = logger;
            _paymentBoletoService = paymentBoletoService;
        }

        [HttpPost]
        public async Task<BoletoPaymentOutputDTO> MakePayment(MakePaymentInputDTO input)
        {
            return await _paymentBoletoService.MakePayment(input);
        }
    }
}
