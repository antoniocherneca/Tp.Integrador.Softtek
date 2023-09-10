using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.ExceptionServices;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        /// <summary> Obtiene todos los roles </summary>
        /// <returns> Lista de todos los roles </returns>
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var role = _rolesRepository.GetAll();
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound("No se encontraron roles.");
        }

        /// <summary> Obtiene el rol solicitado si es que existe </summary>
        /// <returns> Un rol </returns>
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _rolesRepository.GetById(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound("No se encontró el rol.");
        }

        /// <summary> Crea un nuevo registro de rol </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostRole(Role role)
        {
            _rolesRepository.Create(role);
            return Created("", role);
        }

        /// <summary> Modifica un registro de rol si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutRole(int id, Role updatedRole)
        {
            var role = _rolesRepository.GetById(id);
            if (role != null)
            {
                role.RoleId = updatedRole.RoleId;
                role.RoleName = updatedRole.RoleName;

                _rolesRepository.Update(role);
                return Ok("Se actualizó el rol correctamente.");
            }
            return NotFound("No se encontró el rol.");
        }

        /// <summary> Elimina un registro de rol si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _rolesRepository.GetById(id);
            if (role != null)
            {
                _rolesRepository.Delete(id);
                return Ok("Se eliminó el rol correctamente.");
            }
            return NotFound("No se encontró el rol.");
        }
    }
}
