namespace PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi.Pessoa
{
    public class BeneficiarioFinalSicrediDTO : PessoaSicrediDTO
    {
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string numeroEndereco { get; set; }
        public string codigoBeneficiario { get; set; }
    }
}
