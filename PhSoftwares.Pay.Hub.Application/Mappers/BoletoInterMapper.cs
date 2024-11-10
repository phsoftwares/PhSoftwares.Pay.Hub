using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter.Pessoa;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappers;
using System.Text.RegularExpressions;

namespace PhSoftwares.Pay.Hub.Application.Mappers
{
    public class BoletoInterMapper : IBoletoInterMapper
    {
        public Task<BoletoInterInputDTO> MapBoletoInput(CreatePaymentBoletoInterInputDTO inputDTO)
        {
            return Task.FromResult(new BoletoInterInputDTO()
            {
                pagador = GetPagadorInterDTO(inputDTO.Payer),
                beneficiarioFinal = GetBeneficiarioFinalInterDTO(inputDTO),
                dataVencimento = inputDTO.PaymentMethod.ExpirationDate.ToString("dd.MM.yyyy"),
                desconto = new BoletoDescontoInterDTO()
                {
                },
                mora = new BoletoMoraInterDTO()
                {
                },
                multa = new BoletoMultaInterDTO()
                {
                }
            });
        }

        public Task<BoletoPaymentDetailsDTO> MapBoletoSicrediOutputToNormalized(BoletoInterOutputDTO inputDTO)
        {
            return Task.FromResult(new BoletoPaymentDetailsDTO()
            {
                TransactionId = inputDTO.Pix.Txid,
                BarCode = inputDTO.Boleto.CodigoBarras,
                DigitableLine = inputDTO.Boleto.LinhaDigitavel,
                OurNumber = inputDTO.Boleto.NossoNumero,
                QrCode = inputDTO.Pix.PixCopiaECola
            });
        }

        public Task<ErrorDetailsDTO> MapErrorDetails(BoletoDetalhesErroInterOutputDTO inputDTO)
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
                Message = inputDTO.detail,
                Code = "400"
            });
        }

        private BeneficiarioFinalInterDTO GetBeneficiarioFinalInterDTO(CreatePaymentBoletoInterInputDTO inputDTO)
        {
            return new BeneficiarioFinalInterDTO()
            {
                tipoPessoa = "2", //TODO: VOLTAR AQUI DEPOIS
                nome = inputDTO.Payee.FullName,
                cpfCnpj = Regex.Replace(inputDTO.Payee.DocumentNumber, @"\D", ""),
            };
        }
        private PagadorInterDTO GetPagadorInterDTO(PayerDTO payerDTO)
        {
            return new PagadorInterDTO()
            {
                cep = Regex.Replace(payerDTO.Adress.ZipCode, @"\D", ""),
                cidade = payerDTO.Adress.City,
                cpfCnpj = Regex.Replace(payerDTO.DocumentNumber, @"\D", ""),
                endereco = payerDTO.Adress.Street,
                nome = payerDTO.FullName,
                tipoPessoa = "2", //TODO: VOLTAR AQUI DEPOIS
                uf = payerDTO.Adress.State,
                bairro = payerDTO.Adress.Neighborhood,
                telefone = payerDTO.PhoneNumber
            };
        }
    }
}
