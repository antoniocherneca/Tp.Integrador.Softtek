using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Helpers;
using Tp.Integrador.Softtek.Infrastructure;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    ///<summary>
    ///     Servicios para guardar, eliminar, modificar y listar los proyectos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Obtiene todos los proyectos registrados
        /// </summary>
        /// <returns>Todos los proyectos</returns>
        // GET: api/Projects
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllProjects()
        {
            var projectsList = await _unitOfWork.ProjectsRepository.GetAll();

            if (projectsList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron proyectos");
            }

            List<ProjectDto> projectsDtoList = _mapper.Map<List<ProjectDto>>(projectsList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProjects = PaginateHelper.Paginate(projectsDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProjects);
        }

        /// <summary>
        ///     Obtiene un proyecto de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Los datos del proyecto</returns>
        // GET: api/Projects/1
        [HttpGet("{id}", Name = "GetProjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var project = await _unitOfWork.ProjectsRepository.GetById(p => p.ProjectId == id);
            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);

            if (project != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, projectDto);
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el proyecto con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo proyecto
        /// </summary>
        /// <returns>Nuevo proyecto guardado correctamente</returns>
        /// <param name="projectCreateDto">Datos del proyecto</param>
        // POST: api/Projects
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostProject([FromBody] ProjectDto projectCreateDto)
        {
            if (!ModelState.IsValid || projectCreateDto == null)
            {
                ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo proyecto");
            }

            Project project = _mapper.Map<Project>(projectCreateDto);
            project.IsDeleted = false;
            await _unitOfWork.ProjectsRepository.Create(project);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo proyecto guardado correctamente");  //CreatedAtRoute("GetProjectById", new { id = projectDto.ProjectId }, projectDto);
        }

        /// <summary>
        ///     Modifica un proyecto
        /// </summary>
        /// <returns>El proyecto se actualizó correctamente</returns>
        /// <param name="id">Id del proyecto a modificar</param>
        /// <param name="projectUpdateDto">Datos del proyecto</param>
        // PUT: api/Projects/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] ProjectDto projectUpdateDto)
        {
            if (projectUpdateDto == null || id != projectUpdateDto.ProjectId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Project project = _mapper.Map<Project>(projectUpdateDto);
            await _unitOfWork.ProjectsRepository.Update(project);

            return ResponseFactory.CreateSuccessResponse(200, "El proyecto se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un proyecto
        /// </summary>
        /// <returns>El proyecto se eliminó exitosamente</returns>
        /// <param name="id">Id del proyecto a borrar</param>
        // DELETE: api/Projects/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var project = await _unitOfWork.ProjectsRepository.GetById(p => p.ProjectId == id);
            if (project != null)
            {
                project.IsDeleted = true;
                await _unitOfWork.ProjectsRepository.Delete(project);
                return ResponseFactory.CreateSuccessResponse(200, "El proyecto se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el proyecto con ese código");
        }
    }
}
