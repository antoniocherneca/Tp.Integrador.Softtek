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
            List<Service> servicesList = await _unitOfWork.ServicesRepository.GetAll();

            if (servicesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron servicios");
            }

            List<ServiceDto> servicesDtoList = _mapper.Map<List<ServiceDto>>(servicesList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServices = PaginateHelper.Paginate(servicesDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateServices);
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

            Service service = await _unitOfWork.ServicesRepository.GetById(s => s.ServiceId == id);
            ServiceDto serviceDto = _mapper.Map<ServiceDto>(service);

            if (service != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, serviceDto);
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el servicio con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo servicio
        /// </summary>
        /// <returns>Nuevo servicio guardado correctamente</returns>
        /// <param name="serviceCreateDto">Datos del servicio</param>
        // POST: api/Services
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostService([FromBody] ServiceCreateDto serviceCreateDto)
        {
            if (!ModelState.IsValid || serviceCreateDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo servicio");
            }

            Service service = _mapper.Map<Service>(serviceCreateDto);
            service.IsDeleted = false;
            await _unitOfWork.ServicesRepository.Create(service);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo servicio guardado correctamente");  //CreatedAtRoute("GetServiceById", new { id = serviceDto.ServiceId }, serviceDto);
        }

        /// <summary>
        ///     Modifica un servicio
        /// </summary>
        /// <returns>El servicio se actualizó correctamente</returns>
        /// <param name="id">Id del servicio a modificar</param>
        /// <param name="serviceUpdateDto">Datos del servicio</param>
        // PUT: api/Services/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] ServiceUpdateDto serviceUpdateDto)
        {
            if (serviceUpdateDto == null || id != serviceUpdateDto.ServiceId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Service service = _mapper.Map<Service>(serviceUpdateDto);
            await _unitOfWork.ServicesRepository.Update(service);

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

            var service = await _unitOfWork.ServicesRepository.GetById(s => s.ServiceId == id);
            if (service != null)
            {
                service.IsDeleted = true;
                await _unitOfWork.ServicesRepository.Delete(service);
                return ResponseFactory.CreateSuccessResponse(200, "El servicio se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el servicio con ese código");
        }
    }
}
