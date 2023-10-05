using AutoMapper;
using FIAP.CitySolutions.Business.Models.DTOs.Mapping;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Models.DTOs
{
    public class ResponsibleDTO : EntityDTO, IMapFrom<Responsible>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public IEnumerable<Incident> Incidents { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Responsible, ResponsibleDTO>().ReverseMap();
        }
    }
}
