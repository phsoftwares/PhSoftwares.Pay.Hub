namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter
{
    public class BoletoInterOutputDTO
    {
        public BoletoInterDTO Boleto { get; set; }
        public PixInterDTO Pix { get; set; }
    }
    public class BoletoInterDTO
    {
        public string NossoNumero { get; set; }
        public string CodigoBarras { get; set; }
        public string LinhaDigitavel { get; set; }
    }
    public class PixInterDTO
    {
        public string Txid { get; set; }
        public string PixCopiaECola { get; set; }
    }

}
