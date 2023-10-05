namespace FIAP.CitySolutions.Domain.Domain
{
    public class Responsible : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public IEnumerable<Incident> Incidents { get; set; }
    }
}
