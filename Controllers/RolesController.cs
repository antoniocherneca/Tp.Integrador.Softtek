using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary> Obtiene todos los roles de usuario </summary>
        /// <returns> Lista de todos los roles de usuario </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
        {
            IEnumerable<Role> rolesList = await _unitOfWork.RolesRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<RoleDto>>(rolesList));
        }

        /// <summary> Obtiene el rol de usuario solicitado si es que existe </summary>
        /// <returns> Un rol </returns>
        [HttpGet("{id}", Name = "GetRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var role = await _unitOfWork.RolesRepository.GetById(r => r.RoleId == id);
            if (role != null)
            {
                return Ok(_mapper.Map<RoleDto>(role));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de rol de usuario </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<RoleDto>> PostRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (roleDto == null)
            {
                return BadRequest(roleDto);
            }

            Role roleModel = _mapper.Map<Role>(roleDto);
            await _unitOfWork.RolesRepository.Create(roleModel);

            return CreatedAtRoute("GetRoleById", new { id = roleDto.RoleId }, roleDto);
        }

        /// <summary> Modifica un registro de rol de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutRole(int id, [FromBody] RoleDto roleDto)
        {
            if (roleDto == null || id != roleDto.RoleId)
            {
                return BadRequest();
            }

            Role roleModel = _mapper.Map<Role>(roleDto);
            await _unitOfWork.RolesRepository.Update(roleModel);
            
            return NoContent();
        }

        /// <summary> Elimina un registro de rol de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var role = await _unitOfWork.RolesRepository.GetById(r => r.RoleId == id);
            if (role != null)
            {
                role.IsActive = false;
                await _unitOfWork.RolesRepository.Delete(role);
                return NoContent();
            }

            return NotFound();
        }
    }
}
