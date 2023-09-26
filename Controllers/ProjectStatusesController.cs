using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
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

        /// <summary> Obtiene todos los estados de proyecto </summary>
        /// <returns> Lista de todos los estados de proyecto </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProjectStatusDto>>> GetAllProjectStatuses()
        {
            IEnumerable<ProjectStatus> projectStatusesList = await _unitOfWork.ProjectStatusesRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProjectStatusDto>>(projectStatusesList));
        }

        /// <summary> Obtiene el estado de proyecto solicitado si es que existe </summary>
        /// <returns> Un usuario </returns>
        [HttpGet("{id}", Name = "GetProjectStatusesById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<ProjectStatusDto>> GetProjectStatus(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var projectStatuses = await _unitOfWork.ProjectStatusesRepository.GetById(ps => ps.ProjectStatusId == id);
            if (projectStatuses != null)
            {
                return Ok(_mapper.Map<ProjectStatusDto>(projectStatuses));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de estado de proyecto </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<ProjectStatusDto>> PostProjectStatus([FromBody] ProjectStatusDto projectStatusDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (projectStatusDto == null)
            {
                return BadRequest(projectStatusDto);
            }

            ProjectStatus projectStatusModel = _mapper.Map<ProjectStatus>(projectStatusDto);
            await _unitOfWork.ProjectStatusesRepository.Create(projectStatusModel);

            return CreatedAtRoute("GetProjectStatusById", new { id = projectStatusDto.ProjectStatusId }, projectStatusDto);
        }

        /// <summary> Modifica un registro de estado de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutProjectStatus(int id, [FromBody] ProjectStatusDto projectStatusDto)
        {
            if (projectStatusDto == null || id != projectStatusDto.ProjectStatusId)
            {
                return BadRequest();
            }

            ProjectStatus projectStatusModel = _mapper.Map<ProjectStatus>(projectStatusDto);
            await _unitOfWork.ProjectStatusesRepository.Update(projectStatusModel);
            
            return NoContent();
        }

        /// <summary> Elimina un registro de estado de proyecto si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteProjectStatus(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var projectStatus = await _unitOfWork.ProjectStatusesRepository.GetById(ps => ps.ProjectStatusId == id);
            if (projectStatus != null)
            {
                projectStatus.IsActive = false;
                await _unitOfWork.ProjectStatusesRepository.Delete(projectStatus);
                return NoContent();
            }

            return NotFound();
        }
    }
}
