using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi.Pessoa;

namespace PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi
{
    public class BoletoSicrediInputDTO
    {
        public string TipoCobranca { get; set; }
        public string CodigoBeneficiario { get; set; }
        public PagadorSicrediDTO Pagador { get; set; }
        public BeneficiarioFinalSicrediDTO BeneficiarioFinal { get; set; }
        public string EspecieDocumento { get; set; }
        public string NossoNumero { get; set; }
        public string SeuNumero { get; set; }
        public DateTime DataVencimento { get; set; }
        public int? DiasProtestoAuto { get; set; }
        public int? DiasNegativacaoAuto { get; set; }
        public int? ValidadeAposVencimento { get; set; }
        public decimal Valor { get; set; }
        public string TipoDesconto { get; set; }
        public decimal? ValorDesconto1 { get; set; }
        public DateTime? DataDesconto1 { get; set; }
        public decimal? ValorDesconto2 { get; set; }
        public DateTime? DataDesconto2 { get; set; }
        public decimal? ValorDesconto3 { get; set; }
        public DateTime? DataDesconto3 { get; set; }
        public decimal? DescontoAntecipado { get; set; }
        public string TipoJuros { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public List<string> Informativo { get; set; }
        public List<string> Mensagem { get; set; }
    }
}
