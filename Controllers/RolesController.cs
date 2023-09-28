using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Infrastructure;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    ///<summary>
    ///     Servicios para guardar, eliminar, modificar y listar los roles de usuario
    /// </summary>
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

        /// <summary>
        ///     Obtiene todos los roles registrados
        /// </summary>
        /// <returns>Todos los roles</returns>
        // GET: api/Roles
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllRoles()
        {
            IEnumerable<Role> rolesList = await _unitOfWork.RolesRepository.GetAll();

            if (rolesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron roles de usuario");
            }

            return ResponseFactory.CreateSuccessResponse(200, rolesList);  //Ok(_mapper.Map<IEnumerable<RoleDto>>(rolesList));
        }

        /// <summary>
        ///     Obtiene un rol de usuario de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del rol de usuario</param>
        /// <returns>Los datos del rol de usuario</returns>
        // GET: api/Roles/1
        [HttpGet("{id}", Name = "GetRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetRole([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var role = await _unitOfWork.RolesRepository.GetById(r => r.RoleId == id);
            if (role != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, role);  // Ok(_mapper.Map<RoleDto>(role));
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el rol de usuario con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo rol de usuario
        /// </summary>
        /// <returns>Nuevo rol de usuario guardado correctamente</returns>
        /// <param name="roleDto">Datos del rol de usuario</param>
        // POST: api/Roles
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid || roleDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo rol de usuario");
            }

            Role roleModel = _mapper.Map<Role>(roleDto);
            await _unitOfWork.RolesRepository.Create(roleModel);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo rol de usuario guardado correctamente");  //CreatedAtRoute("GetRoleById", new { id = roleDto.RoleId }, roleDto);
        }

        /// <summary>
        ///     Modifica un rol de usuario
        /// </summary>
        /// <returns>El rol de usuario se actualizó correctamente</returns>
        /// <param name="id">Id del rol de usuario a modificar</param>
        /// <param name="roleDto">Datos del rol de usuario</param>
        // PUT: api/Roles/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutRole([FromRoute] int id, [FromBody] RoleDto roleDto)
        {
            if (roleDto == null || id != roleDto.RoleId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Role roleModel = _mapper.Map<Role>(roleDto);
            await _unitOfWork.RolesRepository.Update(roleModel);

            return ResponseFactory.CreateSuccessResponse(200, "El rol de usuario se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un rol de usuario
        /// </summary>
        /// <returns>El rol de usuario se eliminó exitosamente</returns>
        /// <param name="id">Id del rol de usuario a borrar</param>
        // DELETE: api/Roles/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var role = await _unitOfWork.RolesRepository.GetById(r => r.RoleId == id);
            if (role != null)
            {
                role.IsActive = false;
                await _unitOfWork.RolesRepository.Delete(role);
                return ResponseFactory.CreateSuccessResponse(200, "El rol de usuario se eliminó exitosamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el rol de usuario con ese código");
        }
    }
}
