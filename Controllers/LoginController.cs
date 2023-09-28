using Microsoft.AspNetCore.Mvc;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Helpers;
using Tp.Integrador.Softtek.Infrastructure;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
    ///<summary>
    ///     Servicio para loguear un usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        ///     Permite loguear un usuario
        /// </summary>
        /// <returns>Los datos del usuario logueado</returns>
        /// <param name="authDto">Datos de autenticación del usuario</param>
        // POST: api/Jobs
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDto authDto)
        {
            var userCredentials = await _unitOfWork.UsersRepository.AuthenticateCredentials(authDto);
            if (userCredentials == null)
            {
                return ResponseFactory.CreateErrorResponse(401, "Las credenciales son incorrectas");
            }

            var token = _tokenJwtHelper.GenerateToken(userCredentials);
            var user = new UserLoginDto()
            {
                Email = userCredentials.Email,
                UserName = userCredentials.UserName,
                Token = token
            };

            return Ok(user);
        }
    }
}
