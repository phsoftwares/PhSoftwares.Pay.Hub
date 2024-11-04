namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment
{
    public class BoletoPaymentDetailsDTO
    {
        public string TransactionId { get; set; }
        public string QrCode { get; set; }
        public string DigitableLine { get; set; }
        public string BarCode { get; set; }
        public string Cooperative { get; set; }
        public string Post { get; set; }
        public string OurNumber { get; set; }
    }
}
