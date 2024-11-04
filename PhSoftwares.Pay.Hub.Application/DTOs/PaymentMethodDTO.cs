using PhSoftwares.Pay.Hub.Application.Enums;

namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class PaymentMethodDTO
    {
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal IncreaseValue { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public FinancialInstitutionsEnum FinancialInstitutions { get; set; }
    }
}
