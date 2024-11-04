namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil
{
    public class BoletoMultaBancoBrasilDTO
    {
        public int tipo { get; set; }
        public string dados { get; set; }
        public decimal porcentagem { get; set; }
        public decimal valor { get; set; }
    }
}
