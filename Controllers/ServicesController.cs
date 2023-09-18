﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public ServicesController(IServicesRepository servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        /// <summary> Obtiene todos los servicios </summary>
        /// <returns> Lista de todos los servicios </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
        {
            IEnumerable<Service> servicesList = await _servicesRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ServiceDto>>(servicesList));
        }

        /// <summary> Obtiene el servicio solicitado si es que existe </summary>
        /// <returns> Un servicio </returns>
        [HttpGet("{id}", Name = "GetServiceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var service = await _servicesRepository.GetById(s => s.SeviceId == id);
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
            await _servicesRepository.Create(serviceModel);

            return CreatedAtRoute("GetServiceById", new { id = serviceDto.SeviceId }, serviceDto);
        }

        /// <summary> Modifica un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutService(int id, [FromBody] ServiceDto serviceDto)
        {
            if (serviceDto == null || id != serviceDto.SeviceId)
            {
                return BadRequest();
            }

            Service serviceModel = _mapper.Map<Service>(serviceDto);
            await _servicesRepository.Update(serviceModel);

            return NoContent();
        }

        /// <summary> Elimina un registro de servicio si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var service = await _servicesRepository.GetById(s => s.SeviceId == id);
            if (service != null)
            {
                await _servicesRepository.Delete(service);
                return NoContent();
            }

            return NotFound();
        }
    }
}
