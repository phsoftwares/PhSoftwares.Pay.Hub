using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi.Pessoa;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;

namespace PhSoftwares.Pay.Hub.Application.Mappers
{
    public class BoletoSicrediMapper : IBoletoSicrediMapper
    {
        public Task<BoletoSicrediInputDTO> MapBoletoInput(MakePaymentInputDTO inputDTO)
        {
            throw new NotImplementedException();
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

        private BeneficiarioFinalSicrediDTO GetBeneficiarioFinalSicrediDTO(RecipientDTO recipientDTO)
        {
            return new BeneficiarioFinalSicrediDTO()
            {
                Cep = recipientDTO.Adress.ZipCode,
                Cidade = recipientDTO.Adress.City,
                Documento = recipientDTO.DocumentNumber,
                Logradouro = recipientDTO.Adress.Street,
                Nome = recipientDTO.FullName,
                NumeroEndereco = recipientDTO.Adress.Number,
                TipoPessoa = "TODO: VOLTAR AQUI",
                Uf = recipientDTO.Adress.State
            };
        }
        private PagadorSicrediDTO GetPagadorSicrediDTO(PayerDTO payerDTO)
        {
            return new PagadorSicrediDTO()
            {
                Cep = payerDTO.Adress.ZipCode,
                Cidade = payerDTO.Adress.City,
                Documento = payerDTO.DocumentNumber,
                Endereco = payerDTO.Adress.Street,
                Nome = payerDTO.FullName,
                TipoPessoa = "TODO: VOLTAR AQUI",
                Uf = payerDTO.Adress.State
            };
        }
    }
}
