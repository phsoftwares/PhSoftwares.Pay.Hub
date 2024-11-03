using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Core.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal IncreaseValue { get; set; }
        public Guid PaymentTypeId { get; set; }
        public required PaymentType PaymentType { get; set; }  
        public Guid FinancialInstitutionId { get; set; }
        public required FinancialInstitution FinancialInstitution { get; set; }
        public Guid PayerId {  get; set; }
        public required Payer Payer { get; set; }
        public Guid RecipientId { get; set; }
        public required Recipient Recipient { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public Guid CreationUserId { get; set; }
    }
}
