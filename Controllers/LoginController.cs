using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Helpers;
using Tp.Integrador.Softtek.Services;

namespace Tp.Integrador.Softtek.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDto authDto)
        {
            var userCredentials = await _unitOfWork.UsersRepository.AuthenticateCredentials(authDto);
            if (userCredentials == null)
            {
                return Unauthorized("Las credenciales son incorrectas");
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
