using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProjectsController(IProjectsRepository projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }

        /// <summary> Obtiene todos los proyectos </summary>
        /// <returns> Lista de todos los proyectos </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            IEnumerable<Project> projectsList = await _projectsRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projectsList));
        }

        /// <summary> Obtiene el proyecto solicitado si es que existe </summary>
        /// <returns> Un proyecto </returns>
        [HttpGet("{id}", Name = "GetProjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var project = await _projectsRepository.GetById(p => p.ProjectId == id);
            if (project != null)
            {
                return Ok(_mapper.Map<ProjectDto>(project));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de proyecto </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDto>> PostProject([FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (projectDto == null)
            {
                return BadRequest(projectDto);
            }

            Project projectModel = _mapper.Map<Project>(projectDto);
            await _projectsRepository.Create(projectModel);

            return CreatedAtRoute("GetProjectById", new { id = projectDto.ProjectId }, projectDto);
        }

        /// <summary> Modifica un registro de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProject(int id, [FromBody] ProjectDto projectDto)
        {
            if (projectDto == null || id != projectDto.ProjectId)
            {
                return BadRequest();
            }

            Project projectModel = _mapper.Map<Project>(projectDto);
            await _projectsRepository.Update(projectModel);

            return NoContent();
        }

        /// <summary> Elimina un registro de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var project = await _projectsRepository.GetById(p => p.ProjectId == id);
            if (project != null)
            {
                await _projectsRepository.Delete(project);
                return NoContent();
            }

            return NotFound();
        }
    }
}
