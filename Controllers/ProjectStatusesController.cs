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
    ///     Servicios para guardar, eliminar, modificar y listar los estados de proyecto
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectStatusesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Obtiene todos los estados de proyecto registrados
        /// </summary>
        /// <returns>Todos los estados de proyecto</returns>
        // GET: api/ProjectStatuses
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllProjectStatuses()
        {
            List<ProjectStatus> projectStatusesList = await _unitOfWork.ProjectStatusesRepository.GetAll();

            if (projectStatusesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron estados de proyecto");
            }

            List<ProjectStatusDto> projectStatusesDtoList = _mapper.Map<List<ProjectStatusDto>>(projectStatusesList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateProjectStatuses = PaginateHelper.Paginate(projectStatusesDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateProjectStatuses);
        }

        /// <summary>
        ///     Obtiene un estado de proyecto de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del estado de proyecto</param>
        /// <returns>Los datos del estado de proyecto</returns>
        // GET: api/ProjectStatuses/1
        [HttpGet("{id}", Name = "GetProjectStatusesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetProjectStatus([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            ProjectStatus projectStatus = await _unitOfWork.ProjectStatusesRepository.GetById(ps => ps.ProjectStatusId == id);
            ProjectStatusDto projectStatusDto = _mapper.Map<ProjectStatusDto>(projectStatus);
            if (projectStatus != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, projectStatusDto);
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el estado de proyecto con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo estado de proyecto
        /// </summary>
        /// <returns>Nuevo estado de proyecto guardado correctamente</returns>
        /// <param name="projectStatusCreateDto">Datos del estado de proyecto</param>
        // POST: api/ProjectStatuses
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostProjectStatus([FromBody] ProjectStatusCreateDto projectStatusCreateDto)
        {
            if (!ModelState.IsValid || projectStatusCreateDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo estado de proyecto");
            }

            ProjectStatus projectStatus = _mapper.Map<ProjectStatus>(projectStatusCreateDto);
            projectStatus.IsDeleted = false;
            await _unitOfWork.ProjectStatusesRepository.Create(projectStatus);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo estado de proyecto guardado correctamente");  //CreatedAtRoute("GetProjectStatusById", new { id = projectStatusDto.ProjectStatusId }, projectStatusDto);
        }

        /// <summary>
        ///     Modifica un estado de proyecto
        /// </summary>
        /// <returns>El estado de proyecto se actualizó correctamente</returns>
        /// <param name="id">Id del estado de proyecto a modificar</param>
        /// <param name="projectStatusUpdateDto">Datos del estado de proyecto</param>
        // PUT: api/ProjectStatuses/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutProjectStatus([FromRoute] int id, [FromBody] ProjectStatusUpdateDto projectStatusUpdateDto)
        {
            if (projectStatusUpdateDto == null || id != projectStatusUpdateDto.ProjectStatusId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            ProjectStatus projectStatus = _mapper.Map<ProjectStatus>(projectStatusUpdateDto);
            await _unitOfWork.ProjectStatusesRepository.Update(projectStatus);

            return ResponseFactory.CreateSuccessResponse(200, "El estado de proyecto se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un estado de proyecto
        /// </summary>
        /// <returns>El estado de proyecto se eliminó exitosamente</returns>
        /// <param name="id">Id del estado de proyecto a borrar</param>
        // DELETE: api/ProjectStatuses/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteProjectStatus([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var projectStatus = await _unitOfWork.ProjectStatusesRepository.GetById(ps => ps.ProjectStatusId == id);
            if (projectStatus != null)
            {
                projectStatus.IsDeleted = true;
                await _unitOfWork.ProjectStatusesRepository.Delete(projectStatus);
                return ResponseFactory.CreateSuccessResponse(200, "El estado de proyecto se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el estado de proyecto con ese código");
        }
    }
}
