using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using FIAP.CitySolutions.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.CitySolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApp _userApp;
        public UserController(IUserApp userApp) 
        {
            _userApp = userApp;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _userApp.GetAll();

            return StatusCode((int) response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var response = await _userApp.GetById(id);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Save([FromBody] UserRegisterDTO userRegister)
        {
            var response = await _userApp.Save(userRegister);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var response = await _userApp.Login(userLoginDTO);
            
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            var response = await _userApp.Update(user);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _userApp.Delete(id);

            return StatusCode((int)response.StatusCode, response);
        }

    }
}
