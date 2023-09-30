using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    public class UserNoPassDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public byte RoleId { get; set; }
    }
}
