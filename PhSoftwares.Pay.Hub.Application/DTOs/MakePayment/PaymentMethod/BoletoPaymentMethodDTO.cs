using Microsoft.AspNetCore.Components.Forms;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;

namespace PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod
{
    public class BoletoPaymentMethodDTO : PaymentMethodDTO
    {
        public required string OurNumber { get; set; }
        public AuthorizationDetailsDTO AuthorizationDetails { get; set; }
    }
}
