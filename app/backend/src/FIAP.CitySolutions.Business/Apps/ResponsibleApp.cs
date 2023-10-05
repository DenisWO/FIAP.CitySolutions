using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Business.Models.DTOs;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Apps
{
    public class ResponsibleApp: App, IResponsibleApp
    {
        private readonly IResponsibleRepository _responsibleRepository;
        public ResponsibleApp(IResponsibleRepository responsibleRepository)
        {
            _responsibleRepository = responsibleRepository;
        }

        public async Task<AppResponse<bool>> Delete(Guid id)
        {
            try
            {
                //Realizando soft delete para manter integridade dos dados
                var responsible = await _responsibleRepository.GetById(id);
                responsible.Active = false;

                await _responsibleRepository.Commit();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return Error<bool>(ex);
            }
        }

        public async Task<AppResponse<List<ResponsibleDTO>>> GetAll()
        {
            try
            {
                var responsibles = await _responsibleRepository.GetAll();

                if (!responsibles.Any())
                    return Error<List<ResponsibleDTO>>("Não foram encontrados responsáveis!");

                var responsiblesDTO = Mapper.Map<List<ResponsibleDTO>>(responsibles);

                return Ok(responsiblesDTO);
            }
            catch (Exception ex)
            {
                return Error<List<ResponsibleDTO>>(ex);
            }
        }

        public async Task<AppResponse<ResponsibleDTO>> GetById(Guid id)
        {
            try
            {
                var responsible = await _responsibleRepository.GetById(id);

                var responsibleDTO = Mapper.Map<ResponsibleDTO>(responsible);

                return Ok(responsibleDTO);
            }
            catch (Exception ex)
            {
                return Error<ResponsibleDTO>(ex);
            }
        }

        public async Task<AppResponse<ResponsibleDTO>> Save(ResponsibleDTO responsibleDTO)
        {
            try
            {
                var responsible = Mapper.Map<Responsible>(responsibleDTO);

                await _responsibleRepository.Save(responsible);
                await _responsibleRepository.Commit();

                return Ok(responsibleDTO);
            }
            catch (Exception ex)
            {
                return Error<ResponsibleDTO>(ex);
            }

        }

        public async Task<AppResponse<ResponsibleDTO>> Update(ResponsibleDTO responsibleDTO)
        {
            try
            {
                var responsible = await _responsibleRepository.GetById(responsibleDTO.Id);

                if (responsible == null)
                    throw new Exception("Nenhum responsável encontrado!");

                responsible = Mapper.Map(responsibleDTO, responsible);

                await _responsibleRepository.Commit();

                return Ok(Mapper.Map<ResponsibleDTO>(responsible));
            }
            catch (Exception ex)
            {
                return Error<ResponsibleDTO>(ex);
            }

        }
    }
}
