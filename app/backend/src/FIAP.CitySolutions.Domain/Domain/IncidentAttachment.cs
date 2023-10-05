namespace FIAP.CitySolutions.Domain.Domain
{
    public class IncidentAttachment : Entity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Incident Incident { get; set; }
        public Guid IncidentId { get; set; }
    }
}
