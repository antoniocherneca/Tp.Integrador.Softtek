using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Roles")]
    public class Role
    {
        public Role()
        {
            
        }

        public Role(RoleDto roleDto)
        {
            this.RoleId = roleDto.RoleId;
            this.RoleName = roleDto.RoleName;
            this.IsActive = roleDto.IsActive;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [Column(TypeName = "VARCHAR(20)")]
        [MaxLength(20, ErrorMessage = "El nombre del rol es muy largo")]
        public string RoleName { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }
    }
}
