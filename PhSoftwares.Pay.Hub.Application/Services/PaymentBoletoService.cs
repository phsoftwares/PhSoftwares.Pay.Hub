using Microsoft.AspNetCore.Components.Forms;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class PaymentBoletoService : IPaymentBoletoService
    {
        private readonly IPayerService _payerService;
        private readonly IRecipientService _recipientService;
        private readonly IBoletoSicrediService _boletoSicrediService;

        public PaymentBoletoService(IPayerService payerService, IRecipientService recipientService, IBoletoSicrediService boletoSicrediService)
        {
            _payerService = payerService;
            _recipientService = recipientService;
            _boletoSicrediService = boletoSicrediService;
        }

        public async Task<BoletoPaymentOutputDTO> CreatePaymentBoletoSicredi(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(inputDTO.Payer);
            var recipientDTO = await UpsertRecipientByDocument(inputDTO.Recipient);
            return await _boletoSicrediService.StartBillingRegistration(inputDTO);
        }

        private async Task<PayerDTO> UpsertPayerByDocument(PayerDTO payerDTO)
        {
            var payerId = await _payerService.GetIdIfDocumentIsRegistred(payerDTO.DocumentNumber);
            if (payerId == Guid.Empty)
            {
                return await _payerService.Insert(payerDTO);
            }
            else
            {
                return await _payerService.UpdateWithId(payerDTO, payerId);
            }
        }

        private async Task<RecipientDTO> UpsertRecipientByDocument(RecipientDTO recipientDTO)
        {
            var recipientId = await _recipientService.GetIdIfDocumentIsRegistred(recipientDTO.DocumentNumber);
            if (recipientId == Guid.Empty)
            {
                return await _recipientService.Insert(recipientDTO);
            }
            else
            {
                return await _recipientService.UpdateWithId(recipientDTO, recipientId);
            }
        }
    }
}
