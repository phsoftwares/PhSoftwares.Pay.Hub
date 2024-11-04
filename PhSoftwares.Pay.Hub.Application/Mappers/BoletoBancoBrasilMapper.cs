using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil.Pessoa;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappers;
using System.Text.RegularExpressions;

namespace PhSoftwares.Pay.Hub.Application.Mappers
{
    public class BoletoBancoBrasilMapper : IBoletoBancoBrasilMapper
    {
        public Task<BoletoBancoBrasilInputDTO> MapBoletoInput(CreatePaymentBoletoBancoBrasilInputDTO inputDTO)
        {
            return Task.FromResult(new BoletoBancoBrasilInputDTO()
            {
                pagador = GetPagadorBancoBrasilDTO(inputDTO.Payer),
                beneficiarioFinal = GetBeneficiarioFinalBancoBrasilDTO(inputDTO),
                numeroTituloCliente = inputDTO.PaymentMethod.OurNumber,
                codigoAceite = "A",
                codigoTipoTitulo = "02",
                descricaoTipoTitulo = "DM",
                indicadorPix = "S",
                textoEnderecoEmail = inputDTO.Payee.EmailAddress,
                mensagemBloquetoOcorrencia = "",
                numeroTituloBeneficiario = inputDTO.PaymentMethod.YourNumber,
                numeroDiasLimiteRecebimento = "",
                indicadorAceiteTituloVencido = "S",
                valorOriginal = inputDTO.PaymentMethod.NetValue,
                dataEmissao = inputDTO.PaymentMethod.CreatedDateTime.ToString("dd.MM.yyyy"),
                dataVencimento = inputDTO.PaymentMethod.ExpirationDate.ToString("dd.MM.yyyy"),
                codigoModalidade = 1,
                numeroConvenio = inputDTO.Payee.AgreementNumber ?? 0,
                numeroCarteira = inputDTO.Payee.WalletNumber ?? 0,
                numeroVariacaoCarteira = inputDTO.Payee.WalletVariationNumber ?? 0,
                desconto = new BoletoDescontoBancoBrasilDTO()
                {
                    tipo = 0
                },
                jurosMora = new BoletoJurosMoraBancoBrasilDTO()
                {
                    tipo = 1,
                    valor = inputDTO.PaymentMethod.InterestValue ?? 0,
                    porcentagem = 0
                },
                multa = new BoletoMultaBancoBrasilDTO()
                {
                    tipo = 0,
                    dados = "",
                    porcentagem = 0,
                    valor = inputDTO.PaymentMethod.IncreaseValue
                }
            });
        }

        public Task<BoletoPaymentDetailsDTO> MapBoletoBancoBrasilOutputToNormalized(BoletoBancoBrasilOutputDTO inputDTO)
        {
            return Task.FromResult(new BoletoPaymentDetailsDTO()
            {
                TransactionId = inputDTO.qrCode.TxId,
                BarCode = inputDTO.codigoBarraNumerico,
                Cooperative = inputDTO.codigoCliente.ToString(),
                DigitableLine = inputDTO.linhaDigitavel,
                OurNumber = inputDTO.numero,
                Post = inputDTO.numeroCarteira.ToString(),
                QrCode = inputDTO.qrCode.Emv
            });
        }

        public Task<ErrorDetailsDTO> MapErrorDetails(BoletoBancoBrasilErroOutputDTO inputDTO)
        {
            if (inputDTO == null || inputDTO.erros.Count == 0)
            {
                return Task.FromResult(new ErrorDetailsDTO()
                {
                    Message = "",
                    Code = "200"
                });
            }
            return Task.FromResult(new ErrorDetailsDTO()
            {
                Message = inputDTO.erros[0].mensagem,
                Code = inputDTO.erros[0].codigo
            });
        }

        private BeneficiarioFinalBancoBrasilDTO GetBeneficiarioFinalBancoBrasilDTO(CreatePaymentBoletoBancoBrasilInputDTO inputDTO)
        {
            return new BeneficiarioFinalBancoBrasilDTO()
            {
                tipoInscricao = 2, //TODO: VOLTAR AQUI DEPOIS
                nome = inputDTO.Payee.FullName,
                numeroInscricao = long.Parse(Regex.Replace(inputDTO.Payee.DocumentNumber, @"\D", "")),
            };
        }
        private PagadorBancoBrasilDTO GetPagadorBancoBrasilDTO(PayerDTO payerDTO)
        {
            return new PagadorBancoBrasilDTO()
            {
                cep = long.Parse(Regex.Replace(payerDTO.Adress.ZipCode, @"\D", "")),
                cidade = payerDTO.Adress.City,
                numeroInscricao = long.Parse(Regex.Replace(payerDTO.DocumentNumber, @"\D", "")),
                endereco = payerDTO.Adress.Street,
                nome = payerDTO.FullName,
                tipoInscricao = 2, //TODO: VOLTAR AQUI DEPOIS
                uf = payerDTO.Adress.State,
                bairro = payerDTO.Adress.Neighborhood,
                telefone = payerDTO.PhoneNumber
            };
        }
    }
}
