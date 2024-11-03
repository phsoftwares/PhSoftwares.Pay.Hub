using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/payment/pix")]
    public class PaymentPixController : ControllerBase
    {
        private readonly ILogger<PaymentPixController> _logger;

        public PaymentPixController(ILogger<PaymentPixController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public MakePaymentOutputDTO PostMakePaymentPix(MakePaymentInputDTO input)
        {
            input.PaymentMethod.MakePayment();
            return new MakePaymentOutputDTO
            {
                Success = true,
                Message = "Request received - PIX"
            };
        }
    }
}
