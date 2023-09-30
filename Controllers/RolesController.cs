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
            List<Role> rolesList = await _unitOfWork.RolesRepository.GetAll();

            if (rolesList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron roles de usuario");
            }

            List<RoleDto> rolesDtoList = _mapper.Map<List<RoleDto>>(rolesList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateRoles = PaginateHelper.Paginate(rolesDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateRoles);
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

            Role role = await _unitOfWork.RolesRepository.GetById(r => r.RoleId == id);
            RoleDto roleDto = _mapper.Map<RoleDto>(role);

            if (role != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, roleDto);  // Ok(_mapper.Map<RoleDto>(role));
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el rol de usuario con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo rol de usuario
        /// </summary>
        /// <returns>Nuevo rol de usuario guardado correctamente</returns>
        /// <param name="roleCreateDto">Datos del rol de usuario</param>
        // POST: api/Roles
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostRole([FromBody] RoleDto roleCreateDto)
        {
            if (!ModelState.IsValid || roleCreateDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo rol de usuario");
            }

            Role role = _mapper.Map<Role>(roleCreateDto);
            role.IsDeleted = false;
            await _unitOfWork.RolesRepository.Create(role);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo rol de usuario guardado correctamente");  //CreatedAtRoute("GetRoleById", new { id = roleDto.RoleId }, roleDto);
        }

        /// <summary>
        ///     Modifica un rol de usuario
        /// </summary>
        /// <returns>El rol de usuario se actualizó correctamente</returns>
        /// <param name="id">Id del rol de usuario a modificar</param>
        /// <param name="roleUpdateDto">Datos del rol de usuario</param>
        // PUT: api/Roles/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutRole([FromRoute] int id, [FromBody] RoleUpdateDto roleUpdateDto)
        {
            if (roleUpdateDto == null || id != roleUpdateDto.RoleId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            Role role = _mapper.Map<Role>(roleUpdateDto);
            await _unitOfWork.RolesRepository.Update(role);

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
                role.IsDeleted = true;
                await _unitOfWork.RolesRepository.Delete(role);
                return ResponseFactory.CreateSuccessResponse(200, "El rol de usuario se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el rol de usuario con ese código");
        }
    }
}
