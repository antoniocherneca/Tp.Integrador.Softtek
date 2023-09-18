using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        /// <summary> Obtiene todos los usuarios </summary>
        /// <returns> Lista de todos los usuarios </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            IEnumerable<User> usersList = await _usersRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersList));
        }

        /// <summary> Obtiene el usuario solicitado si es que existe </summary>
        /// <returns> Un usuario </returns>
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _usersRepository.GetById(u => u.UserId == id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }

            return NotFound();
        }

        /// <summary> Crea un nuevo registro de usuario </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDto>> PostUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userDto == null)
            {
                return BadRequest(userDto);
            }

            User userModel = _mapper.Map<User>(userDto);
            await _usersRepository.Create(userModel);

            return CreatedAtRoute("GetUserById", new { id = userDto.UserId }, userDto);
        }

        /// <summary> Modifica un registro de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null || id != userDto.UserId)
            {
                return BadRequest();
            }

            User userModel = _mapper.Map<User>(userDto);
            await _usersRepository.Update(userModel);
            
            return NoContent();
        }

        /// <summary> Elimina un registro de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _usersRepository.GetById(u => u.UserId == id);
            if (user != null)
            {
                await _usersRepository.Delete(user);
                return NoContent();
            }

            return NotFound();
        }
    }
}
