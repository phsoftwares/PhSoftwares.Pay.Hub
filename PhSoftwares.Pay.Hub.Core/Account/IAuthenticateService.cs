namespace PhSoftwares.Pay.Hub.Core.Account
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string emailAddress, string password);
        Task<bool> UserExists(string emailAddress);
        public string GenerateToken(Guid id, string emailAddress);
    }
}
