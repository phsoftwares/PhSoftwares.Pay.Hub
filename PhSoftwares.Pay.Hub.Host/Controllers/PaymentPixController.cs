using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/payment/pix")]
    [Authorize]
    public class PaymentPixController : Controller
    {
        private readonly IPaymentPixService _paymentPixService;

        public PaymentPixController(IPaymentPixService paymentPixService)
        {
            _paymentPixService = paymentPixService;
        }

       /* [HttpPost]  
        public async Task<BoletoPaymentOutputDTO> PostMakePaymentPix(MakePaymentInputDTO input)
        {
            var userId = Guid.Parse(User.FindFirst("id").Value);
            input.Payee.SetCreationUserId(userId);
            input.Payer.SetCreationUserId(userId);
            return await _paymentPixService.MakePayment(input);
        } */
    }
}
