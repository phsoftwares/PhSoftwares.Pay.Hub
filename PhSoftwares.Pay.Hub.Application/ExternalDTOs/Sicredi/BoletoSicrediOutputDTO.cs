using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Sicredi;

namespace PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi
{
    public class BoletoSicrediOutputDTO
    {
        public string Txid { get; set; }
        public string QrCode { get; set; }
        public string LinhaDigitavel { get; set; }
        public string CodigoBarras { get; set; }
        public string Cooperativa { get; set; } 
        public string Posto { get; set; } 
        public string NossoNumero { get; set; }
        public BoletoSicrediErroOutputDTO DetalhesErro { get; set; }
    }
}
