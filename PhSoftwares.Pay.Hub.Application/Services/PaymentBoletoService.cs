﻿using Microsoft.AspNetCore.Components.Forms;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
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

        public async Task<BoletoPaymentOutputDTO> MakePayment(MakePaymentInputDTO makePaymentInputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(makePaymentInputDTO.Payer);
            var recipientDTO = await UpsertRecipientByDocument(makePaymentInputDTO.Recipient);
            if (makePaymentInputDTO.PaymentMethod is BoletoPaymentMethodDTO boletoPaymentMethod && boletoPaymentMethod.AuthorizationDetails is SicrediAuthorizationDetailsDTO authorizationDetails)
            {
                return await _boletoSicrediService.StartBillingRegistration(makePaymentInputDTO);
            }
            return null;
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
