using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;
using Tp.Integrador.Softtek.DataAccess.Repositories;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusesController : ControllerBase
    {
        private readonly IProjectStatusesRepository _projectStatusesRepository;

        public ProjectStatusesController(IProjectStatusesRepository projectStatusesRepository)
        {
            _projectStatusesRepository = projectStatusesRepository;
        }

        /// <summary> Obtiene todos los estados de proyecto </summary>
        /// <returns> Lista de todos los estados de proyecto </returns>
        [HttpGet]
        public IActionResult GetAllProjectStatuses()
        {
            var projectStatuses = _projectStatusesRepository.GetAll();
            if (projectStatuses != null)
            {
                return Ok(projectStatuses);
            }
            return NotFound("No se encontraron estados de proyecto.");
        }

        /// <summary> Obtiene el estado de proyecto solicitado si es que existe </summary>
        /// <returns> Un usuario </returns>
        [HttpGet("{id}")]
        public IActionResult GetProjectStatuses(int id)
        {
            var projectStatus = _projectStatusesRepository.GetById(id);
            if (projectStatus != null)
            {
                return Ok(projectStatus);
            }
            return NotFound("No se encontró el estado de proyecto.");
        }

        /// <summary> Crea un nuevo registro de estado de proyecto </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostProjectStatus(ProjectStatus projectStatus)
        {
            _projectStatusesRepository.Create(projectStatus);
            return Created("", projectStatus);
        }

        /// <summary> Modifica un registro de estado de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutProjectStatus(int id, ProjectStatus updatedProjectStatus)
        {
            var projectStatus = _projectStatusesRepository.GetById(id);
            if (projectStatus != null)
            {
                projectStatus.ProjectStatusId = updatedProjectStatus.ProjectStatusId;
                projectStatus.ProjectStatusDescription = updatedProjectStatus.ProjectStatusDescription;

                _projectStatusesRepository.Update(projectStatus);
                return Ok("Se actualizó el estado de proyecto correctamente.");
            }
            return NotFound("No se encontró el estado de proyecto.");
        }

        /// <summary> Elimina un registro de estado de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var projectStatus = _projectStatusesRepository.GetById(id);
            if (projectStatus != null)
            {
                _projectStatusesRepository.Delete(id);
                return Ok("Se eliminó el estado de proyecto correctamente.");
            }
            return NotFound("No se encontró el estado de proyecto.");
        }
    }
}
