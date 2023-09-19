using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary> Obtiene todos los trabajos </summary>
        /// <returns> Lista de todos los trabajos </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetAllJobs()
        {
            IEnumerable<Job> jobsList = await _unitOfWork.JobsRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<JobDto>>(jobsList));
        }

        /// <summary> Obtiene el trabajo solicitado si es que existe </summary>
        /// <returns> Un trabajo </returns>
        [HttpGet("{id:int}", Name = "GetJobById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var job = await _unitOfWork.JobsRepository.GetById(j => j.JobId == id);
            if (job != null)
            {
                return Ok(_mapper.Map<JobDto>(job));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de trabajo </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<JobDto>> PostJob([FromBody] JobDto jobDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (jobDto == null)
            {
                return BadRequest(jobDto);
            }

            Job jobModel = _mapper.Map<Job>(jobDto);
            await _unitOfWork.JobsRepository.Create(jobModel);

            return CreatedAtRoute("GetJobById", new { id = jobDto.JobId }, jobDto);
        }

        /// <summary> Modifica un registro de trabajo si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutJob(int id, [FromBody] JobDto jobDto)
        {
            if (jobDto == null || id != jobDto.JobId)
            {
                return BadRequest();
            }

            Job jobModel = _mapper.Map<Job>(jobDto);
            await _unitOfWork.JobsRepository.Update(jobModel);

            return NoContent();
        }

        /// <summary> Elimina un registro de trabajo si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteJob(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var job = await _unitOfWork.JobsRepository.GetById(j => j.JobId == id);
            if (job != null)
            {
                await _unitOfWork.JobsRepository.Delete(job);
                return NoContent();
            }

            return NotFound();
        }
    }
}
