using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
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

        /// <summary> Obtiene todos los servicios </summary>
        /// <returns> Lista de todos los servicios </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
        {
            IEnumerable<Service> servicesList = await _unitOfWork.ServicesRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ServiceDto>>(servicesList));
        }

        /// <summary> Obtiene el servicio solicitado si es que existe </summary>
        /// <returns> Un servicio </returns>
        [HttpGet("{id}", Name = "GetServiceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var service = await _unitOfWork.ServicesRepository.GetById(s => s.SeviceId == id);
            if (service != null)
            {
                return Ok(_mapper.Map<ServiceDto>(service));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de servicio </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<ServiceDto>> PostService([FromBody] ServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (serviceDto == null)
            {
                return BadRequest(serviceDto);
            }

            Service serviceModel = _mapper.Map<Service>(serviceDto);
            await _unitOfWork.ServicesRepository.Create(serviceModel);

            return CreatedAtRoute("GetServiceById", new { id = serviceDto.SeviceId }, serviceDto);
        }

        /// <summary> Modifica un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutService(int id, [FromBody] ServiceDto serviceDto)
        {
            if (serviceDto == null || id != serviceDto.SeviceId)
            {
                return BadRequest();
            }

            Service serviceModel = _mapper.Map<Service>(serviceDto);
            await _unitOfWork.ServicesRepository.Update(serviceModel);

            return NoContent();
        }

        /// <summary> Elimina un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var service = await _unitOfWork.ServicesRepository.GetById(s => s.SeviceId == id);
            if (service != null)
            {
                service.IsActive = false;
                await _unitOfWork.ServicesRepository.Delete(service);
                return NoContent();
            }

            return NotFound();
        }
    }
}
