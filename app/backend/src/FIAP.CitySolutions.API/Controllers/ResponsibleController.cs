using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.CitySolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleApp _responsibleApp;
        public ResponsibleController(IResponsibleApp responsibleApp)
        {
            _responsibleApp = responsibleApp;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _responsibleApp.GetAll();

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var response = await _responsibleApp.GetById(id);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost()]
        public async Task<ActionResult<ResponsibleDTO>> Save([FromBody] ResponsibleDTO responsible)
        {
            var response = await _responsibleApp.Save(responsible);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ResponsibleDTO responsible)
        {
            var response = await _responsibleApp.Update(responsible);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _responsibleApp.Delete(id);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
