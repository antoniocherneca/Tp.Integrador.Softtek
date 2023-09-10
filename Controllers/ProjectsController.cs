using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DataAccess.Repositories;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        /// <summary> Obtiene todos los proyectos </summary>
        /// <returns> Lista de todos los proyectos </returns>
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectsRepository.GetAll();
            if (projects != null)
            {
                return Ok(projects);
            }
            return NotFound("No se encontraron proyectos.");
        }

        /// <summary> Obtiene el proyecto solicitado si es que existe </summary>
        /// <returns> Un proyecto </returns>
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _projectsRepository.GetById(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound("No se encontró el proyecto.");
        }

        /// <summary> Crea un nuevo registro de proyecto </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostProject(Project project)
        {
            _projectsRepository.Create(project);
            return Created("", project);
        }

        /// <summary> Modifica un registro de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, Project updatedProject)
        {
            var project = _projectsRepository.GetById(id);
            if (project != null)
            {
                project.ProjectId = updatedProject.ProjectId;
                project.ProjectName = updatedProject.ProjectName;
                project.Address = updatedProject.Address;

                _projectsRepository.Update(project);
                return Ok("Se actualizó el proyecto correctamente.");
            }
            return NotFound("No se encontró el proyecto.");
        }

        /// <summary> Elimina un registro de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _projectsRepository.GetById(id);
            if (project != null)
            {
                _projectsRepository.Delete(id);
                return Ok("Se eliminó el proyecto correctamente.");
            }
            return NotFound("No se encontró el proyecto.");
        }
    }
}
