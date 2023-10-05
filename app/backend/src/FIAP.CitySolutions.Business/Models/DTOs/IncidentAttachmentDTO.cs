using AutoMapper;
using FIAP.CitySolutions.Business.Models.DTOs.Mapping;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Models.DTOs
{
    public class IncidentAttachmentDTO : EntityDTO, IMapFrom<IncidentAttachment>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public IncidentDTO Incident { get; set; }
        public Guid IncidentId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IncidentAttachment, IncidentAttachmentDTO>().ReverseMap();
        }
    }
}
