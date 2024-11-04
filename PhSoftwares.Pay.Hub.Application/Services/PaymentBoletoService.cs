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
        private readonly IPayeeService _payeeService;
        private readonly IBoletoSicrediService _boletoSicrediService;
        private readonly IBoletoBancoBrasilService _boletoBancoBrasilService;

        public PaymentBoletoService(IPayerService payerService, IPayeeService payeeService, IBoletoSicrediService boletoSicrediService, IBoletoBancoBrasilService boletoBancoBrasilService)
        {
            _payerService = payerService;
            _payeeService = payeeService;
            _boletoSicrediService = boletoSicrediService;
            _boletoBancoBrasilService = boletoBancoBrasilService;
        }

        public async Task<BoletoPaymentOutputDTO> CreatePaymentBoletoSicredi(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(inputDTO.Payer);
            var payeeDTO = await UpsertPayeeByDocument(inputDTO.Payee);
            return await _boletoSicrediService.StartBillingRegistration(inputDTO);
        }

        public async Task<BoletoPaymentOutputDTO> CreatePaymentBoletoBancoBrasil(CreatePaymentBoletoBancoBrasilInputDTO inputDTO)
        {
            var payerDTO = await UpsertPayerByDocument(inputDTO.Payer);
            var payeeDTO = await UpsertPayeeByDocument(inputDTO.Payee);
            return await _boletoBancoBrasilService.StartBillingRegistration(inputDTO);
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
