using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class PaymentPixService : IPaymentPixService
    {
        private readonly IPayerService _payerService;
        private readonly IRecipientService _recipientService;

        public PaymentPixService(IPayerService payerService, IRecipientService recipientService)
        {
            _payerService = payerService;
            _recipientService = recipientService;
        }

        public async Task<MakePaymentOutputDTO> MakePayment(MakePaymentInputDTO makePaymentInputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(makePaymentInputDTO.Payer);
            var recipientDTO = await UpsertRecipientByDocument(makePaymentInputDTO.Recipient);
            makePaymentInputDTO.PaymentMethod.MakePayment();

            return await Task.FromResult(new MakePaymentOutputDTO
            {
                Success = true,
                Message = "Request received - PIX"
            });
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
