using Microsoft.AspNetCore.Components.Forms;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi.Pessoa;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;
using System.Text.RegularExpressions;

namespace PhSoftwares.Pay.Hub.Application.Mappers
{
    public class BoletoSicrediMapper : IBoletoSicrediMapper
    {
        public Task<BoletoSicrediInputDTO> MapBoletoInput(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            return Task.FromResult(new BoletoSicrediInputDTO()
            {
                beneficiarioFinal = GetBeneficiarioFinalSicrediDTO(inputDTO),
                pagador = GetPagadorSicrediDTO(inputDTO.Payer),
                valor = inputDTO.PaymentMethod.NetValue,
                valorDesconto1 = inputDTO.PaymentMethod.DiscountValue,
                nossoNumero = inputDTO.PaymentMethod.OurNumber,
                seuNumero = inputDTO.PaymentMethod.YourNumber,
                dataVencimento = inputDTO.PaymentMethod.ExpirationDate,
                especieDocumento = inputDTO.PaymentMethod.DocumentType,
                juros = inputDTO.PaymentMethod.InterestValue,
                tipoCobranca = inputDTO.PaymentMethod.TypeCharge,
                codigoBeneficiario = inputDTO.AuthorizationDetails.RecipientCode,
                tipoJuros = "VALOR"
            });
        }

        public Task<BoletoPaymentDetailsDTO> MapBoletoSicrediOutputToNormalized(BoletoSicrediOutputDTO inputDTO)
        {
            return Task.FromResult(new BoletoPaymentDetailsDTO()
            {
                TransactionId = inputDTO.Txid,
                BarCode = inputDTO.CodigoBarras,
                Cooperative = inputDTO.Cooperativa,
                DigitableLine = inputDTO.LinhaDigitavel,
                OurNumber = inputDTO.NossoNumero,
                Post = inputDTO.Posto,
                QrCode = inputDTO.QrCode
            });
        }

        public Task<ErrorDetailsDTO> MapErrorDetails(BoletoSicrediErroOutputDTO inputDTO)
        {
            if (inputDTO == null)
            {
                return Task.FromResult(new ErrorDetailsDTO()
                {
                    Message = "",
                    Code = "200"
                });
            }
            return Task.FromResult(new ErrorDetailsDTO()
            {
                Message = inputDTO.Message,
                Code = inputDTO.Code
            });
        }

        private BeneficiarioFinalSicrediDTO GetBeneficiarioFinalSicrediDTO(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            return new BeneficiarioFinalSicrediDTO()
            {
                cep = Regex.Replace(inputDTO.Recipient.Adress.ZipCode, @"\D", ""),
                cidade = inputDTO.Recipient.Adress.City,
                documento = Regex.Replace(inputDTO.Recipient.DocumentNumber, @"\D", ""),
                logradouro = inputDTO.Recipient.Adress.Street,
                nome = inputDTO.Recipient.FullName,
                numeroEndereco = inputDTO.Recipient.Adress.Number,
                tipoPessoa = "PESSOA_FISICA", //TODO: VOLTAR AQUI DEPOIS
                uf = inputDTO.Recipient.Adress.State,
                codigoBeneficiario = inputDTO.AuthorizationDetails.RecipientCode
            };
        }
        private PagadorSicrediDTO GetPagadorSicrediDTO(PayerDTO payerDTO)
        {
            return new PagadorSicrediDTO()
            {
                cep = Regex.Replace(payerDTO.Adress.ZipCode, @"\D", ""),
                cidade = payerDTO.Adress.City,
                documento = Regex.Replace(payerDTO.DocumentNumber, @"\D", ""),
                endereco = payerDTO.Adress.Street,
                nome = payerDTO.FullName,
                tipoPessoa = "PESSOA_FISICA", //TODO: VOLTAR AQUI DEPOIS
                uf = payerDTO.Adress.State
            };
        }
    }
}
