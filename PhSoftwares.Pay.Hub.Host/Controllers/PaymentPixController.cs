using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/payment/pix")]
    public class PaymentPixController : Controller
    {
        private readonly IPaymentPixService _paymentPixService;

        public PaymentPixController(IPaymentPixService paymentPixService)
        {
            _paymentPixService = paymentPixService;
        }

        [HttpPost]
        public async Task<MakePaymentOutputDTO> PostMakePaymentPix(MakePaymentInputDTO input)
        {
            return await _paymentPixService.MakePayment(input);
        }
    }
}
