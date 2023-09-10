using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DataAccess.Repositories;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        /// <summary> Obtiene todos los servicios </summary>
        /// <returns> Lista de todos los servicios </returns>
        [HttpGet]
        public IActionResult GetAllServices()
        {
            var services = _servicesRepository.GetAll();
            if (services != null)
            {
                return Ok(services);
            }
            return NotFound("No se encontraron servicios.");
        }

        /// <summary> Obtiene el servicio solicitado si es que existe </summary>
        /// <returns> Un servicio </returns>
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _servicesRepository.GetById(id);
            if (service != null)
            {
                return Ok(service);
            }
            return NotFound("No se encontró el servicio.");
        }

        /// <summary> Crea un nuevo registro de servicio </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostService(Service service)
        {
            _servicesRepository.Create(service);
            return Created("", service);
        }

        /// <summary> Modifica un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutService(int id, Service updatedService)
        {
            var service = _servicesRepository.GetById(id);
            if (service != null)
            {
                service.SeviceId = updatedService.SeviceId;
                service.Description = updatedService.Description;
                service.ServiceStatus = updatedService.ServiceStatus;
                service.HourValue = updatedService.HourValue;

                _servicesRepository.Update(service);
                return Ok("Se actualizó el servicio correctamente.");
            }
            return NotFound("No se encontró el servicio.");
        }

        /// <summary> Elimina un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _servicesRepository.GetById(id);
            if (service != null)
            {
                _servicesRepository.Delete(id);
                return Ok("Se eliminó el servicio correctamente.");
            }
            return NotFound("No se encontró el servicio.");
        }
    }
}
