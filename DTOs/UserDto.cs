using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Dni { get; set; }
        public byte Type { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
