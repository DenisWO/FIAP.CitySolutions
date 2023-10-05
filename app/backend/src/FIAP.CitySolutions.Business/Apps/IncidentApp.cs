using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Apps
{
    public class IncidentApp : App, IIncidentApp
    {
        private readonly IIncidentRepository _incidentRepository;
        public IncidentApp(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<AppResponse<bool>> Delete(Guid id)
        {
            try
            {
                //Realizando soft delete para manter integridade dos dados
                var incident = await _incidentRepository.GetById(id);
                incident.Active = false;

                await _incidentRepository.Commit();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return Error<bool>(ex);
            }
        }

        public async Task<AppResponse<List<IncidentDTO>>> GetAll()
        {
            try
            {
                var incidents = await _incidentRepository.GetAll();

                if (!incidents.Any())
                    return Error<List<IncidentDTO>>("Não foram encontrados responsáveis!");

                var incidentsDTO = Mapper.Map<List<IncidentDTO>>(incidents);

                return Ok(incidentsDTO);
            }
            catch (Exception ex)
            {
                return Error<List<IncidentDTO>>(ex);
            }
        }

        public async Task<AppResponse<IncidentDTO>> GetById(Guid id)
        {
            try
            {
                var incident = await _incidentRepository.GetById(id);

                var incidentDTO = Mapper.Map<IncidentDTO>(incident);

                return Ok(incidentDTO);
            }
            catch (Exception ex)
            {
                return Error<IncidentDTO>(ex);
            }
        }

        public async Task<AppResponse<IncidentDTO>> Save(IncidentDTO incidentDTO)
        {
            try
            {
                var incident = Mapper.Map<Incident>(incidentDTO);

                await _incidentRepository.Save(incident);
                await _incidentRepository.Commit();

                return Ok(incidentDTO);
            }
            catch (Exception ex)
            {
                return Error<IncidentDTO>(ex);
            }

        }

        public async Task<AppResponse<IncidentDTO>> Update(IncidentDTO incidentDTO)
        {
            try
            {
                var incident = await _incidentRepository.GetById(incidentDTO.Id);

                if (incident == null)
                    throw new Exception("Nenhum responsável encontrado!");

                incident = Mapper.Map(incidentDTO, incident);

                await _incidentRepository.Commit();

                return Ok(Mapper.Map<IncidentDTO>(incident));
            }
            catch (Exception ex)
            {
                return Error<IncidentDTO>(ex);
            }

        }
    }
}
