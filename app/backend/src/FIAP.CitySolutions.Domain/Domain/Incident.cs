namespace FIAP.CitySolutions.Domain.Domain
{
    public class Incident : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public IEnumerable<IncidentAttachment> Attachments { get; set; }
        public IncidentType IncidentType { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Responsible Responsible { get; set; }
        public Guid ResponsibleId { get; set; }
    }
    public enum IncidentType
    {
        BasicSanitation = 1,
        StreetLighting,
        Paving
    }
}
