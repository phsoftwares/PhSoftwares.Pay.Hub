using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
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
        private readonly IPayeeService _payeeService;

        public PaymentPixService(IPayerService payerService, IPayeeService payeeService)
        {
            _payerService = payerService;
            _payeeService = payeeService;
        }

        public async Task<BoletoPaymentOutputDTO> CreatePaymentPixSicredi(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(inputDTO.Payer);
            var payeeDTO = await UpsertPayeeByDocument(inputDTO.Payee);
            //makePaymentInputDTO.PaymentMethod.MakePayment();

            return await Task.FromResult(new BoletoPaymentOutputDTO
            {
                Success = true
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

        private async Task<PayeeDTO> UpsertPayeeByDocument(PayeeDTO payeeDTO)
        {
            var payeeId = await _payeeService.GetIdIfDocumentIsRegistred(payeeDTO.DocumentNumber);
            if (payeeId == Guid.Empty)
            {
                return await _payeeService.Insert(payeeDTO);
            }
            else
            {
                return await _payeeService.UpdateWithId(payeeDTO, payeeId);
            }
        }
    }
}
