using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAP.CitySolutions.Business.Apps
{
    public class UserApp : App, IUserApp
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserApp(IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AppResponse<bool>> Delete(Guid id)
        {
            try
            {
                //Realizando soft delete para manter integridade dos dados
                var user = await _userRepository.GetById(id);
                user.Active = false;

                await _userRepository.Commit();

                return Ok(true);
            }
            catch(Exception ex)
            {
                return Error<bool>(ex);
            }            
        }

        public async Task<AppResponse<List<UserDTO>>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();

                if (!users.Any())
                    return Ok<List<UserDTO>>();

                var usersDTO = Mapper.Map<List<UserDTO>>(users);

                return Ok(usersDTO);
            }
            catch(Exception ex)
            {
                return Error<List<UserDTO>>(ex);
            }
        }

        public async Task<AppResponse<UserDTO>> GetById(Guid id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                var userDTO = Mapper.Map<UserDTO>(user);

                return Ok(userDTO);
            }
            catch(Exception ex)
            {
                return Error<UserDTO>(ex);
            }
        }

        public async Task<AppResponse<UserDTO>> Save(UserDTO userDTO)
        {
            try
            {
                var user = Mapper.Map<User>(userDTO);

                await _userRepository.Save(user);
                await _userRepository.Commit();

                return Ok(userDTO);
            }
            catch(Exception ex)
            {
                return Error<UserDTO>(ex);
            }

        }

        public async Task<AppResponse<UserDTO>> Update(UserDTO userDTO)
        {
            try
            {
                var user = await _userRepository.GetById(userDTO.Id);

                if (user == null)
                    throw new Exception("Nenhum usuário encontrado!");

                user = Mapper.Map(userDTO, user);

                await _userRepository.Commit();

                return Ok(Mapper.Map<UserDTO>(user));
            }
            catch(Exception ex)
            {
                return Error<UserDTO>(ex);
            }

        }
        public async Task<AppResponse<UserToken>> Login(UserLoginDTO userLoginDTO)
        {
            //Criptografar a senha e validar com a criptografia ao invés da senha bruta
            var user = await _userRepository.FindFirst(u => u.Email == userLoginDTO.Email && u.Password == userLoginDTO.Password);

            if (user != null)
            {
                var token = BuildToken(userLoginDTO);
                
                return Ok(token);
            }

            return Error<UserToken>("Não foi possível completar o login");
        }
        private UserToken BuildToken(UserDTO user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
