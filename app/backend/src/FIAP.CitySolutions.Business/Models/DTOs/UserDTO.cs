using AutoMapper;
using FIAP.CitySolutions.Business.Models.DTOs.Mapping;
using FIAP.CitySolutions.Domain.Domain;
using System.ComponentModel.DataAnnotations;

namespace FIAP.CitySolutions.Business.Models.DTOs
{
    public class UserDTO : EntityDTO, IMapFrom<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDTO>().ReverseMap();
        }
    }
    public class UserRegisterDTO : UserLoginDTO, IMapFrom<User>
    {
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Documento não pode ter menos que 11 caracteres")]
        public string Document { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Confirmação de senha não pode ter menos que 8 caracteres")]
        public string ConfirmPassword { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
    public class UserLoginDTO : UserDTO, IMapFrom<User>
    {
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Senha não pode ter menos que 8 caracteres")]
        public string Password { get; set; }
    }
}
