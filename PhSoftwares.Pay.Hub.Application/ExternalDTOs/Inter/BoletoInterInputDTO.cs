using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter.Pessoa;

namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter
{
    public  class BoletoInterInputDTO
    {
        public string seuNumero { get; set; }
        public decimal valorNominal { get; set; }
        public string dataVencimento { get; set; }
        public int numDiasAgenda { get; set; } = 0;
        public PagadorInterDTO pagador { get; set; }
        public BoletoDescontoInterDTO desconto { get; set; }
        public BoletoMultaInterDTO multa { get; set; }
        public BoletoMoraInterDTO mora { get; set; }
        public BoletoMensagemInterDTO mensagem { get; set; }
        public BeneficiarioFinalInterDTO beneficiarioFinal { get; set; }
        public List<string> formasRecebimento { get; set; }
    }
}
