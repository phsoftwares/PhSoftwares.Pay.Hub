namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil
{
    public class BoletoBancoBrasilOutputDTO
    {
        public BoletoBancoBrasilQrCodeDTO qrCode { get; set; }
        public string numero { get; set; }
        public int numeroCarteira { get; set; }
        public int numeroVariacaoCarteira { get; set; }
        public int codigoCliente { get; set; }
        public string linhaDigitavel { get; set; }
        public string codigoBarraNumerico { get; set; }
        public int numeroContratoCobranca { get; set; }
        public string observacao { get; set; }
        public BoletoBancoBrasilErroOutputDTO DetalhesErro { get; set; }
    }
}
