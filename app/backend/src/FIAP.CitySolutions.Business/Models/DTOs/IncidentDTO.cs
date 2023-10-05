using AutoMapper;
using FIAP.CitySolutions.Business.Models.DTOs.Mapping;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Models.DTOs
{
    public class IncidentDTO : EntityDTO, IMapFrom<Incident>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public IEnumerable<IncidentAttachment> Attachments { get; set; }
        public IncidentType IncidentType { get; set; }
        public UserDTO User { get; set; }
        public Guid UserId { get; set; }
        public ResponsibleDTO Responsible { get; set; }
        public Guid ResponsibleId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Incident, IncidentDTO>().ReverseMap();
        }
    }
}
