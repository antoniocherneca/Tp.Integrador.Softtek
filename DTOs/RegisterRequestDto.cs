using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.DTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }

        public int Dni { get; set; }

        public int RoleId { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
