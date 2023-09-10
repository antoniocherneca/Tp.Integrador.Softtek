using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [Column(TypeName = "INT")]
        public int RoleId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string RoleName { get; set; }
    }
}
