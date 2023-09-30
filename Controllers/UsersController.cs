using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Entities;
using Tp.Integrador.Softtek.Helpers;
using Tp.Integrador.Softtek.Infrastructure;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    ///<summary>
    ///     Servicios para guardar, eliminar, modificar y listar los usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Obtiene todos los usuarios registrados
        /// </summary>
        /// <returns>Todos los usuarios</returns>
        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            List<User> usersList = await _unitOfWork.UsersRepository.GetAll();

            if (usersList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron usuarios");
            }

            List<UserNoPassDto> usersNoPassDtoList = _mapper.Map<List<UserNoPassDto>>(usersList);

            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsers = PaginateHelper.Paginate(usersNoPassDtoList, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }

        /// <summary>
        ///     Obtiene un usuario de acuerdo a su Id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Los datos del usuario</returns>
        // GET: api/Users/1
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            User user = await _unitOfWork.UsersRepository.GetById(u => u.UserId == id);
            UserDto userDto = _mapper.Map<UserDto>(user);

            if (user != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, userDto);
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el usuario con ese código");
        }

        /*
        /// <summary>
        ///     Permite registrar un nuevo usuario
        /// </summary>
        /// <returns>Nuevo usuario guardado correctamente</returns>
        /// <param name="userCreateDto">Datos del usuario</param>
        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostUser([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid || userCreateDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo usuario");
            }

            User user = _mapper.Map<User>(userCreateDto);
            user.IsDeleted = false;
            user.Password = PasswordEncryptHelper.EncryptPassword(user.Password, user.Email);
            await _unitOfWork.UsersRepository.Create(user);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo usuario guardado correctamente"); //CreatedAtRoute("GetUserById", new { id = userDto.UserId }, userDto);
        }
        */

        /// <summary>
        ///     Modifica un usuario
        /// </summary>
        /// <returns>El usuario se actualizó correctamente</returns>
        /// <param name="id">Id del usuario a modificar</param>
        /// <param name="userUpdateDto">Datos del usuario</param>
        // PUT: api/Users/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto == null || id != userUpdateDto.UserId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            User user = _mapper.Map<User>(userUpdateDto);
            await _unitOfWork.UsersRepository.Update(user);

            return ResponseFactory.CreateSuccessResponse(200, "El usuario se actualizó correctamente");
        }

        /// <summary>
        ///     Permite borrar un usuario
        /// </summary>
        /// <returns>El usuario se eliminó exitosamente</returns>
        /// <param name="id">Id del usuario a borrar</param>
        // DELETE: api/Users/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (id == 0)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            var user = await _unitOfWork.UsersRepository.GetById(u => u.UserId == id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _unitOfWork.UsersRepository.Delete(user);
                return ResponseFactory.CreateSuccessResponse(200, "El usuario se eliminó correctamente");
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el usuario con ese código");
        }

        /// <summary>
        ///     Permite registrar un usuario
        /// </summary>
        /// <returns>Usuario nuevo registrado correctamente</returns>
        /// <param name="registerDto">Datos del usuario</param>
        // DELETE: api/Users/Register
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(registerDto.RoleId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Registro incorrecto");
            }

            if (await _unitOfWork.UsersRepository.UserExist(registerDto.Email))
            {
                return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el e-mail {registerDto.Email}");
            }

            User user = new User(registerDto);
            user.IsDeleted = false;
            user.Password = PasswordEncryptHelper.EncryptPassword(user.Password, user.Email);
            await _unitOfWork.UsersRepository.Insert(user);
            
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Usuario nuevo registrado correctamente");
        }
    }
}
