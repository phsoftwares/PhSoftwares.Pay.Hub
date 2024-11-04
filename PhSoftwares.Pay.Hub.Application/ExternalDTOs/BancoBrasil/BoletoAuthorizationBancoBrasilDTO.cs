namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil
{
    public class BoletoAuthorizationBancoBrasilDTO
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
