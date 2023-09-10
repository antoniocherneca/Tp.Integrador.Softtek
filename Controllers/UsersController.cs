using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;
using Tp.Integrador.Softtek.DataAccess.Repositories.Interfaces;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        /// <summary> Obtiene todos los usuarios </summary>
        /// <returns> Lista de todos los usuarios </returns>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersRepository.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound("No se encontraron usuarios.");
        }

        /// <summary> Obtiene el usuario solicitado si es que existe </summary>
        /// <returns> Un usuario </returns>
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("No se encontró el usuario.");
        }

        /// <summary> Crea un nuevo registro de usuario </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _usersRepository.Create(user);
            return Created("", user);
        }

        /// <summary> Modifica un registro de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User updatedUser)
        {
            var user = _usersRepository.GetById(id);
            if (user != null)
            {
                user.UserId = updatedUser.UserId;
                user.UserName = updatedUser.UserName;
                user.Dni = updatedUser.Dni;
                user.Type = updatedUser.Type;
                user.Password = updatedUser.Password;

                _usersRepository.Update(user);
                return Ok("Se actualizó el usuario correctamente.");
            }
            return NotFound("No se encontró el usuario.");
        }

        /// <summary> Elimina un registro de usuario si es que existe </summary>
        /// <returns> Mensaje de confirmación </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user != null)
            {
                _usersRepository.Delete(id);
                return Ok("Se eliminó el usuario correctamente.");
            }
            return NotFound("No se encontró el usuario.");
        }
    }
}
