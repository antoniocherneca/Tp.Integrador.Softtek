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
            IEnumerable<User> usersList = await _unitOfWork.UsersRepository.GetAll();

            if (usersList == null)
            {
                return ResponseFactory.CreateErrorResponse(404, "No se encontraron usuarios");
            }

            return ResponseFactory.CreateSuccessResponse(200, usersList);  //Ok(_mapper.Map<IEnumerable<UserDto>>(usersList));
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

            var user = await _unitOfWork.UsersRepository.GetById(u => u.UserId == id);
            if (user != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, user);  //Ok(_mapper.Map<UserDto>(user));
            }

            return ResponseFactory.CreateErrorResponse(404, "No se encontró el usuario con ese código");
        }

        /// <summary>
        ///     Permite registrar un nuevo usuario
        /// </summary>
        /// <returns>Nuevo usuario guardado correctamente</returns>
        /// <param name="userDto">Datos del usuario</param>
        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid || userDto == null)
            {
                return ResponseFactory.CreateErrorResponse(400, "No se pudo guardar el nuevo usuario");
            }

            User userModel = _mapper.Map<User>(userDto);
            userModel.Password = PasswordEncryptHelper.EncryptPassword(userModel.Password, userModel.Email);
            await _unitOfWork.UsersRepository.Create(userModel);

            return ResponseFactory.CreateSuccessResponse(201, "Nuevo usuario guardado correctamente"); //CreatedAtRoute("GetUserById", new { id = userDto.UserId }, userDto);
        }

        /// <summary>
        ///     Modifica un usuario
        /// </summary>
        /// <returns>El usuario se actualizó correctamente</returns>
        /// <param name="id">Id del usuario a modificar</param>
        /// <param name="userDto">Datos del usuario</param>
        // PUT: api/Users/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] UserDto userDto)
        {
            if (userDto == null || id != userDto.UserId)
            {
                return ResponseFactory.CreateErrorResponse(400, "Los datos ingresados son incorrectos");
            }

            User userModel = _mapper.Map<User>(userDto);
            await _unitOfWork.UsersRepository.Update(userModel);

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
                user.IsActive = false;
                await _unitOfWork.UsersRepository.Delete(user);
                return ResponseFactory.CreateSuccessResponse(200, "El usuario se eliminó exitosamente");
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
            await _unitOfWork.UsersRepository.Insert(user);
            
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Usuario nuevo registrado correctamente");
        }
    }
}
