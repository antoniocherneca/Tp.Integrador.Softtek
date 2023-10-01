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
    ///     Servicios para guardar, eliminar, modificar y listar los trabajos
    /// </summary>
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

        /// <summary>
        ///     Obtiene todos los trabajos registrados
        /// </summary>
        /// <returns>Todos los trabajos</returns>
        // GET: api/Jobs
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllJobs()
        {
            List<Job> jobsList = await _unitOfWork.JobsRepository.GetAll();

            if (jobsList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron trabajos");
            }

            List<JobDto> jobsDtoList = _mapper.Map<List<JobDto>>(jobsList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateJobs = PaginateHelper.Paginate(jobsDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateJobs);
        }

        /// <summary>
        ///     Obtiene un trabajo de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id de la categoría</param>
        /// <returns>Los datos del trabajo</returns>
        // GET: api/Jobs/1
        [HttpGet("{id:int}", Name = "GetJobById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Job job = await _unitOfWork.JobsRepository.GetById(j => j.JobId == id);
            JobDto jobDto = _mapper.Map<JobDto>(job);

            if (job != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, jobDto);
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el trabajo con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo trabajo
        /// </summary>
        /// <returns>Nuevo trabajo guardado correctamente</returns>
        /// <param name="jobCreateDto">Datos del trabajo</param>
        // POST: api/Jobs
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostJob([FromBody] JobCreateDto jobCreateDto)
        {
            if (!ModelState.IsValid || jobCreateDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo trabajo");
            }

            Job job = _mapper.Map<Job>(jobCreateDto);
            job.IsDeleted = false;
            await _unitOfWork.JobsRepository.Create(job);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo trabajo guardado correctamente");   //CreatedAtRoute("GetJobById", new { id = jobDto.JobId }, jobDto);
        }

        /// <summary>
        ///     Modifica un trabajo
        /// </summary>
        /// <returns>El trabajo se actualizó correctamente</returns>
        /// <param name="id">Id del trabajo a modificar</param>
        /// <param name="jobUpdateDto">Datos del trabajo</param>
        // PUT: api/Jobs/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutJob([FromRoute] int id, [FromBody] JobUpdateDto jobUpdateDto)
        {
            if (jobUpdateDto == null || id != jobUpdateDto.JobId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Job job = _mapper.Map<Job>(jobUpdateDto);
            await _unitOfWork.JobsRepository.Update(job);

            return ResponseFactory.CreateSuccessResponse(200, "El trabajo se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un trabajo
        /// </summary>
        /// <returns>El trabajo se eliminó exitosamente</returns>
        /// <param name="id">Id del trabajo a borrar</param>
        // DELETE: api/Jobs/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var job = await _unitOfWork.JobsRepository.GetById(j => j.JobId == id);
            if (job != null)
            {
                job.IsDeleted = true;
                await _unitOfWork.JobsRepository.Delete(job);
                return ResponseFactory.CreateSuccessResponse(200, "El trabajo se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el trabajo con ese código");
        }
    }
}
