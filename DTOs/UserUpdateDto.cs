using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }
    }
}
