using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod
{
    public class BoletoPaymentMethodDTO : PaymentMethodDTO
    {
        public string OurNumber { get; set; }
        public string YourNumber { get; set; }
        public string DocumentType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal? InterestValue { get; set; }
        public string TypeCharge { get; set; }
    }
}
