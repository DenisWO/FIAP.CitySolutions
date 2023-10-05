using AutoMapper;

namespace FIAP.CitySolutions.Business.Models.DTOs.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
