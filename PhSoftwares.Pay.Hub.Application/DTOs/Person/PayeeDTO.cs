namespace PhSoftwares.Pay.Hub.Application.DTOs.Person
{
    public class PayeeDTO : PersonDTO
    {
        public string BankAgency { get; set; }
        public string BankAccount { get; set; }
        public int? AgreementNumber {get;set;}
        public int? WalletNumber { get; set;}
        public int? WalletVariationNumber { get; set;}
    }
}
