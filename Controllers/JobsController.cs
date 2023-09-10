using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DataAccess.Repositories;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        /// <summary> Obtiene todos los trabajos </summary>
        /// <returns> Lista de todos los trabajos </returns>
        [HttpGet]
        public IActionResult GetAllJobs()
        {
            var jobs = _jobsRepository.GetAll();
            if (jobs != null)
            {
                return Ok(jobs);
            }
            return NotFound("No se encontraron trabajos.");
        }

        /// <summary> Obtiene el trabajo solicitado si es que existe </summary>
        /// <returns> Un trabajo </returns>
        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _jobsRepository.GetById(id);
            if (job != null)
            {
                return Ok(job);
            }
            return NotFound("No se encontró el trabajo.");
        }

        /// <summary> Crea un nuevo registro de trabajo </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostJob(Job job)
        {
            _jobsRepository.Create(job);
            return Created("", job);
        }

        /// <summary> Modifica un registro de trabajo si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutJob(int id, Job updatedJob)
        {
            var job = _jobsRepository.GetById(id);
            if (job != null)
            {
                job.JobId = updatedJob.JobId;
                job.JobDate = updatedJob.JobDate;
                job.NumberOfHours = updatedJob.NumberOfHours;
                job.HourValue = updatedJob.HourValue;
                job.Cost = updatedJob.Cost;

                _jobsRepository.Update(job);
                return Ok("Se actualizó el trabajo correctamente.");
            }
            return NotFound("No se encontró el trabajo.");
        }

        /// <summary> Elimina un registro de trabajo si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var user = _jobsRepository.GetById(id);
            if (user != null)
            {
                _jobsRepository.Delete(id);
                return Ok("Se eliminó el trabajo correctamente.");
            }
            return NotFound("No se encontró el trabajo.");
        }
    }
}
