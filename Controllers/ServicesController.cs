using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Infrastructure;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    ///<summary>
    ///     Servicios para guardar, eliminar, modificar y listar los servicios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Obtiene todos los servicios registrados
        /// </summary>
        /// <returns>Todos los servicios</returns>
        // GET: api/Services
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllServices()
        {
            IEnumerable<Service> servicesList = await _unitOfWork.ServicesRepository.GetAll();

            if (servicesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron servicios");
            }

            return ResponseFactory.CreateSuccessResponse(200, servicesList);  //Ok(_mapper.Map<IEnumerable<ServiceDto>>(servicesList));
        }

        /// <summary>
        ///     Obtiene un servicio de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del servicio</param>
        /// <returns>Los datos del servicio</returns>
        // GET: api/Services/1
        [HttpGet("{id}", Name = "GetServiceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var service = await _unitOfWork.ServicesRepository.GetById(s => s.SeviceId == id);
            if (service != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, service); //Ok(_mapper.Map<ServiceDto>(service));
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el servicio con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo servicio
        /// </summary>
        /// <returns>Nuevo servicio guardado correctamente</returns>
        /// <param name="serviceDto">Datos del servicio</param>
        // POST: api/Services
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostService([FromBody] ServiceDto serviceDto)
        {
            if (!ModelState.IsValid || serviceDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo servicio");
            }

            Service serviceModel = _mapper.Map<Service>(serviceDto);
            await _unitOfWork.ServicesRepository.Create(serviceModel);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo servicio guardado correctamente");  //CreatedAtRoute("GetServiceById", new { id = serviceDto.ServiceId }, serviceDto);
        }

        /// <summary>
        ///     Modifica un servicio
        /// </summary>
        /// <returns>El servicio se actualizó correctamente</returns>
        /// <param name="id">Id del servicio a modificar</param>
        /// <param name="serviceDto">Datos del servicio</param>
        // PUT: api/Services/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] ServiceDto serviceDto)
        {
            if (serviceDto == null || id != serviceDto.SeviceId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Service serviceModel = _mapper.Map<Service>(serviceDto);
            await _unitOfWork.ServicesRepository.Update(serviceModel);

            return ResponseFactory.CreateSuccessResponse(200, "El servicio se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un servicio
        /// </summary>
        /// <returns>El servicio se eliminó exitosamente</returns>
        /// <param name="id">Id del servicio a borrar</param>
        // DELETE: api/Services/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var service = await _unitOfWork.ServicesRepository.GetById(s => s.SeviceId == id);
            if (service != null)
            {
                service.IsActive = false;
                await _unitOfWork.ServicesRepository.Delete(service);
                return ResponseFactory.CreateSuccessResponse(200, "El servicio se eliminó exitosamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el servicio con ese código");
        }
    }
}
