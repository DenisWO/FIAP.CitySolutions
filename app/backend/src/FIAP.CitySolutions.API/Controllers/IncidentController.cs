using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.CitySolutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentApp _incidentApp;
        public IncidentController(IIncidentApp incidentApp)
        {
            _incidentApp = incidentApp;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _incidentApp.GetAll();

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var response = await _incidentApp.GetById(id);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost()]
        public async Task<ActionResult<IncidentDTO>> Save([FromBody] IncidentDTO incident)
        {
            var response = await _incidentApp.Save(incident);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IncidentDTO incident)
        {
            var response = await _incidentApp.Update(incident);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _incidentApp.Delete(id);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
