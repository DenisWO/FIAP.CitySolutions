namespace FIAP.CitySolutions.Domain.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Incident> Incidents { get; set; }
    }
}
