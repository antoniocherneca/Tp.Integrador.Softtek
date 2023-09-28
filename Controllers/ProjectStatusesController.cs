using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
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
            IEnumerable<ProjectStatus> projectStatusesList = await _unitOfWork.ProjectStatusesRepository.GetAll();

            if (projectStatusesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron estados de proyecto");
            }

            return ResponseFactory.CreateSuccessResponse(200, projectStatusesList);  //Ok(_mapper.Map<IEnumerable<ProjectStatusDto>>(projectStatusesList));
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

            var projectStatuses = await _unitOfWork.ProjectStatusesRepository.GetById(ps => ps.ProjectStatusId == id);
            if (projectStatuses != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, projectStatuses);  //Ok(_mapper.Map<ProjectStatusDto>(projectStatuses));
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el estado de proyecto con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo estado de proyecto
        /// </summary>
        /// <returns>Nuevo estado de proyecto guardado correctamente</returns>
        /// <param name="projectStatusDto">Datos del estado de proyecto</param>
        // POST: api/ProjectStatuses
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostProjectStatus([FromBody] ProjectStatusDto projectStatusDto)
        {
            if (!ModelState.IsValid || projectStatusDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo estado de proyecto");
            }

            ProjectStatus projectStatusModel = _mapper.Map<ProjectStatus>(projectStatusDto);
            await _unitOfWork.ProjectStatusesRepository.Create(projectStatusModel);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo estado de proyecto guardado correctamente");  //CreatedAtRoute("GetProjectStatusById", new { id = projectStatusDto.ProjectStatusId }, projectStatusDto);
        }

        /// <summary>
        ///     Modifica un estado de proyecto
        /// </summary>
        /// <returns>El estado de proyecto se actualizó correctamente</returns>
        /// <param name="id">Id del estado de proyecto a modificar</param>
        /// <param name="projectStatusDto">Datos del estado de proyecto</param>
        // PUT: api/ProjectStatuses/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutProjectStatus([FromRoute] int id, [FromBody] ProjectStatusDto projectStatusDto)
        {
            if (projectStatusDto == null || id != projectStatusDto.ProjectStatusId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            ProjectStatus projectStatusModel = _mapper.Map<ProjectStatus>(projectStatusDto);
            await _unitOfWork.ProjectStatusesRepository.Update(projectStatusModel);

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
                projectStatus.IsActive = false;
                await _unitOfWork.ProjectStatusesRepository.Delete(projectStatus);
                return ResponseFactory.CreateSuccessResponse(200, "El estado de proyecto se eliminó exitosamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el estado de proyecto con ese código");
        }
    }
}
