using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi.Pessoa;

namespace PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi
{
    public class BoletoSicrediInputDTO
    {
        public BeneficiarioFinalSicrediDTO beneficiarioFinal { get; set; }
        public string especieDocumento { get; set; }
        public string tipoCobranca { get; set; }
        public string codigoBeneficiario { get; set; }
        public PagadorSicrediDTO pagador { get; set; }     
        public string nossoNumero { get; set; }
        public string seuNumero { get; set; }
        public DateTime dataVencimento { get; set; }
        public int? diasProtestoAuto { get; set; }
        public int? diasNegativacaoAuto { get; set; }
        public int? validadeAposVencimento { get; set; }
        public decimal valor { get; set; }
        public string tipoDesconto { get; set; }
        public decimal? valorDesconto1 { get; set; }
        public DateTime? dataDesconto1 { get; set; }
        public decimal? valorDesconto2 { get; set; }
        public DateTime? dataDesconto2 { get; set; }
        public decimal? valorDesconto3 { get; set; }
        public DateTime? dataDesconto3 { get; set; }
        public decimal? descontoAntecipado { get; set; }
        public string tipoJuros { get; set; }
        public decimal? juros { get; set; }
        public decimal? multa { get; set; }
        public List<string> informativos { get; set; }
        public List<string> mensagens { get; set; }
    }
}
