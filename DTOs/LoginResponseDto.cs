using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek.DTOs
{
    public class LoginResponseDto
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
