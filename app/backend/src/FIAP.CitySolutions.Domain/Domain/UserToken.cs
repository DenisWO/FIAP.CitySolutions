namespace FIAP.CitySolutions.Domain.Domain
{

    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
