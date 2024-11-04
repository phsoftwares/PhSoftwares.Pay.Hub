namespace PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi
{
    public class SicrediAuthorizationDetailsDTO: AuthorizationDetailsDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string Cooperative { get; set; }
        public string Post { get; set; }
        public string RecipientCode { get; set; }
    }
}
